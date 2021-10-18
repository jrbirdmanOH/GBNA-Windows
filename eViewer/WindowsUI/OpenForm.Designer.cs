namespace Thayer.Birding.UI.Windows
{
	partial class OpenForm
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
			this.collectionListView = new System.Windows.Forms.ListView();
			this.nameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.cancelButton = new System.Windows.Forms.Button();
			this.openButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.SuspendLayout();
			// 
			// collectionListView
			// 
			this.collectionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.collectionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
			this.collectionListView.FullRowSelect = true;
			this.collectionListView.HideSelection = false;
			this.collectionListView.Location = new System.Drawing.Point(13, 12);
			this.collectionListView.Name = "collectionListView";
			this.collectionListView.Size = new System.Drawing.Size(402, 187);
			this.collectionListView.TabIndex = 0;
			this.collectionListView.UseCompatibleStateImageBehavior = false;
			this.collectionListView.View = System.Windows.Forms.View.Details;
			this.collectionListView.SelectedIndexChanged += new System.EventHandler(this.collectionListView_SelectedIndexChanged);
			this.collectionListView.DoubleClick += new System.EventHandler(this.collectionListView_DoubleClick);
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Collection";
			this.nameColumnHeader.Width = 374;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(340, 234);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// openButton
			// 
			this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.openButton.Enabled = false;
			this.openButton.Location = new System.Drawing.Point(340, 205);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(75, 23);
			this.openButton.TabIndex = 2;
			this.openButton.Text = "Open";
			this.openButton.UseVisualStyleBackColor = true;
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// OpenForm
			// 
			this.AcceptButton = this.openButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(427, 269);
			this.Controls.Add(this.openButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.collectionListView);
			this.helpProvider.SetHelpKeyword(this, "38");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenForm";
			this.helpProvider.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Open";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView collectionListView;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}