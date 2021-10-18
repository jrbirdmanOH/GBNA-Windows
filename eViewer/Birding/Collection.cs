using System.Collections.Generic;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Collection
	{
		public const int GuideToBirdsOfNorthAmerica = 1;

		private int id = 0;
		private string name = string.Empty;
		private string shortName = string.Empty;
		private int taxonomyID = 0;

		public Collection()
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

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public string ShortName
		{
			get
			{
				return shortName;
			}

			set
			{
				shortName = value;
			}
		}

		public int TaxonomyID
		{
			get
			{
				return taxonomyID;
			}

			set
			{
				taxonomyID = value;
			}
		}

		public static List<Collection> GetList()
		{
			return CollectionDM.Instance.GetList();
		}

		public static Collection GetByID(int collectionID)
		{
			return CollectionDM.Instance.GetByID(collectionID);
		}
	}
}
