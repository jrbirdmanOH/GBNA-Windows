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
	public partial class MyMediaVideoForm : BaseForm
	{
		private Organism organism = null;
		private IMedia media = null;

		public MyMediaVideoForm()
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

		private string VideoFile
		{
			get
			{
				return videoFileTextBox.Text.Trim();
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
				videoFileTextBox.Text = media.AbsolutePath;
				captionTextBox.Text = media.Caption;

				this.Text = "Edit Video";
			}
			else
			{
				media = new CustomMedia();
				this.Text = "New Video";
			}

			UpdateControlStatus();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetVideoFileName();
			if (fileName.Length > 0)
			{
				videoFileTextBox.Text = fileName;
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
					media.FileName = Path.GetFileName(this.VideoFile);
					media.OriginalPath = Path.GetDirectoryName(this.VideoFile);
					media.Caption = this.Caption;
					media.Type = MediaType.Video;

					VideoForm form = new VideoForm();
					form.OrganismName = organism.CommonNameDisplay.Name;
					form.Media = media;
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
				CustomMedia video = media as CustomMedia;
				video.FileName = Path.GetFileName(this.VideoFile);
				video.OriginalPath = Path.GetDirectoryName(this.VideoFile);
				video.Caption = this.Caption;
				video.Type = MediaType.Video;

				bool bSave = true;
				if (video.NeedToOverwrite)
				{
					StringBuilder message = new StringBuilder();
					message.Append("File name \"");
					message.Append(video.FileName);
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
						video.SaveAndLinkToThing(this.Organism.ID);
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

			if (File.Exists(this.VideoFile) && IsValidFileExtension())
			{
				isValid = true;
			}
			else
			{
				if (showMessage)
				{
					MessageBox.Show("Please specify a valid video file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			return isValid;
		}

		private bool IsValidFileExtension()
		{
			bool isValid = false;

			string fileExtension = Path.GetExtension(this.VideoFile);
			fileExtension = fileExtension.ToLower();
			if (fileExtension == ".mpg" || fileExtension == ".wmv")
			{
				isValid = true;
			}

			return isValid;
		}

		private string GetVideoFileName()
		{
			string fileName = "";

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a Video File";
			dialog.Filter = "Video Files (*.mpg;*.wmv;)|*.mpg;*.wmv;";
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

		private void videoFileTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateControlStatus();
		}

		private void UpdateControlStatus()
		{
			previewButton.Enabled = IsValid(false);
		}
	}
}