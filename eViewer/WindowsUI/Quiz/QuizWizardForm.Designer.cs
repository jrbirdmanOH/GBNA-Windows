namespace Thayer.Birding.UI.Windows.Quiz
{
    partial class QuizWizardForm
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
			this.hallOfFameButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.finishButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.manageMyQuizzesButton = new System.Windows.Forms.Button();
			this.quizSelectPanel = new Thayer.Birding.UI.Windows.Quiz.QuizSelectPanel();
			this.quizFillInTheBlankPanel = new Thayer.Birding.UI.Windows.Quiz.QuizFillInTheBlankPanel();
			this.quizMultipleChoicePanel = new Thayer.Birding.UI.Windows.Quiz.QuizMultipleChoicePanel();
			this.quizTypePanel = new Thayer.Birding.UI.Windows.Quiz.QuizTypePanel();
			this.quizCommonOptionsPanel = new Thayer.Birding.UI.Windows.Quiz.QuizCommonOptionsPanel();
			this.quizFlashCardPanel = new Thayer.Birding.UI.Windows.Quiz.QuizFlashCardPanel();
			this.quizPickOnePanel = new Thayer.Birding.UI.Windows.Quiz.QuizPickOnePanel();
			this.myQuizzesButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// hallOfFameButton
			// 
			this.hallOfFameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hallOfFameButton.Location = new System.Drawing.Point(136, 410);
			this.hallOfFameButton.Name = "hallOfFameButton";
			this.hallOfFameButton.Size = new System.Drawing.Size(75, 23);
			this.hallOfFameButton.TabIndex = 3;
			this.hallOfFameButton.Text = "Hall of Fame";
			this.hallOfFameButton.UseVisualStyleBackColor = true;
			this.hallOfFameButton.Click += new System.EventHandler(this.hallOfFameButton_Click);
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(294, 410);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 4;
			this.backButton.Text = "<< Bac&k";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(370, 410);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 5;
			this.nextButton.Text = "Ne&xt >>";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(532, 410);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Location = new System.Drawing.Point(451, 410);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 6;
			this.finishButton.Text = "Run &Quiz";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(10, 399);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(597, 2);
			this.label1.TabIndex = 1;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// manageMyQuizzesButton
			// 
			this.manageMyQuizzesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.manageMyQuizzesButton.Location = new System.Drawing.Point(9, 410);
			this.manageMyQuizzesButton.Name = "manageMyQuizzesButton";
			this.manageMyQuizzesButton.Size = new System.Drawing.Size(123, 23);
			this.manageMyQuizzesButton.TabIndex = 2;
			this.manageMyQuizzesButton.Text = "Manage My Quizzes...";
			this.manageMyQuizzesButton.UseVisualStyleBackColor = true;
			this.manageMyQuizzesButton.Click += new System.EventHandler(this.myQuizzesButton_Click);
			// 
			// quizSelectPanel
			// 
			this.quizSelectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizSelectPanel.BackEnabled = false;
			this.quizSelectPanel.Collection = null;
			this.quizSelectPanel.FinishEnabled = false;
			this.quizSelectPanel.Location = new System.Drawing.Point(10, 10);
			this.quizSelectPanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizSelectPanel.Name = "quizSelectPanel";
			this.quizSelectPanel.NextEnabled = false;
			this.quizSelectPanel.QuizSettings = null;
			this.quizSelectPanel.Size = new System.Drawing.Size(597, 380);
			this.quizSelectPanel.TabIndex = 0;
			this.quizSelectPanel.WizardEnabled = true;
			// 
			// quizFillInTheBlankPanel
			// 
			this.quizFillInTheBlankPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizFillInTheBlankPanel.BackEnabled = true;
			this.quizFillInTheBlankPanel.FinishEnabled = false;
			this.quizFillInTheBlankPanel.Location = new System.Drawing.Point(10, 10);
			this.quizFillInTheBlankPanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizFillInTheBlankPanel.Name = "quizFillInTheBlankPanel";
			this.quizFillInTheBlankPanel.NextEnabled = true;
			this.quizFillInTheBlankPanel.QuizSettings = null;
			this.quizFillInTheBlankPanel.Size = new System.Drawing.Size(597, 380);
			this.quizFillInTheBlankPanel.TabIndex = 1;
			// 
			// quizMultipleChoicePanel
			// 
			this.quizMultipleChoicePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizMultipleChoicePanel.BackEnabled = true;
			this.quizMultipleChoicePanel.FinishEnabled = false;
			this.quizMultipleChoicePanel.Location = new System.Drawing.Point(10, 10);
			this.quizMultipleChoicePanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizMultipleChoicePanel.Name = "quizMultipleChoicePanel";
			this.quizMultipleChoicePanel.NextEnabled = true;
			this.quizMultipleChoicePanel.QuizSettings = null;
			this.quizMultipleChoicePanel.Size = new System.Drawing.Size(597, 380);
			this.quizMultipleChoicePanel.TabIndex = 2;
			// 
			// quizTypePanel
			// 
			this.quizTypePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizTypePanel.BackEnabled = false;
			this.quizTypePanel.FinishEnabled = false;
			this.quizTypePanel.Location = new System.Drawing.Point(10, 10);
			this.quizTypePanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizTypePanel.Name = "quizTypePanel";
			this.quizTypePanel.NextEnabled = false;
			this.quizTypePanel.QuizSettings = null;
			this.quizTypePanel.Size = new System.Drawing.Size(597, 380);
			this.quizTypePanel.TabIndex = 3;
			this.quizTypePanel.WizardEnabled = true;
			// 
			// quizCommonOptionsPanel
			// 
			this.quizCommonOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizCommonOptionsPanel.BackEnabled = false;
			this.quizCommonOptionsPanel.FinishEnabled = false;
			this.quizCommonOptionsPanel.Location = new System.Drawing.Point(10, 10);
			this.quizCommonOptionsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizCommonOptionsPanel.Name = "quizCommonOptionsPanel";
			this.quizCommonOptionsPanel.NextEnabled = false;
			this.quizCommonOptionsPanel.QuizSettings = null;
			this.quizCommonOptionsPanel.Size = new System.Drawing.Size(597, 380);
			this.quizCommonOptionsPanel.TabIndex = 4;
			this.quizCommonOptionsPanel.WizardEnabled = true;
			// 
			// quizFlashCardPanel
			// 
			this.quizFlashCardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizFlashCardPanel.BackEnabled = true;
			this.quizFlashCardPanel.FinishEnabled = false;
			this.quizFlashCardPanel.Location = new System.Drawing.Point(10, 10);
			this.quizFlashCardPanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizFlashCardPanel.Name = "quizFlashCardPanel";
			this.quizFlashCardPanel.NextEnabled = true;
			this.quizFlashCardPanel.QuizSettings = null;
			this.quizFlashCardPanel.Size = new System.Drawing.Size(597, 380);
			this.quizFlashCardPanel.TabIndex = 17;
			// 
			// quizPickOnePanel
			// 
			this.quizPickOnePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quizPickOnePanel.BackEnabled = true;
			this.quizPickOnePanel.FinishEnabled = false;
			this.quizPickOnePanel.Location = new System.Drawing.Point(10, 10);
			this.quizPickOnePanel.Margin = new System.Windows.Forms.Padding(0);
			this.quizPickOnePanel.Name = "quizPickOnePanel";
			this.quizPickOnePanel.NextEnabled = true;
			this.quizPickOnePanel.QuizSettings = null;
			this.quizPickOnePanel.Size = new System.Drawing.Size(597, 380);
			this.quizPickOnePanel.TabIndex = 18;
			// 
			// myQuizzesButton
			// 
			this.myQuizzesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.myQuizzesButton.Location = new System.Drawing.Point(9, 410);
			this.myQuizzesButton.Name = "myQuizzesButton";
			this.myQuizzesButton.Size = new System.Drawing.Size(75, 23);
			this.myQuizzesButton.TabIndex = 2;
			this.myQuizzesButton.Text = "Manage My Quizzes";
			this.myQuizzesButton.UseVisualStyleBackColor = true;
			this.myQuizzesButton.Click += new System.EventHandler(this.myQuizzesButton_Click);
			// 
			// QuizWizardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(616, 444);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.hallOfFameButton);
			this.Controls.Add(this.manageMyQuizzesButton);
			this.Controls.Add(this.quizSelectPanel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.quizFillInTheBlankPanel);
			this.Controls.Add(this.quizMultipleChoicePanel);
			this.Controls.Add(this.quizTypePanel);
			this.Controls.Add(this.quizCommonOptionsPanel);
			this.Controls.Add(this.quizFlashCardPanel);
			this.Controls.Add(this.quizPickOnePanel);
			this.helpProvider.SetHelpKeyword(this, "47");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuizWizardForm";
			this.helpProvider.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quiz Wizard";
			this.Load += new System.EventHandler(this.QuizWizardForm_Load);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button hallOfFameButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button cancelButton;
        private QuizSelectPanel quizSelectPanel;
        private QuizTypePanel quizTypePanel;
        private QuizMultipleChoicePanel quizMultipleChoicePanel;
        private QuizFillInTheBlankPanel quizFillInTheBlankPanel;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label label1;
		private QuizCommonOptionsPanel quizCommonOptionsPanel;
        private QuizFlashCardPanel quizFlashCardPanel;
		private QuizPickOnePanel quizPickOnePanel;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button manageMyQuizzesButton;
		private System.Windows.Forms.Button myQuizzesButton;
    }
}