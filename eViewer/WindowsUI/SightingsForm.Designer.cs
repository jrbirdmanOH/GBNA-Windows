namespace Thayer.Birding.UI.Windows
{
	partial class SightingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SightingsForm));
			this.sightingsListView = new System.Windows.Forms.ListView();
			this.commonNameColumnHeader = new System.Windows.Forms.ColumnHeader("(none)");
			this.dateColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.locationColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.observerColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.commentsColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsCustomListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sortTaxonomicallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.observersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.sortTaxonomicallyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.observersToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.reportsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveAsCustomListToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// sightingsListView
			// 
			this.sightingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.commonNameColumnHeader,
            this.dateColumnHeader,
            this.locationColumnHeader,
            this.observerColumnHeader,
            this.commentsColumnHeader});
			this.sightingsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sightingsListView.FullRowSelect = true;
			this.sightingsListView.HideSelection = false;
			this.sightingsListView.Location = new System.Drawing.Point(0, 49);
			this.sightingsListView.Name = "sightingsListView";
			this.sightingsListView.Size = new System.Drawing.Size(795, 408);
			this.sightingsListView.SmallImageList = this.imageList;
			this.sightingsListView.TabIndex = 0;
			this.sightingsListView.UseCompatibleStateImageBehavior = false;
			this.sightingsListView.View = System.Windows.Forms.View.Details;
			this.sightingsListView.SelectedIndexChanged += new System.EventHandler(this.sightingsListView_SelectedIndexChanged);
			this.sightingsListView.DoubleClick += new System.EventHandler(this.sightingsListView_DoubleClick);
			this.sightingsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sightingsListView_ColumnClick);
			this.sightingsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sightingsListView_KeyDown);
			// 
			// commonNameColumnHeader
			// 
			this.commonNameColumnHeader.Text = "Common Name";
			this.commonNameColumnHeader.Width = 160;
			// 
			// dateColumnHeader
			// 
			this.dateColumnHeader.Text = "Date";
			this.dateColumnHeader.Width = 75;
			// 
			// locationColumnHeader
			// 
			this.locationColumnHeader.Text = "Location";
			this.locationColumnHeader.Width = 120;
			// 
			// observerColumnHeader
			// 
			this.observerColumnHeader.Text = "Observer";
			this.observerColumnHeader.Width = 160;
			// 
			// commentsColumnHeader
			// 
			this.commentsColumnHeader.Text = "Comments";
			this.commentsColumnHeader.Width = 240;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList.Images.SetKeyName(0, "SortTaxonomically");
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(795, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.saveAsCustomListToolStripMenuItem,
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
			this.newToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
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
			this.openToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// saveAsCustomListToolStripMenuItem
			// 
			this.saveAsCustomListToolStripMenuItem.Name = "saveAsCustomListToolStripMenuItem";
			this.saveAsCustomListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveAsCustomListToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.saveAsCustomListToolStripMenuItem.Text = "&Save as Custom List...";
			this.saveAsCustomListToolStripMenuItem.Click += new System.EventHandler(this.saveAsCustomListToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortTaxonomicallyToolStripMenuItem,
            this.observersToolStripMenuItem,
            this.reportsToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// sortTaxonomicallyToolStripMenuItem
			// 
			this.sortTaxonomicallyToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OrgChart;
			this.sortTaxonomicallyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sortTaxonomicallyToolStripMenuItem.Name = "sortTaxonomicallyToolStripMenuItem";
			this.sortTaxonomicallyToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.sortTaxonomicallyToolStripMenuItem.Text = "Sort &Taxonomically";
			this.sortTaxonomicallyToolStripMenuItem.Click += new System.EventHandler(this.sortTaxonomicallyToolStripMenuItem_Click);
			// 
			// observersToolStripMenuItem
			// 
			this.observersToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Find;
			this.observersToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.observersToolStripMenuItem.Name = "observersToolStripMenuItem";
			this.observersToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.observersToolStripMenuItem.Text = "&Observers...";
			this.observersToolStripMenuItem.Click += new System.EventHandler(this.observersToolStripMenuItem_Click);
			// 
			// reportsToolStripMenuItem
			// 
			this.reportsToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Reports;
			this.reportsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
			this.reportsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.reportsToolStripMenuItem.Text = "&Reports...";
			this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.sortTaxonomicallyToolStripButton,
            this.observersToolStripButton,
            this.reportsToolStripButton,
            this.toolStripSeparator2,
            this.saveAsCustomListToolStripButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(795, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "newToolStripButton";
			this.newToolStripButton.ToolTipText = "Create New Sighting";
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
			this.openToolStripButton.ToolTipText = "Open Sighting for Editing";
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
			this.deleteToolStripButton.ToolTipText = "Delete Selected Sightings";
			this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// sortTaxonomicallyToolStripButton
			// 
			this.sortTaxonomicallyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.sortTaxonomicallyToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OrgChart;
			this.sortTaxonomicallyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sortTaxonomicallyToolStripButton.Name = "sortTaxonomicallyToolStripButton";
			this.sortTaxonomicallyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.sortTaxonomicallyToolStripButton.Text = "sortTaxonomicallyToolStripButton";
			this.sortTaxonomicallyToolStripButton.ToolTipText = "Sort Taxonomically";
			this.sortTaxonomicallyToolStripButton.Click += new System.EventHandler(this.sortTaxonomicallyToolStripButton_Click);
			// 
			// observersToolStripButton
			// 
			this.observersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.observersToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Find;
			this.observersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.observersToolStripButton.Name = "observersToolStripButton";
			this.observersToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.observersToolStripButton.Text = "Manage Observers";
			this.observersToolStripButton.Click += new System.EventHandler(this.observersToolStripButton_Click);
			// 
			// reportsToolStripButton
			// 
			this.reportsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.reportsToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Reports;
			this.reportsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.reportsToolStripButton.Name = "reportsToolStripButton";
			this.reportsToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.reportsToolStripButton.Text = "reportsToolStripButton";
			this.reportsToolStripButton.ToolTipText = "View Sighting Reports";
			this.reportsToolStripButton.Click += new System.EventHandler(this.reportsToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// saveAsCustomListToolStripButton
			// 
			this.saveAsCustomListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.saveAsCustomListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveAsCustomListToolStripButton.Name = "saveAsCustomListToolStripButton";
			this.saveAsCustomListToolStripButton.Size = new System.Drawing.Size(115, 22);
			this.saveAsCustomListToolStripButton.Text = "Save as Custom List";
			this.saveAsCustomListToolStripButton.Click += new System.EventHandler(this.saveAsCustomListToolStripButton_Click);
			// 
			// SightingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 457);
			this.Controls.Add(this.sightingsListView);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.helpProvider.SetHelpKeyword(this, "56");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "SightingsForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sightings";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView sightingsListView;
		private System.Windows.Forms.ColumnHeader commonNameColumnHeader;
		private System.Windows.Forms.ColumnHeader dateColumnHeader;
		private System.Windows.Forms.ColumnHeader locationColumnHeader;
		private System.Windows.Forms.ColumnHeader observerColumnHeader;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.ColumnHeader commentsColumnHeader;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton reportsToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton observersToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem observersToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton saveAsCustomListToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem saveAsCustomListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripButton sortTaxonomicallyToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem sortTaxonomicallyToolStripMenuItem;
	}
}