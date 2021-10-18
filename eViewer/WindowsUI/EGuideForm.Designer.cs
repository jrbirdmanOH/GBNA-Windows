namespace Thayer.Birding.UI.Windows
{
	partial class EGuideForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Thayer.Birding.Language language1 = new Thayer.Birding.Language();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGuideForm));
			this.organismToolStrip = new System.Windows.Forms.ToolStrip();
			this.organismComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.filtersToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.displayComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.sortOrderComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewBirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewSimilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewRelatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.theBirdersHandbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.vcrToolStrip = new System.Windows.Forms.ToolStrip();
			this.firstBirdToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.previousBirdToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextBirdToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.lastBirdToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolsToolStrip = new System.Windows.Forms.ToolStrip();
			this.zoomToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.compareToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.moreInfoToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.viewToolStrip = new System.Windows.Forms.ToolStrip();
			this.viewBirdToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.viewSimilarToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.viewRelatedToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.eGuide = new Thayer.Birding.UI.EGuide();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.organismToolStrip.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.vcrToolStrip.SuspendLayout();
			this.toolsToolStrip.SuspendLayout();
			this.viewToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// organismToolStrip
			// 
			this.organismToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.organismToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.organismToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.organismComboBox,
			this.filtersToolStripButton,
			this.displayComboBox,
			this.sortOrderComboBox});
			this.organismToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.organismToolStrip.Location = new System.Drawing.Point(3, 0);
			this.organismToolStrip.Name = "organismToolStrip";
			this.organismToolStrip.Size = new System.Drawing.Size(561, 25);
			this.organismToolStrip.TabIndex = 0;
			this.organismToolStrip.Text = "toolStrip1";
			// 
			// organismComboBox
			// 
			this.organismComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.organismComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.organismComboBox.Name = "organismComboBox";
			this.organismComboBox.Size = new System.Drawing.Size(255, 25);
			this.organismComboBox.ToolTipText = "Bird List";
			this.organismComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.organismComboBox_KeyDown);
			this.organismComboBox.LostFocus += new System.EventHandler(this.organismComboBox_LostFocus);
			this.organismComboBox.SelectedIndexChanged += new System.EventHandler(this.organismComboBox_SelectedIndexChanged);
			// 
			// filtersToolStripButton
			// 
			this.filtersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.filtersToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.FilterOff;
			this.filtersToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.filtersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.filtersToolStripButton.Name = "filtersToolStripButton";
			this.filtersToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.filtersToolStripButton.Text = "Filters";
			this.filtersToolStripButton.Click += new System.EventHandler(this.filtersToolStripButton_Click);
			// 
			// displayComboBox
			// 
			this.displayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.displayComboBox.Name = "displayComboBox";
			this.displayComboBox.Size = new System.Drawing.Size(185, 25);
			this.displayComboBox.ToolTipText = "Display Name Type";
			this.displayComboBox.SelectedIndexChanged += new System.EventHandler(this.displayComboBox_SelectedIndexChanged);
			// 
			// sortOrderComboBox
			// 
			this.sortOrderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sortOrderComboBox.Name = "sortOrderComboBox";
			this.sortOrderComboBox.Size = new System.Drawing.Size(115, 25);
			this.sortOrderComboBox.ToolTipText = "Sort Order";
			this.sortOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.sortOrderComboBox_SelectedIndexChanged);
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser.Location = new System.Drawing.Point(0, 0);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(768, 402);
			this.webBrowser.TabIndex = 0;
			this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
			this.webBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.webBrowser);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.menuStrip);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(768, 402);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(768, 466);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.vcrToolStrip);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolsToolStrip);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.viewToolStrip);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.organismToolStrip);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.viewToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(768, 24);
			this.menuStrip.TabIndex = 5;
			this.menuStrip.Text = "menuStrip1";
			this.menuStrip.Visible = false;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.closeToolStripMenuItem,
			this.printToolStripMenuItem});
			this.fileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.printToolStripMenuItem.Text = "&Print...";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.viewBirdToolStripMenuItem,
			this.viewSimilarToolStripMenuItem,
			this.viewRelatedToolStripMenuItem,
			this.toolStripMenuItem1,
			this.zoomToolStripMenuItem,
			this.compareToolStripMenuItem,
			this.toolStripMenuItem2,
			this.filtersToolStripMenuItem,
			this.toolStripMenuItem3,
			this.theBirdersHandbookToolStripMenuItem,
			this.toolStripMenuItem4});
			this.viewToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// viewBirdToolStripMenuItem
			// 
			this.viewBirdToolStripMenuItem.Checked = true;
			this.viewBirdToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewBirdToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.viewBirdToolStripMenuItem.MergeIndex = 0;
			this.viewBirdToolStripMenuItem.Name = "viewBirdToolStripMenuItem";
			this.viewBirdToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.viewBirdToolStripMenuItem.Text = "View &Bird";
			this.viewBirdToolStripMenuItem.Click += new System.EventHandler(this.viewBirdToolStripMenuItem_Click);
			// 
			// viewSimilarToolStripMenuItem
			// 
			this.viewSimilarToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.viewSimilarToolStripMenuItem.MergeIndex = 1;
			this.viewSimilarToolStripMenuItem.Name = "viewSimilarToolStripMenuItem";
			this.viewSimilarToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.viewSimilarToolStripMenuItem.Text = "View &Similar";
			this.viewSimilarToolStripMenuItem.Click += new System.EventHandler(this.viewSimilarToolStripMenuItem_Click);
			// 
			// viewRelatedToolStripMenuItem
			// 
			this.viewRelatedToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.viewRelatedToolStripMenuItem.MergeIndex = 2;
			this.viewRelatedToolStripMenuItem.Name = "viewRelatedToolStripMenuItem";
			this.viewRelatedToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.viewRelatedToolStripMenuItem.Text = "View &Related";
			this.viewRelatedToolStripMenuItem.Click += new System.EventHandler(this.viewRelatedToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.toolStripMenuItem1.MergeIndex = 3;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
			// 
			// zoomToolStripMenuItem
			// 
			this.zoomToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.zoomToolStripMenuItem.MergeIndex = 4;
			this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
			this.zoomToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.zoomToolStripMenuItem.Text = "&Zoom";
			this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// compareToolStripMenuItem
			// 
			this.compareToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.compareToolStripMenuItem.MergeIndex = 5;
			this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
			this.compareToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.compareToolStripMenuItem.Text = "&Compare";
			this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.toolStripMenuItem2.MergeIndex = 6;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
			// 
			// filtersToolStripMenuItem
			// 
			this.filtersToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.filtersToolStripMenuItem.MergeIndex = 7;
			this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
			this.filtersToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.filtersToolStripMenuItem.Text = "&Filters...";
			this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.toolStripMenuItem3.MergeIndex = 8;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 6);
			// 
			// theBirdersHandbookToolStripMenuItem
			// 
			this.theBirdersHandbookToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
			this.theBirdersHandbookToolStripMenuItem.MergeIndex = 9;
			this.theBirdersHandbookToolStripMenuItem.Name = "theBirdersHandbookToolStripMenuItem";
			this.theBirdersHandbookToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.theBirdersHandbookToolStripMenuItem.Text = "The Birder\'s &Handbook";
			this.theBirdersHandbookToolStripMenuItem.Click += new System.EventHandler(this.theBirdersHandbookToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.MergeAction = System.Windows.Forms.MergeAction.Replace;
			this.toolStripMenuItem4.MergeIndex = 11;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(192, 6);
			// 
			// vcrToolStrip
			// 
			this.vcrToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.vcrToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.firstBirdToolStripButton,
			this.previousBirdToolStripButton,
			this.nextBirdToolStripButton,
			this.lastBirdToolStripButton});
			this.vcrToolStrip.Location = new System.Drawing.Point(599, 0);
			this.vcrToolStrip.Name = "vcrToolStrip";
			this.vcrToolStrip.Size = new System.Drawing.Size(104, 25);
			this.vcrToolStrip.TabIndex = 1;
			// 
			// firstBirdToolStripButton
			// 
			this.firstBirdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.firstBirdToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.DataContainer_MoveFirstHS;
			this.firstBirdToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.firstBirdToolStripButton.Name = "firstBirdToolStripButton";
			this.firstBirdToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.firstBirdToolStripButton.Text = "toolStripButton1";
			this.firstBirdToolStripButton.ToolTipText = "First";
			this.firstBirdToolStripButton.Click += new System.EventHandler(this.firstBirdToolStripButton_Click);
			// 
			// previousBirdToolStripButton
			// 
			this.previousBirdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.previousBirdToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.DataContainer_MovePreviousHS;
			this.previousBirdToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.previousBirdToolStripButton.Name = "previousBirdToolStripButton";
			this.previousBirdToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.previousBirdToolStripButton.Text = "toolStripButton2";
			this.previousBirdToolStripButton.ToolTipText = "Previous";
			this.previousBirdToolStripButton.Click += new System.EventHandler(this.previousBirdToolStripButton_Click);
			// 
			// nextBirdToolStripButton
			// 
			this.nextBirdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nextBirdToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.DataContainer_MoveNextHS;
			this.nextBirdToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.nextBirdToolStripButton.Name = "nextBirdToolStripButton";
			this.nextBirdToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.nextBirdToolStripButton.Text = "toolStripButton3";
			this.nextBirdToolStripButton.ToolTipText = "Next";
			this.nextBirdToolStripButton.Click += new System.EventHandler(this.nextBirdToolStripButton_Click);
			// 
			// lastBirdToolStripButton
			// 
			this.lastBirdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.lastBirdToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.DataContainer_MoveLastHS;
			this.lastBirdToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.lastBirdToolStripButton.Name = "lastBirdToolStripButton";
			this.lastBirdToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.lastBirdToolStripButton.Text = "toolStripButton4";
			this.lastBirdToolStripButton.ToolTipText = "Last";
			this.lastBirdToolStripButton.Click += new System.EventHandler(this.lastBirdToolStripButton_Click);
			// 
			// toolsToolStrip
			// 
			this.toolsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.toolsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.zoomToolStripButton,
			this.compareToolStripButton,
			this.moreInfoToolStripButton,
			this.printToolStripButton});
			this.toolsToolStrip.Location = new System.Drawing.Point(3, 25);
			this.toolsToolStrip.Name = "toolsToolStrip";
			this.toolsToolStrip.Size = new System.Drawing.Size(156, 39);
			this.toolsToolStrip.TabIndex = 2;
			// 
			// zoomToolStripButton
			// 
			this.zoomToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.zoomToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Zoom;
			this.zoomToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.zoomToolStripButton.Name = "zoomToolStripButton";
			this.zoomToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.zoomToolStripButton.Text = "Zoom";
			this.zoomToolStripButton.Click += new System.EventHandler(this.zoomToolStripButton_Click);
			// 
			// compareToolStripButton
			// 
			this.compareToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.compareToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.SideBySide;
			this.compareToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.compareToolStripButton.Name = "compareToolStripButton";
			this.compareToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.compareToolStripButton.Text = "Compare";
			this.compareToolStripButton.Click += new System.EventHandler(this.compareToolStripButton_Click);
			// 
			// moreInfoToolStripButton
			// 
			this.moreInfoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.moreInfoToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.BirdersHandbook;
			this.moreInfoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.moreInfoToolStripButton.Name = "moreInfoToolStripButton";
			this.moreInfoToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.moreInfoToolStripButton.Text = "The Birder\'s Handbook";
			this.moreInfoToolStripButton.Click += new System.EventHandler(this.moreInfoToolStripButton_Click);
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Print;
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.printToolStripButton.Text = "Print";
			this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
			// 
			// viewToolStrip
			// 
			this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.viewToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.viewBirdToolStripButton,
			this.viewSimilarToolStripButton,
			this.viewRelatedToolStripButton});
			this.viewToolStrip.Location = new System.Drawing.Point(159, 25);
			this.viewToolStrip.Name = "viewToolStrip";
			this.viewToolStrip.Size = new System.Drawing.Size(151, 39);
			this.viewToolStrip.TabIndex = 3;
			// 
			// viewBirdToolStripButton
			// 
			this.viewBirdToolStripButton.Checked = true;
			this.viewBirdToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewBirdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.viewBirdToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.ViewBird;
			this.viewBirdToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.viewBirdToolStripButton.Name = "viewBirdToolStripButton";
			this.viewBirdToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.viewBirdToolStripButton.Text = "View Bird";
			this.viewBirdToolStripButton.Click += new System.EventHandler(this.viewBirdToolStripButton_Click);
			// 
			// viewSimilarToolStripButton
			// 
			this.viewSimilarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.viewSimilarToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Similar;
			this.viewSimilarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.viewSimilarToolStripButton.Name = "viewSimilarToolStripButton";
			this.viewSimilarToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.viewSimilarToolStripButton.Text = "View Similar";
			this.viewSimilarToolStripButton.Click += new System.EventHandler(this.viewSimilarToolStripButton_Click);
			// 
			// viewRelatedToolStripButton
			// 
			this.viewRelatedToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.viewRelatedToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Related;
			this.viewRelatedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.viewRelatedToolStripButton.Name = "viewRelatedToolStripButton";
			this.viewRelatedToolStripButton.Size = new System.Drawing.Size(36, 36);
			this.viewRelatedToolStripButton.Text = "View Related";
			this.viewRelatedToolStripButton.Click += new System.EventHandler(this.viewRelatedToolStripButton_Click);
			// 
			// eGuide
			// 
			this.eGuide.Collection = null;
			language1.ID = 0;
			language1.Name = "English";
			this.eGuide.Language = language1;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// EGuideForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 466);
			this.Controls.Add(this.toolStripContainer1);
			this.helpProvider.SetHelpKeyword(this, "14");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "EGuideForm";
			this.helpProvider.SetShowHelp(this, true);
			this.Text = "GBNA - Guide to ";
			this.organismToolStrip.ResumeLayout(false);
			this.organismToolStrip.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.vcrToolStrip.ResumeLayout(false);
			this.vcrToolStrip.PerformLayout();
			this.toolsToolStrip.ResumeLayout(false);
			this.toolsToolStrip.PerformLayout();
			this.viewToolStrip.ResumeLayout(false);
			this.viewToolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private EGuide eGuide;
		private System.Windows.Forms.ToolStrip organismToolStrip;
		private System.Windows.Forms.ToolStripComboBox organismComboBox;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.ToolStripComboBox sortOrderComboBox;
		private System.Windows.Forms.ToolStripComboBox displayComboBox;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolsToolStrip;
		private System.Windows.Forms.ToolStripButton zoomToolStripButton;
		private System.Windows.Forms.ToolStripButton compareToolStripButton;
		private System.Windows.Forms.ToolStripButton moreInfoToolStripButton;
		private System.Windows.Forms.ToolStripButton printToolStripButton;
		private System.Windows.Forms.ToolStrip viewToolStrip;
		private System.Windows.Forms.ToolStripButton viewBirdToolStripButton;
		private System.Windows.Forms.ToolStripButton viewSimilarToolStripButton;
		private System.Windows.Forms.ToolStripButton viewRelatedToolStripButton;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStrip vcrToolStrip;
		private System.Windows.Forms.ToolStripButton firstBirdToolStripButton;
		private System.Windows.Forms.ToolStripButton previousBirdToolStripButton;
		private System.Windows.Forms.ToolStripButton nextBirdToolStripButton;
		private System.Windows.Forms.ToolStripButton lastBirdToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem theBirdersHandbookToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem viewBirdToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewSimilarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewRelatedToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripButton filtersToolStripButton;
	}
}

