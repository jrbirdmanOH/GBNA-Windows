namespace Thayer.Birding.UI.Windows
{
	partial class SightingsReportsForm
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
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			this.sightingsOrderComboBox = new System.Windows.Forms.ComboBox();
			this.groupByGroupBox = new System.Windows.Forms.GroupBox();
			this.byLocationRadioButton = new System.Windows.Forms.RadioButton();
			this.byFamilyRadioButton = new System.Windows.Forms.RadioButton();
			this.noneRadioButton = new System.Windows.Forms.RadioButton();
			this.enforceEndDateCheckBox = new System.Windows.Forms.CheckBox();
			this.enforceStartDateCheckBox = new System.Windows.Forms.CheckBox();
			this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.observerComboBox = new System.Windows.Forms.ComboBox();
			this.lifeListOrderComboBox = new System.Windows.Forms.ComboBox();
			this.lifeListReportRadioButton = new System.Windows.Forms.RadioButton();
			this.sightingsReportRadioButton = new System.Windows.Forms.RadioButton();
			this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.previewReportButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.printButton = new System.Windows.Forms.Button();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.birdersDiaryLinkLabel = new System.Windows.Forms.LinkLabel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			this.groupByGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupBox1.Controls.Add(this.sightingsOrderComboBox);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(this.groupByGroupBox);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(this.enforceEndDateCheckBox);
			groupBox1.Controls.Add(this.enforceStartDateCheckBox);
			groupBox1.Controls.Add(this.endDateTimePicker);
			groupBox1.Controls.Add(this.startDateTimePicker);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(this.observerComboBox);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(this.lifeListOrderComboBox);
			groupBox1.Controls.Add(this.lifeListReportRadioButton);
			groupBox1.Controls.Add(this.sightingsReportRadioButton);
			groupBox1.Location = new System.Drawing.Point(12, 388);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(750, 103);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Report Selection";
			// 
			// sightingsOrderComboBox
			// 
			this.sightingsOrderComboBox.FormattingEnabled = true;
			this.sightingsOrderComboBox.Location = new System.Drawing.Point(392, 35);
			this.sightingsOrderComboBox.Name = "sightingsOrderComboBox";
			this.sightingsOrderComboBox.Size = new System.Drawing.Size(130, 21);
			this.sightingsOrderComboBox.TabIndex = 4;
			this.sightingsOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.sightingsOrderComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(350, 38);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(36, 13);
			label6.TabIndex = 3;
			label6.Text = "Order:";
			// 
			// groupByGroupBox
			// 
			this.groupByGroupBox.Controls.Add(this.byLocationRadioButton);
			this.groupByGroupBox.Controls.Add(this.byFamilyRadioButton);
			this.groupByGroupBox.Controls.Add(this.noneRadioButton);
			this.groupByGroupBox.Location = new System.Drawing.Point(115, 20);
			this.groupByGroupBox.Name = "groupByGroupBox";
			this.groupByGroupBox.Size = new System.Drawing.Size(227, 39);
			this.groupByGroupBox.TabIndex = 2;
			this.groupByGroupBox.TabStop = false;
			this.groupByGroupBox.Text = "Group By";
			// 
			// byLocationRadioButton
			// 
			this.byLocationRadioButton.AutoSize = true;
			this.byLocationRadioButton.Location = new System.Drawing.Point(129, 16);
			this.byLocationRadioButton.Name = "byLocationRadioButton";
			this.byLocationRadioButton.Size = new System.Drawing.Size(66, 17);
			this.byLocationRadioButton.TabIndex = 2;
			this.byLocationRadioButton.TabStop = true;
			this.byLocationRadioButton.Text = "Location";
			this.byLocationRadioButton.UseVisualStyleBackColor = true;
			this.byLocationRadioButton.CheckedChanged += new System.EventHandler(this.byLocationRadioButton_CheckedChanged);
			// 
			// byFamilyRadioButton
			// 
			this.byFamilyRadioButton.AutoSize = true;
			this.byFamilyRadioButton.Location = new System.Drawing.Point(67, 16);
			this.byFamilyRadioButton.Name = "byFamilyRadioButton";
			this.byFamilyRadioButton.Size = new System.Drawing.Size(54, 17);
			this.byFamilyRadioButton.TabIndex = 1;
			this.byFamilyRadioButton.TabStop = true;
			this.byFamilyRadioButton.Text = "Family";
			this.byFamilyRadioButton.UseVisualStyleBackColor = true;
			this.byFamilyRadioButton.CheckedChanged += new System.EventHandler(this.byFamilyRadioButton_CheckedChanged);
			// 
			// noneRadioButton
			// 
			this.noneRadioButton.AutoSize = true;
			this.noneRadioButton.Location = new System.Drawing.Point(8, 16);
			this.noneRadioButton.Name = "noneRadioButton";
			this.noneRadioButton.Size = new System.Drawing.Size(51, 17);
			this.noneRadioButton.TabIndex = 0;
			this.noneRadioButton.TabStop = true;
			this.noneRadioButton.Text = "None";
			this.noneRadioButton.UseVisualStyleBackColor = true;
			this.noneRadioButton.CheckedChanged += new System.EventHandler(this.noneRadioButton_CheckedChanged);
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label5.Location = new System.Drawing.Point(700, 17);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 13);
			label5.TabIndex = 9;
			label5.Text = "Enforce";
			// 
			// enforceEndDateCheckBox
			// 
			this.enforceEndDateCheckBox.AutoSize = true;
			this.enforceEndDateCheckBox.Location = new System.Drawing.Point(714, 71);
			this.enforceEndDateCheckBox.Name = "enforceEndDateCheckBox";
			this.enforceEndDateCheckBox.Size = new System.Drawing.Size(15, 14);
			this.enforceEndDateCheckBox.TabIndex = 15;
			this.enforceEndDateCheckBox.UseVisualStyleBackColor = true;
			this.enforceEndDateCheckBox.CheckedChanged += new System.EventHandler(this.enforceEndDateCheckBox_CheckedChanged);
			// 
			// enforceStartDateCheckBox
			// 
			this.enforceStartDateCheckBox.AutoSize = true;
			this.enforceStartDateCheckBox.Location = new System.Drawing.Point(714, 37);
			this.enforceStartDateCheckBox.Name = "enforceStartDateCheckBox";
			this.enforceStartDateCheckBox.Size = new System.Drawing.Size(15, 14);
			this.enforceStartDateCheckBox.TabIndex = 12;
			this.enforceStartDateCheckBox.UseVisualStyleBackColor = true;
			this.enforceStartDateCheckBox.CheckedChanged += new System.EventHandler(this.enforceStartDateCheckBox_CheckedChanged);
			// 
			// endDateTimePicker
			// 
			this.endDateTimePicker.CustomFormat = "MM/dd/yyyy";
			this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.endDateTimePicker.Location = new System.Drawing.Point(590, 68);
			this.endDateTimePicker.Name = "endDateTimePicker";
			this.endDateTimePicker.Size = new System.Drawing.Size(110, 20);
			this.endDateTimePicker.TabIndex = 14;
			this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
			// 
			// startDateTimePicker
			// 
			this.startDateTimePicker.CustomFormat = "MM/dd/yyyy";
			this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.startDateTimePicker.Location = new System.Drawing.Point(590, 34);
			this.startDateTimePicker.Name = "startDateTimePicker";
			this.startDateTimePicker.Size = new System.Drawing.Size(110, 20);
			this.startDateTimePicker.TabIndex = 11;
			this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(530, 71);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(55, 13);
			label4.TabIndex = 13;
			label4.Text = "End Date:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(527, 39);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(58, 13);
			label3.TabIndex = 10;
			label3.Text = "Start Date:";
			// 
			// observerComboBox
			// 
			this.observerComboBox.FormattingEnabled = true;
			this.observerComboBox.Location = new System.Drawing.Point(179, 68);
			this.observerComboBox.Name = "observerComboBox";
			this.observerComboBox.Size = new System.Drawing.Size(163, 21);
			this.observerComboBox.TabIndex = 6;
			this.observerComboBox.SelectedIndexChanged += new System.EventHandler(this.observerComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(120, 71);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(53, 13);
			label2.TabIndex = 5;
			label2.Text = "Observer:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(350, 71);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(36, 13);
			label1.TabIndex = 7;
			label1.Text = "Order:";
			// 
			// lifeListOrderComboBox
			// 
			this.lifeListOrderComboBox.FormattingEnabled = true;
			this.lifeListOrderComboBox.Location = new System.Drawing.Point(392, 68);
			this.lifeListOrderComboBox.Name = "lifeListOrderComboBox";
			this.lifeListOrderComboBox.Size = new System.Drawing.Size(130, 21);
			this.lifeListOrderComboBox.TabIndex = 8;
			this.lifeListOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.lifeListOrderComboBox_SelectedIndexChanged);
			// 
			// lifeListReportRadioButton
			// 
			this.lifeListReportRadioButton.AutoSize = true;
			this.lifeListReportRadioButton.Location = new System.Drawing.Point(6, 69);
			this.lifeListReportRadioButton.Name = "lifeListReportRadioButton";
			this.lifeListReportRadioButton.Size = new System.Drawing.Size(96, 17);
			this.lifeListReportRadioButton.TabIndex = 1;
			this.lifeListReportRadioButton.TabStop = true;
			this.lifeListReportRadioButton.Text = "Life List Report";
			this.lifeListReportRadioButton.UseVisualStyleBackColor = true;
			this.lifeListReportRadioButton.CheckedChanged += new System.EventHandler(this.lifeListReportRadioButton_CheckedChanged);
			// 
			// sightingsReportRadioButton
			// 
			this.sightingsReportRadioButton.AutoSize = true;
			this.sightingsReportRadioButton.Location = new System.Drawing.Point(6, 35);
			this.sightingsReportRadioButton.Name = "sightingsReportRadioButton";
			this.sightingsReportRadioButton.Size = new System.Drawing.Size(103, 17);
			this.sightingsReportRadioButton.TabIndex = 0;
			this.sightingsReportRadioButton.TabStop = true;
			this.sightingsReportRadioButton.Text = "Sightings Report";
			this.sightingsReportRadioButton.UseVisualStyleBackColor = true;
			this.sightingsReportRadioButton.CheckedChanged += new System.EventHandler(this.sightingsReportRadioButton_CheckedChanged);
			// 
			// crystalReportViewer
			// 
			this.crystalReportViewer.ActiveViewIndex = -1;
			this.crystalReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer.DisplayGroupTree = false;
			this.crystalReportViewer.Location = new System.Drawing.Point(12, 12);
			this.crystalReportViewer.Name = "crystalReportViewer";
			this.crystalReportViewer.ShowCloseButton = false;
			this.crystalReportViewer.ShowGroupTreeButton = false;
			this.crystalReportViewer.Size = new System.Drawing.Size(750, 370);
			this.crystalReportViewer.TabIndex = 0;
			// 
			// previewReportButton
			// 
			this.previewReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.previewReportButton.Location = new System.Drawing.Point(501, 500);
			this.previewReportButton.Name = "previewReportButton";
			this.previewReportButton.Size = new System.Drawing.Size(99, 23);
			this.previewReportButton.TabIndex = 3;
			this.previewReportButton.Text = "Preview &Report";
			this.previewReportButton.UseVisualStyleBackColor = true;
			this.previewReportButton.Click += new System.EventHandler(this.previewReportButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(687, 500);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 5;
			this.closeButton.Text = "&Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// printButton
			// 
			this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.printButton.Location = new System.Drawing.Point(606, 500);
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(75, 23);
			this.printButton.TabIndex = 4;
			this.printButton.Text = "&Print";
			this.printButton.UseVisualStyleBackColor = true;
			this.printButton.Click += new System.EventHandler(this.printButton_Click);
			// 
			// helpProvider
			// 
			this.helpProvider.HelpNamespace = "eViewer.chm";
			// 
			// birdersDiaryLinkLabel
			// 
			this.birdersDiaryLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.birdersDiaryLinkLabel.AutoSize = true;
			this.birdersDiaryLinkLabel.Location = new System.Drawing.Point(9, 505);
			this.birdersDiaryLinkLabel.Name = "birdersDiaryLinkLabel";
			this.birdersDiaryLinkLabel.Size = new System.Drawing.Size(124, 13);
			this.birdersDiaryLinkLabel.TabIndex = 2;
			this.birdersDiaryLinkLabel.TabStop = true;
			this.birdersDiaryLinkLabel.Text = "Upgrade to Birder\'s Diary";
			this.birdersDiaryLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.birdersDiaryLinkLabel_LinkClicked);
			// 
			// SightingsReportsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 539);
			this.Controls.Add(this.birdersDiaryLinkLabel);
			this.Controls.Add(this.printButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.previewReportButton);
			this.Controls.Add(groupBox1);
			this.Controls.Add(this.crystalReportViewer);
			this.helpProvider.SetHelpKeyword(this, "10");
			this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "SightingsReportsForm";
			this.helpProvider.SetShowHelp(this, true);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sightings Reports";
			this.Load += new System.EventHandler(this.SightingsReportsForm_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			this.groupByGroupBox.ResumeLayout(false);
			this.groupByGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
		private System.Windows.Forms.RadioButton lifeListReportRadioButton;
		private System.Windows.Forms.RadioButton sightingsReportRadioButton;
		private System.Windows.Forms.ComboBox lifeListOrderComboBox;
		private System.Windows.Forms.ComboBox observerComboBox;
		private System.Windows.Forms.DateTimePicker endDateTimePicker;
		private System.Windows.Forms.DateTimePicker startDateTimePicker;
		private System.Windows.Forms.Button previewReportButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button printButton;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.CheckBox enforceEndDateCheckBox;
		private System.Windows.Forms.CheckBox enforceStartDateCheckBox;
		private System.Windows.Forms.LinkLabel birdersDiaryLinkLabel;
		private System.Windows.Forms.GroupBox groupByGroupBox;
		private System.Windows.Forms.RadioButton byLocationRadioButton;
		private System.Windows.Forms.RadioButton byFamilyRadioButton;
		private System.Windows.Forms.RadioButton noneRadioButton;
		private System.Windows.Forms.ComboBox sightingsOrderComboBox;
	}
}