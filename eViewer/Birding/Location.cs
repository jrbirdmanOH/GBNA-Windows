using System.Collections.Generic;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Location
	{
		private int id = 0;
		private string name = string.Empty;

		public Location()
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

		public override string ToString()
		{
			return name;
		}

		public List<Location> GetChildren(int collectionID)
		{
			return LocationDM.Instance.GetChildren(id, collectionID);
		}

		public static Location GetByID(int id)
		{
			return LocationDM.Instance.GetByID(id);
		}

		public static Location GetParent()
		{
			return LocationDM.Instance.GetParent();
		}

		public static List<Location> GetList(int collectionID)
		{
			return LocationDM.Instance.GetList(collectionID);
		}

		public static List<Location> GetList()
		{
			// Use the collection ID for Guide to Birds of North America
			return LocationDM.Instance.GetList(Collection.GuideToBirdsOfNorthAmerica);
		}
	}
}
