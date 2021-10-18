namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class QuizFillInTheBlankForm
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
			this.mediaPlayer = new Thayer.Birding.UI.Windows.MediaPlayer();
			this.quizSourceLabel = new System.Windows.Forms.Label();
			this.quizMediaPlayer = new Thayer.Birding.UI.Windows.Quiz.QuizMediaPlayer();
			this.quizEngine = new Thayer.Birding.UI.Quiz.QuizEngine();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.goToComboBox = new System.Windows.Forms.ComboBox();
			this.clueComboBox = new Thayer.Birding.UI.Windows.MediaComboBox();
			this.goToGroupBox = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.answerGroupBox = new System.Windows.Forms.GroupBox();
			this.showAnswerButton = new System.Windows.Forms.Button();
			this.languageLabel = new System.Windows.Forms.Label();
			this.correctAnswerLabel = new System.Windows.Forms.Label();
			this.answerLabel = new System.Windows.Forms.Label();
			this.answerTextBox = new System.Windows.Forms.TextBox();
			this.answerButton = new System.Windows.Forms.Button();
			this.clueGroupBox = new System.Windows.Forms.GroupBox();
			this.backButton = new System.Windows.Forms.Button();
			this.mediaGroupBox = new System.Windows.Forms.GroupBox();
			this.nextButton = new System.Windows.Forms.Button();
			this.quizSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.finishButton = new System.Windows.Forms.Button();
			this.scoreGroupBox = new System.Windows.Forms.GroupBox();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.compareButton = new System.Windows.Forms.Button();
			this.goToGroupBox.SuspendLayout();
			this.answerGroupBox.SuspendLayout();
			this.clueGroupBox.SuspendLayout();
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
			// mediaPlayer
			// 
			this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mediaPlayer.Location = new System.Drawing.Point(3, 16);
			this.mediaPlayer.LoopText = "Loop";
			this.mediaPlayer.Name = "mediaPlayer";
			this.mediaPlayer.Size = new System.Drawing.Size(481, 280);
			this.mediaPlayer.TabIndex = 0;
			this.mediaPlayer.VideoZoomLevel = Thayer.Birding.UI.Windows.MediaPlayer.ZoomLevel.Normal;
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
			// quizMediaPlayer
			// 
			this.quizMediaPlayer.MediaPlayer = null;
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
			// clueComboBox
			// 
			this.clueComboBox.DropDownHeight = 175;
			this.clueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.clueComboBox.DropDownWidth = 225;
			this.clueComboBox.FormattingEnabled = true;
			this.clueComboBox.IncludeVideo = true;
			this.clueComboBox.IntegralHeight = false;
			this.clueComboBox.Location = new System.Drawing.Point(13, 20);
			this.clueComboBox.Name = "clueComboBox";
			this.clueComboBox.PreferredMediaID = 0;
			this.clueComboBox.Size = new System.Drawing.Size(159, 21);
			this.clueComboBox.TabIndex = 0;
			this.clueComboBox.SelectedIndexChanged += new System.EventHandler(this.clueComboBox_SelectedIndexChanged);
			// 
			// goToGroupBox
			// 
			this.goToGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.goToGroupBox.Controls.Add(this.label4);
			this.goToGroupBox.Controls.Add(this.goToComboBox);
			this.goToGroupBox.Location = new System.Drawing.Point(196, 365);
			this.goToGroupBox.Name = "goToGroupBox";
			this.goToGroupBox.Size = new System.Drawing.Size(183, 54);
			this.goToGroupBox.TabIndex = 4;
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
			this.answerGroupBox.Controls.Add(this.showAnswerButton);
			this.answerGroupBox.Controls.Add(this.languageLabel);
			this.answerGroupBox.Controls.Add(this.correctAnswerLabel);
			this.answerGroupBox.Controls.Add(this.answerLabel);
			this.answerGroupBox.Controls.Add(this.answerTextBox);
			this.answerGroupBox.Controls.Add(this.answerButton);
			this.answerGroupBox.Location = new System.Drawing.Point(7, 53);
			this.answerGroupBox.Name = "answerGroupBox";
			this.answerGroupBox.Size = new System.Drawing.Size(183, 246);
			this.answerGroupBox.TabIndex = 1;
			this.answerGroupBox.TabStop = false;
			this.answerGroupBox.Text = "What is this?";
			// 
			// showAnswerButton
			// 
			this.showAnswerButton.Location = new System.Drawing.Point(42, 184);
			this.showAnswerButton.Name = "showAnswerButton";
			this.showAnswerButton.Size = new System.Drawing.Size(90, 23);
			this.showAnswerButton.TabIndex = 4;
			this.showAnswerButton.Text = "Show Answer";
			this.showAnswerButton.UseVisualStyleBackColor = true;
			this.showAnswerButton.Click += new System.EventHandler(this.showAnswerButton_Click);
			// 
			// languageLabel
			// 
			this.languageLabel.AutoSize = true;
			this.languageLabel.Location = new System.Drawing.Point(7, 24);
			this.languageLabel.Name = "languageLabel";
			this.languageLabel.Size = new System.Drawing.Size(55, 13);
			this.languageLabel.TabIndex = 0;
			this.languageLabel.Text = "Language";
			// 
			// correctAnswerLabel
			// 
			this.correctAnswerLabel.Location = new System.Drawing.Point(7, 98);
			this.correctAnswerLabel.Name = "correctAnswerLabel";
			this.correctAnswerLabel.Size = new System.Drawing.Size(170, 80);
			this.correctAnswerLabel.TabIndex = 3;
			this.correctAnswerLabel.Text = "Correct answer description";
			// 
			// answerLabel
			// 
			this.answerLabel.AutoSize = true;
			this.answerLabel.Location = new System.Drawing.Point(7, 73);
			this.answerLabel.Name = "answerLabel";
			this.answerLabel.Size = new System.Drawing.Size(94, 13);
			this.answerLabel.TabIndex = 2;
			this.answerLabel.Text = "Correct / Incorrect";
			// 
			// answerTextBox
			// 
			this.answerTextBox.Location = new System.Drawing.Point(8, 41);
			this.answerTextBox.Name = "answerTextBox";
			this.answerTextBox.Size = new System.Drawing.Size(164, 20);
			this.answerTextBox.TabIndex = 1;
			this.answerTextBox.TextChanged += new System.EventHandler(this.answerTextBox_TextChanged);
			this.answerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerTextBox_KeyDown);
			// 
			// answerButton
			// 
			this.answerButton.Location = new System.Drawing.Point(50, 213);
			this.answerButton.Name = "answerButton";
			this.answerButton.Size = new System.Drawing.Size(75, 23);
			this.answerButton.TabIndex = 5;
			this.answerButton.Text = "Answer";
			this.answerButton.UseVisualStyleBackColor = true;
			this.answerButton.Click += new System.EventHandler(this.answerButton_Click);
			// 
			// clueGroupBox
			// 
			this.clueGroupBox.Controls.Add(this.clueComboBox);
			this.clueGroupBox.Location = new System.Drawing.Point(7, 305);
			this.clueGroupBox.Name = "clueGroupBox";
			this.clueGroupBox.Size = new System.Drawing.Size(183, 54);
			this.clueGroupBox.TabIndex = 2;
			this.clueGroupBox.TabStop = false;
			this.clueGroupBox.Text = "Need a clue?";
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(531, 396);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 7;
			this.backButton.Text = "<< Previous";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// mediaGroupBox
			// 
			this.mediaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mediaGroupBox.Controls.Add(this.mediaPlayer);
			this.mediaGroupBox.Location = new System.Drawing.Point(196, 53);
			this.mediaGroupBox.Name = "mediaGroupBox";
			this.mediaGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.mediaGroupBox.Size = new System.Drawing.Size(487, 306);
			this.mediaGroupBox.TabIndex = 9;
			this.mediaGroupBox.TabStop = false;
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(608, 396);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 8;
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
			this.finishButton.TabIndex = 6;
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
			this.scoreGroupBox.Location = new System.Drawing.Point(7, 365);
			this.scoreGroupBox.Name = "scoreGroupBox";
			this.scoreGroupBox.Size = new System.Drawing.Size(183, 54);
			this.scoreGroupBox.TabIndex = 3;
			this.scoreGroupBox.TabStop = false;
			this.scoreGroupBox.Text = "Your Score";
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// compareButton
			// 
			this.compareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.compareButton.Location = new System.Drawing.Point(531, 367);
			this.compareButton.Name = "compareButton";
			this.compareButton.Size = new System.Drawing.Size(152, 23);
			this.compareButton.TabIndex = 5;
			this.compareButton.Text = "Compare";
			this.compareButton.UseVisualStyleBackColor = true;
			this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
			// 
			// QuizFillInTheBlankForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 423);
			this.Controls.Add(this.compareButton);
			this.Controls.Add(this.goToGroupBox);
			this.Controls.Add(this.answerGroupBox);
			this.Controls.Add(this.clueGroupBox);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.mediaGroupBox);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.quizSourceGroupBox);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.scoreGroupBox);
			this.helpProvider.SetHelpKeyword(this, "57");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MinimumSize = new System.Drawing.Size(707, 461);
			this.Name = "QuizFillInTheBlankForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fill In The Blank Quiz";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizFillInTheBlankForm_FormClosing);
			this.Load += new System.EventHandler(this.QuizFillInTheBlankForm_Load);
			this.goToGroupBox.ResumeLayout(false);
			this.goToGroupBox.PerformLayout();
			this.answerGroupBox.ResumeLayout(false);
			this.answerGroupBox.PerformLayout();
			this.clueGroupBox.ResumeLayout(false);
			this.mediaGroupBox.ResumeLayout(false);
			this.quizSourceGroupBox.ResumeLayout(false);
			this.scoreGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label scoreCorrectLabel;
		private System.Windows.Forms.Label scoreRemainingLabel;
		private System.Windows.Forms.Label scoreIncorrectLabel;
		private MediaPlayer mediaPlayer;
		private System.Windows.Forms.Label quizSourceLabel;
		private QuizMediaPlayer quizMediaPlayer;
		private Thayer.Birding.UI.Quiz.QuizEngine quizEngine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox goToComboBox;
		private MediaComboBox clueComboBox;
		private System.Windows.Forms.GroupBox goToGroupBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox answerGroupBox;
		private System.Windows.Forms.Button answerButton;
		private System.Windows.Forms.GroupBox clueGroupBox;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.GroupBox mediaGroupBox;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.GroupBox quizSourceGroupBox;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.GroupBox scoreGroupBox;
		private System.Windows.Forms.TextBox answerTextBox;
		private System.Windows.Forms.Label answerLabel;
		private System.Windows.Forms.Label correctAnswerLabel;
		private System.Windows.Forms.Label languageLabel;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button showAnswerButton;
		private System.Windows.Forms.Button compareButton;
	}
}