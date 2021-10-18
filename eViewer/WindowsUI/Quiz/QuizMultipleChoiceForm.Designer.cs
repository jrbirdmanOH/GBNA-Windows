namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class QuizMultipleChoiceForm
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
			Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
			this.goToGroupBox = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.goToComboBox = new System.Windows.Forms.ComboBox();
			this.clueGroupBox = new System.Windows.Forms.GroupBox();
			this.clueComboBox = new Thayer.Birding.UI.Windows.MediaComboBox();
			this.answerGroupBox = new System.Windows.Forms.GroupBox();
			this.answerButton = new System.Windows.Forms.Button();
			this.answerUltraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.finishButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.mediaGroupBox = new System.Windows.Forms.GroupBox();
			this.mediaPlayer = new Thayer.Birding.UI.Windows.MediaPlayer();
			this.quizSourceLabel = new System.Windows.Forms.Label();
			this.scoreGroupBox = new System.Windows.Forms.GroupBox();
			this.scoreIncorrectLabel = new System.Windows.Forms.Label();
			this.scoreCorrectLabel = new System.Windows.Forms.Label();
			this.scoreRemainingLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nextButton = new System.Windows.Forms.Button();
			this.quizSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.quizMediaPlayer = new Thayer.Birding.UI.Windows.Quiz.QuizMediaPlayer();
			this.quizEngine = new Thayer.Birding.UI.Quiz.QuizEngine();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.compareButton = new System.Windows.Forms.Button();
			this.goToGroupBox.SuspendLayout();
			this.clueGroupBox.SuspendLayout();
			this.answerGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.answerUltraOptionSet)).BeginInit();
			this.mediaGroupBox.SuspendLayout();
			this.scoreGroupBox.SuspendLayout();
			this.quizSourceGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// goToGroupBox
			// 
			this.goToGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.goToGroupBox.Controls.Add(this.label4);
			this.goToGroupBox.Controls.Add(this.goToComboBox);
			this.goToGroupBox.Location = new System.Drawing.Point(196, 424);
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
			// clueGroupBox
			// 
			this.clueGroupBox.Controls.Add(this.clueComboBox);
			this.clueGroupBox.Location = new System.Drawing.Point(7, 364);
			this.clueGroupBox.Name = "clueGroupBox";
			this.clueGroupBox.Size = new System.Drawing.Size(183, 54);
			this.clueGroupBox.TabIndex = 2;
			this.clueGroupBox.TabStop = false;
			this.clueGroupBox.Text = "Need a clue?";
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
			// answerGroupBox
			// 
			this.answerGroupBox.Controls.Add(this.answerButton);
			this.answerGroupBox.Controls.Add(this.answerUltraOptionSet);
			this.answerGroupBox.Location = new System.Drawing.Point(7, 53);
			this.answerGroupBox.Name = "answerGroupBox";
			this.answerGroupBox.Size = new System.Drawing.Size(183, 305);
			this.answerGroupBox.TabIndex = 1;
			this.answerGroupBox.TabStop = false;
			this.answerGroupBox.Text = "What is this?";
			// 
			// answerButton
			// 
			this.answerButton.Location = new System.Drawing.Point(50, 276);
			this.answerButton.Name = "answerButton";
			this.answerButton.Size = new System.Drawing.Size(75, 23);
			this.answerButton.TabIndex = 1;
			this.answerButton.Text = "Answer";
			this.answerButton.UseVisualStyleBackColor = true;
			this.answerButton.Click += new System.EventHandler(this.answerButton_Click);
			// 
			// answerUltraOptionSet
			// 
			this.answerUltraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			valueListItem6.DataValue = "Default Item";
			valueListItem6.DisplayText = "Answer 1 with a longer description";
			valueListItem7.DataValue = "ValueListItem1";
			valueListItem7.DisplayText = "Answer 2 with a bunch of some small length words";
			valueListItem8.DataValue = "ValueListItem2";
			valueListItem8.DisplayText = "Answer 3 with a longer description";
			valueListItem9.DataValue = "ValueListItem3";
			valueListItem9.DisplayText = "Answer 4 with a longer description";
			valueListItem10.DataValue = "ValueListItem4";
			valueListItem10.DisplayText = "Answer 5 with some longer words";
			this.answerUltraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10});
			this.answerUltraOptionSet.ItemSpacingVertical = 23;
			this.answerUltraOptionSet.Location = new System.Drawing.Point(10, 19);
			this.answerUltraOptionSet.MaxColumnWidth = 500;
			this.answerUltraOptionSet.Name = "answerUltraOptionSet";
			this.answerUltraOptionSet.Size = new System.Drawing.Size(170, 251);
			this.answerUltraOptionSet.TabIndex = 0;
			this.answerUltraOptionSet.TextIndentation = 2;
			this.answerUltraOptionSet.ValueChanged += new System.EventHandler(this.answerUltraOptionSet_ValueChanged);
			this.answerUltraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerUltraOptionSet_KeyDown);
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Location = new System.Drawing.Point(441, 455);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 6;
			this.finishButton.Text = "Stop";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(531, 455);
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
			this.mediaGroupBox.Size = new System.Drawing.Size(487, 365);
			this.mediaGroupBox.TabIndex = 9;
			this.mediaGroupBox.TabStop = false;
			// 
			// mediaPlayer
			// 
			this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mediaPlayer.Location = new System.Drawing.Point(3, 16);
			this.mediaPlayer.LoopText = "Loop";
			this.mediaPlayer.Name = "mediaPlayer";
			this.mediaPlayer.Size = new System.Drawing.Size(481, 346);
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
			// scoreGroupBox
			// 
			this.scoreGroupBox.Controls.Add(this.scoreIncorrectLabel);
			this.scoreGroupBox.Controls.Add(this.scoreCorrectLabel);
			this.scoreGroupBox.Controls.Add(this.scoreRemainingLabel);
			this.scoreGroupBox.Controls.Add(this.label3);
			this.scoreGroupBox.Controls.Add(this.label2);
			this.scoreGroupBox.Controls.Add(this.label1);
			this.scoreGroupBox.Location = new System.Drawing.Point(7, 424);
			this.scoreGroupBox.Name = "scoreGroupBox";
			this.scoreGroupBox.Size = new System.Drawing.Size(183, 54);
			this.scoreGroupBox.TabIndex = 3;
			this.scoreGroupBox.TabStop = false;
			this.scoreGroupBox.Text = "Your Score";
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
			// scoreCorrectLabel
			// 
			this.scoreCorrectLabel.ForeColor = System.Drawing.Color.Green;
			this.scoreCorrectLabel.Location = new System.Drawing.Point(75, 34);
			this.scoreCorrectLabel.Name = "scoreCorrectLabel";
			this.scoreCorrectLabel.Size = new System.Drawing.Size(41, 13);
			this.scoreCorrectLabel.TabIndex = 4;
			this.scoreCorrectLabel.Text = "0";
			this.scoreCorrectLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// scoreRemainingLabel
			// 
			this.scoreRemainingLabel.Location = new System.Drawing.Point(11, 34);
			this.scoreRemainingLabel.Name = "scoreRemainingLabel";
			this.scoreRemainingLabel.Size = new System.Drawing.Size(57, 13);
			this.scoreRemainingLabel.TabIndex = 3;
			this.scoreRemainingLabel.Text = "25";
			this.scoreRemainingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(124, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Incorrect";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Green;
			this.label2.Location = new System.Drawing.Point(75, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 1;
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
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(608, 455);
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
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// compareButton
			// 
			this.compareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.compareButton.Location = new System.Drawing.Point(531, 426);
			this.compareButton.Name = "compareButton";
			this.compareButton.Size = new System.Drawing.Size(152, 23);
			this.compareButton.TabIndex = 5;
			this.compareButton.Text = "Compare";
			this.compareButton.UseVisualStyleBackColor = true;
			this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
			// 
			// QuizMultipleChoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 482);
			this.Controls.Add(this.compareButton);
			this.Controls.Add(this.goToGroupBox);
			this.Controls.Add(this.clueGroupBox);
			this.Controls.Add(this.answerGroupBox);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.mediaGroupBox);
			this.Controls.Add(this.scoreGroupBox);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.quizSourceGroupBox);
			this.helpProvider.SetHelpKeyword(this, "59");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MinimumSize = new System.Drawing.Size(707, 520);
			this.Name = "QuizMultipleChoiceForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Multiple Choice Quiz";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizMultipleChoiceForm_FormClosing);
			this.Load += new System.EventHandler(this.QuizMultipleChoiceForm_Load);
			this.goToGroupBox.ResumeLayout(false);
			this.goToGroupBox.PerformLayout();
			this.clueGroupBox.ResumeLayout(false);
			this.answerGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.answerUltraOptionSet)).EndInit();
			this.mediaGroupBox.ResumeLayout(false);
			this.scoreGroupBox.ResumeLayout(false);
			this.quizSourceGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox goToGroupBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox goToComboBox;
		private System.Windows.Forms.GroupBox clueGroupBox;
		private System.Windows.Forms.GroupBox answerGroupBox;
		private System.Windows.Forms.Button answerButton;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet answerUltraOptionSet;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.GroupBox mediaGroupBox;
		private System.Windows.Forms.Label quizSourceLabel;
		private System.Windows.Forms.GroupBox scoreGroupBox;
		private System.Windows.Forms.Label scoreIncorrectLabel;
		private System.Windows.Forms.Label scoreCorrectLabel;
		private System.Windows.Forms.Label scoreRemainingLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.GroupBox quizSourceGroupBox;
		private QuizMediaPlayer quizMediaPlayer;
		private MediaPlayer mediaPlayer;
		private MediaComboBox clueComboBox;
		private Thayer.Birding.UI.Quiz.QuizEngine quizEngine;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button compareButton;
	}
}