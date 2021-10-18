namespace Thayer.Birding.UI.Windows
{
	partial class MediaPlayer
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
			if (disposing)
			{
				if (audio != null)
				{
					audio.Dispose();
				}

				if (video != null)
				{
					video.Dispose();
				}

				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPlayer));
			this.videoPanel = new System.Windows.Forms.Panel();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.zoomOutButton = new System.Windows.Forms.Button();
			this.buttonImageList = new System.Windows.Forms.ImageList(this.components);
			this.zoomInButton = new System.Windows.Forms.Button();
			this.loopCheckBox = new System.Windows.Forms.CheckBox();
			this.mediaProgressBar = new System.Windows.Forms.ProgressBar();
			this.stopButton = new System.Windows.Forms.Button();
			this.playPauseButton = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.buttonPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// videoPanel
			// 
			this.videoPanel.Location = new System.Drawing.Point(10, 6);
			this.videoPanel.Name = "videoPanel";
			this.videoPanel.Size = new System.Drawing.Size(449, 214);
			this.videoPanel.TabIndex = 0;
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.zoomOutButton);
			this.buttonPanel.Controls.Add(this.zoomInButton);
			this.buttonPanel.Controls.Add(this.loopCheckBox);
			this.buttonPanel.Controls.Add(this.mediaProgressBar);
			this.buttonPanel.Controls.Add(this.stopButton);
			this.buttonPanel.Controls.Add(this.playPauseButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 318);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(482, 37);
			this.buttonPanel.TabIndex = 1;
			// 
			// zoomOutButton
			// 
			this.zoomOutButton.AutoSize = true;
			this.zoomOutButton.ImageKey = "ZoomOut";
			this.zoomOutButton.ImageList = this.buttonImageList;
			this.zoomOutButton.Location = new System.Drawing.Point(272, 8);
			this.zoomOutButton.Name = "zoomOutButton";
			this.zoomOutButton.Size = new System.Drawing.Size(23, 23);
			this.zoomOutButton.TabIndex = 4;
			this.toolTip.SetToolTip(this.zoomOutButton, "Zoom Out");
			this.zoomOutButton.UseVisualStyleBackColor = true;
			this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
			// 
			// buttonImageList
			// 
			this.buttonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonImageList.ImageStream")));
			this.buttonImageList.TransparentColor = System.Drawing.Color.Magenta;
			this.buttonImageList.Images.SetKeyName(0, "Play");
			this.buttonImageList.Images.SetKeyName(1, "Pause");
			this.buttonImageList.Images.SetKeyName(2, "Stop");
			this.buttonImageList.Images.SetKeyName(3, "ZoomIn");
			this.buttonImageList.Images.SetKeyName(4, "ZoomOut");
			// 
			// zoomInButton
			// 
			this.zoomInButton.AutoSize = true;
			this.zoomInButton.ImageKey = "ZoomIn";
			this.zoomInButton.ImageList = this.buttonImageList;
			this.zoomInButton.Location = new System.Drawing.Point(301, 8);
			this.zoomInButton.Name = "zoomInButton";
			this.zoomInButton.Size = new System.Drawing.Size(23, 23);
			this.zoomInButton.TabIndex = 5;
			this.toolTip.SetToolTip(this.zoomInButton, "Zoom In");
			this.zoomInButton.UseVisualStyleBackColor = true;
			this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
			// 
			// loopCheckBox
			// 
			this.loopCheckBox.AutoSize = true;
			this.loopCheckBox.Location = new System.Drawing.Point(213, 12);
			this.loopCheckBox.Name = "loopCheckBox";
			this.loopCheckBox.Size = new System.Drawing.Size(50, 17);
			this.loopCheckBox.TabIndex = 3;
			this.loopCheckBox.Text = "Loop";
			this.toolTip.SetToolTip(this.loopCheckBox, "Loop");
			this.loopCheckBox.UseVisualStyleBackColor = true;
			// 
			// mediaProgressBar
			// 
			this.mediaProgressBar.Location = new System.Drawing.Point(72, 11);
			this.mediaProgressBar.Name = "mediaProgressBar";
			this.mediaProgressBar.Size = new System.Drawing.Size(135, 18);
			this.mediaProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.mediaProgressBar.TabIndex = 2;
			// 
			// stopButton
			// 
			this.stopButton.ImageKey = "Stop";
			this.stopButton.ImageList = this.buttonImageList;
			this.stopButton.Location = new System.Drawing.Point(39, 8);
			this.stopButton.Name = "stopButton";
			this.stopButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
			this.stopButton.Size = new System.Drawing.Size(23, 23);
			this.stopButton.TabIndex = 1;
			this.toolTip.SetToolTip(this.stopButton, "Stop");
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// playPauseButton
			// 
			this.playPauseButton.ImageKey = "Play";
			this.playPauseButton.ImageList = this.buttonImageList;
			this.playPauseButton.Location = new System.Drawing.Point(10, 8);
			this.playPauseButton.Name = "playPauseButton";
			this.playPauseButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
			this.playPauseButton.Size = new System.Drawing.Size(23, 23);
			this.playPauseButton.TabIndex = 0;
			this.toolTip.SetToolTip(this.playPauseButton, "Play");
			this.playPauseButton.UseVisualStyleBackColor = true;
			this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(10, 236);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(51, 41);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.videoPanel);
			this.mainPanel.Controls.Add(this.pictureBox);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(482, 318);
			this.mainPanel.TabIndex = 0;
			// 
			// MediaPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.buttonPanel);
			this.Name = "MediaPlayer";
			this.Size = new System.Drawing.Size(482, 355);
			this.Load += new System.EventHandler(this.MediaPlayer_Load);
			this.Resize += new System.EventHandler(this.MediaPlayer_Resize);
			this.buttonPanel.ResumeLayout(false);
			this.buttonPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.mainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel videoPanel;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button playPauseButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.ProgressBar mediaProgressBar;
		private System.Windows.Forms.CheckBox loopCheckBox;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Button zoomOutButton;
		private System.Windows.Forms.Button zoomInButton;
		private System.Windows.Forms.ImageList buttonImageList;
		private System.Windows.Forms.ToolTip toolTip;
	}
}
