namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizCategoriesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyQuizCategoriesForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.categoryListView = new System.Windows.Forms.ListView();
			this.nameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.categoryItemsListView = new System.Windows.Forms.ListView();
			this.thingNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.thingAlternateNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.categoryItemsLabel = new System.Windows.Forms.Label();
			this.categoriesLabel = new System.Windows.Forms.Label();
			this.addCategoryItemButton = new System.Windows.Forms.Button();
			this.editCategoryItemButton = new System.Windows.Forms.Button();
			this.deleteCategoryItemButton = new System.Windows.Forms.Button();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(804, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.newToolStripMenuItem.Text = "New...";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Enabled = false;
			this.openToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// categoryListView
			// 
			this.categoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
			this.categoryListView.FullRowSelect = true;
			this.categoryListView.HideSelection = false;
			this.categoryListView.Location = new System.Drawing.Point(12, 69);
			this.categoryListView.Name = "categoryListView";
			this.categoryListView.Size = new System.Drawing.Size(388, 234);
			this.categoryListView.TabIndex = 3;
			this.categoryListView.UseCompatibleStateImageBehavior = false;
			this.categoryListView.View = System.Windows.Forms.View.Details;
			this.categoryListView.DoubleClick += new System.EventHandler(this.categoryListView_DoubleClick);
			this.categoryListView.SelectedIndexChanged += new System.EventHandler(this.categoryListView_SelectedIndexChanged);
			this.categoryListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.categoryListView_ColumnClick);
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Name";
			this.nameColumnHeader.Width = 362;
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.deleteToolStripButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(804, 25);
			this.toolStrip.TabIndex = 4;
			this.toolStrip.Text = "toolStrip1";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "newToolStripButton";
			this.newToolStripButton.ToolTipText = "Create New Category";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "openToolStripButton";
			this.openToolStripButton.ToolTipText = "Open Category for Editing";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// deleteToolStripButton
			// 
			this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deleteToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripButton.Name = "deleteToolStripButton";
			this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.deleteToolStripButton.Text = "deleteToolStripButton";
			this.deleteToolStripButton.ToolTipText = "Delete Selected Categories";
			this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
			// 
			// categoryItemsListView
			// 
			this.categoryItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.thingNameColumnHeader,
            this.thingAlternateNameColumnHeader});
			this.categoryItemsListView.FullRowSelect = true;
			this.categoryItemsListView.Location = new System.Drawing.Point(423, 69);
			this.categoryItemsListView.Name = "categoryItemsListView";
			this.categoryItemsListView.Size = new System.Drawing.Size(369, 234);
			this.categoryItemsListView.TabIndex = 5;
			this.categoryItemsListView.UseCompatibleStateImageBehavior = false;
			this.categoryItemsListView.View = System.Windows.Forms.View.Details;
			// 
			// thingNameColumnHeader
			// 
			this.thingNameColumnHeader.Text = "Name";
			this.thingNameColumnHeader.Width = 173;
			// 
			// thingAlternateNameColumnHeader
			// 
			this.thingAlternateNameColumnHeader.Text = "Alternate Name";
			this.thingAlternateNameColumnHeader.Width = 168;
			// 
			// categoryItemsLabel
			// 
			this.categoryItemsLabel.AutoSize = true;
			this.categoryItemsLabel.Location = new System.Drawing.Point(420, 53);
			this.categoryItemsLabel.Name = "categoryItemsLabel";
			this.categoryItemsLabel.Size = new System.Drawing.Size(80, 13);
			this.categoryItemsLabel.TabIndex = 6;
			this.categoryItemsLabel.Text = "Category Items:";
			// 
			// categoriesLabel
			// 
			this.categoriesLabel.AutoSize = true;
			this.categoriesLabel.Location = new System.Drawing.Point(12, 53);
			this.categoriesLabel.Name = "categoriesLabel";
			this.categoriesLabel.Size = new System.Drawing.Size(60, 13);
			this.categoriesLabel.TabIndex = 7;
			this.categoriesLabel.Text = "Categories:";
			// 
			// addCategoryItemButton
			// 
			this.addCategoryItemButton.Location = new System.Drawing.Point(423, 310);
			this.addCategoryItemButton.Name = "addCategoryItemButton";
			this.addCategoryItemButton.Size = new System.Drawing.Size(75, 23);
			this.addCategoryItemButton.TabIndex = 8;
			this.addCategoryItemButton.Text = "Add...";
			this.addCategoryItemButton.UseVisualStyleBackColor = true;
			this.addCategoryItemButton.Click += new System.EventHandler(this.addCategoryItemButton_Click);
			// 
			// editCategoryItemButton
			// 
			this.editCategoryItemButton.Location = new System.Drawing.Point(504, 310);
			this.editCategoryItemButton.Name = "editCategoryItemButton";
			this.editCategoryItemButton.Size = new System.Drawing.Size(75, 23);
			this.editCategoryItemButton.TabIndex = 9;
			this.editCategoryItemButton.Text = "Edit...";
			this.editCategoryItemButton.UseVisualStyleBackColor = true;
			this.editCategoryItemButton.Click += new System.EventHandler(this.editCategoryItemButton_Click);
			// 
			// deleteCategoryItemButton
			// 
			this.deleteCategoryItemButton.Location = new System.Drawing.Point(585, 310);
			this.deleteCategoryItemButton.Name = "deleteCategoryItemButton";
			this.deleteCategoryItemButton.Size = new System.Drawing.Size(75, 23);
			this.deleteCategoryItemButton.TabIndex = 10;
			this.deleteCategoryItemButton.Text = "Delete";
			this.deleteCategoryItemButton.UseVisualStyleBackColor = true;
			this.deleteCategoryItemButton.Click += new System.EventHandler(this.deleteCategoryItemButton_Click);
			// 
			// MyQuizCategoriesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(804, 357);
			this.Controls.Add(this.deleteCategoryItemButton);
			this.Controls.Add(this.editCategoryItemButton);
			this.Controls.Add(this.addCategoryItemButton);
			this.Controls.Add(this.categoriesLabel);
			this.Controls.Add(this.categoryItemsLabel);
			this.Controls.Add(this.categoryItemsListView);
			this.Controls.Add(this.categoryListView);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MyQuizCategoriesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "My Quiz Categories";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ListView categoryListView;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.ListView categoryItemsListView;
		private System.Windows.Forms.ColumnHeader thingNameColumnHeader;
		private System.Windows.Forms.ColumnHeader thingAlternateNameColumnHeader;
		private System.Windows.Forms.Label categoryItemsLabel;
		private System.Windows.Forms.Label categoriesLabel;
		private System.Windows.Forms.Button addCategoryItemButton;
		private System.Windows.Forms.Button editCategoryItemButton;
		private System.Windows.Forms.Button deleteCategoryItemButton;
	}
}