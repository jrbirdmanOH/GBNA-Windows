namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class PickOneMediaPlayer
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickOneMediaPlayer));
			this.buttonImageList = new System.Windows.Forms.ImageList(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.loopCheckBox = new System.Windows.Forms.CheckBox();
			this.stopButton = new System.Windows.Forms.Button();
			this.playPauseButton = new System.Windows.Forms.Button();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.mediaProgressBar = new System.Windows.Forms.ProgressBar();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.topSplitContainer = new System.Windows.Forms.SplitContainer();
			this.topLeftPictureButton = new System.Windows.Forms.Button();
			this.topRightPictureButton = new System.Windows.Forms.Button();
			this.bottomSplitContainer = new System.Windows.Forms.SplitContainer();
			this.bottomLeftPictureButton = new System.Windows.Forms.Button();
			this.bottomRightPictureButton = new System.Windows.Forms.Button();
			this.buttonPanel.SuspendLayout();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.topSplitContainer.Panel1.SuspendLayout();
			this.topSplitContainer.Panel2.SuspendLayout();
			this.topSplitContainer.SuspendLayout();
			this.bottomSplitContainer.Panel1.SuspendLayout();
			this.bottomSplitContainer.Panel2.SuspendLayout();
			this.bottomSplitContainer.SuspendLayout();
			this.SuspendLayout();
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
			// loopCheckBox
			// 
			this.loopCheckBox.AutoSize = true;
			this.loopCheckBox.Location = new System.Drawing.Point(213, 8);
			this.loopCheckBox.Name = "loopCheckBox";
			this.loopCheckBox.Size = new System.Drawing.Size(50, 17);
			this.loopCheckBox.TabIndex = 3;
			this.loopCheckBox.Text = "Loop";
			this.toolTip.SetToolTip(this.loopCheckBox, "Loop");
			this.loopCheckBox.UseVisualStyleBackColor = true;
			// 
			// stopButton
			// 
			this.stopButton.ImageKey = "Stop";
			this.stopButton.ImageList = this.buttonImageList;
			this.stopButton.Location = new System.Drawing.Point(39, 4);
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
			this.playPauseButton.Location = new System.Drawing.Point(10, 4);
			this.playPauseButton.Name = "playPauseButton";
			this.playPauseButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
			this.playPauseButton.Size = new System.Drawing.Size(23, 23);
			this.playPauseButton.TabIndex = 0;
			this.toolTip.SetToolTip(this.playPauseButton, "Play");
			this.playPauseButton.UseVisualStyleBackColor = true;
			this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.loopCheckBox);
			this.buttonPanel.Controls.Add(this.mediaProgressBar);
			this.buttonPanel.Controls.Add(this.stopButton);
			this.buttonPanel.Controls.Add(this.playPauseButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 324);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(482, 31);
			this.buttonPanel.TabIndex = 0;
			// 
			// mediaProgressBar
			// 
			this.mediaProgressBar.Location = new System.Drawing.Point(72, 7);
			this.mediaProgressBar.Name = "mediaProgressBar";
			this.mediaProgressBar.Size = new System.Drawing.Size(135, 18);
			this.mediaProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.mediaProgressBar.TabIndex = 2;
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.IsSplitterFixed = true;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.mainSplitContainer.Name = "mainSplitContainer";
			this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.topSplitContainer);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.bottomSplitContainer);
			this.mainSplitContainer.Size = new System.Drawing.Size(482, 324);
			this.mainSplitContainer.SplitterDistance = 172;
			this.mainSplitContainer.TabIndex = 4;
			this.mainSplitContainer.TabStop = false;
			this.mainSplitContainer.Resize += new System.EventHandler(this.splitContainer_Resize);
			// 
			// topSplitContainer
			// 
			this.topSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topSplitContainer.IsSplitterFixed = true;
			this.topSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.topSplitContainer.Name = "topSplitContainer";
			// 
			// topSplitContainer.Panel1
			// 
			this.topSplitContainer.Panel1.Controls.Add(this.topLeftPictureButton);
			// 
			// topSplitContainer.Panel2
			// 
			this.topSplitContainer.Panel2.Controls.Add(this.topRightPictureButton);
			this.topSplitContainer.Size = new System.Drawing.Size(482, 172);
			this.topSplitContainer.SplitterDistance = 220;
			this.topSplitContainer.TabIndex = 0;
			this.topSplitContainer.TabStop = false;
			this.topSplitContainer.Resize += new System.EventHandler(this.splitContainer_Resize);
			// 
			// topLeftPictureButton
			// 
			this.topLeftPictureButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.topLeftPictureButton.FlatAppearance.BorderSize = 0;
			this.topLeftPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.topLeftPictureButton.Location = new System.Drawing.Point(18, 36);
			this.topLeftPictureButton.Name = "topLeftPictureButton";
			this.topLeftPictureButton.Size = new System.Drawing.Size(189, 103);
			this.topLeftPictureButton.TabIndex = 0;
			this.topLeftPictureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.topLeftPictureButton.UseVisualStyleBackColor = true;
			this.topLeftPictureButton.MouseLeave += new System.EventHandler(this.pictureButton_MouseLeave);
			this.topLeftPictureButton.Click += new System.EventHandler(this.pictureButton_Click);
			this.topLeftPictureButton.Resize += new System.EventHandler(this.pictureButton_Resize);
			this.topLeftPictureButton.MouseEnter += new System.EventHandler(this.pictureButton_MouseEnter);
			// 
			// topRightPictureButton
			// 
			this.topRightPictureButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.topRightPictureButton.FlatAppearance.BorderSize = 0;
			this.topRightPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.topRightPictureButton.Location = new System.Drawing.Point(34, 36);
			this.topRightPictureButton.Name = "topRightPictureButton";
			this.topRightPictureButton.Size = new System.Drawing.Size(189, 103);
			this.topRightPictureButton.TabIndex = 0;
			this.topRightPictureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.topRightPictureButton.UseVisualStyleBackColor = true;
			this.topRightPictureButton.MouseLeave += new System.EventHandler(this.pictureButton_MouseLeave);
			this.topRightPictureButton.Click += new System.EventHandler(this.pictureButton_Click);
			this.topRightPictureButton.Resize += new System.EventHandler(this.pictureButton_Resize);
			this.topRightPictureButton.MouseEnter += new System.EventHandler(this.pictureButton_MouseEnter);
			// 
			// bottomSplitContainer
			// 
			this.bottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bottomSplitContainer.IsSplitterFixed = true;
			this.bottomSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.bottomSplitContainer.Name = "bottomSplitContainer";
			// 
			// bottomSplitContainer.Panel1
			// 
			this.bottomSplitContainer.Panel1.Controls.Add(this.bottomLeftPictureButton);
			// 
			// bottomSplitContainer.Panel2
			// 
			this.bottomSplitContainer.Panel2.Controls.Add(this.bottomRightPictureButton);
			this.bottomSplitContainer.Size = new System.Drawing.Size(482, 148);
			this.bottomSplitContainer.SplitterDistance = 220;
			this.bottomSplitContainer.TabIndex = 0;
			this.bottomSplitContainer.TabStop = false;
			this.bottomSplitContainer.Resize += new System.EventHandler(this.splitContainer_Resize);
			// 
			// bottomLeftPictureButton
			// 
			this.bottomLeftPictureButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bottomLeftPictureButton.FlatAppearance.BorderSize = 0;
			this.bottomLeftPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bottomLeftPictureButton.Location = new System.Drawing.Point(18, 15);
			this.bottomLeftPictureButton.Name = "bottomLeftPictureButton";
			this.bottomLeftPictureButton.Size = new System.Drawing.Size(189, 103);
			this.bottomLeftPictureButton.TabIndex = 0;
			this.bottomLeftPictureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.bottomLeftPictureButton.UseVisualStyleBackColor = true;
			this.bottomLeftPictureButton.MouseLeave += new System.EventHandler(this.pictureButton_MouseLeave);
			this.bottomLeftPictureButton.Click += new System.EventHandler(this.pictureButton_Click);
			this.bottomLeftPictureButton.Resize += new System.EventHandler(this.pictureButton_Resize);
			this.bottomLeftPictureButton.MouseEnter += new System.EventHandler(this.pictureButton_MouseEnter);
			// 
			// bottomRightPictureButton
			// 
			this.bottomRightPictureButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bottomRightPictureButton.FlatAppearance.BorderSize = 0;
			this.bottomRightPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bottomRightPictureButton.Location = new System.Drawing.Point(34, 15);
			this.bottomRightPictureButton.Name = "bottomRightPictureButton";
			this.bottomRightPictureButton.Size = new System.Drawing.Size(189, 103);
			this.bottomRightPictureButton.TabIndex = 0;
			this.bottomRightPictureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.bottomRightPictureButton.UseVisualStyleBackColor = true;
			this.bottomRightPictureButton.MouseLeave += new System.EventHandler(this.pictureButton_MouseLeave);
			this.bottomRightPictureButton.Click += new System.EventHandler(this.pictureButton_Click);
			this.bottomRightPictureButton.Resize += new System.EventHandler(this.pictureButton_Resize);
			this.bottomRightPictureButton.MouseEnter += new System.EventHandler(this.pictureButton_MouseEnter);
			// 
			// PickOneMediaPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.buttonPanel);
			this.Name = "PickOneMediaPlayer";
			this.Size = new System.Drawing.Size(482, 355);
			this.Load += new System.EventHandler(this.PickOneMediaPlayer_Load);
			this.buttonPanel.ResumeLayout(false);
			this.buttonPanel.PerformLayout();
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			this.mainSplitContainer.ResumeLayout(false);
			this.topSplitContainer.Panel1.ResumeLayout(false);
			this.topSplitContainer.Panel2.ResumeLayout(false);
			this.topSplitContainer.ResumeLayout(false);
			this.bottomSplitContainer.Panel1.ResumeLayout(false);
			this.bottomSplitContainer.Panel2.ResumeLayout(false);
			this.bottomSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList buttonImageList;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button playPauseButton;
		private System.Windows.Forms.CheckBox loopCheckBox;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.ProgressBar mediaProgressBar;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.SplitContainer topSplitContainer;
		private System.Windows.Forms.SplitContainer bottomSplitContainer;
		private System.Windows.Forms.Button bottomLeftPictureButton;
		private System.Windows.Forms.Button topLeftPictureButton;
		private System.Windows.Forms.Button topRightPictureButton;
		private System.Windows.Forms.Button bottomRightPictureButton;
	}
}
