namespace Thayer.Birding.UI.Windows
{
	partial class ComboBoxTestForm
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
			this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraComboEditor1
			// 
			this.ultraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.ultraComboEditor1.Location = new System.Drawing.Point(43, 109);
			this.ultraComboEditor1.Name = "ultraComboEditor1";
			this.ultraComboEditor1.Size = new System.Drawing.Size(218, 21);
			this.ultraComboEditor1.TabIndex = 1;
			this.ultraComboEditor1.Text = "ultraComboEditor1";
			this.ultraComboEditor1.SelectionChangeCommitted += new System.EventHandler(this.ultraComboEditor1_SelectionChangeCommitted);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(430, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
			// 
			// ComboBoxTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(430, 273);
			this.Controls.Add(this.ultraComboEditor1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ComboBoxTestForm";
			this.Text = "ComboBoxTestForm";
			((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
	}
}