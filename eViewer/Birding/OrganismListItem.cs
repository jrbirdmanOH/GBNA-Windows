using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;
using Thayer.Birding.Filtering;

namespace Thayer.Birding
{
	public class OrganismListItem : IComparable<OrganismListItem>
	{
		private int id = 0;
		private string commonName = string.Empty;
		private string firstName = string.Empty;
		private string lastName = string.Empty;
		private string genus = string.Empty;
		private string species = string.Empty;
		private double taxonomicOrder = 0.0;
		private bool isAlias = false;
		private BandCode bandCode = null;

		public static readonly string AliasPrefix = "...";

		public OrganismListItem()
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

		public bool Exists
		{
			get
			{
				return ThingsDM.Instance.Exists(this.ID);
			}
		}

		public string CommonName
		{
			get
			{
				return commonName;
			}

			set
			{
				commonName = value;
			}
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}

			set
			{
				firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}

			set
			{
				lastName = value;
			}
		}

		public string Genus
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

		public string Species
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

		public double TaxonomicOrder
		{
			get
			{
				return taxonomicOrder;
			}

			set
			{
				taxonomicOrder = value;
			}
		}

		public bool IsAlias
		{
			get
			{
				return isAlias;
			}

			set
			{
				isAlias = value;
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

		public string ScientificName
		{
			get
			{
				return Organism.GenerateScientificName(Genus, Species);
			}
		}

		private static bool IncludeAliases
		{
			get
			{
				bool includeAliases = UserSettings.Instance.ShowAliases;
				if (includeAliases)
				{
					OrganismDisplayOptions selectedOption = UserSettings.Instance.DisplayName;
					if (selectedOption != null)
					{
						includeAliases = !selectedOption.IsScientific;
					}
				}

				return includeAliases;
			}
		}

		public string DisplayText
		{
			get
			{
				return this.ToString(true);
			}
		}

		public override string ToString()
		{
			return this.ToString(false);
		}

		public string ToString(OrganismDisplayOptions displayOption)
		{
			return ToString(displayOption, false);
		}

		private string ToString(bool addAliasPrefix)
		{
			return ToString(UserSettings.Instance.DisplayName, addAliasPrefix);
		}

		private string ToString(OrganismDisplayOptions displayOption, bool addAliasPrefix)
		{
			string retVal;

			if (displayOption == OrganismDisplayOptions.CommonName)
			{
				retVal = commonName;
			}
			else if (displayOption == OrganismDisplayOptions.CommonNameLastFirst)
			{
				StringBuilder name = new StringBuilder(lastName);
				name.Append(", ");
				name.Append(firstName);

				retVal = name.ToString();
			}
			else if (displayOption == OrganismDisplayOptions.ScientificName)
			{
				retVal = ScientificName;
			}
			else if (displayOption == OrganismDisplayOptions.ScientificNameLastFirst)
			{
				StringBuilder name = new StringBuilder(species);
				name.Append(", ");
				name.Append(genus);

				retVal = name.ToString();
			}
			else if (displayOption == OrganismDisplayOptions.BandCode)
			{
				StringBuilder name = new StringBuilder();
				if (this.BandCode != null)
				{
					name.Append(this.BandCode.Code);
				}

				retVal = name.ToString();
			}
			else
			{
				retVal = base.ToString();
			}

			if (this.IsAlias && addAliasPrefix)
			{
				StringBuilder retValWithAliasPrefix = new StringBuilder(retVal);
				retValWithAliasPrefix.Insert(0, OrganismListItem.AliasPrefix);
				retVal = retValWithAliasPrefix.ToString();
			}

			return retVal;
		}

		public static OrganismListItem GetByID(int organismID)
		{
			return ThingsDM.Instance.GetOrganismListItemByID(organismID);
		}

		public static OrganismListItem GetByMediaID(int mediaID)
		{
			return ThingsDM.Instance.GetOrganismListItemByMediaID(mediaID);
		}

		public static List<OrganismListItem> GetList(int collectionID)
		{
			return GetList(collectionID, Language.English.ID, null, IncludeAliases);
		}

		public static List<OrganismListItem> GetList(int collectionID, int languageID)
		{
			return GetList(collectionID, languageID, null, IncludeAliases);
		}

//		public static List<OrganismListItem> GetList(int collectionID, int languageID, IFilter filter)
//		{
//			return GetList(collectionID, languageID, filter, IncludeAliases);
//		}

		public static List<OrganismListItem> GetList(int collectionID, int languageID, FilterCollection filters)
		{
			return GetList(collectionID, languageID, filters, IncludeAliases);
		}

//		private static List<OrganismListItem> GetList(int collectionID, int languageID, IFilter filter, bool includeAliases)
//		{
//			return ThingsDM.Instance.GetList(collectionID, languageID, filter, includeAliases);
//		}

		private static List<OrganismListItem> GetList(int collectionID, int languageID, FilterCollection filters, bool includeAliases)
		{
			return ThingsDM.Instance.GetList(collectionID, languageID, filters, includeAliases);
		}

		public static List<OrganismListItem> Search(int collectionID, int taxonomyID, Location[] locations, bool commonOnly, Size[] sizes, Habitat[] habitats, bool predominantColor, Color[] colors, FieldMark[] fieldMarks, Sound[] sounds, Kingdom[] kingdoms, Phylum[] phyla, Class[] classes, Order[] orders, Family[] families, Genus[] genus)
		{
			return ThingsDM.Instance.Search(collectionID, taxonomyID, locations, commonOnly, sizes, habitats, predominantColor, colors, fieldMarks, sounds, kingdoms, phyla, classes, orders, families, genus);
		}

		#region IComparable<OrganismListItem> Members
		public int CompareTo(OrganismListItem other)
		{
			int result = 0;

			OrganismSortOrder sortOrder = UserSettings.Instance.SortOrder;
			if (sortOrder == OrganismSortOrder.Alphabetic)
			{
				result = this.DisplayText.CompareTo(other.DisplayText);
			}
			else
			{
				result = this.TaxonomicOrder.CompareTo(other.TaxonomicOrder);
				if (result == 0)
				{
					result = this.DisplayText.CompareTo(other.DisplayText);
				}
			}

			return result;
		}
		#endregion
	}
}
