namespace KeyReceiver
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btn_quit = new System.Windows.Forms.Button();
			this.btn_start = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 13);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(728, 399);
			this.textBox1.TabIndex = 0;
			// 
			// btn_quit
			// 
			this.btn_quit.Location = new System.Drawing.Point(191, 419);
			this.btn_quit.Name = "btn_quit";
			this.btn_quit.Size = new System.Drawing.Size(162, 55);
			this.btn_quit.TabIndex = 1;
			this.btn_quit.Text = "Stop tracking";
			this.btn_quit.UseVisualStyleBackColor = true;
			this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
			// 
			// btn_start
			// 
			this.btn_start.Location = new System.Drawing.Point(13, 419);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(162, 55);
			this.btn_start.TabIndex = 2;
			this.btn_start.Text = "Start tracking";
			this.btn_start.UseVisualStyleBackColor = true;
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 486);
			this.Controls.Add(this.btn_start);
			this.Controls.Add(this.btn_quit);
			this.Controls.Add(this.textBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Key receiver";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btn_quit;
		private System.Windows.Forms.Button btn_start;
	}
}

