namespace Thayer.Birding.ScreenSaver
{
	partial class ScreenSaverForm
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
			this.components = new System.ComponentModel.Container();
			this.screenSaverPictureBox = new System.Windows.Forms.PictureBox();
			this.commonNameLabel = new System.Windows.Forms.Label();
			this.captionLabel = new System.Windows.Forms.Label();
			this.copyrightLabel = new System.Windows.Forms.Label();
			this.imageTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.screenSaverPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// screenSaverPictureBox
			// 
			this.screenSaverPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.screenSaverPictureBox.Location = new System.Drawing.Point(0, 49);
			this.screenSaverPictureBox.Name = "screenSaverPictureBox";
			this.screenSaverPictureBox.Size = new System.Drawing.Size(773, 504);
			this.screenSaverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.screenSaverPictureBox.TabIndex = 0;
			this.screenSaverPictureBox.TabStop = false;
			// 
			// commonNameLabel
			// 
			this.commonNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.commonNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.commonNameLabel.ForeColor = System.Drawing.Color.White;
			this.commonNameLabel.Location = new System.Drawing.Point(0, 0);
			this.commonNameLabel.Name = "commonNameLabel";
			this.commonNameLabel.Size = new System.Drawing.Size(773, 46);
			this.commonNameLabel.TabIndex = 1;
			this.commonNameLabel.Text = "Common Name";
			this.commonNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// captionLabel
			// 
			this.captionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.captionLabel.AutoSize = true;
			this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captionLabel.ForeColor = System.Drawing.Color.White;
			this.captionLabel.Location = new System.Drawing.Point(12, 556);
			this.captionLabel.Name = "captionLabel";
			this.captionLabel.Size = new System.Drawing.Size(56, 17);
			this.captionLabel.TabIndex = 2;
			this.captionLabel.Text = "Caption";
			this.captionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// copyrightLabel
			// 
			this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.copyrightLabel.AutoSize = true;
			this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.copyrightLabel.ForeColor = System.Drawing.Color.White;
			this.copyrightLabel.Location = new System.Drawing.Point(702, 556);
			this.copyrightLabel.Name = "copyrightLabel";
			this.copyrightLabel.Size = new System.Drawing.Size(68, 17);
			this.copyrightLabel.TabIndex = 3;
			this.copyrightLabel.Text = "Copyright";
			this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.copyrightLabel.Resize += new System.EventHandler(this.copyrightLabel_Resize);
			// 
			// imageTimer
			// 
			this.imageTimer.Tick += new System.EventHandler(this.imageTimer_Tick);
			// 
			// ScreenSaverForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(773, 578);
			this.ControlBox = false;
			this.Controls.Add(this.copyrightLabel);
			this.Controls.Add(this.captionLabel);
			this.Controls.Add(this.commonNameLabel);
			this.Controls.Add(this.screenSaverPictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ScreenSaverForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Thayer Birding Software Screen Saver";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenSaverForm_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.screenSaverPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox screenSaverPictureBox;
		private System.Windows.Forms.Label commonNameLabel;
		private System.Windows.Forms.Label captionLabel;
		private System.Windows.Forms.Label copyrightLabel;
		private System.Windows.Forms.Timer imageTimer;
	}
}

