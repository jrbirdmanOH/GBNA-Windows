namespace Thayer.Birding.UI.Windows
{
	partial class FilterForm
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
			this.noFilterRadioButton = new System.Windows.Forms.RadioButton();
			this.stateRadioButton = new System.Windows.Forms.RadioButton();
			this.provinceRadioButton = new System.Windows.Forms.RadioButton();
			this.familyRadioButton = new System.Windows.Forms.RadioButton();
			this.customListRadioButton = new System.Windows.Forms.RadioButton();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.filterListView = new System.Windows.Forms.ListView();
			this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.filterOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.commonBirdsRadioButton = new System.Windows.Forms.RadioButton();
			this.allBirdsRadioButton = new System.Windows.Forms.RadioButton();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.regionRadioButton = new System.Windows.Forms.RadioButton();
			this.restoreFilterAtStartupCheckBox = new System.Windows.Forms.CheckBox();
			this.filterOptionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// noFilterRadioButton
			// 
			this.noFilterRadioButton.AutoSize = true;
			this.noFilterRadioButton.Location = new System.Drawing.Point(12, 12);
			this.noFilterRadioButton.Name = "noFilterRadioButton";
			this.noFilterRadioButton.Size = new System.Drawing.Size(51, 17);
			this.noFilterRadioButton.TabIndex = 0;
			this.noFilterRadioButton.TabStop = true;
			this.noFilterRadioButton.Text = "None";
			this.noFilterRadioButton.UseVisualStyleBackColor = true;
			this.noFilterRadioButton.CheckedChanged += new System.EventHandler(this.noFilterRadioButton_CheckedChanged);
			// 
			// stateRadioButton
			// 
			this.stateRadioButton.AutoSize = true;
			this.stateRadioButton.Location = new System.Drawing.Point(12, 35);
			this.stateRadioButton.Name = "stateRadioButton";
			this.stateRadioButton.Size = new System.Drawing.Size(128, 17);
			this.stateRadioButton.TabIndex = 1;
			this.stateRadioButton.TabStop = true;
			this.stateRadioButton.Text = "State in United States";
			this.stateRadioButton.UseVisualStyleBackColor = true;
			this.stateRadioButton.CheckedChanged += new System.EventHandler(this.stateRadioButton_CheckedChanged);
			// 
			// provinceRadioButton
			// 
			this.provinceRadioButton.AutoSize = true;
			this.provinceRadioButton.Location = new System.Drawing.Point(12, 58);
			this.provinceRadioButton.Name = "provinceRadioButton";
			this.provinceRadioButton.Size = new System.Drawing.Size(118, 17);
			this.provinceRadioButton.TabIndex = 2;
			this.provinceRadioButton.TabStop = true;
			this.provinceRadioButton.Text = "Province in Canada";
			this.provinceRadioButton.UseVisualStyleBackColor = true;
			this.provinceRadioButton.CheckedChanged += new System.EventHandler(this.provinceRadioButton_CheckedChanged);
			// 
			// familyRadioButton
			// 
			this.familyRadioButton.AutoSize = true;
			this.familyRadioButton.Location = new System.Drawing.Point(12, 104);
			this.familyRadioButton.Name = "familyRadioButton";
			this.familyRadioButton.Size = new System.Drawing.Size(54, 17);
			this.familyRadioButton.TabIndex = 4;
			this.familyRadioButton.TabStop = true;
			this.familyRadioButton.Text = "Family";
			this.familyRadioButton.UseVisualStyleBackColor = true;
			this.familyRadioButton.CheckedChanged += new System.EventHandler(this.familyRadioButton_CheckedChanged);
			// 
			// customListRadioButton
			// 
			this.customListRadioButton.AutoSize = true;
			this.customListRadioButton.Location = new System.Drawing.Point(12, 127);
			this.customListRadioButton.Name = "customListRadioButton";
			this.customListRadioButton.Size = new System.Drawing.Size(79, 17);
			this.customListRadioButton.TabIndex = 5;
			this.customListRadioButton.TabStop = true;
			this.customListRadioButton.Text = "Custom List";
			this.customListRadioButton.UseVisualStyleBackColor = true;
			this.customListRadioButton.CheckedChanged += new System.EventHandler(this.customListRadioButton_CheckedChanged);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(355, 303);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(436, 303);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// filterListView
			// 
			this.filterListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterListView.CheckBoxes = true;
			this.filterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
			this.filterListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.filterListView.HideSelection = false;
			this.filterListView.Location = new System.Drawing.Point(157, 12);
			this.filterListView.MultiSelect = false;
			this.filterListView.Name = "filterListView";
			this.filterListView.Size = new System.Drawing.Size(354, 280);
			this.filterListView.TabIndex = 7;
			this.filterListView.UseCompatibleStateImageBehavior = false;
			this.filterListView.View = System.Windows.Forms.View.Details;
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Name";
			this.nameColumnHeader.Width = 325;
			// 
			// filterOptionsGroupBox
			// 
			this.filterOptionsGroupBox.Controls.Add(this.commonBirdsRadioButton);
			this.filterOptionsGroupBox.Controls.Add(this.allBirdsRadioButton);
			this.filterOptionsGroupBox.Location = new System.Drawing.Point(12, 164);
			this.filterOptionsGroupBox.Name = "filterOptionsGroupBox";
			this.filterOptionsGroupBox.Size = new System.Drawing.Size(128, 69);
			this.filterOptionsGroupBox.TabIndex = 6;
			this.filterOptionsGroupBox.TabStop = false;
			this.filterOptionsGroupBox.Text = "Options";
			// 
			// commonBirdsRadioButton
			// 
			this.commonBirdsRadioButton.AutoSize = true;
			this.commonBirdsRadioButton.Location = new System.Drawing.Point(10, 42);
			this.commonBirdsRadioButton.Name = "commonBirdsRadioButton";
			this.commonBirdsRadioButton.Size = new System.Drawing.Size(113, 17);
			this.commonBirdsRadioButton.TabIndex = 1;
			this.commonBirdsRadioButton.TabStop = true;
			this.commonBirdsRadioButton.Text = "Common birds only";
			this.commonBirdsRadioButton.UseVisualStyleBackColor = true;
			// 
			// allBirdsRadioButton
			// 
			this.allBirdsRadioButton.AutoSize = true;
			this.allBirdsRadioButton.Location = new System.Drawing.Point(10, 19);
			this.allBirdsRadioButton.Name = "allBirdsRadioButton";
			this.allBirdsRadioButton.Size = new System.Drawing.Size(61, 17);
			this.allBirdsRadioButton.TabIndex = 0;
			this.allBirdsRadioButton.TabStop = true;
			this.allBirdsRadioButton.Text = "All birds";
			this.allBirdsRadioButton.UseVisualStyleBackColor = true;
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// regionRadioButton
			// 
			this.regionRadioButton.AutoSize = true;
			this.regionRadioButton.Location = new System.Drawing.Point(12, 81);
			this.regionRadioButton.Name = "regionRadioButton";
			this.regionRadioButton.Size = new System.Drawing.Size(59, 17);
			this.regionRadioButton.TabIndex = 3;
			this.regionRadioButton.TabStop = true;
			this.regionRadioButton.Text = "Region";
			this.regionRadioButton.UseVisualStyleBackColor = true;
			this.regionRadioButton.CheckedChanged += new System.EventHandler(this.regionRadioButton_CheckedChanged);
			// 
			// restoreFilterAtStartupCheckBox
			// 
			this.restoreFilterAtStartupCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.restoreFilterAtStartupCheckBox.AutoSize = true;
			this.restoreFilterAtStartupCheckBox.Location = new System.Drawing.Point(12, 309);
			this.restoreFilterAtStartupCheckBox.Name = "restoreFilterAtStartupCheckBox";
			this.restoreFilterAtStartupCheckBox.Size = new System.Drawing.Size(194, 17);
			this.restoreFilterAtStartupCheckBox.TabIndex = 10;
			this.restoreFilterAtStartupCheckBox.Text = "Restore last selected filter at startup";
			this.restoreFilterAtStartupCheckBox.UseVisualStyleBackColor = true;
			// 
			// FilterForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(524, 337);
			this.Controls.Add(this.restoreFilterAtStartupCheckBox);
			this.Controls.Add(this.regionRadioButton);
			this.Controls.Add(this.filterOptionsGroupBox);
			this.Controls.Add(this.filterListView);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.customListRadioButton);
			this.Controls.Add(this.familyRadioButton);
			this.Controls.Add(this.provinceRadioButton);
			this.Controls.Add(this.stateRadioButton);
			this.Controls.Add(this.noFilterRadioButton);
			this.helpProvider.SetHelpKeyword(this, "15");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FilterForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Filters";
			this.filterOptionsGroupBox.ResumeLayout(false);
			this.filterOptionsGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton noFilterRadioButton;
		private System.Windows.Forms.RadioButton stateRadioButton;
		private System.Windows.Forms.RadioButton provinceRadioButton;
		private System.Windows.Forms.RadioButton familyRadioButton;
		private System.Windows.Forms.RadioButton customListRadioButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ListView filterListView;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.GroupBox filterOptionsGroupBox;
		private System.Windows.Forms.RadioButton commonBirdsRadioButton;
		private System.Windows.Forms.RadioButton allBirdsRadioButton;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.RadioButton regionRadioButton;
		private System.Windows.Forms.CheckBox restoreFilterAtStartupCheckBox;
	}
}