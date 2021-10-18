using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class OpenForm : BaseForm
	{
		private Collection selectedCollection = null;

		public OpenForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public Collection SelectedCollection
		{
			get
			{
				return selectedCollection;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<Collection> collections = Collection.GetList();
			collectionListView.BeginUpdate();
			foreach (Collection collection in collections)
			{
				ListViewItem item = new ListViewItem(collection.Name);
				item.Tag = collection;

				collectionListView.Items.Add(item);
			}
			collectionListView.EndUpdate();
		}

		private void collectionListView_DoubleClick(object sender, EventArgs e)
		{
			OpenSelectedItem();
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			OpenSelectedItem();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void OpenSelectedItem()
		{
			if (collectionListView.SelectedItems.Count > 0)
			{
				selectedCollection = collectionListView.SelectedItems[0].Tag as Collection;
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void collectionListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			openButton.Enabled = collectionListView.SelectedItems.Count > 0;
		}
	}
}