namespace Thayer.Birding.UI.Windows.Quiz
{
	partial class HallOfFameClearScoresForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.clearButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.hallOfFameListView = new System.Windows.Forms.ListView();
			this.quizNameHeader = new System.Windows.Forms.ColumnHeader();
			this.clearAllButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(322, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please select one or more quiz names to clear Hall of Fame scores.";
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.Location = new System.Drawing.Point(203, 263);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(75, 23);
			this.clearButton.TabIndex = 2;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(284, 263);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 3;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// hallOfFameListView
			// 
			this.hallOfFameListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.hallOfFameListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.quizNameHeader});
			this.hallOfFameListView.FullRowSelect = true;
			this.hallOfFameListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.hallOfFameListView.HideSelection = false;
			this.hallOfFameListView.Location = new System.Drawing.Point(12, 25);
			this.hallOfFameListView.Name = "hallOfFameListView";
			this.hallOfFameListView.Size = new System.Drawing.Size(347, 223);
			this.hallOfFameListView.TabIndex = 1;
			this.hallOfFameListView.UseCompatibleStateImageBehavior = false;
			this.hallOfFameListView.View = System.Windows.Forms.View.Details;
			this.hallOfFameListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.hallOfFameListView_ItemSelectionChanged);
			this.hallOfFameListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hallOfFameListView_KeyDown);
			// 
			// quizNameHeader
			// 
			this.quizNameHeader.Text = "Quiz Name";
			this.quizNameHeader.Width = 306;
			// 
			// clearAllButton
			// 
			this.clearAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearAllButton.Location = new System.Drawing.Point(122, 263);
			this.clearAllButton.Name = "clearAllButton";
			this.clearAllButton.Size = new System.Drawing.Size(75, 23);
			this.clearAllButton.TabIndex = 4;
			this.clearAllButton.Text = "Clear All";
			this.clearAllButton.UseVisualStyleBackColor = true;
			this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
			// 
			// HallOfFameClearScoresForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 298);
			this.Controls.Add(this.clearAllButton);
			this.Controls.Add(this.hallOfFameListView);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.label1);
			this.Name = "HallOfFameClearScoresForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hall of Fame Scores";
			this.Load += new System.EventHandler(this.HallOfFameClearScoresForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.ListView hallOfFameListView;
		private System.Windows.Forms.ColumnHeader quizNameHeader;
		private System.Windows.Forms.Button clearAllButton;
	}
}