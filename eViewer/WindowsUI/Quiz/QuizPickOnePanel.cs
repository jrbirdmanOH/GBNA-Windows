using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
    public partial class QuizPickOnePanel : QuizWizardPanel
    {
		[Browsable(false)]
		public override bool WizardEnabled
        {
            get
            {
                return QuizSettings.QuizType == QuizSettings.QuizTypes.PickOne ? true : false;
            }

            set
            {
                wizardEnabled = value;
            }
        }

		private QuizSettings.DifficultyLevels DifficultyLevel
		{
			get
			{
				QuizSettings.DifficultyLevels difficultyLevel = QuizSettings.DifficultyLevels.Medium;

				if (easyRadioButton.Checked)
				{
					difficultyLevel = QuizSettings.DifficultyLevels.Easy;
				}
				else if (mediumRadioButton.Checked)
				{
					difficultyLevel = QuizSettings.DifficultyLevels.Medium;
				}
				else if (hardRadioButton.Checked)
				{
					difficultyLevel = QuizSettings.DifficultyLevels.Hard;
				}

				return difficultyLevel;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.DifficultyLevels.Easy:
						easyRadioButton.Checked = true;
						break;
					case QuizSettings.DifficultyLevels.Medium:
						mediumRadioButton.Checked = true;
						break;
					case QuizSettings.DifficultyLevels.Hard:
						hardRadioButton.Checked = true;
						break;
					default:
						mediumRadioButton.Checked = true;
						break;
				}
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

		private QuizSettings.AnswerTypes AnswerType
		{
			get
			{
				QuizSettings.AnswerTypes answerType = QuizSettings.AnswerTypes.TryUntilCorrect;

				if (oneTryRadioButton.Checked)
				{
					answerType = QuizSettings.AnswerTypes.OneTry;
				}
				else if (getItRightRadioButton.Checked)
				{
					answerType = QuizSettings.AnswerTypes.TryUntilCorrect;
				}

				return answerType;
			}

			set
			{
				switch (value)
				{
					case QuizSettings.AnswerTypes.OneTry:
						oneTryRadioButton.Checked = true;
						break;
					case QuizSettings.AnswerTypes.TryUntilCorrect:
						getItRightRadioButton.Checked = true;
						break;
					default:
						getItRightRadioButton.Checked = true;
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
				else if (rangeMapRadioButton.Checked)
				{
					mediaType = QuizSettings.MediaTypes.RangeMap;
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
					case QuizSettings.MediaTypes.RangeMap:
						rangeMapRadioButton.Checked = true;
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

        private bool EnableShowNames
        {
            get
            {
                return enableShowNamesCheckBox.Checked;
            }

            set
            {
                enableShowNamesCheckBox.Checked = value;
            }
        }

        public QuizPickOnePanel() : base()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            base.LoadSettings();

			this.DifficultyLevel = QuizSettings.DifficultyLevel;
			this.Language = QuizSettings.Language;
			this.AnswerType = QuizSettings.AnswerType;
			this.MediaType = QuizSettings.MediaType;
			this.PictureType = QuizSettings.PictureType;
			this.SoundType = QuizSettings.SoundType;
            this.EnableShowNames = QuizSettings.EnableShowNames;

			// Handle changes necessary for custom quizzes
			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				bandCodeRadioButton.Enabled = false;
				languageAllRadioButton.Enabled = true;

				rangeMapRadioButton.Enabled = false;

				scientificNameRadioButton.Text = "Alternate Name";

				if (this.Language == QuizSettings.Languages.BandCode)
				{
					this.Language = QuizSettings.Languages.Common;
				}

				if (this.MediaType == QuizSettings.MediaTypes.Video || this.MediaType == QuizSettings.MediaTypes.RangeMap)
				{
					this.MediaType = QuizSettings.MediaTypes.PictureAndSound;
				}

				// Make sure the custom quiz has sounds.  If not, do not allow selection of those options.
				bool hasSounds = CustomQuiz.GetByID(QuizSettings.QuizSource.CustomQuiz.QuizID).HasSounds;
				if (hasSounds)
				{
					pictureAndSoundRadioButton.Enabled = true;
				}
				else
				{
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

				rangeMapRadioButton.Enabled = true;

				scientificNameRadioButton.Text = "Scientific Name";
			}
		}

        public override void SaveSettings()
        {
            base.SaveSettings();

			QuizSettings.DifficultyLevel = this.DifficultyLevel;
			QuizSettings.Language = this.Language;
			QuizSettings.AnswerType = this.AnswerType;
			QuizSettings.MediaType = this.MediaType;
			QuizSettings.PictureType = this.PictureType;
			QuizSettings.SoundType = this.SoundType;
            QuizSettings.EnableShowNames = this.EnableShowNames;
        }

        private void QuizPickOnePanel_Load(object sender, EventArgs e)
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
			if (pictureRadioButton.Checked || pictureAndSoundRadioButton.Checked)
			{
				pictureTypeGroupBox.Enabled = true;
			}
			else
			{
				pictureTypeGroupBox.Enabled = false;
			}

			if (pictureAndSoundRadioButton.Checked)
			{
				soundTypeGroupBox.Enabled = true;
			}
			else
			{
				soundTypeGroupBox.Enabled = false;
			}
		}
	}
}
