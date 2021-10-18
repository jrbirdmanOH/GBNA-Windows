using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizCopyToCategoryForm : BaseForm
	{
		private CustomQuizCategory sourceCategory = null;
		private List<CustomThing> sourceCustomThings = null;

		public MyQuizCopyToCategoryForm(CustomQuizCategory sourceCategory, List<CustomThing> sourceCustomThings)
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			this.sourceCategory = sourceCategory;
			this.sourceCustomThings = sourceCustomThings;
		}

		public CustomQuizCategory SourceCategory
		{
			get
			{
				return sourceCategory;
			}
		}

		public List<CustomThing> SourceCustomThings
		{
			get
			{
				return sourceCustomThings;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Init();
		}

		private void Init()
		{
			// Set the instructions text
			instructionsLabel.Text = string.Format(instructionsLabel.Text, this.SourceCustomThings.Count);

			// Load the target categories
			targetCategoriesComboBox.DisplayMember = "Name";
			targetCategoriesComboBox.ValueMember = "ID";
			targetCategoriesComboBox.DataSource = GetTargetCategories();
			targetCategoriesComboBox.SelectedIndex = -1;
		}

		private List<CustomQuizCategory> GetTargetCategories()
		{
			List<CustomQuizCategory> targetCategories = new List<CustomQuizCategory>();

			// Get list of all categories
			List<CustomQuizCategory> categories = CustomQuizCategory.GetList();

			// Make sure source category is not a target
			foreach (CustomQuizCategory category in categories)
			{
				if (category.ID != this.SourceCategory.ID)
				{
					targetCategories.Add(category);
				}
			}

			return targetCategories;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (targetCategoriesComboBox.SelectedItem != null)
				{
					CustomQuizCategory targetCategory = targetCategoriesComboBox.SelectedItem as CustomQuizCategory;
					if (targetCategory != null)
					{
						// Copy the category items from the source category to the target category.
						targetCategory.CopyCategoryItems(this.SourceCustomThings);

						MessageBox.Show("The category items have been successfully copied.", "Target Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.DialogResult = DialogResult.OK;
					}
				}
				else
				{
					MessageBox.Show("Please select a target category.", "Target Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("An error occurred copying the category items. - {0}", ex.Message), "Target Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}