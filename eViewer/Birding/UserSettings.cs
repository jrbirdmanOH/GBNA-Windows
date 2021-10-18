using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Thayer.Birding.Filtering;

namespace Thayer.Birding
{
	public class UserSettings
	{
		private static UserSettings instance = new UserSettings();

		private string fileName;
		private XmlSerializer generalSerializer = new XmlSerializer(typeof(GeneralSettings));
		private XmlSerializer quizSerializer = new XmlSerializer(typeof(QuizSettings));

		private GeneralSettings generalSettings = null;
		private QuizSettings quizSettings = null;

		private readonly object eventLock = new object();
		private event EventHandler<EventArgs> displayNameChanged;
		private event EventHandler<EventArgs> sortOrderChanged;
		private event EventHandler<EventArgs> showAliasesChanged;
		private event EventHandler<LanguageChangedEventArgs> languageChanged;

		private UserSettings()
		{
			string parentPath = ApplicationSettings.AppDataPath;
			parentPath = Path.Combine(parentPath, "Settings");
			if (!Directory.Exists(parentPath))
			{
				Directory.CreateDirectory(parentPath);
			}

			parentPath = Path.Combine(parentPath, WindowsIdentity.GetCurrent().Name);
			if (!Directory.Exists(parentPath))
			{
				Directory.CreateDirectory(parentPath);
			}

			fileName = Path.Combine(parentPath, "UserSettings.xml");

			Reload();
		}

		public static UserSettings Instance
		{
			get
			{
				return instance;
			}
		}

		public Collection Collection
		{
			get
			{
				int collectionID = generalSettings.CollectionID;

				Collection collection = null;
				if (collectionID > 0)
				{
					collection = Collection.GetByID(collectionID);
				}

				if (collection == null)
				{
					List<Collection> collections = Collection.GetList();
					collection = collections[0];
				}

				return collection;
			}

			set
			{
				generalSettings.CollectionID = value.ID;
				Save();
			}
		}

		public OrganismDisplayOptions DisplayName
		{
			get
			{
				if (generalSettings.DisplayName == null)
				{
					return OrganismDisplayOptions.CommonName;
				}
				else
				{
					return OrganismDisplayOptions.FromCode(generalSettings.DisplayName);
				}
			}

			set
			{
				if (generalSettings.DisplayName != value.Code)
				{
					generalSettings.DisplayName = value.Code;
					Save();
					OnDisplayNameChanged(new EventArgs());
				}
			}
		}

		public int OrganismID
		{
			get
			{
				return generalSettings.OrganismID;
			}

			set
			{
				if (generalSettings.OrganismID != value)
				{
					generalSettings.OrganismID = value;
					Save();
				}
			}
		}

		public OrganismSortOrder SortOrder
		{
			get
			{
				if (generalSettings.SortOrder == null)
				{
					return OrganismSortOrder.Alphabetic;
				}
				else
				{
					return OrganismSortOrder.FromCode(generalSettings.SortOrder);
				}
			}

			set
			{
				generalSettings.SortOrder = value.Code;
				Save();
				OnSortOrderChanged(EventArgs.Empty);
			}
		}

		public Language Language
		{
			get
			{
				return Language.GetByID(generalSettings.LanguageID);
			}

			set
			{
				if (generalSettings.LanguageID != value.ID)
				{
					generalSettings.LanguageID = value.ID;
					Save();
					OnLanguageChanged(new LanguageChangedEventArgs(value));
				}
			}
		}

		public bool ShowAliases
		{
			get
			{
				return generalSettings.ShowAliases;
			}

			set
			{
				if (generalSettings.ShowAliases != value)
				{
					generalSettings.ShowAliases = value;
					Save();
					OnShowAliasesChanged(new EventArgs());
				}
			}
		}

		public bool ShowCustomQuizQuickStart
		{
			get
			{
				return generalSettings.ShowCustomQuizQuickStart;
			}

			set
			{
				if (generalSettings.ShowCustomQuizQuickStart != value)
				{
					generalSettings.ShowCustomQuizQuickStart = value;
					Save();
				}
			}
		}

		public bool HideSightingsComments
		{
			get
			{
				return generalSettings.HideSightingsComments;
			}

			set
			{
				if (generalSettings.HideSightingsComments != value)
				{
					generalSettings.HideSightingsComments = value;
					Save();
				}
			}
		}

		public bool LimitNumberOfSightingsToDisplay
		{
			get
			{
				return generalSettings.LimitNumberOfSightingsToDisplay;
			}

			set
			{
				if (generalSettings.LimitNumberOfSightingsToDisplay != value)
				{
					generalSettings.LimitNumberOfSightingsToDisplay = value;
					Save();
				}
			}
		}

		public int NumberOfSightingsToDisplayLimit
		{
			get
			{
				return generalSettings.NumberOfSightingsToDisplayLimit;
			}

			set
			{
				if (generalSettings.NumberOfSightingsToDisplayLimit != value)
				{
					generalSettings.NumberOfSightingsToDisplayLimit = value;
					Save();
				}
			}
		}

