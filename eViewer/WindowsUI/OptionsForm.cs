using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Thayer.Birding.Filtering;

namespace Thayer.Birding.UI.Windows
{
	public partial class OptionsForm : BaseForm
	{
		public OptionsForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			spectrogramPathTextBox.Text = ApplicationSettings.SpectrogramLocation;

			LoadFilterOptions();
			LoadNameListOptions();
			LoadQuizOptions();
			LoadSightingsOptions();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				DialogResult = DialogResult.OK;

				ApplicationSettings.SpectrogramLocation = spectrogramPathTextBox.Text;

				SaveFilterOptions();
				SaveNameListOptions();
				SaveQuizOptions();
				SaveSightingsOptions();

				Close();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void browseSpectrogramButton_Click(object sender, EventArgs e)
		{
			string spectrogramFileName = spectrogramPathTextBox.Text.Trim();
			string initialFileName = string.IsNullOrEmpty(spectrogramFileName) ? null : spectrogramFileName;
			string file = Utility.BrowseForSpectrogram(this, initialFileName);
			if (file != null)
			{
				spectrogramPathTextBox.Text = file;
			}
		}

		private void LoadFilterOptions()
		{
			// Set the status of the restore filter at startup check box
			restoreFilterAtStartupCheckBox.Checked = UserSettings.Instance.FilterSettings.RestoreFilterAtStartup;
		}

		private void SaveFilterOptions()
		{
			// Save filter options (setting FilterSettings properties will force save)
			FilterSettings filterSettings = UserSettings.Instance.FilterSettings;
			filterSettings.RestoreFilterAtStartup = restoreFilterAtStartupCheckBox.Checked;
			UserSettings.Instance.FilterSettings = filterSettings;
		}

		private void LoadNameListOptions()
		{
			// Load combo box with available languages
			List<Language> languages = Language.GetList();
			languageComboBox.Items.AddRange(languages.ToArray());

			// Select the user's chosen language
			foreach (Language language in languageComboBox.Items)
			{
				if (language.ID == UserSettings.Instance.Language.ID)
				{
					languageComboBox.SelectedItem = language;
					break;
				}
			}

			// Set the status of the Show Aliases check box
			showAliasesCheckBox.Checked = UserSettings.Instance.ShowAliases;
		}

		private void SaveNameListOptions()
		{
			// Set default language
			int languageID = Language.Default.ID;

			// Get selected language
			Language language = languageComboBox.SelectedItem as Language;
			if (language != null)
			{
				languageID = language.ID;
			}

			// Set language ID option
			UserSettings.Instance.Language = Language.GetByID(languageID);

			// Set ShowAliases option
			UserSettings.Instance.ShowAliases = showAliasesCheckBox.Checked;
		}

		private void LoadQuizOptions()
		{
			quizRestartCheckBox.Checked = ApplicationSettings.RestartQuiz;
			bool enableHallOfFame = ApplicationSettings.EnableHallOfFame;
			enableHallOfFameCheckBox.Checked = enableHallOfFame;
			SetHallOfFameStatus(enableHallOfFame);
			if (enableHallOfFame)
			{
				numberOfTopScorersNumericUpDown.Value = ApplicationSettings.NumberOfHallOfFameTopScorers;
				soundEffectTextBox.Text = ApplicationSettings.HallOfFameSoundEffectLocation;
				SetSoundEffectPlayButtonStatus();
			}
		}

		private void SaveQuizOptions()
		{
			ApplicationSettings.RestartQuiz = quizRestartCheckBox.Checked;
			ApplicationSettings.EnableHallOfFame = enableHallOfFameCheckBox.Checked;
			if (enableHallOfFameCheckBox.Checked)
			{
				bool updateTopScorers = true;
				int numberOfHallOfFameTopScorers = Convert.ToInt32(numberOfTopScorersNumericUpDown.Value);
				if (numberOfHallOfFameTopScorers < ApplicationSettings.NumberOfHallOfFameTopScorers)
				{
					DialogResult result = MessageBox.Show(this, "Reducing the number of top scorers may result in the deletion of entries to enforce this new setting.  Do you wish to update the value?", "Hall of Fame Top Scorers", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
					if (result != DialogResult.Yes)
					{
						updateTopScorers = false;
					}
				}

				if (updateTopScorers)
				{
					ApplicationSettings.NumberOfHallOfFameTopScorers = numberOfHallOfFameTopScorers;
					HallOfFame.OnNumberOfHallOfFameTopScorersChanged();
				}

				ApplicationSettings.HallOfFameSoundEffectLocation = soundEffectTextBox.Text;
			}
		}

		private void LoadSightingsOptions()
		{
			bool hideSightingsComments = UserSettings.Instance.HideSightingsComments;
			hideSightingsCommentsCheckBox.Checked = hideSightingsComments;

			bool limitNumberOfSightings = UserSettings.Instance.LimitNumberOfSightingsToDisplay;
			limitNumberOfSightingsCheckBox.Checked = limitNumberOfSightings;
			numberOfSightingsLimitNumericUpDown.Value = UserSettings.Instance.NumberOfSightingsToDisplayLimit;

			sightingsLimitLabel.Enabled = limitNumberOfSightings;
			numberOfSightingsLimitNumericUpDown.Enabled = limitNumberOfSightings;
		}

		private void SaveSightingsOptions()
		{
			UserSettings.Instance.HideSightingsComments = hideSightingsCommentsCheckBox.Checked;
			UserSettings.Instance.LimitNumberOfSightingsToDisplay = limitNumberOfSightingsCheckBox.Checked;
			UserSettings.Instance.NumberOfSightingsToDisplayLimit = Convert.ToInt32(numberOfSightingsLimitNumericUpDown.Value);
		}

		private void soundEffectBrowseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetSoundEffectFileName();
			if (fileName.Length > 0)
			{
				soundEffectTextBox.Text = fileName;
			}
		}

		private void soundEffectPlayButton_Click(object sender, EventArgs e)
		{
			PlaySound(soundEffectTextBox.Text);
		}

		private void soundEffectTextBox_TextChanged(object sender, EventArgs e)
		{
			SetSoundEffectPlayButtonStatus();
		}

		private string GetSoundEffectFileName()
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

		private void PlaySound(string path)
		{
			if (File.Exists(path))
			{
				Utility.PlaySound(path);
			}
		}

		private void SetSoundEffectPlayButtonStatus()
		{
			string path = soundEffectTextBox.Text;
			if (File.Exists(path) && IsValidSoundFileExtension(path))
			{
				soundEffectPlayButton.Enabled = true;
			}
			else
			{
				soundEffectPlayButton.Enabled = false;
			}
		}

		private void enableHallOfFameCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetHallOfFameStatus(enableHallOfFameCheckBox.Checked);
		}

		private void SetHallOfFameStatus(bool enabled)
		{
			hallOfFameGroupBox.Enabled = enabled;
		}

		private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool enableShowAliases = false;

			Language language = languageComboBox.SelectedItem as Language;
			if (language != null)
			{
				if (language.IsEnglish)
				{
					enableShowAliases = true;
				}
			}

			showAliasesCheckBox.Enabled = enableShowAliases;
		}

		private void limitNumberOfSightingsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool limitNumberOfSightings = limitNumberOfSightingsCheckBox.Checked;
			sightingsLimitLabel.Enabled = limitNumberOfSightings;
			numberOfSightingsLimitNumericUpDown.Enabled = limitNumberOfSightings;
		}
	}
}