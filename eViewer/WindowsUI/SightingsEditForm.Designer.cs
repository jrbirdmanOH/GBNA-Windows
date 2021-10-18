namespace Thayer.Birding.UI.Windows
{
	partial class SightingsEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.observerComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.newObserverButton = new System.Windows.Forms.Button();
            this.organismComboBox = new Thayer.Birding.UI.Windows.OrganismComboBox();
            this.saveAndAddButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(71, 39);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(251, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location:";
            // 
            // locationComboBox
            // 
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(71, 65);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(251, 21);
            this.locationComboBox.Sorted = true;
            this.locationComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Comments:";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(71, 92);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(251, 99);
            this.commentsTextBox.TabIndex = 7;
            // 
            // observerComboBox
            // 
            this.observerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.observerComboBox.FormattingEnabled = true;
            this.observerComboBox.Location = new System.Drawing.Point(71, 197);
            this.observerComboBox.Name = "observerComboBox";
            this.observerComboBox.Size = new System.Drawing.Size(189, 21);
            this.observerComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Observer:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(247, 246);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(55, 246);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.toolTip.SetToolTip(this.okButton, "Save current sighting and close");
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "eViewer.chm";
            // 
            // newObserverButton
            // 
            this.newObserverButton.Location = new System.Drawing.Point(266, 195);
            this.newObserverButton.Name = "newObserverButton";
            this.newObserverButton.Size = new System.Drawing.Size(56, 23);
            this.newObserverButton.TabIndex = 10;
            this.newObserverButton.Text = "New...";
            this.toolTip.SetToolTip(this.newObserverButton, "Create new observer");
            this.newObserverButton.UseVisualStyleBackColor = true;
            this.newObserverButton.Click += new System.EventHandler(this.newObserverButton_Click);
            // 
            // organismComboBox
            // 
            this.organismComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.organismComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.organismComboBox.FormattingEnabled = true;
            this.organismComboBox.Location = new System.Drawing.Point(71, 12);
            this.organismComboBox.Name = "organismComboBox";
            this.organismComboBox.Size = new System.Drawing.Size(251, 21);
            this.organismComboBox.TabIndex = 1;
            // 
            // saveAndAddButton
            // 
            this.saveAndAddButton.Location = new System.Drawing.Point(136, 246);
            this.saveAndAddButton.Name = "saveAndAddButton";
            this.saveAndAddButton.Size = new System.Drawing.Size(105, 23);
            this.saveAndAddButton.TabIndex = 12;
            this.saveAndAddButton.Text = "Save and Add...";
            this.toolTip.SetToolTip(this.saveAndAddButton, "Save current sighting and add more");
            this.saveAndAddButton.UseVisualStyleBackColor = true;
            this.saveAndAddButton.Click += new System.EventHandler(this.saveAndAddButton_Click);
            // 
            // SightingsEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(334, 281);
            this.Controls.Add(this.saveAndAddButton);
            this.Controls.Add(this.newObserverButton);
            this.Controls.Add(this.organismComboBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.observerComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.helpProvider.SetHelpKeyword(this, "11");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SightingsEditForm";
            this.helpProvider.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sighting";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox locationComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox commentsTextBox;
		private System.Windows.Forms.ComboBox observerComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private OrganismComboBox organismComboBox;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button newObserverButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button saveAndAddButton;
	}
}