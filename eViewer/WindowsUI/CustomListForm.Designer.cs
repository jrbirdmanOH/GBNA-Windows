namespace Thayer.Birding.UI.Windows
{
	partial class CustomListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomListForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.customListsTreeView = new System.Windows.Forms.TreeView();
			this.customListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToClipboardContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customListImageList = new System.Windows.Forms.ImageList(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.removeContentButton = new System.Windows.Forms.Button();
			this.contentsImageList = new System.Windows.Forms.ImageList(this.components);
			this.moveDownButton = new System.Windows.Forms.Button();
			this.moveUpButton = new System.Windows.Forms.Button();
			this.addContentButton = new System.Windows.Forms.Button();
			this.organismComboBox = new Thayer.Birding.UI.Windows.OrganismComboBox();
			this.contentsListBox = new System.Windows.Forms.ListBox();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveAsScreenSaverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.portableDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.takeQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.idWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.photoGalleryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToClipboardToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.alphabeticToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.taxonomicToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.photoGalleryToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.takeQuizToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.idWizardToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.customListContextMenuStrip.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.customListsTreeView);
			this.groupBox1.Location = new System.Drawing.Point(12, 52);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(333, 382);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lists";
			// 
			// customListsTreeView
			// 
			this.customListsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.customListsTreeView.ContextMenuStrip = this.customListContextMenuStrip;
			this.customListsTreeView.HideSelection = false;
			this.customListsTreeView.ImageIndex = 0;
			this.customListsTreeView.ImageList = this.customListImageList;
			this.customListsTreeView.Location = new System.Drawing.Point(6, 19);
			this.customListsTreeView.Name = "customListsTreeView";
			this.customListsTreeView.SelectedImageIndex = 0;
			this.customListsTreeView.Size = new System.Drawing.Size(321, 357);
			this.customListsTreeView.TabIndex = 1;
			this.customListsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.customListsTreeView_AfterSelect);
			this.customListsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.customListsTreeView_NodeMouseClick);
			this.customListsTreeView.DoubleClick += new System.EventHandler(this.customListsTreeView_DoubleClick);
			// 
			// customListContextMenuStrip
			// 
			this.customListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardContextMenuToolStripMenuItem});
			this.customListContextMenuStrip.Name = "customListContextMenuStrip";
			this.customListContextMenuStrip.Size = new System.Drawing.Size(172, 26);
			// 
			// copyToClipboardContextMenuToolStripMenuItem
			// 
			this.copyToClipboardContextMenuToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Clipboard;
			this.copyToClipboardContextMenuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToClipboardContextMenuToolStripMenuItem.Name = "copyToClipboardContextMenuToolStripMenuItem";
			this.copyToClipboardContextMenuToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.copyToClipboardContextMenuToolStripMenuItem.Text = "Copy to Clip&board";
			this.copyToClipboardContextMenuToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardContextMenuToolStripMenuItem_Click);
			// 
			// customListImageList
			// 
			this.customListImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("customListImageList.ImageStream")));
			this.customListImageList.TransparentColor = System.Drawing.Color.Fuchsia;
			this.customListImageList.Images.SetKeyName(0, "Collection.bmp");
			this.customListImageList.Images.SetKeyName(1, "CustomList.bmp");
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.removeContentButton);
			this.groupBox2.Controls.Add(this.moveDownButton);
			this.groupBox2.Controls.Add(this.moveUpButton);
			this.groupBox2.Controls.Add(this.addContentButton);
			this.groupBox2.Controls.Add(this.organismComboBox);
			this.groupBox2.Controls.Add(this.contentsListBox);
			this.groupBox2.Location = new System.Drawing.Point(351, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(294, 382);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Contents";
			// 
			// removeContentButton
			// 
			this.removeContentButton.AutoSize = true;
			this.removeContentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.removeContentButton.Enabled = false;
			this.removeContentButton.ImageKey = "Delete.bmp";
			this.removeContentButton.ImageList = this.contentsImageList;
			this.removeContentButton.Location = new System.Drawing.Point(266, 47);
			this.removeContentButton.Name = "removeContentButton";
			this.removeContentButton.Size = new System.Drawing.Size(22, 22);
			this.removeContentButton.TabIndex = 5;
			this.toolTip.SetToolTip(this.removeContentButton, "Remove highlighted bird from this Custom List");
			this.removeContentButton.UseVisualStyleBackColor = true;
			this.removeContentButton.Click += new System.EventHandler(this.removeContentButton_Click);
			// 
			// contentsImageList
			// 
			this.contentsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("contentsImageList.ImageStream")));
			this.contentsImageList.TransparentColor = System.Drawing.Color.Magenta;
			this.contentsImageList.Images.SetKeyName(0, "MoveUp");
			this.contentsImageList.Images.SetKeyName(1, "MoveDown");
			this.contentsImageList.Images.SetKeyName(2, "Delete.bmp");
			// 
			// moveDownButton
			// 
			this.moveDownButton.AutoSize = true;
			this.moveDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveDownButton.Enabled = false;
			this.moveDownButton.ImageKey = "MoveDown";
			this.moveDownButton.ImageList = this.contentsImageList;
			this.moveDownButton.Location = new System.Drawing.Point(238, 47);
			this.moveDownButton.Name = "moveDownButton";
			this.moveDownButton.Size = new System.Drawing.Size(22, 22);
			this.moveDownButton.TabIndex = 4;
			this.toolTip.SetToolTip(this.moveDownButton, "Move Down");
			this.moveDownButton.UseVisualStyleBackColor = true;
			this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
			// 
			// moveUpButton
			// 
			this.moveUpButton.AutoSize = true;
			this.moveUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveUpButton.Enabled = false;
			this.moveUpButton.ImageKey = "MoveUp";
			this.moveUpButton.ImageList = this.contentsImageList;
			this.moveUpButton.Location = new System.Drawing.Point(210, 47);
			this.moveUpButton.Name = "moveUpButton";
			this.moveUpButton.Size = new System.Drawing.Size(22, 22);
			this.moveUpButton.TabIndex = 3;
			this.toolTip.SetToolTip(this.moveUpButton, "Move Up");
			this.moveUpButton.UseVisualStyleBackColor = true;
			this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
			// 
			// addContentButton
			// 
			this.addContentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addContentButton.Enabled = false;
			this.addContentButton.Location = new System.Drawing.Point(213, 18);
			this.addContentButton.Name = "addContentButton";
			this.addContentButton.Size = new System.Drawing.Size(75, 23);
			this.addContentButton.TabIndex = 2;
			this.addContentButton.Text = "Add";
			this.addContentButton.UseVisualStyleBackColor = true;
			this.addContentButton.Click += new System.EventHandler(this.addContentButton_Click);
			// 
			// organismComboBox
			// 
			this.organismComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.organismComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.organismComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.organismComboBox.FormattingEnabled = true;
			this.organismComboBox.Location = new System.Drawing.Point(6, 19);
			this.organismComboBox.MaxDropDownItems = 15;
			this.organismComboBox.Name = "organismComboBox";
			this.organismComboBox.Size = new System.Drawing.Size(201, 21);
			this.organismComboBox.TabIndex = 1;
			this.organismComboBox.SelectedIndexChanged += new System.EventHandler(this.organismComboBox_SelectedIndexChanged);
			// 
			// contentsListBox
			// 
			this.contentsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contentsListBox.Location = new System.Drawing.Point(6, 71);
			this.contentsListBox.Name = "contentsListBox";
			this.contentsListBox.Size = new System.Drawing.Size(282, 303);
			this.contentsListBox.TabIndex = 0;
			this.contentsListBox.SelectedIndexChanged += new System.EventHandler(this.contentsListBox_SelectedIndexChanged);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(657, 24);
			this.menuStrip.TabIndex = 3;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveAsScreenSaverToolStripMenuItem,
            this.portableDeviceToolStripMenuItem,
            this.takeQuizToolStripMenuItem,
            this.idWizardToolStripMenuItem,
            this.toolStripMenuItem4,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.newToolStripMenuItem.Text = "&New...";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Copy;
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// copyToClipboardToolStripMenuItem
			// 
			this.copyToClipboardToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Clipboard;
			this.copyToClipboardToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
			this.copyToClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.copyToClipboardToolStripMenuItem.Text = "Copy to Clip&board";
			this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.PrintPreview;
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
			this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Print1;
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.printToolStripMenuItem.Text = "&Print...";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(232, 6);
			// 
			// saveAsScreenSaverToolStripMenuItem
			// 
			this.saveAsScreenSaverToolStripMenuItem.Name = "saveAsScreenSaverToolStripMenuItem";
			this.saveAsScreenSaverToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.saveAsScreenSaverToolStripMenuItem.Text = "&Save As Screen Saver...";
			this.saveAsScreenSaverToolStripMenuItem.Click += new System.EventHandler(this.saveAsScreenSaverToolStripMenuItem_Click);
			// 
			// portableDeviceToolStripMenuItem
			// 
			this.portableDeviceToolStripMenuItem.Name = "portableDeviceToolStripMenuItem";
			this.portableDeviceToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.portableDeviceToolStripMenuItem.Text = "Prepare for iPod/&MP3 Player...";
			this.portableDeviceToolStripMenuItem.Click += new System.EventHandler(this.portableDeviceToolStripMenuItem_Click);
			// 
			// takeQuizToolStripMenuItem
			// 
			this.takeQuizToolStripMenuItem.Name = "takeQuizToolStripMenuItem";
			this.takeQuizToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.takeQuizToolStripMenuItem.Text = "Take &Quiz...";
			this.takeQuizToolStripMenuItem.Click += new System.EventHandler(this.takeQuizToolStripMenuItem_Click);
			// 
			// idWizardToolStripMenuItem
			// 
			this.idWizardToolStripMenuItem.Name = "idWizardToolStripMenuItem";
			this.idWizardToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.idWizardToolStripMenuItem.Text = "Create New List with ID &Wizard";
			this.idWizardToolStripMenuItem.ToolTipText = "Create new custom list using the ID Wizard";
			this.idWizardToolStripMenuItem.Click += new System.EventHandler(this.idWizardToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(232, 6);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.importToolStripMenuItem.Text = "&Import...";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.exportToolStripMenuItem.Text = "&Export...";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.closeToolStripMenuItem.Text = "C&lose";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoGalleryToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// photoGalleryToolStripMenuItem
			// 
			this.photoGalleryToolStripMenuItem.Name = "photoGalleryToolStripMenuItem";
			this.photoGalleryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.photoGalleryToolStripMenuItem.Text = "Photo Gallery";
			this.photoGalleryToolStripMenuItem.Click += new System.EventHandler(this.photoGalleryToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.copyToolStripButton,
            this.copyToClipboardToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator2,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator1,
            this.alphabeticToolStripButton,
            this.taxonomicToolStripButton,
            this.toolStripSeparator3,
            this.photoGalleryToolStripButton,
            this.takeQuizToolStripButton,
            this.idWizardToolStripButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(657, 25);
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
			this.newToolStripButton.ToolTipText = "New";
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
			this.openToolStripButton.ToolTipText = "Open";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Copy;
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.copyToolStripButton.Text = "Copy";
			this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
			// 
			// copyToClipboardToolStripButton
			// 
			this.copyToClipboardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToClipboardToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Clipboard;
			this.copyToClipboardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToClipboardToolStripButton.Name = "copyToClipboardToolStripButton";
			this.copyToClipboardToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.copyToClipboardToolStripButton.Text = "Copy to Clipboard";
			this.copyToClipboardToolStripButton.Click += new System.EventHandler(this.copyToClipboardToolStripButton_Click);
			// 
			// deleteToolStripButton
			// 
			this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deleteToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripButton.Name = "deleteToolStripButton";
			this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.deleteToolStripButton.Text = "deleteToolStripButton";
			this.deleteToolStripButton.ToolTipText = "Delete the highlighted Custom List";
			this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Print1;
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.printToolStripButton.Text = "printToolStripButton";
			this.printToolStripButton.ToolTipText = "Print";
			this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
			// 
			// printPreviewToolStripButton
			// 
			this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printPreviewToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.PrintPreview;
			this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
			this.printPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.printPreviewToolStripButton.Text = "Print Preview";
			this.printPreviewToolStripButton.Click += new System.EventHandler(this.printPreviewToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// alphabeticToolStripButton
			// 
			this.alphabeticToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.alphabeticToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Sort;
			this.alphabeticToolStripButton.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.alphabeticToolStripButton.Name = "alphabeticToolStripButton";
			this.alphabeticToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.alphabeticToolStripButton.Text = "Sort Contents Alphabetically";
			this.alphabeticToolStripButton.Click += new System.EventHandler(this.alphabeticToolStripButton_Click);
			// 
			// taxonomicToolStripButton
			// 
			this.taxonomicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.taxonomicToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OrgChart;
			this.taxonomicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.taxonomicToolStripButton.Name = "taxonomicToolStripButton";
			this.taxonomicToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.taxonomicToolStripButton.Text = "Sort Contents Taxonomically";
			this.taxonomicToolStripButton.Click += new System.EventHandler(this.taxonomicToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// photoGalleryToolStripButton
			// 
			this.photoGalleryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.photoGalleryToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("photoGalleryToolStripButton.Image")));
			this.photoGalleryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.photoGalleryToolStripButton.Name = "photoGalleryToolStripButton";
			this.photoGalleryToolStripButton.Size = new System.Drawing.Size(82, 22);
			this.photoGalleryToolStripButton.Text = "Photo Gallery";
			this.photoGalleryToolStripButton.Click += new System.EventHandler(this.photoGalleryToolStripButton_Click);
			// 
			// takeQuizToolStripButton
			// 
			this.takeQuizToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.takeQuizToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("takeQuizToolStripButton.Image")));
			this.takeQuizToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.takeQuizToolStripButton.Name = "takeQuizToolStripButton";
			this.takeQuizToolStripButton.Size = new System.Drawing.Size(63, 22);
			this.takeQuizToolStripButton.Text = "Take Quiz";
			this.takeQuizToolStripButton.Click += new System.EventHandler(this.takeQuizToolStripButton_Click);
			// 
			// idWizardToolStripButton
			// 
			this.idWizardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.idWizardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.idWizardToolStripButton.Name = "idWizardToolStripButton";
			this.idWizardToolStripButton.Size = new System.Drawing.Size(172, 22);
			this.idWizardToolStripButton.Text = "Create New List with ID Wizard";
			this.idWizardToolStripButton.ToolTipText = "Create new custom list using the ID Wizard";
			this.idWizardToolStripButton.Click += new System.EventHandler(this.idWizardToolStripButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// CustomListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 446);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip);
			this.helpProvider.SetHelpKeyword(this, "62");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "CustomListForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Custom List Manager";
			this.groupBox1.ResumeLayout(false);
			this.customListContextMenuStrip.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TreeView customListsTreeView;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox contentsListBox;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem photoGalleryToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem saveAsScreenSaverToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ImageList customListImageList;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.ToolStripButton printToolStripButton;
		private System.Windows.Forms.ToolStripButton alphabeticToolStripButton;
		private System.Windows.Forms.ToolStripButton taxonomicToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Button addContentButton;
		private OrganismComboBox organismComboBox;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton photoGalleryToolStripButton;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button removeContentButton;
		private System.Windows.Forms.Button moveDownButton;
		private System.Windows.Forms.Button moveUpButton;
		private System.Windows.Forms.ImageList contentsImageList;
		private System.Windows.Forms.ToolStripMenuItem portableDeviceToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton takeQuizToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem takeQuizToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripButton idWizardToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem idWizardToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip customListContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem copyToClipboardContextMenuToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton copyToClipboardToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
	}
}