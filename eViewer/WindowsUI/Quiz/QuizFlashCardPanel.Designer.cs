namespace Thayer.Birding.UI.Windows.Quiz
{
    partial class QuizFlashCardPanel
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
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label8;
			this.bestPictureRadioButton = new System.Windows.Forms.RadioButton();
			this.videoRadioButton = new System.Windows.Forms.RadioButton();
			this.randomPictureRadioButton = new System.Windows.Forms.RadioButton();
			this.pictureTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.videoTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.randomVideoRadioButton = new System.Windows.Forms.RadioButton();
			this.bestVideoRadioButton = new System.Windows.Forms.RadioButton();
			this.soundTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.randomSoundRadioButton = new System.Windows.Forms.RadioButton();
			this.bestSoundRadioButton = new System.Windows.Forms.RadioButton();
			this.allMediaRadioButton = new System.Windows.Forms.RadioButton();
			this.rangeMapRadioButton = new System.Windows.Forms.RadioButton();
			this.soundRadioButton = new System.Windows.Forms.RadioButton();
			this.pictureAndSoundRadioButton = new System.Windows.Forms.RadioButton();
			this.pictureRadioButton = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.mnemonicGroupBox = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.mnemonicNoRadioButton = new System.Windows.Forms.RadioButton();
			this.mnemonicYesRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.displayNextMediaTimerLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.displayNextItemTimerLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.displayNameTimerLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.commonNameRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bandCodeRadioButton = new System.Windows.Forms.RadioButton();
			this.languageAllRadioButton = new System.Windows.Forms.RadioButton();
			this.scientificNameRadioButton = new System.Windows.Forms.RadioButton();
			this.pronunciationGroupBox = new System.Windows.Forms.GroupBox();
			this.pronunciationNoRadioButton = new System.Windows.Forms.RadioButton();
			this.pronunciationYesRadioButton = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.femaleOtherPictureRadioButton = new System.Windows.Forms.RadioButton();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			this.pictureTypeGroupBox.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.videoTypeGroupBox.SuspendLayout();
			this.soundTypeGroupBox.SuspendLayout();
			this.mnemonicGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.displayNextMediaTimerLengthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayNextItemTimerLengthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayNameTimerLengthNumericUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.pronunciationGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(8, 50);
			label5.MaximumSize = new System.Drawing.Size(370, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(354, 26);
			label5.TabIndex = 3;
			label5.Text = "After the media and name have been displayed, how long do you want to wait to dis" +
    "play the next quiz item?";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 24);
			label1.MaximumSize = new System.Drawing.Size(420, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(416, 13);
			label1.TabIndex = 0;
			label1.Text = "After the media has been displayed, how long do you want to wait to display the n" +
    "ame?";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(492, 58);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(47, 13);
			label4.TabIndex = 5;
			label4.Text = "seconds";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(492, 26);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 13);
			label3.TabIndex = 2;
			label3.Text = "seconds";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(492, 90);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(47, 13);
			label8.TabIndex = 8;
			label8.Text = "seconds";
			// 
			// bestPictureRadioButton
			// 
			this.bestPictureRadioButton.AutoSize = true;
			this.bestPictureRadioButton.Location = new System.Drawing.Point(18, 19);
			this.bestPictureRadioButton.Name = "bestPictureRadioButton";
			this.bestPictureRadioButton.Size = new System.Drawing.Size(46, 17);
			this.bestPictureRadioButton.TabIndex = 0;
			this.bestPictureRadioButton.TabStop = true;
			this.bestPictureRadioButton.Text = "&Best";
			this.bestPictureRadioButton.UseVisualStyleBackColor = true;
			// 
			// videoRadioButton
			// 
			this.videoRadioButton.AutoSize = true;
			this.videoRadioButton.Location = new System.Drawing.Point(274, 32);
			this.videoRadioButton.Name = "videoRadioButton";
			this.videoRadioButton.Size = new System.Drawing.Size(52, 17);
			this.videoRadioButton.TabIndex = 4;
			this.videoRadioButton.TabStop = true;
			this.videoRadioButton.Text = "&Video";
			this.videoRadioButton.UseVisualStyleBackColor = true;
			this.videoRadioButton.CheckedChanged += new System.EventHandler(this.mediaTypeRadioButton_CheckedChanged);
			// 
			// randomPictureRadioButton
			// 
			this.randomPictureRadioButton.AutoSize = true;
			this.randomPictureRadioButton.Location = new System.Drawing.Point(166, 19);
			this.randomPictureRadioButton.Name = "randomPictureRadioButton";
			this.randomPictureRadioButton.Size = new System.Drawing.Size(65, 17);
			this.randomPictureRadioButton.TabIndex = 2;
			this.randomPictureRadioButton.TabStop = true;
			this.randomPictureRadioButton.Text = "&Random";
			this.randomPictureRadioButton.UseVisualStyleBackColor = true;
			// 
			// pictureTypeGroupBox
			// 
			this.pictureTypeGroupBox.Controls.Add(this.femaleOtherPictureRadioButton);
			this.pictureTypeGroupBox.Controls.Add(this.randomPictureRadioButton);
			this.pictureTypeGroupBox.Controls.Add(this.bestPictureRadioButton);
			this.pictureTypeGroupBox.Location = new System.Drawing.Point(11, 55);
			this.pictureTypeGroupBox.Name = "pictureTypeGroupBox";
			this.pictureTypeGroupBox.Size = new System.Drawing.Size(235, 44);
			this.pictureTypeGroupBox.TabIndex = 7;
			this.pictureTypeGroupBox.TabStop = false;
			this.pictureTypeGroupBox.Text = "Picture Type";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.videoTypeGroupBox);
			this.groupBox4.Controls.Add(this.soundTypeGroupBox);
			this.groupBox4.Controls.Add(this.allMediaRadioButton);
			this.groupBox4.Controls.Add(this.rangeMapRadioButton);
			this.groupBox4.Controls.Add(this.pictureTypeGroupBox);
			this.groupBox4.Controls.Add(this.videoRadioButton);
			this.groupBox4.Controls.Add(this.soundRadioButton);
			this.groupBox4.Controls.Add(this.pictureAndSoundRadioButton);
			this.groupBox4.Controls.Add(this.pictureRadioButton);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Location = new System.Drawing.Point(5, 186);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(548, 111);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Media";
			// 
			// videoTypeGroupBox
			// 
			this.videoTypeGroupBox.Controls.Add(this.randomVideoRadioButton);
			this.videoTypeGroupBox.Controls.Add(this.bestVideoRadioButton);
			this.videoTypeGroupBox.Location = new System.Drawing.Point(398, 55);
			this.videoTypeGroupBox.Name = "videoTypeGroupBox";
			this.videoTypeGroupBox.Size = new System.Drawing.Size(140, 44);
			this.videoTypeGroupBox.TabIndex = 9;
			this.videoTypeGroupBox.TabStop = false;
			this.videoTypeGroupBox.Text = "Video Type";
			// 
			// randomVideoRadioButton
			// 
			this.randomVideoRadioButton.AutoSize = true;
			this.randomVideoRadioButton.Location = new System.Drawing.Point(70, 19);
			this.randomVideoRadioButton.Name = "randomVideoRadioButton";
			this.randomVideoRadioButton.Size = new System.Drawing.Size(65, 17);
			this.randomVideoRadioButton.TabIndex = 1;
			this.randomVideoRadioButton.TabStop = true;
			this.randomVideoRadioButton.Text = "Random";
			this.randomVideoRadioButton.UseVisualStyleBackColor = true;
			// 
			// bestVideoRadioButton
			// 
			this.bestVideoRadioButton.AutoSize = true;
			this.bestVideoRadioButton.Location = new System.Drawing.Point(18, 19);
			this.bestVideoRadioButton.Name = "bestVideoRadioButton";
			this.bestVideoRadioButton.Size = new System.Drawing.Size(46, 17);
			this.bestVideoRadioButton.TabIndex = 0;
			this.bestVideoRadioButton.TabStop = true;
			this.bestVideoRadioButton.Text = "Best";
			this.bestVideoRadioButton.UseVisualStyleBackColor = true;
			// 
			// soundTypeGroupBox
			// 
			this.soundTypeGroupBox.Controls.Add(this.randomSoundRadioButton);
			this.soundTypeGroupBox.Controls.Add(this.bestSoundRadioButton);
			this.soundTypeGroupBox.Location = new System.Drawing.Point(252, 55);
			this.soundTypeGroupBox.Name = "soundTypeGroupBox";
			this.soundTypeGroupBox.Size = new System.Drawing.Size(140, 44);
			this.soundTypeGroupBox.TabIndex = 8;
			this.soundTypeGroupBox.TabStop = false;
			this.soundTypeGroupBox.Text = "Sound Type";
			// 
			// randomSoundRadioButton
			// 
			this.randomSoundRadioButton.AutoSize = true;
			this.randomSoundRadioButton.Location = new System.Drawing.Point(70, 19);
			this.randomSoundRadioButton.Name = "randomSoundRadioButton";
			this.randomSoundRadioButton.Size = new System.Drawing.Size(65, 17);
			this.randomSoundRadioButton.TabIndex = 1;
			this.randomSoundRadioButton.TabStop = true;
			this.randomSoundRadioButton.Text = "Random";
			this.randomSoundRadioButton.UseVisualStyleBackColor = true;
			// 
			// bestSoundRadioButton
			// 
			this.bestSoundRadioButton.AutoSize = true;
			this.bestSoundRadioButton.Location = new System.Drawing.Point(18, 19);
			this.bestSoundRadioButton.Name = "bestSoundRadioButton";
			this.bestSoundRadioButton.Size = new System.Drawing.Size(46, 17);
			this.bestSoundRadioButton.TabIndex = 0;
			this.bestSoundRadioButton.TabStop = true;
			this.bestSoundRadioButton.Text = "Best";
			this.bestSoundRadioButton.UseVisualStyleBackColor = true;
			// 
			// allMediaRadioButton
			// 
			this.allMediaRadioButton.AutoSize = true;
			this.allMediaRadioButton.Location = new System.Drawing.Point(419, 32);
			this.allMediaRadioButton.Name = "allMediaRadioButton";
			this.allMediaRadioButton.Size = new System.Drawing.Size(36, 17);
			this.allMediaRadioButton.TabIndex = 6;
			this.allMediaRadioButton.TabStop = true;
			this.allMediaRadioButton.Text = "&All";
			this.allMediaRadioButton.UseVisualStyleBackColor = true;
			this.allMediaRadioButton.CheckedChanged += new System.EventHandler(this.mediaTypeRadioButton_CheckedChanged);
			// 
			// rangeMapRadioButton
			// 
			this.rangeMapRadioButton.AutoSize = true;
			this.rangeMapRadioButton.Location = new System.Drawing.Point(332, 32);
			this.rangeMapRadioButton.Name = "rangeMapRadioButton";
			this.rangeMapRadioButton.Size = new System.Drawing.Size(81, 17);
			this.rangeMapRadioButton.TabIndex = 5;
			this.rangeMapRadioButton.TabStop = true;
			this.rangeMapRadioButton.Text = "Ran&ge Map";
			this.rangeMapRadioButton.UseVisualStyleBackColor = true;
			this.rangeMapRadioButton.CheckedChanged += new System.EventHandler(this.mediaTypeRadioButton_CheckedChanged);
			// 
			// soundRadioButton
			// 
			this.soundRadioButton.AutoSize = true;
			this.soundRadioButton.Location = new System.Drawing.Point(212, 32);
			this.soundRadioButton.Name = "soundRadioButton";
			this.soundRadioButton.Size = new System.Drawing.Size(56, 17);
			this.soundRadioButton.TabIndex = 3;
			this.soundRadioButton.TabStop = true;
			this.soundRadioButton.Text = "So&und";
			this.soundRadioButton.UseVisualStyleBackColor = true;
			this.soundRadioButton.CheckedChanged += new System.EventHandler(this.mediaTypeRadioButton_CheckedChanged);
			// 
			// pictureAndSoundRadioButton
			// 
			this.pictureAndSoundRadioButton.AutoSize = true;
			this.pictureAndSoundRadioButton.Location = new System.Drawing.Point(93, 32);
			this.pictureAndSoundRadioButton.Name = "pictureAndSoundRadioButton";
			this.pictureAndSoundRadioButton.Size = new System.Drawing.Size(113, 17);
			this.pictureAndSoundRadioButton.TabIndex = 2;
			this.pictureAndSoundRadioButton.TabStop = true;
			this.pictureAndSoundRadioButton.Text = "P&icture and Sound";
			this.pictureAndSoundRadioButton.UseVisualStyleBackColor = true;
			this.pictureAndSoundRadioButton.CheckedChanged += new System.EventHandler(this.mediaTypeRadioButton_CheckedChanged);
			// 
			// pictureRadioButton
			// 
			this.pictureRadioButton.AutoSize = true;
			this.pictureRadioButton.Location = new System.Drawing.Point(29, 32);
			this.pictureRadioButton.Name = "pictureRadioButton";
			this.pictureRadioButton.Size = new System.Drawing.Size(58, 17);
			this.pictureRadioButton.TabIndex = 1;
			this.pictureRadioButton.TabStop = true;
			this.pictureRadioButton.Text = "&Picture";
			this.pictureRadioButton.UseVisualStyleBackColor = true;
			this.pictureRadioButton.CheckedChanged += new System.EventHandler(this.mediaTypeRadioButton_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(235, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "What media do you want to see during the quiz?";
			// 
			// mnemonicGroupBox
			// 
			this.mnemonicGroupBox.Controls.Add(this.label9);
			this.mnemonicGroupBox.Controls.Add(this.mnemonicNoRadioButton);
			this.mnemonicGroupBox.Controls.Add(this.mnemonicYesRadioButton);
			this.mnemonicGroupBox.Location = new System.Drawing.Point(334, 303);
			this.mnemonicGroupBox.Name = "mnemonicGroupBox";
			this.mnemonicGroupBox.Size = new System.Drawing.Size(219, 74);
			this.mnemonicGroupBox.TabIndex = 4;
			this.mnemonicGroupBox.TabStop = false;
			this.mnemonicGroupBox.Text = "Mnemonic";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(206, 28);
			this.label9.TabIndex = 0;
			this.label9.Text = "Would you like to see a written description of the sound?";
			// 
			// mnemonicNoRadioButton
			// 
			this.mnemonicNoRadioButton.AutoSize = true;
			this.mnemonicNoRadioButton.Location = new System.Drawing.Point(76, 47);
			this.mnemonicNoRadioButton.Name = "mnemonicNoRadioButton";
			this.mnemonicNoRadioButton.Size = new System.Drawing.Size(39, 17);
			this.mnemonicNoRadioButton.TabIndex = 2;
			this.mnemonicNoRadioButton.TabStop = true;
			this.mnemonicNoRadioButton.Text = "&No";
			this.mnemonicNoRadioButton.UseVisualStyleBackColor = true;
			// 
			// mnemonicYesRadioButton
			// 
			this.mnemonicYesRadioButton.AutoSize = true;
			this.mnemonicYesRadioButton.Location = new System.Drawing.Point(29, 47);
			this.mnemonicYesRadioButton.Name = "mnemonicYesRadioButton";
			this.mnemonicYesRadioButton.Size = new System.Drawing.Size(43, 17);
			this.mnemonicYesRadioButton.TabIndex = 1;
			this.mnemonicYesRadioButton.TabStop = true;
			this.mnemonicYesRadioButton.Text = "&Yes";
			this.mnemonicYesRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(label8);
			this.groupBox1.Controls.Add(this.displayNextMediaTimerLengthNumericUpDown);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(label5);
			this.groupBox1.Controls.Add(label1);
			this.groupBox1.Controls.Add(label4);
			this.groupBox1.Controls.Add(label3);
			this.groupBox1.Controls.Add(this.displayNextItemTimerLengthNumericUpDown);
			this.groupBox1.Controls.Add(this.displayNameTimerLengthNumericUpDown);
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(548, 122);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Display Options";
			// 
			// displayNextMediaTimerLengthNumericUpDown
			// 
			this.displayNextMediaTimerLengthNumericUpDown.Location = new System.Drawing.Point(434, 86);
			this.displayNextMediaTimerLengthNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.displayNextMediaTimerLengthNumericUpDown.Name = "displayNextMediaTimerLengthNumericUpDown";
			this.displayNextMediaTimerLengthNumericUpDown.Size = new System.Drawing.Size(52, 20);
			this.displayNextMediaTimerLengthNumericUpDown.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 88);
			this.label7.MaximumSize = new System.Drawing.Size(400, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(398, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "When displaying all media, how long do you want to wait to display the next media" +
    "?";
			// 
			// displayNextItemTimerLengthNumericUpDown
			// 
			this.displayNextItemTimerLengthNumericUpDown.Location = new System.Drawing.Point(434, 54);
			this.displayNextItemTimerLengthNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.displayNextItemTimerLengthNumericUpDown.Name = "displayNextItemTimerLengthNumericUpDown";
			this.displayNextItemTimerLengthNumericUpDown.Size = new System.Drawing.Size(52, 20);
			this.displayNextItemTimerLengthNumericUpDown.TabIndex = 4;
			// 
			// displayNameTimerLengthNumericUpDown
			// 
			this.displayNameTimerLengthNumericUpDown.Location = new System.Drawing.Point(434, 22);
			this.displayNameTimerLengthNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.displayNameTimerLengthNumericUpDown.Name = "displayNameTimerLengthNumericUpDown";
			this.displayNameTimerLengthNumericUpDown.Size = new System.Drawing.Size(52, 20);
			this.displayNameTimerLengthNumericUpDown.TabIndex = 1;
			// 
			// commonNameRadioButton
			// 
			this.commonNameRadioButton.AutoSize = true;
			this.commonNameRadioButton.Location = new System.Drawing.Point(29, 19);
			this.commonNameRadioButton.Name = "commonNameRadioButton";
			this.commonNameRadioButton.Size = new System.Drawing.Size(97, 17);
			this.commonNameRadioButton.TabIndex = 0;
			this.commonNameRadioButton.TabStop = true;
			this.commonNameRadioButton.Text = "&Common Name";
			this.commonNameRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bandCodeRadioButton);
			this.groupBox2.Controls.Add(this.languageAllRadioButton);
			this.groupBox2.Controls.Add(this.scientificNameRadioButton);
			this.groupBox2.Controls.Add(this.commonNameRadioButton);
			this.groupBox2.Location = new System.Drawing.Point(5, 133);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(548, 47);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Language";
			// 
			// bandCodeRadioButton
			// 
			this.bandCodeRadioButton.AutoSize = true;
			this.bandCodeRadioButton.Location = new System.Drawing.Point(238, 20);
			this.bandCodeRadioButton.Name = "bandCodeRadioButton";
			this.bandCodeRadioButton.Size = new System.Drawing.Size(78, 17);
			this.bandCodeRadioButton.TabIndex = 2;
			this.bandCodeRadioButton.TabStop = true;
			this.bandCodeRadioButton.Text = "Ban&d Code";
			this.bandCodeRadioButton.UseVisualStyleBackColor = true;
			// 
			// languageAllRadioButton
			// 
			this.languageAllRadioButton.AutoSize = true;
			this.languageAllRadioButton.Location = new System.Drawing.Point(322, 20);
			this.languageAllRadioButton.Name = "languageAllRadioButton";
			this.languageAllRadioButton.Size = new System.Drawing.Size(36, 17);
			this.languageAllRadioButton.TabIndex = 3;
			this.languageAllRadioButton.TabStop = true;
			this.languageAllRadioButton.Text = "A&ll";
			this.languageAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// scientificNameRadioButton
			// 
			this.scientificNameRadioButton.AutoSize = true;
			this.scientificNameRadioButton.Location = new System.Drawing.Point(132, 19);
			this.scientificNameRadioButton.Name = "scientificNameRadioButton";
			this.scientificNameRadioButton.Size = new System.Drawing.Size(99, 17);
			this.scientificNameRadioButton.TabIndex = 1;
			this.scientificNameRadioButton.TabStop = true;
			this.scientificNameRadioButton.Text = "&Scientific Name";
			this.scientificNameRadioButton.UseVisualStyleBackColor = true;
			// 
			// pronunciationGroupBox
			// 
			this.pronunciationGroupBox.Controls.Add(this.pronunciationNoRadioButton);
			this.pronunciationGroupBox.Controls.Add(this.pronunciationYesRadioButton);
			this.pronunciationGroupBox.Controls.Add(this.label6);
			this.pronunciationGroupBox.Location = new System.Drawing.Point(5, 303);
			this.pronunciationGroupBox.Name = "pronunciationGroupBox";
			this.pronunciationGroupBox.Size = new System.Drawing.Size(323, 74);
			this.pronunciationGroupBox.TabIndex = 3;
			this.pronunciationGroupBox.TabStop = false;
			this.pronunciationGroupBox.Text = "Pronunciation";
			// 
			// pronunciationNoRadioButton
			// 
			this.pronunciationNoRadioButton.AutoSize = true;
			this.pronunciationNoRadioButton.Location = new System.Drawing.Point(76, 47);
			this.pronunciationNoRadioButton.Name = "pronunciationNoRadioButton";
			this.pronunciationNoRadioButton.Size = new System.Drawing.Size(39, 17);
			this.pronunciationNoRadioButton.TabIndex = 2;
			this.pronunciationNoRadioButton.TabStop = true;
			this.pronunciationNoRadioButton.Text = "N&o";
			this.pronunciationNoRadioButton.UseVisualStyleBackColor = true;
			// 
			// pronunciationYesRadioButton
			// 
			this.pronunciationYesRadioButton.AutoSize = true;
			this.pronunciationYesRadioButton.Location = new System.Drawing.Point(29, 47);
			this.pronunciationYesRadioButton.Name = "pronunciationYesRadioButton";
			this.pronunciationYesRadioButton.Size = new System.Drawing.Size(43, 17);
			this.pronunciationYesRadioButton.TabIndex = 1;
			this.pronunciationYesRadioButton.TabStop = true;
			this.pronunciationYesRadioButton.Text = "Y&es";
			this.pronunciationYesRadioButton.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(297, 28);
			this.label6.TabIndex = 0;
			this.label6.Text = "Would you like to hear a pronunciation of the common and/or scientific names?";
			// 
			// femaleOtherPictureRadioButton
			// 
			this.femaleOtherPictureRadioButton.AutoSize = true;
			this.femaleOtherPictureRadioButton.Location = new System.Drawing.Point(70, 19);
			this.femaleOtherPictureRadioButton.Name = "femaleOtherPictureRadioButton";
			this.femaleOtherPictureRadioButton.Size = new System.Drawing.Size(90, 17);
			this.femaleOtherPictureRadioButton.TabIndex = 1;
			this.femaleOtherPictureRadioButton.TabStop = true;
			this.femaleOtherPictureRadioButton.Text = "Female/Other";
			this.femaleOtherPictureRadioButton.UseVisualStyleBackColor = true;
			// 
			// QuizFlashCardPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pronunciationGroupBox);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.mnemonicGroupBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "QuizFlashCardPanel";
			this.Size = new System.Drawing.Size(558, 380);
			this.Load += new System.EventHandler(this.QuizFlashCardPanel_Load);
			this.pictureTypeGroupBox.ResumeLayout(false);
			this.pictureTypeGroupBox.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.videoTypeGroupBox.ResumeLayout(false);
			this.videoTypeGroupBox.PerformLayout();
			this.soundTypeGroupBox.ResumeLayout(false);
			this.soundTypeGroupBox.PerformLayout();
			this.mnemonicGroupBox.ResumeLayout(false);
			this.mnemonicGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.displayNextMediaTimerLengthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayNextItemTimerLengthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayNameTimerLengthNumericUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.pronunciationGroupBox.ResumeLayout(false);
			this.pronunciationGroupBox.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.RadioButton bestPictureRadioButton;
		private System.Windows.Forms.RadioButton videoRadioButton;
		private System.Windows.Forms.RadioButton randomPictureRadioButton;
		private System.Windows.Forms.GroupBox pictureTypeGroupBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton soundRadioButton;
		private System.Windows.Forms.RadioButton pictureAndSoundRadioButton;
		private System.Windows.Forms.RadioButton pictureRadioButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton commonNameRadioButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton scientificNameRadioButton;
		private System.Windows.Forms.NumericUpDown displayNextItemTimerLengthNumericUpDown;
		private System.Windows.Forms.NumericUpDown displayNameTimerLengthNumericUpDown;
		private System.Windows.Forms.GroupBox pronunciationGroupBox;
		private System.Windows.Forms.GroupBox mnemonicGroupBox;
		private System.Windows.Forms.RadioButton mnemonicYesRadioButton;
		private System.Windows.Forms.RadioButton mnemonicNoRadioButton;
		private System.Windows.Forms.RadioButton languageAllRadioButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton pronunciationNoRadioButton;
		private System.Windows.Forms.RadioButton pronunciationYesRadioButton;
		private System.Windows.Forms.RadioButton rangeMapRadioButton;
		private System.Windows.Forms.RadioButton allMediaRadioButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown displayNextMediaTimerLengthNumericUpDown;
		private System.Windows.Forms.RadioButton bandCodeRadioButton;
		private System.Windows.Forms.GroupBox videoTypeGroupBox;
		private System.Windows.Forms.RadioButton randomVideoRadioButton;
		private System.Windows.Forms.RadioButton bestVideoRadioButton;
		private System.Windows.Forms.GroupBox soundTypeGroupBox;
		private System.Windows.Forms.RadioButton randomSoundRadioButton;
		private System.Windows.Forms.RadioButton bestSoundRadioButton;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.RadioButton femaleOtherPictureRadioButton;

	}
}
