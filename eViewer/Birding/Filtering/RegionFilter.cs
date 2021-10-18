using System.Text;
using System.Collections.Generic;
using Thayer.Birding.Data;

namespace Thayer.Birding.Filtering
{
	public class RegionFilter : IFilter
	{
		private int id;
		private string name;

		public RegionFilter(int collectionID, string name)
		{
			this.id = collectionID;
			this.name = name;
		}

		public int ID
		{
			get
			{
				return id;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public string DisplayName
		{
			get
			{
				return this.Name;
			}
		}

		public string Query
		{
			get
			{
				List<int> collections = new List<int>(1);
				collections.Add(id);
				return GetQuery(collections, true);
			}
		}

		public static string GetQuery(List<int> collections, bool commonOnly)
		{
			StringBuilder query = new StringBuilder();
			query.Append("SELECT DISTINCT CheckList.ThingID FROM CollectionLocations, Checklist WHERE Checklist.LocationID=CollectionLocations.LocationID AND CollectionLocations.CollectionID");

			if (collections.Count == 1)
			{
				query.Append("=");
				query.Append(collections[0]);
			}
			else
			{
				query.Append(" IN(");

				int index = 0;
				foreach (int collection in collections)
				{
					if (index > 0)
					{
						query.Append(", ");
					}
					query.Append(collection);
					index++;
				}

				query.Append(")");
			}

			if (commonOnly)
			{
				query.Append(" AND Checklist.Common=");
				query.Append(ApplicationSettings.GetDBBooleanValue(true));
			}

			return query.ToString();
		}

		public override int GetHashCode()
		{
			return this.ID;
		}

		public override bool Equals(object obj)
		{
			RegionFilter filter = obj as RegionFilter;

			return filter != null && filter.ID == this.ID;
		}
	}
}
