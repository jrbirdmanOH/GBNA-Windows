namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizEditCategoryForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyQuizEditCategoryForm));
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.deleteCategoryItemButton = new System.Windows.Forms.Button();
			this.editCategoryItemButton = new System.Windows.Forms.Button();
			this.newCategoryItemButton = new System.Windows.Forms.Button();
			this.categoryItemsListView = new System.Windows.Forms.ListView();
			this.thingNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.thingAlternateNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.categoryItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.categoryItemsGroupBox = new System.Windows.Forms.GroupBox();
			this.copyButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			label1 = new System.Windows.Forms.Label();
			this.categoryItemContextMenuStrip.SuspendLayout();
			this.categoryItemsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			label1.Location = new System.Drawing.Point(10, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(523, 59);
			label1.TabIndex = 0;
			label1.Text = resources.GetString("label1.Text");
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(12, 23);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(83, 13);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Category Name:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(101, 20);
			this.nameTextBox.MaxLength = 50;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(300, 20);
			this.nameTextBox.TabIndex = 1;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(284, 431);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.Location = new System.Drawing.Point(203, 431);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// deleteCategoryItemButton
			// 
			this.deleteCategoryItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.deleteCategoryItemButton.Location = new System.Drawing.Point(272, 325);
			this.deleteCategoryItemButton.Name = "deleteCategoryItemButton";
			this.deleteCategoryItemButton.Size = new System.Drawing.Size(75, 23);
			this.deleteCategoryItemButton.TabIndex = 4;
			this.deleteCategoryItemButton.Text = "Delete";
			this.deleteCategoryItemButton.UseVisualStyleBackColor = true;
			this.deleteCategoryItemButton.Click += new System.EventHandler(this.deleteCategoryItemButton_Click);
			// 
			// editCategoryItemButton
			// 
			this.editCategoryItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.editCategoryItemButton.Location = new System.Drawing.Point(191, 325);
			this.editCategoryItemButton.Name = "editCategoryItemButton";
			this.editCategoryItemButton.Size = new System.Drawing.Size(75, 23);
			this.editCategoryItemButton.TabIndex = 3;
			this.editCategoryItemButton.Text = "Edit...";
			this.editCategoryItemButton.UseVisualStyleBackColor = true;
			this.editCategoryItemButton.Click += new System.EventHandler(this.editCategoryItemButton_Click);
			// 
			// newCategoryItemButton
			// 
			this.newCategoryItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.newCategoryItemButton.Location = new System.Drawing.Point(110, 325);
			this.newCategoryItemButton.Name = "newCategoryItemButton";
			this.newCategoryItemButton.Size = new System.Drawing.Size(75, 23);
			this.newCategoryItemButton.TabIndex = 2;
			this.newCategoryItemButton.Text = "New...";
			this.newCategoryItemButton.UseVisualStyleBackColor = true;
			this.newCategoryItemButton.Click += new System.EventHandler(this.newCategoryItemButton_Click);
			// 
			// categoryItemsListView
			// 
			this.categoryItemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.categoryItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.thingNameColumnHeader,
            this.thingAlternateNameColumnHeader});
			this.categoryItemsListView.ContextMenuStrip = this.categoryItemContextMenuStrip;
			this.categoryItemsListView.FullRowSelect = true;
			this.categoryItemsListView.HideSelection = false;
			this.categoryItemsListView.Location = new System.Drawing.Point(10, 85);
			this.categoryItemsListView.Name = "categoryItemsListView";
			this.categoryItemsListView.Size = new System.Drawing.Size(520, 234);
			this.categoryItemsListView.TabIndex = 1;
			this.categoryItemsListView.UseCompatibleStateImageBehavior = false;
			this.categoryItemsListView.View = System.Windows.Forms.View.Details;
			this.categoryItemsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.categoryItemsListView_ColumnClick);
			this.categoryItemsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.categoryItemsListView_ItemSelectionChanged);
			this.categoryItemsListView.DoubleClick += new System.EventHandler(this.categoryItemsListView_DoubleClick);
			this.categoryItemsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoryItemsListView_KeyDown);
			// 
			// thingNameColumnHeader
			// 
			this.thingNameColumnHeader.Text = "Name";
			this.thingNameColumnHeader.Width = 249;
			// 
			// thingAlternateNameColumnHeader
			// 
			this.thingAlternateNameColumnHeader.Text = "Alternate Name";
			this.thingAlternateNameColumnHeader.Width = 226;
			// 
			// categoryItemContextMenuStrip
			// 
			this.categoryItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.categoryItemContextMenuStrip.Name = "categoryItemContextMenuStrip";
			this.categoryItemContextMenuStrip.Size = new System.Drawing.Size(108, 70);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.editToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// categoryItemsGroupBox
			// 
			this.categoryItemsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.categoryItemsGroupBox.Controls.Add(this.copyButton);
			this.categoryItemsGroupBox.Controls.Add(label1);
			this.categoryItemsGroupBox.Controls.Add(this.categoryItemsListView);
			this.categoryItemsGroupBox.Controls.Add(this.deleteCategoryItemButton);
			this.categoryItemsGroupBox.Controls.Add(this.newCategoryItemButton);
			this.categoryItemsGroupBox.Controls.Add(this.editCategoryItemButton);
			this.categoryItemsGroupBox.Location = new System.Drawing.Point(12, 58);
			this.categoryItemsGroupBox.Name = "categoryItemsGroupBox";
			this.categoryItemsGroupBox.Size = new System.Drawing.Size(539, 356);
			this.categoryItemsGroupBox.TabIndex = 2;
			this.categoryItemsGroupBox.TabStop = false;
			this.categoryItemsGroupBox.Text = "Category Items";
			// 
			// copyButton
			// 
			this.copyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.copyButton.Location = new System.Drawing.Point(353, 325);
			this.copyButton.Name = "copyButton";
			this.copyButton.Size = new System.Drawing.Size(75, 23);
			this.copyButton.TabIndex = 5;
			this.copyButton.Text = "Copy...";
			this.copyButton.UseVisualStyleBackColor = true;
			this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyQuizEditCategoryForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(562, 466);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.categoryItemsGroupBox);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.nameLabel);
			this.helpProvider.SetHelpKeyword(this, "31");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "MyQuizEditCategoryForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Category";
			this.categoryItemContextMenuStrip.ResumeLayout(false);
			this.categoryItemsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button deleteCategoryItemButton;
		private System.Windows.Forms.Button editCategoryItemButton;
		private System.Windows.Forms.Button newCategoryItemButton;
		private System.Windows.Forms.ListView categoryItemsListView;
		private System.Windows.Forms.ColumnHeader thingNameColumnHeader;
		private System.Windows.Forms.ColumnHeader thingAlternateNameColumnHeader;
		private System.Windows.Forms.GroupBox categoryItemsGroupBox;
		private System.Windows.Forms.ContextMenuStrip categoryItemContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button copyButton;
	}
}