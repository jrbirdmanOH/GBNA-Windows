namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class HallOfFameForm
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
			this.hallOfFameWebBrowser = new System.Windows.Forms.WebBrowser();
			this.printButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.clearScoresButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.SuspendLayout();
			// 
			// hallOfFameWebBrowser
			// 
			this.hallOfFameWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hallOfFameWebBrowser.IsWebBrowserContextMenuEnabled = false;
			this.hallOfFameWebBrowser.Location = new System.Drawing.Point(0, 0);
			this.hallOfFameWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.hallOfFameWebBrowser.Name = "hallOfFameWebBrowser";
			this.hallOfFameWebBrowser.Size = new System.Drawing.Size(648, 423);
			this.hallOfFameWebBrowser.TabIndex = 0;
			this.hallOfFameWebBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.hallOfFameWebBrowser_PreviewKeyDown);
			// 
			// printButton
			// 
			this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.printButton.Location = new System.Drawing.Point(478, 438);
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(75, 23);
			this.printButton.TabIndex = 2;
			this.printButton.Text = "Print...";
			this.printButton.UseVisualStyleBackColor = true;
			this.printButton.Click += new System.EventHandler(this.printButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(559, 438);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 3;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// clearScoresButton
			// 
			this.clearScoresButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearScoresButton.Location = new System.Drawing.Point(388, 438);
			this.clearScoresButton.Name = "clearScoresButton";
			this.clearScoresButton.Size = new System.Drawing.Size(84, 23);
			this.clearScoresButton.TabIndex = 1;
			this.clearScoresButton.Text = "Clear Scores...";
			this.clearScoresButton.UseVisualStyleBackColor = true;
			this.clearScoresButton.Click += new System.EventHandler(this.clearScoresButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// HallOfFameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(646, 473);
			this.Controls.Add(this.clearScoresButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.printButton);
			this.Controls.Add(this.hallOfFameWebBrowser);
			this.helpProvider.SetHelpKeyword(this, "18");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "HallOfFameForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quiz Hall of Fame";
			this.Load += new System.EventHandler(this.HallOfFameForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser hallOfFameWebBrowser;
		private System.Windows.Forms.Button printButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button clearScoresButton;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}