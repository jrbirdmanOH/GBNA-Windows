namespace Thayer.Birding.ScreenSaver
{
	partial class SettingsForm
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
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.GroupBox groupBox3;
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.loopSoundCheckBox = new System.Windows.Forms.CheckBox();
			this.playSoundCheckBox = new System.Windows.Forms.CheckBox();
			this.captionCheckBox = new System.Windows.Forms.CheckBox();
			this.commonNameCheckBox = new System.Windows.Forms.CheckBox();
			this.randomOrderCheckBox = new System.Windows.Forms.CheckBox();
			this.imageDisplayTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageDisplayTimeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this.loopSoundCheckBox);
			groupBox2.Controls.Add(this.playSoundCheckBox);
			groupBox2.Location = new System.Drawing.Point(18, 190);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(357, 79);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Sounds";
			// 
			// loopSoundCheckBox
			// 
			this.loopSoundCheckBox.AutoSize = true;
			this.loopSoundCheckBox.Location = new System.Drawing.Point(16, 48);
			this.loopSoundCheckBox.Name = "loopSoundCheckBox";
			this.loopSoundCheckBox.Size = new System.Drawing.Size(128, 17);
			this.loopSoundCheckBox.TabIndex = 1;
			this.loopSoundCheckBox.Text = "Loop sound playback";
			this.loopSoundCheckBox.UseVisualStyleBackColor = true;
			// 
			// playSoundCheckBox
			// 
			this.playSoundCheckBox.AutoSize = true;
			this.playSoundCheckBox.Location = new System.Drawing.Point(16, 25);
			this.playSoundCheckBox.Name = "playSoundCheckBox";
			this.playSoundCheckBox.Size = new System.Drawing.Size(137, 17);
			this.playSoundCheckBox.TabIndex = 0;
			this.playSoundCheckBox.Text = "Play sound (if available)";
			this.playSoundCheckBox.UseVisualStyleBackColor = true;
			this.playSoundCheckBox.CheckedChanged += new System.EventHandler(this.playSoundCheckBox_CheckedChanged);
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(groupBox1);
			groupBox3.Controls.Add(this.randomOrderCheckBox);
			groupBox3.Controls.Add(label3);
			groupBox3.Controls.Add(this.imageDisplayTimeNumericUpDown);
			groupBox3.Controls.Add(label1);
			groupBox3.Location = new System.Drawing.Point(15, 12);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(360, 172);
			groupBox3.TabIndex = 0;
			groupBox3.TabStop = false;
			groupBox3.Text = "Images";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(this.captionCheckBox);
			groupBox1.Controls.Add(this.commonNameCheckBox);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new System.Drawing.Point(19, 86);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(314, 69);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Information";
			// 
			// captionCheckBox
			// 
			this.captionCheckBox.AutoSize = true;
			this.captionCheckBox.Location = new System.Drawing.Point(133, 44);
			this.captionCheckBox.Name = "captionCheckBox";
			this.captionCheckBox.Size = new System.Drawing.Size(62, 17);
			this.captionCheckBox.TabIndex = 2;
			this.captionCheckBox.Text = "Caption";
			this.captionCheckBox.UseVisualStyleBackColor = true;
			// 
			// commonNameCheckBox
			// 
			this.commonNameCheckBox.AutoSize = true;
			this.commonNameCheckBox.Location = new System.Drawing.Point(16, 44);
			this.commonNameCheckBox.Name = "commonNameCheckBox";
			this.commonNameCheckBox.Size = new System.Drawing.Size(98, 17);
			this.commonNameCheckBox.TabIndex = 1;
			this.commonNameCheckBox.Text = "Common Name";
			this.commonNameCheckBox.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(256, 13);
			label2.TabIndex = 0;
			label2.Text = "Select the information to be displayed for each image";
			// 
			// randomOrderCheckBox
			// 
			this.randomOrderCheckBox.AutoSize = true;
			this.randomOrderCheckBox.Location = new System.Drawing.Point(19, 54);
			this.randomOrderCheckBox.Name = "randomOrderCheckBox";
			this.randomOrderCheckBox.Size = new System.Drawing.Size(172, 17);
			this.randomOrderCheckBox.TabIndex = 3;
			this.randomOrderCheckBox.Text = "Display images in random order";
			this.randomOrderCheckBox.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(304, 28);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 13);
			label3.TabIndex = 2;
			label3.Text = "secs";
			// 
			// imageDisplayTimeNumericUpDown
			// 
			this.imageDisplayTimeNumericUpDown.Location = new System.Drawing.Point(248, 25);
			this.imageDisplayTimeNumericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.imageDisplayTimeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.imageDisplayTimeNumericUpDown.Name = "imageDisplayTimeNumericUpDown";
			this.imageDisplayTimeNumericUpDown.Size = new System.Drawing.Size(53, 20);
			this.imageDisplayTimeNumericUpDown.TabIndex = 1;
			this.imageDisplayTimeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 28);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(224, 13);
			label1.TabIndex = 0;
			label1.Text = "How long do you want to display each image?";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(300, 285);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(219, 285);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(393, 322);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thayer Birding Software Screen Saver Settings";
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageDisplayTimeNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox loopSoundCheckBox;
		private System.Windows.Forms.CheckBox playSoundCheckBox;
		private System.Windows.Forms.NumericUpDown imageDisplayTimeNumericUpDown;
		private System.Windows.Forms.CheckBox randomOrderCheckBox;
		private System.Windows.Forms.CheckBox captionCheckBox;
		private System.Windows.Forms.CheckBox commonNameCheckBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
	}
}