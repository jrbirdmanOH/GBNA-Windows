namespace Thayer.Birding.Updates.Downloader
{
	partial class DownloadForm
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
			System.Windows.Forms.Label downloadUpdatesLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
			this.checkForUpdatesLabel = new System.Windows.Forms.Label();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.downloadCompletedTimer = new System.Windows.Forms.Timer(this.components);
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.installButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.hideButton = new System.Windows.Forms.Button();
			this.checkForUpatesPanel = new System.Windows.Forms.Panel();
			this.checkForUpdatesPictureBox = new System.Windows.Forms.PictureBox();
			this.downloadUpdatesPanel = new System.Windows.Forms.Panel();
			this.percentCompleteLabel = new System.Windows.Forms.Label();
			this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
			this.downloadPictureBox = new System.Windows.Forms.PictureBox();
			this.installPanel = new System.Windows.Forms.Panel();
			this.installPictureBox = new System.Windows.Forms.PictureBox();
			this.installLabel = new System.Windows.Forms.Label();
			this.updatesAvailablePanel = new System.Windows.Forms.Panel();
			this.availableUpdatesPictureBox = new System.Windows.Forms.PictureBox();
			this.updatesAvailableLabel = new System.Windows.Forms.Label();
			this.downloader = new Thayer.Birding.Updates.UpdateDownloader();
			downloadUpdatesLabel = new System.Windows.Forms.Label();
			this.notifyIconContextMenuStrip.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.checkForUpatesPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkForUpdatesPictureBox)).BeginInit();
			this.downloadUpdatesPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.downloadPictureBox)).BeginInit();
			this.installPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.installPictureBox)).BeginInit();
			this.updatesAvailablePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.availableUpdatesPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// downloadUpdatesLabel
			// 
			downloadUpdatesLabel.AutoSize = true;
			downloadUpdatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			downloadUpdatesLabel.Location = new System.Drawing.Point(17, 68);
			downloadUpdatesLabel.Name = "downloadUpdatesLabel";
			downloadUpdatesLabel.Size = new System.Drawing.Size(119, 13);
			downloadUpdatesLabel.TabIndex = 15;
			downloadUpdatesLabel.Text = "Downloading updates...";
			// 
			// checkForUpdatesLabel
			// 
			this.checkForUpdatesLabel.AutoSize = true;
			this.checkForUpdatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkForUpdatesLabel.Location = new System.Drawing.Point(101, 41);
			this.checkForUpdatesLabel.Name = "checkForUpdatesLabel";
			this.checkForUpdatesLabel.Size = new System.Drawing.Size(117, 13);
			this.checkForUpdatesLabel.TabIndex = 8;
			this.checkForUpdatesLabel.Text = "Checking for updates...";
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Downloading Updates...";
			this.notifyIcon.Visible = true;
			this.notifyIcon.BalloonTipClosed += new System.EventHandler(this.notifyIcon_BalloonTipClosed);
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			this.notifyIcon.BalloonTipShown += new System.EventHandler(this.notifyIcon_BalloonTipShown);
			this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
			// 
			// notifyIconContextMenuStrip
			// 
			this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.installToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
			this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(106, 70);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// installToolStripMenuItem
			// 
			this.installToolStripMenuItem.Name = "installToolStripMenuItem";
			this.installToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.installToolStripMenuItem.Text = "Install";
			this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// downloadCompletedTimer
			// 
			this.downloadCompletedTimer.Interval = 600000;
			this.downloadCompletedTimer.Tick += new System.EventHandler(this.downloadCompletedTimer_Tick);
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.installButton);
			this.buttonPanel.Controls.Add(this.cancelButton);
			this.buttonPanel.Controls.Add(this.hideButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 149);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(384, 45);
			this.buttonPanel.TabIndex = 0;
			// 
			// installButton
			// 
			this.installButton.Location = new System.Drawing.Point(135, 10);
			this.installButton.Name = "installButton";
			this.installButton.Size = new System.Drawing.Size(75, 23);
			this.installButton.TabIndex = 0;
			this.installButton.Text = "Install";
			this.installButton.UseVisualStyleBackColor = true;
			this.installButton.Click += new System.EventHandler(this.installButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(297, 10);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// hideButton
			// 
			this.hideButton.Location = new System.Drawing.Point(216, 10);
			this.hideButton.Name = "hideButton";
			this.hideButton.Size = new System.Drawing.Size(75, 23);
			this.hideButton.TabIndex = 1;
			this.hideButton.Text = "Hide";
			this.hideButton.UseVisualStyleBackColor = true;
			this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
			// 
			// checkForUpatesPanel
			// 
			this.checkForUpatesPanel.BackColor = System.Drawing.Color.White;
			this.checkForUpatesPanel.Controls.Add(this.checkForUpdatesPictureBox);
			this.checkForUpatesPanel.Controls.Add(this.checkForUpdatesLabel);
			this.checkForUpatesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkForUpatesPanel.Location = new System.Drawing.Point(0, 0);
			this.checkForUpatesPanel.Name = "checkForUpatesPanel";
			this.checkForUpatesPanel.Size = new System.Drawing.Size(384, 194);
			this.checkForUpatesPanel.TabIndex = 10;
			// 
			// checkForUpdatesPictureBox
			// 
			this.checkForUpdatesPictureBox.Location = new System.Drawing.Point(20, 20);
			this.checkForUpdatesPictureBox.Name = "checkForUpdatesPictureBox";
			this.checkForUpdatesPictureBox.Size = new System.Drawing.Size(75, 55);
			this.checkForUpdatesPictureBox.TabIndex = 10;
			this.checkForUpdatesPictureBox.TabStop = false;
			// 
			// downloadUpdatesPanel
			// 
			this.downloadUpdatesPanel.BackColor = System.Drawing.Color.White;
			this.downloadUpdatesPanel.Controls.Add(downloadUpdatesLabel);
			this.downloadUpdatesPanel.Controls.Add(this.percentCompleteLabel);
			this.downloadUpdatesPanel.Controls.Add(this.downloadProgressBar);
			this.downloadUpdatesPanel.Controls.Add(this.downloadPictureBox);
			this.downloadUpdatesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.downloadUpdatesPanel.Location = new System.Drawing.Point(0, 0);
			this.downloadUpdatesPanel.Name = "downloadUpdatesPanel";
			this.downloadUpdatesPanel.Size = new System.Drawing.Size(384, 194);
			this.downloadUpdatesPanel.TabIndex = 11;
			// 
			// percentCompleteLabel
			// 
			this.percentCompleteLabel.Location = new System.Drawing.Point(142, 112);
			this.percentCompleteLabel.Name = "percentCompleteLabel";
			this.percentCompleteLabel.Size = new System.Drawing.Size(100, 23);
			this.percentCompleteLabel.TabIndex = 14;
			this.percentCompleteLabel.Text = "0% Complete";
			this.percentCompleteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// downloadProgressBar
			// 
			this.downloadProgressBar.Location = new System.Drawing.Point(20, 86);
			this.downloadProgressBar.Name = "downloadProgressBar";
			this.downloadProgressBar.Size = new System.Drawing.Size(344, 23);
			this.downloadProgressBar.Step = 1;
			this.downloadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.downloadProgressBar.TabIndex = 13;
			// 
			// downloadPictureBox
			// 
			this.downloadPictureBox.Location = new System.Drawing.Point(20, 20);
			this.downloadPictureBox.Name = "downloadPictureBox";
			this.downloadPictureBox.Size = new System.Drawing.Size(344, 33);
			this.downloadPictureBox.TabIndex = 11;
			this.downloadPictureBox.TabStop = false;
			// 
			// installPanel
			// 
			this.installPanel.BackColor = System.Drawing.Color.White;
			this.installPanel.Controls.Add(this.installPictureBox);
			this.installPanel.Controls.Add(this.installLabel);
			this.installPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.installPanel.Location = new System.Drawing.Point(0, 0);
			this.installPanel.Name = "installPanel";
			this.installPanel.Size = new System.Drawing.Size(384, 194);
			this.installPanel.TabIndex = 12;
			// 
			// installPictureBox
			// 
			this.installPictureBox.Location = new System.Drawing.Point(20, 20);
			this.installPictureBox.Name = "installPictureBox";
			this.installPictureBox.Size = new System.Drawing.Size(48, 48);
			this.installPictureBox.TabIndex = 1;
			this.installPictureBox.TabStop = false;
			// 
			// installLabel
			// 
			this.installLabel.Location = new System.Drawing.Point(76, 20);
			this.installLabel.Name = "installLabel";
			this.installLabel.Size = new System.Drawing.Size(296, 107);
			this.installLabel.TabIndex = 0;
			this.installLabel.Text = "Updates are ready to install.";
			// 
			// updatesAvailablePanel
			// 
			this.updatesAvailablePanel.BackColor = System.Drawing.Color.White;
			this.updatesAvailablePanel.Controls.Add(this.availableUpdatesPictureBox);
			this.updatesAvailablePanel.Controls.Add(this.updatesAvailableLabel);
			this.updatesAvailablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.updatesAvailablePanel.Location = new System.Drawing.Point(0, 0);
			this.updatesAvailablePanel.Name = "updatesAvailablePanel";
			this.updatesAvailablePanel.Size = new System.Drawing.Size(384, 194);
			this.updatesAvailablePanel.TabIndex = 13;
			// 
			// availableUpdatesPictureBox
			// 
			this.availableUpdatesPictureBox.Location = new System.Drawing.Point(20, 20);
			this.availableUpdatesPictureBox.Name = "availableUpdatesPictureBox";
			this.availableUpdatesPictureBox.Size = new System.Drawing.Size(48, 48);
			this.availableUpdatesPictureBox.TabIndex = 1;
			this.availableUpdatesPictureBox.TabStop = false;
			// 
			// updatesAvailableLabel
			// 
			this.updatesAvailableLabel.Location = new System.Drawing.Point(76, 32);
			this.updatesAvailableLabel.Name = "updatesAvailableLabel";
			this.updatesAvailableLabel.Size = new System.Drawing.Size(296, 89);
			this.updatesAvailableLabel.TabIndex = 0;
			this.updatesAvailableLabel.Text = "There are updates available";
			// 
			// downloader
			// 
			this.downloader.ApplicationName = "";
			this.downloader.ApplicationProcessID = null;
			this.downloader.Source = null;
			// 
			// DownloadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 194);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.downloadUpdatesPanel);
			this.Controls.Add(this.installPanel);
			this.Controls.Add(this.checkForUpatesPanel);
			this.Controls.Add(this.updatesAvailablePanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DownloadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thayer Birding Software Update";
			this.notifyIconContextMenuStrip.ResumeLayout(false);
			this.buttonPanel.ResumeLayout(false);
			this.checkForUpatesPanel.ResumeLayout(false);
			this.checkForUpatesPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkForUpdatesPictureBox)).EndInit();
			this.downloadUpdatesPanel.ResumeLayout(false);
			this.downloadUpdatesPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.downloadPictureBox)).EndInit();
			this.installPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.installPictureBox)).EndInit();
			this.updatesAvailablePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.availableUpdatesPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
		private UpdateDownloader downloader;
		private System.Windows.Forms.Timer downloadCompletedTimer;
		private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button installButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button hideButton;
		private System.Windows.Forms.Panel checkForUpatesPanel;
		private System.Windows.Forms.Panel downloadUpdatesPanel;
		private System.Windows.Forms.PictureBox checkForUpdatesPictureBox;
		private System.Windows.Forms.Label percentCompleteLabel;
		private System.Windows.Forms.ProgressBar downloadProgressBar;
		private System.Windows.Forms.PictureBox downloadPictureBox;
		private System.Windows.Forms.Panel installPanel;
		private System.Windows.Forms.Label installLabel;
		private System.Windows.Forms.Label checkForUpdatesLabel;
		private System.Windows.Forms.PictureBox installPictureBox;
		private System.Windows.Forms.Panel updatesAvailablePanel;
		private System.Windows.Forms.PictureBox availableUpdatesPictureBox;
		private System.Windows.Forms.Label updatesAvailableLabel;
	}
}