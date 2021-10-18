using System.Text;
using System.Collections.Generic;

namespace Thayer.Birding.Filtering
{
	public class StateFilter : IFilter
	{
		private int id;
		private string name;

		public StateFilter(int locationID, string name)
		{
			this.id = locationID;
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
				List<int> locations = new List<int>(1);
				locations.Add(id);
				return GetQuery(locations, true);
			}
		}

		public static string GetQuery(List<int> locations, bool commonOnly)
		{
			StringBuilder query = new StringBuilder("SELECT DISTINCT CheckList.ThingID FROM CheckList WHERE LocationID");
			if (locations.Count == 1)
			{
				query.Append("=");
				query.Append(locations[0]);
			}
			else
			{
				query.Append(" IN(");

				int index = 0;
				foreach (int location in locations)
				{
					if (index > 0)
					{
						query.Append(", ");
					}
					query.Append(location);
					index++;
				}

				query.Append(")");
			}

			if (commonOnly)
			{
				query.Append(" AND Common=");
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
			StateFilter filter = obj as StateFilter;

			return filter != null && filter.ID == this.ID;
		}
	}
}
