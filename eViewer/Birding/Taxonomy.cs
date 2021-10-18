using System.Collections.Generic;
using Thayer.Birding.Data;


namespace Thayer.Birding
{
	/// <summary>
	/// Summary description for Taxonomy.
	/// </summary>
	public class Taxonomy
	{
		private int id;
		private string name;
		private string description;
		private string comments;
		private bool locked;

		public Taxonomy()
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

		public string Comments
		{
			get
			{
				return comments;
			}

			set
			{
				comments = value;
			}
		}

		public bool Locked
		{
			get
			{
				return locked;
			}

			set
			{
				locked = value;
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public static TaxonomyCollection GetList()
		{
			return TaxonomyDM.Instance.GetList();
		}

		public static void GetClassifications(ITaxonomy[] taxonomies, out Kingdom[] kingdoms, out Phylum[] phyla, out Class[] classes, out Order[] orders, out Family[] families, out Genus[] genera)
		{
			List<Kingdom> kingdomList = new List<Kingdom>();
			List<Phylum> phylumList = new List<Phylum>();
			List<Class> classList = new List<Class>();
			List<Order> orderList = new List<Order>();
			List<Family> familyList = new List<Family>();
			List<Genus> genusList = new List<Genus>();

			if (taxonomies != null)
			{
				foreach (ITaxonomy taxonomy in taxonomies)
				{
					if (taxonomy is Kingdom)
					{
						kingdomList.Add((Kingdom)taxonomy);
					}
					else if (taxonomy is Phylum)
					{
						phylumList.Add((Phylum)taxonomy);
					}
					else if (taxonomy is Class)
					{
						classList.Add((Class)taxonomy);
					}
					else if (taxonomy is Order)
					{
						orderList.Add((Order)taxonomy);
					}
					else if (taxonomy is Family)
					{
						familyList.Add((Family)taxonomy);
					}
					else if (taxonomy is Genus)
					{
						genusList.Add((Genus)taxonomy);
					}
				}
			}

			kingdoms = kingdomList.ToArray();
			phyla = phylumList.ToArray();
			classes = classList.ToArray();
			orders = orderList.ToArray();
			families = familyList.ToArray();
			genera = genusList.ToArray();
		}
	}
}
