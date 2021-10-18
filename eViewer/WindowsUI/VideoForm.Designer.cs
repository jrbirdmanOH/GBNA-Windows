namespace Thayer.Birding.UI.Windows
{
	partial class VideoForm
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
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.stopButton = new System.Windows.Forms.Button();
			this.playButton = new System.Windows.Forms.Button();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoSize50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoSize100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoSize200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.videoPanel = new System.Windows.Forms.Panel();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.buttonPanel.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.stopButton);
			this.buttonPanel.Controls.Add(this.playButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 236);
			this.buttonPanel.MinimumSize = new System.Drawing.Size(175, 30);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(308, 30);
			this.buttonPanel.TabIndex = 1;
			// 
			// stopButton
			// 
			this.stopButton.Location = new System.Drawing.Point(84, 3);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(75, 23);
			this.stopButton.TabIndex = 1;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// playButton
			// 
			this.playButton.Location = new System.Drawing.Point(3, 3);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(75, 23);
			this.playButton.TabIndex = 0;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(308, 24);
			this.menuStrip.TabIndex = 2;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.playToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.playToolStripMenuItem.Text = "&Play/Pause";
			this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoSizeToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// videoSizeToolStripMenuItem
			// 
			this.videoSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoSize50ToolStripMenuItem,
            this.videoSize100ToolStripMenuItem,
            this.videoSize200ToolStripMenuItem});
			this.videoSizeToolStripMenuItem.Name = "videoSizeToolStripMenuItem";
			this.videoSizeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.videoSizeToolStripMenuItem.Text = "Video Si&ze";
			// 
			// videoSize50ToolStripMenuItem
			// 
			this.videoSize50ToolStripMenuItem.Name = "videoSize50ToolStripMenuItem";
			this.videoSize50ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
			this.videoSize50ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.videoSize50ToolStripMenuItem.Text = "50%";
			this.videoSize50ToolStripMenuItem.Click += new System.EventHandler(this.videoSize50ToolStripMenuItem_Click);
			// 
			// videoSize100ToolStripMenuItem
			// 
			this.videoSize100ToolStripMenuItem.Name = "videoSize100ToolStripMenuItem";
			this.videoSize100ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
			this.videoSize100ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.videoSize100ToolStripMenuItem.Text = "100%";
			this.videoSize100ToolStripMenuItem.Click += new System.EventHandler(this.videoSize100ToolStripMenuItem_Click);
			// 
			// videoSize200ToolStripMenuItem
			// 
			this.videoSize200ToolStripMenuItem.Name = "videoSize200ToolStripMenuItem";
			this.videoSize200ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
			this.videoSize200ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.videoSize200ToolStripMenuItem.Text = "200%";
			this.videoSize200ToolStripMenuItem.Click += new System.EventHandler(this.videoSize200ToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.videoPanel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(308, 212);
			this.panel1.TabIndex = 3;
			// 
			// videoPanel
			// 
			this.videoPanel.Location = new System.Drawing.Point(12, 3);
			this.videoPanel.Name = "videoPanel";
			this.videoPanel.Size = new System.Drawing.Size(284, 203);
			this.videoPanel.TabIndex = 0;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// VideoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(308, 266);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.menuStrip);
			this.helpProvider.SetHelpKeyword(this, "46");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "VideoForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Video";
			this.buttonPanel.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem videoSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem videoSize50ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem videoSize100ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem videoSize200ToolStripMenuItem;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel videoPanel;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}