using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SortableColumn = Thayer.Birding.UI.MediaComparer.SortableColumn;

namespace Thayer.Birding.UI.Windows
{
	public partial class MyMediaForm : BaseForm
	{
		private Organism organism = null;
		private MediaList mediaList = null;
		private SortableColumn sortColumn = SortableColumn.FileName;
		private SortOrder sortOrder = SortOrder.Ascending;
		private static Dictionary<int, SortableColumn> mediaColumnMap = null;
		private bool mediaChanged = false;

		public MyMediaForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			mediaColumnMap = new Dictionary<int, SortableColumn>(3);
			mediaColumnMap.Add(0, SortableColumn.FileName);
			mediaColumnMap.Add(1, SortableColumn.Caption);
			mediaColumnMap.Add(2, SortableColumn.Type);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			string organismName = this.Organism.CommonNameDisplay.Name;
			this.Text = "My Media : " + organismName;
			nameLabel.Text = "Name:  " + organismName;

			LoadMedia();
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

		public bool MediaChanged
		{
			get
			{
				return mediaChanged;
			}
		}

		private void LoadMedia(bool reloadData)
		{
			mediaListView.BeginUpdate();

			// Clear any existing items
			mediaListView.Items.Clear();

//			MediaCollection mediaCollection = CustomMedia.GetListByThingID(this.ThingID);
//			MediaCollection mediaCollection = CustomMedia.GetListByThingID(this.Organism.ID);

			if (reloadData)
			{
				mediaList = CustomMedia.GetListByThingID(this.Organism.ID).All;
			}

			// Sort the data
			Sort();

			foreach (IMedia media in mediaList)
			{
				ListViewItem item = new ListViewItem(media.FileName);
				item.SubItems.Add(media.Caption);
				item.SubItems.Add(MediaType.GetDescription(media.Type));
				item.Tag = media;

				mediaListView.Items.Add(item);
			}

			mediaListView.EndUpdate();

			UpdateControlStatus();
		}

		private void LoadMedia()
		{
			LoadMedia(true);
		}

		private void newPhotoButton_Click(object sender, EventArgs e)
		{
			NewPhoto();
		}

		private void photoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewPhoto();
		}

		private void newPhotoDropDownButtonMenuItem_Click(object sender, EventArgs e)
		{
			NewPhoto();
		}

		private void photoToolStripContextMenuItem_Click(object sender, EventArgs e)
		{
			NewPhoto();
		}

		private void NewPhoto()
		{
			MyMediaPhotoForm form = new MyMediaPhotoForm();
			form.Organism = this.Organism;
			if (form.ShowDialog() == DialogResult.OK)
			{
				mediaChanged = true;
				LoadMedia();
			}
		}

		private void newSoundButton_Click(object sender, EventArgs e)
		{
			NewSound();
		}

