using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.Filtering;

namespace Thayer.Birding.UI.Windows
{
	public partial class EGuideForm : BaseForm, IEGuideForm
	{
		private string htmlFilename = null;
		private List<OrganismListItem> list = null;
		private ImagePreferenceType imagePreference = ImagePreferenceType.Primary;
		private static string spectrogramLocation = null;

		private readonly object eventLock = new object();
		private event EventHandler<EventArgs> filterChanged;

		private static readonly string ViewBirdHelpTopicId = "22";
		private static readonly string ViewRelatedHelpTopicId = "70";
		private static readonly string ViewSimilarHelpTopicId = "71";

		private static Dictionary<string, string> birdersHandbookMap = null;

		static EGuideForm()
		{
			birdersHandbookMap = new Dictionary<string, string>();
			birdersHandbookMap.Add(OrganismListItem.GetByID(9627).ScientificName, "Carduelis tristis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1730).ScientificName, "Sterna aleutica");
			birdersHandbookMap.Add(OrganismListItem.GetByID(3490).ScientificName, "Ceryle alcyon");
			birdersHandbookMap.Add(OrganismListItem.GetByID(5973).ScientificName, "Bombycilla garrulous");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1696).ScientificName, "Larus philadelphia");
			birdersHandbookMap.Add(OrganismListItem.GetByID(7756).ScientificName, "Poecile hudsonica");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8473).ScientificName, "Psilorhinus morio");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1709).ScientificName, "Sterna caspia");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9632).ScientificName, "Carduelis flammea");
			birdersHandbookMap.Add(OrganismListItem.GetByID(5110).ScientificName, "Myiarchus tuberculifer");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1714).ScientificName, "Sterna elegans");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1683).ScientificName, "Larus pipixcan");
			birdersHandbookMap.Add(OrganismListItem.GetByID(779).ScientificName, "Asturina nitida");
			birdersHandbookMap.Add(OrganismListItem.GetByID(7755).ScientificName, "Poecile cincta");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1708).ScientificName, "Sterna nilotica");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(1028).ScientificName, "Centrocercus minimus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9631).ScientificName, "Carduelis hornemanni");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1682).ScientificName, "Larus atricilla");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9629).ScientificName, "Carduelis lawrencei");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9628).ScientificName, "Carduelis psaltria");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1698).ScientificName, "Larus minutus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9612).ScientificName, "Carduelis pinus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(3489).ScientificName, "Ceryle torquatus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1711).ScientificName, "Sterna maxima");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1715).ScientificName, "Sterna sandvicensis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(2770).ScientificName, "Nyctea scandiacus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1732).ScientificName, "Sterna fuscata");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1574).ScientificName, "Heteroscelus incanus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1576).ScientificName, "Catoptrophorus semipalmatus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(10131).ScientificName, "Gallinago gallinago");

			birdersHandbookMap.Add(OrganismListItem.GetByID(8800).ScientificName, "Aimophila quinquestriata");
			birdersHandbookMap.Add(OrganismListItem.GetByID(19850).ScientificName, "Caprimulgus vociferus");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(3489).ScientificName, "Ceryle torquatus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(582).ScientificName, "Melanitta nigra");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8963).ScientificName, "Pipilo aberti");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8962).ScientificName, "Pipilo crissalis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8961).ScientificName, "Pipilo fuscus");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(5110).ScientificName, "Hirundo tuberculifer");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(7755).ScientificName, "Poecile cincta");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(7756).ScientificName, "Poecile hudsonica");
			birdersHandbookMap.Add(OrganismListItem.GetByID(19851).ScientificName, "Troglodytes troglodytes");
			birdersHandbookMap.Add(OrganismListItem.GetByID(6046).ScientificName, "Troglodytes troglodytes");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9339).ScientificName, "Vermivora pinus");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9632).ScientificName, "Carduelis flammea");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9631).ScientificName, "Carduelis hornemanni");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9629).ScientificName, "Carduelis lawrencei");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9612).ScientificName, "Carduelis pinus");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9628).ScientificName, "Carduelis psaltria");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9611).ScientificName, "Carduelis spinus");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9627).ScientificName, "Carduelis tristis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9607).ScientificName, "Carduelis sinica");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(8473).ScientificName, "Cyanocorax morio");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9341).ScientificName, "Vermivora celata");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9344).ScientificName, "Vermivora crissalis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9345).ScientificName, "Vermivora luciae");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9340).ScientificName, "Vermivora peregrina");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9342).ScientificName, "Vermivora ruficapilla");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9347).ScientificName, "Parula superciliosa");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9343).ScientificName, "Vermivora virginiae");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9384).ScientificName, "Seiurus motacilla");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9383).ScientificName, "Seiurus noveboracensis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8808).ScientificName, "Aimophila aestivalis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8809).ScientificName, "Aimophila botterii");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8806).ScientificName, "Aimophila carpalis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8810).ScientificName, "Aimophila cassinii");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8751).ScientificName, "Calcarius mccownii");

			birdersHandbookMap.Add(OrganismListItem.GetByID(1365).ScientificName, "Gallinula chloropus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(1523).ScientificName, "Charadrius alexandrinus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9348).ScientificName, "Parula americana");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9349).ScientificName, "Parula pitiayumi");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9352).ScientificName, "Dendroica cerulea");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9353).ScientificName, "Dendroica caerulescens");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9357).ScientificName, "Dendroica pinus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9358).ScientificName, "Dendroica pensylvanica");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9359).ScientificName, "Dendroica graciae");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9364).ScientificName, "Dendroica dominica");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9365).ScientificName, "Dendroica fusca");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9366).ScientificName, "Dendroica nigrescens");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9367).ScientificName, "Dendroica townsendi");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9368).ScientificName, "Dendroica occidentalis");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9369).ScientificName, "Dendroica chrysoparia");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9370).ScientificName, "Dendroica virens");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9371).ScientificName, "Dendroica discolor");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9373).ScientificName, "Dendroica palmarum");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9374).ScientificName, "Dendroica kirtlandii");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9375).ScientificName, "Dendroica tigrina");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9376).ScientificName, "Dendroica magnolia");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9377).ScientificName, "Dendroica coronata");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9378).ScientificName, "Dendroica striata");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9379).ScientificName, "Dendroica castanea");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9398).ScientificName, "Oporornis formosus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9400).ScientificName, "Oporornis philadelphia");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9401).ScientificName, "Oporornis tolmiei");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9407).ScientificName, "Wilsonia citrina");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9408).ScientificName, "Wilsonia pusilla");
			birdersHandbookMap.Add(OrganismListItem.GetByID(9409).ScientificName, "Wilsonia canadensis");
