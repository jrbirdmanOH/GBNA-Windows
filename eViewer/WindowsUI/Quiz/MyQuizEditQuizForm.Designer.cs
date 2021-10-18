namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class MyQuizEditQuizForm
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
			this.categoryLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.authorLabel = new System.Windows.Forms.Label();
			this.authorTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.categoryNameLabel = new System.Windows.Forms.Label();
			this.questionsGroupBox = new System.Windows.Forms.GroupBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.removeAllItemsButton = new System.Windows.Forms.Button();
			this.removeItemButton = new System.Windows.Forms.Button();
			this.addItemButton = new System.Windows.Forms.Button();
			this.addAllItemsButton = new System.Windows.Forms.Button();
			this.questionsLabel = new System.Windows.Forms.Label();
			this.questionsListView = new System.Windows.Forms.ListView();
			this.nameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.alternateNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.questionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageCategoryItemsButton = new System.Windows.Forms.Button();
			this.categoryItemsLabel = new System.Windows.Forms.Label();
			this.categoryItemsListView = new System.Windows.Forms.ListView();
			this.itemNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.itemAlternateNameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.categoryItemsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			label1 = new System.Windows.Forms.Label();
			this.questionsGroupBox.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.questionsContextMenuStrip.SuspendLayout();
			this.categoryItemsContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			label1.Location = new System.Drawing.Point(14, 27);
			label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(793, 30);
			label1.TabIndex = 0;
			label1.Text = "Questions are added to a quiz by selecting from the available category items.  Ca" +
				"tegory items also serve as a common group of items that are randomly used as inc" +
				"orrect answers when generating quizzes.";
			// 
			// categoryLabel
			// 
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.Location = new System.Drawing.Point(12, 15);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(52, 13);
			this.categoryLabel.TabIndex = 0;
			this.categoryLabel.Text = "Category:";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(12, 42);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(62, 13);
			this.nameLabel.TabIndex = 2;
			this.nameLabel.Text = "Quiz Name:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(80, 39);
			this.nameTextBox.MaxLength = 100;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(318, 20);
			this.nameTextBox.TabIndex = 3;
			// 
			// authorLabel
			// 
			this.authorLabel.AutoSize = true;
			this.authorLabel.Location = new System.Drawing.Point(12, 68);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(41, 13);
			this.authorLabel.TabIndex = 4;
			this.authorLabel.Text = "Author:";
			// 
			// authorTextBox
			// 
			this.authorTextBox.Location = new System.Drawing.Point(80, 65);
			this.authorTextBox.MaxLength = 50;
			this.authorTextBox.Name = "authorTextBox";
			this.authorTextBox.Size = new System.Drawing.Size(318, 20);
			this.authorTextBox.TabIndex = 5;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(425, 410);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(344, 410);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// categoryNameLabel
			// 
			this.categoryNameLabel.AutoSize = true;
			this.categoryNameLabel.Location = new System.Drawing.Point(80, 15);
			this.categoryNameLabel.Name = "categoryNameLabel";
			this.categoryNameLabel.Size = new System.Drawing.Size(80, 13);
			this.categoryNameLabel.TabIndex = 1;
			this.categoryNameLabel.Text = "Category Name";
			// 
			// questionsGroupBox
			// 
			this.questionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.questionsGroupBox.Controls.Add(label1);
			this.questionsGroupBox.Controls.Add(this.splitContainer);
			this.questionsGroupBox.Location = new System.Drawing.Point(12, 102);
			this.questionsGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.questionsGroupBox.Name = "questionsGroupBox";
			this.questionsGroupBox.Padding = new System.Windows.Forms.Padding(0);
			this.questionsGroupBox.Size = new System.Drawing.Size(822, 299);
			this.questionsGroupBox.TabIndex = 6;
			this.questionsGroupBox.TabStop = false;
			this.questionsGroupBox.Text = "Quiz Questions";
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(3, 54);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.removeAllItemsButton);
			this.splitContainer.Panel1.Controls.Add(this.removeItemButton);
			this.splitContainer.Panel1.Controls.Add(this.addItemButton);
			this.splitContainer.Panel1.Controls.Add(this.addAllItemsButton);
			this.splitContainer.Panel1.Controls.Add(this.questionsLabel);
			this.splitContainer.Panel1.Controls.Add(this.questionsListView);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.manageCategoryItemsButton);
			this.splitContainer.Panel2.Controls.Add(this.categoryItemsLabel);
			this.splitContainer.Panel2.Controls.Add(this.categoryItemsListView);
			this.splitContainer.Size = new System.Drawing.Size(816, 240);
			this.splitContainer.SplitterDistance = 426;
			this.splitContainer.TabIndex = 1;
			// 
			// removeAllItemsButton
			// 
			this.removeAllItemsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.removeAllItemsButton.Location = new System.Drawing.Point(390, 172);
			this.removeAllItemsButton.Name = "removeAllItemsButton";
			this.removeAllItemsButton.Size = new System.Drawing.Size(35, 23);
			this.removeAllItemsButton.TabIndex = 5;
			this.removeAllItemsButton.Text = ">>";
			this.toolTip.SetToolTip(this.removeAllItemsButton, "Remove all questions");
			this.removeAllItemsButton.UseVisualStyleBackColor = true;
			this.removeAllItemsButton.Click += new System.EventHandler(this.removeAllItemsButton_Click);
			// 
			// removeItemButton
			// 
			this.removeItemButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.removeItemButton.Location = new System.Drawing.Point(390, 143);
			this.removeItemButton.Name = "removeItemButton";
			this.removeItemButton.Size = new System.Drawing.Size(35, 23);
			this.removeItemButton.TabIndex = 4;
			this.removeItemButton.Text = ">";
			this.toolTip.SetToolTip(this.removeItemButton, "Remove selected questions");
			this.removeItemButton.UseVisualStyleBackColor = true;
			this.removeItemButton.Click += new System.EventHandler(this.removeItemButton_Click);
			// 
			// addItemButton
			// 
			this.addItemButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.addItemButton.Location = new System.Drawing.Point(391, 88);
			this.addItemButton.Name = "addItemButton";
			this.addItemButton.Size = new System.Drawing.Size(34, 23);
			this.addItemButton.TabIndex = 3;
			this.addItemButton.Text = "<";
			this.toolTip.SetToolTip(this.addItemButton, "Add selected category items");
			this.addItemButton.UseVisualStyleBackColor = true;
			this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
			// 
			// addAllItemsButton
			// 
			this.addAllItemsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.addAllItemsButton.Location = new System.Drawing.Point(390, 59);
			this.addAllItemsButton.Name = "addAllItemsButton";
			this.addAllItemsButton.Size = new System.Drawing.Size(35, 23);
			this.addAllItemsButton.TabIndex = 2;
			this.addAllItemsButton.Text = "<<";
			this.toolTip.SetToolTip(this.addAllItemsButton, "Add all available category items");
			this.addAllItemsButton.UseVisualStyleBackColor = true;
			this.addAllItemsButton.Click += new System.EventHandler(this.addAllItemsButton_Click);
			// 
			// questionsLabel
			// 
			this.questionsLabel.AutoSize = true;
			this.questionsLabel.Location = new System.Drawing.Point(10, 10);
			this.questionsLabel.Name = "questionsLabel";
			this.questionsLabel.Size = new System.Drawing.Size(57, 13);
			this.questionsLabel.TabIndex = 0;
			this.questionsLabel.Text = "Questions:";
			// 
			// questionsListView
			// 
			this.questionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.questionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.alternateNameColumnHeader});
			this.questionsListView.ContextMenuStrip = this.questionsContextMenuStrip;
			this.questionsListView.FullRowSelect = true;
			this.questionsListView.HideSelection = false;
			this.questionsListView.Location = new System.Drawing.Point(10, 26);
			this.questionsListView.Name = "questionsListView";
			this.questionsListView.Size = new System.Drawing.Size(373, 178);
			this.questionsListView.TabIndex = 1;
			this.questionsListView.UseCompatibleStateImageBehavior = false;
			this.questionsListView.View = System.Windows.Forms.View.Details;
			this.questionsListView.DoubleClick += new System.EventHandler(this.questionsListView_DoubleClick);
			this.questionsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.questionsListView_ColumnClick);
			this.questionsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.questionsListView_ItemSelectionChanged);
			this.questionsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.questionsListView_KeyDown);
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Name";
			this.nameColumnHeader.Width = 186;
			// 
			// alternateNameColumnHeader
			// 
			this.alternateNameColumnHeader.Text = "Alternate Name";
			this.alternateNameColumnHeader.Width = 175;
			// 
			// questionsContextMenuStrip
			// 
			this.questionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem,
            this.removeAllToolStripMenuItem});
			this.questionsContextMenuStrip.Name = "questionsContextMenuStrip";
			this.questionsContextMenuStrip.Size = new System.Drawing.Size(165, 48);
			// 
			// removeSelectedToolStripMenuItem
			// 
			this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
			this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.removeSelectedToolStripMenuItem.Text = "Remove &Selected";
			this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
			// 
			// removeAllToolStripMenuItem
			// 
			this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
			this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.removeAllToolStripMenuItem.Text = "Remove &All";
			this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
			// 
			// manageCategoryItemsButton
			// 
			this.manageCategoryItemsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.manageCategoryItemsButton.Location = new System.Drawing.Point(113, 210);
			this.manageCategoryItemsButton.Name = "manageCategoryItemsButton";
			this.manageCategoryItemsButton.Size = new System.Drawing.Size(156, 23);
			this.manageCategoryItemsButton.TabIndex = 2;
			this.manageCategoryItemsButton.Text = "Manage Category Items...";
			this.manageCategoryItemsButton.UseVisualStyleBackColor = true;
			this.manageCategoryItemsButton.Click += new System.EventHandler(this.manageCategoryItemsButton_Click);
			// 
			// categoryItemsLabel
			// 
			this.categoryItemsLabel.AutoSize = true;
			this.categoryItemsLabel.Location = new System.Drawing.Point(3, 10);
			this.categoryItemsLabel.Name = "categoryItemsLabel";
			this.categoryItemsLabel.Size = new System.Drawing.Size(126, 13);
			this.categoryItemsLabel.TabIndex = 0;
			this.categoryItemsLabel.Text = "Available Category Items:";
			// 
			// categoryItemsListView
			// 
			this.categoryItemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.categoryItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemNameColumnHeader,
            this.itemAlternateNameColumnHeader});
			this.categoryItemsListView.ContextMenuStrip = this.categoryItemsContextMenuStrip;
			this.categoryItemsListView.FullRowSelect = true;
			this.categoryItemsListView.HideSelection = false;
			this.categoryItemsListView.Location = new System.Drawing.Point(3, 26);
			this.categoryItemsListView.Name = "categoryItemsListView";
			this.categoryItemsListView.Size = new System.Drawing.Size(373, 178);
			this.categoryItemsListView.TabIndex = 1;
			this.categoryItemsListView.UseCompatibleStateImageBehavior = false;
			this.categoryItemsListView.View = System.Windows.Forms.View.Details;
			this.categoryItemsListView.DoubleClick += new System.EventHandler(this.categoryItemsListView_DoubleClick);
			this.categoryItemsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.categoryItemsListView_ColumnClick);
			this.categoryItemsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.categoryItemsListView_ItemSelectionChanged);
			this.categoryItemsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoryItemsListView_KeyDown);
			// 
			// itemNameColumnHeader
			// 
			this.itemNameColumnHeader.Text = "Name";
			this.itemNameColumnHeader.Width = 182;
			// 
			// itemAlternateNameColumnHeader
			// 
			this.itemAlternateNameColumnHeader.Text = "Alternate Name";
			this.itemAlternateNameColumnHeader.Width = 176;
			// 
			// categoryItemsContextMenuStrip
			// 
			this.categoryItemsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSelectedToolStripMenuItem,
            this.addAllToolStripMenuItem});
			this.categoryItemsContextMenuStrip.Name = "categoryItemsContextMenuStrip";
			this.categoryItemsContextMenuStrip.Size = new System.Drawing.Size(144, 48);
			// 
			// addSelectedToolStripMenuItem
			// 
			this.addSelectedToolStripMenuItem.Name = "addSelectedToolStripMenuItem";
			this.addSelectedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.addSelectedToolStripMenuItem.Text = "Add &Selected";
			this.addSelectedToolStripMenuItem.Click += new System.EventHandler(this.addSelectedToolStripMenuItem_Click);
			// 
			// addAllToolStripMenuItem
			// 
			this.addAllToolStripMenuItem.Name = "addAllToolStripMenuItem";
			this.addAllToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.addAllToolStripMenuItem.Text = "Add &All";
			this.addAllToolStripMenuItem.Click += new System.EventHandler(this.addAllToolStripMenuItem_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyQuizEditQuizForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(844, 445);
			this.Controls.Add(this.questionsGroupBox);
			this.Controls.Add(this.categoryNameLabel);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.authorTextBox);
			this.Controls.Add(this.authorLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.categoryLabel);
			this.Controls.Add(this.nameLabel);
			this.helpProvider.SetHelpKeyword(this, "32");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "MyQuizEditQuizForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit My Quiz";
			this.questionsGroupBox.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.questionsContextMenuStrip.ResumeLayout(false);
			this.categoryItemsContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label authorLabel;
		private System.Windows.Forms.TextBox authorTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label categoryNameLabel;
		private System.Windows.Forms.GroupBox questionsGroupBox;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Button removeAllItemsButton;
		private System.Windows.Forms.Button removeItemButton;
		private System.Windows.Forms.Button addItemButton;
		private System.Windows.Forms.Button addAllItemsButton;
		private System.Windows.Forms.Label questionsLabel;
		private System.Windows.Forms.ListView questionsListView;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.ColumnHeader alternateNameColumnHeader;
		private System.Windows.Forms.Button manageCategoryItemsButton;
		private System.Windows.Forms.Label categoryItemsLabel;
		private System.Windows.Forms.ListView categoryItemsListView;
		private System.Windows.Forms.ColumnHeader itemNameColumnHeader;
		private System.Windows.Forms.ColumnHeader itemAlternateNameColumnHeader;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ContextMenuStrip questionsContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip categoryItemsContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addSelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAllToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}