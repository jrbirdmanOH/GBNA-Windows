using System.Collections.Generic;

namespace Thayer.Birding
{
	public class OrganismSortOrder
	{
		public static OrganismSortOrder Alphabetic;
		public static OrganismSortOrder Taxonomic;

		private static List<OrganismSortOrder> list = null;

		private string code;
		private string text;

		static OrganismSortOrder()
		{
			list = new List<OrganismSortOrder>();

			Alphabetic = Create("A", "Alphabetic");
			Taxonomic = Create("T", "Taxonomic");
		}

		private static OrganismSortOrder Create(string code, string text)
		{
			OrganismSortOrder sort = new OrganismSortOrder(code, text);
			list.Add(sort);

			return sort;
		}

		private OrganismSortOrder(string code, string text)
		{
			this.code = code;
			this.text = text;
		}

		internal string Code
		{
			get
			{
				return code;
			}
		}

		public override string ToString()
		{
			return text;
		}

		public static OrganismSortOrder[] GetList()
		{
			return list.ToArray();
		}

		internal static OrganismSortOrder FromCode(string code)
		{
			foreach (OrganismSortOrder sort in list)
			{
				if (sort.Code == code)
				{
					return sort;
				}
			}

			return null;
		}
	}
}
