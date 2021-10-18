namespace Thayer.Birding.UI.Windows
{
	partial class NarrativeForm
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
			this.narrativeTextBox = new System.Windows.Forms.TextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.SuspendLayout();
			// 
			// narrativeTextBox
			// 
			this.narrativeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.narrativeTextBox.Location = new System.Drawing.Point(13, 13);
			this.narrativeTextBox.Multiline = true;
			this.narrativeTextBox.Name = "narrativeTextBox";
			this.narrativeTextBox.ReadOnly = true;
			this.narrativeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.narrativeTextBox.Size = new System.Drawing.Size(329, 212);
			this.narrativeTextBox.TabIndex = 1;
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(267, 231);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// NarrativeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(354, 266);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.narrativeTextBox);
			this.helpProvider.SetHelpKeyword(this, "-1");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NarrativeForm";
			this.helpProvider.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Narrative";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox narrativeTextBox;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}