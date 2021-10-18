namespace Thayer.Birding.UI.Windows
{
	partial class PeteySandboxForm
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tipButton = new System.Windows.Forms.Button();
			this.jokeButton = new System.Windows.Forms.Button();
			this.showButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.speakButton = new System.Windows.Forms.Button();
			this.sandboxTextBox = new System.Windows.Forms.TextBox();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.optionsButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.petey_shadowed;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(81, 90);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// tipButton
			// 
			this.tipButton.Location = new System.Drawing.Point(12, 177);
			this.tipButton.Name = "tipButton";
			this.tipButton.Size = new System.Drawing.Size(94, 23);
			this.tipButton.TabIndex = 2;
			this.tipButton.Text = "&Tip of the Day";
			this.tipButton.UseVisualStyleBackColor = true;
			this.tipButton.Click += new System.EventHandler(this.tipButton_Click);
			// 
			// jokeButton
			// 
			this.jokeButton.Location = new System.Drawing.Point(112, 177);
			this.jokeButton.Name = "jokeButton";
			this.jokeButton.Size = new System.Drawing.Size(94, 23);
			this.jokeButton.TabIndex = 3;
			this.jokeButton.Text = "Tell a &Joke";
			this.jokeButton.UseVisualStyleBackColor = true;
			this.jokeButton.Click += new System.EventHandler(this.jokeButton_Click);
			// 
			// showButton
			// 
			this.showButton.Location = new System.Drawing.Point(212, 177);
			this.showButton.Name = "showButton";
			this.showButton.Size = new System.Drawing.Size(94, 23);
			this.showButton.TabIndex = 4;
			this.showButton.Text = "Show &Petey";
			this.showButton.UseVisualStyleBackColor = true;
			this.showButton.Click += new System.EventHandler(this.showButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(312, 177);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(94, 23);
			this.closeButton.TabIndex = 5;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.speakButton);
			this.groupBox1.Controls.Add(this.sandboxTextBox);
			this.groupBox1.Location = new System.Drawing.Point(99, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(307, 159);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sandbox";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(289, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type in anything below, click \"Speak\", and Petey will say it!";
			// 
			// speakButton
			// 
			this.speakButton.Location = new System.Drawing.Point(226, 36);
			this.speakButton.Name = "speakButton";
			this.speakButton.Size = new System.Drawing.Size(75, 23);
			this.speakButton.TabIndex = 1;
			this.speakButton.Text = "&Speak";
			this.speakButton.UseVisualStyleBackColor = true;
			this.speakButton.Click += new System.EventHandler(this.speakButton_Click);
			// 
			// sandboxTextBox
			// 
			this.sandboxTextBox.Location = new System.Drawing.Point(6, 36);
			this.sandboxTextBox.Multiline = true;
			this.sandboxTextBox.Name = "sandboxTextBox";
			this.sandboxTextBox.Size = new System.Drawing.Size(214, 117);
			this.sandboxTextBox.TabIndex = 2;
			this.sandboxTextBox.Text = "Welcome to Petey\'s sandbox!";
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// optionsButton
			// 
			this.optionsButton.Location = new System.Drawing.Point(12, 108);
			this.optionsButton.Name = "optionsButton";
			this.optionsButton.Size = new System.Drawing.Size(81, 23);
			this.optionsButton.TabIndex = 1;
			this.optionsButton.Text = "&Options...";
			this.optionsButton.UseVisualStyleBackColor = true;
			this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
			// 
			// PeteySandboxForm
			// 
			this.AcceptButton = this.speakButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(418, 212);
			this.Controls.Add(this.optionsButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.showButton);
			this.Controls.Add(this.jokeButton);
			this.Controls.Add(this.tipButton);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.helpProvider.SetHelpKeyword(this, "43");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PeteySandboxForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Petey\'s Sandbox";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button tipButton;
		private System.Windows.Forms.Button jokeButton;
		private System.Windows.Forms.Button showButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button speakButton;
		private System.Windows.Forms.TextBox sandboxTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button optionsButton;
	}
}