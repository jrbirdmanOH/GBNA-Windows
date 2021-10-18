using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Organism : IQuizThing
	{
		private int id = 0;
		private Genus genus = new Genus();
		private Species species = new Species();
		private Order order = new Order();
		private Family family = new Family();
		private CharacteristicDictionary characteristics = null;
		private MediaCollection media = null;
		private List<Reference> references = null;
		private List<LanguageString> languages = null;
		private BandCode bandCode = null;
		private string notes = null;
        private AnimatedRangeMap animatedRangeMap = null;
		private WorldRangeMap worldRangeMap = null;
		private EBirdReference ebirdReference = null;

		private Dictionary<int, CommonName> commonNames = new Dictionary<int, CommonName>();

		public Organism()
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

		public CommonName CommonName
		{
			get
			{
				return GetCommonName(Language.English.ID);
			}
		}

		public CommonName CommonNameDisplay
		{
			get
			{
				return GetCommonName(UserSettings.Instance.Language.ID);
			}
		}

		public Genus Genus
		{
			get
			{
				return genus;
			}

			set
			{
				genus = value;
			}
		}

		public Species Species
		{
			get
			{
				return species;
			}

			set
			{
				species = value;
			}
		}

		public Order Order
		{
			get
			{
				return order;
			}

			set
			{
				order = value;
			}
		}

		public Family Family
		{
			get
			{
				return family;
			}

			set
			{
				family = value;
			}
		}

		public CharacteristicDictionary Characteristics
		{
			get
			{
				if (characteristics == null)
				{
					characteristics = ThingsDescriptionsDM.Instance.GetListByThingID(id);

					// Add additional references
					characteristics.Add(CharacteristicType.Reference, Reference.Flickr.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.Bing.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.GoogleCommonName.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.GoogleScientificName.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.Wikipedia.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.InternetBirdCollection.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.XenoCanto.Code);
					characteristics.Add(CharacteristicType.Reference, Reference.AllAboutBirds.Code);

					if (this.EBirdReference != null)
					{
						characteristics.Add(CharacteristicType.Reference, Reference.EBird.Code);
					}
				}

				return characteristics;
			}
		}

		private MediaCollection Media
		{
			get
			{
				if (media == null)
				{
					media = Thayer.Birding.Media.GetListByThingID(id);
					foreach (IMedia customMedia in CustomMedia.GetListByThingID(id).All)
					{
						media.Add(customMedia);
					}
				}

				return media;
			}
		}

		public List<LanguageString> Languages
		{
			get
			{
				if (languages == null)
				{
					languages = Data.LanguageRegionListDM.Instance.GetByThingID(this.ID);
				}

				return languages;
			}
		}

		public BandCode BandCode
		{
			get
			{
				if (bandCode == null)
				{
					bandCode = BandCode.GetByThingID(id);
				}

				return bandCode;
			}

			set
			{
				bandCode = value;
			}
		}

		public IMediaList Photos
		{
			get
			{
				return Media.Photos;
			}
		}

		public IMediaList Sounds
		{
			get
			{
				return Media.Sounds;
			}
		}

		public IMediaList Videos
		{
			get
			{
				return Media.Videos;
			}
		}

		public IMediaList RangeMaps
		{
			get
			{
				return Media.RangeMaps;
			}
		}

		public IMediaList AbundanceMaps
		{
			get
			{
				return Media.AbundanceMaps;
			}
		}

		public List<Reference> References
		{
			get
			{
				if (references == null)
				{
					references = new List<Reference>();

					CharacteristicCollection list = Characteristics[CharacteristicType.Reference];
					foreach (string characteristic in list)
					{
						Reference reference = Reference.GetByCode(characteristic);
						references.Add(reference);
					}
				}

				return references;
			}
		}

		public string ScientificName
		{
			get
			{
				return GenerateScientificName(Genus.Name, Species.Name);
			}
		}

		public string ScientificNamePronunciation
		{
			get
			{
				string genusPronunciation = Genus.Pronunciation;
				string speciesPronunciation = Species.Pronunciation;
				if(genusPronunciation == null || genusPronunciation.Length == 0)
				{
					genusPronunciation = Genus.Name;
				}

				if(speciesPronunciation == null || speciesPronunciation.Length == 0)
				{
					speciesPronunciation = Species.Name;
				}

				return GenerateScientificName(genusPronunciation, speciesPronunciation);
			}
		}

		public string Notes
		{
			get
			{
				if (notes == null)
				{
					notes = NotesDM.Instance.GetByThingID(id);
				}

				return notes;
			}

			set
			{
				notes = value;
			}
		}

        public AnimatedRangeMap AnimatedRangeMap
        {
            get
            {
                if (animatedRangeMap == null)
                {
                    animatedRangeMap = AnimatedRangeMap.GetByThingID(this.ID);
                }

                return animatedRangeMap;
            }
        }

		public WorldRangeMap WorldRangeMap
		{
			get
			{
				if (worldRangeMap == null)
				{
					worldRangeMap = WorldRangeMap.GetByThingID(this.ID);
				}

				return worldRangeMap;
			}
		}

		public EBirdReference EBirdReference
		{
			get
			{
				if (ebirdReference == null)
				{
					ebirdReference = EBirdReference.GetByThingID(this.ID);
				}

				return ebirdReference;
			}
		}

		public void SaveNotes(string notes)
		{
			Note note = new Note();
			note.ThingID = id;
			note.Text = notes;

			note.Save();
		}

		public CommonName GetCommonName(int languageID)
		{
			CommonName commonName = null;

			if(!commonNames.TryGetValue(languageID, out commonName))
			{
				// Retrieve the common name and add it to the dictionary
				commonName = CommonName.GetByThingIDAndLanguage(this.ID, languageID);
				commonNames[languageID] = commonName;
			}

			return commonName;
		}

		public void SetCommonName(CommonName commonName)
		{
			commonNames[commonName.LanguageID] = commonName;
		}

		public override string ToString()
		{
			string retVal;

			OrganismDisplayOptions displayName = UserSettings.Instance.DisplayName;
			if (displayName == OrganismDisplayOptions.CommonName)
			{
				retVal = CommonName.Name;
			}
			else if (displayName == OrganismDisplayOptions.CommonNameLastFirst)
			{
				StringBuilder name = new StringBuilder(CommonName.Last);
				name.Append(", ");
				name.Append(CommonName.First);

				retVal = name.ToString();
			}
			else if (displayName == OrganismDisplayOptions.ScientificName)
			{
				retVal = ScientificName;
			}
			else if (displayName == OrganismDisplayOptions.ScientificNameLastFirst)
			{
				StringBuilder name = new StringBuilder(species.Name);
				name.Append(", ");
				name.Append(genus.Name);

				retVal = name.ToString();
			}
			else
			{
				retVal = base.ToString();
			}

			return retVal;
		}

		internal static string GenerateScientificName(string genus, string species)
		{
			StringBuilder name = new StringBuilder(genus);
			name.Append(" ");
			name.Append(species);

			return name.ToString();
		}

		public static Organism GetByID(int thingID)
		{
//			return ThingsDM.Instance.GetByID(thingID);
			return ThingsDM.Instance.GetByIDAndLanguage(thingID, Language.English.ID);
		}

		public static Organism GetByIDAndLanguage(int thingID, int languageID)
		{
			return ThingsDM.Instance.GetByIDAndLanguage(thingID, languageID);
		}

		public List<SimilarSpecies> GetSimilarSpecies(int collectionID)
		{
			return SimilarThingsDM.Instance.GetSimilarSpecies(id, collectionID);
		}

		public List<int> GetRelatedSpecies(int collectionID, int taxonomyID)
		{
			return ThingsDM.Instance.GetRelatedThings(collectionID, family.ID, taxonomyID);
		}

		public static int GetNumberOfThingsWithMediaByQuiz(int quizID, int collectionID)
		{
			return ThingsDM.Instance.GetNumberOfThingsWithMediaByQuiz(quizID, collectionID);
		}

		public static int GetNumberOfThingsWithMediaByLocation(Location[] locations, bool commonOnly)
		{
			return ThingsDM.Instance.GetNumberOfThingsWithMediaByLocation(locations, commonOnly);
		}

		public static int GetNumberOfThingsWithMediaByTaxonomy(int taxonomyID, ITaxonomy[] taxonomies)
		{
			Kingdom[] kingdoms;
			Phylum[] phyla;
			Class[] classes;
			Order[] orders;
			Family[] families;
			Genus[] genera;
			Taxonomy.GetClassifications(taxonomies, out kingdoms, out phyla, out classes, out orders, out families, out genera);

			return ThingsDM.Instance.GetNumberOfThingsWithMediaByTaxonomy(taxonomyID, kingdoms, phyla, classes, orders, families, genera);
		}

		public static List<int> GetListWithMedia(int collectionID)
		{
			return ThingsDM.Instance.GetListWithMedia(collectionID);
		}

		public static List<SimilarSpecies> GetSimilarSpecies(int thingID, int collectionID)
		{
			return SimilarThingsDM.Instance.GetSimilarSpecies(thingID, collectionID);
		}

		public static CharacteristicCollection GetCharacteristicByID(int thingID, string characteristicType)
		{
			return ThingsDescriptionsDM.Instance.GetCharacteristicByThingID(thingID, characteristicType);
		}

		public static bool Exists(int thingID)
		{
			return ThingsDM.Instance.Exists(thingID);
		}
	}
}
