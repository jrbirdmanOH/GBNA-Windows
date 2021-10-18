namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class QuizPickOneForm
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
			this.scoreCorrectLabel = new System.Windows.Forms.Label();
			this.scoreRemainingLabel = new System.Windows.Forms.Label();
			this.scoreIncorrectLabel = new System.Windows.Forms.Label();
			this.quizSourceLabel = new System.Windows.Forms.Label();
			this.quizEngine = new Thayer.Birding.UI.Quiz.QuizEngine();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.goToComboBox = new System.Windows.Forms.ComboBox();
			this.goToGroupBox = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.answerGroupBox = new System.Windows.Forms.GroupBox();
			this.answerMessageLabel = new System.Windows.Forms.Label();
			this.scientificNameLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.answerNameLabel = new System.Windows.Forms.Label();
			this.showNamesButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.mediaGroupBox = new System.Windows.Forms.GroupBox();
			this.pickOneMediaPlayer = new Thayer.Birding.UI.Windows.Quiz.PickOneMediaPlayer();
			this.nextButton = new System.Windows.Forms.Button();
			this.quizSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.finishButton = new System.Windows.Forms.Button();
			this.scoreGroupBox = new System.Windows.Forms.GroupBox();
			this.quizMediaPlayer = new Thayer.Birding.UI.Windows.Quiz.QuizMediaPlayer();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.compareButton = new System.Windows.Forms.Button();
			this.goToGroupBox.SuspendLayout();
			this.answerGroupBox.SuspendLayout();
			this.mediaGroupBox.SuspendLayout();
			this.quizSourceGroupBox.SuspendLayout();
			this.scoreGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// scoreCorrectLabel
			// 
			this.scoreCorrectLabel.ForeColor = System.Drawing.Color.Green;
			this.scoreCorrectLabel.Location = new System.Drawing.Point(75, 34);
			this.scoreCorrectLabel.Name = "scoreCorrectLabel";
			this.scoreCorrectLabel.Size = new System.Drawing.Size(41, 13);
			this.scoreCorrectLabel.TabIndex = 3;
			this.scoreCorrectLabel.Text = "0";
			this.scoreCorrectLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// scoreRemainingLabel
			// 
			this.scoreRemainingLabel.Location = new System.Drawing.Point(11, 34);
			this.scoreRemainingLabel.Name = "scoreRemainingLabel";
			this.scoreRemainingLabel.Size = new System.Drawing.Size(57, 13);
			this.scoreRemainingLabel.TabIndex = 1;
			this.scoreRemainingLabel.Text = "25";
			this.scoreRemainingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// scoreIncorrectLabel
			// 
			this.scoreIncorrectLabel.ForeColor = System.Drawing.Color.Red;
			this.scoreIncorrectLabel.Location = new System.Drawing.Point(124, 34);
			this.scoreIncorrectLabel.Name = "scoreIncorrectLabel";
			this.scoreIncorrectLabel.Size = new System.Drawing.Size(49, 13);
			this.scoreIncorrectLabel.TabIndex = 5;
			this.scoreIncorrectLabel.Text = "0";
			this.scoreIncorrectLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// quizSourceLabel
			// 
			this.quizSourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.quizSourceLabel.Location = new System.Drawing.Point(11, 20);
			this.quizSourceLabel.Name = "quizSourceLabel";
			this.quizSourceLabel.Size = new System.Drawing.Size(659, 20);
			this.quizSourceLabel.TabIndex = 0;
			this.quizSourceLabel.Text = "Predefined Quiz:  25 Birds You Know";
			// 
			// quizEngine
			// 
			this.quizEngine.CurrentEntryIndex = 0;
			this.quizEngine.MediaPlayer = null;
			this.quizEngine.QuestionMode = Thayer.Birding.UI.Quiz.QuizEngine.QuestionModes.Answer;
			this.quizEngine.QuizForm = null;
			this.quizEngine.QuizSettings = null;
			this.quizEngine.SpeechProvider = null;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(124, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Incorrect";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Green;
			this.label2.Location = new System.Drawing.Point(75, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Correct";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Remaining";
			// 
			// goToComboBox
			// 
			this.goToComboBox.DropDownHeight = 150;
			this.goToComboBox.DropDownWidth = 200;
			this.goToComboBox.FormattingEnabled = true;
			this.goToComboBox.IntegralHeight = false;
			this.goToComboBox.Location = new System.Drawing.Point(59, 24);
			this.goToComboBox.Name = "goToComboBox";
			this.goToComboBox.Size = new System.Drawing.Size(118, 21);
			this.goToComboBox.TabIndex = 1;
			this.goToComboBox.SelectedIndexChanged += new System.EventHandler(this.goToComboBox_SelectedIndexChanged);
			this.goToComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.goToComboBox_KeyDown);
			// 
			// goToGroupBox
			// 
			this.goToGroupBox.Controls.Add(this.label4);
			this.goToGroupBox.Controls.Add(this.goToComboBox);
			this.goToGroupBox.Location = new System.Drawing.Point(7, 336);
			this.goToGroupBox.Name = "goToGroupBox";
			this.goToGroupBox.Size = new System.Drawing.Size(183, 54);
			this.goToGroupBox.TabIndex = 3;
			this.goToGroupBox.TabStop = false;
			this.goToGroupBox.Text = "Question 1 of 25";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Go To:";
			// 
			// answerGroupBox
			// 
			this.answerGroupBox.Controls.Add(this.answerMessageLabel);
			this.answerGroupBox.Controls.Add(this.scientificNameLabel);
			this.answerGroupBox.Controls.Add(this.label5);
			this.answerGroupBox.Controls.Add(this.answerNameLabel);
			this.answerGroupBox.Controls.Add(this.showNamesButton);
			this.answerGroupBox.Location = new System.Drawing.Point(7, 53);
			this.answerGroupBox.Name = "answerGroupBox";
			this.answerGroupBox.Size = new System.Drawing.Size(183, 217);
			this.answerGroupBox.TabIndex = 1;
			this.answerGroupBox.TabStop = false;
			this.answerGroupBox.Text = "Question";
			// 
			// answerMessageLabel
			// 
			this.answerMessageLabel.Location = new System.Drawing.Point(11, 110);
			this.answerMessageLabel.Name = "answerMessageLabel";
			this.answerMessageLabel.Size = new System.Drawing.Size(167, 61);
			this.answerMessageLabel.TabIndex = 3;
			this.answerMessageLabel.Text = "Answer message with some text to make it switch to three lines.  Will need more";
			// 
			// scientificNameLabel
			// 
			this.scientificNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scientificNameLabel.Location = new System.Drawing.Point(11, 75);
			this.scientificNameLabel.Name = "scientificNameLabel";
			this.scientificNameLabel.Size = new System.Drawing.Size(167, 31);
			this.scientificNameLabel.TabIndex = 2;
			this.scientificNameLabel.Text = "Scientific name with some more text";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(11, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Which of these is a...";
			// 
			// answerNameLabel
			// 
			this.answerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.answerNameLabel.Location = new System.Drawing.Point(11, 44);
			this.answerNameLabel.Name = "answerNameLabel";
			this.answerNameLabel.Size = new System.Drawing.Size(167, 31);
			this.answerNameLabel.TabIndex = 1;
			this.answerNameLabel.Text = "Organism name with some longer text";
			// 
			// showNamesButton
			// 
			this.showNamesButton.Location = new System.Drawing.Point(49, 185);
			this.showNamesButton.Name = "showNamesButton";
			this.showNamesButton.Size = new System.Drawing.Size(78, 23);
			this.showNamesButton.TabIndex = 4;
			this.showNamesButton.Text = "Show Names";
			this.showNamesButton.UseVisualStyleBackColor = true;
			this.showNamesButton.Click += new System.EventHandler(this.showNamesButton_Click);
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(531, 396);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 6;
			this.backButton.Text = "<< Previous";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// mediaGroupBox
			// 
			this.mediaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mediaGroupBox.Controls.Add(this.pickOneMediaPlayer);
			this.mediaGroupBox.Location = new System.Drawing.Point(196, 53);
			this.mediaGroupBox.Name = "mediaGroupBox";
			this.mediaGroupBox.Size = new System.Drawing.Size(487, 337);
			this.mediaGroupBox.TabIndex = 8;
			this.mediaGroupBox.TabStop = false;
			// 
			// pickOneMediaPlayer
			// 
			this.pickOneMediaPlayer.AllowSelection = true;
			this.pickOneMediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pickOneMediaPlayer.Location = new System.Drawing.Point(3, 16);
			this.pickOneMediaPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pickOneMediaPlayer.Name = "pickOneMediaPlayer";
			this.pickOneMediaPlayer.ShowNames = false;
			this.pickOneMediaPlayer.Size = new System.Drawing.Size(481, 318);
			this.pickOneMediaPlayer.TabIndex = 0;
			this.pickOneMediaPlayer.PickOnePictureClicked += new Thayer.Birding.UI.Windows.Quiz.PickOnePictureClickedEventHandler(this.pickOneMediaPlayer_PickOnePictureClicked);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(608, 396);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 7;
			this.nextButton.Text = "Next >>";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// quizSourceGroupBox
			// 
			this.quizSourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizSourceGroupBox.Controls.Add(this.quizSourceLabel);
			this.quizSourceGroupBox.Location = new System.Drawing.Point(7, 3);
			this.quizSourceGroupBox.Name = "quizSourceGroupBox";
			this.quizSourceGroupBox.Size = new System.Drawing.Size(676, 44);
			this.quizSourceGroupBox.TabIndex = 0;
			this.quizSourceGroupBox.TabStop = false;
			this.quizSourceGroupBox.Text = "Quiz Source";
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Location = new System.Drawing.Point(441, 396);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 5;
			this.finishButton.Text = "Stop";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// scoreGroupBox
			// 
			this.scoreGroupBox.Controls.Add(this.scoreIncorrectLabel);
			this.scoreGroupBox.Controls.Add(this.scoreCorrectLabel);
			this.scoreGroupBox.Controls.Add(this.scoreRemainingLabel);
			this.scoreGroupBox.Controls.Add(this.label3);
			this.scoreGroupBox.Controls.Add(this.label2);
			this.scoreGroupBox.Controls.Add(this.label1);
			this.scoreGroupBox.Location = new System.Drawing.Point(7, 276);
			this.scoreGroupBox.Name = "scoreGroupBox";
			this.scoreGroupBox.Size = new System.Drawing.Size(183, 54);
			this.scoreGroupBox.TabIndex = 2;
			this.scoreGroupBox.TabStop = false;
			this.scoreGroupBox.Text = "Your Score";
			// 
			// quizMediaPlayer
			// 
			this.quizMediaPlayer.MediaPlayer = null;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// compareButton
			// 
			this.compareButton.Location = new System.Drawing.Point(22, 396);
			this.compareButton.Name = "compareButton";
			this.compareButton.Size = new System.Drawing.Size(152, 23);
			this.compareButton.TabIndex = 4;
			this.compareButton.Text = "Compare";
			this.compareButton.UseVisualStyleBackColor = true;
			this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
			// 
			// QuizPickOneForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 423);
			this.Controls.Add(this.compareButton);
			this.Controls.Add(this.goToGroupBox);
			this.Controls.Add(this.answerGroupBox);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.mediaGroupBox);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.quizSourceGroupBox);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.scoreGroupBox);
			this.helpProvider.SetHelpKeyword(this, "60");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimumSize = new System.Drawing.Size(707, 461);
			this.Name = "QuizPickOneForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pick One Quiz";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizPickOneForm_FormClosing);
			this.Load += new System.EventHandler(this.QuizPickOneForm_Load);
			this.goToGroupBox.ResumeLayout(false);
			this.goToGroupBox.PerformLayout();
			this.answerGroupBox.ResumeLayout(false);
			this.answerGroupBox.PerformLayout();
			this.mediaGroupBox.ResumeLayout(false);
			this.quizSourceGroupBox.ResumeLayout(false);
			this.scoreGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label scoreCorrectLabel;
		private System.Windows.Forms.Label scoreRemainingLabel;
		private System.Windows.Forms.Label scoreIncorrectLabel;
		private System.Windows.Forms.Label quizSourceLabel;
		private Thayer.Birding.UI.Quiz.QuizEngine quizEngine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox goToComboBox;
		private System.Windows.Forms.GroupBox goToGroupBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox answerGroupBox;
		private System.Windows.Forms.Button showNamesButton;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.GroupBox mediaGroupBox;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.GroupBox quizSourceGroupBox;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.GroupBox scoreGroupBox;
		private System.Windows.Forms.Label answerNameLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label scientificNameLabel;
		private QuizMediaPlayer quizMediaPlayer;
		private System.Windows.Forms.Label answerMessageLabel;
		private PickOneMediaPlayer pickOneMediaPlayer;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button compareButton;
	}
}