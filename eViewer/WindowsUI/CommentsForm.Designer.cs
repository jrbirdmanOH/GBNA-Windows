namespace Thayer.Birding.UI.Windows
{
	partial class CommentsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentsForm));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.winHTMLEditorControl = new WinHTMLEditorControl.winHTMLEditorControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.sourceTextBox = new System.Windows.Forms.TextBox();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.winHTMLEditorControl.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(285, 454);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(367, 453);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Location = new System.Drawing.Point(12, 22);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(700, 419);
			this.tabControl.TabIndex = 3;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.winHTMLEditorControl);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(692, 393);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Editor";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// winHTMLEditorControl
			// 
			this.winHTMLEditorControl.AccessibleDescription = "";
			this.winHTMLEditorControl.AccessibleName = "";
			this.winHTMLEditorControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
			this.winHTMLEditorControl.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.winHTMLEditorControl.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.winHTMLEditorControl.BackgroundImagePath = "";
			this.winHTMLEditorControl.BaseURL = "";
			this.winHTMLEditorControl.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.winHTMLEditorControl.BodyHtml = "&nbsp;";
			this.winHTMLEditorControl.BodyStyle = "FONT-SIZE: x-small; OVERFLOW: auto; FONT-FAMILY: Arial";
			this.winHTMLEditorControl.BodyText = " ";
			this.winHTMLEditorControl.Charset = "unicode";
			this.winHTMLEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.winHTMLEditorControl.DocumentHtml = resources.GetString("winHTMLEditorControl.DocumentHtml");
			this.winHTMLEditorControl.DocumentTitle = "";
			// 
			// winHTMLEditorControl.WinHTMLEditorToolStrip1
			// 
			this.winHTMLEditorControl.EditorToolStripFirst.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.winHTMLEditorControl.EditorToolStripFirst.Location = new System.Drawing.Point(0, 0);
			this.winHTMLEditorControl.EditorToolStripFirst.Name = "WinHTMLEditorToolStrip1";
			this.winHTMLEditorControl.EditorToolStripFirst.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.winHTMLEditorControl.EditorToolStripFirst.Size = new System.Drawing.Size(686, 29);
			this.winHTMLEditorControl.EditorToolStripFirst.TabIndex = 2;
			this.winHTMLEditorControl.EditorToolStripFirst.Text = "toolStrip1";
			// 
			// winHTMLEditorControl.WinHTMLEditorToolStrip2
			// 
			this.winHTMLEditorControl.EditorToolStripSecond.Location = new System.Drawing.Point(0, 29);
			this.winHTMLEditorControl.EditorToolStripSecond.Name = "WinHTMLEditorToolStrip2";
			this.winHTMLEditorControl.EditorToolStripSecond.Size = new System.Drawing.Size(686, 29);
			this.winHTMLEditorControl.EditorToolStripSecond.TabIndex = 3;
			this.winHTMLEditorControl.EditorToolStripSecond.Text = "toolStrip2";
			this.winHTMLEditorControl.EnterKeyResponse = WinHTMLEditorControl.EnteryKeyResponses.LineBreak;
			this.winHTMLEditorControl.LanguageCulture = null;
			this.winHTMLEditorControl.LicenseKey = "7F36-AFB9-1BF6-2B9E-06AD-D4BB-F9F8-48E6-54BA-BD3B-85AF-68B7-583E-E5C1-5EF7-E683-9" +
				"C81-F717-5ED8-0199";
			this.winHTMLEditorControl.Location = new System.Drawing.Point(3, 3);
			this.winHTMLEditorControl.Name = "winHTMLEditorControl";
			this.winHTMLEditorControl.OutputXHTML = false;
			this.winHTMLEditorControl.ReadOnly = false;
			this.winHTMLEditorControl.ScrollBars = WinHTMLEditorControl.ScrollBarVisibility.Auto;
			this.winHTMLEditorControl.Size = new System.Drawing.Size(686, 387);
			this.winHTMLEditorControl.TabIndex = 1;
			this.winHTMLEditorControl.ToolbarConfigXML = resources.GetString("winHTMLEditorControl.ToolbarConfigXML");
			this.winHTMLEditorControl.WordWrap = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.sourceTextBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(692, 393);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Source";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// sourceTextBox
			// 
			this.sourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.sourceTextBox.Location = new System.Drawing.Point(6, 28);
			this.sourceTextBox.Multiline = true;
			this.sourceTextBox.Name = "sourceTextBox";
			this.sourceTextBox.Size = new System.Drawing.Size(670, 318);
			this.sourceTextBox.TabIndex = 0;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// CommentsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(724, 491);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.helpProvider.SetHelpKeyword(this, "63");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "CommentsForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "My Comments";
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.winHTMLEditorControl.ResumeLayout(false);
			this.winHTMLEditorControl.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private WinHTMLEditorControl.winHTMLEditorControl winHTMLEditorControl;
		private System.Windows.Forms.TextBox sourceTextBox;
		private System.Windows.Forms.HelpProvider helpProvider;
	}
}