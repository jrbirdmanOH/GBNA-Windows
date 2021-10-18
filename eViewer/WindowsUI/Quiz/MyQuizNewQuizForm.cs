using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizNewQuizForm : BaseForm
	{
		private CustomQuizCategory category = null;
		private CustomQuiz quiz = null;
		private bool addQuestions = false;

		public MyQuizNewQuizForm(CustomQuizCategory category)
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			this.category = category;
		}

		public CustomQuiz Quiz
		{
			get
			{
				return quiz;
			}
		}

		public bool AddQuestions
		{
			get
			{
				return addQuestions;
			}
		}

		private string QuizName
		{
			get
			{
				return nameTextBox.Text.Trim();
			}
		}

		private string Author
		{
			get
			{
				return authorTextBox.Text.Trim();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			categoryNameLabel.Text = category.Name;
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			if (CreateQuiz(false))
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void createAndAddQuestionsButton_Click(object sender, EventArgs e)
		{
			if (CreateQuiz(true))
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private bool CreateQuiz(bool addQuestions)
		{
			bool result = false;

			if (IsValid())
			{
				this.addQuestions = addQuestions;

				// Save the quiz
				quiz = new CustomQuiz();
				quiz.Name = this.QuizName;
				quiz.Author = this.Author;
				quiz.CategoryID = category.ID;
				quiz.Save();

				result = true;
			}

			return result;
		}

		private bool IsValid()
		{
			bool isValid = true;

			if (this.QuizName.Length == 0)
			{
				isValid = false;
				MessageBox.Show("Please specify a quiz name.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return isValid;
		}
	}
}