using System.Collections.Generic;

namespace Thayer.Birding
{
	public class Reference
	{
		public static Reference BirdersHandbook;
		public static Reference SibleysBirdsOfTheWorld;
		public static Reference ThayerBirding;
		public static Reference Flickr;
		public static Reference Bing;
		public static Reference GoogleCommonName;
		public static Reference GoogleScientificName;
		public static Reference Wikipedia;
		public static Reference InternetBirdCollection;
		public static Reference XenoCanto;
		public static Reference AllAboutBirds;
		public static Reference EBird;

		private static Dictionary<string, Reference> list;

		private string code;
		private string text;

		static Reference()
		{
			list = new Dictionary<string, Reference>();

			BirdersHandbook = CreateReference("TBH", "The Birder's Handbook");
			SibleysBirdsOfTheWorld = CreateReference("SBOW", "Dr. Charles Sibley's Birds of the World");
			ThayerBirding = CreateReference("thayerbirding.com", "Internet: Online guide for this species");
			Flickr = CreateReference("FLICKR", "Photos - Flickr");
			Bing = CreateReference("BING", "Photos - Bing");
			GoogleCommonName = CreateReference("GOOGLE_COMMON", "Google - Common Name");
			GoogleScientificName = CreateReference("GOOGLE_SCIENTIFIC", "Google - Scientific Name");
			Wikipedia = CreateReference("WIKIPEDIA", "Wikipedia");
			InternetBirdCollection = CreateReference("IBC", "The Internet Bird Collection");
			XenoCanto = CreateReference("XENO_CANTO", "Xeno-Canto Songs");
			AllAboutBirds = CreateReference("ALL_ABOUT_BIRDS", "All About Birds");
			EBird = CreateReference("EBIRD", "eBird");
		}

		private static Reference CreateReference(string code, string text)
		{
			Reference reference = new Reference(code, text);

			list.Add(code, reference);

			return reference;
		}

		private Reference(string code, string text)
		{
			this.code = code;
			this.text = text;
		}

		public string Code
		{
			get
			{
				return code;
			}
		}

		public string Text
		{
			get
			{
				return text;
			}
		}

		public static Reference GetByCode(string code)
		{
			return list[code];
		}
	}
}
