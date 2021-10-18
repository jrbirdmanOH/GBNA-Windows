using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Thayer.Birding.UI.Windows
{
	public partial class MyMediaPhotoForm : BaseForm
	{
		private Organism organism = null;
		private IMedia media = null;

		public MyMediaPhotoForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
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

		public IMedia Media
		{
			get
			{
				return media;
			}

			set
			{
				media = value;
			}
		}

		private string PhotoFile
		{
			get
			{
				return photoFileTextBox.Text.Trim();
			}
		}

		private string Caption
		{
			get
			{
				return captionTextBox.Text.Trim();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Init();
		}

		private void Init()
		{
			if (media != null)
			{
				photoFileTextBox.Text = media.AbsolutePath;
				captionTextBox.Text = media.Caption;

				this.Text = "Edit Photo";
			}
			else
			{
				media = new CustomMedia();
				this.Text = "New Photo";
			}

			UpdateControlStatus();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetPhotoFileName();
			if (fileName.Length > 0)
			{
				photoFileTextBox.Text = fileName;
			}
		}

		private void previewButton_Click(object sender, EventArgs e)
		{
			if (IsValid())
			{
				CustomMedia media = null;
				try
				{
					media = new CustomMedia();
					media.FileName = Path.GetFileName(this.PhotoFile);
					media.OriginalPath = Path.GetDirectoryName(this.PhotoFile);
					media.Caption = this.Caption;
					media.Type = MediaType.Photo;

					List<IMedia> photoList = new List<IMedia>();
					photoList.Add(media);

					PhotoForm form = new PhotoForm();
					form.OrganismName = organism.CommonNameDisplay.Name;
					form.Photos = photoList.ToArray();
					form.SelectedPhotoIndex = 0;
					form.ShowDialog();
				}
				catch (Exception ex)
				{
					StringBuilder message = new StringBuilder("Error previewing media");
					if (media != null)
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
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (IsValid())
			{
				CustomMedia photo = media as CustomMedia;
				photo.FileName = Path.GetFileName(this.PhotoFile);
				photo.OriginalPath = Path.GetDirectoryName(this.PhotoFile);
				photo.Caption = this.Caption;
				photo.Type = MediaType.Photo;

				bool bSave = true;
				if (photo.NeedToOverwrite)
				{
					StringBuilder message = new StringBuilder();
					message.Append("File name \"");
					message.Append(photo.FileName);
					message.Append("\" already exists as a custom media file.\r\n\r\n");
					message.Append("Do you want to overwrite it?  Select\"Yes\" to overwrite ");
					message.Append("the file and associated media information.  Select \"No\" to ");
					message.Append("cancel saving the media.");

					if (MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						bSave = false;
					}
				}

				if (bSave)
				{
					try
					{
						photo.SaveAndLinkToThing(this.Organism.ID);
						DialogResult = DialogResult.OK;
					}
					catch (Exception ex)
					{
						StringBuilder message = new StringBuilder("Error saving media - ");
						message.Append(ex.Message);
						MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		private bool IsValid()
		{
			return IsValid(true);
		}

		private bool IsValid(bool showMessage)
		{
			bool isValid = false;

			if (File.Exists(this.PhotoFile) && IsValidFileExtension())
			{
				isValid = true;
			}
			else
			{
				if (showMessage)
				{
					MessageBox.Show("Please specify a valid photo file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			return isValid;
		}

		private bool IsValidFileExtension()
		{
			bool isValid = false;

			string fileExtension = Path.GetExtension(this.PhotoFile);
			fileExtension = fileExtension.ToLower();
			if (fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".jpg" || fileExtension == ".png")
			{
				isValid = true;
			}

			return isValid;
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

		private void photoFileTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateControlStatus();
		}

		private void UpdateControlStatus()
		{
			previewButton.Enabled = IsValid(false);
		}
	}
}