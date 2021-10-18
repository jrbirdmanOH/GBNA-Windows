using System.Text;
using System.Collections.Generic;

namespace Thayer.Birding.Filtering
{
	class CustomListFilter : IFilter
	{
		private int id;
		private string name;
		private string displayName;

		public CustomListFilter(int customListID, string name, string displayName)
		{
			this.id = customListID;
			this.name = name;
			this.displayName = displayName;
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
				return displayName;
			}
		}

		public string Query
		{
			get
			{
				List<int> customLists = new List<int>(1);
				customLists.Add(id);
				return GetQuery(customLists);
			}
		}

		public static string GetQuery(List<int> customLists)
		{
			StringBuilder query = new StringBuilder("SELECT ThingID FROM CustomListsThings WHERE CustomListID");
			if (customLists.Count == 1)
			{
				query.Append("=");
				query.Append(customLists[0]);
			}
			else
			{
				query.Append(" IN(");

				int index = 0;
				foreach (int customList in customLists)
				{
					if (index > 0)
					{
						query.Append(", ");
					}
					query.Append(customList);
					index++;
				}

				query.Append(")");
			}
			return query.ToString();
		}

		public override int GetHashCode()
		{
			return id;
		}

		public override bool Equals(object obj)
		{
			CustomListFilter filter = obj as CustomListFilter;

			return filter != null && filter.id == id;
		}
	}
}