		public List<int> IDWizardSelectedLocations
		{
			get
			{
				return generalSettings.IDWizardSelectedLocations;
			}

			set
			{
				generalSettings.IDWizardSelectedLocations = value;
				Save();
			}
		}

		public QuizSettings QuizSettings
		{
			get
			{
				return quizSettings;
			}

			set
			{
				quizSettings = value;
				Save();
			}
		}

		public FilterSettings FilterSettings
		{
			get
			{
				return UserFilterSettings.Instance.FilterSettings;
			}

			set
			{
				UserFilterSettings.Instance.FilterSettings = value;
			}
		}

		public event EventHandler<EventArgs> DisplayNameChanged
		{
			add
			{
				lock (eventLock)
				{
					displayNameChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					displayNameChanged -= value;
				}
			}
		}

		protected virtual void OnDisplayNameChanged(EventArgs e)
		{
			EventHandler<EventArgs> temp = displayNameChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		public event EventHandler<EventArgs> SortOrderChanged
		{
			add
			{
				lock (eventLock)
				{
					sortOrderChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					sortOrderChanged -= value;
				}
			}
		}

		protected virtual void OnSortOrderChanged(EventArgs e)
		{
			EventHandler<EventArgs> temp = sortOrderChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		public event EventHandler<EventArgs> ShowAliasesChanged
		{
			add
			{
				lock (eventLock)
				{
					showAliasesChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					showAliasesChanged -= value;
				}
			}
		}

		protected virtual void OnShowAliasesChanged(EventArgs e)
		{
			EventHandler<EventArgs> temp = showAliasesChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		public event EventHandler<LanguageChangedEventArgs> LanguageChanged
		{
			add
			{
				lock (eventLock)
				{
					languageChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					languageChanged -= value;
				}
			}
		}

		protected virtual void OnLanguageChanged(LanguageChangedEventArgs e)
		{
			EventHandler<LanguageChangedEventArgs> temp = languageChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		public void Reload()
		{
			if (File.Exists(fileName))
			{
				using (XmlTextReader reader = new XmlTextReader(fileName))
				{
					reader.WhitespaceHandling = WhitespaceHandling.None;

					reader.ReadToFollowing("GeneralSettings");
					generalSettings = (GeneralSettings)generalSerializer.Deserialize(reader);

					if (reader.Name != "QuizSettings")
					{
						reader.ReadToFollowing("QuizSettings");
					}
					quizSettings = (QuizSettings)quizSerializer.Deserialize(reader);
				}
			}
			else
			{
				generalSettings = new GeneralSettings();
				quizSettings = new QuizSettings();
			}
		}

		public void Save()
		{
			using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
			{
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument();
				writer.WriteStartElement("UserSettings");
				generalSerializer.Serialize(writer, generalSettings);
				quizSerializer.Serialize(writer, quizSettings);
				writer.WriteEndElement();
			}
		}

		public class GeneralSettings
		{
			private int collectionID = 0;
			private string displayName = "CN";
			private int organismID = 0;
			private string sortOrder = "A";
			private int languageID = Language.Default.ID;
			private bool showAliases = false;
			private bool showCustomQuizQuickStart = true;
			private bool hideSightingsComments = false;
			private bool limitNumberOfSightingsToDisplay = false;
			private int numberOfSightingsToDisplayLimit = 5;
			private List<int> idWizardSelectedLocations = new List<int>();

			public GeneralSettings()
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

			public string DisplayName
			{
				get
				{
					return displayName;
				}

				set
				{
					displayName = value;
				}
			}

			public int OrganismID
			{
				get
				{
					return organismID;
				}

				set
				{
					organismID = value;
				}
			}

			public string SortOrder
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

			public int LanguageID
			{
				get
				{
					return languageID;
				}

				set
				{
					languageID = value;
				}
			}

			public bool ShowAliases
			{
				get
				{
					return showAliases;
				}

				set
				{
					showAliases = value;
				}
			}

			public bool ShowCustomQuizQuickStart
			{
				get
				{
					return showCustomQuizQuickStart;
				}

				set
				{
					showCustomQuizQuickStart = value;
				}
			}

			public bool HideSightingsComments
			{
				get
				{
					return hideSightingsComments;
				}

				set
				{
					hideSightingsComments = value;
				}
			}

			public bool LimitNumberOfSightingsToDisplay
			{
				get
				{
					return limitNumberOfSightingsToDisplay;
				}

				set
				{
					limitNumberOfSightingsToDisplay = value;
				}
			}

			public int NumberOfSightingsToDisplayLimit
			{
				get
				{
					return numberOfSightingsToDisplayLimit;
				}

				set
				{
					numberOfSightingsToDisplayLimit = value;
				}
			}

			public List<int> IDWizardSelectedLocations
			{
				get
				{
					return idWizardSelectedLocations;
				}

				set
				{
					idWizardSelectedLocations = value;
				}
			}
		}
	}
}
