namespace KeySender
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_shortcut = new System.Windows.Forms.Button();
			this.btn_shortcut2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_shortcut
			// 
			this.btn_shortcut.Location = new System.Drawing.Point(13, 13);
			this.btn_shortcut.Name = "btn_shortcut";
			this.btn_shortcut.Size = new System.Drawing.Size(221, 64);
			this.btn_shortcut.TabIndex = 1;
			this.btn_shortcut.Text = "Ctrl+Shift+B";
			this.btn_shortcut.UseVisualStyleBackColor = true;
			this.btn_shortcut.Click += new System.EventHandler(this.btn_shortcut_Click);
			// 
			// btn_shortcut2
			// 
			this.btn_shortcut2.Location = new System.Drawing.Point(13, 83);
			this.btn_shortcut2.Name = "btn_shortcut2";
			this.btn_shortcut2.Size = new System.Drawing.Size(221, 64);
			this.btn_shortcut2.TabIndex = 2;
			this.btn_shortcut2.Text = "B";
			this.btn_shortcut2.UseVisualStyleBackColor = true;
			this.btn_shortcut2.Click += new System.EventHandler(this.btn_shortcut2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 156);
			this.Controls.Add(this.btn_shortcut2);
			this.Controls.Add(this.btn_shortcut);
			this.Name = "Form1";
			this.Text = "Key checker";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btn_shortcut;
		private System.Windows.Forms.Button btn_shortcut2;
	}
}

