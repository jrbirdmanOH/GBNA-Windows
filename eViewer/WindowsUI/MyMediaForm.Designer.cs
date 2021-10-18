namespace Thayer.Birding.UI.Windows
{
	partial class MyMediaForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMediaForm));
			this.newPhotoButton = new System.Windows.Forms.Button();
			this.newVideoButton = new System.Windows.Forms.Button();
			this.mediaListView = new System.Windows.Forms.ListView();
			this.fileName = new System.Windows.Forms.ColumnHeader();
			this.caption = new System.Windows.Forms.ColumnHeader();
			this.type = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.photoToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.soundToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newSoundButton = new System.Windows.Forms.Button();
			this.editMediaButton = new System.Windows.Forms.Button();
			this.deleteMediaButton = new System.Windows.Forms.Button();
			this.mediaGroupBox = new System.Windows.Forms.GroupBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.photoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeButton = new System.Windows.Forms.Button();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.newPhotoDropDownButtonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newSoundDropDownButtonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newVideoDropDownButtonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip.SuspendLayout();
			this.mediaGroupBox.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			label1.Location = new System.Drawing.Point(12, 55);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(581, 42);
			label1.TabIndex = 2;
			label1.Text = resources.GetString("label1.Text");
			// 
			// newPhotoButton
			// 
			this.newPhotoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.newPhotoButton.Location = new System.Drawing.Point(43, 222);
			this.newPhotoButton.Name = "newPhotoButton";
			this.newPhotoButton.Size = new System.Drawing.Size(85, 23);
			this.newPhotoButton.TabIndex = 2;
			this.newPhotoButton.Text = "New Photo...";
			this.newPhotoButton.UseVisualStyleBackColor = true;
			this.newPhotoButton.Click += new System.EventHandler(this.newPhotoButton_Click);
			// 
			// newVideoButton
			// 
			this.newVideoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.newVideoButton.Location = new System.Drawing.Point(225, 222);
			this.newVideoButton.Name = "newVideoButton";
			this.newVideoButton.Size = new System.Drawing.Size(85, 23);
			this.newVideoButton.TabIndex = 4;
			this.newVideoButton.Text = "New Video...";
			this.newVideoButton.UseVisualStyleBackColor = true;
			this.newVideoButton.Click += new System.EventHandler(this.newVideoButton_Click);
			// 
			// mediaListView
			// 
			this.mediaListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mediaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.caption,
            this.type});
			this.mediaListView.ContextMenuStrip = this.contextMenuStrip;
			this.mediaListView.FullRowSelect = true;
			this.mediaListView.HideSelection = false;
			this.mediaListView.Location = new System.Drawing.Point(12, 23);
			this.mediaListView.Name = "mediaListView";
			this.mediaListView.Size = new System.Drawing.Size(557, 193);
			this.mediaListView.TabIndex = 1;
			this.mediaListView.UseCompatibleStateImageBehavior = false;
			this.mediaListView.View = System.Windows.Forms.View.Details;
			this.mediaListView.SelectedIndexChanged += new System.EventHandler(this.mediaListView_SelectedIndexChanged);
			this.mediaListView.DoubleClick += new System.EventHandler(this.mediaListView_DoubleClick);
			this.mediaListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.mediaListView_ColumnClick);
			this.mediaListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mediaListView_KeyDown);
			// 
			// fileName
			// 
			this.fileName.Text = "File Name";
			this.fileName.Width = 244;
			// 
			// caption
			// 
			this.caption.Text = "Caption";
			this.caption.Width = 179;
			// 
			// type
			// 
			this.type.Text = "Type";
			this.type.Width = 86;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripContextMenuItem,
            this.editToolStripContextMenuItem,
            this.deleteToolStripContextMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(108, 70);
			// 
			// newToolStripContextMenuItem
			// 
			this.newToolStripContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoToolStripContextMenuItem,
            this.soundToolStripContextMenuItem,
            this.videoToolStripContextMenuItem});
			this.newToolStripContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripContextMenuItem.Name = "newToolStripContextMenuItem";
			this.newToolStripContextMenuItem.Size = new System.Drawing.Size(107, 22);
			this.newToolStripContextMenuItem.Text = "&New";
			// 
			// photoToolStripContextMenuItem
			// 
			this.photoToolStripContextMenuItem.Name = "photoToolStripContextMenuItem";
			this.photoToolStripContextMenuItem.Size = new System.Drawing.Size(108, 22);
			this.photoToolStripContextMenuItem.Text = "&Photo";
			this.photoToolStripContextMenuItem.Click += new System.EventHandler(this.photoToolStripContextMenuItem_Click);
			// 
			// soundToolStripContextMenuItem
			// 
			this.soundToolStripContextMenuItem.Name = "soundToolStripContextMenuItem";
			this.soundToolStripContextMenuItem.Size = new System.Drawing.Size(108, 22);
			this.soundToolStripContextMenuItem.Text = "&Sound";
			this.soundToolStripContextMenuItem.Click += new System.EventHandler(this.soundToolStripContextMenuItem_Click);
			// 
			// videoToolStripContextMenuItem
			// 
			this.videoToolStripContextMenuItem.Name = "videoToolStripContextMenuItem";
			this.videoToolStripContextMenuItem.Size = new System.Drawing.Size(108, 22);
			this.videoToolStripContextMenuItem.Text = "&Video";
			this.videoToolStripContextMenuItem.Click += new System.EventHandler(this.videoToolStripContextMenuItem_Click);
			// 
			// editToolStripContextMenuItem
			// 
			this.editToolStripContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.editToolStripContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripContextMenuItem.Name = "editToolStripContextMenuItem";
			this.editToolStripContextMenuItem.Size = new System.Drawing.Size(107, 22);
			this.editToolStripContextMenuItem.Text = "&Edit";
			this.editToolStripContextMenuItem.Click += new System.EventHandler(this.editToolStripContextMenuItem_Click);
			// 
			// deleteToolStripContextMenuItem
			// 
			this.deleteToolStripContextMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripContextMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripContextMenuItem.Name = "deleteToolStripContextMenuItem";
			this.deleteToolStripContextMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripContextMenuItem.Text = "&Delete";
			this.deleteToolStripContextMenuItem.Click += new System.EventHandler(this.deleteToolStripContextMenuItem_Click);
			// 
			// newSoundButton
			// 
			this.newSoundButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.newSoundButton.Location = new System.Drawing.Point(134, 222);
			this.newSoundButton.Name = "newSoundButton";
			this.newSoundButton.Size = new System.Drawing.Size(85, 23);
			this.newSoundButton.TabIndex = 3;
			this.newSoundButton.Text = "New Sound...";
			this.newSoundButton.UseVisualStyleBackColor = true;
			this.newSoundButton.Click += new System.EventHandler(this.newSoundButton_Click);
			// 
			// editMediaButton
			// 
			this.editMediaButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.editMediaButton.Location = new System.Drawing.Point(382, 222);
			this.editMediaButton.Name = "editMediaButton";
			this.editMediaButton.Size = new System.Drawing.Size(75, 23);
			this.editMediaButton.TabIndex = 5;
			this.editMediaButton.Text = "Edit...";
			this.editMediaButton.UseVisualStyleBackColor = true;
			this.editMediaButton.Click += new System.EventHandler(this.editMediaButton_Click);
			// 
			// deleteMediaButton
			// 
			this.deleteMediaButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.deleteMediaButton.Location = new System.Drawing.Point(463, 222);
			this.deleteMediaButton.Name = "deleteMediaButton";
			this.deleteMediaButton.Size = new System.Drawing.Size(75, 23);
			this.deleteMediaButton.TabIndex = 6;
			this.deleteMediaButton.Text = "Delete";
			this.deleteMediaButton.UseVisualStyleBackColor = true;
			this.deleteMediaButton.Click += new System.EventHandler(this.deleteMediaButton_Click);
			// 
			// mediaGroupBox
			// 
			this.mediaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mediaGroupBox.Controls.Add(this.deleteMediaButton);
			this.mediaGroupBox.Controls.Add(this.editMediaButton);
			this.mediaGroupBox.Controls.Add(this.newVideoButton);
			this.mediaGroupBox.Controls.Add(this.newPhotoButton);
			this.mediaGroupBox.Controls.Add(this.newSoundButton);
			this.mediaGroupBox.Controls.Add(this.mediaListView);
			this.mediaGroupBox.Location = new System.Drawing.Point(12, 136);
			this.mediaGroupBox.Name = "mediaGroupBox";
			this.mediaGroupBox.Size = new System.Drawing.Size(581, 256);
			this.mediaGroupBox.TabIndex = 3;
			this.mediaGroupBox.TabStop = false;
			this.mediaGroupBox.Text = "My Media";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(12, 107);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(38, 13);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name:";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(609, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.videoToolStripMenuItem});
			this.newToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newToolStripMenuItem.Text = "&New";
			// 
			// photoToolStripMenuItem
			// 
			this.photoToolStripMenuItem.Name = "photoToolStripMenuItem";
			this.photoToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.photoToolStripMenuItem.Text = "&Photo";
			this.photoToolStripMenuItem.Click += new System.EventHandler(this.photoToolStripMenuItem_Click);
			// 
			// soundToolStripMenuItem
			// 
			this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
			this.soundToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.soundToolStripMenuItem.Text = "&Sound";
			this.soundToolStripMenuItem.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
			// 
			// videoToolStripMenuItem
			// 
			this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
			this.videoToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.videoToolStripMenuItem.Text = "&Video";
			this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.editToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.Delete;
			this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(266, 407);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 4;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripDropDownButton,
            this.editToolStripButton,
            this.deleteToolStripButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(609, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "toolStrip1";
			// 
			// newToolStripDropDownButton
			// 
			this.newToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPhotoDropDownButtonMenuItem,
            this.newSoundDropDownButtonMenuItem,
            this.newVideoDropDownButtonMenuItem});
			this.newToolStripDropDownButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.NewDocument;
			this.newToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripDropDownButton.Name = "newToolStripDropDownButton";
			this.newToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
			this.newToolStripDropDownButton.Text = "New";
			// 
			// newPhotoDropDownButtonMenuItem
			// 
			this.newPhotoDropDownButtonMenuItem.Name = "newPhotoDropDownButtonMenuItem";
			this.newPhotoDropDownButtonMenuItem.Size = new System.Drawing.Size(135, 22);
			this.newPhotoDropDownButtonMenuItem.Text = "New &Photo";
			this.newPhotoDropDownButtonMenuItem.Click += new System.EventHandler(this.newPhotoDropDownButtonMenuItem_Click);
			// 
			// newSoundDropDownButtonMenuItem
			// 
			this.newSoundDropDownButtonMenuItem.Name = "newSoundDropDownButtonMenuItem";
			this.newSoundDropDownButtonMenuItem.Size = new System.Drawing.Size(135, 22);
			this.newSoundDropDownButtonMenuItem.Text = "New &Sound";
			this.newSoundDropDownButtonMenuItem.Click += new System.EventHandler(this.newSoundDropDownButtonMenuItem_Click);
			// 
			// newVideoDropDownButtonMenuItem
			// 
			this.newVideoDropDownButtonMenuItem.Name = "newVideoDropDownButtonMenuItem";
			this.newVideoDropDownButtonMenuItem.Size = new System.Drawing.Size(135, 22);
			this.newVideoDropDownButtonMenuItem.Text = "New &Video";
			this.newVideoDropDownButtonMenuItem.Click += new System.EventHandler(this.newVideoDropDownButtonMenuItem_Click);
			// 
			// editToolStripButton
			// 
			this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.editToolStripButton.Image = global::Thayer.Birding.UI.Windows.Properties.Resources.OpenFolder;
			this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripButton.Name = "editToolStripButton";
			this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.editToolStripButton.Text = "Edit";
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
			this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// MyMediaForm
			// 
			this.AcceptButton = this.closeButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(609, 444);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(label1);
			this.Controls.Add(this.mediaGroupBox);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.helpProvider.SetHelpKeyword(this, "64");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MyMediaForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "My Media";
			this.contextMenuStrip.ResumeLayout(false);
			this.mediaGroupBox.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button newPhotoButton;
		private System.Windows.Forms.Button newVideoButton;
		private System.Windows.Forms.ListView mediaListView;
		private System.Windows.Forms.ColumnHeader fileName;
		private System.Windows.Forms.ColumnHeader caption;
		private System.Windows.Forms.Button newSoundButton;
		private System.Windows.Forms.Button editMediaButton;
		private System.Windows.Forms.Button deleteMediaButton;
		private System.Windows.Forms.GroupBox mediaGroupBox;
		private System.Windows.Forms.ColumnHeader type;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem photoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem newToolStripContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem photoToolStripContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem soundToolStripContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem videoToolStripContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripContextMenuItem;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripDropDownButton newToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem newPhotoDropDownButtonMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newSoundDropDownButtonMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newVideoDropDownButtonMenuItem;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}