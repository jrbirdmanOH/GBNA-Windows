namespace Thayer.Birding.UI.Windows
{
	partial class OptionsForm
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
			System.Windows.Forms.Label label5;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.spectrogramTabPage = new System.Windows.Forms.TabPage();
			this.browseSpectrogramButton = new System.Windows.Forms.Button();
			this.spectrogramPathTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.optionsTabControl = new System.Windows.Forms.TabControl();
			this.nameListTabPage = new System.Windows.Forms.TabPage();
			this.showAliasesCheckBox = new System.Windows.Forms.CheckBox();
			this.languageComboBox = new System.Windows.Forms.ComboBox();
			this.quizTabPage = new System.Windows.Forms.TabPage();
			this.hallOfFameGroupBox = new System.Windows.Forms.GroupBox();
			this.soundEffectPlayButton = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.numberOfTopScorersNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.soundEffectBrowseButton = new System.Windows.Forms.Button();
			this.soundEffectTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.quizRestartCheckBox = new System.Windows.Forms.CheckBox();
			this.enableHallOfFameCheckBox = new System.Windows.Forms.CheckBox();
			this.sightingsTabPage = new System.Windows.Forms.TabPage();
			this.hideSightingsCommentsCheckBox = new System.Windows.Forms.CheckBox();
			this.numberOfSightingsLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.sightingsLimitLabel = new System.Windows.Forms.Label();
			this.limitNumberOfSightingsCheckBox = new System.Windows.Forms.CheckBox();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.filtersTabPage = new System.Windows.Forms.TabPage();
			this.restoreFilterAtStartupCheckBox = new System.Windows.Forms.CheckBox();
			label5 = new System.Windows.Forms.Label();
			this.spectrogramTabPage.SuspendLayout();
			this.optionsTabControl.SuspendLayout();
			this.nameListTabPage.SuspendLayout();
			this.quizTabPage.SuspendLayout();
			this.hallOfFameGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numberOfTopScorersNumericUpDown)).BeginInit();
			this.sightingsTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numberOfSightingsLimitNumericUpDown)).BeginInit();
			this.filtersTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(5, 10);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(255, 13);
			label5.TabIndex = 1;
			label5.Text = "Select the language used to display Common Names";
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.Location = new System.Drawing.Point(131, 254);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(212, 254);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// spectrogramTabPage
			// 
			this.spectrogramTabPage.Controls.Add(this.browseSpectrogramButton);
			this.spectrogramTabPage.Controls.Add(this.spectrogramPathTextBox);
			this.spectrogramTabPage.Controls.Add(this.label1);
			this.spectrogramTabPage.Location = new System.Drawing.Point(4, 22);
			this.spectrogramTabPage.Name = "spectrogramTabPage";
			this.spectrogramTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.spectrogramTabPage.Size = new System.Drawing.Size(386, 203);
			this.spectrogramTabPage.TabIndex = 0;
			this.spectrogramTabPage.Text = "Spectrogram";
			this.spectrogramTabPage.UseVisualStyleBackColor = true;
			// 
			// browseSpectrogramButton
			// 
			this.browseSpectrogramButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseSpectrogramButton.AutoSize = true;
			this.browseSpectrogramButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.browseSpectrogramButton.Location = new System.Drawing.Point(351, 58);
			this.browseSpectrogramButton.Name = "browseSpectrogramButton";
			this.browseSpectrogramButton.Size = new System.Drawing.Size(26, 23);
			this.browseSpectrogramButton.TabIndex = 2;
			this.browseSpectrogramButton.Text = "...";
			this.browseSpectrogramButton.UseVisualStyleBackColor = true;
			this.browseSpectrogramButton.Click += new System.EventHandler(this.browseSpectrogramButton_Click);
			// 
			// spectrogramPathTextBox
			// 
			this.spectrogramPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.spectrogramPathTextBox.Location = new System.Drawing.Point(8, 58);
			this.spectrogramPathTextBox.Name = "spectrogramPathTextBox";
			this.spectrogramPathTextBox.Size = new System.Drawing.Size(337, 20);
			this.spectrogramPathTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(374, 45);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thayer Birding Software\'s eViewer can integrate with external spectrogram applica" +
    "tions such as Audacity or Raven Lite.  If you have one installed, enter the path" +
    " to the executable in the field below.";
			// 
			// optionsTabControl
			// 
			this.optionsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.optionsTabControl.Controls.Add(this.filtersTabPage);
			this.optionsTabControl.Controls.Add(this.nameListTabPage);
			this.optionsTabControl.Controls.Add(this.quizTabPage);
			this.optionsTabControl.Controls.Add(this.sightingsTabPage);
			this.optionsTabControl.Controls.Add(this.spectrogramTabPage);
			this.optionsTabControl.Location = new System.Drawing.Point(12, 12);
			this.optionsTabControl.Name = "optionsTabControl";
			this.optionsTabControl.SelectedIndex = 0;
			this.optionsTabControl.Size = new System.Drawing.Size(394, 229);
			this.optionsTabControl.TabIndex = 0;
			// 
			// nameListTabPage
			// 
			this.nameListTabPage.Controls.Add(this.showAliasesCheckBox);
			this.nameListTabPage.Controls.Add(label5);
			this.nameListTabPage.Controls.Add(this.languageComboBox);
			this.nameListTabPage.Location = new System.Drawing.Point(4, 22);
			this.nameListTabPage.Name = "nameListTabPage";
			this.nameListTabPage.Size = new System.Drawing.Size(386, 203);
			this.nameListTabPage.TabIndex = 3;
			this.nameListTabPage.Text = "Name List";
			this.nameListTabPage.UseVisualStyleBackColor = true;
			// 
			// showAliasesCheckBox
			// 
			this.showAliasesCheckBox.AutoSize = true;
			this.showAliasesCheckBox.Location = new System.Drawing.Point(8, 66);
			this.showAliasesCheckBox.Name = "showAliasesCheckBox";
			this.showAliasesCheckBox.Size = new System.Drawing.Size(216, 17);
			this.showAliasesCheckBox.TabIndex = 2;
			this.showAliasesCheckBox.Text = "Include aliases in name list (English only)";
			this.showAliasesCheckBox.UseVisualStyleBackColor = true;
			// 
			// languageComboBox
			// 
			this.languageComboBox.FormattingEnabled = true;
			this.languageComboBox.Location = new System.Drawing.Point(8, 26);
			this.languageComboBox.Name = "languageComboBox";
			this.languageComboBox.Size = new System.Drawing.Size(192, 21);
			this.languageComboBox.TabIndex = 0;
			this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
			// 
			// quizTabPage
			// 
			this.quizTabPage.Controls.Add(this.hallOfFameGroupBox);
			this.quizTabPage.Controls.Add(this.quizRestartCheckBox);
			this.quizTabPage.Controls.Add(this.enableHallOfFameCheckBox);
			this.quizTabPage.Location = new System.Drawing.Point(4, 22);
			this.quizTabPage.Name = "quizTabPage";
			this.quizTabPage.Size = new System.Drawing.Size(386, 203);
			this.quizTabPage.TabIndex = 2;
			this.quizTabPage.Text = "Quiz";
			this.quizTabPage.UseVisualStyleBackColor = true;
			// 
			// hallOfFameGroupBox
			// 
			this.hallOfFameGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hallOfFameGroupBox.Controls.Add(this.soundEffectPlayButton);
			this.hallOfFameGroupBox.Controls.Add(this.numberOfTopScorersNumericUpDown);
			this.hallOfFameGroupBox.Controls.Add(this.soundEffectBrowseButton);
			this.hallOfFameGroupBox.Controls.Add(this.soundEffectTextBox);
			this.hallOfFameGroupBox.Controls.Add(this.label4);
			this.hallOfFameGroupBox.Controls.Add(this.label3);
			this.hallOfFameGroupBox.Location = new System.Drawing.Point(5, 59);
			this.hallOfFameGroupBox.Name = "hallOfFameGroupBox";
			this.hallOfFameGroupBox.Size = new System.Drawing.Size(374, 133);
			this.hallOfFameGroupBox.TabIndex = 2;
			this.hallOfFameGroupBox.TabStop = false;
			this.hallOfFameGroupBox.Text = "Hall of Fame";
			// 
			// soundEffectPlayButton
			// 
			this.soundEffectPlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.soundEffectPlayButton.AutoSize = true;
			this.soundEffectPlayButton.BackColor = System.Drawing.SystemColors.Control;
			this.soundEffectPlayButton.ImageIndex = 1;
			this.soundEffectPlayButton.ImageList = this.imageList;
			this.soundEffectPlayButton.Location = new System.Drawing.Point(337, 79);
			this.soundEffectPlayButton.Name = "soundEffectPlayButton";
			this.soundEffectPlayButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.soundEffectPlayButton.Size = new System.Drawing.Size(23, 22);
			this.soundEffectPlayButton.TabIndex = 5;
			this.soundEffectPlayButton.UseVisualStyleBackColor = false;
			this.soundEffectPlayButton.Click += new System.EventHandler(this.soundEffectPlayButton_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList.Images.SetKeyName(0, "Find.bmp");
			this.imageList.Images.SetKeyName(1, "Speaker.bmp");
			// 
			// numberOfTopScorersNumericUpDown
			// 
			this.numberOfTopScorersNumericUpDown.Location = new System.Drawing.Point(261, 24);
			this.numberOfTopScorersNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numberOfTopScorersNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numberOfTopScorersNumericUpDown.Name = "numberOfTopScorersNumericUpDown";
			this.numberOfTopScorersNumericUpDown.Size = new System.Drawing.Size(59, 20);
			this.numberOfTopScorersNumericUpDown.TabIndex = 1;
			this.numberOfTopScorersNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// soundEffectBrowseButton
			// 
			this.soundEffectBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.soundEffectBrowseButton.AutoSize = true;
			this.soundEffectBrowseButton.ImageIndex = 0;
			this.soundEffectBrowseButton.ImageList = this.imageList;
			this.soundEffectBrowseButton.Location = new System.Drawing.Point(308, 79);
			this.soundEffectBrowseButton.Name = "soundEffectBrowseButton";
			this.soundEffectBrowseButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.soundEffectBrowseButton.Size = new System.Drawing.Size(23, 22);
			this.soundEffectBrowseButton.TabIndex = 4;
			this.soundEffectBrowseButton.UseVisualStyleBackColor = true;
			this.soundEffectBrowseButton.Click += new System.EventHandler(this.soundEffectBrowseButton_Click);
			// 
			// soundEffectTextBox
			// 
			this.soundEffectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.soundEffectTextBox.Location = new System.Drawing.Point(9, 81);
			this.soundEffectTextBox.Name = "soundEffectTextBox";
			this.soundEffectTextBox.Size = new System.Drawing.Size(290, 20);
			this.soundEffectTextBox.TabIndex = 3;
			this.soundEffectTextBox.TextChanged += new System.EventHandler(this.soundEffectTextBox_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(302, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Sound file to play when someone qualifies for the Hall of Fame:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(249, 30);
			this.label3.TabIndex = 0;
			this.label3.Text = "Maximum number of scorers to track for each quiz, quiz type, difficulty level, an" +
    "d name type:";
			// 
			// quizRestartCheckBox
			// 
			this.quizRestartCheckBox.AutoSize = true;
			this.quizRestartCheckBox.Location = new System.Drawing.Point(5, 10);
			this.quizRestartCheckBox.Name = "quizRestartCheckBox";
			this.quizRestartCheckBox.Size = new System.Drawing.Size(337, 17);
			this.quizRestartCheckBox.TabIndex = 0;
			this.quizRestartCheckBox.Text = "Prompt for a quiz restart, if applicable, when the Quiz Wizard starts";
			this.quizRestartCheckBox.UseVisualStyleBackColor = true;
			// 
			// enableHallOfFameCheckBox
			// 
			this.enableHallOfFameCheckBox.AutoSize = true;
			this.enableHallOfFameCheckBox.Location = new System.Drawing.Point(5, 33);
			this.enableHallOfFameCheckBox.Name = "enableHallOfFameCheckBox";
			this.enableHallOfFameCheckBox.Size = new System.Drawing.Size(209, 17);
			this.enableHallOfFameCheckBox.TabIndex = 1;
			this.enableHallOfFameCheckBox.Text = "Enable the Hall of Fame for top scorers";
			this.enableHallOfFameCheckBox.UseVisualStyleBackColor = true;
			this.enableHallOfFameCheckBox.CheckedChanged += new System.EventHandler(this.enableHallOfFameCheckBox_CheckedChanged);
			// 
			// sightingsTabPage
			// 
			this.sightingsTabPage.Controls.Add(this.hideSightingsCommentsCheckBox);
			this.sightingsTabPage.Controls.Add(this.numberOfSightingsLimitNumericUpDown);
			this.sightingsTabPage.Controls.Add(this.sightingsLimitLabel);
			this.sightingsTabPage.Controls.Add(this.limitNumberOfSightingsCheckBox);
			this.sightingsTabPage.Location = new System.Drawing.Point(4, 22);
			this.sightingsTabPage.Name = "sightingsTabPage";
			this.sightingsTabPage.Size = new System.Drawing.Size(386, 203);
			this.sightingsTabPage.TabIndex = 4;
			this.sightingsTabPage.Text = "Sightings";
			this.sightingsTabPage.UseVisualStyleBackColor = true;
			// 
			// hideSightingsCommentsCheckBox
			// 
			this.hideSightingsCommentsCheckBox.AutoSize = true;
			this.hideSightingsCommentsCheckBox.Location = new System.Drawing.Point(5, 10);
			this.hideSightingsCommentsCheckBox.Name = "hideSightingsCommentsCheckBox";
			this.hideSightingsCommentsCheckBox.Size = new System.Drawing.Size(217, 17);
			this.hideSightingsCommentsCheckBox.TabIndex = 0;
			this.hideSightingsCommentsCheckBox.Text = "Hide sightings comments in My Sightings";
			this.hideSightingsCommentsCheckBox.UseVisualStyleBackColor = true;
			// 
			// numberOfSightingsLimitNumericUpDown
			// 
			this.numberOfSightingsLimitNumericUpDown.Location = new System.Drawing.Point(207, 57);
			this.numberOfSightingsLimitNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numberOfSightingsLimitNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numberOfSightingsLimitNumericUpDown.Name = "numberOfSightingsLimitNumericUpDown";
			this.numberOfSightingsLimitNumericUpDown.Size = new System.Drawing.Size(59, 20);
			this.numberOfSightingsLimitNumericUpDown.TabIndex = 3;
			this.numberOfSightingsLimitNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// sightingsLimitLabel
			// 
			this.sightingsLimitLabel.AutoSize = true;
			this.sightingsLimitLabel.Location = new System.Drawing.Point(2, 59);
			this.sightingsLimitLabel.Name = "sightingsLimitLabel";
			this.sightingsLimitLabel.Size = new System.Drawing.Size(195, 13);
			this.sightingsLimitLabel.TabIndex = 2;
			this.sightingsLimitLabel.Text = "Maximum number of sightings to display:";
			// 
			// limitNumberOfSightingsCheckBox
			// 
			this.limitNumberOfSightingsCheckBox.AutoSize = true;
			this.limitNumberOfSightingsCheckBox.Location = new System.Drawing.Point(5, 33);
			this.limitNumberOfSightingsCheckBox.Name = "limitNumberOfSightingsCheckBox";
			this.limitNumberOfSightingsCheckBox.Size = new System.Drawing.Size(360, 17);
			this.limitNumberOfSightingsCheckBox.TabIndex = 1;
			this.limitNumberOfSightingsCheckBox.Text = "Limit number of sightings displayed on main eField Guide Viewer screen";
			this.limitNumberOfSightingsCheckBox.UseVisualStyleBackColor = true;
			this.limitNumberOfSightingsCheckBox.CheckedChanged += new System.EventHandler(this.limitNumberOfSightingsCheckBox_CheckedChanged);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// filtersTabPage
			// 
			this.filtersTabPage.Controls.Add(this.restoreFilterAtStartupCheckBox);
			this.filtersTabPage.Location = new System.Drawing.Point(4, 22);
			this.filtersTabPage.Name = "filtersTabPage";
			this.filtersTabPage.Size = new System.Drawing.Size(386, 203);
			this.filtersTabPage.TabIndex = 5;
			this.filtersTabPage.Text = "Filters";
			this.filtersTabPage.UseVisualStyleBackColor = true;
			// 
			// restoreFilterAtStartupCheckBox
			// 
			this.restoreFilterAtStartupCheckBox.AutoSize = true;
			this.restoreFilterAtStartupCheckBox.Location = new System.Drawing.Point(5, 10);
			this.restoreFilterAtStartupCheckBox.Name = "restoreFilterAtStartupCheckBox";
			this.restoreFilterAtStartupCheckBox.Size = new System.Drawing.Size(194, 17);
			this.restoreFilterAtStartupCheckBox.TabIndex = 0;
			this.restoreFilterAtStartupCheckBox.Text = "Restore last selected filter at startup";
			this.restoreFilterAtStartupCheckBox.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(418, 292);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.optionsTabControl);
			this.helpProvider.SetHelpKeyword(this, "53");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.helpProvider.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Options";
			this.spectrogramTabPage.ResumeLayout(false);
			this.spectrogramTabPage.PerformLayout();
			this.optionsTabControl.ResumeLayout(false);
			this.nameListTabPage.ResumeLayout(false);
			this.nameListTabPage.PerformLayout();
			this.quizTabPage.ResumeLayout(false);
			this.quizTabPage.PerformLayout();
			this.hallOfFameGroupBox.ResumeLayout(false);
			this.hallOfFameGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numberOfTopScorersNumericUpDown)).EndInit();
			this.sightingsTabPage.ResumeLayout(false);
			this.sightingsTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numberOfSightingsLimitNumericUpDown)).EndInit();
			this.filtersTabPage.ResumeLayout(false);
			this.filtersTabPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TabPage spectrogramTabPage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl optionsTabControl;
		private System.Windows.Forms.Button browseSpectrogramButton;
		private System.Windows.Forms.TextBox spectrogramPathTextBox;
		private System.Windows.Forms.TabPage quizTabPage;
		private System.Windows.Forms.CheckBox quizRestartCheckBox;
		private System.Windows.Forms.GroupBox hallOfFameGroupBox;
		private System.Windows.Forms.CheckBox enableHallOfFameCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox soundEffectTextBox;
		private System.Windows.Forms.Button soundEffectBrowseButton;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.NumericUpDown numberOfTopScorersNumericUpDown;
		private System.Windows.Forms.Button soundEffectPlayButton;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.TabPage nameListTabPage;
		private System.Windows.Forms.ComboBox languageComboBox;
		private System.Windows.Forms.CheckBox showAliasesCheckBox;
		private System.Windows.Forms.TabPage sightingsTabPage;
		private System.Windows.Forms.CheckBox limitNumberOfSightingsCheckBox;
		private System.Windows.Forms.NumericUpDown numberOfSightingsLimitNumericUpDown;
		private System.Windows.Forms.Label sightingsLimitLabel;
		private System.Windows.Forms.CheckBox hideSightingsCommentsCheckBox;
		private System.Windows.Forms.TabPage filtersTabPage;
		private System.Windows.Forms.CheckBox restoreFilterAtStartupCheckBox;
	}
}