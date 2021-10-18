namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizCopyToCategoryForm
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
			this.targetCategoryLabel = new System.Windows.Forms.Label();
			this.targetCategoriesComboBox = new System.Windows.Forms.ComboBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.instructionsLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// targetCategoryLabel
			// 
			this.targetCategoryLabel.AutoSize = true;
			this.targetCategoryLabel.Location = new System.Drawing.Point(12, 40);
			this.targetCategoryLabel.Name = "targetCategoryLabel";
			this.targetCategoryLabel.Size = new System.Drawing.Size(86, 13);
			this.targetCategoryLabel.TabIndex = 1;
			this.targetCategoryLabel.Text = "Target Category:";
			// 
			// targetCategoriesComboBox
			// 
			this.targetCategoriesComboBox.FormattingEnabled = true;
			this.targetCategoriesComboBox.Location = new System.Drawing.Point(104, 37);
			this.targetCategoriesComboBox.Name = "targetCategoriesComboBox";
			this.targetCategoriesComboBox.Size = new System.Drawing.Size(310, 21);
			this.targetCategoriesComboBox.TabIndex = 2;
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(140, 78);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(221, 78);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// instructionsLabel
			// 
			this.instructionsLabel.AutoSize = true;
			this.instructionsLabel.Location = new System.Drawing.Point(12, 9);
			this.instructionsLabel.Name = "instructionsLabel";
			this.instructionsLabel.Size = new System.Drawing.Size(331, 13);
			this.instructionsLabel.TabIndex = 0;
			this.instructionsLabel.Text = "The selected {0} category items will be copied to the target category.";
			// 
			// MyQuizCopyToCategoryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 117);
			this.Controls.Add(this.instructionsLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.targetCategoriesComboBox);
			this.Controls.Add(this.targetCategoryLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MyQuizCopyToCategoryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Copy to Category";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label targetCategoryLabel;
		private System.Windows.Forms.ComboBox targetCategoriesComboBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label instructionsLabel;
	}
}