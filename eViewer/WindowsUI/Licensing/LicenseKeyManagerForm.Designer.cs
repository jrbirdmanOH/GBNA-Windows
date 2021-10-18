namespace Thayer.Birding.UI.Windows.Licensing
{
	partial class LicenseKeyManagerForm
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
			this.licenseListView = new System.Windows.Forms.ListView();
			this.productNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.licenseKeyColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.closeButton = new System.Windows.Forms.Button();
			this.addLicenseKeyButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(112, 13);
			label1.TabIndex = 4;
			label1.Text = "Installed License Keys";
			// 
			// licenseListView
			// 
			this.licenseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productNameColumnHeader,
            this.licenseKeyColumnHeader});
			this.licenseListView.FullRowSelect = true;
			this.licenseListView.Location = new System.Drawing.Point(12, 28);
			this.licenseListView.Name = "licenseListView";
			this.licenseListView.Size = new System.Drawing.Size(385, 153);
			this.licenseListView.TabIndex = 0;
			this.licenseListView.UseCompatibleStateImageBehavior = false;
			this.licenseListView.View = System.Windows.Forms.View.Details;
			this.licenseListView.SelectedIndexChanged += new System.EventHandler(this.licenseListView_SelectedIndexChanged);
			// 
			// productNameColumnHeader
			// 
			this.productNameColumnHeader.Text = "Product Name";
			this.productNameColumnHeader.Width = 216;
			// 
			// licenseKeyColumnHeader
			// 
			this.licenseKeyColumnHeader.Text = "License Key";
			this.licenseKeyColumnHeader.Width = 134;
			// 
			// closeButton
			// 
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(403, 158);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// addLicenseKeyButton
			// 
			this.addLicenseKeyButton.Location = new System.Drawing.Point(403, 28);
			this.addLicenseKeyButton.Name = "addLicenseKeyButton";
			this.addLicenseKeyButton.Size = new System.Drawing.Size(75, 23);
			this.addLicenseKeyButton.TabIndex = 2;
			this.addLicenseKeyButton.Text = "Add...";
			this.addLicenseKeyButton.UseVisualStyleBackColor = true;
			this.addLicenseKeyButton.Click += new System.EventHandler(this.addLicenseKeyButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Enabled = false;
			this.deleteButton.Location = new System.Drawing.Point(403, 57);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 3;
			this.deleteButton.Text = "Delete";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// LicenseKeyManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(490, 193);
			this.Controls.Add(label1);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addLicenseKeyButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.licenseListView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.helpProvider.SetHelpKeyword(this, "25");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LicenseKeyManagerForm";
			this.helpProvider.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "License Keys";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView licenseListView;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button addLicenseKeyButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.ColumnHeader productNameColumnHeader;
		private System.Windows.Forms.ColumnHeader licenseKeyColumnHeader;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}