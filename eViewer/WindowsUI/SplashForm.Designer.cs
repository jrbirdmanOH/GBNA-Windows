namespace Thayer.Birding.UI.Windows
{
	partial class SplashForm
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
			this.infoLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// infoLabel
			// 
			this.infoLabel.BackColor = System.Drawing.Color.Transparent;
			this.infoLabel.Font = new System.Drawing.Font("Arial", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoLabel.ForeColor = System.Drawing.Color.White;
			this.infoLabel.Location = new System.Drawing.Point(11, 64);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(225, 110);
			this.infoLabel.TabIndex = 0;
			this.infoLabel.Text = "Version 7.0";
			// 
			// statusLabel
			// 
			this.statusLabel.BackColor = System.Drawing.Color.Transparent;
			this.statusLabel.Location = new System.Drawing.Point(15, 210);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(364, 27);
			this.statusLabel.TabIndex = 1;
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// SplashForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = global::Thayer.Birding.UI.Windows.Properties.Resources.SplashScreen;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(400, 236);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.infoLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SplashForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashForm";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.Label statusLabel;
	}
}