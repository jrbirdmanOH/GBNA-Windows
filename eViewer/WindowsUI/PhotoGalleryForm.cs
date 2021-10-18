using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class PhotoGalleryForm : BaseForm, IPhotoGalleryForm
	{
		private Collection collection = null;
		private IShowsBird showsBirdProvider = null;

		public PhotoGalleryForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			photoGallery.PhotoGalleryForm = this;
		}

		[DefaultValue(null)]
		public int[] OrganismIDs
		{
			get
			{
				return photoGallery.OrganismIDs;
			}

			set
			{
				photoGallery.OrganismIDs = value;

				if (value != null)
				{
					// Set the default image preference and generate the HTML
					SetImagePreference(ImagePreferenceType.Primary);
				}
			}
		}

		[Browsable(false)]
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

		[Browsable(false)]
		public IShowsBird ShowsBirdProvider
		{
			get
			{
				return showsBirdProvider;
			}

			set
			{
				showsBirdProvider = value;
			}
		}

		private ImagePreferenceType ImagePreference
		{
			get
			{
				return secondaryRadioButton.Checked ? ImagePreferenceType.Secondary : ImagePreferenceType.Primary;
			}
		}

		ImagePreferenceType IPhotoGalleryForm.GetImagePreference()
		{
			return this.ImagePreference;
		}

		void IPhotoGalleryForm.ShowWorking(bool isWorking)
		{
			if (isWorking)
			{
				Cursor = Cursors.WaitCursor;
			}
			else
			{
				Cursor = Cursors.Default;
			}
		}

		private void GeneratePhotoGalleryHTML()
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				string htmlFilename = photoGallery.GeneratePhotoGalleryHTML(this.ImagePreference);
				webBrowser.Navigate(htmlFilename);
				webBrowser.Focus();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.webBrowser.Focus();
		}

		private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			bool htmlDirty;
			e.Cancel = photoGallery.OnLinkClick(e.Url.OriginalString, out htmlDirty);

			if (htmlDirty)
			{
				GeneratePhotoGalleryHTML();
			}
		}

		void IImageGenerator.GenerateImage(string source, int width, int height, string destination)
		{
			Utility.GenerateImage(source, width, height, destination);
		}

		void IPlaysSound.PlaySound(string path, bool loop)
		{
			Utility.ShowSoundForm(path, loop);
		}

		void IShowsBird.ShowBird(int organismID)
		{
			if (this.ShowsBirdProvider != null)
			{
				this.ShowsBirdProvider.ShowBird(organismID);
			}
		}

		void IShowsBird.SetImagePreference(ImagePreferenceType imagePreference)
		{
			SetImagePreference(imagePreference);
		}

		void IShowsBird.ShowNewBird(Collection collection, int organismID)
		{
			if (this.ShowsBirdProvider != null && this.Collection != null)
			{
				this.ShowsBirdProvider.ShowNewBird(this.Collection, organismID);
			}
		}

		void IShowsPhotos.ShowPhotos(string organismName, IMedia[] photos, IMedia[] sounds, int initialPhotoIndex)
		{
			Utility.ShowPhotos(organismName, photos, sounds, initialPhotoIndex);
		}

		void IShowsPhotoList.ShowPhotoList(List<PhotoListItem> photoListItems, int selectedListIndex)
		{
			Utility.ShowPhotoList(photoListItems, selectedListIndex);
		}

		private void SetImagePreference(ImagePreferenceType imagePreference)
		{
			if (imagePreference == ImagePreferenceType.Secondary)
			{
				primaryToolStripMenuItem.Checked = false;
				secondaryToolStripMenuItem.Checked = true;

				primaryRadioButton.Checked = false;
				secondaryRadioButton.Checked = true;
			}
			else
			{
				primaryToolStripMenuItem.Checked = true;
				secondaryToolStripMenuItem.Checked = false;

				primaryRadioButton.Checked = true;
				secondaryRadioButton.Checked = false;
			}

			GeneratePhotoGalleryHTML();

			this.webBrowser.Focus();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void primaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!primaryToolStripMenuItem.Checked)
			{
				SetImagePreference(ImagePreferenceType.Primary);
			}
		}

		private void secondaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!secondaryToolStripMenuItem.Checked)
			{
				SetImagePreference(ImagePreferenceType.Secondary);
			}
		}

		private void primaryRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (primaryRadioButton.Checked)
			{
				SetImagePreference(ImagePreferenceType.Primary);
			}
		}

		private void secondaryRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (secondaryRadioButton.Checked)
			{
				SetImagePreference(ImagePreferenceType.Secondary);
			}
		}

		private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				Help.ShowHelp(this, helpProvider.HelpNamespace, HelpNavigator.TopicId, helpProvider.GetHelpKeyword(this));
			}
		}

		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.webBrowser.Focus();
		}
	}
}