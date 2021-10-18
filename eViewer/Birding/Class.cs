using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public class Class : ITaxonomy
	{
		private int id = 0;
		private string name = string.Empty;
		private string description = string.Empty;
		private List<Order> orders = new List<Order>();

		public Class()
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

		public List<Order> Orders
		{
			get
			{
				return orders;
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
				List<ITaxonomy> list = new List<ITaxonomy>(Orders.Count);
				foreach (Order item in Orders)
				{
					list.Add(item);
				}

				return list;
			}
		}
	}
}
