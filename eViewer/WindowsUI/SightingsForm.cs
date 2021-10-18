using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SortableColumn = Thayer.Birding.UI.SightingComparer.SortableColumn;

namespace Thayer.Birding.UI.Windows
{
	public partial class SightingsForm : BaseForm
	{
		private Collection collection = null;
		private Language language = null;
		private Organism organism = null;
		private SightingsDataSource sightingsDataSource = null;
		private static Dictionary<int, SortableColumn> sightingColumnNameMap = null;
		private static Dictionary<SortableColumn, int> sightingColumnIndexMap = null;

		private readonly object eventLock = new object();
		private event EventHandler<EventArgs> sightingsChanged;

		public SightingsForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
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

		public Language Language
		{
			get
			{
				return language;
			}

			set
			{
				language = value;
			}
		}

		public Organism Organism
		{
			get
			{
				return organism;
			}

			set
			{
				organism = value;
			}
		}

		private int? OrganismID
		{
			get
			{
				int? organismID = null;

				if (this.Organism != null)
				{
					organismID = this.Organism.ID;
				}

				return organismID;
			}
		}

		private SightingsDataSource SightingsDataSource
		{
			get
			{
				if (sightingsDataSource == null)
				{
					sightingsDataSource = new SightingsDataSource(this.OrganismID);
				}

				return sightingsDataSource;
			}
		}

		private static Dictionary<int, SortableColumn> SightingColumnNameMap
		{
			get
			{
				if (sightingColumnNameMap == null)
				{
					sightingColumnNameMap = new Dictionary<int, SortableColumn>(6);
					sightingColumnNameMap.Add(0, SortableColumn.CommonName);
					sightingColumnNameMap.Add(1, SortableColumn.Date);
					sightingColumnNameMap.Add(2, SortableColumn.Location);
					sightingColumnNameMap.Add(3, SortableColumn.Observer);
					sightingColumnNameMap.Add(4, SortableColumn.Comments);
					sightingColumnNameMap.Add(5, SortableColumn.TaxonomicOrder);
				}

				return sightingColumnNameMap;
			}
		}

		private static Dictionary<SortableColumn, int> SightingColumnIndexMap
		{
			get
			{
				if (sightingColumnIndexMap == null)
				{
					sightingColumnIndexMap = new Dictionary<SortableColumn, int>(6);
					sightingColumnIndexMap.Add(SortableColumn.CommonName, 0);
					sightingColumnIndexMap.Add(SortableColumn.Date, 1);
					sightingColumnIndexMap.Add(SortableColumn.Location, 2);
					sightingColumnIndexMap.Add(SortableColumn.Observer, 3);
					sightingColumnIndexMap.Add(SortableColumn.Comments, 4);
					sightingColumnIndexMap.Add(SortableColumn.TaxonomicOrder, 0);
				}

				return sightingColumnIndexMap;
			}
		}

		public event EventHandler<EventArgs> SightingsChanged
		{
			add
			{
				lock (eventLock)
				{
					sightingsChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					sightingsChanged -= value;
				}
			}
		}

		protected virtual void OnSightingsChanged(EventArgs e)
		{
			EventHandler<EventArgs> temp = sightingsChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Set the title of the form
			this.Text = "Sightings";
			if (this.Organism != null)
			{
				string organismName = this.Organism.CommonNameDisplay.Name;
				this.Text += " : " + organismName;
			}

			RefreshSightings();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(sightingsListView.Handle, GetColumnIndex(SightingsDataSource.SortColumn), SightingsDataSource.SortOrder == SortOrder.Ascending ? true : false);

			UserSettings.Instance.LanguageChanged += new EventHandler<LanguageChangedEventArgs>(UserSettings_LanguageChanged);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			UserSettings.Instance.LanguageChanged -= new EventHandler<LanguageChangedEventArgs>(UserSettings_LanguageChanged);
		}

		private void UserSettings_LanguageChanged(object sender, LanguageChangedEventArgs e)
		{
			this.Language = e.Language;
		}

