using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class ObserversForm : BaseForm
	{
		private ObserversDataSource observersDataSource = null;
		private static Dictionary<int, ObserversDataSource.SortableColumn> observerColumnMap = null;

		public ObserversForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private ObserversDataSource ObserversDataSource
		{
			get
			{
				if (observersDataSource == null)
				{
					observersDataSource = new ObserversDataSource();
				}

				return observersDataSource;
			}
		}

		private static Dictionary<int, ObserversDataSource.SortableColumn> ObserverColumnMap
		{
			get
			{
				if (observerColumnMap == null)
				{
					observerColumnMap = new Dictionary<int, ObserversDataSource.SortableColumn>(3);
					observerColumnMap.Add(0, ObserversDataSource.SortableColumn.LastName);
					observerColumnMap.Add(1, ObserversDataSource.SortableColumn.FirstName);
					observerColumnMap.Add(2, ObserversDataSource.SortableColumn.MiddleInitial);
				}

				return observerColumnMap;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			RefreshObservers();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(observersListView.Handle, GetColumnIndex(ObserversDataSource.SortColumn), ObserversDataSource.SortOrder == SortOrder.Ascending ? true : false);
		}

		public void RefreshObservers()
		{
			observersListView.BeginUpdate();

			// Get any existing selections
			List<int> selectedObservers = new List<int>(observersListView.SelectedItems.Count);
			foreach (ListViewItem item in observersListView.SelectedItems)
			{
				Observer observer = item.Tag as Observer;
				if (observer != null)
				{
					selectedObservers.Add(observer.ID);
				}
			}

			// Clear any existing items
			observersListView.Items.Clear();

			ObserversDataSource.Refresh();
			IList<Observer> list = ObserversDataSource.List;
			foreach (Observer observer in list)
			{
				ListViewItem item = new ListViewItem(observer.LastName);
				item.SubItems.Add(observer.FirstName);
				item.SubItems.Add(observer.MiddleInitial);
				item.Tag = observer;

				// Restore selected state
				if (selectedObservers.Contains(observer.ID))
				{
					item.Selected = true;
				}

				observersListView.Items.Add(item);
			}

			observersListView.EndUpdate();

			UpdateMenuAndToolStripButtonStatus();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewObserver();
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			NewObserver();
		}

		private void NewObserver()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				ObserverEditForm form = new ObserverEditForm();
				form.Observer = new Observer();
				if (form.ShowDialog() == DialogResult.OK)
				{
					RefreshObservers();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenSelectedObserver();
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			OpenSelectedObserver();
		}

		private void observersListView_DoubleClick(object sender, EventArgs e)
		{
			OpenSelectedObserver();
		}

		private void OpenSelectedObserver()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				foreach (ListViewItem item in observersListView.SelectedItems)
				{
					ObserverEditForm form = new ObserverEditForm();
					form.Observer = item.Tag as Observer;
					if (form.ShowDialog() == DialogResult.OK)
					{
						RefreshObservers();

						// Refresh any open SightingsForm forms
						SightingsForm.RefreshForm();
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
			DeleteSelectedObservers();
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e)
		{
			DeleteSelectedObservers();
		}

		private void DeleteSelectedObservers()
		{
			int count = observersListView.SelectedItems.Count;

			if (count == 0)
			{
				return;
			}

			if (count == 1)
			{
				ListViewItem item = observersListView.SelectedItems[0];
				Observer observer = item.Tag as Observer;

				StringBuilder message = new StringBuilder("Are you sure you want to delete observer \"");
				message.Append(observer.FullName);
				message.Append("\"?\r\n\r\n");
				message.Append("NOTE:  All sightings for this observer will also be deleted.");

				if (MessageBox.Show(this, message.ToString(), "Confirm Observer Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					observersListView.Items.Remove(item);
					observer.Delete();

					// Refresh any open SightingsForm forms
					SightingsForm.RefreshForm();
				}
			}
			else
			{
				StringBuilder message = new StringBuilder("Are you sure you want to delete the selected observers?\r\n\r\n");
				message.Append("NOTE:  All sightings for these observers will also be deleted.");

				if (MessageBox.Show(this, message.ToString(), "Confirm Multiple Observer Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					observersListView.BeginUpdate();

					try
					{
						List<Observer> observers = new List<Observer>(observersListView.SelectedItems.Count);
						foreach (ListViewItem item in observersListView.SelectedItems)
						{
							observers.Add(item.Tag as Observer);
							observersListView.Items.Remove(item);
						}

						// Delete the observers
						Observer.DeleteList(observers);

						// Refresh any open SightingsForm forms
						SightingsForm.RefreshForm();
					}
					finally
					{
						observersListView.EndUpdate();
					}
				}
			}

			UpdateMenuAndToolStripButtonStatus();
		}

		private void observersListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Get current sort column and sort order
			SortOrder currentSortOrder = ObserversDataSource.SortOrder;
			ObserversDataSource.SortableColumn currentSortColumn = ObserversDataSource.SortColumn;

			// Determine new sort column
			ObserversDataSource.SortableColumn newSortColumn;
			if (!ObserverColumnMap.TryGetValue(e.Column, out newSortColumn))
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
			ObserversDataSource.Sort(newSortColumn, newSortOrder);

			// Load the observers based on the new sort criteria
			RefreshObservers();

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(observersListView.Handle, e.Column, newSortOrder == SortOrder.Ascending ? true : false);

			// Make sure a selected item is visible
			EnsureSelectedItemIsVisible(observersListView);
		}

		private void EnsureSelectedItemIsVisible(ListView listView)
		{
			// Make sure the selected item is visible
			if (listView.SelectedIndices.Count >= 1)
			{
				listView.EnsureVisible(listView.SelectedIndices[0]);
			}
		}

		private void observersListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				observersListView.BeginUpdate();

				// Select all items
				foreach (ListViewItem item in observersListView.Items)
				{
					item.Selected = true;
				}

				observersListView.EndUpdate();
			}
		}

		private void observersListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateMenuAndToolStripButtonStatus();
		}

		private void UpdateMenuAndToolStripButtonStatus()
		{
			int numObserversSelected = observersListView.SelectedIndices.Count;

			// Update Open status
			bool canOpen = numObserversSelected == 1;
			openToolStripMenuItem.Enabled = canOpen;
			openToolStripButton.Enabled = canOpen;

			// Update Delete status
			bool canDelete = numObserversSelected > 0;
			deleteToolStripMenuItem.Enabled = canDelete;
			deleteToolStripButton.Enabled = canDelete;
		}

		private int GetColumnIndex(ObserversDataSource.SortableColumn column)
		{
			int columnIndex = 0;

			foreach (int index in ObserverColumnMap.Keys)
			{
				if (ObserverColumnMap[index] == column)
				{
					columnIndex = index;
					break;
				}
			}

			return columnIndex;
		}

		public static void RefreshForm()
		{
			// Refresh the observers for all open ObserversForm forms (should only be max of one)
			List<ObserversForm> openForms = Utility.GetOpenForms<ObserversForm>();
			foreach (ObserversForm form in openForms)
			{
				form.RefreshObservers();
			}
		}
	}

	/// <summary>
	/// ObserversDataSource
	/// </summary>
	class ObserversDataSource
	{
		public enum SortableColumn
		{
			LastName,
			FirstName,
			MiddleInitial
		}

		private List<Observer> list = null;
		private SortableColumn sortColumn = SortableColumn.LastName;
		private SortOrder sortOrder = SortOrder.Ascending;

		public ObserversDataSource()
		{
		}

		public IList<Observer> List
		{
			get
			{
				return this.ListInternal;
			}
		}

		private List<Observer> ListInternal
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
			list = Observer.GetList();
			Sort();
		}

		private void Sort()
		{
			this.ListInternal.Sort(new ObserverComparer(this.SortColumn, this.SortOrder));
		}

		public void Sort(SortableColumn sortColumn, SortOrder sortOrder)
		{
			this.sortColumn = sortColumn;
			this.sortOrder = sortOrder;

			Sort();
		}

		private class ObserverComparer : IComparer<Observer>
		{
			private SortableColumn sortColumn = SortableColumn.LastName;
			private SortOrder sortOrder = SortOrder.Ascending;

			public ObserverComparer(SortableColumn sortColumn, SortOrder sortOrder)
			{
				this.sortColumn = sortColumn;
				this.sortOrder = sortOrder;
			}

			public int Compare(Observer x, Observer y)
			{
				int compareResult = 0;
				bool enforceSortOrder = true;
				switch (sortColumn)
				{
					case SortableColumn.LastName:
						compareResult = x.LastName.CompareTo(y.LastName);
						if (compareResult == 0)
						{
							compareResult = x.FirstName.CompareTo(y.FirstName);
							enforceSortOrder = false;
						}
						break;
					case SortableColumn.FirstName:
						compareResult = x.FirstName.CompareTo(y.FirstName);
						if (compareResult == 0)
						{
							compareResult = x.LastName.CompareTo(y.LastName);
							enforceSortOrder = false;
						}
						break;
					case SortableColumn.MiddleInitial:
						compareResult = x.MiddleInitial.CompareTo(y.MiddleInitial);
						if (compareResult == 0)
						{
							compareResult = x.LastName.CompareTo(y.LastName);
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
}