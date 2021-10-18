namespace Thayer.Birding.UI.Windows.Quiz
{
    partial class QuizCommonOptionsPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizCommonOptionsPanel));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.shuffleYesRadioButton = new System.Windows.Forms.RadioButton();
			this.shuffleNoRadioButton = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.observedYesRadioButton = new System.Windows.Forms.RadioButton();
			this.observedNoRadioButton = new System.Windows.Forms.RadioButton();
			this.observedGroupBox = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.observerComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.frequencyLabel = new System.Windows.Forms.Label();
			this.frequencyTrackBar = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.soundEffectsGroupBox = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.soundEffectsIncorrectSoundButton = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.soundEffectsIncorrectBrowseButton = new System.Windows.Forms.Button();
			this.soundEffectsCorrectSoundButton = new System.Windows.Forms.Button();
			this.soundEffectsCorrectBrowseButton = new System.Windows.Forms.Button();
			this.soundEffectsIncorrectTextBox = new System.Windows.Forms.TextBox();
			this.soundEffectsCorrectTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.soundEffectsNoRadioButton = new System.Windows.Forms.RadioButton();
			this.soundEffectsYesRadioButton = new System.Windows.Forms.RadioButton();
			this.loopGroupBox = new System.Windows.Forms.GroupBox();
			this.loopNoRadioButton = new System.Windows.Forms.RadioButton();
			this.loopYesRadioButton = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.loopYesWithShuffleRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.observedGroupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.frequencyTrackBar)).BeginInit();
			this.soundEffectsGroupBox.SuspendLayout();
			this.panel2.SuspendLayout();
			this.loopGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.shuffleYesRadioButton);
			this.groupBox1.Controls.Add(this.shuffleNoRadioButton);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(548, 62);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Shuffle";
			// 
			// shuffleYesRadioButton
			// 
			this.shuffleYesRadioButton.AutoSize = true;
			this.shuffleYesRadioButton.Location = new System.Drawing.Point(29, 35);
			this.shuffleYesRadioButton.Name = "shuffleYesRadioButton";
			this.shuffleYesRadioButton.Size = new System.Drawing.Size(43, 17);
			this.shuffleYesRadioButton.TabIndex = 1;
			this.shuffleYesRadioButton.TabStop = true;
			this.shuffleYesRadioButton.Text = "&Yes";
			this.toolTip.SetToolTip(this.shuffleYesRadioButton, "Shuffle the order in which they appear");
			this.shuffleYesRadioButton.UseVisualStyleBackColor = true;
			// 
			// shuffleNoRadioButton
			// 
			this.shuffleNoRadioButton.AutoSize = true;
			this.shuffleNoRadioButton.Location = new System.Drawing.Point(78, 35);
			this.shuffleNoRadioButton.Name = "shuffleNoRadioButton";
			this.shuffleNoRadioButton.Size = new System.Drawing.Size(39, 17);
			this.shuffleNoRadioButton.TabIndex = 2;
			this.shuffleNoRadioButton.TabStop = true;
			this.shuffleNoRadioButton.Text = "&No";
			this.toolTip.SetToolTip(this.shuffleNoRadioButton, "Display in preset order if using a custom list, otherwise display in taxonomic or" +
        "der");
			this.shuffleNoRadioButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Should items be \"shuffled\" before each quiz?";
			// 
			// observedYesRadioButton
			// 
			this.observedYesRadioButton.AutoSize = true;
			this.observedYesRadioButton.Location = new System.Drawing.Point(29, 35);
			this.observedYesRadioButton.Name = "observedYesRadioButton";
			this.observedYesRadioButton.Size = new System.Drawing.Size(43, 17);
			this.observedYesRadioButton.TabIndex = 1;
			this.observedYesRadioButton.TabStop = true;
			this.observedYesRadioButton.Text = "Y&es";
			this.observedYesRadioButton.UseVisualStyleBackColor = true;
			this.observedYesRadioButton.CheckedChanged += new System.EventHandler(this.observedYesRadioButton_CheckedChanged);
			// 
			// observedNoRadioButton
			// 
			this.observedNoRadioButton.AutoSize = true;
			this.observedNoRadioButton.Location = new System.Drawing.Point(78, 35);
			this.observedNoRadioButton.Name = "observedNoRadioButton";
			this.observedNoRadioButton.Size = new System.Drawing.Size(39, 17);
			this.observedNoRadioButton.TabIndex = 2;
			this.observedNoRadioButton.TabStop = true;
			this.observedNoRadioButton.Text = "N&o";
			this.observedNoRadioButton.UseVisualStyleBackColor = true;
			// 
			// observedGroupBox
			// 
			this.observedGroupBox.Controls.Add(this.panel1);
			this.observedGroupBox.Controls.Add(this.observedYesRadioButton);
			this.observedGroupBox.Controls.Add(this.observedNoRadioButton);
			this.observedGroupBox.Controls.Add(this.label2);
			this.observedGroupBox.Location = new System.Drawing.Point(5, 73);
			this.observedGroupBox.Name = "observedGroupBox";
			this.observedGroupBox.Size = new System.Drawing.Size(548, 90);
			this.observedGroupBox.TabIndex = 1;
			this.observedGroupBox.TabStop = false;
			this.observedGroupBox.Text = "Observed";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.observerComboBox);
			this.panel1.Location = new System.Drawing.Point(6, 54);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(468, 30);
			this.panel1.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "O&bserver:";
			// 
			// observerComboBox
			// 
			this.observerComboBox.FormattingEnabled = true;
			this.observerComboBox.Location = new System.Drawing.Point(61, 5);
			this.observerComboBox.Name = "observerComboBox";
			this.observerComboBox.Size = new System.Drawing.Size(211, 21);
			this.observerComboBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(270, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Exclude those things that have already been observed?";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.frequencyLabel);
			this.groupBox3.Controls.Add(this.frequencyTrackBar);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(5, 169);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(548, 75);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Item Frequency";
			// 
			// frequencyLabel
			// 
			this.frequencyLabel.AutoSize = true;
			this.frequencyLabel.Location = new System.Drawing.Point(346, 40);
			this.frequencyLabel.Name = "frequencyLabel";
			this.frequencyLabel.Size = new System.Drawing.Size(100, 13);
			this.frequencyLabel.TabIndex = 3;
			this.frequencyLabel.Text = "Fill in statistics here!";
			// 
			// frequencyTrackBar
			// 
			this.frequencyTrackBar.AutoSize = false;
			this.frequencyTrackBar.LargeChange = 10;
			this.frequencyTrackBar.Location = new System.Drawing.Point(77, 36);
			this.frequencyTrackBar.Maximum = 50;
			this.frequencyTrackBar.Name = "frequencyTrackBar";
			this.frequencyTrackBar.Size = new System.Drawing.Size(263, 32);
			this.frequencyTrackBar.TabIndex = 2;
			this.frequencyTrackBar.Scroll += new System.EventHandler(this.frequencyTrackBar_Scroll);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "How &many?";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(237, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Should items in the quiz appear more than once?";
			// 
			// soundEffectsGroupBox
			// 
			this.soundEffectsGroupBox.Controls.Add(this.panel2);
			this.soundEffectsGroupBox.Controls.Add(this.soundEffectsNoRadioButton);
			this.soundEffectsGroupBox.Controls.Add(this.soundEffectsYesRadioButton);
			this.soundEffectsGroupBox.Location = new System.Drawing.Point(5, 250);
			this.soundEffectsGroupBox.Name = "soundEffectsGroupBox";
			this.soundEffectsGroupBox.Size = new System.Drawing.Size(548, 112);
			this.soundEffectsGroupBox.TabIndex = 3;
			this.soundEffectsGroupBox.TabStop = false;
			this.soundEffectsGroupBox.Text = "Sound Effects";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.soundEffectsIncorrectSoundButton);
			this.panel2.Controls.Add(this.soundEffectsIncorrectBrowseButton);
			this.panel2.Controls.Add(this.soundEffectsCorrectSoundButton);
			this.panel2.Controls.Add(this.soundEffectsCorrectBrowseButton);
			this.panel2.Controls.Add(this.soundEffectsIncorrectTextBox);
			this.panel2.Controls.Add(this.soundEffectsCorrectTextBox);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new System.Drawing.Point(40, 37);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(434, 47);
			this.panel2.TabIndex = 2;
			// 
			// soundEffectsIncorrectSoundButton
			// 
			this.soundEffectsIncorrectSoundButton.AutoSize = true;
			this.soundEffectsIncorrectSoundButton.BackColor = System.Drawing.SystemColors.Control;
			this.soundEffectsIncorrectSoundButton.ImageIndex = 1;
			this.soundEffectsIncorrectSoundButton.ImageList = this.imageList;
			this.soundEffectsIncorrectSoundButton.Location = new System.Drawing.Point(389, 24);
			this.soundEffectsIncorrectSoundButton.Name = "soundEffectsIncorrectSoundButton";
			this.soundEffectsIncorrectSoundButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.soundEffectsIncorrectSoundButton.Size = new System.Drawing.Size(23, 22);
			this.soundEffectsIncorrectSoundButton.TabIndex = 7;
			this.toolTip.SetToolTip(this.soundEffectsIncorrectSoundButton, "Play the sound effect file");
			this.soundEffectsIncorrectSoundButton.UseVisualStyleBackColor = false;
			this.soundEffectsIncorrectSoundButton.Click += new System.EventHandler(this.soundEffectsIncorrectSoundButton_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList.Images.SetKeyName(0, "Find.bmp");
			this.imageList.Images.SetKeyName(1, "Speaker.bmp");
			// 
			// soundEffectsIncorrectBrowseButton
			// 
			this.soundEffectsIncorrectBrowseButton.AutoSize = true;
			this.soundEffectsIncorrectBrowseButton.ImageIndex = 0;
			this.soundEffectsIncorrectBrowseButton.ImageList = this.imageList;
			this.soundEffectsIncorrectBrowseButton.Location = new System.Drawing.Point(361, 24);
			this.soundEffectsIncorrectBrowseButton.Name = "soundEffectsIncorrectBrowseButton";
			this.soundEffectsIncorrectBrowseButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.soundEffectsIncorrectBrowseButton.Size = new System.Drawing.Size(23, 22);
			this.soundEffectsIncorrectBrowseButton.TabIndex = 6;
			this.toolTip.SetToolTip(this.soundEffectsIncorrectBrowseButton, "Browse your system for a sound file");
			this.soundEffectsIncorrectBrowseButton.UseVisualStyleBackColor = true;
			this.soundEffectsIncorrectBrowseButton.Click += new System.EventHandler(this.soundEffectsIncorrectBrowseButton_Click);
			// 
			// soundEffectsCorrectSoundButton
			// 
			this.soundEffectsCorrectSoundButton.AutoSize = true;
			this.soundEffectsCorrectSoundButton.BackColor = System.Drawing.SystemColors.Control;
			this.soundEffectsCorrectSoundButton.ImageIndex = 1;
			this.soundEffectsCorrectSoundButton.ImageList = this.imageList;
			this.soundEffectsCorrectSoundButton.Location = new System.Drawing.Point(389, 1);
			this.soundEffectsCorrectSoundButton.Name = "soundEffectsCorrectSoundButton";
			this.soundEffectsCorrectSoundButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.soundEffectsCorrectSoundButton.Size = new System.Drawing.Size(23, 22);
			this.soundEffectsCorrectSoundButton.TabIndex = 3;
			this.toolTip.SetToolTip(this.soundEffectsCorrectSoundButton, "Play the sound effect file");
			this.soundEffectsCorrectSoundButton.UseVisualStyleBackColor = false;
			this.soundEffectsCorrectSoundButton.Click += new System.EventHandler(this.soundEffectsCorrectSoundButton_Click);
			// 
			// soundEffectsCorrectBrowseButton
			// 
			this.soundEffectsCorrectBrowseButton.AutoSize = true;
			this.soundEffectsCorrectBrowseButton.ImageIndex = 0;
			this.soundEffectsCorrectBrowseButton.ImageList = this.imageList;
			this.soundEffectsCorrectBrowseButton.Location = new System.Drawing.Point(361, 1);
			this.soundEffectsCorrectBrowseButton.Name = "soundEffectsCorrectBrowseButton";
			this.soundEffectsCorrectBrowseButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.soundEffectsCorrectBrowseButton.Size = new System.Drawing.Size(23, 22);
			this.soundEffectsCorrectBrowseButton.TabIndex = 2;
			this.toolTip.SetToolTip(this.soundEffectsCorrectBrowseButton, "Browse your system for a sound file");
			this.soundEffectsCorrectBrowseButton.UseVisualStyleBackColor = true;
			this.soundEffectsCorrectBrowseButton.Click += new System.EventHandler(this.soundEffectsCorrectBrowseButton_Click);
			// 
			// soundEffectsIncorrectTextBox
			// 
			this.soundEffectsIncorrectTextBox.Location = new System.Drawing.Point(117, 24);
			this.soundEffectsIncorrectTextBox.Name = "soundEffectsIncorrectTextBox";
			this.soundEffectsIncorrectTextBox.Size = new System.Drawing.Size(235, 20);
			this.soundEffectsIncorrectTextBox.TabIndex = 5;
			this.soundEffectsIncorrectTextBox.TextChanged += new System.EventHandler(this.soundEffectsIncorrectTextBox_TextChanged);
			// 
			// soundEffectsCorrectTextBox
			// 
			this.soundEffectsCorrectTextBox.Location = new System.Drawing.Point(117, 1);
			this.soundEffectsCorrectTextBox.Name = "soundEffectsCorrectTextBox";
			this.soundEffectsCorrectTextBox.Size = new System.Drawing.Size(235, 20);
			this.soundEffectsCorrectTextBox.TabIndex = 1;
			this.soundEffectsCorrectTextBox.TextChanged += new System.EventHandler(this.soundEffectsCorrectTextBox_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(24, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "&Incorrect Answer:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "&Correct Answer:";
			// 
			// soundEffectsNoRadioButton
			// 
			this.soundEffectsNoRadioButton.AutoSize = true;
			this.soundEffectsNoRadioButton.Location = new System.Drawing.Point(29, 83);
			this.soundEffectsNoRadioButton.Name = "soundEffectsNoRadioButton";
			this.soundEffectsNoRadioButton.Size = new System.Drawing.Size(114, 17);
			this.soundEffectsNoRadioButton.TabIndex = 1;
			this.soundEffectsNoRadioButton.TabStop = true;
			this.soundEffectsNoRadioButton.Text = "No, &don\'t use them";
			this.soundEffectsNoRadioButton.UseVisualStyleBackColor = true;
			// 
			// soundEffectsYesRadioButton
			// 
			this.soundEffectsYesRadioButton.AutoSize = true;
			this.soundEffectsYesRadioButton.Location = new System.Drawing.Point(29, 19);
			this.soundEffectsYesRadioButton.Name = "soundEffectsYesRadioButton";
			this.soundEffectsYesRadioButton.Size = new System.Drawing.Size(198, 17);
			this.soundEffectsYesRadioButton.TabIndex = 0;
			this.soundEffectsYesRadioButton.TabStop = true;
			this.soundEffectsYesRadioButton.Text = "Yes, &use the following sound effects:";
			this.soundEffectsYesRadioButton.UseVisualStyleBackColor = true;
			this.soundEffectsYesRadioButton.CheckedChanged += new System.EventHandler(this.soundEffectsYesRadioButton_CheckedChanged);
			// 
			// loopGroupBox
			// 
			this.loopGroupBox.Controls.Add(this.loopYesWithShuffleRadioButton);
			this.loopGroupBox.Controls.Add(this.loopNoRadioButton);
			this.loopGroupBox.Controls.Add(this.loopYesRadioButton);
			this.loopGroupBox.Controls.Add(this.label8);
			this.loopGroupBox.Location = new System.Drawing.Point(5, 250);
			this.loopGroupBox.Name = "loopGroupBox";
			this.loopGroupBox.Size = new System.Drawing.Size(490, 62);
			this.loopGroupBox.TabIndex = 4;
			this.loopGroupBox.TabStop = false;
			this.loopGroupBox.Text = "Loop";
			// 
			// loopNoRadioButton
			// 
			this.loopNoRadioButton.AutoSize = true;
			this.loopNoRadioButton.Location = new System.Drawing.Point(78, 35);
			this.loopNoRadioButton.Name = "loopNoRadioButton";
			this.loopNoRadioButton.Size = new System.Drawing.Size(39, 17);
			this.loopNoRadioButton.TabIndex = 2;
			this.loopNoRadioButton.TabStop = true;
			this.loopNoRadioButton.Text = "No";
			this.loopNoRadioButton.UseVisualStyleBackColor = true;
			// 
			// loopYesRadioButton
			// 
			this.loopYesRadioButton.AutoSize = true;
			this.loopYesRadioButton.Location = new System.Drawing.Point(29, 35);
			this.loopYesRadioButton.Name = "loopYesRadioButton";
			this.loopYesRadioButton.Size = new System.Drawing.Size(43, 17);
			this.loopYesRadioButton.TabIndex = 1;
			this.loopYesRadioButton.TabStop = true;
			this.loopYesRadioButton.Text = "Yes";
			this.loopYesRadioButton.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(278, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Do you want the flash cards to loop over and over again?";
			// 
			// loopYesWithShuffleRadioButton
			// 
			this.loopYesWithShuffleRadioButton.AutoSize = true;
			this.loopYesWithShuffleRadioButton.Location = new System.Drawing.Point(124, 35);
			this.loopYesWithShuffleRadioButton.Name = "loopYesWithShuffleRadioButton";
			this.loopYesWithShuffleRadioButton.Size = new System.Drawing.Size(105, 17);
			this.loopYesWithShuffleRadioButton.TabIndex = 3;
			this.loopYesWithShuffleRadioButton.TabStop = true;
			this.loopYesWithShuffleRadioButton.Text = "Yes (with shuffle)";
			this.loopYesWithShuffleRadioButton.UseVisualStyleBackColor = true;
			// 
			// QuizCommonOptionsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.observedGroupBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.soundEffectsGroupBox);
			this.Controls.Add(this.loopGroupBox);
			this.Name = "QuizCommonOptionsPanel";
			this.Size = new System.Drawing.Size(558, 380);
			this.Load += new System.EventHandler(this.QuizCommonOptionsPanel_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.observedGroupBox.ResumeLayout(false);
			this.observedGroupBox.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.frequencyTrackBar)).EndInit();
			this.soundEffectsGroupBox.ResumeLayout(false);
			this.soundEffectsGroupBox.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.loopGroupBox.ResumeLayout(false);
			this.loopGroupBox.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton shuffleNoRadioButton;
		private System.Windows.Forms.RadioButton shuffleYesRadioButton;
		private System.Windows.Forms.GroupBox observedGroupBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton observedYesRadioButton;
		private System.Windows.Forms.RadioButton observedNoRadioButton;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar frequencyTrackBar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox soundEffectsGroupBox;
		private System.Windows.Forms.RadioButton soundEffectsYesRadioButton;
		private System.Windows.Forms.RadioButton soundEffectsNoRadioButton;
		private System.Windows.Forms.Label frequencyLabel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox observerComboBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button soundEffectsIncorrectSoundButton;
		private System.Windows.Forms.Button soundEffectsIncorrectBrowseButton;
		private System.Windows.Forms.Button soundEffectsCorrectSoundButton;
		private System.Windows.Forms.Button soundEffectsCorrectBrowseButton;
		private System.Windows.Forms.TextBox soundEffectsIncorrectTextBox;
		private System.Windows.Forms.TextBox soundEffectsCorrectTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.GroupBox loopGroupBox;
		private System.Windows.Forms.RadioButton loopNoRadioButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton loopYesRadioButton;
		private System.Windows.Forms.RadioButton loopYesWithShuffleRadioButton;
    }
}
