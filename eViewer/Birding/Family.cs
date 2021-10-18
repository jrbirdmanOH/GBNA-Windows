using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Family : ITaxonomy
	{
		private int id = 0;
		private string name = string.Empty;
		private string description = string.Empty;
		private string narrative = string.Empty;
		private List<Genus> genera = new List<Genus>();

		public Family()
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

		public string Narrative
		{
			get
			{
				return narrative;
			}

			set
			{
				narrative = value;
			}
		}

		public List<Genus> Genera
		{
			get
			{
				return genera;
			}
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
				List<ITaxonomy> list = new List<ITaxonomy>(Genera.Count);
				foreach (Genus item in Genera)
				{
					list.Add(item);
				}

				return list;
			}
		}

		public static List<Family> GetList()
		{
			return FamilyDM.Instance.GetList();
		}
	}
}
