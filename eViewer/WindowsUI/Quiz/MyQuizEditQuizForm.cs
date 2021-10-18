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
	public partial class MyQuizEditQuizForm : BaseForm
	{
		private CustomQuiz quiz = null;
		private CustomQuizCategory category = null;
		private int? categoryItemsTopItemIndex = null;

		private List<CustomThing> questions = new List<CustomThing>();
		private List<CustomThing> availableCategoryItems = new List<CustomThing>();
		private static Dictionary<int, SortableColumn> customThingColumnMap = null;
		private SortableColumn questionsSortColumn = SortableColumn.Name;
		private SortOrder questionsSortOrder = SortOrder.Ascending;
		private SortableColumn categoryItemsSortColumn = SortableColumn.Name;
		private SortOrder categoryItemsSortOrder = SortOrder.Ascending;

		public MyQuizEditQuizForm(CustomQuiz quiz)
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			this.quiz = quiz;
			this.category = CustomQuizCategory.GetByID(quiz.CategoryID);

			customThingColumnMap = new Dictionary<int, SortableColumn>(2);
			customThingColumnMap.Add(0, SortableColumn.Name);
			customThingColumnMap.Add(1, SortableColumn.AlternateName);
		}

		public CustomQuiz Quiz
		{
			get
			{
				return quiz;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Init();
		}

		protected void Init()
		{
			categoryNameLabel.Text = category.Name;
			nameTextBox.Text = quiz.Name;
			authorTextBox.Text = quiz.Author;

			InitLists();
		}

		private void InitLists()
		{
			questions.Clear();
			questions.AddRange(quiz.Entries);

			availableCategoryItems.Clear();
			availableCategoryItems.AddRange(CustomQuizCategory.GetItems(category.ID));

			for (int itemIndex = availableCategoryItems.Count - 1; itemIndex >= 0; itemIndex--)
			{
				CustomThing item = availableCategoryItems[itemIndex];
				foreach (CustomThing quizEntry in questions)
				{
					if (item.ID == quizEntry.ID)
					{
						availableCategoryItems.RemoveAt(itemIndex);
					}
				}
			}

			LoadQuestions();
			LoadItems();
		}

		private void RefreshLists()
		{
			availableCategoryItems.Clear();
			availableCategoryItems.AddRange(CustomQuizCategory.GetItems(category.ID));

			// Remove questions that no longer exist
			for (int questionIndex = questions.Count - 1; questionIndex >= 0; questionIndex--)
			{
				CustomThing quizEntry = questions[questionIndex];
				bool found = false;
				foreach (CustomThing item in availableCategoryItems)
				{
					if (quizEntry.ID == item.ID)
					{
						questions[questionIndex] = item;
						found = true;
					}
				}

				if (!found)
				{
					questions.RemoveAt(questionIndex);
				}
			}

			for (int itemIndex = availableCategoryItems.Count - 1; itemIndex >= 0; itemIndex--)
			{
				CustomThing item = availableCategoryItems[itemIndex];
				foreach (CustomThing quizEntry in questions)
				{
					if (item.ID == quizEntry.ID)
					{
						availableCategoryItems.RemoveAt(itemIndex);
					}
				}
			}

			LoadQuestions();
			LoadItems();
		}

		private void LoadQuestions()
		{
			LoadQuestions(questions);
		}

		private void LoadQuestions(List<CustomThing> questions)
		{
			questionsListView.BeginUpdate();

			// Clear any existing items
			questionsListView.Items.Clear();

			// Sort the list based on the sort column and sort order
			Sort(questions, questionsSortColumn, questionsSortOrder);

			foreach (CustomThing thing in questions)
			{
				ListViewItem item = new ListViewItem(thing.Name);
				item.Tag = thing;
				item.SubItems.Add(thing.AlternateNameOriginal);
				questionsListView.Items.Add(item);
			}

			questionsListView.EndUpdate();
			UpdateControlStatus();
		}

		private void LoadItems()
		{
			categoryItemsListView.BeginUpdate();

			// Clear any existing items
			categoryItemsListView.Items.Clear();

			// Sort the list based on the sort column and sort order
			Sort(availableCategoryItems, categoryItemsSortColumn, categoryItemsSortOrder);

			foreach (CustomThing thing in availableCategoryItems)
			{
				ListViewItem item = new ListViewItem(thing.Name);
				item.Tag = thing;
				item.SubItems.Add(thing.AlternateNameOriginal);
				categoryItemsListView.Items.Add(item);
			}

			if (categoryItemsTopItemIndex.HasValue && categoryItemsListView.Items.Count > 0)
			{
				// Maintain scrolling position after selections have been made
				int index = categoryItemsTopItemIndex.Value;
				if (index < 0)
				{
					index = 0;
				}
				else if (index >= categoryItemsListView.Items.Count)
				{
					index = categoryItemsListView.Items.Count - 1;
				}

				// Need to compensate for bug in TopItem
				categoryItemsListView.TopItem = categoryItemsListView.Items[index];
				categoryItemsListView.TopItem = categoryItemsListView.Items[index];
				categoryItemsListView.TopItem = categoryItemsListView.Items[index];
				if (categoryItemsListView.TopItem.Index != index)
				{
					categoryItemsListView.EnsureVisible(index);
				}

				categoryItemsTopItemIndex = null;
			}

			categoryItemsListView.EndUpdate();
			UpdateControlStatus();
		}

		private void Sort(List<CustomThing> list, SortableColumn sortColumn, SortOrder sortOrder)
		{
			list.Sort(new CustomThingComparer(sortColumn, sortOrder));
		}

		private void addItemButton_Click(object sender, EventArgs e)
		{
			AddSelectedItems();
		}

		private void addSelectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddSelectedItems();
		}

		private void categoryItemsListView_DoubleClick(object sender, EventArgs e)
		{
			AddSelectedItems();
		}

		private void addAllItemsButton_Click(object sender, EventArgs e)
		{
			AddAllItems();
		}

		private void addAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddAllItems();
		}

		private void AddSelectedItems()
		{
			// Keep track of the top item so scroll position can be maintained
			ListViewItem topItem = categoryItemsListView.TopItem;
			if (topItem != null)
			{
				categoryItemsTopItemIndex = topItem.Index;
			}

			int numSelectedAboveTopIndex = 0;
			foreach (ListViewItem listViewItem in categoryItemsListView.SelectedItems)
			{
				int index = listViewItem.Index;
				if (categoryItemsTopItemIndex.HasValue && index < categoryItemsTopItemIndex.Value)
				{
					numSelectedAboveTopIndex++;
				}

				CustomThing item = listViewItem.Tag as CustomThing;
				questions.Add(item);
				availableCategoryItems.Remove(item);
			}

			if (categoryItemsTopItemIndex.HasValue)
			{
				categoryItemsTopItemIndex -= numSelectedAboveTopIndex;
			}

			LoadQuestions();
			LoadItems();
		}

		private void AddAllItems()
		{
			categoryItemsListView.BeginUpdate();
			foreach (ListViewItem item in categoryItemsListView.Items)
			{
				item.Selected = true;
			}
			categoryItemsListView.EndUpdate();

			AddSelectedItems();
		}

		private void removeItemButton_Click(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		private void questionsListView_DoubleClick(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		private void removeAllItemsButton_Click(object sender, EventArgs e)
		{
			RemoveAllItems();
		}

		private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveAllItems();
		}

		private void RemoveSelectedItems()
		{
			foreach (ListViewItem listViewItem in questionsListView.SelectedItems)
			{
				CustomThing item = listViewItem.Tag as CustomThing;
				questions.Remove(item);
				availableCategoryItems.Add(item);
			}

			LoadQuestions();
			LoadItems();
		}

		private void RemoveAllItems()
		{
			questionsListView.BeginUpdate();
			foreach (ListViewItem item in questionsListView.Items)
			{
				item.Selected = true;
			}
			questionsListView.EndUpdate();

			RemoveSelectedItems();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			quiz.Name = nameTextBox.Text;
			quiz.Author = authorTextBox.Text;
			quiz.Entries.Clear();
			quiz.Entries.AddRange(questions);
			quiz.Save();
		}

		private void manageCategoryItemsButton_Click(object sender, EventArgs e)
		{
			MyQuizEditCategoryForm form = new MyQuizEditCategoryForm(category);
			if (form.ShowDialog() == DialogResult.OK)
			{
				categoryNameLabel.Text = category.Name;
				RefreshLists();
			}
		}

		private void questionsListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine new sort column
			SortableColumn oldSortColumn = questionsSortColumn;
			SortableColumn newSortColumn;
			if (!customThingColumnMap.TryGetValue(e.Column, out newSortColumn))
			{
				newSortColumn = oldSortColumn;
			}

			// Determine new sort order
			SortOrder oldSortOrder = questionsSortOrder;
			SortOrder newSortOrder = oldSortOrder;
			if (newSortColumn == oldSortColumn)
			{
				newSortOrder = oldSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Default to ascending
				newSortOrder = SortOrder.Ascending;
			}

			questionsSortColumn = newSortColumn;
			questionsSortOrder = newSortOrder;

			// Refresh the data
			RefreshLists();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(questionsListView.Handle, e.Column, questionsSortOrder == SortOrder.Ascending ? true : false);
		}

		private void questionsListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				questionsListView.BeginUpdate();

				// Select all items
				foreach (ListViewItem item in questionsListView.Items)
				{
					item.Selected = true;
				}

				questionsListView.EndUpdate();
			}
		}

		private void categoryItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine new sort column
			SortableColumn oldSortColumn = categoryItemsSortColumn;
			SortableColumn newSortColumn;
			if (!customThingColumnMap.TryGetValue(e.Column, out newSortColumn))
			{
				newSortColumn = oldSortColumn;
			}

			// Determine new sort order
			SortOrder oldSortOrder = categoryItemsSortOrder;
			SortOrder newSortOrder = oldSortOrder;
			if (newSortColumn == oldSortColumn)
			{
				newSortOrder = oldSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Default to ascending
				newSortOrder = SortOrder.Ascending;
			}

			categoryItemsSortColumn = newSortColumn;
			categoryItemsSortOrder = newSortOrder;

			// Refresh the data
			RefreshLists();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(categoryItemsListView.Handle, e.Column, categoryItemsSortOrder == SortOrder.Ascending ? true : false);
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
		}

		private void questionsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			UpdateControlStatus();
		}

		private void categoryItemsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			UpdateControlStatus();
		}

		private void UpdateControlStatus()
		{
			removeItemButton.Enabled = questionsListView.SelectedIndices.Count > 0;
			removeSelectedToolStripMenuItem.Enabled = removeItemButton.Enabled;
			addItemButton.Enabled = categoryItemsListView.SelectedIndices.Count > 0;
			addSelectedToolStripMenuItem.Enabled = addItemButton.Enabled;
		}
	}
}