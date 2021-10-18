using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Thayer.Birding.Data;

namespace Thayer.Birding.Licensing
{
	public class Product
	{
		public const string GuideToBirdsOfNorthAmerica = "GBNA";
		public const string FeederWatchersGuideToBackyardBirds = "FGBB";
		public const string DucksGeeseAndSwansOfNorthAmerica = "DUCK";
		public const string HawksEaglesAndOwlsOfNorthAmerica = "HAWK";
		public const string WarblersOfNorthAmerica = "WARBLER";
		public const string BirdsOfCanada = "CAN";
		public const string The25BirdSampler = "SAMPLER";
		public const string BirdsOfMyRegion = "BOMR";
		public const string BirdsOfTheLower48 = "LF";
		public const string BirdsOfMexico = "MX";

		public const string BirdsOfAlabama = "AL";
		public const string BirdsOfAlaska = "AK";
		public const string BirdsOfArizona = "AZ";
		public const string BirdsOfArkansas = "AR";
		public const string BirdsOfCalifornia = "CA";
		public const string BirdsOfColorado = "CO";
		public const string BirdsOfConnecticut = "CT";
		public const string BirdsOfDelaware = "DE";
		public const string BirdsOfTheDistrictOfColumbia = "DC";
		public const string BirdsOfFlorida = "FL";
		public const string BirdsOfGeorgia = "GA";
		public const string BirdsOfIdaho = "ID";
		public const string BirdsOfIllinois = "IL";
		public const string BirdsOfIndiana = "IN";
		public const string BirdsOfIowa = "IA";
		public const string BirdsOfKansas = "KS";
		public const string BirdsOfKentucky = "KY";
		public const string BirdsOfLouisiana = "LA";
		public const string BirdsOfMaine = "ME";
		public const string BirdsOfMaryland = "MD";
		public const string BirdsOfMassachusetts = "MA";
		public const string BirdsOfMichigan = "MI";
		public const string BirdsOfMinnesota = "MN";
		public const string BirdsOfMississippi = "MS";
		public const string BirdsOfMissouri = "MO";
		public const string BirdsOfMontana = "MT";
		public const string BirdsOfNebraska = "NE";
		public const string BirdsOfNevada = "NV";
		public const string BirdsOfNewHampshire = "NH";
		public const string BirdsOfNewJersey = "NJ";
		public const string BirdsOfNewMexico = "NM";
		public const string BirdsOfNewYork = "NY";
		public const string BirdsOfNorthCarolina = "NC";
		public const string BirdsOfNorthDakota = "ND";
		public const string BirdsOfOhio = "OH";
		public const string BirdsOfOklahoma = "OK";
		public const string BirdsOfOregon = "OR";
		public const string BirdsOfPennsylvania = "PA";
		public const string BirdsOfRhodeIsland = "RI";
		public const string BirdsOfSouthCarolina = "SC";
		public const string BirdsOfSouthDakota = "SD";
		public const string BirdsOfTennessee = "TN";
		public const string BirdsOfTexas = "TX";
		public const string BirdsOfUtah = "UT";
		public const string BirdsOfVermont = "VT";
		public const string BirdsOfVirginia = "VA";
		public const string BirdsOfWashington = "WA";
		public const string BirdsOfWestVirginia = "WV";
		public const string BirdsOfWisconsin = "WI";
		public const string BirdsOfWyoming = "WY";

		public const string BirdsOfNewEngland = "USNE";
		public const string BirdsOfTheAtlanticCoast = "USAC";
		public const string BirdsOfTheMidwest = "USMW";
		public const string BirdsOfTheSouth = "USSO";
		public const string BirdsOfTheGreatPlains = "USGP";
		public const string BirdsOfTheRockies = "USRK";
		public const string BirdsOfTheSouthwest = "USSW";
		public const string BirdsOfThePacificNorthwest = "USNW";
		public const string BirdsOfWesternCanada = "CAPR";
		public const string BirdsOfEasternCanada = "CAMA";