		private void soundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewSound();
		}

		private void newSoundDropDownButtonMenuItem_Click(object sender, EventArgs e)
		{
			NewSound();
		}

		private void soundToolStripContextMenuItem_Click(object sender, EventArgs e)
		{
			NewSound();
		}

		private void NewSound()
		{
			MyMediaSoundForm form = new MyMediaSoundForm();
			form.Organism = this.Organism;
			if (form.ShowDialog() == DialogResult.OK)
			{
				mediaChanged = true;
				LoadMedia();
			}
		}

		private void newVideoButton_Click(object sender, EventArgs e)
		{
			NewVideo();
		}

		private void videoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewVideo();
		}

		private void newVideoDropDownButtonMenuItem_Click(object sender, EventArgs e)
		{
			NewVideo();
		}

		private void videoToolStripContextMenuItem_Click(object sender, EventArgs e)
		{
			NewVideo();
		}

		private void NewVideo()
		{
			MyMediaVideoForm form = new MyMediaVideoForm();
			form.Organism = this.Organism;
			if (form.ShowDialog() == DialogResult.OK)
			{
				mediaChanged = true;
				LoadMedia();
			}
		}

		private void editMediaButton_Click(object sender, EventArgs e)
		{
			EditMedia();
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditMedia();
		}

		private void editToolStripButton_Click(object sender, EventArgs e)
		{
			EditMedia();
		}

		private void editToolStripContextMenuItem_Click(object sender, EventArgs e)
		{
			EditMedia();
		}

		private void mediaListView_DoubleClick(object sender, EventArgs e)
		{
			EditMedia();
		}

		private void EditMedia()
		{
			if (mediaListView.SelectedIndices.Count == 1)
			{
				IMedia media = mediaListView.SelectedItems[0].Tag as IMedia;

				switch (media.Type)
				{
					case MediaType.Photo:
						{
							MyMediaPhotoForm form = new MyMediaPhotoForm();
							form.Organism = this.Organism;
							form.Media = media;
							if (form.ShowDialog() == DialogResult.OK)
							{
								mediaChanged = true;
								LoadMedia();
							}
						}
						break;
					case MediaType.Sound:
						{
							MyMediaSoundForm form = new MyMediaSoundForm();
							form.Organism = this.Organism;
							form.Media = media;
							if (form.ShowDialog() == DialogResult.OK)
							{
								mediaChanged = true;
								LoadMedia();
							}
						}
						break;
					case MediaType.Video:
						{
							MyMediaVideoForm form = new MyMediaVideoForm();
							form.Organism = this.Organism;
							form.Media = media;
							if (form.ShowDialog() == DialogResult.OK)
							{
								mediaChanged = true;
								LoadMedia();
							}
						}
						break;
					default:
						break;
				}
			}
		}

		private void deleteMediaButton_Click(object sender, EventArgs e)
		{
			DeleteMedia();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteMedia();
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e)
		{
			DeleteMedia();
		}

		private void deleteToolStripContextMenuItem_Click(object sender, EventArgs e)
		{
			DeleteMedia();
		}

		private void DeleteMedia()
		{
			if (mediaListView.SelectedIndices.Count > 0)
			{
				if (MessageBox.Show(this, "Are you sure you want to delete the selected media?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					foreach (ListViewItem item in mediaListView.SelectedItems)
					{
						CustomMedia media = null;
						try
						{
							media = item.Tag as CustomMedia;
							media.DeleteByThingID(this.Organism.ID);
						}
						catch (Exception ex)
						{
							StringBuilder message = new StringBuilder("Error deleting media");
							if(media != null)
							{
								message.Append(" with file name \"");
								message.Append(media.FileName);
								message.Append("\"");
							}
							message.Append(" - ");
							message.Append(ex.Message);
							MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}

					mediaChanged = true;
					LoadMedia();
				}
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mediaListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControlStatus();
		}

		private void UpdateControlStatus()
		{
			switch (mediaListView.SelectedIndices.Count)
			{
				case 0:
					editMediaButton.Enabled = false;
					editToolStripMenuItem.Enabled = false;
					editToolStripButton.Enabled = false;
					editToolStripContextMenuItem.Enabled = false;

					deleteMediaButton.Enabled = false;
					deleteToolStripMenuItem.Enabled = false;
					deleteToolStripButton.Enabled = false;
					deleteToolStripContextMenuItem.Enabled = false;
					break;
				case 1:
					editMediaButton.Enabled = true;
					editToolStripMenuItem.Enabled = true;
					editToolStripButton.Enabled = true;
					editToolStripContextMenuItem.Enabled = true;

					deleteMediaButton.Enabled = true;
					deleteToolStripMenuItem.Enabled = true;
					deleteToolStripButton.Enabled = true;
					deleteToolStripContextMenuItem.Enabled = true;
					break;
				default:
					editMediaButton.Enabled = false;
					editToolStripMenuItem.Enabled = false;
					editToolStripButton.Enabled = false;
					editToolStripContextMenuItem.Enabled = false;

					deleteMediaButton.Enabled = true;
					deleteToolStripMenuItem.Enabled = true;
					deleteToolStripButton.Enabled = true;
					deleteToolStripContextMenuItem.Enabled = true;
					break;
			}
		}

		private void mediaListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine new sort column
			SortableColumn newSortColumn;
			if (!mediaColumnMap.TryGetValue(e.Column, out newSortColumn))
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
			LoadMedia(false);

			// Set the header sort image
			Utility.ListView_SetHeaderSortImage(mediaListView.Handle, e.Column, sortOrder == SortOrder.Ascending ? true : false);

			// Make sure a selected item is visible
//			EnsureSelectedItemIsVisible(categoryItemsListView);
		}

		private void Sort()
		{
			mediaList.Sort(new MediaComparer(sortColumn, sortOrder));
		}

		private void mediaListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				mediaListView.BeginUpdate();

				// Select all items
				foreach (ListViewItem item in mediaListView.Items)
				{
					item.Selected = true;
				}

				mediaListView.EndUpdate();
			}
			else if (e.KeyCode == Keys.Delete)
			{
				DeleteMedia();
			}
		}
	}
}