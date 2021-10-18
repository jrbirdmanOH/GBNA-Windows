namespace Thayer.Birding.UI.Windows
{
	partial class PortableDeviceForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.customListLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.recordingsLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.directoryTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.firstLastRadioButton = new System.Windows.Forms.RadioButton();
			this.lastFirstRadioButton = new System.Windows.Forms.RadioButton();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Custom List:";
			// 
			// customListLabel
			// 
			this.customListLabel.AutoSize = true;
			this.customListLabel.Location = new System.Drawing.Point(82, 15);
			this.customListLabel.Name = "customListLabel";
			this.customListLabel.Size = new System.Drawing.Size(92, 13);
			this.customListLabel.TabIndex = 1;
			this.customListLabel.Text = "Custom List Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Recordings:";
			// 
			// recordingsLabel
			// 
			this.recordingsLabel.AutoSize = true;
			this.recordingsLabel.Location = new System.Drawing.Point(82, 46);
			this.recordingsLabel.Name = "recordingsLabel";
			this.recordingsLabel.Size = new System.Drawing.Size(87, 13);
			this.recordingsLabel.TabIndex = 3;
			this.recordingsLabel.Text = "Recording Count";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 76);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Location:";
			// 
			// directoryTextBox
			// 
			this.directoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.directoryTextBox.Location = new System.Drawing.Point(85, 73);
			this.directoryTextBox.Name = "directoryTextBox";
			this.directoryTextBox.Size = new System.Drawing.Size(244, 20);
			this.directoryTextBox.TabIndex = 5;
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.AutoSize = true;
			this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.browseButton.Location = new System.Drawing.Point(335, 71);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(26, 23);
			this.browseButton.TabIndex = 6;
			this.browseButton.Text = "...";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 109);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Order:";
			// 
			// firstLastRadioButton
			// 
			this.firstLastRadioButton.AutoSize = true;
			this.firstLastRadioButton.Checked = true;
			this.firstLastRadioButton.Location = new System.Drawing.Point(85, 107);
			this.firstLastRadioButton.Name = "firstLastRadioButton";
			this.firstLastRadioButton.Size = new System.Drawing.Size(67, 17);
			this.firstLastRadioButton.TabIndex = 8;
			this.firstLastRadioButton.TabStop = true;
			this.firstLastRadioButton.Text = "First Last";
			this.firstLastRadioButton.UseVisualStyleBackColor = true;
			// 
			// lastFirstRadioButton
			// 
			this.lastFirstRadioButton.AutoSize = true;
			this.lastFirstRadioButton.Location = new System.Drawing.Point(171, 107);
			this.lastFirstRadioButton.Name = "lastFirstRadioButton";
			this.lastFirstRadioButton.Size = new System.Drawing.Size(70, 17);
			this.lastFirstRadioButton.TabIndex = 9;
			this.lastFirstRadioButton.TabStop = true;
			this.lastFirstRadioButton.Text = "Last, First";
			this.lastFirstRadioButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.Location = new System.Drawing.Point(108, 166);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 10;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(189, 166);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 11;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// PortableDeviceForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(373, 201);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.lastFirstRadioButton);
			this.Controls.Add(this.firstLastRadioButton);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.directoryTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.recordingsLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.customListLabel);
			this.Controls.Add(this.label1);
			this.helpProvider.SetHelpKeyword(this, "24");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PortableDeviceForm";
			this.helpProvider.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Prepare Custom List for iPod/MP3 Player";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label customListLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label recordingsLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox directoryTextBox;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton firstLastRadioButton;
		private System.Windows.Forms.RadioButton lastFirstRadioButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}