using System.Text;
using System.Collections.Generic;

namespace Thayer.Birding.Filtering
{
	public class FamilyFilter : IFilter
	{
		private int id;
		private string name;

		public FamilyFilter(int familyID, string name)
		{
			this.id = familyID;
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
				List<int> families = new List<int>(1);
				families.Add(id);
				return GetQuery(families);
			}
		}

		public static string GetQuery(List<int> families)
		{
			StringBuilder query = new StringBuilder("SELECT ThingID FROM Classifications WHERE FamilyID");
			if (families.Count == 1)
			{
				query.Append("=");
				query.Append(families[0]);
			}
			else
			{
				query.Append(" IN(");

				int index = 0;
				foreach (int family in families)
				{
					if (index > 0)
					{
						query.Append(", ");
					}
					query.Append(family);
					index++;
				}

				query.Append(")");
			}
			return query.ToString();
		}

		public override int GetHashCode()
		{
			return this.ID;
		}

		public override bool Equals(object obj)
		{
			FamilyFilter filter = obj as FamilyFilter;

			return filter != null && filter.ID == this.ID;
		}
	}
}
