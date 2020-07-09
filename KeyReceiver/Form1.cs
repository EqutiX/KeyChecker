using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeyReceiver
{
	public partial class Form1 : Form
	{
		private static Form1 form1;
		private static LowLevelKeyboardProc _proc = HookCallback;
		private static IntPtr _hookID = IntPtr.Zero;
		private static bool shiftPressed;
		private static bool ctrlPressed;
		private static bool altPressed;
		private static bool recording;

		private const int WH_KEYBOARD_LL = 13;
		private const int WM_KEYDOWN = 0x0100;
		private const int WM_KEYUP = 0x0101;

		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		public Form1()
		{
			InitializeComponent();
			form1 = this;
		}

		private static IntPtr SetHook(LowLevelKeyboardProc proc)
		{
			using (var curProcess = Process.GetCurrentProcess())
			using (var curModule = curProcess.MainModule)
			{
				return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
			}
		}
		
		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			int vkCode = Marshal.ReadInt32(lParam);
			var enumContainsValue = Enum.IsDefined(typeof(VirtualKeyShort), (short)vkCode);
			var keyDown = wParam == (IntPtr) WM_KEYDOWN;
			var extraText = keyDown ? "pressed" : "released";

			if (enumContainsValue)
			{
				form1.textBox1.Text += $"{(VirtualKeyShort)vkCode} {extraText}\r\n";
			}
			else
			{
				form1.textBox1.Text += $"{vkCode} {extraText} Unknown key\r\n";
			}
			
			return CallNextHookEx(_hookID, nCode, wParam, lParam);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			if (recording) return;
			_hookID = SetHook(_proc);
			recording = true;
			Text = "***RECORDING KEYS***";
		}

		private void btn_quit_Click(object sender, EventArgs e)
		{
			if (!recording) return;
			UnhookWindowsHookEx(_hookID);
			recording = false;
			Text = "Key receiver";
		}

		private void btn_copy_Click(object sender, EventArgs e)
		{
			if (recording)
			{
				MessageBox.Show("Application is still tracking keyinput. Please stop tracking first.");
				return;
			}

			var clipboardThread = new Thread(CopyToClipboard);
			clipboardThread.SetApartmentState(ApartmentState.STA);
			clipboardThread.IsBackground = false;
			clipboardThread.Start();
		}

		private void CopyToClipboard()
		{
			if (string.IsNullOrEmpty(textBox1.Text)) return;
			Clipboard.SetText(textBox1.Text);
		}
	}
}
