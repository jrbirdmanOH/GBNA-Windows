namespace Deploy
{
	partial class DeploymentWizardForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeploymentWizardForm));
			this.titlePanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.previousButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.finishButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.contentPanel = new System.Windows.Forms.Panel();
			this.selectOutputDirectoryPanel = new Deploy.SelectOutputDirectoryPanel();
			this.fileListPanel = new Deploy.FileListPanel();
			this.selectInputDirectoryPanel = new Deploy.SelectInputDirectoryPanel();
			this.titlePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.buttonPanel.SuspendLayout();
			this.contentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// titlePanel
			// 
			this.titlePanel.BackColor = System.Drawing.Color.White;
			this.titlePanel.Controls.Add(this.label1);
			this.titlePanel.Controls.Add(this.pictureBox1);
			this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titlePanel.Location = new System.Drawing.Point(0, 0);
			this.titlePanel.Name = "titlePanel";
			this.titlePanel.Size = new System.Drawing.Size(414, 57);
			this.titlePanel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(50, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Deployment Wizard";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.label2);
			this.buttonPanel.Controls.Add(this.previousButton);
			this.buttonPanel.Controls.Add(this.nextButton);
			this.buttonPanel.Controls.Add(this.finishButton);
			this.buttonPanel.Controls.Add(this.cancelButton);
			this.buttonPanel.Location = new System.Drawing.Point(12, 271);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(390, 33);
			this.buttonPanel.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(390, 3);
			this.label2.TabIndex = 0;
			// 
			// previousButton
			// 
			this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.previousButton.Location = new System.Drawing.Point(72, 10);
			this.previousButton.Name = "previousButton";
			this.previousButton.Size = new System.Drawing.Size(75, 23);
			this.previousButton.TabIndex = 1;
			this.previousButton.Text = "< Previous";
			this.previousButton.UseVisualStyleBackColor = true;
			this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(153, 10);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 2;
			this.nextButton.Text = "Next >";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Location = new System.Drawing.Point(234, 10);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 3;
			this.finishButton.Text = "Finish";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(315, 10);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// contentPanel
			// 
			this.contentPanel.Controls.Add(this.selectOutputDirectoryPanel);
			this.contentPanel.Controls.Add(this.fileListPanel);
			this.contentPanel.Controls.Add(this.selectInputDirectoryPanel);
			this.contentPanel.Location = new System.Drawing.Point(12, 63);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(390, 202);
			this.contentPanel.TabIndex = 10;
			// 
			// selectOutputDirectoryPanel
			// 
			this.selectOutputDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectOutputDirectoryPanel.Location = new System.Drawing.Point(0, 0);
			this.selectOutputDirectoryPanel.Name = "selectOutputDirectoryPanel";
			this.selectOutputDirectoryPanel.Size = new System.Drawing.Size(390, 202);
			this.selectOutputDirectoryPanel.TabIndex = 0;
			this.selectOutputDirectoryPanel.Visible = false;
			// 
			// fileListPanel
			// 
			this.fileListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fileListPanel.Location = new System.Drawing.Point(0, 0);
			this.fileListPanel.Manifest = null;
			this.fileListPanel.Name = "fileListPanel";
			this.fileListPanel.Size = new System.Drawing.Size(390, 202);
			this.fileListPanel.TabIndex = 1;
			this.fileListPanel.Visible = false;
			// 
			// selectInputDirectoryPanel
			// 
			this.selectInputDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectInputDirectoryPanel.Location = new System.Drawing.Point(0, 0);
			this.selectInputDirectoryPanel.Name = "selectInputDirectoryPanel";
			this.selectInputDirectoryPanel.Size = new System.Drawing.Size(390, 202);
			this.selectInputDirectoryPanel.TabIndex = 0;
			// 
			// DeploymentWizardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 316);
			this.Controls.Add(this.contentPanel);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.titlePanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeploymentWizardForm";
			this.ShowIcon = false;
			this.Text = "eViewer Deployment Wizard";
			this.titlePanel.ResumeLayout(false);
			this.titlePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.buttonPanel.ResumeLayout(false);
			this.contentPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel titlePanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button previousButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Panel contentPanel;
		private SelectInputDirectoryPanel selectInputDirectoryPanel;
		private FileListPanel fileListPanel;
		private SelectOutputDirectoryPanel selectOutputDirectoryPanel;
	}
}

