namespace Thayer.Birding.UI.Windows
{
	partial class PhotoGalleryForm
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
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.photoGallery = new Thayer.Birding.UI.PhotoGallery();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.primaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.secondaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.topPanel = new System.Windows.Forms.Panel();
			this.imageTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.secondaryRadioButton = new System.Windows.Forms.RadioButton();
			this.primaryRadioButton = new System.Windows.Forms.RadioButton();
			this.bottomPanel = new System.Windows.Forms.Panel();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.menuStrip.SuspendLayout();
			this.topPanel.SuspendLayout();
			this.imageTypeGroupBox.SuspendLayout();
			this.bottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(539, 24);
			this.menuStrip.TabIndex = 3;
			this.menuStrip.Text = "menuStrip";
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
            this.primaryToolStripMenuItem,
            this.secondaryToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// primaryToolStripMenuItem
			// 
			this.primaryToolStripMenuItem.Name = "primaryToolStripMenuItem";
			this.primaryToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.primaryToolStripMenuItem.Text = "&Primary";
			this.primaryToolStripMenuItem.Click += new System.EventHandler(this.primaryToolStripMenuItem_Click);
			// 
			// secondaryToolStripMenuItem
			// 
			this.secondaryToolStripMenuItem.Name = "secondaryToolStripMenuItem";
			this.secondaryToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.secondaryToolStripMenuItem.Text = "&Secondary";
			this.secondaryToolStripMenuItem.Click += new System.EventHandler(this.secondaryToolStripMenuItem_Click);
			// 
			// topPanel
			// 
			this.topPanel.BackColor = System.Drawing.SystemColors.Window;
			this.topPanel.Controls.Add(this.imageTypeGroupBox);
			this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPanel.Location = new System.Drawing.Point(0, 24);
			this.topPanel.Name = "topPanel";
			this.topPanel.Size = new System.Drawing.Size(539, 59);
			this.topPanel.TabIndex = 4;
			// 
			// imageTypeGroupBox
			// 
			this.imageTypeGroupBox.Controls.Add(this.secondaryRadioButton);
			this.imageTypeGroupBox.Controls.Add(this.primaryRadioButton);
			this.imageTypeGroupBox.Location = new System.Drawing.Point(12, 5);
			this.imageTypeGroupBox.Name = "imageTypeGroupBox";
			this.imageTypeGroupBox.Size = new System.Drawing.Size(171, 49);
			this.imageTypeGroupBox.TabIndex = 0;
			this.imageTypeGroupBox.TabStop = false;
			this.imageTypeGroupBox.Text = "Image Type";
			// 
			// secondaryRadioButton
			// 
			this.secondaryRadioButton.AutoSize = true;
			this.secondaryRadioButton.Location = new System.Drawing.Point(71, 20);
			this.secondaryRadioButton.Name = "secondaryRadioButton";
			this.secondaryRadioButton.Size = new System.Drawing.Size(76, 17);
			this.secondaryRadioButton.TabIndex = 1;
			this.secondaryRadioButton.TabStop = true;
			this.secondaryRadioButton.Text = "&Secondary";
			this.secondaryRadioButton.UseVisualStyleBackColor = true;
			this.secondaryRadioButton.CheckedChanged += new System.EventHandler(this.secondaryRadioButton_CheckedChanged);
			// 
			// primaryRadioButton
			// 
			this.primaryRadioButton.AutoSize = true;
			this.primaryRadioButton.Location = new System.Drawing.Point(6, 20);
			this.primaryRadioButton.Name = "primaryRadioButton";
			this.primaryRadioButton.Size = new System.Drawing.Size(59, 17);
			this.primaryRadioButton.TabIndex = 0;
			this.primaryRadioButton.TabStop = true;
			this.primaryRadioButton.Text = "&Primary";
			this.primaryRadioButton.UseVisualStyleBackColor = true;
			this.primaryRadioButton.CheckedChanged += new System.EventHandler(this.primaryRadioButton_CheckedChanged);
			// 
			// bottomPanel
			// 
			this.bottomPanel.Controls.Add(this.webBrowser);
			this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bottomPanel.Location = new System.Drawing.Point(0, 83);
			this.bottomPanel.Name = "bottomPanel";
			this.bottomPanel.Size = new System.Drawing.Size(539, 183);
			this.bottomPanel.TabIndex = 5;
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser.Location = new System.Drawing.Point(0, 0);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(539, 183);
			this.webBrowser.TabIndex = 2;
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
			this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
			this.webBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);
			// 
			// PhotoGalleryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 266);
			this.Controls.Add(this.bottomPanel);
			this.Controls.Add(this.topPanel);
			this.Controls.Add(this.menuStrip);
			this.helpProvider.SetHelpKeyword(this, "44");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "PhotoGalleryForm";
			this.helpProvider.SetShowHelp(this, true);
			this.Text = "Photo Gallery";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.topPanel.ResumeLayout(false);
			this.imageTypeGroupBox.ResumeLayout(false);
			this.imageTypeGroupBox.PerformLayout();
			this.bottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PhotoGallery photoGallery;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem primaryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem secondaryToolStripMenuItem;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.GroupBox imageTypeGroupBox;
		private System.Windows.Forms.RadioButton secondaryRadioButton;
		private System.Windows.Forms.RadioButton primaryRadioButton;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.WebBrowser webBrowser;
	}
}