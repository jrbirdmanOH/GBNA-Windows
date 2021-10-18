using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public delegate void ProgressUpdateHandler(ProgressUpdateEventArgs e);

	public class QuizEntry
	{
		private static object eventLock = new object();
		private static event ProgressUpdateHandler progressUpdateHandler = null;

		public const string Correct = "C";
		public const string Incorrect = "I";

		private int id = 0;
		private string answered = null;
		private int thingID = 0;
		private int? mediaID = null;
		private bool isMediaCustom = false;
		private int? secondaryMediaID = null;
		private bool isSecondaryMediaCustom = false;
		private int sortOrder = 0;
		private List<int> alternateThings = null;
		private string response = null;

		private List<int> choices = null;
		private bool isDuplicate = false;
		private bool isCustom = false;

		private MediaCollection mediaCollection = null;
		private MediaList mediaList = null;
		private int mediaIndex = 0;

		public QuizEntry()
		{
		}

		public int ID
		{
			get
			{
				return id;
			}

			set
			{
				id = value;
			}
		}

		public string Answered
		{
			get
			{
				return answered;
			}

			set
			{
				answered = value;
			}
		}

		public bool IsCorrect
		{
			get
			{
				return (IsAnswered && Answered == QuizEntry.Correct) ? true : false;
			}
		}

		public bool IsAnswered
		{
			get
			{
				return (answered == null || answered.Length == 0) ? false : true;
			}
		}

		public int ThingID
		{
			get
			{
				return thingID;
			}

			set
			{
				thingID = value;
			}
		}

		public IQuizThing Thing
		{
			get
			{
				return QuizEntry.GetThing(thingID);
			}
		}

		public int? MediaID
		{
			get
			{
				return mediaID;
			}

			set
			{
				mediaID = value;
			}
		}

		public bool IsMediaCustom
		{
			get
			{
				return isMediaCustom;
			}

			set
			{
				isMediaCustom = value;
			}
		}

		public IMedia PrimaryMedia
		{
			get
			{
				IMedia media = null;

				if (this.MediaID != null)
				{
					media = QuizEntry.GetMedia((int)this.MediaID, this.IsMediaCustom);
				}

				return media;
			}
		}

		public int? SecondaryMediaID
		{
			get
			{
				return secondaryMediaID;
			}

			set
			{
				secondaryMediaID = value;
			}
		}

		public bool IsSecondaryMediaCustom
		{
			get
			{
				return isSecondaryMediaCustom;
			}

			set
			{
				isSecondaryMediaCustom = value;
			}
		}

		public IMedia SecondaryMedia
		{
			get
			{
				IMedia media = null;

				if (this.SecondaryMediaID != null)
				{
					media = QuizEntry.GetMedia((int)this.SecondaryMediaID, this.IsSecondaryMediaCustom);
				}

				return media;
			}
		}

		public int SortOrder
		{
			get
			{
				return sortOrder;
			}

			set
			{
				sortOrder = value;
			}
		}

		public List<int> AlternateThings
		{
			get
			{
				if (alternateThings == null)
				{
					alternateThings = new List<int>();
				}

				return alternateThings;
			}

			set
			{
				alternateThings = value;
			}
		}

		public string Response
		{
			get
			{
				return response;
			}

			set
			{
				response = value;
			}
		}

		public bool IsDuplicate
		{
			get
			{
				return isDuplicate;
			}

			set
			{
				isDuplicate = value;
			}
		}

		public bool IsCustom
		{
			get
			{
				return isCustom;
			}

			set
			{
				isCustom = value;
			}
		}

		public List<int> Choices
		{
			get
			{
				if (choices == null)
				{
					choices = new List<int>();
					choices.Add(thingID);

					if (alternateThings != null)
					{
						foreach (int alternateThingID in alternateThings)
						{
							choices.Add(alternateThingID);
						}
					}

					// Randomly shuffle the choices
					choices = QuizEntry.RandomShuffle<int>(choices);
				}

				return choices;
			}
		}

		private MediaCollection MediaCollection
		{
			get
			{
				if (mediaCollection == null)
				{
					if (isCustom)
					{
						mediaCollection = CustomMedia.GetListByCustomThingID(thingID);
					}
					else
					{
						mediaCollection = Media.GetListByThingID(thingID);

						// Add any My Media custom media for the specified thingID
						foreach (IMedia customMedia in CustomMedia.GetListByThingID(thingID).All)
						{
							mediaCollection.Add(customMedia);
						}
					}
				}

				return mediaCollection;
			}
		}

		private MediaList MediaList
		{
			get
			{
				if (mediaList == null)
				{
					mediaList = (MediaList)QuizEntry.RandomShuffle<IMedia>(this.MediaCollection.AllVisible);
				}

				return mediaList;
			}
		}

		public bool HasMoreMedia
		{
			get
			{
				MediaList mediaList = this.MediaCollection.AllVisible;
				return mediaIndex < mediaList.Count;
			}
		}

		public bool SetNextMedia(bool displayAll)
		{
			bool isMediaSet = false;

			if (displayAll)
			{
				if (mediaIndex < this.MediaList.Count)
				{
					IMedia primaryMedia = this.MediaList[mediaIndex];
					mediaID = primaryMedia.ID;
					isMediaCustom = primaryMedia.IsCustom;

					// Set the secondary media only for first photo
					secondaryMediaID = null;
					if (this.MediaCollection.Photos.Count > 0)
					{
						if (mediaID == this.MediaCollection.Photos[0].ID)
						{
							if (this.MediaCollection.Sounds.Count > 0)
							{
								IMedia secondaryMedia = this.MediaCollection.Sounds[0];
								secondaryMediaID = secondaryMedia.ID;
								isSecondaryMediaCustom = secondaryMedia.IsCustom;
							}
						}
					}

					mediaIndex++;
					isMediaSet = true;
				}
			}
			else
			{
				isMediaSet = true;
			}

			return isMediaSet;
		}

		private static List<T> RandomShuffle<T>(List<T> listToShuffle)
		{
			Random random = new Random();

			for (int index = listToShuffle.Count - 1; index >= 0; index--)
			{
				int newIndex = random.Next(index + 1);
				T tempValue = listToShuffle[index];
				listToShuffle[index] = listToShuffle[newIndex];
				listToShuffle[newIndex] = tempValue;
			}

			return listToShuffle;
		}

		public void ResetMediaPosition()
		{
			mediaIndex = 0;
		}

		public void Save()
		{
			QuizEntryDM.Instance.Save(this);
		}

		public static void Save(List<QuizEntry> quizEntries)
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				QuizEntryDM.Instance.DeleteAll(trans);
				QuizEntryDM.Instance.Save(quizEntries, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public static List<QuizEntry> GetList(QuizSource.QuizSourceTypes quizSource)
		{
			return QuizEntryDM.Instance.GetList(quizSource);
		}

		public static int GetNumberOfUnansweredQuestions()
		{
			return QuizEntryDM.Instance.GetNumberOfUnansweredQuestions();
		}

		public static int GetQuizLength()
		{
			return QuizEntryDM.Instance.GetQuizLength();
		}

		public static void GenerateQuizEntries(QuizSettings quizSettings, int collectionID, bool checkForQuizRestart = true)
		{
			if (checkForQuizRestart)
			{
				// See if user wants to restart a quiz
				if (quizSettings.RestartQuiz)
				{
					// Entries already exist
					OnProgressUpdate(new ProgressUpdateEventArgs("Done", 100));
					return;
				}
			}

			if (quizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				GenerateQuizEntriesForCustomQuiz(quizSettings);
				return;
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Generating list of birds based on selected quiz source...", 0));

			List<QuizEntry> quizEntries = null;

			switch (quizSettings.QuizSource.Type)
			{
				case QuizSource.QuizSourceTypes.PredefinedQuiz:
					quizEntries = GetQuizEntriesForQuiz(quizSettings.QuizSource.PredefinedQuiz, collectionID);
					break;
				case QuizSource.QuizSourceTypes.Location:
					quizEntries = GetQuizEntriesForLocation(quizSettings.QuizSource.Location, collectionID);
					break;
				case QuizSource.QuizSourceTypes.TaxonomicGroup:
					quizEntries = GetQuizEntriesForTaxonomicGroup(quizSettings.QuizSource.TaxonomicGroup, collectionID);
					break;
				case QuizSource.QuizSourceTypes.CustomList:
					quizEntries = GetQuizEntriesForCustomList(quizSettings.QuizSource.CustomList, collectionID);
					break;
//				case QuizSource.QuizSourceTypes.CustomQuiz:
//					quizEntries = GetQuizEntriesForCustomQuiz(quizSettings.QuizSource.CustomQuiz);
//					break;
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Excluding entries for observer...", 10));

			List<int> taxonomyList = Organism.GetListWithMedia(collectionID);

			// See if user wants to exclude observed birds
			if (quizSettings.ExcludeObserved)
			{
				ExcludeEntriesForObserver(quizEntries, quizSettings.ExcludedObserverID);
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Adding duplicate entries...", 15));

			// Add duplicate entries if necessary
			if (quizSettings.ItemFrequency > 0)
			{
				AddDuplicateEntries(quizEntries, quizSettings.ItemFrequency);
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Preparing media...", 20));

			// Set the media
			SetMedia(quizEntries, quizSettings);

			OnProgressUpdate(new ProgressUpdateEventArgs("Setting alternate answers...", 80));

			// Set alternate answers for multiple choice and pick one quiz types
			if (quizSettings.QuizType == QuizSettings.QuizTypes.MultipleChoice || quizSettings.QuizType == QuizSettings.QuizTypes.PickOne)
			{
				SetAlternateAnswers(quizEntries, taxonomyList, quizSettings.QuizType, quizSettings.DifficultyLevel, collectionID);
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Setting the sort order...", 85));

			// Set the sort order
            SetSortOrder(quizEntries, taxonomyList, quizSettings.QuizSource.Type, quizSettings.ShuffleItems);

			OnProgressUpdate(new ProgressUpdateEventArgs("Saving quiz entries...", 90));

			// Set the exact quiz length
			quizSettings.QuizLength = quizEntries.Count;

			// Save the generated quiz entries
			Save(quizEntries);

			OnProgressUpdate(new ProgressUpdateEventArgs("Done", 100));
		}

		public static void GenerateQuizEntriesForCustomQuiz(QuizSettings quizSettings)
		{
			OnProgressUpdate(new ProgressUpdateEventArgs("Generating list of questions based on selected quiz source...", 0));

			List<QuizEntry> quizEntries = GetQuizEntriesForCustomQuiz(quizSettings.QuizSource.CustomQuiz);

			OnProgressUpdate(new ProgressUpdateEventArgs("Adding duplicate entries...", 15));

			// Add duplicate entries if necessary
			if (quizSettings.ItemFrequency > 0)
			{
				AddDuplicateEntries(quizEntries, quizSettings.ItemFrequency);
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Preparing media...", 20));

			// Set the media
			SetMediaCustom(quizEntries, quizSettings.MediaType, quizSettings.PictureType);

			OnProgressUpdate(new ProgressUpdateEventArgs("Setting alternate answers...", 80));

			// Set alternate answers for multiple choice and pick one quiz types
			if (quizSettings.QuizType == QuizSettings.QuizTypes.MultipleChoice || quizSettings.QuizType == QuizSettings.QuizTypes.PickOne)
			{
				SetAlternateAnswersCustom(quizEntries, quizSettings.QuizSource.CustomQuiz.CategoryID, quizSettings.QuizType, quizSettings.DifficultyLevel);
			}

			OnProgressUpdate(new ProgressUpdateEventArgs("Setting the sort order...", 85));

			// Set the sort order
			SetSortOrderCustom(quizEntries, quizSettings.ShuffleItems);

			OnProgressUpdate(new ProgressUpdateEventArgs("Saving quiz entries...", 90));

			// Set the exact quiz length
			quizSettings.QuizLength = quizEntries.Count;

			// Save the generated quiz entries
			Save(quizEntries);

			OnProgressUpdate(new ProgressUpdateEventArgs("Done", 100));
		}

		private static List<QuizEntry> GetQuizEntriesForQuiz(QuizSource.PredefinedQuizSource predefinedQuiz, int collectionID)
		{
			return QuizEntryDM.Instance.GetEntriesForQuiz(predefinedQuiz, collectionID);
		}

		private static List<QuizEntry> GetQuizEntriesForLocation(QuizSource.LocationQuizSource locationQuizSource, int collectionID)
		{
			return QuizEntryDM.Instance.GetEntriesForLocation(locationQuizSource, collectionID);
		}

		private static List<QuizEntry> GetQuizEntriesForTaxonomicGroup(QuizSource.TaxonomicGroupQuizSource taxonomicGroupQuizSource, int collectionID)
		{
			return QuizEntryDM.Instance.GetEntriesForTaxonomicGroup(taxonomicGroupQuizSource, collectionID);
		}

		private static List<QuizEntry> GetQuizEntriesForCustomList(QuizSource.CustomListQuizSource customListQuizSource, int collectionID)
		{
			return QuizEntryDM.Instance.GetEntriesForCustomList(customListQuizSource, collectionID);
		}

		private static List<QuizEntry> GetQuizEntriesForCustomQuiz(QuizSource.CustomQuizSource customQuizSource)
		{
			return QuizEntryDM.Instance.GetEntriesForCustomQuiz(customQuizSource);
		}

		private static void ExcludeEntriesForObserver(List<QuizEntry> quizEntries, int observerID)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			foreach (QuizEntry quizEntry in list)
			{
				// See if the organism was observed by the specified observer
				if (Sighting.WasObservedByObserver(quizEntry.ThingID, observerID))
				{
					// Remove from list
					quizEntries.Remove(quizEntry);
				}
			}
		}

		private static void AddDuplicateEntries(List<QuizEntry> quizEntries, int itemFrequency)
		{
			int originalEntryCount = quizEntries.Count;
			int numberOfDuplicates = Convert.ToInt32(Math.Round(quizEntries.Count * (itemFrequency / 100.0), MidpointRounding.AwayFromZero));
			List<int> addedDuplicates = new List<int>(numberOfDuplicates);

			if (numberOfDuplicates <= originalEntryCount)
			{
				Random random = new Random();
				int duplicateRecordIndex = 0;
				for (int i = 0; i < numberOfDuplicates; i++)
				{
					do
					{
						duplicateRecordIndex = random.Next(0, originalEntryCount);
					}
					while (addedDuplicates.Contains(duplicateRecordIndex));

					QuizEntry duplicateEntry = new QuizEntry();
					duplicateEntry.ThingID = quizEntries[duplicateRecordIndex].ThingID;
					duplicateEntry.IsDuplicate = true;
					quizEntries.Add(duplicateEntry);

					addedDuplicates.Add(duplicateRecordIndex);
				}
			}
		}

		private static void SetMedia(List<QuizEntry> quizEntries, QuizSettings quizSettings)
		{
			// Media progress is from 20 to 80 percent
			double startPosition = 20;
			double endPosition = 80;
			double increment = 1.0;
			if (quizEntries.Count > 0)
			{
				increment = ((endPosition - startPosition) / quizEntries.Count);
			}

			switch (quizSettings.MediaType)
			{
				case QuizSettings.MediaTypes.Picture:
					SetPictureMedia(quizEntries, quizSettings, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.PictureAndSound:
					SetPictureAndSoundMedia(quizEntries, quizSettings, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.Sound:
					SetSoundMedia(quizEntries, quizSettings, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.Video:
					SetVideoMedia(quizEntries, quizSettings, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.RangeMap:
					SetRangeMapMedia(quizEntries, quizSettings, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.All:
					// When showing all media, start off with picture and sound
//					SetPictureAndSoundMedia(quizEntries, pictureType, startPosition, increment);
					break;
			}
		}

		private static void SetPictureMedia(List<QuizEntry> quizEntries, QuizSettings quizSettings, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			Random random = new Random();

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					MediaList mediaList = quizEntry.MediaCollection.QuizPhotos;
					if (mediaList.Count > 0)
					{
						int index = 0;
						switch (quizSettings.PictureType)
						{
							case QuizSettings.PictureTypes.Best:
								index = 0;
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best picture for a duplicate
									if (mediaList.Count > 1)
									{
										index = 1;
									}
								}
								break;
							case QuizSettings.PictureTypes.FemaleOther:
								if (mediaList.Count > 1)
								{
									// Use the second picture (female/other) if available
									index = 1;
									if (quizEntry.IsDuplicate)
									{
										// Use a random picture for a duplicate
										index = random.Next(0, mediaList.Count);
									}
								}
								break;
							case QuizSettings.PictureTypes.Random:
								// Set a random picture from the media list
								index = random.Next(0, mediaList.Count);
								break;
						}

						quizEntry.MediaID = mediaList[index].ID;
						quizEntry.IsMediaCustom = mediaList[index].IsCustom;
					}

					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMedia(quizEntry, quizSettings);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetPictureAndSoundMedia(List<QuizEntry> quizEntries, QuizSettings quizSettings, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			Random random = new Random();

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					MediaList mediaList = quizEntry.MediaCollection.QuizPhotos;
					if (mediaList.Count > 0)
					{
						int index = 0;
						switch (quizSettings.PictureType)
						{
							case QuizSettings.PictureTypes.Best:
								index = 0;
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best picture for a duplicate
									if (mediaList.Count > 1)
									{
										index = 1;
									}
								}
								break;
							case QuizSettings.PictureTypes.FemaleOther:
								if (mediaList.Count > 1)
								{
									// Use the second picture (female/other) if available
									index = 1;
									if (quizEntry.IsDuplicate)
									{
										// Use a random picture for a duplicate
										index = random.Next(0, mediaList.Count);
									}
								}
								break;
							case QuizSettings.PictureTypes.Random:
								// Set a random picture from the media list
								index = random.Next(0, mediaList.Count);
								break;
						}

						quizEntry.MediaID = mediaList[index].ID;
						quizEntry.IsMediaCustom = mediaList[index].IsCustom;
					}

					// Add sound as the secondary media
					MediaList secondaryMediaList = quizEntry.MediaCollection.Sounds;
					if (secondaryMediaList.Count > 0)
					{
						int index = 0;
						switch (quizSettings.SoundType)
						{
							case QuizSettings.SoundTypes.Best:
								index = 0;
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best sound for a duplicate
									if (secondaryMediaList.Count > 1)
									{
										index = 1;
									}
								}
								break;
							case QuizSettings.SoundTypes.Random:
								// Set a random sound from the media list
								index = random.Next(0, secondaryMediaList.Count);
								break;
						}

						quizEntry.SecondaryMediaID = secondaryMediaList[index].ID;
						quizEntry.IsSecondaryMediaCustom = secondaryMediaList[index].IsCustom;
					}

					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null && quizEntry.SecondaryMediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMedia(quizEntry, quizSettings);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetSoundMedia(List<QuizEntry> quizEntries, QuizSettings quizSettings, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			Random random = new Random();

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					MediaList mediaList = quizEntry.MediaCollection.Sounds;
					if (mediaList.Count > 0)
					{
						int index = 0;
						switch (quizSettings.SoundType)
						{
							case QuizSettings.SoundTypes.Best:
								index = 0;
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best sound for a duplicate
									if (mediaList.Count > 1)
									{
										index = 1;
									}
								}
								break;
							case QuizSettings.SoundTypes.Random:
								// Set a random sound from the media list
								index = random.Next(0, mediaList.Count);
								break;
						}

						quizEntry.MediaID = mediaList[index].ID;
						quizEntry.IsMediaCustom = mediaList[index].IsCustom;
					}
					
					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMedia(quizEntry, quizSettings);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetVideoMedia(List<QuizEntry> quizEntries, QuizSettings quizSettings, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			Random random = new Random();

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					MediaList mediaList = quizEntry.MediaCollection.Videos;
					if (mediaList.Count > 0)
					{
						int index = 0;
						switch (quizSettings.VideoType)
						{
							case QuizSettings.VideoTypes.Best:
								index = 0;
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best video for a duplicate
									if (mediaList.Count > 1)
									{
										index = 1;
									}
								}
								break;
							case QuizSettings.VideoTypes.Random:
								// Set a random video from the media list
								index = random.Next(0, mediaList.Count);
								break;
						}

						quizEntry.MediaID = mediaList[index].ID;
						quizEntry.IsMediaCustom = mediaList[index].IsCustom;
					}
					
					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMedia(quizEntry, quizSettings);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetRangeMapMedia(List<QuizEntry> quizEntries, QuizSettings quizSettings, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					MediaList mediaList = quizEntry.MediaCollection.RangeMaps;
					if (mediaList.Count > 0)
					{
						quizEntry.MediaID = mediaList[0].ID;
						quizEntry.IsMediaCustom = mediaList[0].IsCustom;
					}
					
					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMedia(quizEntry, quizSettings);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetSecondaryMedia(QuizEntry quizEntry, QuizSettings quizSettings)
		{
			if (quizEntry.SecondaryMediaID == null)
			{
				IMedia primaryMedia = quizEntry.PrimaryMedia;
				if (primaryMedia.Type == MediaType.Photo)
				{
					MediaList secondaryMediaList = quizEntry.MediaCollection.Sounds;
					if (secondaryMediaList.Count > 0)
					{
						int index = 0;
						switch (quizSettings.SoundType)
						{
							case QuizSettings.SoundTypes.Best:
								index = 0;
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best sound for a duplicate
									if (secondaryMediaList.Count > 1)
									{
										index = 1;
									}
								}
								break;
							case QuizSettings.SoundTypes.Random:
								// Set a random sound from the media list
								Random random = new Random();
								index = random.Next(0, secondaryMediaList.Count);
								break;
						}

						quizEntry.SecondaryMediaID = secondaryMediaList[index].ID;
						quizEntry.IsSecondaryMediaCustom = secondaryMediaList[index].IsCustom;
					}
				}
			}
		}

		private static void SetMediaCustom(List<QuizEntry> quizEntries, QuizSettings.MediaTypes mediaType, QuizSettings.PictureTypes pictureType)
		{
			// Media progress is from 20 to 80 percent
			double startPosition = 20;
			double endPosition = 80;
			double increment = 1.0;
			if (quizEntries.Count > 0)
			{
				increment = ((endPosition - startPosition) / quizEntries.Count);
			}

			switch (mediaType)
			{
				case QuizSettings.MediaTypes.Picture:
					SetPictureMediaCustom(quizEntries, pictureType, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.PictureAndSound:
					SetPictureAndSoundMediaCustom(quizEntries, pictureType, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.Sound:
					SetSoundMediaCustom(quizEntries, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.Video:
					SetVideoMediaCustom(quizEntries, startPosition, increment);
					break;
				case QuizSettings.MediaTypes.All:
					break;
			}
		}

		private static void SetPictureMediaCustom(List<QuizEntry> quizEntries, QuizSettings.PictureTypes pictureType, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			Random random = new Random();

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					List<int> mediaList = CustomMedia.GetIDListByCustomThingAndType(quizEntry.ThingID, MediaType.Photo);
					if (mediaList.Count > 0)
					{
						switch (pictureType)
						{
							case QuizSettings.PictureTypes.Best:
								quizEntry.MediaID = mediaList[0];
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best picture for a duplicate
									if (mediaList.Count > 1)
									{
										quizEntry.MediaID = mediaList[1];
									}
								}
								break;
							case QuizSettings.PictureTypes.FemaleOther:
								if (mediaList.Count > 1)
								{
									// Use the second picture (female/other) if available
									quizEntry.MediaID = mediaList[1];
									if (quizEntry.IsDuplicate)
									{
										// Use a random picture for a duplicate
										quizEntry.MediaID = mediaList[random.Next(0, mediaList.Count)];
									}
								}
								else
								{
									// Default to only available picture
									quizEntry.MediaID = mediaList[0];
								}
								break;
							case QuizSettings.PictureTypes.Random:
								// Set a random picture from the media list
								quizEntry.MediaID = mediaList[random.Next(0, mediaList.Count)];
								break;
						}
					}

					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMediaCustom(quizEntry);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetPictureAndSoundMediaCustom(List<QuizEntry> quizEntries, QuizSettings.PictureTypes pictureType, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);
			Random random = new Random();

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					List<int> mediaList = CustomMedia.GetIDListByCustomThingAndType(quizEntry.ThingID, MediaType.Photo);
					if (mediaList.Count > 0)
					{
						switch (pictureType)
						{
							case QuizSettings.PictureTypes.Best:
								quizEntry.MediaID = mediaList[0];
								if (quizEntry.IsDuplicate)
								{
									// Try set to the next best picture for a duplicate
									if (mediaList.Count > 1)
									{
										quizEntry.MediaID = mediaList[1];
									}
								}
								break;
							case QuizSettings.PictureTypes.FemaleOther:
								if (mediaList.Count > 1)
								{
									// Use the second picture (female/other) if available
									quizEntry.MediaID = mediaList[1];
									if (quizEntry.IsDuplicate)
									{
										// Use a random picture for a duplicate
										quizEntry.MediaID = mediaList[random.Next(0, mediaList.Count)];
									}
								}
								else
								{
									// Default to only available picture
									quizEntry.MediaID = mediaList[0];
								}
								break;
							case QuizSettings.PictureTypes.Random:
								// Set a random picture from the media list
								quizEntry.MediaID = mediaList[random.Next(0, mediaList.Count)];
								break;
						}
					}

					// Add sound as the secondary media
					List<int> secondaryMediaList = CustomMedia.GetIDListByCustomThingAndType(quizEntry.ThingID, MediaType.Sound);
					if (secondaryMediaList.Count > 0)
					{
						quizEntry.SecondaryMediaID = secondaryMediaList[0];
					}

					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null || quizEntry.SecondaryMediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMediaCustom(quizEntry);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetSoundMediaCustom(List<QuizEntry> quizEntries, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					List<int> mediaList = CustomMedia.GetIDListByCustomThingAndType(quizEntry.ThingID, MediaType.Sound);
					if (mediaList.Count > 0)
					{
						quizEntry.MediaID = mediaList[0];
					}

					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMediaCustom(quizEntry);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetVideoMediaCustom(List<QuizEntry> quizEntries, double progressPosition, double progressIncrement)
		{
			List<QuizEntry> list = new List<QuizEntry>(quizEntries);

			foreach (QuizEntry quizEntry in list)
			{
				if (quizEntry.MediaID == null)
				{
					List<int> mediaList = CustomMedia.GetIDListByCustomThingAndType(quizEntry.ThingID, MediaType.Video);
					if (mediaList.Count > 0)
					{
						quizEntry.MediaID = mediaList[0];
					}

					// Remove quiz entry if proper media is not found
					if (quizEntry.MediaID == null)
					{
						quizEntries.Remove(quizEntry);
					}
				}
				else
				{
					SetSecondaryMediaCustom(quizEntry);
				}

				// Progress status needs to be updated
				OnProgressUpdate(new ProgressUpdateEventArgs((int)(progressPosition += progressIncrement)));
			}
		}

		private static void SetSecondaryMediaCustom(QuizEntry quizEntry)
		{
			string mediaType = CustomMedia.GetTypeByID((int)quizEntry.MediaID);
			if (mediaType == MediaType.Photo)
			{
				List<int> secondaryMediaList = CustomMedia.GetIDListByCustomThingAndType(quizEntry.ThingID, MediaType.Sound);
				if (secondaryMediaList.Count > 0)
				{
					quizEntry.SecondaryMediaID = secondaryMediaList[0];
				}
			}
		}

		private static void SetAlternateAnswers(List<QuizEntry> quizEntries, List<int> taxonomyList, QuizSettings.QuizTypes quizType, QuizSettings.DifficultyLevels difficultyLevel, int collectionID)
		{
			int increment = 1;
			int variant = 0;

			switch (difficultyLevel)
			{
				case QuizSettings.DifficultyLevels.Easy:
					increment = 25;
					variant = 5;
					break;
				case QuizSettings.DifficultyLevels.Medium:
					increment = 4;
					variant = 1;
					break;
				case QuizSettings.DifficultyLevels.Hard:
					increment = 1;
					variant = 0;
					break;
			}

			int numberOfAlternatesToAssign = quizType == QuizSettings.QuizTypes.MultipleChoice ? 4 : 3;
			Random random = new Random();

			foreach(QuizEntry quizEntry in quizEntries)
			{
				// Alternates for the "hard" quiz are, by default, pulled from "similar species".
				// If there are not enough "similars", the rest will be filled in below.
				if (difficultyLevel == QuizSettings.DifficultyLevels.Hard)
				{
					List<SimilarSpecies> similarList = Organism.GetSimilarSpecies(quizEntry.ThingID, collectionID);
					int numberOfSimilarSpeciesToAssign = similarList.Count >= numberOfAlternatesToAssign ? numberOfAlternatesToAssign : similarList.Count;
					for (int similarIndex = 0; similarIndex < numberOfSimilarSpeciesToAssign; similarIndex++)
					{
						quizEntry.AlternateThings.Add(similarList[similarIndex].ThingID);
					}
				}

				// Set any alternates that haven't already been set
				bool alternateDirection = true;
				while (quizEntry.AlternateThings.Count < numberOfAlternatesToAssign)
				{
					int entryIndex = taxonomyList.IndexOf(quizEntry.ThingID);

					// Set the jiggle to be a random number between zero and the variant
					int jiggle = random.Next(variant + 1);

					// Randomly determine the direction of the jiggle
					if (random.Next(2) == 0)
					{
						jiggle *= -1;
					}

					// Alternate between selecting an alternate above or below the taxonomy list
					int direction = alternateDirection ? 1 : -1;
					alternateDirection = !alternateDirection;

                    // Calculate the jump.
                    // Check the breadth of the jump.  If it attempts to go beyond the top
                    // or bottom of the list, switch to the other direction.
					int jumpValue = ((increment * (quizEntry.AlternateThings.Count + 1)) + jiggle) * direction;
					if((jumpValue < 0 && (jumpValue * -1) >= entryIndex) || (jumpValue > 0 && (jumpValue + entryIndex) >= (taxonomyList.Count - 1)))
					{
						jumpValue *= -1;
					}

					// Make sure the alternate is valid.  If not, try another method to get valid alternate.
					int alternateIndex = entryIndex + jumpValue;
					if (alternateIndex < 0 || alternateIndex >= taxonomyList.Count)
					{
						if (entryIndex == 0)
						{
							alternateIndex = random.Next(1, taxonomyList.Count);
						}
						else if (entryIndex == taxonomyList.Count - 1)
						{
							alternateIndex = random.Next(1, taxonomyList.Count - 1);
						}
						else
						{
							if (direction == 1)
							{
								alternateIndex = random.Next(entryIndex + 1, taxonomyList.Count);
							}
							else
							{
								alternateIndex = random.Next(1, entryIndex);
							}
						}
					}

					// Make sure the alternate is valid
					if (alternateIndex >= 0 && alternateIndex < taxonomyList.Count)
					{
						int alternateThingID = taxonomyList[alternateIndex];

						// Make sure the alternate is not the answer or is a duplicate
						if (alternateThingID != quizEntry.ThingID && !quizEntry.AlternateThings.Contains(alternateThingID))
						{
							quizEntry.AlternateThings.Add(alternateThingID);
						}
					}
				}
			}
		}

		private static void SetSortOrder(List<QuizEntry> quizEntries, List<int> taxonomyList, QuizSource.QuizSourceTypes quizSourceType, bool shuffle)
		{
			Random random = new Random();
			int listIndex = 0;
			foreach (QuizEntry quizEntry in quizEntries)
			{
				if (shuffle)
				{
					// Set sort order to random number between 1 and 100000
					quizEntry.SortOrder = random.Next(1, 100000 + 1);
				}
				else
				{
                    if (quizSourceType == QuizSource.QuizSourceTypes.CustomList)
                    {
                        // Keep custom lists in their original order
                        quizEntry.SortOrder = listIndex + 1;
                    }
                    else
					{
						// Use index from taxonomy list to determine the sort order since
						// the taxonomy list is already sorted in the proper order
						int entryIndex = taxonomyList.IndexOf(quizEntry.ThingID);
						quizEntry.SortOrder = entryIndex + 1;
					}
				}

				listIndex++;
			}
		}

		private static void SetAlternateAnswersCustom(List<QuizEntry> quizEntries, int categoryID, QuizSettings.QuizTypes quizType, QuizSettings.DifficultyLevels difficultyLevel)
		{
			List<int> possibleQuizEntries = CustomThing.GetIDListByCategoryID(categoryID);

			int numberOfAlternatesToAssign = quizType == QuizSettings.QuizTypes.MultipleChoice ? 4 : 3;
			bool enforceDuplicates = numberOfAlternatesToAssign < possibleQuizEntries.Count;

			Random random = new Random();

			foreach (QuizEntry quizEntry in quizEntries)
			{
				while (quizEntry.AlternateThings.Count < numberOfAlternatesToAssign)
				{
					// Get a random alternate
					int alternateIndex = random.Next(0, possibleQuizEntries.Count);
					int alternateThingID = possibleQuizEntries[alternateIndex];

					// Make sure the alternate is not the answer or is a duplicate
					if (alternateThingID != quizEntry.ThingID)
					{
						if (!enforceDuplicates || (enforceDuplicates && !quizEntry.AlternateThings.Contains(alternateThingID)))
						{
							quizEntry.AlternateThings.Add(alternateThingID);
						}
					}
				}
			}
		}

		private static void SetSortOrderCustom(List<QuizEntry> quizEntries, bool shuffle)
		{
			Random random = new Random();
			int listIndex = 0;
			foreach (QuizEntry quizEntry in quizEntries)
			{
				if (shuffle)
				{
					// Set sort order to random number between 1 and 100000
					quizEntry.SortOrder = random.Next(1, 100000 + 1);
				}
				else
				{
					quizEntry.SortOrder = ++listIndex;
				}
			}
		}

		public static IMedia GetMedia(int mediaID, bool isCustom)
		{
			IMedia media = null;

			if (isCustom || UserSettings.Instance.QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				media = CustomMedia.GetByID(mediaID);
			}
			else
			{
				media = Media.GetByID(mediaID);
			}

			return media;
		}

		public static IMedia GetPhotoMedia(int thingID, QuizSettings.PictureTypes pictureType)
		{
			IMedia media = null;

			if (UserSettings.Instance.QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				Random random = new Random();
				List<int> mediaIDList = CustomMedia.GetIDListByCustomThingAndType(thingID, MediaType.Photo);
				if (mediaIDList.Count > 0)
				{
					switch (pictureType)
					{
						case QuizSettings.PictureTypes.Best:
							media = CustomMedia.GetByID(mediaIDList[0]);
							break;
						case QuizSettings.PictureTypes.FemaleOther:
							if (mediaIDList.Count > 1)
							{
								// Use the second picture (female/other) if available
								media = CustomMedia.GetByID(mediaIDList[1]);
							}
							else
							{
								// Default to only available picture
								media = CustomMedia.GetByID(mediaIDList[0]);
							}
							break;
						case QuizSettings.PictureTypes.Random:
							// Set a random picture from the media list
							media = CustomMedia.GetByID(mediaIDList[random.Next(0, mediaIDList.Count)]);
							break;
					}
				}
			}
			else
			{
				Random random = new Random();
				List<int> mediaIDList = Media.GetListByThingAndType(thingID, MediaType.Photo, true);
				if (mediaIDList.Count > 0)
				{
					switch (pictureType)
					{
						case QuizSettings.PictureTypes.Best:
							media = Media.GetByID(mediaIDList[0]);
							break;
						case QuizSettings.PictureTypes.FemaleOther:
							if (mediaIDList.Count > 1)
							{
								// Use the second picture (female/other) if available
								media = Media.GetByID(mediaIDList[1]);
							}
							else
							{
								// Default to only available picture
								media = Media.GetByID(mediaIDList[0]);
							}
							break;
						case QuizSettings.PictureTypes.Random:
							// Set a random picture from the media list
							media = Media.GetByID(mediaIDList[random.Next(0, mediaIDList.Count)]);
							break;
					}
				}
			}

			return media;
		}

		public static IMedia GetRangeMapMedia(int thingID)
		{
			IMedia media = null;

			if (UserSettings.Instance.QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				// Just use photos for custom quizzes
				Random random = new Random();
				List<int> mediaIDList = CustomMedia.GetIDListByCustomThingAndType(thingID, MediaType.Photo);
				if (mediaIDList.Count > 0)
				{
					media = CustomMedia.GetByID(mediaIDList[0]);
				}
			}
			else
			{
				List<int> mediaIDList = Media.GetListByThingAndType(thingID, MediaType.RangeMap);
				if (mediaIDList.Count > 0)
				{
					media = Media.GetByID(mediaIDList[0]);
				}
			}

			return media;
		}

		public static IQuizThing GetThing(int thingID)
		{
			IQuizThing thing = null;

			if (UserSettings.Instance.QuizSettings.QuizSource.Type == QuizSource.QuizSourceTypes.CustomQuiz)
			{
				thing = CustomThing.GetByID(thingID);
			}
			else
			{
				thing = Organism.GetByID(thingID);
			}

			return thing;
		}

		public static event ProgressUpdateHandler ProgressUpdate
		{
			add
			{
				lock (eventLock)
				{
					progressUpdateHandler += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					progressUpdateHandler -= value;
				}
			}
		}

		protected static void OnProgressUpdate(ProgressUpdateEventArgs e)
		{
			ProgressUpdateHandler temp = progressUpdateHandler;
			if (temp != null)
			{
				temp(e);
			}
		}
	}
}
