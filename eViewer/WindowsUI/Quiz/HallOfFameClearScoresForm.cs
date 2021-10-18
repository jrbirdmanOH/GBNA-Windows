using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class HallOfFameClearScoresForm : Form
	{
		private event EventHandler hallOfFameListChanged;

		public HallOfFameClearScoresForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		public event EventHandler HallOfFameListChanged
		{
			add
			{
				hallOfFameListChanged += value;
			}

			remove
			{
				hallOfFameListChanged -= value;
			}
		}

		protected virtual void OnHallOfFameListChanged(EventArgs e)
		{
			if (hallOfFameListChanged != null)
			{
				hallOfFameListChanged(this, e);
			}
		}

		private void HallOfFameClearScoresForm_Load(object sender, EventArgs e)
		{
			LoadHallOfFameList();
			UpdateClearButtonStatus();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			ClearSelectedItems();
		}

		private void clearAllButton_Click(object sender, EventArgs e)
		{
			ClearAllItems();
		}

		private void LoadHallOfFameList()
		{
			hallOfFameListView.Items.Clear();

			List<string> quizNameList = HallOfFame.GetListOfUniqueQuizNames();
			foreach (string quizName in quizNameList)
			{
				ListViewItem item = new ListViewItem(quizName);
				item.Tag = quizName;
				hallOfFameListView.Items.Add(item);
			}
		}

		private void hallOfFameListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			UpdateClearButtonStatus();
		}

		private void ClearSelectedItems()
		{
			DialogResult result = MessageBox.Show(this, "Are you sure you want to clear the selected Hall of Fame scores?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				List<string> quizNamesToDelete = new List<string>();
				ListView.SelectedListViewItemCollection selectedItems = hallOfFameListView.SelectedItems;
				foreach (ListViewItem item in selectedItems)
				{
					quizNamesToDelete.Add((string)item.Tag);
				}

				if (quizNamesToDelete.Count > 0)
				{
					if (quizNamesToDelete.Count == hallOfFameListView.Items.Count)
					{
						HallOfFame.DeleteAll();
					}
					else
					{
						HallOfFame.DeleteByQuizNames(quizNamesToDelete);
					}

					// Fire event indicating that the Hall of Fame list has changed
					OnHallOfFameListChanged(new EventArgs());

					// Reload list after clearing any scores
					LoadHallOfFameList();
					UpdateClearButtonStatus();
				}
			}
		}

		private void ClearAllItems()
		{
			DialogResult result = MessageBox.Show(this, "Are you sure you want to clear all Hall of Fame scores?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				if (hallOfFameListView.Items.Count > 0)
				{
					HallOfFame.DeleteAll();
				}

				// Fire event indicating that the Hall of Fame list has changed
				OnHallOfFameListChanged(new EventArgs());

				// Reload list after clearing any scores
				LoadHallOfFameList();
				UpdateClearButtonStatus();
			}
		}

		private void UpdateClearButtonStatus()
		{
			clearButton.Enabled = hallOfFameListView.SelectedItems.Count > 0;
			clearAllButton.Enabled = hallOfFameListView.Items.Count > 0;
		}

		private void hallOfFameListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				// Select all items
				foreach (ListViewItem item in hallOfFameListView.Items)
				{
					item.Selected = true;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				ClearSelectedItems();
			}
		}
	}
}