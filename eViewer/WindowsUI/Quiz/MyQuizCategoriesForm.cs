using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizCategoriesForm : BaseForm
	{
		private CustomQuizCategoryDataSource customQuizCategoryDataSource = null;
		private static Dictionary<int, CustomQuizCategoryDataSource.SortableColumn> customQuizCategoryColumnMap = null;

		public MyQuizCategoriesForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadCategories();
			LoadCategoryItems();
		}

		private CustomQuizCategoryDataSource CustomQuizCategoryDataSource
		{
			get
			{
				if (customQuizCategoryDataSource == null)
				{
					customQuizCategoryDataSource = new CustomQuizCategoryDataSource();
				}

				return customQuizCategoryDataSource;
			}
		}

		private static Dictionary<int, CustomQuizCategoryDataSource.SortableColumn> CustomQuizCategoryColumnMap
		{
			get
			{
				if (customQuizCategoryColumnMap == null)
				{
					customQuizCategoryColumnMap = new Dictionary<int, CustomQuizCategoryDataSource.SortableColumn>(1);
					customQuizCategoryColumnMap.Add(0, CustomQuizCategoryDataSource.SortableColumn.Name);
				}

				return customQuizCategoryColumnMap;
			}
		}

		private void LoadCategories()
		{
			categoryListView.BeginUpdate();

			// Get any existing selections
			List<int> selectedCategories = new List<int>(categoryListView.SelectedItems.Count);
			foreach (ListViewItem item in categoryListView.SelectedItems)
			{
				CustomQuizCategory category = item.Tag as CustomQuizCategory;
				if (category != null)
				{
					selectedCategories.Add(category.ID);
				}
			}

			// Clear any existing items
			categoryListView.Items.Clear();

			CustomQuizCategoryDataSource.Refresh();
			foreach (CustomQuizCategory category in CustomQuizCategoryDataSource.List)
			{
				ListViewItem item = new ListViewItem(category.Name);
				item.Tag = category;

				// Restore selected state
				if (selectedCategories.Contains(category.ID))
				{
					item.Selected = true;
				}

				categoryListView.Items.Add(item);
			}

			categoryListView.EndUpdate();

			UpdateMenuAndToolStripButtonStatus();
		}

		private void LoadCategoryItems()
		{
			categoryItemsListView.BeginUpdate();

			categoryItemsListView.Items.Clear();

			if (categoryListView.SelectedItems.Count > 0)
			{
				ListViewItem categoryItem = categoryListView.SelectedItems[0];
				if (categoryItem != null)
				{
					CustomQuizCategory category = categoryItem.Tag as CustomQuizCategory;
					foreach (CustomThing thing in category.GetItems())
					{
						ListViewItem item = new ListViewItem(thing.Name);
						item.Tag = thing;
						item.SubItems.Add(thing.AlternateName);

						categoryItemsListView.Items.Add(item);
					}
				}
			}


			categoryItemsListView.EndUpdate();
		}

		private void categoryListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadCategoryItems();
			UpdateMenuAndToolStripButtonStatus();
		}

		private void UpdateMenuAndToolStripButtonStatus()
		{
			int numSelected = categoryListView.SelectedIndices.Count;

			// Update Open status
			bool canOpen = numSelected == 1;
			openToolStripMenuItem.Enabled = canOpen;
			openToolStripButton.Enabled = canOpen;

			// Update Delete status
			bool canDelete = numSelected > 0;
			deleteToolStripMenuItem.Enabled = canDelete;
			deleteToolStripButton.Enabled = canDelete;
		}

		private void categoryListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Get current sort column and sort order
			SortOrder currentSortOrder = CustomQuizCategoryDataSource.SortOrder;
			CustomQuizCategoryDataSource.SortableColumn currentSortColumn = CustomQuizCategoryDataSource.SortColumn;

			// Determine new sort column
			CustomQuizCategoryDataSource.SortableColumn newSortColumn;
			if (!CustomQuizCategoryColumnMap.TryGetValue(e.Column, out newSortColumn))
			{
				newSortColumn = currentSortColumn;
			}

			// Determine new sort order
			SortOrder newSortOrder = currentSortOrder;
			if (newSortColumn == currentSortColumn)
			{
				newSortOrder = currentSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Default to ascending
				newSortOrder = SortOrder.Ascending;
			}

			// Sort the list based on the given sort column and sort order
			CustomQuizCategoryDataSource.Sort(newSortColumn, newSortOrder);

			// Load the categories based on the new sort criteria
			LoadCategories();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(categoryListView.Handle, e.Column, newSortOrder == SortOrder.Ascending ? true : false);

			// Make sure a selected item is visible
			EnsureSelectedItemIsVisible(categoryListView);
		}

		private void EnsureSelectedItemIsVisible(ListView listView)
		{
			// Make sure the selected item is visible
			if (listView.SelectedIndices.Count >= 1)
			{
				listView.EnsureVisible(listView.SelectedIndices[0]);
			}
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewCategory();
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			NewCategory();
		}

		private void NewCategory()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				MyQuizCategoryEditForm form = new MyQuizCategoryEditForm(new CustomQuizCategory());
				form.Text = "Add My Quiz Category";
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadCategories();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void categoryListView_DoubleClick(object sender, EventArgs e)
		{
			EditCategory();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditCategory();
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			EditCategory();
		}

		private void EditCategory()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				foreach (ListViewItem item in categoryListView.SelectedItems)
				{
					MyQuizCategoryEditForm form = new MyQuizCategoryEditForm(item.Tag as CustomQuizCategory);
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadCategories();
					}
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteCategories();
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e)
		{
			DeleteCategories();
		}

		private void DeleteCategories()
		{
			int count = categoryListView.SelectedItems.Count;

			if (count == 0)
			{
				return;
			}

			if (count == 1)
			{
				ListViewItem item = categoryListView.SelectedItems[0];
				CustomQuizCategory category = item.Tag as CustomQuizCategory;

				if (MessageBox.Show(this, "Are you sure you want to delete the category \"" + category.Name + "\"?", "Confirm Category Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					category.Delete();
					categoryListView.Items.Remove(item);
				}
			}
			else
			{
				if (MessageBox.Show(this, "Are you sure you want to delete these " + count + " categories?", "Confirm Multiple Category Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					categoryListView.BeginUpdate();

					try
					{
						List<CustomQuizCategory> categories = new List<CustomQuizCategory>(categoryListView.SelectedItems.Count);
						foreach (ListViewItem item in categoryListView.SelectedItems)
						{
							categories.Add(item.Tag as CustomQuizCategory);
							categoryListView.Items.Remove(item);
						}

						// Delete the categories
						CustomQuizCategory.DeleteList(categories);
					}
					finally
					{
						categoryListView.EndUpdate();
					}
				}
			}

			UpdateMenuAndToolStripButtonStatus();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void addCategoryItemButton_Click(object sender, EventArgs e)
		{
			MyQuizCategoryItemEditForm form = new MyQuizCategoryItemEditForm();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				if (categoryListView.SelectedItems.Count > 0)
				{
					ListViewItem item = categoryListView.SelectedItems[0];
					if (item != null)
					{
						CustomQuizCategory category = item.Tag as CustomQuizCategory;
						category.SaveCategoryItem(form.QuizEntry);
						LoadCategoryItems();
					}
				}
			}
		}

		private void editCategoryItemButton_Click(object sender, EventArgs e)
		{
			if(categoryItemsListView.SelectedItems.Count == 1)
			{
				MyQuizCategoryItemEditForm form = new MyQuizCategoryItemEditForm();
				form.QuizEntry = categoryItemsListView.SelectedItems[0].Tag as CustomThing;
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					if (categoryListView.SelectedItems.Count > 0)
					{
						ListViewItem item = categoryListView.SelectedItems[0];
						if (item != null)
						{
							CustomQuizCategory category = item.Tag as CustomQuizCategory;
							category.SaveCategoryItem(form.QuizEntry);
							LoadCategoryItems();
						}
					}
				}
			}
		}

		private void deleteCategoryItemButton_Click(object sender, EventArgs e)
		{
			DeleteCategoryItems();
		}

		private void DeleteCategoryItems()
		{
			CustomQuizCategory category = null;
			if (categoryListView.SelectedItems.Count > 0)
			{
				ListViewItem item = categoryListView.SelectedItems[0];
				if (item != null)
				{
					category = item.Tag as CustomQuizCategory;
				}
			}

			if (category == null)
			{
				return;
			}

			int count = categoryItemsListView.SelectedItems.Count;

			if (count == 0)
			{
				return;
			}

			if (count == 1)
			{
				ListViewItem item = categoryItemsListView.SelectedItems[0];
				CustomThing thing = item.Tag as CustomThing;

				if (MessageBox.Show(this, "Are you sure you want to delete the category item \"" + thing.Name + "\"?", "Confirm Category Item Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					categoryItemsListView.Items.Remove(item);
					category.DeleteCategoryItem(thing);
				}
			}
			else
			{
				if (MessageBox.Show(this, "Are you sure you want to delete these " + count + " category items?", "Confirm Multiple Category Item Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					categoryItemsListView.BeginUpdate();

					try
					{
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

			UpdateMenuAndToolStripButtonStatus();
		}

/*
		private int GetColumnIndex(CustomQuizCategoryDataSource.SortableColumn column)
		{
			int columnIndex = 0;

			foreach (int index in SightingColumnMap.Keys)
			{
				if (SightingColumnMap[index] == column)
				{
					columnIndex = index;
					break;
				}
			}

			return columnIndex;
		}
*/
	}

	/// <summary>
	/// CustomQuizCategoryDataSource
	/// </summary>
	class CustomQuizCategoryDataSource
	{
		public enum SortableColumn
		{
			Name
		}

		private List<CustomQuizCategory> list = null;
		private SortableColumn sortColumn = SortableColumn.Name;
		private SortOrder sortOrder = SortOrder.Ascending;

		public CustomQuizCategoryDataSource()
		{
		}

		public IList<CustomQuizCategory> List
		{
			get
			{
				return this.ListInternal;
			}
		}

		private List<CustomQuizCategory> ListInternal
		{
			get
			{
				if (list == null)
				{
					Refresh();
				}

				return list;
			}
		}

		public SortableColumn SortColumn
		{
			get
			{
				return sortColumn;
			}
			set
			{
				sortColumn = value;
			}
		}

		public SortOrder SortOrder
		{
			get
			{
				return sortOrder;
			}
			set
			{
				sortOrder = value;
			}
		}

		public void Refresh()
		{
			list = CustomQuizCategory.GetList();
			Sort();
		}

		private void Sort()
		{
			this.ListInternal.Sort(new CustomQuizCategoryComparer(this.SortColumn, this.SortOrder));
		}

		public void Sort(SortableColumn sortColumn, SortOrder sortOrder)
		{
			this.sortColumn = sortColumn;
			this.sortOrder = sortOrder;

			Sort();
		}

		private class CustomQuizCategoryComparer : IComparer<CustomQuizCategory>
		{
			private SortableColumn sortColumn = SortableColumn.Name;
			private SortOrder sortOrder = SortOrder.Ascending;

			public CustomQuizCategoryComparer(SortableColumn sortColumn, SortOrder sortOrder)
			{
				this.sortColumn = sortColumn;
				this.sortOrder = sortOrder;
			}

			public int Compare(CustomQuizCategory x, CustomQuizCategory y)
			{
				int compareResult = 0;
				switch (sortColumn)
				{
					case SortableColumn.Name:
						compareResult = x.Name.CompareTo(y.Name);
						break;
				}

				if (sortOrder == SortOrder.Descending)
				{
					compareResult = -compareResult;
				}

				return compareResult;
			}
		}
	}
}