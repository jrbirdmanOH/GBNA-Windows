using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class QuizSelectPanel : QuizWizardPanel, IShowsWebBrowser
	{
		private Collection collection = null;
		private QuizListDataSource quizListDataSource = null;
		private CustomListDataSource customListDataSource = null;

		private static Dictionary<int, QuizListDataSource.SortableColumn> quizListColumnMap = null;
		private static Dictionary<int, CustomListDataSource.SortableColumn> customListColumnMap = null;

		private enum QuizViewType
		{
			Alphabetical,
			GroupByCategory
		}

		public QuizSelectPanel()
		{
			InitializeComponent();
		}

		public Collection Collection
		{
			get
			{
				return collection;
			}

			set
			{
				collection = value;
			}
		}

		private QuizListDataSource QuizListDataSource
		{
			get
			{
				if (quizListDataSource == null)
				{
					quizListDataSource = new QuizListDataSource();
				}

				return quizListDataSource;
			}
		}

		private CustomListDataSource CustomListDataSource
		{
			get
			{
				if (customListDataSource == null)
				{
					customListDataSource = new CustomListDataSource();
				}

				return customListDataSource;
			}
		}

		private static Dictionary<int, QuizListDataSource.SortableColumn> QuizListColumnMap
		{
			get
			{
				if (quizListColumnMap == null)
				{
					quizListColumnMap = new Dictionary<int, QuizListDataSource.SortableColumn>(1);
					quizListColumnMap.Add(0, QuizListDataSource.SortableColumn.Name);
				}

				return quizListColumnMap;
			}
		}

		private static Dictionary<int, CustomListDataSource.SortableColumn> CustomListColumnMap
		{
			get
			{
				if (customListColumnMap == null)
				{
					customListColumnMap = new Dictionary<int, CustomListDataSource.SortableColumn>(2);
					customListColumnMap.Add(0, CustomListDataSource.SortableColumn.Name);
					customListColumnMap.Add(1, CustomListDataSource.SortableColumn.Length);
				}

				return customListColumnMap;
			}
		}

		public override void LoadSettings()
		{
			base.LoadSettings();
		}

		public override void SaveSettings()
		{
			base.SaveSettings();
			QuizSettings.QuizLength = GetQuizLength();

			switch (quizSelectTabControl.SelectedIndex)
			{
				case 0:
					// Predefined quizzes
					QuizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.PredefinedQuiz;
					QuizSettings.QuizSource.PredefinedQuiz.QuizID = GetSelectedQuiz();
					break;
				case 1:
					// Locations
					QuizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.Location;
					QuizSettings.QuizSource.Location.CommonOnly = locationTreeView.ExcludeRareBirds;
					QuizSettings.QuizSource.Location.Locations = locationTreeView.SelectedLocations;
					break;
				case 2:
					// Taxonomy group
					QuizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.TaxonomicGroup;
					QuizSettings.QuizSource.TaxonomicGroup.TaxonomyID = Collection.TaxonomyID;
					QuizSettings.QuizSource.TaxonomicGroup.Classifications = taxonomyTreeView.SelectedClassifications;
					break;
				case 3:
					// Custom list
					QuizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.CustomList;
					QuizSettings.QuizSource.CustomList.CustomListID = GetSelectedCustomList();
					break;
				case 4:
					// Custom quiz
					QuizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.CustomQuiz;
					CustomQuiz customQuiz = GetSelectedCustomQuiz();
					QuizSettings.QuizSource.CustomQuiz.QuizID = customQuiz.ID;
					QuizSettings.QuizSource.CustomQuiz.CategoryID = customQuiz.CategoryID;
					break;
			}
		}

		private void QuizSelectPanel_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				Application.DoEvents();

				Cursor previousCursor = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					// Set the link for the free quizzes link label
					string webLinkCode = "FREEQUIZ";
					WebLink link = WebLink.GetByCode(webLinkCode);
					if (link != null)
					{
						freeQuizzesLinkLabel.Text = link.Caption;
						freeQuizzesLinkLabel.Links.Add(0, freeQuizzesLinkLabel.Text.Length, webLinkCode);
					}
					else
					{
						freeQuizzesLinkLabel.Enabled = false;
						freeQuizzesLinkLabel.Visible = false;
					}

					InitializeQuizzes();
					InitializeLocations();
					InitializeTaxonomyGroups();
					InitializeCustomLists();
					InitializeCustomQuizzes();
				}
				finally
				{
					Cursor.Current = previousCursor;
				}
			}
		}

		private void InitializeQuizzes()
		{
			// Load the quizzes
			QuizListDataSource.CollectionID = Collection.ID;
			LoadQuizzes();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(quizListView.Handle, GetColumnIndex(QuizListDataSource.SortColumn), QuizListDataSource.SortOrder == SortOrder.Ascending ? true : false);

			// Optimize column widths in quiz list view
			quizListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

			// Set the initial view type
			SetQuizViewType(QuizViewType.GroupByCategory);
		}

		private void InitializeLocations()
		{
			locationTreeView.CollectionID = Collection.ID;
		}

		private void InitializeTaxonomyGroups()
		{
			taxonomyTreeView.TaxonomyID = Collection.TaxonomyID;
		}

		private void InitializeCustomLists()
		{
			// Load the custom lists
			CustomListDataSource.CollectionID = Collection.ID;
			LoadCustomLists();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(customListView.Handle, GetColumnIndex(CustomListDataSource.SortColumn), CustomListDataSource.SortOrder == SortOrder.Ascending ? true : false);

			// Optimize column widths in custom list view
			customListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
			customListView.Columns[1].Width = 75;
		}

		private void InitializeCustomQuizzes()
		{
			// Load the custom quizzes
			LoadCustomQuizzes();
		}

		private void SetQuizViewType(QuizViewType type)
		{
			if (type == QuizViewType.Alphabetical)
			{
				alphabeticalRadioButton.Checked = true;

				quizListView.Enabled = true;
				quizListView.Visible = true;

				quizTreeView.Enabled = false;
				quizTreeView.Visible = false;

				// Make sure the selected item is visible
				EnsureSelectedItemIsVisible(quizTreeView);
			}
			else
			{
				categoryRadioButton.Checked = true;

				quizTreeView.Enabled = true;
				quizTreeView.Visible = true;

				quizListView.Enabled = false;
				quizListView.Visible = false;

				// Make sure the selected item is visible
				EnsureSelectedItemIsVisible(quizListView);
			}

			// Set the status of the wizard navigation
			SetNavigationStatusForQuizzes();
			SetCreateCustomListButtonStatus();
		}

		private void LoadQuizzes()
		{
			// Load the quiz tree view
			LoadQuizTree();

			// Load the quiz list view            
			LoadQuizList();
		}

		private void LoadQuizTree()
		{
			// Load the quiz tree view
			quizTreeView.BeginUpdate();
			Dictionary<string, List<Thayer.Birding.Quiz>> categorizedList = Thayer.Birding.Quiz.GetCategorizedList(Collection.ID);
			foreach (KeyValuePair<string, List<Thayer.Birding.Quiz>> keyValuePair in categorizedList)
			{
				TreeNode categoryNode = new TreeNode();
				categoryNode.Text = keyValuePair.Key;
				quizTreeView.Nodes.Add(categoryNode);
				List<Thayer.Birding.Quiz> quizList = keyValuePair.Value;
				foreach (Thayer.Birding.Quiz quiz in quizList)
				{
					TreeNode quizNode = new TreeNode();
					quizNode.Text = quiz.Name;
					quizNode.Tag = quiz;
					categoryNode.Nodes.Add(quizNode);
				}
			}
			quizTreeView.EndUpdate();
		}

		private void LoadQuizList()
		{
			// Keep track of any previously selected item
			int selectedQuizID = 0;
			if (quizListView.SelectedItems.Count == 1)
			{
				Thayer.Birding.Quiz selectedQuiz = quizListView.SelectedItems[0].Tag as Thayer.Birding.Quiz;
				if (selectedQuiz != null)
				{
					selectedQuizID = selectedQuiz.ID;
				}
			}

			// Load the quiz list view            
			IList<Thayer.Birding.Quiz> quizzes = QuizListDataSource.List;
			quizListView.BeginUpdate();
			quizListView.Items.Clear();
			int index = 0;
			foreach (Thayer.Birding.Quiz quiz in quizzes)
			{
				ListViewItem item = new ListViewItem(quiz.Name);
				if (index % 2 != 0)
				{
					item.BackColor = System.Drawing.Color.WhiteSmoke;
				}
				item.Tag = quiz;
				quizListView.Items.Add(item);

				// Check if item was previously selected
				if (quiz.ID == selectedQuizID)
				{
					item.Selected = true;
				}

				index++;
			}

			quizListView.EndUpdate();
		}

		private void LoadCustomLists()
		{
			// Keep track of any previously selected item
			int selectedCustomListID = GetSelectedCustomList();

			IList<CustomList> customLists = CustomListDataSource.List;
			customListView.BeginUpdate();
			customListView.Items.Clear();
			int index = 0;
			foreach (CustomList customList in customLists)
			{
				ListViewItem item = new ListViewItem(customList.Name);
				if (index % 2 != 0)
				{
					item.BackColor = System.Drawing.Color.WhiteSmoke;
				}
				item.Tag = customList;
				item.SubItems.Add(customList.Length.ToString());
				customListView.Items.Add(item);

				// Check if item was previously selected
				if (customList.ID == selectedCustomListID)
				{
					item.Selected = true;
				}

				index++;
			}

			customListView.EndUpdate();
		}

		private void LoadCustomQuizzes()
		{
			// Load the custom quiz tree view
			customQuizTreeView.BeginUpdate();
			customQuizTreeView.Nodes.Clear();

			List<CustomQuizCategory> categories = CustomQuizCategory.GetList();
			foreach (CustomQuizCategory category in categories)
			{
				TreeNode parent = customQuizTreeView.Nodes.Add(category.Name);
				parent.Tag = category;

				List<CustomQuiz> quizzes = CustomQuiz.GetList(category.ID);
				foreach (CustomQuiz quiz in quizzes)
				{
					TreeNode node = parent.Nodes.Add(quiz.Name);
					node.Tag = quiz;
				}
			}

			// Make sure a node is always selected
			if (customQuizTreeView.SelectedNode == null && customQuizTreeView.Nodes.Count > 0)
			{
				customQuizTreeView.SelectedNode = customQuizTreeView.Nodes[0];
			}

			customQuizTreeView.EndUpdate();
		}

		public void UpdateCustomQuizzes()
		{
			LoadCustomQuizzes();
			SetNavigationStatusForCustomQuizzes();
		}

		private void quizListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Get current sort column and sort order
			SortOrder currentSortOrder = QuizListDataSource.SortOrder;
			QuizListDataSource.SortableColumn currentSortColumn = QuizListDataSource.SortColumn;

			// Determine new sort column
			QuizListDataSource.SortableColumn newSortColumn;
			if (!QuizListColumnMap.TryGetValue(e.Column, out newSortColumn))
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
			QuizListDataSource.Sort(newSortColumn, newSortOrder);

			// Load the quizzes based on the new sort criteria
			LoadQuizList();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(quizListView.Handle, e.Column, newSortOrder == SortOrder.Ascending ? true : false);

			// Make sure a selected item is visible
			EnsureSelectedItemIsVisible(quizListView);
		}

		private void categoryRadioButton_Click(object sender, EventArgs e)
		{
			SetQuizViewType(QuizViewType.GroupByCategory);
		}

		private void EnsureSelectedItemIsVisible(ListView listView)
		{
			// Make sure the selected item is visible
			if (listView.SelectedIndices.Count >= 1)
			{
				listView.EnsureVisible(listView.SelectedIndices[0]);
			}
		}

		private void EnsureSelectedItemIsVisible(TreeView treeView)
		{
			// Make sure the selected node is visible
			TreeNode selectedNode = treeView.SelectedNode;
			if (selectedNode != null)
			{
				selectedNode.EnsureVisible();
			}
		}

		private void alphabeticalRadioButton_Click(object sender, EventArgs e)
		{
			SetQuizViewType(QuizViewType.Alphabetical);
		}

		private void customListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Get current sort column and sort order
			SortOrder currentSortOrder = CustomListDataSource.SortOrder;
			CustomListDataSource.SortableColumn currentSortColumn = CustomListDataSource.SortColumn;

			// Determine new sort column
			CustomListDataSource.SortableColumn newSortColumn;
			if (!CustomListColumnMap.TryGetValue(e.Column, out newSortColumn))
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
			CustomListDataSource.Sort(newSortColumn, newSortOrder);

			// Load the custom lists based on the new sort criteria
			LoadCustomLists();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(customListView.Handle, e.Column, newSortOrder == SortOrder.Ascending ? true : false);

			// Make sure a selected item is visible
			EnsureSelectedItemIsVisible(customListView);
		}

		private void quizSelectTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (quizSelectTabControl.SelectedIndex)
			{
				case 0:
					// Predefined quizzes
					SetNavigationStatusForQuizzes();
					SetCreateCustomListButtonStatus();
					if (categoryRadioButton.Checked)
					{
						quizTreeView.Focus();
					}
					else
					{
						quizListView.Focus();
					}
					break;
				case 1:
					// Locations
					SetNavigationStatusForLocations();
					locationTreeView.Focus();
					break;
				case 2:
					// Taxonomy group
					SetNavigationStatusForTaxonomyGroups();
					taxonomyTreeView.Focus();
					break;
				case 3:
					// Custom list
					SetNavigationStatusForCustomLists();
					customListView.Focus();
					break;
				case 4:
					// Custom quizzes
					SetNavigationStatusForCustomQuizzes();
					customQuizTreeView.Focus();
					break;
			}
		}

		private void quizTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SetNavigationStatusForQuizzes();
			SetCreateCustomListButtonStatus();
		}

		private void quizListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetNavigationStatusForQuizzes();
			SetCreateCustomListButtonStatus();
		}

		private void locationTreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			SetNavigationStatusForLocations();
		}

		private void locationTreeView_ExcludeRareBirdsCheckedChanged(object sender, EventArgs e)
		{
			SetNavigationStatusForLocations();
		}

		private void taxonomyTreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			SetNavigationStatusForTaxonomyGroups();
		}

		private void customListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetNavigationStatusForCustomLists();
		}

		private void customQuizTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SetNavigationStatusForCustomQuizzes();
		}

		private void SetNavigationStatusForQuizzes()
		{
			BackEnabled = false;
			NextEnabled = IsQuizSelected();
			FinishEnabled = false;
		}

		private void SetCreateCustomListButtonStatus()
		{
			createCustomListButton.Enabled = IsQuizSelected();
		}

		private bool IsQuizSelected()
		{
			bool isQuizSelected = false;

			if (alphabeticalRadioButton.Checked)
			{
				if (quizListView.SelectedItems.Count == 1)
				{
					isQuizSelected = true;
				}
			}
			else
			{
				TreeNode selectedNode = quizTreeView.SelectedNode;
				if (selectedNode != null)
				{
					if (selectedNode.Level > 0)
					{
						isQuizSelected = true;
					}
				}
			}

			return isQuizSelected;
		}

		private void SetNavigationStatusForLocations()
		{
			bool nextEnabled = false;

			if (GetQuizLengthByLocation() > 0)
			{
				nextEnabled = true;
			}

			BackEnabled = false;
			NextEnabled = nextEnabled;
			FinishEnabled = false;
		}

		private void SetNavigationStatusForTaxonomyGroups()
		{
			bool nextEnabled = false;

			if (GetQuizLengthByTaxonomy() > 0)
			{
				nextEnabled = true;
			}

			BackEnabled = false;
			NextEnabled = nextEnabled;
			FinishEnabled = false;
		}

		private void SetNavigationStatusForCustomLists()
		{
			BackEnabled = false;
			NextEnabled = false;
			FinishEnabled = false;

			if (customListView.SelectedItems.Count == 1)
			{
				NextEnabled = true;
			}
		}

		private void SetNavigationStatusForCustomQuizzes()
		{
			BackEnabled = false;
			NextEnabled = false;
			FinishEnabled = false;

			TreeNode selectedNode = customQuizTreeView.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Level > 0)
				{
					NextEnabled = true;
				}
			}
		}

		private int GetQuizLength()
		{
			int quizLength = 0;

			switch (quizSelectTabControl.SelectedIndex)
			{
				case 0:
					// Predefined quizzes
					quizLength = GetQuizLengthByQuiz();
					break;
				case 1:
					// Locations
					quizLength = GetQuizLengthByLocation();
					break;
				case 2:
					// Taxonomy group
					quizLength = GetQuizLengthByTaxonomy();
					break;
				case 3:
					// Custom list
					quizLength = GetQuizLengthByCustomList();
					break;
				case 4:
					// Custom quiz
					quizLength = GetQuizLengthByCustomQuiz();
					break;
			}


			return quizLength;
		}

		private int GetQuizLengthByQuiz()
		{
			int quizLength = 0;

			Thayer.Birding.Quiz selectedQuiz = null;

			if (alphabeticalRadioButton.Checked)
			{
				if (quizListView.SelectedItems.Count == 1)
				{
					selectedQuiz = quizListView.SelectedItems[0].Tag as Thayer.Birding.Quiz;
				}
			}
			else
			{
				TreeNode selectedNode = quizTreeView.SelectedNode;
				if (selectedNode != null)
				{
					selectedQuiz = selectedNode.Tag as Thayer.Birding.Quiz;
				}
			}

			if (selectedQuiz != null)
			{
				quizLength = Organism.GetNumberOfThingsWithMediaByQuiz(selectedQuiz.ID, Collection.ID);
			}

			return quizLength;
		}

		private int GetQuizLengthByLocation()
		{
			int quizLength = 0;

			Location[] locations = locationTreeView.SelectedLocations;
			if (locations != null && locations.Length > 0)
			{
				quizLength = Organism.GetNumberOfThingsWithMediaByLocation(locations, locationTreeView.ExcludeRareBirds);
			}

			return quizLength;
		}

		private int GetQuizLengthByTaxonomy()
		{
			int quizLength = 0;

			ITaxonomy[] taxonomies = taxonomyTreeView.SelectedClassifications;
			if (taxonomies != null && taxonomies.Length > 0)
			{
				quizLength = Organism.GetNumberOfThingsWithMediaByTaxonomy(Collection.TaxonomyID, taxonomies);
			}

			return quizLength;
		}

		private int GetQuizLengthByCustomList()
		{
			int quizLength = 0;

			if (customListView.SelectedItems.Count == 1)
			{
				CustomList customList = customListView.SelectedItems[0].Tag as CustomList;
				if (customList != null)
				{
					quizLength = customList.Length;
				}
			}

			return quizLength;
		}

		private int GetQuizLengthByCustomQuiz()
		{
			int quizLength = 0;

			CustomQuiz customQuiz = GetSelectedCustomQuiz();

			if (customQuiz != null)
			{
				quizLength = CustomThing.GetByQuizID(customQuiz.ID).Count;
			}

			return quizLength;
		}

		private int GetSelectedQuiz()
		{
			int selectedQuizID = 0;

			if (alphabeticalRadioButton.Checked)
			{
				// Alphabetical list
				if (quizListView.SelectedItems.Count == 1)
				{
					Thayer.Birding.Quiz selectedQuiz = quizListView.SelectedItems[0].Tag as Thayer.Birding.Quiz;
					if (selectedQuiz != null)
					{
						selectedQuizID = selectedQuiz.ID;
					}
				}
			}
			else
			{
				// Categorized list
				TreeNode selectedNode = quizTreeView.SelectedNode;
				if (selectedNode != null)
				{
					if (selectedNode.Level > 0)
					{
						Thayer.Birding.Quiz selectedQuiz = selectedNode.Tag as Thayer.Birding.Quiz;
						if (selectedQuiz != null)
						{
							selectedQuizID = selectedQuiz.ID;
						}
					}
				}
			}

			return selectedQuizID;
		}

		private int GetSelectedCustomList()
		{
			int selectedCustomListID = 0;
			if (customListView.SelectedItems.Count == 1)
			{
				CustomList selectedCustomList = customListView.SelectedItems[0].Tag as CustomList;
				if (selectedCustomList != null)
				{
					selectedCustomListID = selectedCustomList.ID;
				}
			}

			return selectedCustomListID;
		}

		private CustomQuiz GetSelectedCustomQuiz()
		{
			CustomQuiz customQuiz = null;

			TreeNode selectedNode = customQuizTreeView.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Level > 0)
				{
					customQuiz = selectedNode.Tag as CustomQuiz;
				}
			}

			return customQuiz;
		}

		private int GetColumnIndex(QuizListDataSource.SortableColumn column)
		{
			int columnIndex = 0;

			foreach (int index in QuizListColumnMap.Keys)
			{
				if (QuizListColumnMap[index] == column)
				{
					columnIndex = index;
					break;
				}
			}

			return columnIndex;
		}

		private int GetColumnIndex(CustomListDataSource.SortableColumn column)
		{
			int columnIndex = 0;

			foreach (int index in CustomListColumnMap.Keys)
			{
				if (CustomListColumnMap[index] == column)
				{
					columnIndex = index;
					break;
				}
			}

			return columnIndex;
		}

		private void freeQuizzesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string webLinkCode = e.Link.LinkData as string;
			WebLink link = WebLink.GetByCode(webLinkCode);
			if (link != null)
			{
				link.Navigate(this);
			}
			else
			{
				StringBuilder message = new StringBuilder("Web link with code \"");
				message.Append(webLinkCode);
				message.Append("\" cannot be found.");
				MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		void IShowsWebBrowser.OpenBrowser(string url)
		{
			Utility.ShowWebBrowser(url);
		}

		private void createCustomListButton_Click(object sender, EventArgs e)
		{
			if (IsQuizSelected())
			{
				int quizID = GetSelectedQuiz();
				Thayer.Birding.Quiz quiz = Thayer.Birding.Quiz.GetByID(quizID);

				CustomList customList = new CustomList();
				customList.Name = quiz.Name;
				customList.CollectionID = Collection.ID;
				customList.Length = quiz.Things.Count;

				CustomListEditForm form = new CustomListEditForm();
				form.CustomList = customList;
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					Application.DoEvents();

					Cursor = Cursors.WaitCursor;

					try
					{
						int order = 0;
						foreach (int thingID in quiz.Things)
						{
							CustomListItem item = new CustomListItem();
							item.CustomListID = customList.ID;
							item.Order = ++order;
							item.Organism.ID = thingID;
							customList.Contents.Add(item);
						}

						customList.SaveContents();

						// Initialize the custom lists so new list is visible
						InitializeCustomLists();
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}
	}


	/// <summary>
	/// CustomListDataSource
	/// </summary>
	class CustomListDataSource
	{
		public enum SortableColumn
		{
			Name,
			Length
		}

		private List<CustomList> list = null;
		private int collectionID = 0;
		private SortableColumn sortColumn = SortableColumn.Name;
		private SortOrder sortOrder = SortOrder.Ascending;

		public CustomListDataSource()
		{
		}

		public IList<CustomList> List
		{
			get
			{
				return list;
			}
		}

		public int CollectionID
		{
			get
			{
				return collectionID;
			}
			set
			{
				collectionID = value;
				list = CustomList.GetList(collectionID);
				Sort();
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

		private void Sort()
		{
			list.Sort(new CustomListComparer(this.SortColumn, this.SortOrder));
		}

		public void Sort(SortableColumn sortColumn, SortOrder sortOrder)
		{
			this.sortColumn = sortColumn;
			this.sortOrder = sortOrder;

			Sort();
		}

		private class CustomListComparer : IComparer<CustomList>
		{
			private SortableColumn sortColumn = SortableColumn.Name;
			private SortOrder sortOrder = SortOrder.Ascending;

			public CustomListComparer(SortableColumn sortColumn, SortOrder sortOrder)
			{
				this.sortColumn = sortColumn;
				this.sortOrder = sortOrder;
			}

			public int Compare(CustomList x, CustomList y)
			{
				int compareResult = 0;
				bool enforceSortOrder = true;
				switch (sortColumn)
				{
					case SortableColumn.Name:
						compareResult = x.Name.CompareTo(y.Name);
						if(compareResult == 0)
						{
							compareResult = x.Length.CompareTo(y.Length);
							enforceSortOrder = false;
						}
						break;
					case SortableColumn.Length:
						compareResult = x.Length.CompareTo(y.Length);
						if (compareResult == 0)
						{
							compareResult = x.Name.CompareTo(y.Name);
							enforceSortOrder = false;
						}
						break;
				}

				if (sortOrder == SortOrder.Descending && enforceSortOrder)
				{
					compareResult = -compareResult;
				}

				return compareResult;
			}
		}
	}

	/// <summary>
	/// QuizListDataSource
	/// </summary>
	class QuizListDataSource
	{
		public enum SortableColumn
		{
			Name
		}

		private List<Thayer.Birding.Quiz> list = null;
		private int collectionID = 0;
		private SortableColumn sortColumn = SortableColumn.Name;
		private SortOrder sortOrder = SortOrder.Ascending;

		public QuizListDataSource()
		{
		}

		public IList<Thayer.Birding.Quiz> List
		{
			get
			{
				return list;
			}
		}

		public int CollectionID
		{
			get
			{
				return collectionID;
			}
			set
			{
				collectionID = value;
				list = Thayer.Birding.Quiz.GetList(collectionID);
				Sort();
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

		private void Sort()
		{
			list.Sort(new QuizComparer(this.SortColumn, this.SortOrder));
		}

		public void Sort(SortableColumn sortColumn, SortOrder sortOrder)
		{
			this.sortColumn = sortColumn;
			this.sortOrder = sortOrder;

			Sort();
		}

		private class QuizComparer : IComparer<Thayer.Birding.Quiz>
		{
			private SortableColumn sortColumn = SortableColumn.Name;
			private SortOrder sortOrder = SortOrder.None;

			public QuizComparer(SortableColumn sortColumn, SortOrder sortOrder)
			{
				this.sortColumn = sortColumn;
				this.sortOrder = sortOrder;
			}

			public int Compare(Thayer.Birding.Quiz x, Thayer.Birding.Quiz y)
			{
				int compareResult = 0;
				switch (sortColumn)
				{
					case SortableColumn.Name:
						compareResult = x.Name.CompareTo(y.Name);
						break;
					default:
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
