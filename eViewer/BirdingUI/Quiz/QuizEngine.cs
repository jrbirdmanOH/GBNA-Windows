using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Thayer.Birding.UI.Quiz
{
	public class QuizEngine : Component
	{
		public enum NavigationDirection
		{
			Next,
			Back
		}

		public enum QuestionModes
		{
			Answer,
			ReadOnly
		}

		private IQuizForm form = null;
		private IQuizMediaPlayer mediaPlayer = null;
		private ISpeechProvider speechProvider = null;
		private QuizSettings quizSettings = null;
		private List<QuizEntry> quizEntries = null;
		private QuizScore quizScore = null;
		private int currentEntryIndex = 0;
		private QuestionModes questionMode = QuestionModes.Answer;
		private bool navigateUnansweredOnly = false;
		private bool isFinished = false;

		[Browsable(false)]
		public IQuizForm QuizForm
		{
			get
			{
				return form;
			}

			set
			{
				form = value;
			}
		}

		[Browsable(false)]
		public IQuizMediaPlayer MediaPlayer
		{
			get
			{
				return mediaPlayer;
			}

			set
			{
				mediaPlayer = value;
			}
		}

		[Browsable(false)]
		public ISpeechProvider SpeechProvider
		{
			get
			{
				return speechProvider;
			}

			set
			{
				speechProvider = value;
			}
		}

		[Browsable(false)]
		public QuizSettings QuizSettings
		{
			get
			{
				return quizSettings;
			}

			set
			{
				quizSettings = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<QuizEntry> QuizEntries
		{
			get
			{
				if (quizEntries == null)
				{
					quizEntries = new List<QuizEntry>();
				}

				return quizEntries;
			}

			set
			{
				quizEntries = value;
			}
		}

		[Browsable(false)]
		public List<int> QuizChoices
		{
			get
			{
				return CurrentEntry.Choices;
			}
		}

		[Browsable(false)]
		public QuizScore QuizScore
		{
			get
			{
				return quizScore;
			}
		}

		[Browsable(false)]
		public int CurrentEntryIndex
		{
			get
			{
				return currentEntryIndex;
			}

			set
			{
				currentEntryIndex = value;
			}
		}

		[Browsable(false)]
		public QuizEntry CurrentEntry
		{
			get
			{
				return QuizEntries[CurrentEntryIndex];
			}
		}

		[Browsable(false)]
		public QuestionModes QuestionMode
		{
			get
			{
				return questionMode;
			}

			set
			{
				questionMode = value;
			}
		}

		[Browsable(false)]
		public int CurrentQuestionNumber
		{
			get
			{
				return CurrentEntryIndex + 1;
			}
		}

		[Browsable(false)]
		public int NumberOfEntries
		{
			get
			{
				return QuizEntries.Count;
			}
		}

		[Browsable(false)]
		public bool CanNavigateBackward
		{
			get
			{
				return CurrentEntryIndex > 0 ? true : false;
			}
		}

		[Browsable(false)]
		public bool CanNavigateForward
		{
			get
			{
				bool canNavigateForward = true;
				if (!CanLoop())
				{
					canNavigateForward = (CurrentEntryIndex < QuizEntries.Count - 1) ? true : false;
				}

				return canNavigateForward;
			}
		}

		public QuizEngine()
		{
		}

		public void Start()
		{
			if (QuizSettings.RestartQuiz)
			{
				currentEntryIndex = -1;
				Start(GetNextUnansweredIndex(NavigationDirection.Next));
			}
			else
			{
				Start(0);
			}
		}

		public void Start(int index)
		{
			isFinished = false;

			InitializeScores();
			form.UpdateScore(quizScore);

			currentEntryIndex = index;
			form.LoadQuizEntry(CurrentEntry);
		}

		private void InitializeScores()
		{
			quizScore = new QuizScore(this.NumberOfEntries);

			foreach (QuizEntry quizEntry in QuizEntries)
			{
				if (quizEntry.IsAnswered)
				{
					if (quizEntry.IsCorrect)
					{
						QuizScore.AddScore(QuizScore.QuizAnswerTypes.Correct);
					}
					else
					{
						QuizScore.AddScore(QuizScore.QuizAnswerTypes.Incorrect);
					}
				}
			}
		}

		public void NavigateQuiz(NavigationDirection direction)
		{
			NavigateQuiz(direction, false);
		}

		public void NavigateQuiz(NavigationDirection direction, bool navigateUnanswered)
		{
			int previousEntryIndex = currentEntryIndex;

			if (quizScore.Remaining > 0 || isFinished)
			{
				if (navigateUnanswered)
				{
					currentEntryIndex = GetNextUnansweredIndex(direction);
				}
				else
				{
					currentEntryIndex = GetNextIndex(direction, CanLoop());
				}

				if (currentEntryIndex != previousEntryIndex)
				{
                    QuizEntry quizEntry = quizEntries[currentEntryIndex];
                    quizEntry.ResetMediaPosition();
                    form.LoadQuizEntry(quizEntry);
				}
			}
			else
			{
				// Allow user to navigate through all questions
				navigateUnansweredOnly = false;

				// Set finished flag to true
				isFinished = true;

				// Quiz is finished
				form.OnQuizFinished();
			}
		}

		private bool CanLoop()
		{
			bool canLoop = false;

			if (QuizSettings.QuizType == QuizSettings.QuizTypes.FlashCards && QuizSettings.LoopFlashCards)
			{
				canLoop = true;
			}

			return canLoop;
		}

		private int GetNextIndex(NavigationDirection direction, bool canLoop)
		{
			int nextIndex = currentEntryIndex;

			switch (direction)
			{
				case NavigationDirection.Back:
					if ((currentEntryIndex - 1) >= 0)
					{
						nextIndex--;
					}
					else
					{
						if (canLoop)
						{
							nextIndex = QuizEntries.Count - 1;
						}
					}
					break;
				case NavigationDirection.Next:
					if ((currentEntryIndex + 1) < QuizEntries.Count)
					{
						nextIndex++;
					}
					else
					{
						if (canLoop)
						{
							if (this.QuizSettings.LoopType == QuizSettings.LoopTypes.YesWithShuffle)
							{
								if (this.QuizSettings.HasRandomMedia)
								{
									// Regenerate the quiz entries to include new random media.
									// Set checkForQuizRestart parameter to false to skip check for quiz restart so quiz entries always get regenerated
									QuizEntry.GenerateQuizEntries(this.QuizSettings, this.QuizSettings.CollectionID, false);
									this.QuizEntries = QuizEntry.GetList(this.QuizSettings.QuizSource.Type);
								}

								// Shuffle the items before looping (only shuffle when navigating forward)
								this.QuizEntries.Shuffle<QuizEntry>(new Random());
							}

							nextIndex = 0;
						}
					}
					break;
			}

			return nextIndex;
		}

		private int GetNextUnansweredIndex(NavigationDirection direction)
		{
			int nextUnansweredIndex = currentEntryIndex;

			switch (direction)
			{
				case NavigationDirection.Back:
					// Search backward from current index
					for (int index = currentEntryIndex - 1; index >= 0; index--)
					{
						QuizEntry quizEntry = quizEntries[index];
						if (!quizEntries[index].IsAnswered)
						{
							nextUnansweredIndex = index;
							break;
						}
					}

					// If not found, try cycling around to end of list to find next unanswered
					if (nextUnansweredIndex == currentEntryIndex)
					{
						for (int index = quizEntries.Count - 1; index > currentEntryIndex; index--)
						{
							QuizEntry quizEntry = quizEntries[index];
							if (!quizEntries[index].IsAnswered)
							{
								nextUnansweredIndex = index;
								break;
							}
						}
					}
					break;
				case NavigationDirection.Next:
					// Search forward from current entry
					for (int index = currentEntryIndex + 1; index < quizEntries.Count; index++)
					{
						QuizEntry quizEntry = quizEntries[index];
						if (!quizEntries[index].IsAnswered)
						{
							nextUnansweredIndex = index;
							break;
						}
					}

					// If not found, try cycling around to beginning of list to find next unanswered
					if (nextUnansweredIndex == currentEntryIndex)
					{
						for (int index = 0; index < currentEntryIndex; index++)
						{
							QuizEntry quizEntry = quizEntries[index];
							if (!quizEntries[index].IsAnswered)
							{
								nextUnansweredIndex = index;
								break;
							}
						}
					}
					break;
			}

			return nextUnansweredIndex;
		}

		public void AnswerQuestion(QuizAnswer answer)
		{
			if (answer.Status == QuizAnswer.QuizAnswerStatus.ShowAnswer)
			{
				ProcessShowAnswer(answer);
			}
			else
			{
				QuizEntry quizEntry = quizEntries[currentEntryIndex];

				// See if the selected answer is the correct answer
				bool isCorrect = IsAnswerCorrect(answer);

				// See if this is the first attempt at answering this question
				bool updateAnswer = !quizEntry.IsAnswered;
				if (updateAnswer)
				{
					// Set the response (answer) for the quiz entry
					quizEntry.Response = answer.Response;
					quizEntry.Answered = isCorrect ? QuizEntry.Correct : QuizEntry.Incorrect;
					answer.Status = isCorrect ? QuizAnswer.QuizAnswerStatus.Correct : QuizAnswer.QuizAnswerStatus.Incorrect;

					// Save the quiz entry
					quizEntry.Save();
				}

				// See if this is the final answer for this question
				if (isCorrect || (!isCorrect && quizSettings.AnswerType == QuizSettings.AnswerTypes.OneTry))
				{
					questionMode = QuestionModes.ReadOnly;
				}

				// Update the status of the answer navigation
				form.UpdateAnswerNavigation();

				if (isCorrect)
				{
					if (updateAnswer)
					{
						quizScore.AddScore(QuizScore.QuizAnswerTypes.Correct);
						form.UpdateAnswer(answer);

						// Last question has just been answered and there are unanswered questions
						if (currentEntryIndex == quizEntries.Count - 1 && quizScore.Remaining > 0)
						{
							navigateUnansweredOnly = true;
						}
					}

					if (quizSettings.QuizType != QuizSettings.QuizTypes.FlashCards && quizSettings.UseAnswerSoundEffects)
					{
						// Play the sound associated with a correct answer
						mediaPlayer.PlaySound(quizSettings.CorrectSoundEffectFileName, true);
					}

					// Navigate to the next question
					NavigateQuiz(NavigationDirection.Next, navigateUnansweredOnly);
				}
				else
				{
					if (updateAnswer)
					{
						quizScore.AddScore(QuizScore.QuizAnswerTypes.Incorrect);
						form.UpdateAnswer(answer);

						// Last question has just been answered and there are unanswered questions
						if (currentEntryIndex == quizEntries.Count - 1 && quizScore.Remaining > 0)
						{
							navigateUnansweredOnly = true;
						}
					}

					if (quizSettings.QuizType != QuizSettings.QuizTypes.FlashCards && quizSettings.UseAnswerSoundEffects)
					{
						// Play the sound associated with an incorrect answer
						bool waitUntilFinished = quizSettings.AnswerType == QuizSettings.AnswerTypes.OneTry ? true : false;
						mediaPlayer.PlaySound(quizSettings.IncorrectSoundEffectFileName, waitUntilFinished);
					}

					if (quizSettings.AnswerType == QuizSettings.AnswerTypes.OneTry)
					{
						// Navigate to the next question
						NavigateQuiz(NavigationDirection.Next, navigateUnansweredOnly);
					}
				}
			}
		}

		private void ProcessShowAnswer(QuizAnswer answer)
		{
			QuizEntry quizEntry = quizEntries[currentEntryIndex];

			// See if this is the first attempt at answering this question
			bool updateAnswer = !quizEntry.IsAnswered;
			if (updateAnswer)
			{
				// Set the response (answer) for the quiz entry
				quizEntry.Response = "\"Show Answer\" was selected";
				quizEntry.Answered = QuizEntry.Incorrect;
				answer.Status = QuizAnswer.QuizAnswerStatus.Incorrect;

				// Save the quiz entry
				quizEntry.Save();
			}

			// Make this the final answer for this question
			questionMode = QuestionModes.ReadOnly;

			// Update the status of the answer navigation
			form.UpdateAnswerNavigation();

			if (updateAnswer)
			{
				quizScore.AddScore(QuizScore.QuizAnswerTypes.Incorrect);
				form.UpdateAnswer(answer);

				// Last question has just been answered and there are unanswered questions
				if (currentEntryIndex == quizEntries.Count - 1 && quizScore.Remaining > 0)
				{
					navigateUnansweredOnly = true;
				}
			}

			// Navigate to the next question
			NavigateQuiz(NavigationDirection.Next, navigateUnansweredOnly);
		}

		private bool IsAnswerCorrect(QuizAnswer answer)
		{
			bool isCorrect = false;

			switch (QuizSettings.QuizType)
			{
				case QuizSettings.QuizTypes.MultipleChoice:
					isCorrect = answer.ThingID == CurrentEntry.ThingID; 
					break;
				case QuizSettings.QuizTypes.FillInTheBlank:
					isCorrect = IsFillInTheBlankAnswerCorrect(answer);
					break;
				case QuizSettings.QuizTypes.FlashCards:
					isCorrect = true;
					break;
				case QuizSettings.QuizTypes.PickOne:
					isCorrect = answer.ThingID == CurrentEntry.ThingID;
					break;
			}

			return isCorrect;
		}

		private bool IsFillInTheBlankAnswerCorrect(QuizAnswer answer)
		{
			bool isCorrect = false;

			// Get the unprocessed correct answer
			string correctAnswerUnprocessed = GetFillInTheBlankCorrectAnswer(CurrentEntry.ThingID, QuizSettings.DifficultyLevel);

			// Process the correct and submitted answers to the
			// proper format depending on difficulty level
			string correctAnswer = ProcessFillInTheBlankString(correctAnswerUnprocessed, QuizSettings.DifficultyLevel);
			string submittedAnswer = ProcessFillInTheBlankString(answer.Response, QuizSettings.DifficultyLevel);

			// Check to see if the answer is correct
			switch (QuizSettings.DifficultyLevel)
			{
				case QuizSettings.DifficultyLevels.Easy:
					// Make sure that an answer that is correct for the Medium difficulty level
					// is not determined to be incorrect by the Easy difficulty level
					string correctAnswerMedium = ProcessFillInTheBlankString(GetFillInTheBlankCorrectAnswer(CurrentEntry.ThingID, QuizSettings.DifficultyLevels.Medium), QuizSettings.DifficultyLevels.Medium);
					if (submittedAnswer == correctAnswer || submittedAnswer == correctAnswerMedium)
					{
						isCorrect = true;
					}
					break;
				case QuizSettings.DifficultyLevels.Medium:
					if (submittedAnswer == correctAnswer)
					{
						isCorrect = true;
					}
					break;
				case QuizSettings.DifficultyLevels.Hard:
					if (submittedAnswer == correctAnswer)
					{
						isCorrect = true;
					}
					break;
			}

			return isCorrect;
		}

		public string GetFillInTheBlankCorrectAnswer(int thingID)
		{
			return GetFillInTheBlankCorrectAnswer(thingID, QuizSettings.DifficultyLevels.Hard);
		}

		private string GetFillInTheBlankCorrectAnswer(int thingID, QuizSettings.DifficultyLevels difficultyLevel)
		{
			string correctAnswer = string.Empty;

			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				CustomThing thing = CustomThing.GetByID(thingID);
				if (QuizSettings.Language == QuizSettings.Languages.Common)
				{
					correctAnswer = thing.Name;
				}
				else
				{
					// For custom quizzes, make sure the alternate name was specified
					if (thing.AlternateName.Length > 0)
					{
						correctAnswer = thing.AlternateName;
					}
					else
					{
						correctAnswer = thing.Name;
					}
				}
			}
			else
			{
				OrganismListItem organismListItem = OrganismListItem.GetByID(thingID);

				if (QuizSettings.Language == QuizSettings.Languages.Common || QuizSettings.Language == QuizSettings.Languages.All)
				{
					if (difficultyLevel == QuizSettings.DifficultyLevels.Easy)
					{
						// Only use last name for Easy difficulty level
						correctAnswer = organismListItem.LastName;
					}
					else
					{
						correctAnswer = organismListItem.CommonName;
					}
				}
				else if (QuizSettings.Language == QuizSettings.Languages.Scientific)
				{
					if (difficultyLevel == QuizSettings.DifficultyLevels.Easy)
					{
						// Only use species for Easy difficulty level
						correctAnswer = organismListItem.Species;
					}
					else
					{
						correctAnswer = organismListItem.ScientificName;
					}
				}
				else if (QuizSettings.Language == QuizSettings.Languages.BandCode)
				{
					correctAnswer = organismListItem.BandCode.Code;
				}
			}

			return correctAnswer;
		}

		private string ProcessFillInTheBlankString(string source, QuizSettings.DifficultyLevels difficultyLevel)
		{
			string fillInTheBlankString = string.Empty;

			switch (QuizSettings.DifficultyLevel)
			{
				case QuizSettings.DifficultyLevels.Easy:
					fillInTheBlankString = source.ToUpper();
					fillInTheBlankString = ToAlphabeticOnly(fillInTheBlankString);
					break;
				case QuizSettings.DifficultyLevels.Medium:
					fillInTheBlankString = source.ToUpper();
					fillInTheBlankString = ToAlphabeticOnly(fillInTheBlankString);
					break;
				case QuizSettings.DifficultyLevels.Hard:
					fillInTheBlankString = source;
					break;
			}

			return fillInTheBlankString;
		}

		private string ToAlphabeticOnly(string source)
		{
			StringBuilder alphabeticOnly = new StringBuilder();

			for (int index = 0; index < source.Length; index++)
			{
				char character = source[index];
				if (Char.IsLetter(character))
				{
					alphabeticOnly.Append(character);
				}
			}

			return alphabeticOnly.ToString();
		}

		public QuizEntry GetQuizEntry(int index)
		{
			QuizEntry quizEntry = null;

			if (index >= 0 && index < this.NumberOfEntries)
			{
				quizEntry = QuizEntries[index];
			}

			return quizEntry;
		}

		public string GetOrganismText(int thingID)
		{
			return GetOrganismText(thingID, QuizSettings.Language);
		}

		public string GetOrganismText(int thingID, QuizSettings.Languages language)
		{
			string text = string.Empty;

			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				CustomThing thing = CustomThing.GetByID(thingID);
				switch (language)
				{
					case QuizSettings.Languages.Common:
						text = thing.Name;
						break;
					case QuizSettings.Languages.Scientific:
						text = thing.AlternateName;
						break;
					case QuizSettings.Languages.BandCode:
						// Use common name since custom thing will not have band code
						text = thing.Name;
						break;
					case QuizSettings.Languages.All:
						string delimiter = QuizSettings.QuizType == QuizSettings.QuizTypes.MultipleChoice ? Environment.NewLine : " ";
						StringBuilder textBuilder = new StringBuilder(thing.Name);
						textBuilder.Append(delimiter);
						textBuilder.Append("(");
						textBuilder.Append(thing.AlternateName);
						textBuilder.Append(")");
						text = textBuilder.ToString();
						break;
				}
			}
			else
			{
				OrganismListItem organismListItem = OrganismListItem.GetByID(thingID);
				switch (language)
				{
					case QuizSettings.Languages.Common:
						text = organismListItem.CommonName;
						break;
					case QuizSettings.Languages.Scientific:
						text = organismListItem.ScientificName;
						break;
					case QuizSettings.Languages.BandCode:
						text = organismListItem.BandCode.Code;
						break;
					case QuizSettings.Languages.All:
						string delimiter = QuizSettings.QuizType == QuizSettings.QuizTypes.MultipleChoice ? Environment.NewLine : " ";
						StringBuilder textBuilder = new StringBuilder(organismListItem.CommonName);
						textBuilder.Append(delimiter);
						textBuilder.Append("(");
						textBuilder.Append(organismListItem.ScientificName);
						textBuilder.Append(")");
						textBuilder.Append(delimiter);
						textBuilder.Append("[");
						textBuilder.Append(organismListItem.BandCode.Code);
						textBuilder.Append("]");
						text = textBuilder.ToString();
						break;
				}
			}

			return text;
		}

		private SpeechPhrase GetSpeechPhrase(int thingID)
		{
			return GetSpeechPhrase(thingID, QuizSettings.Language);
		}

		private SpeechPhrase GetSpeechPhrase(int thingID, QuizSettings.Languages language)
		{
			SpeechPhrase speechPhrase = new SpeechPhrase();

			StringBuilder actualPhrase = new StringBuilder();
			StringBuilder pronunciationPhrase = new StringBuilder();

			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				CustomThing thing = CustomThing.GetByID(thingID);
				switch (language)
				{
					case QuizSettings.Languages.Common:
						actualPhrase.Append(thing.Name);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(thing.Name);
						pronunciationPhrase.Append(".");
						break;
					case QuizSettings.Languages.Scientific:
						actualPhrase.Append(thing.AlternateName);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(thing.AlternateName);
						pronunciationPhrase.Append(".");
						break;
					case QuizSettings.Languages.BandCode:
						actualPhrase.Append(thing.Name);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(thing.Name);
						pronunciationPhrase.Append(".");
						break;
					case QuizSettings.Languages.All:
						actualPhrase.Append(thing.Name);
						actualPhrase.Append(".  ");
						actualPhrase.Append(thing.AlternateName);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(thing.Name);
						pronunciationPhrase.Append(".  ");
						pronunciationPhrase.Append(thing.AlternateName);
						pronunciationPhrase.Append(".");
						break;
				}
			}
			else
			{
				Organism organism = Organism.GetByID(thingID);

				switch (language)
				{
					case QuizSettings.Languages.Common:
						actualPhrase.Append(organism.CommonName.Name);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(organism.CommonName.Pronunciation);
						pronunciationPhrase.Append(".");
						break;
					case QuizSettings.Languages.Scientific:
						actualPhrase.Append(organism.ScientificName);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(organism.ScientificNamePronunciation);
						pronunciationPhrase.Append(".");
						break;
					case QuizSettings.Languages.BandCode:
						actualPhrase.Append(organism.BandCode.Code);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(organism.BandCode.Code);
						pronunciationPhrase.Append(".");
						break;
					case QuizSettings.Languages.All:
						actualPhrase.Append(organism.CommonName.Name);
						actualPhrase.Append(".  ");
						actualPhrase.Append(organism.ScientificName);
						actualPhrase.Append(".");

						pronunciationPhrase.Append(organism.CommonName.Pronunciation);
						pronunciationPhrase.Append(".  ");
						pronunciationPhrase.Append(organism.ScientificNamePronunciation);
						pronunciationPhrase.Append(".");
						break;
				}
			}

			speechPhrase.ActualPhrase = actualPhrase.ToString();
			speechPhrase.PronunciationPhrase = pronunciationPhrase.ToString();

			return speechPhrase;
		}

		public void PronounceSpeech(int thingID)
		{
			if (this.SpeechProvider != null)
			{
				this.SpeechProvider.PronounceSpeech(GetSpeechPhrase(thingID));
			}
			else
			{
				throw new NotSupportedException("A speech provider has not been set for the quiz engine.");
			}
		}

		public string GetMnemonicText(int thingID)
		{
			string text = string.Empty;

			if (QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				// Leave blank
			}
			else
			{
				CharacteristicCollection characteristic = Organism.GetCharacteristicByID(thingID, CharacteristicType.Mnemonic);
				if (characteristic.Count > 0)
				{
					text = characteristic[0];
				}
			}

			return text;
		}

		public int GetChoiceIndex(QuizAnswer answer)
		{
			int choiceIndex = 0;

			for (int index = 0; index < QuizChoices.Count; index++)
			{
				if (QuizChoices[index] == answer.ThingID)
				{
					choiceIndex = index;
					break;
				}
			}

			return choiceIndex;
		}
	}
}
