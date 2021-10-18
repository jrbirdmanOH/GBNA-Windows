using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.UI;
using SortableColumn = Thayer.Birding.UI.CustomThingComparer.SortableColumn;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizEditCategoryForm : BaseForm
	{
		private CustomQuizCategory category = null;
		private List<CustomThing> items = new List<CustomThing>();
		private SortableColumn sortColumn = SortableColumn.Name;
		private SortOrder sortOrder = SortOrder.Ascending;
		private static Dictionary<int, SortableColumn> categoryItemColumnMap = null;

		public MyQuizEditCategoryForm(CustomQuizCategory category)
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			this.category = category;

			categoryItemColumnMap = new Dictionary<int, SortableColumn>(2);
			categoryItemColumnMap.Add(0, SortableColumn.Name);
			categoryItemColumnMap.Add(1, SortableColumn.AlternateName);
		}

		public CustomQuizCategory Category
		{
			get
			{
				return category;
			}
		}

		private string CategoryName
		{
			get
			{
				return nameTextBox.Text.Trim();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Init();
		}

		protected void Init()
		{
			nameTextBox.Text = category.Name;
			LoadCategoryItems();

			// Only allow Copy functionality if there is another category to copy to
			List<CustomQuizCategory> categories = CustomQuizCategory.GetList();
			copyButton.Enabled = categories.Count > 1;
		}

		private void LoadCategoryItems()
		{
			categoryItemsListView.BeginUpdate();
			categoryItemsListView.Items.Clear();

			// Load the category items
			items = category.GetItems();

			// Sort the list based on the sort column and sort order
			Sort();

			foreach (CustomThing thing in items)
			{
				ListViewItem item = new ListViewItem(thing.Name);
				item.Tag = thing;
				item.SubItems.Add(thing.AlternateNameOriginal);

				categoryItemsListView.Items.Add(item);
			}

			categoryItemsListView.EndUpdate();
			UpdateControlStatus();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (SaveCategory())
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private bool SaveCategory()
		{
			bool result = false;

			if (IsValid())
			{
				// Save the category
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

		private void newCategoryItemButton_Click(object sender, EventArgs e)
		{
			NewCategoryItem();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewCategoryItem();
		}

		private void NewCategoryItem()
		{
			MyQuizEditCategoryItemForm form = new MyQuizEditCategoryItemForm(this.Category);
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				LoadCategoryItems();
				SelectItem(form.CategoryItem);
			}
		}

		private void editCategoryItemButton_Click(object sender, EventArgs e)
		{
			EditCategoryItem();
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditCategoryItem();
		}

		private void categoryItemsListView_DoubleClick(object sender, EventArgs e)
		{
			EditCategoryItem();
		}

		private void EditCategoryItem()
		{
			if (categoryItemsListView.SelectedItems.Count == 1)
			{
				MyQuizEditCategoryItemForm form = new MyQuizEditCategoryItemForm(this.Category);
				CustomThing selectedItem = categoryItemsListView.SelectedItems[0].Tag as CustomThing;
				form.CategoryItem = selectedItem;
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					LoadCategoryItems();
					SelectItem(form.CategoryItem);
				}

				categoryItemsListView.Focus();
			}
		}

		private void deleteCategoryItemButton_Click(object sender, EventArgs e)
		{
			DeleteCategoryItems();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteCategoryItems();
		}

		private void DeleteCategoryItems()
		{
			int count = categoryItemsListView.SelectedItems.Count;

			if (count == 0)
			{
				return;
			}

			if (count == 1)
			{
				ListViewItem item = categoryItemsListView.SelectedItems[0];
				CustomThing thing = item.Tag as CustomThing;

				if (MessageBox.Show(this, "Are you sure you want to delete the item \"" + thing.Name + "\"?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					categoryItemsListView.Items.Remove(item);
					category.DeleteCategoryItem(thing);
				}
			}
			else
			{
				if (MessageBox.Show(this, "Are you sure you want to delete the selected items?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{

					try
					{
						categoryItemsListView.BeginUpdate();
						List<CustomThing> categoryItems = new List<CustomThing>(categoryItemsListView.SelectedItems.Count);
						foreach (ListViewItem item in categoryItemsListView.SelectedItems)
						{
							categoryItems.Add(item.Tag as CustomThing);
							categoryItemsListView.Items.Remove(item);
						}

						// Delete the category items
						category.DeleteCategoryItems(categoryItems);
					}
					finally
					{
						categoryItemsListView.EndUpdate();
					}
				}
			}

			UpdateControlStatus();
		}

		private void categoryItemsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			UpdateControlStatus();
		}

		private void UpdateControlStatus()
		{
			switch (categoryItemsListView.SelectedIndices.Count)
			{
				case 0:
					editCategoryItemButton.Enabled = false;
					editToolStripMenuItem.Enabled = false;
					deleteCategoryItemButton.Enabled = false;
					deleteToolStripMenuItem.Enabled = false;
					break;
				case 1:
					editCategoryItemButton.Enabled = true;
					editToolStripMenuItem.Enabled = true;
					deleteCategoryItemButton.Enabled = true;
					deleteToolStripMenuItem.Enabled = true;
					break;
				default:
					editCategoryItemButton.Enabled = false;
					editToolStripMenuItem.Enabled = false;
					deleteCategoryItemButton.Enabled = true;
					deleteToolStripMenuItem.Enabled = true;
					break;
			}
		}

		private void categoryItemsListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				categoryItemsListView.BeginUpdate();

				// Select all items
				foreach (ListViewItem item in categoryItemsListView.Items)
				{
					item.Selected = true;
				}

				categoryItemsListView.EndUpdate();
			}
			else if (e.KeyCode == Keys.Delete)
			{
				DeleteCategoryItems();
			}
		}

		private void categoryItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine new sort column
			SortableColumn newSortColumn;
			if (!categoryItemColumnMap.TryGetValue(e.Column, out newSortColumn))
			{
				newSortColumn = sortColumn;
			}

			// Determine new sort order
			SortOrder newSortOrder = sortOrder;
			if (newSortColumn == sortColumn)
			{
				newSortOrder = sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Default to ascending
				newSortOrder = SortOrder.Ascending;
			}

			sortColumn = newSortColumn;
			sortOrder = newSortOrder;

			// Refresh the data
			LoadCategoryItems();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(categoryItemsListView.Handle, e.Column, sortOrder == SortOrder.Ascending ? true : false);

			// Make sure a selected item is visible
			EnsureSelectedItemIsVisible(categoryItemsListView);
		}

		private void Sort()
		{
			items.Sort(new CustomThingComparer(sortColumn, sortOrder));
		}

		private void SelectItem(CustomThing itemToSelect)
		{
			foreach (ListViewItem item in categoryItemsListView.Items)
			{
				if (((CustomThing)item.Tag).ID == itemToSelect.ID)
				{
					item.Selected = true;
					EnsureSelectedItemIsVisible(categoryItemsListView);
					categoryItemsListView.Focus();
					break;
				}
			}
		}

		private void EnsureSelectedItemIsVisible(ListView listView)
		{
			// Make sure the selected item is visible
			if (listView.SelectedIndices.Count >= 1)
			{
				listView.EnsureVisible(listView.SelectedIndices[0]);
			}
		}

		private void copyButton_Click(object sender, EventArgs e)
		{
			List<CustomThing> sourceCustomThings = new List<CustomThing>();

			if (categoryItemsListView.SelectedIndices.Count > 0)
			{
				foreach (ListViewItem item in categoryItemsListView.SelectedItems)
				{
					sourceCustomThings.Add(item.Tag as CustomThing);
				}
			}
			else
			{
				sourceCustomThings = this.Category.GetItems();
			}

			MyQuizCopyToCategoryForm form = new MyQuizCopyToCategoryForm(this.Category, sourceCustomThings);
			form.ShowDialog();
		}
	}
}