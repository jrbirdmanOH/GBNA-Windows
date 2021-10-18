namespace Thayer.Birding.UI.Windows.Quiz
{
    partial class QuizSelectPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label5;
			this.quizSelectTabControl = new System.Windows.Forms.TabControl();
			this.quizzesTabPage = new System.Windows.Forms.TabPage();
			this.createCustomListButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.quizTreeView = new System.Windows.Forms.TreeView();
			this.quizListView = new System.Windows.Forms.ListView();
			this.quizHeaderColumn = new System.Windows.Forms.ColumnHeader();
			this.quizViewGroupBox = new System.Windows.Forms.GroupBox();
			this.categoryRadioButton = new System.Windows.Forms.RadioButton();
			this.alphabeticalRadioButton = new System.Windows.Forms.RadioButton();
			this.locationsTabPage = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.locationTreeView = new Thayer.Birding.UI.Windows.LocationTreeView();
			this.groupsTabPage = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.taxonomyTreeView = new Thayer.Birding.UI.Windows.TaxonomyTreeView();
			this.customListsTabPage = new System.Windows.Forms.TabPage();
			this.customListView = new System.Windows.Forms.ListView();
			this.nameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.lengthColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.myQuizzesTabPage = new System.Windows.Forms.TabPage();
			this.customQuizTreeView = new System.Windows.Forms.TreeView();
			this.instructionsLabel = new System.Windows.Forms.Label();
			this.freeQuizzesLinkLabel = new System.Windows.Forms.LinkLabel();
			label5 = new System.Windows.Forms.Label();
			this.quizSelectTabControl.SuspendLayout();
			this.quizzesTabPage.SuspendLayout();
			this.quizViewGroupBox.SuspendLayout();
			this.locationsTabPage.SuspendLayout();
			this.groupsTabPage.SuspendLayout();
			this.customListsTabPage.SuspendLayout();
			this.myQuizzesTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label5.Location = new System.Drawing.Point(7, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(253, 13);
			label5.TabIndex = 8;
			label5.Text = "Select one of the following custom quizzes.";
			// 
			// quizSelectTabControl
			// 
			this.quizSelectTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.quizSelectTabControl.Controls.Add(this.quizzesTabPage);
			this.quizSelectTabControl.Controls.Add(this.locationsTabPage);
			this.quizSelectTabControl.Controls.Add(this.groupsTabPage);
			this.quizSelectTabControl.Controls.Add(this.customListsTabPage);
			this.quizSelectTabControl.Controls.Add(this.myQuizzesTabPage);
			this.quizSelectTabControl.Location = new System.Drawing.Point(0, 28);
			this.quizSelectTabControl.Name = "quizSelectTabControl";
			this.quizSelectTabControl.SelectedIndex = 0;
			this.quizSelectTabControl.Size = new System.Drawing.Size(558, 349);
			this.quizSelectTabControl.TabIndex = 1;
			this.quizSelectTabControl.SelectedIndexChanged += new System.EventHandler(this.quizSelectTabControl_SelectedIndexChanged);
			// 
			// quizzesTabPage
			// 
			this.quizzesTabPage.Controls.Add(this.createCustomListButton);
			this.quizzesTabPage.Controls.Add(this.label1);
			this.quizzesTabPage.Controls.Add(this.quizTreeView);
			this.quizzesTabPage.Controls.Add(this.quizListView);
			this.quizzesTabPage.Controls.Add(this.quizViewGroupBox);
			this.quizzesTabPage.Location = new System.Drawing.Point(4, 22);
			this.quizzesTabPage.Name = "quizzesTabPage";
			this.quizzesTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.quizzesTabPage.Size = new System.Drawing.Size(550, 323);
			this.quizzesTabPage.TabIndex = 0;
			this.quizzesTabPage.Text = "Favorite Quizzes";
			this.quizzesTabPage.UseVisualStyleBackColor = true;
			// 
			// createCustomListButton
			// 
			this.createCustomListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.createCustomListButton.Location = new System.Drawing.Point(426, 18);
			this.createCustomListButton.Name = "createCustomListButton";
			this.createCustomListButton.Size = new System.Drawing.Size(113, 23);
			this.createCustomListButton.TabIndex = 8;
			this.createCustomListButton.Text = "Create Custom List...";
			this.createCustomListButton.UseVisualStyleBackColor = true;
			this.createCustomListButton.Click += new System.EventHandler(this.createCustomListButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(570, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Expand any of the quiz categories below and click on a quiz to select.  (Click th" +
				"e + sign to expand)";
			// 
			// quizTreeView
			// 
			this.quizTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.quizTreeView.HideSelection = false;
			this.quizTreeView.Location = new System.Drawing.Point(10, 69);
			this.quizTreeView.Name = "quizTreeView";
			this.quizTreeView.Size = new System.Drawing.Size(529, 244);
			this.quizTreeView.TabIndex = 6;
			this.quizTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.quizTreeView_AfterSelect);
			// 
			// quizListView
			// 
			this.quizListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.quizListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.quizHeaderColumn});
			this.quizListView.FullRowSelect = true;
			this.quizListView.HideSelection = false;
			this.quizListView.Location = new System.Drawing.Point(10, 69);
			this.quizListView.MultiSelect = false;
			this.quizListView.Name = "quizListView";
			this.quizListView.Size = new System.Drawing.Size(529, 244);
			this.quizListView.TabIndex = 7;
			this.quizListView.UseCompatibleStateImageBehavior = false;
			this.quizListView.View = System.Windows.Forms.View.Details;
			this.quizListView.SelectedIndexChanged += new System.EventHandler(this.quizListView_SelectedIndexChanged);
			this.quizListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.quizListView_ColumnClick);
			// 
			// quizHeaderColumn
			// 
			this.quizHeaderColumn.Text = "Quiz";
			this.quizHeaderColumn.Width = 6;
			// 
			// quizViewGroupBox
			// 
			this.quizViewGroupBox.Controls.Add(this.categoryRadioButton);
			this.quizViewGroupBox.Controls.Add(this.alphabeticalRadioButton);
			this.quizViewGroupBox.Location = new System.Drawing.Point(10, 5);
			this.quizViewGroupBox.Name = "quizViewGroupBox";
			this.quizViewGroupBox.Size = new System.Drawing.Size(267, 39);
			this.quizViewGroupBox.TabIndex = 2;
			this.quizViewGroupBox.TabStop = false;
			this.quizViewGroupBox.Text = "Quiz View";
			// 
			// categoryRadioButton
			// 
			this.categoryRadioButton.AutoSize = true;
			this.categoryRadioButton.Location = new System.Drawing.Point(10, 16);
			this.categoryRadioButton.Name = "categoryRadioButton";
			this.categoryRadioButton.Size = new System.Drawing.Size(113, 17);
			this.categoryRadioButton.TabIndex = 3;
			this.categoryRadioButton.TabStop = true;
			this.categoryRadioButton.Text = "Group by &Category";
			this.categoryRadioButton.UseVisualStyleBackColor = true;
			this.categoryRadioButton.Click += new System.EventHandler(this.categoryRadioButton_Click);
			// 
			// alphabeticalRadioButton
			// 
			this.alphabeticalRadioButton.AutoSize = true;
			this.alphabeticalRadioButton.Location = new System.Drawing.Point(134, 16);
			this.alphabeticalRadioButton.Name = "alphabeticalRadioButton";
			this.alphabeticalRadioButton.Size = new System.Drawing.Size(109, 17);
			this.alphabeticalRadioButton.TabIndex = 4;
			this.alphabeticalRadioButton.TabStop = true;
			this.alphabeticalRadioButton.Text = "List &Alphabetically";
			this.alphabeticalRadioButton.UseVisualStyleBackColor = true;
			this.alphabeticalRadioButton.Click += new System.EventHandler(this.alphabeticalRadioButton_Click);
			// 
			// locationsTabPage
			// 
			this.locationsTabPage.Controls.Add(this.label3);
			this.locationsTabPage.Controls.Add(this.locationTreeView);
			this.locationsTabPage.Location = new System.Drawing.Point(4, 22);
			this.locationsTabPage.Name = "locationsTabPage";
			this.locationsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.locationsTabPage.Size = new System.Drawing.Size(550, 323);
			this.locationsTabPage.TabIndex = 1;
			this.locationsTabPage.Text = "Locations";
			this.locationsTabPage.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(7, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Select one or more of the following locations.";
			// 
			// locationTreeView
			// 
			this.locationTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.locationTreeView.Location = new System.Drawing.Point(10, 27);
			this.locationTreeView.Name = "locationTreeView";
			this.locationTreeView.Size = new System.Drawing.Size(529, 286);
			this.locationTreeView.TabIndex = 0;
			this.locationTreeView.ExcludeRareBirdsCheckedChanged += new System.EventHandler(this.locationTreeView_ExcludeRareBirdsCheckedChanged);
			this.locationTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.locationTreeView_AfterCheck);
			// 
			// groupsTabPage
			// 
			this.groupsTabPage.Controls.Add(this.label4);
			this.groupsTabPage.Controls.Add(this.taxonomyTreeView);
			this.groupsTabPage.Location = new System.Drawing.Point(4, 22);
			this.groupsTabPage.Name = "groupsTabPage";
			this.groupsTabPage.Size = new System.Drawing.Size(550, 323);
			this.groupsTabPage.TabIndex = 2;
			this.groupsTabPage.Text = " Bird Groups";
			this.groupsTabPage.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(7, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(312, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Select one or more of the following taxonomic groups.";
			// 
			// taxonomyTreeView
			// 
			this.taxonomyTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.taxonomyTreeView.CheckBoxes = true;
			this.taxonomyTreeView.HideSelection = false;
			this.taxonomyTreeView.ImageIndex = 0;
			this.taxonomyTreeView.Location = new System.Drawing.Point(10, 27);
			this.taxonomyTreeView.Name = "taxonomyTreeView";
			this.taxonomyTreeView.SelectedImageIndex = 0;
			this.taxonomyTreeView.Size = new System.Drawing.Size(529, 286);
			this.taxonomyTreeView.TabIndex = 0;
			this.taxonomyTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.taxonomyTreeView_AfterCheck);
			// 
			// customListsTabPage
			// 
			this.customListsTabPage.Controls.Add(this.customListView);
			this.customListsTabPage.Controls.Add(this.label2);
			this.customListsTabPage.Location = new System.Drawing.Point(4, 22);
			this.customListsTabPage.Name = "customListsTabPage";
			this.customListsTabPage.Size = new System.Drawing.Size(550, 323);
			this.customListsTabPage.TabIndex = 3;
			this.customListsTabPage.Text = "Custom Lists";
			this.customListsTabPage.UseVisualStyleBackColor = true;
			// 
			// customListView
			// 
			this.customListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.customListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.lengthColumnHeader});
			this.customListView.FullRowSelect = true;
			this.customListView.HideSelection = false;
			this.customListView.Location = new System.Drawing.Point(10, 27);
			this.customListView.MultiSelect = false;
			this.customListView.Name = "customListView";
			this.customListView.ShowItemToolTips = true;
			this.customListView.Size = new System.Drawing.Size(529, 286);
			this.customListView.TabIndex = 7;
			this.customListView.UseCompatibleStateImageBehavior = false;
			this.customListView.View = System.Windows.Forms.View.Details;
			this.customListView.SelectedIndexChanged += new System.EventHandler(this.customListView_SelectedIndexChanged);
			this.customListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.customListView_ColumnClick);
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Name";
			// 
			// lengthColumnHeader
			// 
			this.lengthColumnHeader.Text = "Length";
			this.lengthColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.lengthColumnHeader.Width = 50;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(233, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Select one of the following custom lists.";
			// 
			// myQuizzesTabPage
			// 
			this.myQuizzesTabPage.Controls.Add(this.customQuizTreeView);
			this.myQuizzesTabPage.Controls.Add(label5);
			this.myQuizzesTabPage.Location = new System.Drawing.Point(4, 22);
			this.myQuizzesTabPage.Name = "myQuizzesTabPage";
			this.myQuizzesTabPage.Size = new System.Drawing.Size(550, 323);
			this.myQuizzesTabPage.TabIndex = 4;
			this.myQuizzesTabPage.Text = "My Quizzes";
			this.myQuizzesTabPage.UseVisualStyleBackColor = true;
			// 
			// customQuizTreeView
			// 
			this.customQuizTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.customQuizTreeView.HideSelection = false;
			this.customQuizTreeView.Location = new System.Drawing.Point(10, 27);
			this.customQuizTreeView.Name = "customQuizTreeView";
			this.customQuizTreeView.Size = new System.Drawing.Size(529, 286);
			this.customQuizTreeView.TabIndex = 9;
			this.customQuizTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.customQuizTreeView_AfterSelect);
			// 
			// instructionsLabel
			// 
			this.instructionsLabel.AutoSize = true;
			this.instructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.instructionsLabel.Location = new System.Drawing.Point(0, 0);
			this.instructionsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.instructionsLabel.Name = "instructionsLabel";
			this.instructionsLabel.Size = new System.Drawing.Size(276, 13);
			this.instructionsLabel.TabIndex = 0;
			this.instructionsLabel.Text = "Select one of the following sources for quizzes.";
			// 
			// freeQuizzesLinkLabel
			// 
			this.freeQuizzesLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.freeQuizzesLinkLabel.AutoSize = true;
			this.freeQuizzesLinkLabel.Location = new System.Drawing.Point(451, 0);
			this.freeQuizzesLinkLabel.Name = "freeQuizzesLinkLabel";
			this.freeQuizzesLinkLabel.Size = new System.Drawing.Size(103, 13);
			this.freeQuizzesLinkLabel.TabIndex = 2;
			this.freeQuizzesLinkLabel.TabStop = true;
			this.freeQuizzesLinkLabel.Text = "Get 40 Free Quizzes";
			this.freeQuizzesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.freeQuizzesLinkLabel_LinkClicked);
			// 
			// QuizSelectPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.freeQuizzesLinkLabel);
			this.Controls.Add(this.instructionsLabel);
			this.Controls.Add(this.quizSelectTabControl);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "QuizSelectPanel";
			this.Size = new System.Drawing.Size(558, 380);
			this.Load += new System.EventHandler(this.QuizSelectPanel_Load);
			this.quizSelectTabControl.ResumeLayout(false);
			this.quizzesTabPage.ResumeLayout(false);
			this.quizzesTabPage.PerformLayout();
			this.quizViewGroupBox.ResumeLayout(false);
			this.quizViewGroupBox.PerformLayout();
			this.locationsTabPage.ResumeLayout(false);
			this.locationsTabPage.PerformLayout();
			this.groupsTabPage.ResumeLayout(false);
			this.groupsTabPage.PerformLayout();
			this.customListsTabPage.ResumeLayout(false);
			this.customListsTabPage.PerformLayout();
			this.myQuizzesTabPage.ResumeLayout(false);
			this.myQuizzesTabPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl quizSelectTabControl;
        private System.Windows.Forms.TabPage quizzesTabPage;
        private System.Windows.Forms.TabPage locationsTabPage;
        private System.Windows.Forms.TabPage groupsTabPage;
        private System.Windows.Forms.TabPage customListsTabPage;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.TreeView quizTreeView;
        private System.Windows.Forms.Label label1;
        private LocationTreeView locationTreeView;
        private TaxonomyTreeView taxonomyTreeView;
        private System.Windows.Forms.ListView quizListView;
        private System.Windows.Forms.ColumnHeader quizHeaderColumn;
        private System.Windows.Forms.RadioButton alphabeticalRadioButton;
        private System.Windows.Forms.RadioButton categoryRadioButton;
        private System.Windows.Forms.GroupBox quizViewGroupBox;
        private System.Windows.Forms.ListView customListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader lengthColumnHeader;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage myQuizzesTabPage;
		private System.Windows.Forms.TreeView customQuizTreeView;
		private System.Windows.Forms.LinkLabel freeQuizzesLinkLabel;
		private System.Windows.Forms.Button createCustomListButton;

    }
}
