namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizNewQuizForm
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
			System.Windows.Forms.Label label1;
			this.categoryNameLabel = new System.Windows.Forms.Label();
			this.authorTextBox = new System.Windows.Forms.TextBox();
			this.authorLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.categoryLabel = new System.Windows.Forms.Label();
			this.createButton = new System.Windows.Forms.Button();
			this.createAndAddQuestionsButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			label1.Location = new System.Drawing.Point(15, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(408, 35);
			label1.TabIndex = 0;
			label1.Text = "Please specify a name and author for the new quiz.  You can then choose to just c" +
				"reate the quiz (adding questions later) or create the quiz and add questions now" +
				".";
			// 
			// categoryNameLabel
			// 
			this.categoryNameLabel.AutoSize = true;
			this.categoryNameLabel.Location = new System.Drawing.Point(83, 61);
			this.categoryNameLabel.Name = "categoryNameLabel";
			this.categoryNameLabel.Size = new System.Drawing.Size(80, 13);
			this.categoryNameLabel.TabIndex = 2;
			this.categoryNameLabel.Text = "Category Name";
			// 
			// authorTextBox
			// 
			this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.authorTextBox.Location = new System.Drawing.Point(83, 111);
			this.authorTextBox.MaxLength = 50;
			this.authorTextBox.Name = "authorTextBox";
			this.authorTextBox.Size = new System.Drawing.Size(340, 20);
			this.authorTextBox.TabIndex = 6;
			// 
			// authorLabel
			// 
			this.authorLabel.AutoSize = true;
			this.authorLabel.Location = new System.Drawing.Point(15, 114);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(41, 13);
			this.authorLabel.TabIndex = 5;
			this.authorLabel.Text = "Author:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.Location = new System.Drawing.Point(83, 85);
			this.nameTextBox.MaxLength = 100;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(340, 20);
			this.nameTextBox.TabIndex = 4;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(15, 88);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(62, 13);
			this.nameLabel.TabIndex = 3;
			this.nameLabel.Text = "Quiz Name:";
			// 
			// categoryLabel
			// 
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.Location = new System.Drawing.Point(15, 61);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(52, 13);
			this.categoryLabel.TabIndex = 1;
			this.categoryLabel.Text = "Category:";
			// 
			// createButton
			// 
			this.createButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.createButton.Location = new System.Drawing.Point(59, 155);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(75, 23);
			this.createButton.TabIndex = 7;
			this.createButton.Text = "Create";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// createAndAddQuestionsButton
			// 
			this.createAndAddQuestionsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.createAndAddQuestionsButton.Location = new System.Drawing.Point(140, 155);
			this.createAndAddQuestionsButton.Name = "createAndAddQuestionsButton";
			this.createAndAddQuestionsButton.Size = new System.Drawing.Size(164, 23);
			this.createAndAddQuestionsButton.TabIndex = 8;
			this.createAndAddQuestionsButton.Text = "Create and Add Questions...";
			this.createAndAddQuestionsButton.UseVisualStyleBackColor = true;
			this.createAndAddQuestionsButton.Click += new System.EventHandler(this.createAndAddQuestionsButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(310, 155);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyQuizNewQuizForm
			// 
			this.AcceptButton = this.createButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(445, 200);
			this.Controls.Add(label1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.createAndAddQuestionsButton);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.categoryNameLabel);
			this.Controls.Add(this.authorTextBox);
			this.Controls.Add(this.authorLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.categoryLabel);
			this.helpProvider.SetHelpKeyword(this, "33");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MinimumSize = new System.Drawing.Size(461, 236);
			this.Name = "MyQuizNewQuizForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Quiz";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label categoryNameLabel;
		private System.Windows.Forms.TextBox authorTextBox;
		private System.Windows.Forms.Label authorLabel;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.Button createAndAddQuestionsButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}