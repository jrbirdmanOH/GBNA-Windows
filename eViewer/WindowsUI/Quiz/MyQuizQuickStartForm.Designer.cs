namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizQuickStartForm
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
			this.showQuickStartCheckBox = new System.Windows.Forms.CheckBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.panel = new System.Windows.Forms.Panel();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// showQuickStartCheckBox
			// 
			this.showQuickStartCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.showQuickStartCheckBox.AutoSize = true;
			this.showQuickStartCheckBox.Location = new System.Drawing.Point(12, 533);
			this.showQuickStartCheckBox.Name = "showQuickStartCheckBox";
			this.showQuickStartCheckBox.Size = new System.Drawing.Size(154, 17);
			this.showQuickStartCheckBox.TabIndex = 1;
			this.showQuickStartCheckBox.Text = "Show this screen at startup";
			this.showQuickStartCheckBox.UseVisualStyleBackColor = true;
			// 
			// closeButton
			// 
			this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(339, 529);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "&Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel.Controls.Add(this.richTextBox);
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(751, 511);
			this.panel.TabIndex = 0;
			// 
			// richTextBox
			// 
			this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox.Location = new System.Drawing.Point(15, 0);
			this.richTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.ReadOnly = true;
			this.richTextBox.Size = new System.Drawing.Size(736, 511);
			this.richTextBox.TabIndex = 0;
			this.richTextBox.Text = "";
			this.richTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_LinkClicked);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyQuizQuickStartForm
			// 
			this.AcceptButton = this.closeButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(752, 564);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.showQuickStartCheckBox);
			this.helpProvider.SetHelpKeyword(this, "34");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "MyQuizQuickStartForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "My Quiz Quick Start";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyQuizQuickStartForm_FormClosing);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox showQuickStartCheckBox;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.RichTextBox richTextBox;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}