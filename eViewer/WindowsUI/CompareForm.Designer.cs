namespace Thayer.Birding.UI.Windows
{
	partial class CompareForm
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
			this.viewEFieldGuideLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.leftPanel = new System.Windows.Forms.Panel();
			this.leftMediaComboBox = new Thayer.Birding.UI.Windows.MediaComboBox();
			this.leftOrganismComboBox = new Thayer.Birding.UI.Windows.OrganismComboBox();
			this.rightPictureBox = new System.Windows.Forms.PictureBox();
			this.rightContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.playRecordingRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flipRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewEFieldGuideRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rightPanel = new System.Windows.Forms.Panel();
			this.rightMediaComboBox = new Thayer.Birding.UI.Windows.MediaComboBox();
			this.rightOrganismComboBox = new Thayer.Birding.UI.Windows.OrganismComboBox();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
			this.menu.TabIndex = 4;
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
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(0, 24);
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
			this.splitContainer.Size = new System.Drawing.Size(792, 442);
			this.splitContainer.SplitterDistance = 380;
			this.splitContainer.TabIndex = 5;
			// 
			// leftPictureBox
			// 
			this.leftPictureBox.ContextMenuStrip = this.leftContextMenuStrip;
			this.leftPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPictureBox.Location = new System.Drawing.Point(2, 27);
			this.leftPictureBox.Name = "leftPictureBox";
			this.leftPictureBox.Size = new System.Drawing.Size(376, 413);
			this.leftPictureBox.TabIndex = 4;
			this.leftPictureBox.TabStop = false;
			// 
			// leftContextMenuStrip
			// 
			this.leftContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playRecordingLeftToolStripMenuItem,
            this.flipLeftToolStripMenuItem,
            this.viewEFieldGuideLeftToolStripMenuItem});
			this.leftContextMenuStrip.Name = "leftContextMenuStrip";
			this.leftContextMenuStrip.Size = new System.Drawing.Size(168, 70);
			// 
			// playRecordingLeftToolStripMenuItem
			// 
			this.playRecordingLeftToolStripMenuItem.Name = "playRecordingLeftToolStripMenuItem";
			this.playRecordingLeftToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.playRecordingLeftToolStripMenuItem.Text = "Play &Recording";
			this.playRecordingLeftToolStripMenuItem.Click += new System.EventHandler(this.playRecordingLeftToolStripMenuItem_Click);
			// 
			// flipLeftToolStripMenuItem
			// 
			this.flipLeftToolStripMenuItem.Name = "flipLeftToolStripMenuItem";
			this.flipLeftToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.flipLeftToolStripMenuItem.Text = "&Flip Image";
			this.flipLeftToolStripMenuItem.Click += new System.EventHandler(this.flipLeftToolStripMenuItem_Click);
			// 
			// viewEFieldGuideLeftToolStripMenuItem
			// 
			this.viewEFieldGuideLeftToolStripMenuItem.Name = "viewEFieldGuideLeftToolStripMenuItem";
			this.viewEFieldGuideLeftToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.viewEFieldGuideLeftToolStripMenuItem.Text = "&View eField Guide";
			this.viewEFieldGuideLeftToolStripMenuItem.Click += new System.EventHandler(this.viewEFieldGuideLeftToolStripMenuItem_Click);
			// 
			// leftPanel
			// 
			this.leftPanel.Controls.Add(this.leftMediaComboBox);
			this.leftPanel.Controls.Add(this.leftOrganismComboBox);
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
			// leftOrganismComboBox
			// 
			this.leftOrganismComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.leftOrganismComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.leftOrganismComboBox.FormattingEnabled = true;
			this.leftOrganismComboBox.Location = new System.Drawing.Point(0, 0);
			this.leftOrganismComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.leftOrganismComboBox.Name = "leftOrganismComboBox";
			this.leftOrganismComboBox.Size = new System.Drawing.Size(187, 21);
			this.leftOrganismComboBox.TabIndex = 0;
			this.leftOrganismComboBox.SelectedIndexChanged += new System.EventHandler(this.leftOrganismComboBox_SelectedIndexChanged);
			// 
			// rightPictureBox
			// 
			this.rightPictureBox.ContextMenuStrip = this.rightContextMenuStrip;
			this.rightPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPictureBox.Location = new System.Drawing.Point(2, 27);
			this.rightPictureBox.Name = "rightPictureBox";
			this.rightPictureBox.Size = new System.Drawing.Size(404, 413);
			this.rightPictureBox.TabIndex = 5;
			this.rightPictureBox.TabStop = false;
			// 
			// rightContextMenuStrip
			// 
			this.rightContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playRecordingRightToolStripMenuItem,
            this.flipRightToolStripMenuItem,
            this.viewEFieldGuideRightToolStripMenuItem});
			this.rightContextMenuStrip.Name = "rightContextMenuStrip";
			this.rightContextMenuStrip.Size = new System.Drawing.Size(168, 70);
			// 
			// playRecordingRightToolStripMenuItem
			// 
			this.playRecordingRightToolStripMenuItem.Name = "playRecordingRightToolStripMenuItem";
			this.playRecordingRightToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.playRecordingRightToolStripMenuItem.Text = "Play &Recording";
			this.playRecordingRightToolStripMenuItem.Click += new System.EventHandler(this.playRecordingRightToolStripMenuItem_Click);
			// 
			// flipRightToolStripMenuItem
			// 
			this.flipRightToolStripMenuItem.Name = "flipRightToolStripMenuItem";
			this.flipRightToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.flipRightToolStripMenuItem.Text = "&Flip Image";
			this.flipRightToolStripMenuItem.Click += new System.EventHandler(this.flipRightToolStripMenuItem_Click);
			// 
			// viewEFieldGuideRightToolStripMenuItem
			// 
			this.viewEFieldGuideRightToolStripMenuItem.Name = "viewEFieldGuideRightToolStripMenuItem";
			this.viewEFieldGuideRightToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.viewEFieldGuideRightToolStripMenuItem.Text = "&View eField Guide";
			this.viewEFieldGuideRightToolStripMenuItem.Click += new System.EventHandler(this.viewEFieldGuideRightToolStripMenuItem_Click);
			// 
			// rightPanel
			// 
			this.rightPanel.Controls.Add(this.rightMediaComboBox);
			this.rightPanel.Controls.Add(this.rightOrganismComboBox);
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
			this.rightMediaComboBox.TabIndex = 2;
			this.rightMediaComboBox.SelectedIndexChanged += new System.EventHandler(this.rightMediaComboBox_SelectedIndexChanged);
			// 
			// rightOrganismComboBox
			// 
			this.rightOrganismComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.rightOrganismComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.rightOrganismComboBox.FormattingEnabled = true;
			this.rightOrganismComboBox.Location = new System.Drawing.Point(0, 0);
			this.rightOrganismComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.rightOrganismComboBox.Name = "rightOrganismComboBox";
			this.rightOrganismComboBox.Size = new System.Drawing.Size(187, 21);
			this.rightOrganismComboBox.TabIndex = 0;
			this.rightOrganismComboBox.SelectedIndexChanged += new System.EventHandler(this.rightOrganismComboBox_SelectedIndexChanged);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// CompareForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 466);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.menu);
			this.helpProvider.SetHelpKeyword(this, "5");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MinimumSize = new System.Drawing.Size(500, 300);
			this.Name = "CompareForm";
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
		private OrganismComboBox leftOrganismComboBox;
		private System.Windows.Forms.PictureBox rightPictureBox;
		private System.Windows.Forms.Panel rightPanel;
		private MediaComboBox rightMediaComboBox;
		private OrganismComboBox rightOrganismComboBox;
		private System.Windows.Forms.ContextMenuStrip leftContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem flipLeftToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip rightContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem flipRightToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playRecordingLeftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playRecordingRightToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewEFieldGuideLeftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewEFieldGuideRightToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.ToolTip toolTip;

	}
}