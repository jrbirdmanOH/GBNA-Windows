using System.Collections.Generic;

namespace Thayer.Birding
{
	public class OrganismDisplayOptions
	{
		private static OrganismDisplayOptions commonName;
		private static OrganismDisplayOptions commonNameLastFirst;
		private static OrganismDisplayOptions scientificName;
		private static OrganismDisplayOptions scientificNameLastFirst;
		private static OrganismDisplayOptions bandCode;

		private static List<OrganismDisplayOptions> list;

		private string code;
		private string text;

		static OrganismDisplayOptions()
		{
			list = new List<OrganismDisplayOptions>();

			commonName = Create("CN", "Common Name");
			commonNameLastFirst = Create("CNLF", "Common Name (Last, First)");
			scientificName = Create("SN", "Scientific Name");
			scientificNameLastFirst = Create("SNLF", "Scientific Name (Last, First)");
			bandCode = Create("BC", "Bird Codes");
		}

		public static OrganismDisplayOptions CommonName
		{
			get
			{
				return commonName;
			}
		}

		public static OrganismDisplayOptions CommonNameLastFirst
		{
			get
			{
				return commonNameLastFirst;
			}
		}

		public static OrganismDisplayOptions ScientificName
		{
			get
			{
				return scientificName;
			}
		}

		public static OrganismDisplayOptions ScientificNameLastFirst
		{
			get
			{
				return scientificNameLastFirst;
			}
		}

		public static OrganismDisplayOptions BandCode
		{
			get
			{
				return bandCode;
			}
		}

		private static OrganismDisplayOptions Create(string code, string text)
		{
			OrganismDisplayOptions options = new OrganismDisplayOptions(code, text);
			list.Add(options);

			return options;
		}

		private OrganismDisplayOptions(string code, string text)
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

		public static OrganismDisplayOptions[] GetList()
		{
			return list.ToArray();
		}

		public override string ToString()
		{
			return text;
		}

		internal static OrganismDisplayOptions FromCode(string code)
		{
			foreach (OrganismDisplayOptions option in list)
			{
				if (option.Code == code)
				{
					return option;
				}
			}

			return null;
		}

		public bool IsScientific
		{
			get
			{
				bool isScientific = false;

				if (code == "SN" || code == "SNLF")
				{
					isScientific = true;
				}

				return isScientific;
			}
		}
	}
}
