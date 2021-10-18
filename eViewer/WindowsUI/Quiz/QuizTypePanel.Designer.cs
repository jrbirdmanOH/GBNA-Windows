namespace Thayer.Birding.UI.Windows.Quiz
{
    partial class QuizTypePanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizTypePanel));
			this.multipleChoiceRadioButton = new System.Windows.Forms.RadioButton();
			this.flashCardsRadioButton = new System.Windows.Forms.RadioButton();
			this.pickOneRadioButton = new System.Windows.Forms.RadioButton();
			this.quizLengthLabel = new System.Windows.Forms.Label();
			this.informationLabel = new System.Windows.Forms.Label();
			this.fillInTheBlankRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// multipleChoiceRadioButton
			// 
			this.multipleChoiceRadioButton.AutoSize = true;
			this.multipleChoiceRadioButton.Location = new System.Drawing.Point(29, 21);
			this.multipleChoiceRadioButton.Name = "multipleChoiceRadioButton";
			this.multipleChoiceRadioButton.Size = new System.Drawing.Size(97, 17);
			this.multipleChoiceRadioButton.TabIndex = 0;
			this.multipleChoiceRadioButton.TabStop = true;
			this.multipleChoiceRadioButton.Text = "&Multiple Choice";
			this.multipleChoiceRadioButton.UseVisualStyleBackColor = true;
			// 
			// flashCardsRadioButton
			// 
			this.flashCardsRadioButton.AutoSize = true;
			this.flashCardsRadioButton.Location = new System.Drawing.Point(29, 67);
			this.flashCardsRadioButton.Name = "flashCardsRadioButton";
			this.flashCardsRadioButton.Size = new System.Drawing.Size(80, 17);
			this.flashCardsRadioButton.TabIndex = 2;
			this.flashCardsRadioButton.TabStop = true;
			this.flashCardsRadioButton.Text = "Flash &Cards";
			this.flashCardsRadioButton.UseVisualStyleBackColor = true;
			// 
			// pickOneRadioButton
			// 
			this.pickOneRadioButton.AutoSize = true;
			this.pickOneRadioButton.Location = new System.Drawing.Point(29, 90);
			this.pickOneRadioButton.Name = "pickOneRadioButton";
			this.pickOneRadioButton.Size = new System.Drawing.Size(69, 17);
			this.pickOneRadioButton.TabIndex = 3;
			this.pickOneRadioButton.TabStop = true;
			this.pickOneRadioButton.Text = "&Pick One";
			this.pickOneRadioButton.UseVisualStyleBackColor = true;
			// 
			// quizLengthLabel
			// 
			this.quizLengthLabel.AutoSize = true;
			this.quizLengthLabel.Location = new System.Drawing.Point(5, 5);
			this.quizLengthLabel.Name = "quizLengthLabel";
			this.quizLengthLabel.Size = new System.Drawing.Size(409, 13);
			this.quizLengthLabel.TabIndex = 0;
			this.quizLengthLabel.Text = "Based on your selection, the quiz will be 25 species long plus duplicates, if req" +
				"uested.";
			// 
			// informationLabel
			// 
			this.informationLabel.Location = new System.Drawing.Point(5, 166);
			this.informationLabel.Name = "informationLabel";
			this.informationLabel.Size = new System.Drawing.Size(548, 64);
			this.informationLabel.TabIndex = 2;
			this.informationLabel.Text = resources.GetString("informationLabel.Text");
			// 
			// fillInTheBlankRadioButton
			// 
			this.fillInTheBlankRadioButton.AutoSize = true;
			this.fillInTheBlankRadioButton.Location = new System.Drawing.Point(29, 44);
			this.fillInTheBlankRadioButton.Name = "fillInTheBlankRadioButton";
			this.fillInTheBlankRadioButton.Size = new System.Drawing.Size(96, 17);
			this.fillInTheBlankRadioButton.TabIndex = 1;
			this.fillInTheBlankRadioButton.TabStop = true;
			this.fillInTheBlankRadioButton.Text = "&Fill in the Blank";
			this.fillInTheBlankRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fillInTheBlankRadioButton);
			this.groupBox1.Controls.Add(this.multipleChoiceRadioButton);
			this.groupBox1.Controls.Add(this.flashCardsRadioButton);
			this.groupBox1.Controls.Add(this.pickOneRadioButton);
			this.groupBox1.Location = new System.Drawing.Point(20, 33);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(297, 115);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "What kind of quiz would you like to take?";
			// 
			// QuizTypePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.informationLabel);
			this.Controls.Add(this.quizLengthLabel);
			this.Controls.Add(this.groupBox1);
			this.Name = "QuizTypePanel";
			this.Size = new System.Drawing.Size(558, 380);
			this.Load += new System.EventHandler(this.QuizTypePanel_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.RadioButton multipleChoiceRadioButton;
        private System.Windows.Forms.RadioButton flashCardsRadioButton;
		private System.Windows.Forms.RadioButton pickOneRadioButton;
		private System.Windows.Forms.Label quizLengthLabel;
		private System.Windows.Forms.Label informationLabel;
		private System.Windows.Forms.RadioButton fillInTheBlankRadioButton;
		private System.Windows.Forms.GroupBox groupBox1;
    }
}
