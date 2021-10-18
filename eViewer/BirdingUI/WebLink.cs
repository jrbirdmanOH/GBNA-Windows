using System.Collections.Generic;

namespace Thayer.Birding.UI
{
	public class WebLink
	{
		private string code;
		private string caption;
		private bool displayInMenu = false;

		public static readonly string SEPARATOR = "SEPARATOR";

		private static List<WebLink> links = new List<WebLink>();

		static WebLink()
		{
			links.Add(new WebLink("TBS", "Thayer Birding Software"));
			links.Add(new WebLink("FAQ", "FAQ/Knowledgebase", false));
			links.Add(new WebLink("HELPNOW", "Get Help NOW!"));
			links.Add(new WebLink("NEWSLETTERS", "Sign Up for Newsletters"));
			links.Add(new WebLink("TUTORIAL", "Tutorials / Help Sessions"));
			links.Add(new WebLink("VERSION", "Version History"));
			links.Add(new WebLink("AUDACITY", "Sonogram Information"));
			links.Add(new WebLink(WebLink.SEPARATOR, string.Empty));
			links.Add(new WebLink("TOP25", "Top 25 Birding Sites"));
			links.Add(new WebLink("WILDBIRDS", "WildBirds Web Site"));
			links.Add(new WebLink("QUIZZES", "Online Bird Quizzes"));
			links.Add(new WebLink("CHECKLISTS", "State / Province Checklists"));
			links.Add(new WebLink("CLO", "Cornell Lab of Ornithology"));
			links.Add(new WebLink("ABA", "American Birding Association"));
			links.Add(new WebLink("CHICAGO", "Chicago Academy of Sciences"));
			links.Add(new WebLink("EBIRD", "eBird - Share Sightings"));
			links.Add(new WebLink("DENDROICA", "Dendroica: ID Birds"));
			links.Add(new WebLink("BIRDFORUM", "BirdForum - Ask Questions"));
			links.Add(new WebLink("IBC", "Internet Bird Collection"));
			links.Add(new WebLink("CANTO", "World Bird Songs"));
			links.Add(new WebLink("10000BIRDS", "10,000 Birds"));
			links.Add(new WebLink("PFW", "Project Feeder Watch"));
			links.Add(new WebLink("GBBC", "Great Backyard Bird Count"));
			links.Add(new WebLink("ONM", "Shop - Nature Mall"));
		}

		public static List<WebLink> Links
		{
			get
			{
				return links;
			}
		}

		public static List<WebLink> MenuLinks
		{
			get
			{
				List<WebLink> menuLinks = new List<WebLink>();

				foreach (WebLink link in links)
				{
					if (link.DisplayInMenu)
					{
						menuLinks.Add(link);
					}
				}

				return menuLinks;
			}
		}

		public static WebLink GetByCode(string code)
		{
			WebLink webLink = null;

			foreach (WebLink link in links)
			{
				if (link.Code == code)
				{
					webLink = link;
					break;
				}
			}

			return webLink;
		}

		private WebLink(string code, string caption) : this(code, caption, true)
		{
		}

		private WebLink(string code, string caption, bool displayInMenu)
		{
			this.code = code;
			this.caption = caption;
			this.displayInMenu = displayInMenu;
		}

		public string Code
		{
			get
			{
				return code;
			}
		}

		public string Caption
		{
			get
			{
				return caption;
			}
		}

		public bool DisplayInMenu
		{
			get
			{
				return displayInMenu;
			}
		}

		public bool IsSeparator
		{
			get
			{
				return this.Code.Equals(WebLink.SEPARATOR);
			}
		}

		public void Navigate(IShowsWebBrowser browser)
		{
			string url = "http://www.thayerbirding.com/gbna/WebLinks.asp?r=" + code;

			browser.OpenBrowser(url);
		}
	}
}
