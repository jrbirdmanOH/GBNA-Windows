using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Kingdom : ITaxonomy
	{
		private int id = 0;
		private string name = string.Empty;
		private string description = string.Empty;
		private List<Phylum> phyla = new List<Phylum>();

		public Kingdom()
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

		public string Description
		{
			get
			{
				return description;
			}

			set
			{
				description = value;
			}
		}

		public List<Phylum> Phyla
		{
			get
			{
				return phyla;
			}
		}

		public static List<Kingdom> GetList(int taxonomyID)
		{
			return KingdomDM.Instance.GetList(taxonomyID);
		}

		string ITaxonomy.Caption
		{
			get
			{
				StringBuilder caption = new StringBuilder(Description);
				caption.Append(" (");
				caption.Append(Name);
				caption.Append(")");

				return caption.ToString();
			}
		}

		List<ITaxonomy> ITaxonomy.Children
		{
			get
			{
				List<ITaxonomy> list = new List<ITaxonomy>(Phyla.Count);
				foreach (Phylum item in Phyla)
				{
					list.Add(item);
				}

				return list;
			}
		}
	}
}
