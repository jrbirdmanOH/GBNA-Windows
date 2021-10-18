namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class GenerateQuizProgressForm
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
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.taskDescriptionLabel = new System.Windows.Forms.Label();
			this.percentCompleteLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(11, 37);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(309, 17);
			this.progressBar.TabIndex = 0;
			// 
			// taskDescriptionLabel
			// 
			this.taskDescriptionLabel.Location = new System.Drawing.Point(11, 19);
			this.taskDescriptionLabel.Name = "taskDescriptionLabel";
			this.taskDescriptionLabel.Size = new System.Drawing.Size(309, 15);
			this.taskDescriptionLabel.TabIndex = 1;
			this.taskDescriptionLabel.Text = "Task description";
			// 
			// percentCompleteLabel
			// 
			this.percentCompleteLabel.Location = new System.Drawing.Point(11, 59);
			this.percentCompleteLabel.Name = "percentCompleteLabel";
			this.percentCompleteLabel.Size = new System.Drawing.Size(309, 13);
			this.percentCompleteLabel.TabIndex = 2;
			this.percentCompleteLabel.Text = "0 %";
			this.percentCompleteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GenerateQuizProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 78);
			this.Controls.Add(this.percentCompleteLabel);
			this.Controls.Add(this.taskDescriptionLabel);
			this.Controls.Add(this.progressBar);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(338, 114);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(338, 114);
			this.Name = "GenerateQuizProgressForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generating Quiz Entries...";
			this.Load += new System.EventHandler(this.GenerateQuizProgressForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label taskDescriptionLabel;
		private System.Windows.Forms.Label percentCompleteLabel;
	}
}