		public const string BirdsOfAlberta = "AB";
		public const string BirdsOfBritishColumbia = "BC";
		public const string BirdsOfManitoba = "MB";
		public const string BirdsOfNewBrunswick = "NB";
		public const string BirdsOfNewfoundland = "NF";
		public const string BirdsOfTheNorthwestTerritories = "NT";
		public const string BirdsOfNovaScotia = "NS";
		public const string BirdsOfNunavut = "NU";
		public const string BirdsOfOntario = "ON";
		public const string BirdsOfPrinceEdwardIsland = "PE";
		public const string BirdsOfQuebec = "QC";
		public const string BirdsOfSaskatchewan = "SK";
		public const string BirdsOfTheYukonTerritory = "YT";

		private static Dictionary<string, string> nameMap = null;
		private static List<Product> stateList = null;
		private static List<Product> regionList = null;
		private static List<Product> provinceList = null;

		private static Product defaultProduct = null;

		private string code = string.Empty;
		private string selectedProductCode = string.Empty;
		private Collection collection = null;

		static Product()
		{
			nameMap = new Dictionary<string, string>();
			nameMap.Add(GuideToBirdsOfNorthAmerica, "Guide to Birds of North America");
			nameMap.Add(FeederWatchersGuideToBackyardBirds, "FeederWatchers Guide to Backyard Birds");
			nameMap.Add(DucksGeeseAndSwansOfNorthAmerica, "Ducks, Geese and Swans of North America");
			nameMap.Add(HawksEaglesAndOwlsOfNorthAmerica, "Hawks, Eagles and Owls of North America");
			nameMap.Add(WarblersOfNorthAmerica, "Warblers of North America");
			nameMap.Add(BirdsOfCanada, "Birds of Canada");
			nameMap.Add(The25BirdSampler, "25 Bird Sampler");
			nameMap.Add(BirdsOfMyRegion, "Birds of My Region");
			nameMap.Add(BirdsOfTheLower48, "Birds of the Lower 48");
			nameMap.Add(BirdsOfMexico, "Birds of Mexico");

			nameMap.Add(BirdsOfAlabama, "Birds of Alabama");
			nameMap.Add(BirdsOfAlaska, "Birds of Alaska");
			nameMap.Add(BirdsOfArizona, "Birds of Arizona");
			nameMap.Add(BirdsOfArkansas, "Birds of Arkansas");
			nameMap.Add(BirdsOfCalifornia, "Birds of California");
			nameMap.Add(BirdsOfColorado, "Birds of Colorado");
			nameMap.Add(BirdsOfConnecticut, "Birds of Connecticut");
			nameMap.Add(BirdsOfDelaware, "Birds of Delaware");
			nameMap.Add(BirdsOfTheDistrictOfColumbia, "Birds of the District of Columbia");
			nameMap.Add(BirdsOfFlorida, "Birds of Florida");
			nameMap.Add(BirdsOfGeorgia, "Birds of Georgia");
			nameMap.Add(BirdsOfIdaho, "Birds of Idaho");
			nameMap.Add(BirdsOfIllinois, "Birds of Illinois");
			nameMap.Add(BirdsOfIndiana, "Birds of Indiana");
			nameMap.Add(BirdsOfIowa, "Birds of Iowa");
			nameMap.Add(BirdsOfKansas, "Birds of Kansas");
			nameMap.Add(BirdsOfKentucky, "Birds of Kentucky");
			nameMap.Add(BirdsOfLouisiana, "Birds of Louisiana");
			nameMap.Add(BirdsOfMaine, "Birds of Maine");
			nameMap.Add(BirdsOfMaryland, "Birds of Maryland");
			nameMap.Add(BirdsOfMassachusetts, "Birds of Massachusetts");
			nameMap.Add(BirdsOfMichigan, "Birds of Michigan");
			nameMap.Add(BirdsOfMinnesota, "Birds of Minnesota");
			nameMap.Add(BirdsOfMississippi, "Birds of Mississippi");
			nameMap.Add(BirdsOfMissouri, "Birds of Missouri");
			nameMap.Add(BirdsOfMontana, "Birds of Montana");
			nameMap.Add(BirdsOfNebraska, "Birds of Nebraska");
			nameMap.Add(BirdsOfNevada, "Birds of Nevada");
			nameMap.Add(BirdsOfNewHampshire, "Birds of New Hampshire");
			nameMap.Add(BirdsOfNewJersey, "Birds of New Jersey");
			nameMap.Add(BirdsOfNewMexico, "Birds of New Mexico");
			nameMap.Add(BirdsOfNewYork, "Birds of New York");
			nameMap.Add(BirdsOfNorthCarolina, "Birds of North Carolina");
			nameMap.Add(BirdsOfNorthDakota, "Birds of North Dakota");
			nameMap.Add(BirdsOfOhio, "Birds of Ohio");
			nameMap.Add(BirdsOfOklahoma, "Birds of Oklahoma");
			nameMap.Add(BirdsOfOregon, "Birds of Oregon");
			nameMap.Add(BirdsOfPennsylvania, "Birds of Pennsylvania");
			nameMap.Add(BirdsOfRhodeIsland, "Birds of Rhode Island");
			nameMap.Add(BirdsOfSouthCarolina, "Birds of South Carolina");
			nameMap.Add(BirdsOfSouthDakota, "Birds of South Dakota");
			nameMap.Add(BirdsOfTennessee, "Birds of Tennessee");
			nameMap.Add(BirdsOfTexas, "Birds of Texas");
			nameMap.Add(BirdsOfUtah, "Birds of Utah");
			nameMap.Add(BirdsOfVermont, "Birds of Vermont");
			nameMap.Add(BirdsOfVirginia, "Birds of Virginia");
			nameMap.Add(BirdsOfWashington, "Birds of Washington");
			nameMap.Add(BirdsOfWestVirginia, "Birds of West Virginia");
			nameMap.Add(BirdsOfWisconsin, "Birds of Wisconsin");
			nameMap.Add(BirdsOfWyoming, "Birds of Wyoming");

			nameMap.Add(BirdsOfNewEngland, "Birds of New England (CT, MA, ME, NH, NY, RI, VT)");
			nameMap.Add(BirdsOfTheAtlanticCoast, "Birds of the Atlantic Coast (DC, DE, MD, NC, NJ, PA, VA)");
			nameMap.Add(BirdsOfTheMidwest, "Birds of the Midwest (IL, IN, KY, MI, MN, OH, WI, WV)");
			nameMap.Add(BirdsOfTheSouth, "Birds of the South (AL, FL, GA, LA, MS, SC, TN)");
			nameMap.Add(BirdsOfTheGreatPlains, "Birds of the Great Plains (AR, IA, KS, MO, ND, NE, OK, SD)");
			nameMap.Add(BirdsOfTheRockies, "Birds of the Rockies (CO, ID, MT, UT, WY)");
			nameMap.Add(BirdsOfTheSouthwest, "Birds of the Southwest (AZ, NM, NV)");
			nameMap.Add(BirdsOfThePacificNorthwest, "Birds of the Pacific Northwest (BC, OR, WA)");
			nameMap.Add(BirdsOfWesternCanada, "Birds of Western Canada (AB, BC, MB, NT, SK, YT)");
			nameMap.Add(BirdsOfEasternCanada, "Birds of Eastern Canada (NB, NL, NS, NU, ON, PE, QC)");

			nameMap.Add(BirdsOfAlberta, "Birds of Alberta");
			nameMap.Add(BirdsOfBritishColumbia, "Birds of British Columbia");
			nameMap.Add(BirdsOfManitoba, "Birds of Manitoba");
			nameMap.Add(BirdsOfNewBrunswick, "Birds of New Brunswick");
			nameMap.Add(BirdsOfNewfoundland, "Birds of Newfoundland");
			nameMap.Add(BirdsOfTheNorthwestTerritories, "Birds of the Northwest Territories");
			nameMap.Add(BirdsOfNovaScotia, "Birds of Nova Scotia");
			nameMap.Add(BirdsOfNunavut, "Birds of Nunavut");
			nameMap.Add(BirdsOfOntario, "Birds of Ontario");
			nameMap.Add(BirdsOfPrinceEdwardIsland, "Birds of Prince Edward Island");
			nameMap.Add(BirdsOfQuebec, "Birds of Quebec");
			nameMap.Add(BirdsOfSaskatchewan, "Birds of Saskatchewan");
			nameMap.Add(BirdsOfTheYukonTerritory, "Birds of the Yukon Territory");

			stateList = new List<Product>();
			stateList.Add(new Product(BirdsOfAlabama));
			stateList.Add(new Product(BirdsOfAlaska));
			stateList.Add(new Product(BirdsOfArizona));
			stateList.Add(new Product(BirdsOfArkansas));
			stateList.Add(new Product(BirdsOfCalifornia));
			stateList.Add(new Product(BirdsOfColorado));
			stateList.Add(new Product(BirdsOfConnecticut));
			stateList.Add(new Product(BirdsOfDelaware));
			stateList.Add(new Product(BirdsOfTheDistrictOfColumbia));
			stateList.Add(new Product(BirdsOfFlorida));
			stateList.Add(new Product(BirdsOfGeorgia));
			stateList.Add(new Product(BirdsOfIdaho));
			stateList.Add(new Product(BirdsOfIllinois));
			stateList.Add(new Product(BirdsOfIndiana));
			stateList.Add(new Product(BirdsOfIowa));
			stateList.Add(new Product(BirdsOfKansas));
			stateList.Add(new Product(BirdsOfKentucky));
			stateList.Add(new Product(BirdsOfLouisiana));
			stateList.Add(new Product(BirdsOfMaine));
			stateList.Add(new Product(BirdsOfMaryland));
			stateList.Add(new Product(BirdsOfMassachusetts));
			stateList.Add(new Product(BirdsOfMichigan));
			stateList.Add(new Product(BirdsOfMinnesota));
			stateList.Add(new Product(BirdsOfMississippi));
			stateList.Add(new Product(BirdsOfMissouri));
			stateList.Add(new Product(BirdsOfMontana));
			stateList.Add(new Product(BirdsOfNebraska));
			stateList.Add(new Product(BirdsOfNevada));
			stateList.Add(new Product(BirdsOfNewHampshire));
			stateList.Add(new Product(BirdsOfNewJersey));
			stateList.Add(new Product(BirdsOfNewMexico));
			stateList.Add(new Product(BirdsOfNewYork));
			stateList.Add(new Product(BirdsOfNorthCarolina));
			stateList.Add(new Product(BirdsOfNorthDakota));
			stateList.Add(new Product(BirdsOfOhio));
			stateList.Add(new Product(BirdsOfOklahoma));
			stateList.Add(new Product(BirdsOfOregon));
			stateList.Add(new Product(BirdsOfPennsylvania));
			stateList.Add(new Product(BirdsOfRhodeIsland));
			stateList.Add(new Product(BirdsOfSouthCarolina));
			stateList.Add(new Product(BirdsOfSouthDakota));
			stateList.Add(new Product(BirdsOfTennessee));
			stateList.Add(new Product(BirdsOfTexas));
			stateList.Add(new Product(BirdsOfUtah));
			stateList.Add(new Product(BirdsOfVermont));
			stateList.Add(new Product(BirdsOfVirginia));
			stateList.Add(new Product(BirdsOfWashington));
			stateList.Add(new Product(BirdsOfWestVirginia));
			stateList.Add(new Product(BirdsOfWisconsin));
			stateList.Add(new Product(BirdsOfWyoming));

			regionList = new List<Product>();
			regionList.Add(new Product(BirdsOfNewEngland));
			regionList.Add(new Product(BirdsOfTheAtlanticCoast));
			regionList.Add(new Product(BirdsOfTheMidwest));
			regionList.Add(new Product(BirdsOfTheSouth));
			regionList.Add(new Product(BirdsOfTheGreatPlains));
			regionList.Add(new Product(BirdsOfTheRockies));
			regionList.Add(new Product(BirdsOfTheSouthwest));
			regionList.Add(new Product(BirdsOfThePacificNorthwest));
			regionList.Add(new Product(BirdsOfWesternCanada));
			regionList.Add(new Product(BirdsOfEasternCanada));
            regionList.Add(new Product(BirdsOfAlaska));
			regionList.Add(new Product(BirdsOfCanada));
			regionList.Add(new Product(BirdsOfTheLower48));
			regionList.Add(new Product(BirdsOfMexico));

			provinceList = new List<Product>();
			provinceList.Add(new Product(BirdsOfAlberta));
			provinceList.Add(new Product(BirdsOfBritishColumbia));
			provinceList.Add(new Product(BirdsOfManitoba));
			provinceList.Add(new Product(BirdsOfNewBrunswick));
			provinceList.Add(new Product(BirdsOfNewfoundland));
			provinceList.Add(new Product(BirdsOfTheNorthwestTerritories));
			provinceList.Add(new Product(BirdsOfNovaScotia));
			provinceList.Add(new Product(BirdsOfNunavut));
			provinceList.Add(new Product(BirdsOfOntario));
			provinceList.Add(new Product(BirdsOfPrinceEdwardIsland));
			provinceList.Add(new Product(BirdsOfQuebec));
			provinceList.Add(new Product(BirdsOfSaskatchewan));
			provinceList.Add(new Product(BirdsOfTheYukonTerritory));
		}

