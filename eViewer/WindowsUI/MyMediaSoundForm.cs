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
	public partial class MyMediaSoundForm : BaseForm
	{
		private Organism organism = null;
		private IMedia media = null;

		public MyMediaSoundForm()
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

		private string SoundFile
		{
			get
			{
				return soundFileTextBox.Text.Trim();
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
				soundFileTextBox.Text = media.AbsolutePath;
				captionTextBox.Text = media.Caption;

				this.Text = "Edit Sound";
			}
			else
			{
				media = new CustomMedia();
				this.Text = "New Sound";
			}

			UpdateControlStatus();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetSoundFileName();
			if (fileName.Length > 0)
			{
				soundFileTextBox.Text = fileName;
			}
		}

		private void previewButton_Click(object sender, EventArgs e)
		{
			if (IsValid())
			{
				try
				{
					SoundForm form = new SoundForm();
					form.Path = this.SoundFile;
					form.ShowDialog();
				}
				catch (Exception ex)
				{
					StringBuilder message = new StringBuilder("Error previewing media");
					message.Append(" with file name \"");
					message.Append(this.SoundFile);
					message.Append("\"");
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
				CustomMedia sound = media as CustomMedia;
				sound.FileName = Path.GetFileName(this.SoundFile);
				sound.OriginalPath = Path.GetDirectoryName(this.SoundFile);
				sound.Caption = this.Caption;
				sound.Type = MediaType.Sound;

				bool bSave = true;
				if (sound.NeedToOverwrite)
				{
					StringBuilder message = new StringBuilder();
					message.Append("File name \"");
					message.Append(sound.FileName);
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
						sound.SaveAndLinkToThing(this.Organism.ID);
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

			if (File.Exists(this.SoundFile) && IsValidFileExtension())
			{
				isValid = true;
			}
			else
			{
				if (showMessage)
				{
					MessageBox.Show("Please specify a valid sound file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			return isValid;
		}

		private bool IsValidFileExtension()
		{
			bool isValid = false;

			string fileExtension = Path.GetExtension(this.SoundFile);
			fileExtension = fileExtension.ToLower();
			if (fileExtension == ".mp3" || fileExtension == ".wav")
			{
				isValid = true;
			}

			return isValid;
		}

		private string GetSoundFileName()
		{
			string fileName = "";

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a Sound File";
			dialog.Filter = "Sound Files (*.mp3;*.wav;)|*.mp3;*.wav;";
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

		private void soundFileTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateControlStatus();
		}

		private void UpdateControlStatus()
		{
			previewButton.Enabled = IsValid(false);
		}
	}
}