namespace Thayer.Birding.UI.Windows
{
	partial class ImportPreviousVersionForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPreviousVersionForm));
			this.databaseNameTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.cancelButton = new System.Windows.Forms.Button();
			this.importButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.restoringMessageLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 95);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(57, 13);
			label1.TabIndex = 1;
			label1.Text = "File Name:";
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(12, 18);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(448, 56);
			label2.TabIndex = 0;
			label2.Text = resources.GetString("label2.Text");
			// 
			// databaseNameTextBox
			// 
			this.databaseNameTextBox.Location = new System.Drawing.Point(75, 91);
			this.databaseNameTextBox.Name = "databaseNameTextBox";
			this.databaseNameTextBox.Size = new System.Drawing.Size(354, 20);
			this.databaseNameTextBox.TabIndex = 2;
			this.databaseNameTextBox.TextChanged += new System.EventHandler(this.databaseNameTextBox_TextChanged);
			// 
			// browseButton
			// 
			this.browseButton.ImageIndex = 0;
			this.browseButton.ImageList = this.imageList;
			this.browseButton.Location = new System.Drawing.Point(435, 90);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(23, 22);
			this.browseButton.TabIndex = 3;
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList.Images.SetKeyName(0, "Find.bmp");
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(383, 149);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// importButton
			// 
			this.importButton.Location = new System.Drawing.Point(302, 149);
			this.importButton.Name = "importButton";
			this.importButton.Size = new System.Drawing.Size(75, 23);
			this.importButton.TabIndex = 5;
			this.importButton.Text = "&Restore";
			this.importButton.UseVisualStyleBackColor = true;
			this.importButton.Click += new System.EventHandler(this.importButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// restoringMessageLabel
			// 
			this.restoringMessageLabel.AutoSize = true;
			this.restoringMessageLabel.Location = new System.Drawing.Point(75, 124);
			this.restoringMessageLabel.Name = "restoringMessageLabel";
			this.restoringMessageLabel.Size = new System.Drawing.Size(322, 13);
			this.restoringMessageLabel.TabIndex = 4;
			this.restoringMessageLabel.Text = "Restoring...   This may take a few minutes depending on your data.";
			this.restoringMessageLabel.Visible = false;
			// 
			// ImportPreviousVersionForm
			// 
			this.AcceptButton = this.importButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(472, 191);
			this.Controls.Add(this.restoringMessageLabel);
			this.Controls.Add(label2);
			this.Controls.Add(this.importButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.databaseNameTextBox);
			this.Controls.Add(label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.helpProvider.SetHelpKeyword(this, "8");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "ImportPreviousVersionForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eViewer Restore Backup";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox databaseNameTextBox;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button importButton;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Label restoringMessageLabel;
	}
}