		private void RefreshSightings()
		{
			sightingsListView.BeginUpdate();

			// Get any existing selections
			List<int> selectedSightings = new List<int>(sightingsListView.SelectedItems.Count);
			foreach (ListViewItem item in sightingsListView.SelectedItems)
			{
				Sighting sighting = item.Tag as Sighting;
				if (sighting != null)
				{
					selectedSightings.Add(sighting.ID);
				}
			}

			// Clear any existing items
			sightingsListView.Items.Clear();

			SightingsDataSource.Refresh();
			IList<Sighting> list = SightingsDataSource.List;
			foreach (Sighting sighting in list)
			{
				ListViewItem item = new ListViewItem(sighting.Organism.Text);
				item.SubItems.Add(sighting.Date.ToShortDateString());
				item.SubItems.Add(sighting.Location.Text);
				item.SubItems.Add(sighting.Observer.Text);
				item.SubItems.Add(sighting.Comments);
				item.SubItems.Add("");
				item.Tag = sighting;

				// Restore selected state
				if (selectedSightings.Contains(sighting.ID))
				{
					item.Selected = true;
				}

				sightingsListView.Items.Add(item);
			}

			sightingsListView.EndUpdate();

			UpdateMenuAndToolStripButtonStatus();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewSighting();
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			NewSighting();
		}

        private void NewSighting()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                SightingsEditForm form = new SightingsEditForm();
                form.Collection = collection;
                form.Language = language;
                form.Sighting = new Sighting();
                if (this.OrganismID.HasValue)
                {
                    form.Sighting.Organism.ID = this.OrganismID.Value;
                }
                form.ObserverCreated += new EventHandler<EventArgs>(sightingsEditForm_ObserverCreated);
                form.SightingSaved += new EventHandler<EventArgs>(sightingsEditForm_SightingSaved);
                form.ShowDialog();

                // Cleanup event handlers after form is closed
                form.ObserverCreated -= sightingsEditForm_ObserverCreated;
                form.SightingSaved -= sightingsEditForm_SightingSaved;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        void sightingsEditForm_ObserverCreated(object sender, EventArgs e)
        {
            ObserversForm.RefreshForm();
        }

        void sightingsEditForm_SightingSaved(object sender, EventArgs e)
        {
            OnSightingsChanged();
        }

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenSelectedSighting();
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			OpenSelectedSighting();
		}

		private void sightingsListView_DoubleClick(object sender, EventArgs e)
		{
			OpenSelectedSighting();
		}

