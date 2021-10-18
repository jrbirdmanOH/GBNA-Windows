namespace Deploy
{
	partial class FileListPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListPanel));
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.fileListView = new System.Windows.Forms.DataGridView();
			this.fileNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.removeButton = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.manifestBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.FileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RetainColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.fileListView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manifestBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(390, 31);
			this.label1.TabIndex = 2;
			this.label1.Text = "The following is a list of the files to be included in the manifest. Remove any f" +
				"iles that should not be part of the download.";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
			// 
			// fileListView
			// 
			this.fileListView.AllowUserToAddRows = false;
			this.fileListView.AllowUserToResizeRows = false;
			this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fileListView.AutoGenerateColumns = false;
			this.fileListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileNameColumn,
            this.RetainColumn});
			this.fileListView.DataSource = this.manifestBindingSource;
			this.fileListView.Location = new System.Drawing.Point(0, 62);
			this.fileListView.Name = "fileListView";
			this.fileListView.RowHeadersVisible = false;
			this.fileListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.fileListView.Size = new System.Drawing.Size(390, 140);
			this.fileListView.TabIndex = 3;
			// 
			// fileNameColumnHeader
			// 
			this.fileNameColumnHeader.Text = "File Name";
			this.fileNameColumnHeader.Width = 357;
			// 
			// removeButton
			// 
			this.removeButton.AutoSize = true;
			this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.removeButton.ImageIndex = 0;
			this.removeButton.ImageList = this.imageList;
			this.removeButton.Location = new System.Drawing.Point(365, 34);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(22, 22);
			this.removeButton.TabIndex = 4;
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
			this.imageList.Images.SetKeyName(0, "Delete.bmp");
			// 
			// manifestBindingSource
			// 
			this.manifestBindingSource.DataMember = "Files";
			this.manifestBindingSource.DataSource = typeof(Thayer.Birding.Updates.Manifest);
			// 
			// FileNameColumn
			// 
			this.FileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FileNameColumn.DataPropertyName = "Name";
			this.FileNameColumn.HeaderText = "File Name";
			this.FileNameColumn.Name = "FileNameColumn";
			this.FileNameColumn.ReadOnly = true;
			// 
			// RetainColumn
			// 
			this.RetainColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.RetainColumn.DataPropertyName = "Retain";
			this.RetainColumn.HeaderText = "Retain";
			this.RetainColumn.Name = "RetainColumn";
			this.RetainColumn.Width = 44;
			// 
			// FileListPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fileListView);
			this.Name = "FileListPanel";
			this.Size = new System.Drawing.Size(390, 202);
			((System.ComponentModel.ISupportInitialize)(this.fileListView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manifestBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.DataGridView fileListView;
		private System.Windows.Forms.ColumnHeader fileNameColumnHeader;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileNameColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn RetainColumn;
		private System.Windows.Forms.BindingSource manifestBindingSource;

	}
}
