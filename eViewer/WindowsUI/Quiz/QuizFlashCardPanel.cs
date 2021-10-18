using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
    public partial class QuizFlashCardPanel : QuizWizardPanel
    {
		[Browsable(false)]
		public override bool WizardEnabled
        {
            get
            {
                return QuizSettings.QuizType == QuizSettings.QuizTypes.FlashCards ? true : false;
            }

            set
            {
                wizardEnabled = value;
            }
        }

		private int DisplayNameTimerLength
		{
			get
			{
				return (int)displayNameTimerLengthNumericUpDown.Value;
			}

			set
			{
				displayNameTimerLengthNumericUpDown.Value = value;
			}
		}

		private int DisplayNextItemTimerLength
		{
			get
			{
				return (int)displayNextItemTimerLengthNumericUpDown.Value;
			}

			set
			{
				displayNextItemTimerLengthNumericUpDown.Value = value;
			}
		}

		private int DisplayNextMediaTimerLength
		{
			get
			{
				return (int)displayNextMediaTimerLengthNumericUpDown.Value;
			}

			set
			{
				displayNextMediaTimerLengthNumericUpDown.Value = value;
			}
		}

		private QuizSettings.Languages Language
		{
			get
			{
				QuizSettings.Languages language = QuizSettings.Languages.Common;

				if (commonNameRadioButton.Checked)
				{
					language = QuizSettings.Languages.Common;
				}
				else if (scientificNameRadioButton.Checked)
				{
					language = QuizSettings.Languages.Scientific;
				}
				else if (bandCodeRadioButton.Checked)
				{
					language = QuizSettings.Languages.BandCode;
				}
				else if (languageAllRadioButton.Checked)
				{
					language = QuizSettings.Languages.All;
				}

				return language;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.Languages.Common:
						commonNameRadioButton.Checked = true;
						break;
					case QuizSettings.Languages.Scientific:
						scientificNameRadioButton.Checked = true;
						break;
					case QuizSettings.Languages.BandCode:
						bandCodeRadioButton.Checked = true;
						break;
					case QuizSettings.Languages.All:
						languageAllRadioButton.Checked = true;
						break;
					default:
						commonNameRadioButton.Checked = true;
						break;
				}
			}
		}

		private QuizSettings.MediaTypes MediaType
		{
			get
			{
				QuizSettings.MediaTypes mediaType = QuizSettings.MediaTypes.PictureAndSound;

				if (pictureRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.Picture;
				}
				else if (pictureAndSoundRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.PictureAndSound;
				}
				else if (soundRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.Sound;
				}
				else if (videoRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.Video;
				}
				else if (rangeMapRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.RangeMap;
				}
				else if (allMediaRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.All;
				}

				return mediaType;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.MediaTypes.Picture:
						pictureRadioButton.Checked = true;
						break;
					case QuizSettings.MediaTypes.PictureAndSound:
						pictureAndSoundRadioButton.Checked = true;
						break;
					case QuizSettings.MediaTypes.Sound:
						soundRadioButton.Checked = true;
						break;
					case QuizSettings.MediaTypes.Video:
						videoRadioButton.Checked = true;
						break;
					case QuizSettings.MediaTypes.RangeMap:
						rangeMapRadioButton.Checked = true;
						break;
					case QuizSettings.MediaTypes.All:
						allMediaRadioButton.Checked = true;
						break;
					default:
						pictureAndSoundRadioButton.Checked = true;
						break;
				}

				// Update the status of the media type groups
				UpdateMediaTypeStatus();
			}
		}

		private QuizSettings.PictureTypes PictureType
		{
			get
			{
				QuizSettings.PictureTypes pictureType = QuizSettings.PictureTypes.Best;

				if (bestPictureRadioButton.Checked)
				{
					pictureType = QuizSettings.PictureTypes.Best;
				}
				else if (femaleOtherPictureRadioButton.Checked)
				{
					pictureType = QuizSettings.PictureTypes.FemaleOther;
				}
				else if (randomPictureRadioButton.Checked)
				{
					pictureType = QuizSettings.PictureTypes.Random;
				}

				return pictureType;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.PictureTypes.Best:
						bestPictureRadioButton.Checked = true;
						break;
					case QuizSettings.PictureTypes.FemaleOther:
						femaleOtherPictureRadioButton.Checked = true;
						break;
					case QuizSettings.PictureTypes.Random:
						randomPictureRadioButton.Checked = true;
						break;
					default:
						bestPictureRadioButton.Checked = true;
						break;
				}
			}
		}

		private QuizSettings.SoundTypes SoundType
		{
			get
			{
				QuizSettings.SoundTypes soundType = QuizSettings.SoundTypes.Best;

				if (bestSoundRadioButton.Checked)
				{
					soundType = QuizSettings.SoundTypes.Best;
				}
				else if (randomSoundRadioButton.Checked)
				{
					soundType = QuizSettings.SoundTypes.Random;
				}

				return soundType;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.SoundTypes.Best:
						bestSoundRadioButton.Checked = true;
						break;
					case QuizSettings.SoundTypes.Random:
						randomSoundRadioButton.Checked = true;
						break;
					default:
						bestSoundRadioButton.Checked = true;
						break;
				}
			}
		}

		private QuizSettings.VideoTypes VideoType
		{
			get
			{
				QuizSettings.VideoTypes videoType = QuizSettings.VideoTypes.Best;

				if (bestVideoRadioButton.Checked)
				{
					videoType = QuizSettings.VideoTypes.Best;
				}
				else if (randomVideoRadioButton.Checked)
				{
					videoType = QuizSettings.VideoTypes.Random;
				}

				return videoType;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.VideoTypes.Best:
						bestVideoRadioButton.Checked = true;
						break;
					case QuizSettings.VideoTypes.Random:
						randomVideoRadioButton.Checked = true;
						break;
					default:
						bestVideoRadioButton.Checked = true;
						break;
				}
			}
		}

		private bool ShowMnemonic
		{
			get
			{
				return mnemonicYesRadioButton.Checked;
			}

			set
			{
				if (value)
				{
					mnemonicYesRadioButton.Checked = true;
				}
				else
				{
					mnemonicNoRadioButton.Checked = true;
				}
			}
		}

		private bool PlayPronunciation
		{
			get
			{
				return pronunciationYesRadioButton.Checked;
			}

			set
			{
				if (value)
				{
					pronunciationYesRadioButton.Checked = true;
				}
				else
				{
					pronunciationNoRadioButton.Checked = true;
				}
			}
		}

        public QuizFlashCardPanel() : base()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            base.LoadSettings();

			this.DisplayNameTimerLength = QuizSettings.DisplayNameTimerLength;
			this.DisplayNextItemTimerLength = QuizSettings.DisplayNextItemTimerLength;
			this.DisplayNextMediaTimerLength = QuizSettings.DisplayNextMediaTimerLength;
			this.Language = QuizSettings.Language;
			this.MediaType = QuizSettings.MediaType;
			this.PictureType = QuizSettings.PictureType;
			this.SoundType = QuizSettings.SoundType;
			this.VideoType = QuizSettings.VideoType;
			this.ShowMnemonic = QuizSettings.ShowMnemonic;
			this.PlayPronunciation = QuizSettings.PlayPronunciation;

			// Handle changes necessary for custom quizzes
			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				bandCodeRadioButton.Enabled = false;
				languageAllRadioButton.Enabled = true;

				videoRadioButton.Enabled = false;
				rangeMapRadioButton.Enabled = false;
				allMediaRadioButton.Enabled = false;

				pronunciationGroupBox.Enabled = false;
				mnemonicGroupBox.Enabled = false;
				
				scientificNameRadioButton.Text = "Alternate Name";

				if (this.Language == QuizSettings.Languages.BandCode)
				{
					this.Language = QuizSettings.Languages.Common;
				}

				if (this.MediaType == QuizSettings.MediaTypes.Video || this.MediaType == QuizSettings.MediaTypes.RangeMap || this.MediaType == QuizSettings.MediaTypes.All)
				{
					this.MediaType = QuizSettings.MediaTypes.PictureAndSound;
				}

				// Make sure the custom quiz has sounds.  If not, do not allow selection of those options.
				bool hasSounds = CustomQuiz.GetByID(QuizSettings.QuizSource.CustomQuiz.QuizID).HasSounds;
				if (hasSounds)
				{
					soundRadioButton.Enabled = true;
					pictureAndSoundRadioButton.Enabled = true;
				}
				else
				{
					soundRadioButton.Enabled = false;
					pictureAndSoundRadioButton.Enabled = false;
					if (this.MediaType == QuizSettings.MediaTypes.PictureAndSound || this.MediaType == QuizSettings.MediaTypes.Sound)
					{
						this.MediaType = QuizSettings.MediaTypes.Picture;
					}
				}
			}
			else
			{
				bandCodeRadioButton.Enabled = true;
				languageAllRadioButton.Enabled = true;

				videoRadioButton.Enabled = true;
				rangeMapRadioButton.Enabled = true;

				pronunciationGroupBox.Enabled = true;
				mnemonicGroupBox.Enabled = true;

				scientificNameRadioButton.Text = "Scientific Name";
			}
		}

        public override void SaveSettings()
        {
            base.SaveSettings();

			QuizSettings.DisplayNameTimerLength = this.DisplayNameTimerLength;
			QuizSettings.DisplayNextItemTimerLength = this.DisplayNextItemTimerLength;
			QuizSettings.DisplayNextMediaTimerLength = this.DisplayNextMediaTimerLength;
			QuizSettings.Language = this.Language;
			QuizSettings.MediaType = this.MediaType;
			QuizSettings.PictureType = this.PictureType;
			QuizSettings.SoundType = this.SoundType;
			QuizSettings.VideoType = this.VideoType;
			QuizSettings.ShowMnemonic = this.ShowMnemonic;
			QuizSettings.PlayPronunciation = this.PlayPronunciation;
        }

        private void QuizFlashCardPanel_Load(object sender, EventArgs e)
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
			NextEnabled = true;
			FinishEnabled = false;
		}

		private void mediaTypeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			UpdateMediaTypeStatus();
		}

		private void UpdateMediaTypeStatus()
		{
			if (pictureRadioButton.Checked || pictureAndSoundRadioButton.Checked || allMediaRadioButton.Checked)
			{
				pictureTypeGroupBox.Enabled = true;
			}
			else
			{
				pictureTypeGroupBox.Enabled = false;
			}

			if (soundRadioButton.Checked || pictureAndSoundRadioButton.Checked || allMediaRadioButton.Checked)
			{
				soundTypeGroupBox.Enabled = true;
			}
			else
			{
				soundTypeGroupBox.Enabled = false;
			}

			if (videoRadioButton.Checked || allMediaRadioButton.Checked)
			{
				videoTypeGroupBox.Enabled = true;
			}
			else
			{
				videoTypeGroupBox.Enabled = false;
			}
		}
	}
}