		public Product()
		{
		}

		public Product(string code)
		{
			this.code = code;
		}

		public static Product Default
		{
			get
			{
				if (defaultProduct == null)
				{
					defaultProduct = new Product(The25BirdSampler);
				}

				return defaultProduct;
			}
		}

		public static List<Product> RegionProductList
		{
			get
			{
				return regionList;
			}
		}

		public static List<Product> StateProductList
		{
			get
			{
				return stateList;
			}
		}

		public static List<Product> ProvinceProductList
		{
			get
			{
				return provinceList;
			}
		}

		public string Code
		{
			get
			{
				return code;
			}

			set
			{
				code = value;
			}
		}

		public string Name
		{
			get
			{
				return nameMap[this.Code];
			}
		}

		public string SelectedProductCode
		{
			get
			{
				return selectedProductCode;
			}

			set
			{
				selectedProductCode = value;
			}
		}

		public bool RequiresProductSelection
		{
			get
			{
				return this.Code == Product.BirdsOfMyRegion;
			}
		}

		public bool HasSelectedProduct
		{
			get
			{
				return selectedProductCode.Length > 0;
			}
		}

		public string EffectiveProductCode
		{
			get
			{
				string effectiveProductCode = string.Empty;

				if (this.RequiresProductSelection)
				{
					if (this.HasSelectedProduct)
					{
						effectiveProductCode = this.SelectedProductCode;
					}
				}
				else
				{
					effectiveProductCode = this.Code;
				}

				return effectiveProductCode;
			}
		}

		public Collection Collection
		{
			get
			{
				if (collection == null)
				{
					collection = CollectionDM.Instance.GetByCode(this.EffectiveProductCode);
				}

				return collection;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		public void ReadXml(XmlNode node)
		{
			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Name == "productCode")
				{
					this.Code = childNode.FirstChild.Value;
				}
				else if (childNode.Name == "selectedProductCode")
				{
					this.SelectedProductCode = childNode.FirstChild.Value;
				}
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("product");
			writer.WriteAttributeString("requiresProductSelection", this.RequiresProductSelection.ToString());
			writer.WriteElementString("productCode", this.Code);
			if (this.RequiresProductSelection && this.HasSelectedProduct)
			{
				writer.WriteElementString("selectedProductCode", this.SelectedProductCode);
			}
			writer.WriteEndElement();
		}
	}
}
