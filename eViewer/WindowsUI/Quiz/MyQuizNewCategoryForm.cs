using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizNewCategoryForm : BaseForm
	{
		private CustomQuizCategory category = null;
		private bool addItems = false;

		public MyQuizNewCategoryForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public CustomQuizCategory Category
		{
			get
			{
				return category;
			}
		}

		public bool AddItems
		{
			get
			{
				return addItems;
			}
		}

		private string CategoryName
		{
			get
			{
				return nameTextBox.Text.Trim();
			}
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			if (CreateCategory(false))
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void createAndAddItemsButton_Click(object sender, EventArgs e)
		{
			if (CreateCategory(true))
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private bool CreateCategory(bool addItems)
		{
			bool result = false;

			if (IsValid())
			{
				this.addItems = addItems;

				// Save the category
				category = new CustomQuizCategory();
				category.Name = this.CategoryName;
				category.Save();

				result = true;
			}

			return result;
		}

		private bool IsValid()
		{
			bool isValid = true;

			if (this.CategoryName.Length == 0)
			{
				isValid = false;
				MessageBox.Show("Please specify a category name.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return isValid;
		}
	}
}