		private void OpenSelectedSighting()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				foreach (ListViewItem item in sightingsListView.SelectedItems)
				{
					SightingsEditForm form = new SightingsEditForm();
					form.Collection = collection;
					form.Language = language;
					form.Sighting = item.Tag as Sighting;
					form.ObserverCreated += new EventHandler<EventArgs>(sightingsEditForm_ObserverCreated);
                    form.SightingSaved += new EventHandler<EventArgs>(sightingsEditForm_SightingSaved);
                    form.ShowDialog();

                    // Cleanup event handlers after form is closed
                    form.ObserverCreated -= sightingsEditForm_ObserverCreated;
                    form.SightingSaved -= sightingsEditForm_SightingSaved;
                }
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteSelectedSightings();
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e)
		{
			DeleteSelectedSightings();
		}

		private void DeleteSelectedSightings()
		{
			int count = sightingsListView.SelectedItems.Count;

			if (count == 0)
			{
				return;
			}

			if (count == 1)
			{
				ListViewItem item = sightingsListView.SelectedItems[0];
				Sighting sighting = item.Tag as Sighting;

				if (MessageBox.Show(this, "Are you sure you want to delete the sighting of " + sighting.Organism.Text + " on " + sighting.Date.ToShortDateString() + "?", "Confirm Sighting Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					sighting.Delete();
					OnSightingsChanged();
				}
			}
			else
			{
				if (MessageBox.Show(this, "Are you sure you want to delete these " + count + " sightings?", "Confirm Multiple Sighting Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					sightingsListView.BeginUpdate();

					try
					{
						List<Sighting> sightings = new List<Sighting>(sightingsListView.SelectedItems.Count);
						foreach (ListViewItem item in sightingsListView.SelectedItems)
						{
							sightings.Add(item.Tag as Sighting);
						}

						// Delete the sightings
						Sighting.DeleteList(sightings);
						OnSightingsChanged();
					}
					finally
					{
						sightingsListView.EndUpdate();
					}
				}
			}

			UpdateMenuAndToolStripButtonStatus();
		}

		private void observersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewObservers();
		}

		private void observersToolStripButton_Click(object sender, EventArgs e)
		{
			ViewObservers();
		}

		private void ViewObservers()
		{
			ObserversForm openForm = Utility.GetOpenForm<ObserversForm>();
			if (openForm != null)
			{
				openForm.Activate();
			}
			else
			{
				ObserversForm form = new ObserversForm();
				form.Show();
			}
		}

		private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewReports();
		}

		private void reportsToolStripButton_Click(object sender, EventArgs e)
		{
			ViewReports();
		}

		private void ViewReports()
		{
			SightingsReportsForm form = new SightingsReportsForm();
			form.ShowDialog();
		}

		private void sightingsListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				sightingsListView.BeginUpdate();

				// Select all items
				foreach (ListViewItem item in sightingsListView.Items)
				{
					item.Selected = true;
				}

				sightingsListView.EndUpdate();
			}
		}

		private void sightingsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateMenuAndToolStripButtonStatus();
		}

		private void UpdateMenuAndToolStripButtonStatus()
		{
			int numSightingsSelected = sightingsListView.SelectedIndices.Count;

			// Update Open status
			bool canOpen = numSightingsSelected == 1;
			openToolStripMenuItem.Enabled = canOpen;
			openToolStripButton.Enabled = canOpen;

			// Update Delete status
			bool canDelete = numSightingsSelected > 0;
			deleteToolStripMenuItem.Enabled = canDelete;
			deleteToolStripButton.Enabled = canDelete;

			// Update Reports status
			bool canShowReports = sightingsListView.Items.Count > 0;
			reportsToolStripMenuItem.Enabled = canShowReports;
			reportsToolStripButton.Enabled = canShowReports;
		}

		private void sightingsListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortListView(e.Column);
		}

		private void SortListView(int columnIndex)
		{
			// Get current sort column and sort order
			SortOrder currentSortOrder = SightingsDataSource.SortOrder;
			SortableColumn currentSortColumn = SightingsDataSource.SortColumn;

			// Determine new sort column
			SortableColumn newSortColumn;
			if (!SightingColumnNameMap.TryGetValue(columnIndex, out newSortColumn))
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

			// Handle the special case for the Common Name column
			if (newSortColumn == SortableColumn.CommonName && currentSortColumn == SortableColumn.CommonName)
			{
				if (currentSortOrder == SortOrder.Descending)
				{
					newSortColumn = SortableColumn.TaxonomicOrder;
					newSortOrder = SortOrder.Ascending;
				}
			}

			SortListView(newSortColumn, newSortOrder);
		}

		private void SortListView(SortableColumn sortColumn, SortOrder sortOrder)
		{
			// Clear out images from all columns in the list view
			Utility.ListView_ClearAllHeaderImageFlags(sightingsListView.Handle);

			int columnIndex = SightingColumnIndexMap[sortColumn];
			bool setSortImage = true;

			// Handle the special case for the Common Name column
			if (sortColumn == SortableColumn.TaxonomicOrder)
			{
				sightingsListView.Columns[columnIndex].ImageKey = "SortTaxonomically";

				// ListView_SetHeaderImageFlag must be called after setting the
				// ImageKey property so that the image is right justified.
				Utility.ListView_SetHeaderImageFlag(sightingsListView.Handle, columnIndex);
				setSortImage = false;
			}

			if (setSortImage)
			{
				// Set the header sort image
				Utility.ListView_SetHeaderSortImage(sightingsListView.Handle, columnIndex, sortOrder == SortOrder.Ascending ? true : false);
			}

			// Sort the list based on the given sort column and sort order
			SightingsDataSource.Sort(sortColumn, sortOrder);

			// Load the sightings based on the new sort criteria
			RefreshSightings();

			// Make sure a selected item is visible
			EnsureSelectedItemIsVisible(sightingsListView);
		}

		private void EnsureSelectedItemIsVisible(ListView listView)
		{
			// Make sure the selected item is visible
			if (listView.SelectedIndices.Count >= 1)
			{
				listView.EnsureVisible(listView.SelectedIndices[0]);
			}
		}

		private int GetColumnIndex(SortableColumn column)
		{
			int columnIndex = 0;

			foreach (int index in SightingColumnNameMap.Keys)
			{
				if (SightingColumnNameMap[index] == column)
				{
					columnIndex = index;
					break;
				}
			}

			return columnIndex;
		}

		public static void RefreshForm()
		{
			// Refresh the sightings for all open SightingsForm forms
			List<SightingsForm> openForms = Utility.GetOpenForms<SightingsForm>();
			foreach (SightingsForm form in openForms)
			{
				form.RefreshSightings();
			}
		}

		private void OnSightingsChanged()
		{
			// Refresh the sightings for all open SightingsForm forms
			RefreshForm();

			// Fire event to notify listeners that the sightings have changed
			OnSightingsChanged(EventArgs.Empty);
		}

		private void saveAsCustomListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveAsCustomList();
		}

		private void saveAsCustomListToolStripButton_Click(object sender, EventArgs e)
		{
			SaveAsCustomList();
		}

		private void SaveAsCustomList()
		{
			CustomList customList = new CustomList();
			customList.CollectionID = Collection.ID;

			CustomListEditForm form = new CustomListEditForm();
			form.CustomList = customList;
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Application.DoEvents();
				Cursor = Cursors.WaitCursor;

				try
				{
					int order = 0;
					foreach (ListViewItem listViewItem in sightingsListView.Items)
					{
						Sighting sighting = listViewItem.Tag as Sighting;
						if (sighting != null)
						{
							int organismID = sighting.Organism.ID;
							if (customList.Contents.CanAdd(organismID))
							{
								CustomListItem item = new CustomListItem();
								item.CustomListID = customList.ID;
								item.Order = ++order;
								item.Organism.ID = organismID;
								customList.Contents.Add(item);
							}
						}
					}

					customList.Length = customList.Contents.Count;
					customList.SaveContents();

					// Refresh CustomListForm if open
					CustomListForm.RefreshForm();
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void sortTaxonomicallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SortTaxonomically();
		}

		private void sortTaxonomicallyToolStripButton_Click(object sender, EventArgs e)
		{
			SortTaxonomically();
		}

		private void SortTaxonomically()
		{
			SortListView(SortableColumn.TaxonomicOrder, SortOrder.Ascending);
		}
	}

	/// <summary>
	/// SightingsDataSource
	/// </summary>
	class SightingsDataSource
	{
		private int? organismID = null;
		private List<Sighting> list = null;
		private SortableColumn sortColumn = SortableColumn.CommonName;
		private SortOrder sortOrder = SortOrder.Ascending;

		public SightingsDataSource() : this(null)
		{
		}

		public SightingsDataSource(int? organismID)
		{
			this.organismID = organismID;
		}

		public IList<Sighting> List
		{
			get
			{
				return this.ListInternal;
			}
		}

		private List<Sighting> ListInternal
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
			list = organismID.HasValue ? Sighting.GetList(organismID.Value) : Sighting.GetList();
			Sort();
		}

		private void Sort()
		{
			this.ListInternal.Sort(new SightingComparer(this.SortColumn, this.SortOrder));
		}

		public void Sort(SortableColumn sortColumn, SortOrder sortOrder)
		{
			this.sortColumn = sortColumn;
			this.sortOrder = sortOrder;

			Sort();
		}
	}
}