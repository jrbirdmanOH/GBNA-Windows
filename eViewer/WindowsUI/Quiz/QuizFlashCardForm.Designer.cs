namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class QuizFlashCardForm
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
			this.backButton = new System.Windows.Forms.Button();
			this.mediaGroupBox = new System.Windows.Forms.GroupBox();
			this.mediaPlayer = new Thayer.Birding.UI.Windows.MediaPlayer();
			this.nextButton = new System.Windows.Forms.Button();
			this.navigationTimerLabel = new System.Windows.Forms.Label();
			this.quizSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.quizSourceLabel = new System.Windows.Forms.Label();
			this.finishButton = new System.Windows.Forms.Button();
			this.quizEngine = new Thayer.Birding.UI.Quiz.QuizEngine();
			this.answerLabel = new System.Windows.Forms.Label();
			this.mnemonicLabel = new System.Windows.Forms.Label();
			this.nameTimerLabel = new System.Windows.Forms.Label();
			this.quizMediaPlayer = new Thayer.Birding.UI.Windows.Quiz.QuizMediaPlayer();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.pauseResumeButton = new System.Windows.Forms.Button();
			this.mediaGroupBox.SuspendLayout();
			this.quizSourceGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(531, 396);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 8;
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
			this.mediaGroupBox.Location = new System.Drawing.Point(7, 53);
			this.mediaGroupBox.Name = "mediaGroupBox";
			this.mediaGroupBox.Size = new System.Drawing.Size(676, 306);
			this.mediaGroupBox.TabIndex = 1;
			this.mediaGroupBox.TabStop = false;
			// 
			// mediaPlayer
			// 
			this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mediaPlayer.Location = new System.Drawing.Point(3, 16);
			this.mediaPlayer.LoopText = "Replay Song";
			this.mediaPlayer.Name = "mediaPlayer";
			this.mediaPlayer.Size = new System.Drawing.Size(670, 287);
			this.mediaPlayer.TabIndex = 0;
			this.mediaPlayer.VideoZoomLevel = Thayer.Birding.UI.Windows.MediaPlayer.ZoomLevel.Normal;
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(608, 396);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 9;
			this.nextButton.Text = "Next >>";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// navigationTimerLabel
			// 
			this.navigationTimerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.navigationTimerLabel.Location = new System.Drawing.Point(438, 370);
			this.navigationTimerLabel.Name = "navigationTimerLabel";
			this.navigationTimerLabel.Size = new System.Drawing.Size(245, 13);
			this.navigationTimerLabel.TabIndex = 5;
			this.navigationTimerLabel.Text = "Navigation timer label";
			this.navigationTimerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			// quizSourceLabel
			// 
			this.quizSourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.quizSourceLabel.Location = new System.Drawing.Point(11, 20);
			this.quizSourceLabel.Name = "quizSourceLabel";
			this.quizSourceLabel.Size = new System.Drawing.Size(659, 20);
			this.quizSourceLabel.TabIndex = 0;
			this.quizSourceLabel.Text = "Predefined Quiz:  25 Birds You Know";
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Location = new System.Drawing.Point(441, 396);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 7;
			this.finishButton.Text = "Stop";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
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
			// answerLabel
			// 
			this.answerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.answerLabel.AutoSize = true;
			this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.answerLabel.Location = new System.Drawing.Point(18, 367);
			this.answerLabel.Name = "answerLabel";
			this.answerLabel.Size = new System.Drawing.Size(158, 24);
			this.answerLabel.TabIndex = 3;
			this.answerLabel.Text = "Organism name";
			// 
			// mnemonicLabel
			// 
			this.mnemonicLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.mnemonicLabel.AutoSize = true;
			this.mnemonicLabel.Location = new System.Drawing.Point(18, 394);
			this.mnemonicLabel.Name = "mnemonicLabel";
			this.mnemonicLabel.Size = new System.Drawing.Size(56, 13);
			this.mnemonicLabel.TabIndex = 4;
			this.mnemonicLabel.Text = "Mnemonic";
			// 
			// nameTimerLabel
			// 
			this.nameTimerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nameTimerLabel.AutoSize = true;
			this.nameTimerLabel.Location = new System.Drawing.Point(18, 370);
			this.nameTimerLabel.Name = "nameTimerLabel";
			this.nameTimerLabel.Size = new System.Drawing.Size(85, 13);
			this.nameTimerLabel.TabIndex = 2;
			this.nameTimerLabel.Text = "Name timer label";
			// 
			// quizMediaPlayer
			// 
			this.quizMediaPlayer.MediaPlayer = null;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// pauseResumeButton
			// 
			this.pauseResumeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pauseResumeButton.Location = new System.Drawing.Point(364, 396);
			this.pauseResumeButton.Name = "pauseResumeButton";
			this.pauseResumeButton.Size = new System.Drawing.Size(75, 23);
			this.pauseResumeButton.TabIndex = 6;
			this.pauseResumeButton.Text = "Pause";
			this.pauseResumeButton.UseVisualStyleBackColor = true;
			this.pauseResumeButton.Click += new System.EventHandler(this.pauseResumeButton_Click);
			// 
			// QuizFlashCardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 423);
			this.Controls.Add(this.pauseResumeButton);
			this.Controls.Add(this.mnemonicLabel);
			this.Controls.Add(this.navigationTimerLabel);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.mediaGroupBox);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.quizSourceGroupBox);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.nameTimerLabel);
			this.Controls.Add(this.answerLabel);
			this.helpProvider.SetHelpKeyword(this, "58");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MinimumSize = new System.Drawing.Size(707, 461);
			this.Name = "QuizFlashCardForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Flash Card Quiz";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizFlashCardForm_FormClosing);
			this.Load += new System.EventHandler(this.QuizFlashCardForm_Load);
			this.Resize += new System.EventHandler(this.QuizFlashCardForm_Resize);
			this.mediaGroupBox.ResumeLayout(false);
			this.quizSourceGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.GroupBox mediaGroupBox;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.GroupBox quizSourceGroupBox;
		private System.Windows.Forms.Label quizSourceLabel;
		private System.Windows.Forms.Button finishButton;
		private Thayer.Birding.UI.Quiz.QuizEngine quizEngine;
		private System.Windows.Forms.Label navigationTimerLabel;
		private System.Windows.Forms.Label answerLabel;
		private System.Windows.Forms.Label mnemonicLabel;
		private System.Windows.Forms.Label nameTimerLabel;
		private QuizMediaPlayer quizMediaPlayer;
		private MediaPlayer mediaPlayer;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button pauseResumeButton;
	}
}