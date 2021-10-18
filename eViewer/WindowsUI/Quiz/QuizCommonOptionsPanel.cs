using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
    public partial class QuizCommonOptionsPanel : QuizWizardPanel
    {
		[Browsable(false)]
		public override bool WizardEnabled
        {
            get
            {
				return true;
			}

            set
            {
                wizardEnabled = value;
            }
        }

		private bool ShuffleItems
		{
			get
			{
				return shuffleYesRadioButton.Checked;
			}

			set
			{
				if (value)
				{
					shuffleYesRadioButton.Checked = true;
				}
				else
				{
					shuffleNoRadioButton.Checked = true;
				}
			}
		}

		private bool ExcludeObserved
		{
			get
			{
				return observedYesRadioButton.Checked;
			}

			set
			{
				if (value)
				{
					observedYesRadioButton.Checked = true;
				}
				else
				{
					observedNoRadioButton.Checked = true;
				}

				// Set the status of the observer
				SetObserverStatus();
			}
		}

		private int ExcludedObserverID
		{
			get
			{
				int observerID = 0;

				Observer observer = observerComboBox.SelectedItem as Observer;
				if (observer != null)
				{
					observerID = observer.ID;
				}

				return observerID;
			}

			set
			{
				foreach (Observer observer in observerComboBox.Items)
				{
					if (observer.ID == value)
					{
						observerComboBox.SelectedItem = observer;
						break;
					}
				}
			}
		}

		private int ItemFrequency
		{
			get
			{
				return frequencyTrackBar.Value;
			}

			set
			{
				frequencyTrackBar.Value = value;

				SetFrequencyLabel();
			}
		}

		private bool UseAnswerSoundEffects
		{
			get
			{
				return soundEffectsYesRadioButton.Checked;
			}

			set
			{
				if (value)
				{
					soundEffectsYesRadioButton.Checked = true;
				}
				else
				{
					soundEffectsNoRadioButton.Checked = true;
				}

				// Set the status of the correct and incorrect sound effect file name controls
				SetSoundEffectsStatus();
			}
		}

		private string CorrectSoundEffectFileName
		{
			get
			{
				return soundEffectsCorrectTextBox.Text;
			}

			set
			{
				soundEffectsCorrectTextBox.Text = value;
				SetSoundEffectsCorrectSoundButtonStatus();
			}
		}

		private string IncorrectSoundEffectFileName
		{
			get
			{
				return soundEffectsIncorrectTextBox.Text;
			}

			set
			{
				soundEffectsIncorrectTextBox.Text = value;
				SetSoundEffectsIncorrectSoundButtonStatus();
			}
		}

		private QuizSettings.LoopTypes LoopType
		{
			get
			{
				QuizSettings.LoopTypes loopType = QuizSettings.LoopTypes.Yes;

				if (loopYesRadioButton.Checked)
				{
					loopType = QuizSettings.LoopTypes.Yes;
				}
				else if (loopNoRadioButton.Checked)
				{
					loopType = QuizSettings.LoopTypes.No;
				}
				else if (loopYesWithShuffleRadioButton.Checked)
				{
					loopType = QuizSettings.LoopTypes.YesWithShuffle;
				}

				return loopType;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.LoopTypes.Yes:
						loopYesRadioButton.Checked = true;
						break;
					case QuizSettings.LoopTypes.No:
						loopNoRadioButton.Checked = true;
						break;
					case QuizSettings.LoopTypes.YesWithShuffle:
						loopYesWithShuffleRadioButton.Checked = true;
						break;
				}
			}
		}

		public QuizCommonOptionsPanel()
		{
			InitializeComponent();
		}

        public override void LoadSettings()
        {
            base.LoadSettings();

			this.ShuffleItems = QuizSettings.ShuffleItems;
			this.ExcludeObserved = QuizSettings.ExcludeObserved;
			this.ExcludedObserverID = QuizSettings.ExcludedObserverID;
			this.ItemFrequency = QuizSettings.ItemFrequency;

			// Disable observer settings for custom quizzes
			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				observedGroupBox.Enabled = false;
			}

			if (QuizSettings.QuizType == QuizSettings.QuizTypes.FlashCards)
			{
				ShowSoundEffectsGroup(false);
				ShowLoopGroup(true);

				this.LoopType = QuizSettings.LoopType;
			}
			else
			{
				ShowSoundEffectsGroup(true);
				ShowLoopGroup(false);

				this.UseAnswerSoundEffects = QuizSettings.UseAnswerSoundEffects;
				this.CorrectSoundEffectFileName = QuizSettings.CorrectSoundEffectFileName;
				this.IncorrectSoundEffectFileName = QuizSettings.IncorrectSoundEffectFileName;
			}
		}

        public override void SaveSettings()
        {
            base.SaveSettings();

			QuizSettings.ShuffleItems = this.ShuffleItems;
			QuizSettings.ExcludeObserved = this.ExcludeObserved;
			QuizSettings.ExcludedObserverID = this.ExcludedObserverID;
			QuizSettings.ItemFrequency = this.ItemFrequency;

			if (QuizSettings.QuizType == QuizSettings.QuizTypes.FlashCards)
			{
				QuizSettings.LoopType = this.LoopType;
			}
			else
			{
				QuizSettings.UseAnswerSoundEffects = this.UseAnswerSoundEffects;
				QuizSettings.CorrectSoundEffectFileName = this.CorrectSoundEffectFileName;
				QuizSettings.IncorrectSoundEffectFileName = this.IncorrectSoundEffectFileName;
			}
		}

        private void QuizCommonOptionsPanel_Load(object sender, EventArgs e)
        {
			if (!DesignMode)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			// Initialize navigation capabilities of panel
			BackEnabled = true;
			NextEnabled = false;
			FinishEnabled = true;

			// Load the observers combo box
			LoadObservers();
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

		private void soundEffectsCorrectBrowseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetSoundEffectFileName();
			if(fileName.Length > 0)
			{
				soundEffectsCorrectTextBox.Text = fileName;
			}
		}

		private void soundEffectsIncorrectBrowseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetSoundEffectFileName();
			if (fileName.Length > 0)
			{
				soundEffectsIncorrectTextBox.Text = fileName;
			}
		}

		private void PlaySound(string path)
		{
			if (File.Exists(path))
			{
				Utility.PlaySound(path);
			}
		}

		private void soundEffectsCorrectSoundButton_Click(object sender, EventArgs e)
		{
			PlaySound(soundEffectsCorrectTextBox.Text);
		}

		private void soundEffectsIncorrectSoundButton_Click(object sender, EventArgs e)
		{
			PlaySound(soundEffectsIncorrectTextBox.Text);
		}

		private void frequencyTrackBar_Scroll(object sender, EventArgs e)
		{
			toolTip.SetToolTip(frequencyTrackBar, frequencyTrackBar.Value.ToString());
			SetFrequencyLabel();
		}

		private void SetFrequencyLabel()
		{
			int quizLength = QuizSettings.QuizLength;
			int quizLengthIncrease = quizLength + Convert.ToInt32(Math.Round(quizLength * (frequencyTrackBar.Value / 100.0), MidpointRounding.AwayFromZero));

			StringBuilder frequencyText = new StringBuilder("+ ");
			frequencyText.Append(frequencyTrackBar.Value.ToString());
			frequencyText.Append("%, ");
			frequencyText.Append(quizLengthIncrease.ToString());
			frequencyText.Append(" total");
			frequencyLabel.Text = frequencyText.ToString();
		}

		private void LoadObservers()
		{
			List<Observer> observers = Observer.GetList();
			foreach (Observer observer in observers)
			{
				observerComboBox.Items.Add(observer);
			}
		}

		private void observedYesRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (observedNoRadioButton.Checked)
			{
				observerComboBox.SelectedIndex = -1;
			}

			SetObserverStatus();
		}

		private void SetObserverStatus()
		{
			observerComboBox.Enabled = observedYesRadioButton.Checked;
		}

		private void soundEffectsYesRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetSoundEffectsStatus();
		}

		private void SetSoundEffectsStatus()
		{
			soundEffectsCorrectTextBox.Enabled = soundEffectsYesRadioButton.Checked;
			soundEffectsCorrectBrowseButton.Enabled = soundEffectsYesRadioButton.Checked;
			soundEffectsCorrectSoundButton.Enabled = soundEffectsYesRadioButton.Checked;

			soundEffectsIncorrectTextBox.Enabled = soundEffectsYesRadioButton.Checked;
			soundEffectsIncorrectBrowseButton.Enabled = soundEffectsYesRadioButton.Checked;
			soundEffectsIncorrectSoundButton.Enabled = soundEffectsYesRadioButton.Checked;
		}

		private void ShowSoundEffectsGroup(bool showGroup)
		{
			soundEffectsGroupBox.Enabled = showGroup;
			soundEffectsGroupBox.Visible = showGroup;
		}

		private void ShowLoopGroup(bool showGroup)
		{
			loopGroupBox.Enabled = showGroup;
			loopGroupBox.Visible = showGroup;
		}

		private void soundEffectsCorrectTextBox_TextChanged(object sender, EventArgs e)
		{
			SetSoundEffectsCorrectSoundButtonStatus();
		}

		private void soundEffectsIncorrectTextBox_TextChanged(object sender, EventArgs e)
		{
			SetSoundEffectsIncorrectSoundButtonStatus();
		}

		private void SetSoundEffectsCorrectSoundButtonStatus()
		{
			string path = soundEffectsCorrectTextBox.Text;
			if (File.Exists(path) && IsValidSoundFileExtension(path))
			{
				soundEffectsCorrectSoundButton.Enabled = true;
			}
			else
			{
				soundEffectsCorrectSoundButton.Enabled = false;
			}
		}

		private void SetSoundEffectsIncorrectSoundButtonStatus()
		{
			string path = soundEffectsIncorrectTextBox.Text;
			if (File.Exists(path) && IsValidSoundFileExtension(path))
			{
				soundEffectsIncorrectSoundButton.Enabled = true;
			}
			else
			{
				soundEffectsIncorrectSoundButton.Enabled = false;
			}
		}
	}
}
