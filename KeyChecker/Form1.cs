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
using WindowsInput;
using WindowsInput.Native;

namespace KeyChecker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btn_shortcut_Click(object sender, EventArgs e)
		{
			var sim = new InputSimulator();
			sim.Keyboard.Sleep(5000);
			sim.Keyboard.ModifiedKeyStroke(
				new[] {VirtualKeyCode.LCONTROL, VirtualKeyCode.LSHIFT },
				new[] {VirtualKeyCode.VK_B});
		}

		private void btn_shortcut2_Click(object sender, EventArgs e)
		{
			var sim = new InputSimulator();
			sim.Keyboard.Sleep(5000);

			sim.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
			sim.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
			sim.Keyboard.KeyDown(VirtualKeyCode.VK_B);
			sim.Keyboard.KeyUp(VirtualKeyCode.VK_B);
			sim.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);
			sim.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);
		}
	}
}
