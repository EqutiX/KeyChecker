using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KeyReceiver
{
	public partial class Form1 : Form
	{
		private static Form1 form1;
		private static LowLevelKeyboardProc _proc = HookCallback;
		private static IntPtr _hookID = IntPtr.Zero;

		private const int WH_KEYBOARD_LL = 13;
		private const int WM_KEYDOWN = 0x0100;

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
			if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN)
			{
				int vkCode = Marshal.ReadInt32(lParam);
				var key = (char) vkCode;

			}

			form1.textBox1.Text += $"\r\n{wParam} {Marshal.ReadInt32(lParam)} {wParam == (IntPtr) WM_KEYDOWN}";

			return CallNextHookEx(_hookID, nCode, wParam, lParam);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_hookID = SetHook(_proc);
		}

		private void btn_quit_Click(object sender, EventArgs e)
		{
			UnhookWindowsHookEx(_hookID);
		}
	}
}
