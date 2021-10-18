namespace Thayer.Birding.Updates.Installer
{
	partial class InstallForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallForm));
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.hideButton = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.installingUpdatesPanel = new System.Windows.Forms.Panel();
			this.percentCompleteLabel = new System.Windows.Forms.Label();
			this.installingUpdatesLabel = new System.Windows.Forms.Label();
			this.installProgressBar = new System.Windows.Forms.ProgressBar();
			this.installer = new Thayer.Birding.Updates.UpdateInstaller();
			this.buttonPanel.SuspendLayout();
			this.notifyIconContextMenuStrip.SuspendLayout();
			this.installingUpdatesPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.hideButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 149);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(384, 45);
			this.buttonPanel.TabIndex = 0;
			// 
			// hideButton
			// 
			this.hideButton.Location = new System.Drawing.Point(297, 10);
			this.hideButton.Name = "hideButton";
			this.hideButton.Size = new System.Drawing.Size(75, 23);
			this.hideButton.TabIndex = 0;
			this.hideButton.Text = "Hide";
			this.hideButton.UseVisualStyleBackColor = true;
			this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Installing Updates...";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			// 
			// notifyIconContextMenuStrip
			// 
			this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
			this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(104, 26);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// installingUpdatesPanel
			// 
			this.installingUpdatesPanel.BackColor = System.Drawing.Color.White;
			this.installingUpdatesPanel.Controls.Add(this.percentCompleteLabel);
			this.installingUpdatesPanel.Controls.Add(this.installingUpdatesLabel);
			this.installingUpdatesPanel.Controls.Add(this.installProgressBar);
			this.installingUpdatesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.installingUpdatesPanel.Location = new System.Drawing.Point(0, 0);
			this.installingUpdatesPanel.Name = "installingUpdatesPanel";
			this.installingUpdatesPanel.Size = new System.Drawing.Size(384, 194);
			this.installingUpdatesPanel.TabIndex = 2;
			// 
			// percentCompleteLabel
			// 
			this.percentCompleteLabel.Location = new System.Drawing.Point(142, 88);
			this.percentCompleteLabel.Name = "percentCompleteLabel";
			this.percentCompleteLabel.Size = new System.Drawing.Size(100, 23);
			this.percentCompleteLabel.TabIndex = 2;
			this.percentCompleteLabel.Text = "0% Complete";
			this.percentCompleteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// installingUpdatesLabel
			// 
			this.installingUpdatesLabel.AutoSize = true;
			this.installingUpdatesLabel.Location = new System.Drawing.Point(20, 44);
			this.installingUpdatesLabel.Name = "installingUpdatesLabel";
			this.installingUpdatesLabel.Size = new System.Drawing.Size(98, 13);
			this.installingUpdatesLabel.TabIndex = 1;
			this.installingUpdatesLabel.Text = "Installing updates...";
			// 
			// installProgressBar
			// 
			this.installProgressBar.Location = new System.Drawing.Point(20, 62);
			this.installProgressBar.Name = "installProgressBar";
			this.installProgressBar.Size = new System.Drawing.Size(344, 23);
			this.installProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.installProgressBar.TabIndex = 0;
			// 
			// installer
			// 
			this.installer.ApplicationName = "";
			this.installer.ApplicationProcessID = null;
			// 
			// InstallForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 194);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.installingUpdatesPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InstallForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thayer Birding Software Update";
			this.buttonPanel.ResumeLayout(false);
			this.notifyIconContextMenuStrip.ResumeLayout(false);
			this.installingUpdatesPanel.ResumeLayout(false);
			this.installingUpdatesPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button hideButton;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.Panel installingUpdatesPanel;
		private System.Windows.Forms.ProgressBar installProgressBar;
		private System.Windows.Forms.Label installingUpdatesLabel;
		private System.Windows.Forms.Label percentCompleteLabel;
		private Thayer.Birding.Updates.UpdateInstaller installer;

	}
}