using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Genus : ITaxonomy
	{
		private int id;
		private string name;
		private string description = string.Empty;
		private string pronunciation;

		public Genus()
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

		public string Pronunciation
		{
			get
			{
				return pronunciation;
			}

			set
			{
				pronunciation = value;
			}
		}

		public static Genus GetByID(int id)
		{
			return GenusDM.Instance.GetByID(id);
		}

		string ITaxonomy.Caption
		{
			get
			{
				return Name;
			}
		}

		List<ITaxonomy> ITaxonomy.Children
		{
			get
			{
				return null;
			}
		}
	}
}
