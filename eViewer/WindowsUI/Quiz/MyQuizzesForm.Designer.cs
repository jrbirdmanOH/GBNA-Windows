namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizzesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyQuizzesForm));
            this.quizTreeView = new System.Windows.Forms.TreeView();
            this.treeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCategoryContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuizContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMyMediaPackageContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewCompareContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.quickStartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMyMediaPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newCategoryDropDownButtonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuizDropDownButtonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.importMyMediaPackageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewCompareToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quickStartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.closeButton = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.treeViewContextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // quizTreeView
            // 
            this.quizTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quizTreeView.ContextMenuStrip = this.treeViewContextMenuStrip;
            this.quizTreeView.HideSelection = false;
            this.quizTreeView.ImageIndex = 0;
            this.quizTreeView.ImageList = this.treeViewImageList;
            this.quizTreeView.Location = new System.Drawing.Point(0, 49);
            this.quizTreeView.Name = "quizTreeView";
            this.quizTreeView.SelectedImageIndex = 0;
            this.quizTreeView.Size = new System.Drawing.Size(590, 327);
            this.quizTreeView.TabIndex = 2;
            this.quizTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.quizTreeView_AfterSelect);
            this.quizTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.quizTreeView_NodeMouseClick);
            // 
            // treeViewContextMenuStrip
            // 
            this.treeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newContextMenuItem,
            this.editContextMenuItem,
            this.deleteContextMenuItem,
            this.importMyMediaPackageContextMenuItem,
            this.toolStripSeparator3,
            this.viewCompareContextMenuItem,
            this.toolStripSeparator5,
            this.quickStartContextMenuItem});
            this.treeViewContextMenuStrip.Name = "categoryContextMenuStrip";
            this.treeViewContextMenuStrip.Size = new System.Drawing.Size(223, 170);
            // 
            // newContextMenuItem
            // 
            this.newContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCategoryContextMenuItem,
            this.newQuizContextMenuItem});
            this.newContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
            this.newContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newContextMenuItem.Name = "newContextMenuItem";
            this.newContextMenuItem.Size = new System.Drawing.Size(222, 22);
            this.newContextMenuItem.Text = "&New";
            this.newContextMenuItem.Click += new System.EventHandler(this.newCategoryToolStripMenuItem_Click);
            // 
            // newCategoryContextMenuItem
            // 
            this.newCategoryContextMenuItem.Name = "newCategoryContextMenuItem";
            this.newCategoryContextMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newCategoryContextMenuItem.Text = "&Category";
            this.newCategoryContextMenuItem.Click += new System.EventHandler(this.newCategoryContextMenuItem_Click);
            // 
            // newQuizContextMenuItem
            // 
            this.newQuizContextMenuItem.Name = "newQuizContextMenuItem";
            this.newQuizContextMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newQuizContextMenuItem.Text = "&Quiz";
            this.newQuizContextMenuItem.Click += new System.EventHandler(this.newQuizContextMenuItem_Click);
            // 
            // editContextMenuItem
            // 
            this.editContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
            this.editContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editContextMenuItem.Name = "editContextMenuItem";
            this.editContextMenuItem.Size = new System.Drawing.Size(222, 22);
            this.editContextMenuItem.Text = "&Edit";
            this.editContextMenuItem.Click += new System.EventHandler(this.editContextMenuItem_Click);
            // 
            // deleteContextMenuItem
            // 
            this.deleteContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
            this.deleteContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteContextMenuItem.Name = "deleteContextMenuItem";
            this.deleteContextMenuItem.Size = new System.Drawing.Size(222, 22);
            this.deleteContextMenuItem.Text = "&Delete";
            this.deleteContextMenuItem.Click += new System.EventHandler(this.deleteContextMenuItem_Click);
            // 
            // importMyMediaPackageContextMenuItem
            // 
            this.importMyMediaPackageContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Import;
            this.importMyMediaPackageContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importMyMediaPackageContextMenuItem.Name = "importMyMediaPackageContextMenuItem";
            this.importMyMediaPackageContextMenuItem.Size = new System.Drawing.Size(222, 22);
            this.importMyMediaPackageContextMenuItem.Text = "Import My &Media Package...";
            this.importMyMediaPackageContextMenuItem.Click += new System.EventHandler(this.importMyMediaPackageContextMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
            // 
            // viewCompareContextMenuItem
            // 
            this.viewCompareContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Compare;
            this.viewCompareContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewCompareContextMenuItem.Name = "viewCompareContextMenuItem";
            this.viewCompareContextMenuItem.Size = new System.Drawing.Size(222, 22);
            this.viewCompareContextMenuItem.Text = "&Compare";
            this.viewCompareContextMenuItem.Click += new System.EventHandler(this.viewCompareContextMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(219, 6);
            // 
            // quickStartContextMenuItem
            // 
            this.quickStartContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Help;
            this.quickStartContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quickStartContextMenuItem.Name = "quickStartContextMenuItem";
            this.quickStartContextMenuItem.Size = new System.Drawing.Size(222, 22);
            this.quickStartContextMenuItem.Text = "&Quick Start";
            this.quickStartContextMenuItem.Click += new System.EventHandler(this.quickStartContextMenuItem_Click);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.treeViewImageList.Images.SetKeyName(0, "CustomQuizCategory.bmp");
            this.treeViewImageList.Images.SetKeyName(1, "CustomQuiz.bmp");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(590, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.importMyMediaPackageToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCategoryToolStripMenuItem,
            this.newQuizToolStripMenuItem});
            this.newToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // newCategoryToolStripMenuItem
            // 
            this.newCategoryToolStripMenuItem.Name = "newCategoryToolStripMenuItem";
            this.newCategoryToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newCategoryToolStripMenuItem.Text = "&Category";
            this.newCategoryToolStripMenuItem.Click += new System.EventHandler(this.newCategoryToolStripMenuItem_Click);
            // 
            // newQuizToolStripMenuItem
            // 
            this.newQuizToolStripMenuItem.Name = "newQuizToolStripMenuItem";
            this.newQuizToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newQuizToolStripMenuItem.Text = "&Quiz";
            this.newQuizToolStripMenuItem.Click += new System.EventHandler(this.newQuizToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
            this.editToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
            this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // importMyMediaPackageToolStripMenuItem
            // 
            this.importMyMediaPackageToolStripMenuItem.Name = "importMyMediaPackageToolStripMenuItem";
            this.importMyMediaPackageToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.importMyMediaPackageToolStripMenuItem.Text = "Import My &Media Package...";
            this.importMyMediaPackageToolStripMenuItem.Click += new System.EventHandler(this.importMyMediaPackageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Compare;
            this.compareToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.compareToolStripMenuItem.Text = "&Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickStartToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // quickStartToolStripMenuItem
            // 
            this.quickStartToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Help;
            this.quickStartToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quickStartToolStripMenuItem.Name = "quickStartToolStripMenuItem";
            this.quickStartToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.quickStartToolStripMenuItem.Text = "&Quick Start";
            this.quickStartToolStripMenuItem.Click += new System.EventHandler(this.quickStartToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripDropDownButton,
            this.editToolStripButton,
            this.deleteToolStripButton,
            this.importMyMediaPackageToolStripButton,
            this.toolStripSeparator2,
            this.viewCompareToolStripButton,
            this.toolStripSeparator4,
            this.quickStartToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(590, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolStripDropDownButton
            // 
            this.newToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCategoryDropDownButtonMenuItem,
            this.newQuizDropDownButtonMenuItem});
            this.newToolStripDropDownButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
            this.newToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripDropDownButton.Name = "newToolStripDropDownButton";
            this.newToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.newToolStripDropDownButton.Text = "New";
            this.newToolStripDropDownButton.ToolTipText = "New";
            // 
            // newCategoryDropDownButtonMenuItem
            // 
            this.newCategoryDropDownButtonMenuItem.Name = "newCategoryDropDownButtonMenuItem";
            this.newCategoryDropDownButtonMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newCategoryDropDownButtonMenuItem.Text = "New &Category";
            this.newCategoryDropDownButtonMenuItem.Click += new System.EventHandler(this.newCategoryDropDownButtonMenuItem_Click);
            // 
            // newQuizDropDownButtonMenuItem
            // 
            this.newQuizDropDownButtonMenuItem.Name = "newQuizDropDownButtonMenuItem";
            this.newQuizDropDownButtonMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newQuizDropDownButtonMenuItem.Text = "New &Quiz";
            this.newQuizDropDownButtonMenuItem.Click += new System.EventHandler(this.newQuizDropDownButtonMenuItem_Click);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "Edit";
            this.editToolStripButton.ToolTipText = "Edit";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.ToolTipText = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // importMyMediaPackageToolStripButton
            // 
            this.importMyMediaPackageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importMyMediaPackageToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Import;
            this.importMyMediaPackageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importMyMediaPackageToolStripButton.Name = "importMyMediaPackageToolStripButton";
            this.importMyMediaPackageToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.importMyMediaPackageToolStripButton.Text = "Import My Media Package";
            this.importMyMediaPackageToolStripButton.Click += new System.EventHandler(this.importMyMediaPackageToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // viewCompareToolStripButton
            // 
            this.viewCompareToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewCompareToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Compare;
            this.viewCompareToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewCompareToolStripButton.Name = "viewCompareToolStripButton";
            this.viewCompareToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.viewCompareToolStripButton.Text = "View Categories";
            this.viewCompareToolStripButton.ToolTipText = "Compare";
            this.viewCompareToolStripButton.Click += new System.EventHandler(this.viewCompareToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // quickStartToolStripButton
            // 
            this.quickStartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quickStartToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Help;
            this.quickStartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quickStartToolStripButton.Name = "quickStartToolStripButton";
            this.quickStartToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.quickStartToolStripButton.Text = "toolStripButton1";
            this.quickStartToolStripButton.ToolTipText = "Show Quick Start";
            this.quickStartToolStripButton.Click += new System.EventHandler(this.quickStartToolStripButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(258, 389);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "eViewer.chm";
            // 
            // MyQuizzesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(590, 424);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.quizTreeView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.helpProvider.SetHelpKeyword(this, "36");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MyQuizzesForm";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage My Quizzes";
            this.Shown += new System.EventHandler(this.MyQuizzesForm_Shown);
            this.treeViewContextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView quizTreeView;
		private System.Windows.Forms.ContextMenuStrip treeViewContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem newContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteContextMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newCategoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newQuizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripDropDownButton newToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem newCategoryDropDownButtonMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newQuizDropDownButtonMenuItem;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton viewCompareToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem newCategoryContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newQuizContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem viewCompareContextMenuItem;
		private System.Windows.Forms.ImageList treeViewImageList;
		private System.Windows.Forms.ToolStripButton quickStartToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem quickStartContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quickStartToolStripMenuItem;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.ToolStripMenuItem importMyMediaPackageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importMyMediaPackageContextMenuItem;
		private System.Windows.Forms.ToolStripButton importMyMediaPackageToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
	}
}