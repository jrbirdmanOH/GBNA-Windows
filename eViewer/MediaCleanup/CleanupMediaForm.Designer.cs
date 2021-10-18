namespace Thayer.MediaCleanup
{
	partial class CleanupMediaForm
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
			this.cleanupMediaButton = new System.Windows.Forms.Button();
			this.checkMediaExistsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cleanupMediaButton
			// 
			this.cleanupMediaButton.Location = new System.Drawing.Point(187, 72);
			this.cleanupMediaButton.Name = "cleanupMediaButton";
			this.cleanupMediaButton.Size = new System.Drawing.Size(108, 23);
			this.cleanupMediaButton.TabIndex = 0;
			this.cleanupMediaButton.Text = "Cleanup Media";
			this.cleanupMediaButton.UseVisualStyleBackColor = true;
			this.cleanupMediaButton.Click += new System.EventHandler(this.cleanupMediaButton_Click);
			// 
			// checkMediaExistsButton
			// 
			this.checkMediaExistsButton.Location = new System.Drawing.Point(69, 72);
			this.checkMediaExistsButton.Name = "checkMediaExistsButton";
			this.checkMediaExistsButton.Size = new System.Drawing.Size(112, 23);
			this.checkMediaExistsButton.TabIndex = 1;
			this.checkMediaExistsButton.Text = "Check Media Exists";
			this.checkMediaExistsButton.UseVisualStyleBackColor = true;
			this.checkMediaExistsButton.Click += new System.EventHandler(this.checkMediaExistsButton_Click);
			// 
			// CleanupMediaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 127);
			this.Controls.Add(this.checkMediaExistsButton);
			this.Controls.Add(this.cleanupMediaButton);
			this.Name = "CleanupMediaForm";
			this.Text = "Cleanup Media";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cleanupMediaButton;
		private System.Windows.Forms.Button checkMediaExistsButton;
	}
}

