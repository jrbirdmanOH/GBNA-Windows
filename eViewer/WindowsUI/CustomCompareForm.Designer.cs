using System.Windows.Forms;
namespace Thayer.Birding.UI.Windows
{
	partial class CustomCompareForm
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
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.leftContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playRecordingLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.leftMediaComboBox = new Thayer.Birding.UI.Windows.MediaComboBox();
            this.leftCustomThingComboBox = new Thayer.Birding.UI.Windows.OrganismComboBox();
            this.rightPictureBox = new System.Windows.Forms.PictureBox();
            this.rightContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playRecordingRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.rightMediaComboBox = new Thayer.Birding.UI.Windows.MediaComboBox();
            this.rightCustomThingComboBox = new Thayer.Birding.UI.Windows.OrganismComboBox();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.quizLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.quizComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.menu.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).BeginInit();
            this.leftContextMenuStrip.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).BeginInit();
            this.rightContextMenuStrip.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.filterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(792, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 98);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.leftPictureBox);
            this.splitContainer.Panel1.Controls.Add(this.leftPanel);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rightPictureBox);
            this.splitContainer.Panel2.Controls.Add(this.rightPanel);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer.Size = new System.Drawing.Size(792, 368);
            this.splitContainer.SplitterDistance = 380;
            this.splitContainer.TabIndex = 2;
            // 
            // leftPictureBox
            // 
            this.leftPictureBox.ContextMenuStrip = this.leftContextMenuStrip;
            this.leftPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPictureBox.Location = new System.Drawing.Point(2, 27);
            this.leftPictureBox.Name = "leftPictureBox";
            this.leftPictureBox.Size = new System.Drawing.Size(376, 339);
            this.leftPictureBox.TabIndex = 4;
            this.leftPictureBox.TabStop = false;
            // 
            // leftContextMenuStrip
            // 
            this.leftContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playRecordingLeftToolStripMenuItem,
            this.flipLeftToolStripMenuItem});
            this.leftContextMenuStrip.Name = "leftContextMenuStrip";
            this.leftContextMenuStrip.Size = new System.Drawing.Size(154, 48);
            // 
            // playRecordingLeftToolStripMenuItem
            // 
            this.playRecordingLeftToolStripMenuItem.Name = "playRecordingLeftToolStripMenuItem";
            this.playRecordingLeftToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.playRecordingLeftToolStripMenuItem.Text = "Play &Recording";
            this.playRecordingLeftToolStripMenuItem.Click += new System.EventHandler(this.playRecordingLeftToolStripMenuItem_Click);
            // 
            // flipLeftToolStripMenuItem
            // 
            this.flipLeftToolStripMenuItem.Name = "flipLeftToolStripMenuItem";
            this.flipLeftToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.flipLeftToolStripMenuItem.Text = "&Flip Image";
            this.flipLeftToolStripMenuItem.Click += new System.EventHandler(this.flipLeftToolStripMenuItem_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.leftMediaComboBox);
            this.leftPanel.Controls.Add(this.leftCustomThingComboBox);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftPanel.Location = new System.Drawing.Point(2, 2);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(376, 25);
            this.leftPanel.TabIndex = 1;
            // 
            // leftMediaComboBox
            // 
            this.leftMediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftMediaComboBox.FormattingEnabled = true;
            this.leftMediaComboBox.Location = new System.Drawing.Point(193, 0);
            this.leftMediaComboBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.leftMediaComboBox.Name = "leftMediaComboBox";
            this.leftMediaComboBox.PreferredMediaID = 0;
            this.leftMediaComboBox.Size = new System.Drawing.Size(183, 21);
            this.leftMediaComboBox.TabIndex = 1;
            this.leftMediaComboBox.SelectedIndexChanged += new System.EventHandler(this.leftMediaComboBox_SelectedIndexChanged);
            // 
            // leftCustomThingComboBox
            // 
            this.leftCustomThingComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.leftCustomThingComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.leftCustomThingComboBox.Location = new System.Drawing.Point(0, 0);
            this.leftCustomThingComboBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.leftCustomThingComboBox.Name = "leftCustomThingComboBox";
            this.leftCustomThingComboBox.Size = new System.Drawing.Size(187, 21);
            this.leftCustomThingComboBox.Sorted = true;
            this.leftCustomThingComboBox.TabIndex = 0;
            this.leftCustomThingComboBox.SelectedIndexChanged += new System.EventHandler(this.leftCustomThingComboBox_SelectedIndexChanged);
            // 
            // rightPictureBox
            // 
            this.rightPictureBox.ContextMenuStrip = this.rightContextMenuStrip;
            this.rightPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPictureBox.Location = new System.Drawing.Point(2, 27);
            this.rightPictureBox.Name = "rightPictureBox";
            this.rightPictureBox.Size = new System.Drawing.Size(404, 339);
            this.rightPictureBox.TabIndex = 5;
            this.rightPictureBox.TabStop = false;
            // 
            // rightContextMenuStrip
            // 
            this.rightContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playRecordingRightToolStripMenuItem,
            this.flipRightToolStripMenuItem});
            this.rightContextMenuStrip.Name = "rightContextMenuStrip";
            this.rightContextMenuStrip.Size = new System.Drawing.Size(154, 48);
            // 
            // playRecordingRightToolStripMenuItem
            // 
            this.playRecordingRightToolStripMenuItem.Name = "playRecordingRightToolStripMenuItem";
            this.playRecordingRightToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.playRecordingRightToolStripMenuItem.Text = "Play &Recording";
            this.playRecordingRightToolStripMenuItem.Click += new System.EventHandler(this.playRecordingRightToolStripMenuItem_Click);
            // 
            // flipRightToolStripMenuItem
            // 
            this.flipRightToolStripMenuItem.Name = "flipRightToolStripMenuItem";
            this.flipRightToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.flipRightToolStripMenuItem.Text = "&Flip Image";
            this.flipRightToolStripMenuItem.Click += new System.EventHandler(this.flipRightToolStripMenuItem_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.rightMediaComboBox);
            this.rightPanel.Controls.Add(this.rightCustomThingComboBox);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightPanel.Location = new System.Drawing.Point(2, 2);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(404, 25);
            this.rightPanel.TabIndex = 3;
            // 
            // rightMediaComboBox
            // 
            this.rightMediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rightMediaComboBox.FormattingEnabled = true;
            this.rightMediaComboBox.Location = new System.Drawing.Point(193, 0);
            this.rightMediaComboBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.rightMediaComboBox.Name = "rightMediaComboBox";
            this.rightMediaComboBox.PreferredMediaID = 0;
            this.rightMediaComboBox.Size = new System.Drawing.Size(211, 21);
            this.rightMediaComboBox.TabIndex = 1;
            this.rightMediaComboBox.SelectedIndexChanged += new System.EventHandler(this.rightMediaComboBox_SelectedIndexChanged);
            // 
            // rightCustomThingComboBox
            // 
            this.rightCustomThingComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.rightCustomThingComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.rightCustomThingComboBox.Location = new System.Drawing.Point(0, 0);
            this.rightCustomThingComboBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.rightCustomThingComboBox.Name = "rightCustomThingComboBox";
            this.rightCustomThingComboBox.Size = new System.Drawing.Size(187, 21);
            this.rightCustomThingComboBox.Sorted = true;
            this.rightCustomThingComboBox.TabIndex = 0;
            this.rightCustomThingComboBox.SelectedIndexChanged += new System.EventHandler(this.rightCustomThingComboBox_SelectedIndexChanged);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "eViewer.chm";
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.filterGroupBox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 24);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(792, 68);
            this.filterPanel.TabIndex = 1;
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.quizLabel);
            this.filterGroupBox.Controls.Add(this.categoryLabel);
            this.filterGroupBox.Controls.Add(this.quizComboBox);
            this.filterGroupBox.Controls.Add(this.categoryComboBox);
            this.filterGroupBox.Location = new System.Drawing.Point(12, 10);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(551, 55);
            this.filterGroupBox.TabIndex = 0;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filter";
            // 
            // quizLabel
            // 
            this.quizLabel.AutoSize = true;
            this.quizLabel.Location = new System.Drawing.Point(295, 25);
            this.quizLabel.Name = "quizLabel";
            this.quizLabel.Size = new System.Drawing.Size(31, 13);
            this.quizLabel.TabIndex = 2;
            this.quizLabel.Text = "Quiz:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(20, 25);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(52, 13);
            this.categoryLabel.TabIndex = 0;
            this.categoryLabel.Text = "Category:";
            // 
            // quizComboBox
            // 
            this.quizComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.quizComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.quizComboBox.FormattingEnabled = true;
            this.quizComboBox.Location = new System.Drawing.Point(330, 21);
            this.quizComboBox.Name = "quizComboBox";
            this.quizComboBox.Size = new System.Drawing.Size(198, 21);
            this.quizComboBox.TabIndex = 3;
            this.quizComboBox.SelectedIndexChanged += new System.EventHandler(this.quizComboBox_SelectedIndexChanged);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.categoryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(78, 21);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(189, 21);
            this.categoryComboBox.TabIndex = 1;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // CustomCompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menu);
            this.helpProvider.SetHelpKeyword(this, "5");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "CustomCompareForm";
            this.helpProvider.SetShowHelp(this, true);
            this.Text = "Side-by-side Comparison";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).EndInit();
            this.leftContextMenuStrip.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).EndInit();
            this.rightContextMenuStrip.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.PictureBox leftPictureBox;
		private System.Windows.Forms.Panel leftPanel;
        private MediaComboBox leftMediaComboBox;
		private System.Windows.Forms.PictureBox rightPictureBox;
		private System.Windows.Forms.Panel rightPanel;
        private MediaComboBox rightMediaComboBox;
		private System.Windows.Forms.ContextMenuStrip leftContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem flipLeftToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip rightContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem flipRightToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playRecordingLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playRecordingRightToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
        private OrganismComboBox leftCustomThingComboBox;
        private OrganismComboBox rightCustomThingComboBox;
        private Panel filterPanel;
        private GroupBox filterGroupBox;
        private Label quizLabel;
        private Label categoryLabel;
        private ComboBox quizComboBox;
        private ComboBox categoryComboBox;

	}
}