//			birdersHandbookMap.Add(OrganismListItem.GetByID(9425).ScientificName, "Euthlypis lachrymosa");
			birdersHandbookMap.Add(OrganismListItem.GetByID(19813).ScientificName, "Dendroica petechia");

            birdersHandbookMap.Add(OrganismListItem.GetByID(1739).ScientificName, "Sterna antillarum");
            birdersHandbookMap.Add(OrganismListItem.GetByID(8446).ScientificName, "Aphelocoma ultramarina");

            birdersHandbookMap.Add(OrganismListItem.GetByID(1370).ScientificName, "Porphyrio martinica");
            birdersHandbookMap.Add(OrganismListItem.GetByID(1763).ScientificName, "Synthliboramphus hypoleucus");
            birdersHandbookMap.Add(OrganismListItem.GetByID(2927).ScientificName, "Caprimulgus carolinensis");
            birdersHandbookMap.Add(OrganismListItem.GetByID(2934).ScientificName, "Caprimulgus ridgwayi");
            birdersHandbookMap.Add(OrganismListItem.GetByID(2935).ScientificName, "Caprimulgus vociferus");
            birdersHandbookMap.Add(OrganismListItem.GetByID(3424).ScientificName, "Stellula calliope");
            birdersHandbookMap.Add(OrganismListItem.GetByID(8799).ScientificName, "Amphispiza belli");
            birdersHandbookMap.Add(OrganismListItem.GetByID(9655).ScientificName, "Carpodacus purpureus");
            birdersHandbookMap.Add(OrganismListItem.GetByID(9656).ScientificName, "Carpodacus cassinii");
            birdersHandbookMap.Add(OrganismListItem.GetByID(9657).ScientificName, "Carpodacus mexicanus");

			birdersHandbookMap.Add(OrganismListItem.GetByID(1219).ScientificName, "Grus canadensis");

			birdersHandbookMap.Add(OrganismListItem.GetByID(463).ScientificName, "Chen caerulescens");
			birdersHandbookMap.Add(OrganismListItem.GetByID(464).ScientificName, "Chen rossii");
			birdersHandbookMap.Add(OrganismListItem.GetByID(465).ScientificName, "Chen canagica");
			birdersHandbookMap.Add(OrganismListItem.GetByID(510).ScientificName, "Anas americana");
			birdersHandbookMap.Add(OrganismListItem.GetByID(514).ScientificName, "Anas strepera");
			birdersHandbookMap.Add(OrganismListItem.GetByID(551).ScientificName, "Anas discors");
			birdersHandbookMap.Add(OrganismListItem.GetByID(552).ScientificName, "Anas cyanoptera");
			birdersHandbookMap.Add(OrganismListItem.GetByID(556).ScientificName, "Anas clypeata");
			birdersHandbookMap.Add(OrganismListItem.GetByID(692).ScientificName, "Circus cyaneus");
			birdersHandbookMap.Add(OrganismListItem.GetByID(5945).ScientificName, "Lanius excubitor");

			birdersHandbookMap.Add(OrganismListItem.GetByID(4020).ScientificName, "Picoides arizonae");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8781).ScientificName, "Ammodramus leconteii");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8777).ScientificName, "Ammodramus nelsoni");
			birdersHandbookMap.Add(OrganismListItem.GetByID(8779).ScientificName, "Ammodramus caudacutus");
		}

		public EGuideForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public EGuide EGuide
		{
			get
			{
				return eGuide;
			}
		}

		public Collection Collection
		{
			get
			{
				return eGuide.Collection;
			}

			set
			{
				eGuide.Collection = value;
			}
		}

		public Language Language
		{
			get
			{
				return eGuide.Language;
			}

			set
			{
				eGuide.Language = value;
			}
		}

		public FilterCollection Filters
		{
			get
			{
				return eGuide.Filters;
			}

			set
			{
				eGuide.Filters = value;

				list = eGuide.GetOrganismList();
				RefreshOrganismList();

				// Make sure there is a valid organism selected.  Applying filters
				// could make the selected organism no longer available.
				if (organismComboBox.SelectedIndex == -1)
				{
					organismComboBox.SelectedIndex = 0;
				}

				// Set correct filter button image
				if (eGuide.Filters != null && eGuide.Filters.Count > 0)
				{
					filtersToolStripButton.Image = Properties.Resources.FilterOn;
				}
				else
				{
					filtersToolStripButton.Image = Properties.Resources.FilterOff;
				}

				OnFilterChanged(EventArgs.Empty);
			}
		}

		public int OrganismCount
		{
			get
			{
				int organismCount = 0;
				foreach (OrganismListItem organism in list)
				{
					if (!organism.IsAlias)
					{
						organismCount++;
					}
				}

				return organismCount;
			}
		}

		private string SpectrogramLocation
		{
			get
			{
				if (spectrogramLocation != ApplicationSettings.SpectrogramLocation)
				{
					spectrogramLocation = ApplicationSettings.SpectrogramLocation;
					if (!File.Exists(spectrogramLocation))
					{
						spectrogramLocation = null;
					}
				}

				return spectrogramLocation;
			}
		}

		public event EventHandler<EventArgs> FilterChanged
		{
			add
			{
				lock (eventLock)
				{
					filterChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					filterChanged -= value;
				}
			}
		}

		protected void OnFilterChanged(EventArgs e)
		{
			EventHandler<EventArgs> temp = filterChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!DesignMode)
			{
				eGuide.EGuideForm = this;

				displayComboBox.Items.AddRange(OrganismDisplayOptions.GetList());
				sortOrderComboBox.Items.AddRange(OrganismSortOrder.GetList());

				// Initializing the list after setting the index. This keeps the sorting
				// routine from running until after the initial settings have been
				// selected; the list will be generated once by RefreshOrganismList()
				// rather than twice due to the events being triggered.
				displayComboBox.SelectedItem = UserSettings.Instance.DisplayName;
				sortOrderComboBox.SelectedItem = UserSettings.Instance.SortOrder;

				FilterSettings filterSettings = UserSettings.Instance.FilterSettings;
				if (filterSettings.RestoreFilterAtStartup && filterSettings.CanRestore())
				{
					// Get previously selected bird.  Need to use this value because setting the filter causes
					// the organismID in the UserSettings to be updated.
					int organismID = UserSettings.Instance.OrganismID;

					this.Filters = filterSettings.FilterCollection;

					// Restore the previously selected bird
					if (organismID > 0)
					{
						SelectOrganism(organismID);
					}
					else
					{
						organismComboBox.SelectedIndex = 0;
					}
				}
				else
				{
					// Load the organism list
					list = eGuide.GetOrganismList();
					RefreshOrganismList();

					int organismID = UserSettings.Instance.OrganismID;
					if (organismID > 0)
					{
						SelectOrganism(organismID);
					}
					else
					{
						organismComboBox.SelectedIndex = 0;
					}
				}

				UserSettings.Instance.DisplayNameChanged += new EventHandler<EventArgs>(UserSettings_DisplayNameChanged);
				UserSettings.Instance.ShowAliasesChanged += new EventHandler<EventArgs>(UserSettings_ShowAliasesChanged);
				UserSettings.Instance.LanguageChanged += new EventHandler<LanguageChangedEventArgs>(UserSettings_LanguageChanged);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			UserSettings.Instance.DisplayNameChanged -= new EventHandler<EventArgs>(UserSettings_DisplayNameChanged);
			UserSettings.Instance.ShowAliasesChanged -= new EventHandler<EventArgs>(UserSettings_ShowAliasesChanged);
			UserSettings.Instance.LanguageChanged -= new EventHandler<LanguageChangedEventArgs>(UserSettings_LanguageChanged);
		}

		private void UserSettings_DisplayNameChanged(object sender, EventArgs e)
		{
			displayComboBox.SelectedItem = UserSettings.Instance.DisplayName;
		}

		private void UserSettings_ShowAliasesChanged(object sender, EventArgs e)
		{
			list = eGuide.GetOrganismList();
			RefreshOrganismList();
		}

		private void UserSettings_LanguageChanged(object sender, LanguageChangedEventArgs e)
		{
			this.Language = e.Language;
			list = eGuide.GetOrganismList();
			RefreshOrganismList();
			RefreshHTML();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			Cleanup();

			base.Dispose(disposing);
		}

		private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			bool retry;
			do
			{
				retry = false;

				try
				{
					e.Cancel = eGuide.OnLinkClick(e.Url.OriginalString);
				}
				catch (MediaNotFoundException)
				{
					if (MessageBox.Show(this, "Media (e.g. photos, sounds, videos, maps, etc.) cannot be located because the media DVD is not loaded into your DVD drive or the folders on your hard drive have been changed. Please correct and click Retry.", Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry)
					{
						retry = true;
					}
					else
					{
						e.Cancel = true;
					}
				}
			} while (retry);
		}

		private void organismComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				OrganismListItem organism = organismComboBox.SelectedItem as OrganismListItem;
				if (organism != null)
				{
					Text = organism.ToString();

					if (eGuide.OrganismID != organism.ID)
					{
						UserSettings.Instance.OrganismID = organism.ID;
						eGuide.OrganismID = organism.ID;

						RefreshNavigationButtons();
						RefreshHTML();
					}
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void organismComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			OrganismComboBox.KeyDownHandler(organismComboBox.ComboBox, e);
		}

		private void organismComboBox_LostFocus(object sender, EventArgs e)
		{
			if (organismComboBox.SelectedIndex == -1)
			{
				SelectOrganism(eGuide.OrganismID);
			}
		}

        void IEGuideForm.AddSighting(Sighting sighting)
        {
            SightingsEditForm form = new SightingsEditForm();
            form.Collection = eGuide.Collection;
            form.Language = eGuide.Language;
            form.Sighting = sighting;
            form.SightingSaved += new EventHandler<EventArgs>(sightingsEditForm_SightingSaved);
            form.ShowDialog();

            // Cleanup event handler after form is closed
            form.SightingSaved -= sightingsEditForm_SightingSaved;
        }

        void sightingsEditForm_SightingSaved(object sender, EventArgs e)
        {
            RefreshHTML();
        }

        void IEGuideForm.ManageSightings(Organism organism)
        {
            SightingsForm form = new SightingsForm();
            form.Collection = eGuide.Collection;
            form.Language = eGuide.Language;
            form.Organism = organism;
            form.SightingsChanged += new EventHandler<EventArgs>(sightingsForm_SightingsChanged);
            form.ShowDialog();

            // Cleanup event handler after form is closed
            form.SightingsChanged -= sightingsForm_SightingsChanged;
        }

        void sightingsForm_SightingsChanged(object sender, EventArgs e)
        {
            RefreshHTML();
        }

		void IShowsWebBrowser.OpenBrowser(string url)
		{
			Utility.ShowWebBrowser(url);
		}

		void IEGuideForm.OpenSpectrogram(string path)
		{
			if (this.SpectrogramLocation != null)
			{
				// Make sure path is enclosed in quotes to handle case where the path contains spaces
				path = string.Format("\"{0}\"", path);

				ProcessStartInfo startInfo = new ProcessStartInfo(this.SpectrogramLocation, path);
				startInfo.WorkingDirectory = Path.GetDirectoryName(this.SpectrogramLocation);

				Process process = new Process();
				process.StartInfo = startInfo;
				process.Start();
			}
		}

		void IEGuideForm.PlayVideo(string organismName, IMedia video)
		{
			Utility.PlayVideo(organismName, video);
		}

		void IEGuideForm.Pronounce(string actualPhrase, string speakPhrase)
		{
			try
			{
				Point point = this.DesktopLocation;
				Petey.Instance.MoveTo((short)point.X, (short)point.Y);

				Petey.Instance.Show();
				StringBuilder phrase = new StringBuilder("\\Map=\"");
				phrase.Append(speakPhrase);
				phrase.Append("\"=\"");
				phrase.Append(actualPhrase);
				phrase.Append("\"\\");
				Petey.Instance.Speak(phrase.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
		}

		void IEGuideForm.ShowMap(string caption, IMedia map)
		{
			Bitmap image = Utility.GenerateBitmapWithCopyright(map, "Arial", 6.5f, System.Drawing.Color.Gray);

			MapForm form = new MapForm();
			form.Text = caption;
			form.Image = image;
			form.MapType = map.Type;
			form.ShowDialog();
		}

		void IEGuideForm.ShowBirdersHandbook(string scientificName)
		{
			if (string.IsNullOrEmpty(scientificName))
			{
				Help.ShowHelp(this, "The Birder's Handbook.chm", HelpNavigator.Index);
			}
			else
			{
				// Use old scientific name to maintain compatibility with Birder's Handbook
				if (birdersHandbookMap.ContainsKey(scientificName))
				{
					scientificName = birdersHandbookMap[scientificName];
				}
				Help.ShowHelp(this, "The Birder's Handbook.chm", HelpNavigator.KeywordIndex, scientificName);
			}
		}

		void IEGuideForm.ShowNarrative(string caption, string narrative)
		{
			NarrativeForm form = new NarrativeForm();
			form.Text = caption;
			form.Narrative = narrative;
			form.ShowDialog();
		}

		void IEGuideForm.ShowNotes(string notes)
		{

			CommentsForm form = new CommentsForm();
			form.Comments = notes;
			if (form.ShowDialog() == DialogResult.OK)
			{
				eGuide.SaveNotes(form.Comments);
				RefreshHTML();
			}

/*
			NotesForm form = new NotesForm();
			form.Notes = notes;
			if (form.ShowDialog() == DialogResult.OK)
			{
				eGuide.SaveNotes(form.Notes);
				RefreshHTML();
			}
*/
		}

		void IEGuideForm.ManageMedia(Organism organism)
		{
			MyMediaForm form = new MyMediaForm();
			form.Organism = organism;
			form.ShowDialog();
			if (form.MediaChanged)
			{
				RefreshHTML(true);
			}
		}

		void IEGuideForm.ShowSibleysBirdsOfTheWorld(string scientificName)
		{
			// Not supported
		}

		void IImageGenerator.GenerateImage(string source, int width, int height, string destination)
		{
			Utility.GenerateImage(source, width, height, destination);
		}

		void IPlaysSound.PlaySound(string path, bool loop)
		{
			Utility.ShowSoundForm(path, loop);
		}

		bool IEGuideForm.SpectrogramSupported
		{
			get
			{
				return this.SpectrogramLocation != null;
			}
		}

		public void ShowBird(int organismID)
		{
			int count = organismComboBox.Items.Count;
			for (int i = 0; i < count; i++)
			{
				OrganismListItem item = organismComboBox.Items[i] as OrganismListItem;
				if (item.ID == organismID)
				{
					organismComboBox.SelectedIndex = i;
					ViewBird();
					break;
				}
			}
		}

		public void ShowNewBird(Collection collection, int organismID)
		{
			((IShowsBird)this.ParentForm).ShowNewBird(collection, organismID);
		}

		void IShowsBird.SetImagePreference(ImagePreferenceType imagePreference)
		{
			this.imagePreference = imagePreference;
			RefreshHTML();
		}

		void IShowsPhotos.ShowPhotos(string organismName, IMedia[] photos, IMedia[] sounds, int initialPhotoIndex)
		{
			Utility.ShowPhotos(organismName, photos, sounds, initialPhotoIndex);
		}

		private void Cleanup()
		{
			if (htmlFilename != null)
			{
				try
				{
					File.Delete(htmlFilename);
				}
				catch
				{
					// If error occurs here, just ignore it since the temp folder
					// will be cleared out the next time the application is run.
				}
			}
		}

		internal void RefreshHTML()
		{
			RefreshHTML(false);
		}

		internal void RefreshHTML(bool retrieveThing)
		{
			Cleanup();

			if (retrieveThing)
			{
				eGuide.RefreshOrganism();
			}

			bool retry;
			do
			{
				retry = false;

				try
				{
					Cursor = Cursors.WaitCursor;

					if (viewSimilarToolStripMenuItem.Checked)
					{
						htmlFilename = eGuide.GenerateViewSimilarHTML(imagePreference);
					}
					else if (viewRelatedToolStripMenuItem.Checked)
					{
						htmlFilename = eGuide.GenerateViewRelatedHTML(imagePreference);
					}
					else
					{
						htmlFilename = eGuide.GenerateHTML();
					}
					webBrowser.Navigate(htmlFilename);
				}
				catch (MediaNotFoundException)
				{
					if (MessageBox.Show(this, "Media (e.g. photos, sounds, videos, maps, etc.) cannot be located because the media DVD is not loaded into your DVD drive or the folders on your hard drive have been changed. Please correct and click Retry.", Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry)
					{
						retry = true;
					}
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			} while (retry);
		}

		private void displayComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				UserSettings.Instance.DisplayName = displayComboBox.SelectedItem as OrganismDisplayOptions;

				// Added list != null condition to prevent unnecessary loading of
				// the organism list when loading the form and aliases are shown
				if (list != null && UserSettings.Instance.ShowAliases)
				{
					list = eGuide.GetOrganismList();
				}
				RefreshOrganismList();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void sortOrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				UserSettings.Instance.SortOrder = sortOrderComboBox.SelectedItem as OrganismSortOrder;

				RefreshOrganismList();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void zoomToolStripButton_Click(object sender, EventArgs e)
		{
			Zoom();
		}

		private void compareToolStripButton_Click(object sender, EventArgs e)
		{
			Compare();
		}

		private void printToolStripButton_Click(object sender, EventArgs e)
		{
			webBrowser.Print();
		}

		private void viewBirdToolStripButton_Click(object sender, EventArgs e)
		{
			ViewBird();
		}

		private void viewSimilarToolStripButton_Click(object sender, EventArgs e)
		{
			ViewSimilarSpecies();
		}

		private void viewRelatedToolStripButton_Click(object sender, EventArgs e)
		{
			ViewRelatedSpecies();
		}

		private void RefreshOrganismList()
		{
			if (list != null)
			{
				OrganismComboBox.FillOrganismComboBox(organismComboBox.ComboBox, list);
			}
		}

		private void viewBirdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewBird();
		}

		private void viewSimilarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewSimilarSpecies();
		}

		private void viewRelatedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewRelatedSpecies();
		}

		private void compareToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Compare();
		}

		private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Zoom();
		}

		private void Compare()
		{
			CompareForm form = new CompareForm();
			form.CollectionID = eGuide.Collection.ID;
			form.LanguageID = eGuide.Language.ID;
			form.SelectedLeftOrganismID = eGuide.OrganismID;
			form.SelectedRightOrganismID = eGuide.OrganismID;
			form.ViewEFieldGuide += new ViewEFieldGuideEventHandler(form_ViewEFieldGuide);
			form.ShowDialog();
		}

		void form_ViewEFieldGuide(object sender, ViewEFieldGuideEventArgs e)
		{
			ShowNewBird(this.Collection, e.OrganismID);
		}

		private void Zoom()
		{
			eGuide.ShowPhotos();
		}

		private void RefreshNavigationButtons()
		{
			firstBirdToolStripButton.Enabled = organismComboBox.Items.Count > 0;
			previousBirdToolStripButton.Enabled = organismComboBox.SelectedIndex != 0;
			nextBirdToolStripButton.Enabled = organismComboBox.SelectedIndex != organismComboBox.Items.Count - 1;
			lastBirdToolStripButton.Enabled = organismComboBox.Items.Count > 0;
		}

		private void firstBirdToolStripButton_Click(object sender, EventArgs e)
		{
			organismComboBox.SelectedIndex = 0;
		}

		private void previousBirdToolStripButton_Click(object sender, EventArgs e)
		{
			organismComboBox.SelectedIndex--;
		}

		private void nextBirdToolStripButton_Click(object sender, EventArgs e)
		{
			organismComboBox.SelectedIndex++;
		}

		private void lastBirdToolStripButton_Click(object sender, EventArgs e)
		{
			organismComboBox.SelectedIndex = organismComboBox.Items.Count - 1;
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HtmlDocument doc = webBrowser.Document;
			doc.ExecCommand("Print", true, null);
		}

		private void ShowBirdersHandbook()
		{
			eGuide.ShowBirdersHandbook();
		}

		private void moreInfoToolStripButton_Click(object sender, EventArgs e)
		{
			ShowBirdersHandbook();
		}

		private void theBirdersHandbookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowBirdersHandbook();
		}

		private void ViewBird()
		{
			if (!viewBirdToolStripMenuItem.Checked)
			{
				Cursor = Cursors.WaitCursor;

				try
				{
					viewBirdToolStripMenuItem.Checked = true;
					viewBirdToolStripButton.Checked = true;
					viewSimilarToolStripMenuItem.Checked = false;
					viewSimilarToolStripButton.Checked = false;
					viewRelatedToolStripMenuItem.Checked = false;
					viewRelatedToolStripButton.Checked = false;

					// Reset image preference to primary
					imagePreference = ImagePreferenceType.Primary;

					RefreshHTML();
					helpProvider.SetHelpKeyword(this, ViewBirdHelpTopicId);
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void ViewSimilarSpecies()
		{
			if (!viewSimilarToolStripButton.Checked)
			{
				Cursor = Cursors.WaitCursor;

				try
				{
					viewBirdToolStripMenuItem.Checked = false;
					viewBirdToolStripButton.Checked = false;
					viewSimilarToolStripMenuItem.Checked = true;
					viewSimilarToolStripButton.Checked = true;
					viewRelatedToolStripMenuItem.Checked = false;
					viewRelatedToolStripButton.Checked = false;

					// Reset image preference to primary
					imagePreference = ImagePreferenceType.Primary;

					RefreshHTML();
					helpProvider.SetHelpKeyword(this, ViewSimilarHelpTopicId);
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void ViewRelatedSpecies()
		{
			if (!viewRelatedToolStripMenuItem.Checked)
			{
				Cursor = Cursors.WaitCursor;

				try
				{
					viewBirdToolStripMenuItem.Checked = false;
					viewBirdToolStripButton.Checked = false;
					viewSimilarToolStripMenuItem.Checked = false;
					viewSimilarToolStripButton.Checked = false;
					viewRelatedToolStripMenuItem.Checked = true;
					viewRelatedToolStripButton.Checked = true;

					// Reset image preference to primary
					imagePreference = ImagePreferenceType.Primary;

					RefreshHTML();
					helpProvider.SetHelpKeyword(this, ViewRelatedHelpTopicId);
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void SelectOrganism(int organismID)
		{
			int selectedIndex = -1;

			int count = organismComboBox.Items.Count;
			for (int i = 0; i < count; i++)
			{
				OrganismListItem item = organismComboBox.Items[i] as OrganismListItem;
				if (item.ID == organismID)
				{
					selectedIndex = i;
					break;
				}
			}

			if (selectedIndex >= 0)
			{
				organismComboBox.SelectedIndex = selectedIndex;
			}
			else if(organismComboBox.Items.Count > 0)
			{
				organismComboBox.SelectedIndex = 0;
			}
		}

		private void filterMenuStripItem_Click(object sender, EventArgs e)
		{
			UncheckMenuItems(filtersToolStripMenuItem.DropDownItems);

			ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
			menuItem.Checked = true;
			ToolStripMenuItem parentMenuItem = menuItem;
			while ((parentMenuItem = parentMenuItem.OwnerItem as ToolStripMenuItem) != null)
			{
				parentMenuItem.Checked = true;
			}
		}

		private void UncheckMenuItems(ToolStripItemCollection menuItems)
		{
			foreach (ToolStripItem item in menuItems)
			{
				ToolStripMenuItem menuItem = item as ToolStripMenuItem;
				if (menuItem != null)
				{
					menuItem.Checked = false;
					UncheckMenuItems(menuItem.DropDownItems);
				}
			}
		}

		private void ShowFiltersForm()
		{
			Application.DoEvents();

			FilterForm form = new FilterForm();
			form.CollectionID = Collection.ID;
			form.SelectedFilters = Filters;
			if (form.ShowDialog() == DialogResult.OK)
			{
				Filters = form.SelectedFilters;
			}
		}

		private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFiltersForm();
		}

		private void filtersToolStripButton_Click(object sender, EventArgs e)
		{
			ShowFiltersForm();
		}

		private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
            if (e.KeyCode == Keys.F1)
            {
                string topicId;
                if (viewSimilarToolStripMenuItem.Checked)
                {
                    topicId = ViewSimilarHelpTopicId;
                }
                else if (viewRelatedToolStripMenuItem.Checked)
                {
                    topicId = ViewRelatedHelpTopicId;
                }
                else
                {
                    topicId = ViewBirdHelpTopicId;
                }
                Help.ShowHelp(this, helpProvider.HelpNamespace, HelpNavigator.TopicId, topicId);
            }
		}
	}
}
