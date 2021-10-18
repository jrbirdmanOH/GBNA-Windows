using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public class Order : ITaxonomy
	{
		private int id = 0;
		private string name = string.Empty;
		private string description = string.Empty;
		private string narrative = string.Empty;
		private List<Family> families = new List<Family>();

		public Order()
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

		public List<Family> Families
		{
			get
			{
				return families;
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
				List<ITaxonomy> list = new List<ITaxonomy>(Families.Count);
				foreach (Family item in Families)
				{
					list.Add(item);
				}

				return list;
			}
		}
	}
}
