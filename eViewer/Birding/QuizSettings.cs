using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Thayer.Birding
{
    public class QuizSettings
    {
        public enum QuizTypes
        {
            MultipleChoice,
            FillInTheBlank,
            FlashCards,
            PickOne
        }

		public enum DifficultyLevels
		{
			Easy,
			Medium,
			Hard
		}

		public enum Languages
		{
			Common,
			Scientific,
			BandCode,
			All
		}

		public enum AnswerTypes
		{
			OneTry,
			TryUntilCorrect
		}

		public enum LoopTypes
		{
			Yes,
			No,
			YesWithShuffle
		}

		public enum MediaTypes
		{
			Picture,
			PictureAndSound,
			Sound,
			Video,
			RangeMap,
			All
		}

		public enum PictureTypes
		{
			Best,
			Random,
			FemaleOther
		}

		public enum SoundTypes
		{
			Best,
			Random
		}

		public enum VideoTypes
		{
			Best,
			Random
		}

		public enum WizardStartupTypes
		{
			Default,
			CustomList
		}

		private int collectionID = 0;
		private int quizLength = 0;
		private QuizSource quizSource = null;
		private QuizTypes quizType = QuizSettings.QuizTypes.MultipleChoice;
		private DifficultyLevels difficultyLevel = DifficultyLevels.Medium;
		private Languages language = Languages.Common;
		private AnswerTypes answerType = AnswerTypes.TryUntilCorrect;
		private LoopTypes loopType = LoopTypes.Yes;
		private MediaTypes mediaType = MediaTypes.PictureAndSound;
		private PictureTypes pictureType = PictureTypes.Best;
		private SoundTypes soundType = SoundTypes.Best;
		private VideoTypes videoType = VideoTypes.Best;
		private bool allowClues = true;
		private int displayNameTimerLength = 5;
		private int displayNextItemTimerLength = 5;
		private int displayNextMediaTimerLength = 5;
		private bool showMnemonic = false;
		private bool playPronunciation = false;

		private bool shuffleItems = true;
		private bool excludeObserved = false;
		private int excludedObserverID = 0;
		private int itemFrequency = 0;
		private bool useAnswerSoundEffects = true;
		private string correctSoundEffectFileName = Path.Combine(ApplicationSettings.AssemblyPath, "correct.wav");
		private string incorrectSoundEffectFileName = Path.Combine(ApplicationSettings.AssemblyPath, "incorrect.wav");
        private bool enableShowNames = true;

		private bool restartQuiz = false;
		private WizardStartupTypes wizardStartupType = WizardStartupTypes.Default;

		public QuizSettings()
		{
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

		public int QuizLength
		{
			get
			{
				return quizLength;
			}

			set
			{
				quizLength = value;
			}
		}

		public QuizSource QuizSource
		{
			get
			{
				if (quizSource == null)
				{
					quizSource = new QuizSource();
				}

				return quizSource;
			}

			set
			{
				quizSource = value;
			}
		}
		
		public QuizTypes QuizType
        {
            get
            {
                return quizType;
            }

            set
            {
				quizType = value;
            }
        }

		public DifficultyLevels DifficultyLevel
		{
			get
			{
				return difficultyLevel;
			}

			set
			{
				difficultyLevel = value;
			}
		}

		public Languages Language
		{
			get
			{
				Languages supportedLanguage = language;
				if (!IsLanguageSupported(quizType, supportedLanguage))
				{
					supportedLanguage = GetDefaultLanguage(quizType);
				}

				return supportedLanguage;
			}

			set
			{
				language = value;
			}
		}

		public AnswerTypes AnswerType
		{
			get
			{
				return answerType;
			}

			set
			{
				answerType = value;
			}
		}

		public LoopTypes LoopType
		{
			get
			{
				return loopType;
			}

			set
			{
				loopType = value;
			}
		}

		public MediaTypes MediaType
		{
			get
			{
				MediaTypes supportedMediaType = mediaType;
				if (!IsMediaTypeSupported(quizType, supportedMediaType))
				{
					supportedMediaType = GetDefaultMediaType(quizType);
				}

				return supportedMediaType;
			}

			set
			{
				mediaType = value;
			}
		}

		public PictureTypes PictureType
		{
			get
			{
				return pictureType;
			}

			set
			{
				pictureType = value;
			}
		}

		public SoundTypes SoundType
		{
			get
			{
				return soundType;
			}

			set
			{
				soundType = value;
			}
		}

		public VideoTypes VideoType
		{
			get
			{
				return videoType;
			}

			set
			{
				videoType = value;
			}
		}

		public bool AllowClues
		{
			get
			{
				return allowClues;
			}

			set
			{
				allowClues = value;
			}
		}

		public int DisplayNameTimerLength
		{
			get
			{
				return displayNameTimerLength;
			}

			set
			{
				displayNameTimerLength = value;
			}
		}

		public int DisplayNextItemTimerLength
		{
			get
			{
				return displayNextItemTimerLength;
			}

			set
			{
				displayNextItemTimerLength = value;
			}
		}

		public int DisplayNextMediaTimerLength
		{
			get
			{
				return displayNextMediaTimerLength;
			}

			set
			{
				displayNextMediaTimerLength = value;
			}
		}

		public bool ShowMnemonic
		{
			get
			{
				return showMnemonic;
			}

			set
			{
				showMnemonic = value;
			}
		}

		public bool PlayPronunciation
		{
			get
			{
				return playPronunciation;
			}

			set
			{
				playPronunciation = value;
			}
		}

		public bool ShuffleItems
		{
			get
			{
				return shuffleItems;
			}

			set
			{
				shuffleItems = value;
			}
		}
		
		public bool ExcludeObserved
		{
			get
			{
				return excludeObserved;
			}

			set
			{
				excludeObserved = value;
			}
		}

		public int ExcludedObserverID
		{
			get
			{
				return excludedObserverID;
			}

			set
			{
				excludedObserverID = value;
			}
		}

		public int ItemFrequency
		{
			get
			{
				return itemFrequency;
			}

			set
			{
				itemFrequency = value;
			}
		}

		public bool UseAnswerSoundEffects
		{
			get
			{
				return useAnswerSoundEffects;
			}

			set
			{
				useAnswerSoundEffects = value;
			}
		}

		public string CorrectSoundEffectFileName
		{
			get
			{
				return correctSoundEffectFileName;
			}

			set
			{
				correctSoundEffectFileName = value;
			}
		}

		public string IncorrectSoundEffectFileName
		{
			get
			{
				return incorrectSoundEffectFileName;
			}

			set
			{
				incorrectSoundEffectFileName = value;
			}
		}

		public bool LoopFlashCards
		{
			get
			{
				return this.LoopType != LoopTypes.No;
			}
		}

        public bool EnableShowNames
        {
            get
            {
                return enableShowNames;
            }

            set
            {
                enableShowNames = value;
            }
        }

		[XmlIgnore]
		public bool RestartQuiz
		{
			get
			{
				return restartQuiz;
			}

			set
			{
				restartQuiz = value;
			}
		}

		[XmlIgnore]
		public WizardStartupTypes WizardStartupType
		{
			get
			{
				return wizardStartupType;
			}

			set
			{
				wizardStartupType = value;
			}
		}

		[XmlIgnore]
		public bool HasRandomMedia
		{
			get
			{
				bool hasRandomMedia = false;

				QuizSettings.MediaTypes mediaType = this.MediaType;
				switch (mediaType)
				{
					case QuizSettings.MediaTypes.All:
						if (this.PictureType == QuizSettings.PictureTypes.Random ||
							this.SoundType == QuizSettings.SoundTypes.Random ||
							this.VideoType == QuizSettings.VideoTypes.Random)
						{
							hasRandomMedia = true;
						}
						break;
					case QuizSettings.MediaTypes.Picture:
						if (this.PictureType == QuizSettings.PictureTypes.Random)
						{
							hasRandomMedia = true;
						}
						break;
					case QuizSettings.MediaTypes.PictureAndSound:
						if (this.PictureType == QuizSettings.PictureTypes.Random ||
							this.SoundType == QuizSettings.SoundTypes.Random)
						{
							hasRandomMedia = true;
						}
						break;
					case QuizSettings.MediaTypes.Video:
						if (this.VideoType == QuizSettings.VideoTypes.Random)
						{
							hasRandomMedia = true;
						}
						break;
				}

				return hasRandomMedia;
			}
		}

		public bool CanRestart(int currentCollectionID)
		{
			bool canRestart = false;

			if (collectionID != 0 && collectionID == currentCollectionID)
			{
				canRestart = true;
			}

			return canRestart;
		}

		private bool IsMediaTypeSupported(QuizTypes quizType, MediaTypes mediaType)
		{
			bool isSupported = false;

			switch (quizType)
			{
				case QuizTypes.MultipleChoice:
					if (mediaType != MediaTypes.All)
					{
						isSupported = true;
					}
					break;
				case QuizTypes.FillInTheBlank:
					if (mediaType != MediaTypes.All)
					{
						isSupported = true;
					}
					break;
				case QuizTypes.FlashCards:
					isSupported = true;
					break;
				case QuizTypes.PickOne:
					if (mediaType == MediaTypes.Picture || mediaType == MediaTypes.PictureAndSound || mediaType == MediaTypes.RangeMap)
					{
						isSupported = true;
					}
					else
					{
						isSupported = false;
					}
					break;
				default:
					isSupported = false;
					break;
			}

			return isSupported;
		}

		private MediaTypes GetDefaultMediaType(QuizTypes quizType)
		{
			// Right now all quiz types default to MediaTypes.PictureAndSound
			return MediaTypes.PictureAndSound;
		}

		private bool IsLanguageSupported(QuizTypes quizType, Languages language)
		{
			bool isSupported = false;

			switch (quizType)
			{
				case QuizTypes.MultipleChoice:
					isSupported = true;
					break;
				case QuizTypes.FillInTheBlank:
					if (language == Languages.Common || language == Languages.Scientific || language == Languages.BandCode)
					{
						isSupported = true;
					}
					else
					{
						isSupported = false;
					}
					break;
				case QuizTypes.FlashCards:
					isSupported = true;
					break;
				case QuizTypes.PickOne:
					isSupported = true;
					break;
				default:
					isSupported = false;
					break;
			}

			return isSupported;
		}

		private Languages GetDefaultLanguage(QuizTypes quizType)
		{
			// Right now all quiz types default to Languages.Common
			return Languages.Common;
		}
	}
}
