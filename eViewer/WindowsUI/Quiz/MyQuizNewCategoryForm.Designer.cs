namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizNewCategoryForm
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
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.createButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.createAndAddItemsButton = new System.Windows.Forms.Button();
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
			label1.Size = new System.Drawing.Size(432, 35);
			label1.TabIndex = 0;
			label1.Text = "Please specify a unique name for the new category.  You can then choose to just c" +
    "reate the category (adding items later) or create the category and add category " +
    "items now.";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.Location = new System.Drawing.Point(104, 53);
			this.nameTextBox.MaxLength = 50;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(343, 20);
			this.nameTextBox.TabIndex = 2;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(15, 56);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(83, 13);
			this.nameLabel.TabIndex = 1;
			this.nameLabel.Text = "Category Name:";
			// 
			// createButton
			// 
			this.createButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.createButton.Location = new System.Drawing.Point(84, 95);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(75, 23);
			this.createButton.TabIndex = 3;
			this.createButton.Text = "Create";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(309, 95);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// createAndAddItemsButton
			// 
			this.createAndAddItemsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.createAndAddItemsButton.Location = new System.Drawing.Point(165, 95);
			this.createAndAddItemsButton.Name = "createAndAddItemsButton";
			this.createAndAddItemsButton.Size = new System.Drawing.Size(138, 23);
			this.createAndAddItemsButton.TabIndex = 4;
			this.createAndAddItemsButton.Text = "Create and Add Items...";
			this.createAndAddItemsButton.UseVisualStyleBackColor = true;
			this.createAndAddItemsButton.Click += new System.EventHandler(this.createAndAddItemsButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyQuizNewCategoryForm
			// 
			this.AcceptButton = this.createButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(468, 140);
			this.Controls.Add(this.createAndAddItemsButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.createButton);
			this.Controls.Add(label1);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.nameLabel);
			this.helpProvider.SetHelpKeyword(this, "30");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MinimumSize = new System.Drawing.Size(484, 176);
			this.Name = "MyQuizNewCategoryForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Category";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button createAndAddItemsButton;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}