using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class CustomListEditForm : BaseForm
	{
		private CustomList customList = null;

		public CustomListEditForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public CustomList CustomList
		{
			get
			{
				return customList;
			}

			set
			{
				customList = value;

				nameTextBox.Text = customList.Name;
				authorTextBox.Text = customList.Author;
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (IsValid(true))
			{
				customList.Name = nameTextBox.Text;
				customList.Author = authorTextBox.Text;

				customList.Save();

				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private bool IsValid(bool showMessage)
		{
			bool isValid = false;

			string name = nameTextBox.Text;
//			string author = authorTextBox.Text;

			if (name.Length > 0)
			{
				isValid = true;
			}
			else
			{
				isValid = false;
				if (showMessage)
				{
					MessageBox.Show("Please specify a custom list name.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					nameTextBox.Focus();
				}
			}
/*
			if (isValid)
			{
				if (author.Length > 0)
				{
					isValid = true;
				}
				else
				{
					isValid = false;
					if (showMessage)
					{
						MessageBox.Show("Please specify an author.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						authorTextBox.Focus();
					}
				}
			}
*/
			return isValid;
		}
	}
}