namespace Thayer.Birding.UI.Windows
{
	partial class MyMediaSoundForm
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
			System.Windows.Forms.Label label2;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMediaSoundForm));
			this.captionTextBox = new System.Windows.Forms.TextBox();
			this.previewButton = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.browseButton = new System.Windows.Forms.Button();
			this.soundFileTextBox = new System.Windows.Forms.TextBox();
			this.soundFileLabel = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 71);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(46, 13);
			label2.TabIndex = 2;
			label2.Text = "Caption:";
			// 
			// captionTextBox
			// 
			this.captionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.captionTextBox.Location = new System.Drawing.Point(70, 68);
			this.captionTextBox.MaxLength = 60;
			this.captionTextBox.Name = "captionTextBox";
			this.captionTextBox.Size = new System.Drawing.Size(263, 20);
			this.captionTextBox.TabIndex = 3;
			// 
			// previewButton
			// 
			this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.previewButton.ImageKey = "Preview Sound";
			this.previewButton.ImageList = this.imageList;
			this.previewButton.Location = new System.Drawing.Point(445, 66);
			this.previewButton.Name = "previewButton";
			this.previewButton.Size = new System.Drawing.Size(82, 23);
			this.previewButton.TabIndex = 5;
			this.previewButton.Text = "Preview...";
			this.previewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip.SetToolTip(this.previewButton, "Preview sound");
			this.previewButton.UseVisualStyleBackColor = true;
			this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList.Images.SetKeyName(0, "Browse");
			this.imageList.Images.SetKeyName(1, "Preview Sound Old");
			this.imageList.Images.SetKeyName(2, "Preview Sound");
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.ImageKey = "Browse";
			this.browseButton.ImageList = this.imageList;
			this.browseButton.Location = new System.Drawing.Point(357, 66);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(82, 23);
			this.browseButton.TabIndex = 4;
			this.browseButton.Text = "Browse...";
			this.browseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip.SetToolTip(this.browseButton, "Browse for sound file");
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// soundFileTextBox
			// 
			this.soundFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.soundFileTextBox.Location = new System.Drawing.Point(70, 42);
			this.soundFileTextBox.MaxLength = 255;
			this.soundFileTextBox.Name = "soundFileTextBox";
			this.soundFileTextBox.Size = new System.Drawing.Size(457, 20);
			this.soundFileTextBox.TabIndex = 1;
			this.soundFileTextBox.TextChanged += new System.EventHandler(this.soundFileTextBox_TextChanged);
			// 
			// soundFileLabel
			// 
			this.soundFileLabel.AutoSize = true;
			this.soundFileLabel.Location = new System.Drawing.Point(8, 45);
			this.soundFileLabel.Name = "soundFileLabel";
			this.soundFileLabel.Size = new System.Drawing.Size(60, 13);
			this.soundFileLabel.TabIndex = 0;
			this.soundFileLabel.Text = "Sound File:";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(273, 115);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.Location = new System.Drawing.Point(191, 115);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyMediaSoundForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(539, 156);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(label2);
			this.Controls.Add(this.captionTextBox);
			this.Controls.Add(this.previewButton);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.soundFileTextBox);
			this.Controls.Add(this.soundFileLabel);
			this.helpProvider.SetHelpKeyword(this, "64");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "MyMediaSoundForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Sound";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox captionTextBox;
		private System.Windows.Forms.Button previewButton;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.TextBox soundFileTextBox;
		private System.Windows.Forms.Label soundFileLabel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}