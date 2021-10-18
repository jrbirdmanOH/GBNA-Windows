using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizEditCategoryItemForm : BaseForm
	{
		public enum FormMode
		{
			New,
			Edit
		}

		private FormMode mode = FormMode.New;
		private CustomQuizCategory category = null;
		private CustomThing thing = null;
		private CustomMedia bestPhotoMedia = null;
		private CustomMedia alternatePhoto1Media = null;
		private CustomMedia alternatePhoto2Media = null;
		private CustomMedia alternatePhoto3Media = null;
		private CustomMedia soundMedia = null;

		public MyQuizEditCategoryItemForm(CustomQuizCategory category)
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			this.category = category;
		}

		public FormMode Mode
		{
			get
			{
				return mode;
			}

			set
			{
				mode = value;
			}
		}

		public CustomThing CategoryItem
		{
			get
			{
				return thing;
			}
			set
			{
				thing = value;
				mode = FormMode.Edit;

				if (IsHandleCreated)
				{
					Init();
				}
			}
		}

		private string ItemName
		{
			get
			{
				return nameTextBox.Text.Trim();
			}
		}

		private string AlternateItemName
		{
			get
			{
				return alternateNameTextBox.Text.Trim();
			}
		}

		private string BestPhotoPath
		{
			get
			{
				return bestPhotoTextBox.Text.Trim();
			}
		}

		private string BestPhotoCaption
		{
			get
			{
				return bestPhotoCaptionTextBox.Text.Trim();
			}
		}

		private CustomMedia BestPhotoMedia
		{
			get
			{
				if (bestPhotoMedia == null)
				{
					bestPhotoMedia = new CustomMedia();
				}
				bestPhotoMedia.FileName = Path.GetFileName(this.BestPhotoPath);
				bestPhotoMedia.OriginalPath = Path.GetDirectoryName(this.BestPhotoPath);
				bestPhotoMedia.Caption = this.BestPhotoCaption;
				bestPhotoMedia.Type = MediaType.Photo;

				return bestPhotoMedia;
			}
		}

		private string AlternatePhoto1Path
		{
			get
			{
				return alternatePhoto1TextBox.Text.Trim();
			}
		}

		private string AlternatePhoto1Caption
		{
			get
			{
				return alternatePhoto1CaptionTextBox.Text.Trim();
			}
		}

		private CustomMedia AlternatePhoto1Media
		{
			get
			{
				if (alternatePhoto1Media == null)
				{
					alternatePhoto1Media = new CustomMedia();
				}
				alternatePhoto1Media.FileName = Path.GetFileName(this.AlternatePhoto1Path);
				alternatePhoto1Media.OriginalPath = Path.GetDirectoryName(this.AlternatePhoto1Path);
				alternatePhoto1Media.Caption = this.AlternatePhoto1Caption;
				alternatePhoto1Media.Type = MediaType.Photo;

				return alternatePhoto1Media;
			}
		}

		private string AlternatePhoto2Path
		{
			get
			{
				return alternatePhoto2TextBox.Text.Trim();
			}
		}

		private string AlternatePhoto2Caption
		{
			get
			{
				return alternatePhoto2CaptionTextBox.Text.Trim();
			}
		}

		private CustomMedia AlternatePhoto2Media
		{
			get
			{
				if (alternatePhoto2Media == null)
				{
					alternatePhoto2Media = new CustomMedia();
				}
				alternatePhoto2Media.FileName = Path.GetFileName(this.AlternatePhoto2Path);
				alternatePhoto2Media.OriginalPath = Path.GetDirectoryName(this.AlternatePhoto2Path);
				alternatePhoto2Media.Caption = this.AlternatePhoto2Caption;
				alternatePhoto2Media.Type = MediaType.Photo;

				return alternatePhoto2Media;
			}
		}

		private string AlternatePhoto3Path
		{
			get
			{
				return alternatePhoto3TextBox.Text.Trim();
			}
		}

		private string AlternatePhoto3Caption
		{
			get
			{
				return alternatePhoto3CaptionTextBox.Text.Trim();
			}
		}

		private CustomMedia AlternatePhoto3Media
		{
			get
			{
				if (alternatePhoto3Media == null)
				{
					alternatePhoto3Media = new CustomMedia();
				}
				alternatePhoto3Media.FileName = Path.GetFileName(this.AlternatePhoto3Path);
				alternatePhoto3Media.OriginalPath = Path.GetDirectoryName(this.AlternatePhoto3Path);
				alternatePhoto3Media.Caption = this.AlternatePhoto3Caption;
				alternatePhoto3Media.Type = MediaType.Photo;

				return alternatePhoto3Media;
			}
		}

		private string SoundPath
		{
			get
			{
				return soundTextBox.Text.Trim();
			}
		}

		private string SoundCaption
		{
			get
			{
				return soundCaptionTextBox.Text.Trim();
			}
		}

		private CustomMedia SoundMedia
		{
			get
			{
				if (soundMedia == null)
				{
					soundMedia = new CustomMedia();
				}
				soundMedia.FileName = Path.GetFileName(this.SoundPath);
				soundMedia.OriginalPath = Path.GetDirectoryName(this.SoundPath);
				soundMedia.Caption = this.SoundCaption;
				soundMedia.Type = MediaType.Sound;

				return soundMedia;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Init();
		}

		private void Init()
		{
			if (thing == null)
			{
				thing = new CustomThing();
			}

			switch (mode)
			{
				case FormMode.New:
					this.Text = "Create a New Item";
					break;
				case FormMode.Edit:
					this.Text = "Edit Item";
					break;
			}

			nameTextBox.Text = thing.Name;
			alternateNameTextBox.Text = thing.AlternateNameOriginal;
			if (thing.Media.Sounds.Count > 0)
			{
				soundTextBox.Text = thing.Media.Sounds[0].AbsolutePath;
				soundMedia = thing.Media.Sounds[0] as CustomMedia;
			}

			switch (thing.Media.Photos.Count)
			{
				case 1:
					bestPhotoTextBox.Text = thing.Media.Photos[0].AbsolutePath;
					bestPhotoCaptionTextBox.Text = thing.Media.Photos[0].Caption;
					bestPhotoMedia = thing.Media.Photos[0] as CustomMedia;
					break;
				case 2:
					bestPhotoTextBox.Text = thing.Media.Photos[0].AbsolutePath;
					bestPhotoCaptionTextBox.Text = thing.Media.Photos[0].Caption;
					bestPhotoMedia = thing.Media.Photos[0] as CustomMedia;

					alternatePhoto1TextBox.Text = thing.Media.Photos[1].AbsolutePath;
					alternatePhoto1CaptionTextBox.Text = thing.Media.Photos[1].Caption;
					alternatePhoto1Media = thing.Media.Photos[1] as CustomMedia;
					break;
				case 3:
					bestPhotoTextBox.Text = thing.Media.Photos[0].AbsolutePath;
					bestPhotoCaptionTextBox.Text = thing.Media.Photos[0].Caption;
					bestPhotoMedia = thing.Media.Photos[0] as CustomMedia;

					alternatePhoto1TextBox.Text = thing.Media.Photos[1].AbsolutePath;
					alternatePhoto1CaptionTextBox.Text = thing.Media.Photos[1].Caption;
					alternatePhoto1Media = thing.Media.Photos[1] as CustomMedia;

					alternatePhoto2TextBox.Text = thing.Media.Photos[2].AbsolutePath;
					alternatePhoto2CaptionTextBox.Text = thing.Media.Photos[2].Caption;
					alternatePhoto2Media = thing.Media.Photos[2] as CustomMedia;
					break;
				case 4:
					bestPhotoTextBox.Text = thing.Media.Photos[0].AbsolutePath;
					bestPhotoCaptionTextBox.Text = thing.Media.Photos[0].Caption;
					bestPhotoMedia = thing.Media.Photos[0] as CustomMedia;

					alternatePhoto1TextBox.Text = thing.Media.Photos[1].AbsolutePath;
					alternatePhoto1CaptionTextBox.Text = thing.Media.Photos[1].Caption;
					alternatePhoto1Media = thing.Media.Photos[1] as CustomMedia;

					alternatePhoto2TextBox.Text = thing.Media.Photos[2].AbsolutePath;
					alternatePhoto2CaptionTextBox.Text = thing.Media.Photos[2].Caption;
					alternatePhoto2Media = thing.Media.Photos[2] as CustomMedia;

					alternatePhoto3TextBox.Text = thing.Media.Photos[3].AbsolutePath;
					alternatePhoto3CaptionTextBox.Text = thing.Media.Photos[3].Caption;
					alternatePhoto3Media = thing.Media.Photos[3] as CustomMedia;
					break;
			}

			UpdatePreviewButtonStatus();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (IsValid())
				{
					thing.Name = this.ItemName;
					thing.AlternateName = this.AlternateItemName;

					MediaCollection mediaCollection = new MediaCollection();

					if (File.Exists(this.BestPhotoPath))
					{
						mediaCollection.Add(this.BestPhotoMedia);
					}

					if (File.Exists(this.AlternatePhoto1Path))
					{
						mediaCollection.Add(this.AlternatePhoto1Media);
					}

					if (File.Exists(this.AlternatePhoto2Path))
					{
						mediaCollection.Add(this.AlternatePhoto2Media);
					}

					if (File.Exists(this.AlternatePhoto3Path))
					{
						mediaCollection.Add(this.AlternatePhoto3Media);
					}

					if (File.Exists(this.SoundPath))
					{
						mediaCollection.Add(this.SoundMedia);
					}

					thing.Media = mediaCollection;

					// Save the category item
					category.SaveCategoryItem(thing);

					DialogResult = DialogResult.OK;
				}
			}
			catch (Exception ex)
			{
				StringBuilder message = new StringBuilder("Error saving item - ");
				message.Append(ex.Message);
				MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private bool IsValid()
		{
			bool isValid = true;

			if (isValid && this.BestPhotoPath.Length > 0)
			{
				if (!IsValidBestPhoto())
				{
					isValid = false;
					MessageBox.Show("The file name specified for the best photo is not valid.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			if (isValid && this.AlternatePhoto1Path.Length > 0)
			{
				if (!IsValidAlternatePhoto1())
				{
					isValid = false;
					MessageBox.Show("The file name specified for the alternate photo 1 is not valid.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			if (isValid && this.AlternatePhoto2Path.Length > 0)
			{
				if (!IsValidAlternatePhoto2())
				{
					isValid = false;
					MessageBox.Show("The file name specified for the alternate photo 2 is not valid.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			if (isValid && this.AlternatePhoto3Path.Length > 0)
			{
				if (!IsValidAlternatePhoto3())
				{
					isValid = false;
					MessageBox.Show("The file name specified for the alternate photo 3 is not valid.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			if (isValid && this.SoundPath.Length > 0)
			{
				if (!IsValidSound())
				{
					isValid = false;
					MessageBox.Show("The file name specified for the sound is not valid.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			if (isValid && this.ItemName.Length == 0)
			{
				isValid = false;
				MessageBox.Show("Please enter a category item name.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			if (isValid && !File.Exists(this.BestPhotoPath))
			{
				isValid = false;
				MessageBox.Show("Please enter a best photo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			if (isValid)
			{
				StringBuilder message = new StringBuilder();
				StringCollection existingFileNames = GetExistingFileNames();
				if (existingFileNames.Count == 1)
				{
					message.Append("File name \"");
					message.Append(existingFileNames[0]);
					message.Append("\" already exists as a custom media file.\r\n\r\n");
					message.Append("Do you want to overwrite it?  Select\"Yes\" to overwrite ");
					message.Append("the file and save the category item.  Select \"No\" to ");
					message.Append("cancel saving the category item.");
				}
				else if (existingFileNames.Count > 1)
				{
					message.Append("File names ");
					int index = 0;
					foreach (string fileName in existingFileNames)
					{
						message.Append("\"");
						message.Append(fileName);
						message.Append("\"");
						if (index < existingFileNames.Count - 1)
						{
							if (index == existingFileNames.Count - 2)
							{
								message.Append(" and ");
							}
							else
							{
								message.Append(", ");
							}
						}
						index++;
					}
					message.Append(" already exist as custom media files.\r\n\r\n");
					message.Append("Do you want to overwrite them?  Select\"Yes\" to overwrite ");
					message.Append("the files and save the category item.  Select \"No\" to ");
					message.Append("cancel saving the category item.");
				}

				if (message.Length > 0)
				{
					if (MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						isValid = false;
					}
				}
			}

			return isValid;
		}

		private bool IsValidBestPhoto()
		{
			bool isValid = false;

			if (this.BestPhotoPath.Length > 0)
			{
				if (File.Exists(this.BestPhotoPath) && IsValidPhotoFileExtension(this.BestPhotoPath))
				{
					isValid = true;
				}
			}

			return isValid;
		}

		private bool IsValidAlternatePhoto1()
		{
			bool isValid = false;

			if (this.AlternatePhoto1Path.Length > 0)
			{
				if (File.Exists(this.AlternatePhoto1Path) && IsValidPhotoFileExtension(this.AlternatePhoto1Path))
				{
					isValid = true;
				}
			}

			return isValid;
		}

		private bool IsValidAlternatePhoto2()
		{
			bool isValid = false;

			if (this.AlternatePhoto2Path.Length > 0)
			{
				if (File.Exists(this.AlternatePhoto2Path) && IsValidPhotoFileExtension(this.AlternatePhoto2Path))
				{
					isValid = true;
				}
			}

			return isValid;
		}

		private bool IsValidAlternatePhoto3()
		{
			bool isValid = false;

			if (this.AlternatePhoto3Path.Length > 0)
			{
				if (File.Exists(this.AlternatePhoto3Path) && IsValidPhotoFileExtension(this.AlternatePhoto3Path))
				{
					isValid = true;
				}
			}

			return isValid;
		}

		private bool IsValidSound()
		{
			bool isValid = false;

			if (this.SoundPath.Length > 0)
			{
				if (File.Exists(this.SoundPath) && IsValidSoundFileExtension(this.SoundPath))
				{
					isValid = true;
				}
			}

			return isValid;
		}

		private bool IsValidPhotoFileExtension(string fileName)
		{
			bool isValid = false;

			string fileExtension = Path.GetExtension(fileName);
			fileExtension = fileExtension.ToLower();
			if (fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".jpg" || fileExtension == ".png")
			{
				isValid = true;
			}

			return isValid;
		}

		private bool IsValidSoundFileExtension(string fileName)
		{
			bool isValid = false;

			string fileExtension = Path.GetExtension(fileName);
			fileExtension = fileExtension.ToLower();
			if (fileExtension == ".mp3" || fileExtension == ".wav")
			{
				isValid = true;
			}

			return isValid;
		}

		private StringCollection GetExistingFileNames()
		{
			StringCollection existingFileNames = new StringCollection();

			if (File.Exists(this.BestPhotoPath))
			{
				CustomMedia media = this.BestPhotoMedia;
				if (media.NeedToOverwrite)
				{
					existingFileNames.Add(media.FileName);
				}
			}

			if (File.Exists(this.AlternatePhoto1Path))
			{
				CustomMedia media = this.AlternatePhoto1Media;
				if (media.NeedToOverwrite)
				{
					existingFileNames.Add(media.FileName);
				}
			}

			if (File.Exists(this.AlternatePhoto2Path))
			{
				CustomMedia media = this.AlternatePhoto2Media;
				if (media.NeedToOverwrite)
				{
					existingFileNames.Add(media.FileName);
				}
			}

			if (File.Exists(this.AlternatePhoto3Path))
			{
				CustomMedia media = this.AlternatePhoto3Media;
				if (media.NeedToOverwrite)
				{
					existingFileNames.Add(media.FileName);
				}
			}

			if (File.Exists(this.SoundPath))
			{
				CustomMedia media = this.SoundMedia;
				if (media.NeedToOverwrite)
				{
					existingFileNames.Add(media.FileName);
				}
			}

			return existingFileNames;
		}

		private void browseSoundButton_Click(object sender, EventArgs e)
		{
			string soundFileName = GetSoundFileName();
			if (File.Exists(soundFileName))
			{
				soundTextBox.Text = soundFileName;
			}
		}

		private string GetSoundFileName()
		{
			string fileName = "";

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a Sound File";
			dialog.Filter = "Sound Files (*.mp3;*.wav)|*.mp3;*.wav";
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.Multiselect = false;
			dialog.ShowReadOnly = false;
			dialog.RestoreDirectory = true;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = dialog.FileName;
			}

			return fileName;
		}

		private void bestPhotoBrowseButton_Click(object sender, EventArgs e)
		{
			string photoFileName = GetPhotoFileName();
			if (File.Exists(photoFileName))
			{
				bestPhotoTextBox.Text = photoFileName;
			}
		}

		private void alternatePhoto1BrowseButton_Click(object sender, EventArgs e)
		{
			string photoFileName = GetPhotoFileName();
			if (File.Exists(photoFileName))
			{
				alternatePhoto1TextBox.Text = photoFileName;
			}
		}

		private void alternatePhoto2BrowseButton_Click(object sender, EventArgs e)
		{
			string photoFileName = GetPhotoFileName();
			if (File.Exists(photoFileName))
			{
				alternatePhoto2TextBox.Text = photoFileName;
			}
		}

		private void alternatePhoto3BrowseButton_Click(object sender, EventArgs e)
		{
			string photoFileName = GetPhotoFileName();
			if (File.Exists(photoFileName))
			{
				alternatePhoto3TextBox.Text = photoFileName;
			}
		}

		private string GetPhotoFileName()
		{
			string fileName = "";

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a Photo File";
			dialog.Filter = "Image Files (*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png";
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.Multiselect = false;
			dialog.ShowReadOnly = false;
			dialog.RestoreDirectory = true;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = dialog.FileName;
			}

			return fileName;
		}

		private void bestPhotoPreviewButton_Click(object sender, EventArgs e)
		{
			PreviewMedia(0);
		}

		private void alternatePhoto1PreviewButton_Click(object sender, EventArgs e)
		{
			PreviewMedia(1);
		}

		private void alternatePhoto2PreviewButton_Click(object sender, EventArgs e)
		{
			PreviewMedia(2);
		}

		private void alternatePhoto3PreviewButton_Click(object sender, EventArgs e)
		{
			PreviewMedia(3);
		}

		private void PreviewMedia(int displayIndex)
		{
			bool showMedia = false;

			int initialPhotoIndex = 0;
			List<IMedia> photoList = new List<IMedia>();
			if (File.Exists(this.BestPhotoPath))
			{
				CustomMedia media = new CustomMedia();
				media.FileName = Path.GetFileName(this.BestPhotoPath);
				media.OriginalPath = Path.GetDirectoryName(this.BestPhotoPath);
				media.Caption = this.BestPhotoCaption;
				media.Type = MediaType.Photo;
				photoList.Add(media);
				if (displayIndex == 0)
				{
					showMedia = true;
				}
			}

			if (File.Exists(this.AlternatePhoto1Path))
			{
				CustomMedia media = new CustomMedia();
				media.FileName = Path.GetFileName(this.AlternatePhoto1Path);
				media.OriginalPath = Path.GetDirectoryName(this.AlternatePhoto1Path);
				media.Caption = this.AlternatePhoto1Caption;
				media.Type = MediaType.Photo;
				photoList.Add(media);
				if (displayIndex == 1)
				{
					initialPhotoIndex = photoList.Count - 1;
					showMedia = true;
				}
			}

			if (File.Exists(this.AlternatePhoto2Path))
			{
				CustomMedia media = new CustomMedia();
				media.FileName = Path.GetFileName(this.AlternatePhoto2Path);
				media.OriginalPath = Path.GetDirectoryName(this.AlternatePhoto2Path);
				media.Caption = this.AlternatePhoto2Caption;
				media.Type = MediaType.Photo;
				photoList.Add(media);
				if (displayIndex == 2)
				{
					initialPhotoIndex = photoList.Count - 1;
					showMedia = true;
				}
			}

			if (File.Exists(this.AlternatePhoto3Path))
			{
				CustomMedia media = new CustomMedia();
				media.FileName = Path.GetFileName(this.AlternatePhoto3Path);
				media.OriginalPath = Path.GetDirectoryName(this.AlternatePhoto3Path);
				media.Caption = this.AlternatePhoto3Caption;
				media.Type = MediaType.Photo;
				photoList.Add(media);
				if (displayIndex == 3)
				{
					initialPhotoIndex = photoList.Count - 1;
					showMedia = true;
				}
			}

			List<IMedia> soundList = new List<IMedia>();
			if (File.Exists(this.SoundPath))
			{
				CustomMedia media = new CustomMedia();
				media.FileName = Path.GetFileName(this.SoundPath);
				media.OriginalPath = Path.GetDirectoryName(this.SoundPath);
				media.Caption = this.SoundCaption;
				media.Type = MediaType.Sound;
				soundList.Add(media);
			}

			if (showMedia)
			{
				PhotoForm form = new PhotoForm();
				form.OrganismName = nameTextBox.Text;
				form.Photos = photoList.ToArray();
				form.Sounds = soundList.ToArray();
				form.SelectedPhotoIndex = initialPhotoIndex;

				form.ShowDialog();
			}
			else
			{
				MessageBox.Show("Please specify a valid photo file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void soundPreviewButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(this.SoundPath))
			{
				SoundForm form = new SoundForm();
				form.Path = soundTextBox.Text;
				form.ShowDialog();
			}
			else
			{
				MessageBox.Show("Please specify a valid sound file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void bestPhotoTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateBestPhotoPreviewButtonStatus();
		}

		private void alternatePhoto1TextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateAlternatePhoto1PreviewButtonStatus();
		}

		private void alternatePhoto2TextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateAlternatePhoto2PreviewButtonStatus();
		}

		private void alternatePhoto3TextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateAlternatePhoto3PreviewButtonStatus();
		}

		private void soundTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateSoundPreviewButtonStatus();
		}

		private void UpdatePreviewButtonStatus()
		{
			UpdateBestPhotoPreviewButtonStatus();
			UpdateAlternatePhoto1PreviewButtonStatus();
			UpdateAlternatePhoto2PreviewButtonStatus();
			UpdateAlternatePhoto3PreviewButtonStatus();
			UpdateSoundPreviewButtonStatus();
		}

		private void UpdateBestPhotoPreviewButtonStatus()
		{
			bestPhotoPreviewButton.Enabled = IsValidBestPhoto();
		}

		private void UpdateAlternatePhoto1PreviewButtonStatus()
		{
			alternatePhoto1PreviewButton.Enabled = IsValidAlternatePhoto1();
		}

		private void UpdateAlternatePhoto2PreviewButtonStatus()
		{
			alternatePhoto2PreviewButton.Enabled = IsValidAlternatePhoto2();
		}

		private void UpdateAlternatePhoto3PreviewButtonStatus()
		{
			alternatePhoto3PreviewButton.Enabled = IsValidAlternatePhoto3();
		}

		private void UpdateSoundPreviewButtonStatus()
		{
			soundPreviewButton.Enabled = IsValidSound();
		}
	}
}