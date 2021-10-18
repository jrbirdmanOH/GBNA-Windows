using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Thayer.Birding.UI.Windows
{
	public partial class CompareForm : BaseForm
	{
		private int collectionID = 0;
		private int languageID = Language.Default.ID;
		private int selectedLeftOrganismID = 0;
		private int selectedRightOrganismID = 0;
		private Dictionary<int, Organism> organisms = new Dictionary<int, Organism>();
		private Audio leftAudio = null;
		private Audio rightAudio = null;
		private event ViewEFieldGuideEventHandler viewEFieldGuide = null;

		private const string PlayRecordingText = "Play &Recording";
		private const string StopRecordingText = "Stop &Recording";

		public CompareForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<OrganismListItem> list = OrganismListItem.GetList(CollectionID, LanguageID);
			OrganismListItem[] organisms = list.ToArray();

			leftOrganismComboBox.Organisms = organisms;
			rightOrganismComboBox.Organisms = organisms;

			leftOrganismComboBox.SelectedOrganismID = selectedLeftOrganismID;
			rightOrganismComboBox.SelectedOrganismID = selectedRightOrganismID;

			if (splitContainer.Orientation == Orientation.Vertical)
			{
				horizontalToolStripMenuItem.Checked = true;
			}
			else
			{
				verticalToolStripMenuItem.Checked = true;
			}

			// Remove the View eField Guide menu option if an event handler is not defined
			if (viewEFieldGuide == null)
			{
				leftContextMenuStrip.Items.RemoveAt(2);
				rightContextMenuStrip.Items.RemoveAt(2);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			if (leftAudio != null)
			{
				StopAudio(leftAudio);
			}

			if (rightAudio != null)
			{
				StopAudio(rightAudio);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (leftAudio != null)
				{
					leftAudio.Dispose();
				}

				if (rightAudio != null)
				{
					rightAudio.Dispose();
				}

				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
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
			}
		}

		public int LanguageID
		{
			get
			{
				return languageID;
			}

			set
			{
				languageID = value;
			}
		}

		public int SelectedLeftOrganismID
		{
			get
			{
				return selectedLeftOrganismID;
			}

			set
			{
				selectedLeftOrganismID = value;

				leftOrganismComboBox.SelectedOrganismID = selectedLeftOrganismID;
			}
		}

		public int SelectedRightOrganismID
		{
			get
			{
				return selectedRightOrganismID;
			}

			set
			{
				selectedRightOrganismID = value;

				rightOrganismComboBox.SelectedOrganismID = selectedRightOrganismID;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (this.IsHandleCreated && WindowState != FormWindowState.Minimized)
			{
				UpdateLayout();
			}
		}

		private void UpdateLayout()
		{
			UpdateSplitterPosition();
			UpdateComboBoxLayout();
			RefreshLeftPhoto();
			RefreshRightPhoto();
		}

		private void leftOrganismComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshLeftMedia();
		}

		private void rightOrganismComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshRightMedia();
		}

		private void RefreshLeftMedia()
		{
			RefreshMedia(leftOrganismComboBox, leftMediaComboBox, playRecordingLeftToolStripMenuItem);
		}

		private void RefreshRightMedia()
		{
			RefreshMedia(rightOrganismComboBox, rightMediaComboBox, playRecordingRightToolStripMenuItem);
		}

		private void RefreshMedia(ComboBox organismComboBox, MediaComboBox mediaComboBox, ToolStripMenuItem playRecordingMenuItem)
		{
			OrganismListItem item = organismComboBox.SelectedItem as OrganismListItem;

			if (item != null)
			{
				Organism organism = GetOrganism(item.ID);
				mediaComboBox.Thing = organism;
				mediaComboBox.SelectedIndex = 0;

				playRecordingMenuItem.Enabled = organism.Sounds.Count > 0;
			}
		}

		private void RefreshLeftPhoto()
		{
			RefreshPhoto(leftMediaComboBox, leftPictureBox);
		}

		private void RefreshRightPhoto()
		{
			RefreshPhoto(rightMediaComboBox, rightPictureBox);
		}

		private void RefreshPhoto(MediaComboBox mediaComboBox, PictureBox pictureBox)
		{
			IMedia item = mediaComboBox.SelectedMedia;
			if (item != null)
			{
				if (item.Type == MediaType.Sound)
				{
					Utility.PlaySound(item.AbsolutePath);
				}
				else
				{
					if (pictureBox.Width > 0 && pictureBox.Height > 0)
					{
						Bitmap picture = new Bitmap(item.AbsolutePath);
						System.Drawing.Size newSize = Utility.GetOptimalSize(picture, pictureBox.Size);
						pictureBox.Image = new Bitmap(picture, newSize);
						this.toolTip.SetToolTip(pictureBox, item.FullCopyright);
					}
				}
			}
		}

		private Organism GetOrganism(int organismID)
		{
			Organism organism = null;

			if (!organisms.TryGetValue(organismID, out organism))
			{
				organism = Organism.GetByID(organismID);
				organisms[organismID] = organism;
			}

			return organism;
		}

		private void leftMediaComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StopAudio(leftAudio, playRecordingLeftToolStripMenuItem);
			RefreshLeftPhoto();
		}

		private void rightMediaComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StopAudio(rightAudio, playRecordingRightToolStripMenuItem);
			RefreshRightPhoto();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			verticalToolStripMenuItem.Checked = false;
			horizontalToolStripMenuItem.Checked = true;

			splitContainer.Orientation = Orientation.Vertical;
			UpdateLayout();
		}

		private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			verticalToolStripMenuItem.Checked = true;
			horizontalToolStripMenuItem.Checked = false;

			splitContainer.Orientation = Orientation.Horizontal;
			UpdateLayout();
		}

		private void UpdateSplitterPosition()
		{
			if (splitContainer.Orientation == Orientation.Horizontal)
			{
				splitContainer.SplitterDistance = (splitContainer.Height - splitContainer.SplitterWidth) / 2;
			}
			else
			{
				splitContainer.SplitterDistance = (splitContainer.Width - splitContainer.SplitterWidth) / 2;
			}
		}

		private void UpdateComboBoxLayout()
		{
			int space = 5;
			int dropDownWidth = 225;

			int leftComboBoxWidth = (leftPanel.Width - space) / 2;
			leftOrganismComboBox.Width = leftComboBoxWidth;
			leftOrganismComboBox.DropDownWidth = dropDownWidth;
			leftMediaComboBox.Left = leftOrganismComboBox.Right + space;
			leftMediaComboBox.Width = leftComboBoxWidth;
			leftMediaComboBox.DropDownWidth = dropDownWidth;

			int rightComboBoxWidth = (rightPanel.Width - space) / 2;
			rightOrganismComboBox.Width = rightComboBoxWidth;
			rightOrganismComboBox.DropDownWidth = dropDownWidth;
			rightMediaComboBox.Left = rightOrganismComboBox.Right + space;
			rightMediaComboBox.Width = rightComboBoxWidth;
			rightMediaComboBox.DropDownWidth = dropDownWidth;
		}

		private void Flip(PictureBox pictureBox)
		{
			Image image = pictureBox.Image;
			if (image != null)
			{
				image.RotateFlip(RotateFlipType.RotateNoneFlipX);

				pictureBox.Refresh();
			}
		}

		private void PlayRecording(OrganismComboBox organismComboBox, ToolStripMenuItem menuItem, ref Audio audio)
		{
			if (audio != null && !audio.Disposed && audio.State == StateFlags.Running)
			{
				StopAudio(audio, menuItem);
			}
			else
			{
				OrganismListItem item = organismComboBox.SelectedItem as OrganismListItem;

				if (item != null)
				{
					Organism organism = GetOrganism(item.ID);

					IMedia media = organism.Sounds[0];
					audio = new Audio(media.AbsolutePath);
					audio.Ending += new EventHandler(audio_Ending);
					audio.Play();
				}

				menuItem.Text = StopRecordingText;
			}
		}

		void audio_Ending(object sender, EventArgs e)
		{
			Audio audio = sender as Audio;
			if (audio != null && !audio.Disposed)
			{
				if (audio.State == StateFlags.Running)
				{
					audio.Stop();
				}

				if (audio == leftAudio)
				{
					playRecordingLeftToolStripMenuItem.Text = PlayRecordingText;
				}
				else if (audio == rightAudio)
				{
					playRecordingRightToolStripMenuItem.Text = PlayRecordingText;
				}
			}
		}

		private void StopAudio(Audio audio, ToolStripMenuItem menuItem)
		{
			StopAudio(audio);
			menuItem.Text = PlayRecordingText;
		}

		private void StopAudio(Audio audio)
		{
			if (audio != null && !audio.Disposed)
			{
				audio.Stop();
				audio.Dispose();
				audio = null;
			}
		}

		private void playRecordingLeftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayRecording(leftOrganismComboBox, playRecordingLeftToolStripMenuItem, ref leftAudio);
		}

		private void flipLeftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Flip(leftPictureBox);
		}

		private void playRecordingRightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayRecording(rightOrganismComboBox, playRecordingRightToolStripMenuItem, ref rightAudio);
		}

		private void flipRightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Flip(rightPictureBox);
		}

		public event ViewEFieldGuideEventHandler ViewEFieldGuide
		{
			add
			{
				viewEFieldGuide += value;
			}

			remove
			{
				viewEFieldGuide -= value;
			}
		}

		protected virtual void OnViewEFieldGuide(ViewEFieldGuideEventArgs e)
		{
			if (viewEFieldGuide != null)
			{
				viewEFieldGuide(this, e);
			}

			Close();
		}

		private void viewEFieldGuideLeftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OnViewEFieldGuide(new ViewEFieldGuideEventArgs(leftOrganismComboBox.SelectedOrganismID));
		}

		private void viewEFieldGuideRightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OnViewEFieldGuide(new ViewEFieldGuideEventArgs(rightOrganismComboBox.SelectedOrganismID));
		}
	}

	public delegate void ViewEFieldGuideEventHandler(object sender, ViewEFieldGuideEventArgs e);

	public class ViewEFieldGuideEventArgs
	{
		private int organismID;

		public ViewEFieldGuideEventArgs(int organismID)
		{
			this.organismID = organismID;
		}

		public int OrganismID
		{
			get
			{
				return organismID;
			}
		}
	}
}
