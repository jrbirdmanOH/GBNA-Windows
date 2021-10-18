using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.UI.Windows.Quiz;

namespace Thayer.Birding.UI.Windows
{
	public partial class IdentificationForm : BaseForm, IIdentificationForm
	{
		private IdentificationWizard wizard = null;
		private Dictionary<Color, CheckBox> colors = null;
		private Dictionary<FieldMark, CheckBox> fieldMarks = null;
		private Dictionary<Habitat, CheckBox> habitats = null;
		private Dictionary<Size, CheckBox> sizes = null;
		private Dictionary<Sound, CheckBox> sounds = null;
		private bool isUpdating = false;
		private List<OrganismListItem> results = null;
		private IShowsBird showsBirdProvider = null;

		public IdentificationForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;

			wizard = new IdentificationWizard(this);
		}

		public Collection Collection
		{
			get
			{
				return wizard.Collection;
			}

			set
			{
				wizard.Collection = value;

				locationTreeView.CollectionID = value.ID;
				taxonomyTreeView.TaxonomyID = value.TaxonomyID;
			}
		}

		[Browsable(false)]
		public IShowsBird ShowsBirdProvider
		{
			get
			{
				return showsBirdProvider;
			}

			set
			{
				showsBirdProvider = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			UserSettings.Instance.DisplayNameChanged += new EventHandler<EventArgs>(UserSettings_DisplayNameChanged);
			UserSettings.Instance.SortOrderChanged += new EventHandler<EventArgs>(UserSettings_SortOrderChanged);

			colors = new Dictionary<Color, CheckBox>();
			colors[Color.White] = whiteCheckBox;
			colors[Color.Gray] = grayCheckBox;
			colors[Color.Black] = blackCheckBox;
			colors[Color.Brown] = brownCheckBox;
			colors[Color.Chestnut] = chestnutCheckBox;
			colors[Color.Rufous] = chestnutCheckBox;
			colors[Color.Red] = redCheckBox;
			colors[Color.Pink] = redCheckBox;
			colors[Color.Orange] = orangeCheckBox;
			colors[Color.Yellow] = yellowCheckBox;
			colors[Color.Buff] = yellowCheckBox;
			colors[Color.Green] = greenCheckBox;
			colors[Color.Olive] = greenCheckBox;
			colors[Color.Blue] = blueCheckBox;
			colors[Color.Indigo] = blueCheckBox;
			colors[Color.Purple] = purpleCheckBox;

			fieldMarks = new Dictionary<FieldMark, CheckBox>();
			fieldMarks[FieldMark.CrestTufts] = crestsTuftsCheckBox;
			fieldMarks[FieldMark.EyeRing] = eyeRingCheckBox;
			fieldMarks[FieldMark.WhiteOuterTailFeathers] = whiteOuterTailFeathersCheckBox;
			fieldMarks[FieldMark.WingBars] = wingBarsCheckBox;

			habitats = new Dictionary<Habitat, CheckBox>();
			habitats[Habitat.CitySuburbs] = citySuburbsCheckBox;
			habitats[Habitat.Desert] = desertCheckBox;
			habitats[Habitat.Feeders] = feedersCheckBox;
			habitats[Habitat.FieldsGrasslandsScrub] = fieldsGrasslandsScrubCheckBox;
			habitats[Habitat.LakesStreamsWetlands] = lakesStreamsWetlandsCheckBox;
			habitats[Habitat.MountainsCanyons] = mountainsCanyonsCheckBox;
			habitats[Habitat.OceanShore] = oceanShoreCheckBox;
			habitats[Habitat.OpenOcean] = openOceanCheckBox;
			habitats[Habitat.Tundra] = tundraCheckBox;
			habitats[Habitat.Woodlands] = woodlandsCheckBox;

			sizes = new Dictionary<Size, CheckBox>();
			sizes[Thayer.Birding.Size.Crow] = crowCheckBox;
			sizes[Thayer.Birding.Size.Goose] = gooseCheckBox;
			sizes[Thayer.Birding.Size.LargerThanGoose] = largerThanGooseCheckBox;
			sizes[Thayer.Birding.Size.Pigeon] = pigeonCheckBox;
			sizes[Thayer.Birding.Size.Robin] = robinCheckBox;
			sizes[Thayer.Birding.Size.SmallerThanSparrow] = smallerThanSparrowCheckBox;
			sizes[Thayer.Birding.Size.Sparrow] = sparrowCheckBox;

			sounds = new Dictionary<Sound, CheckBox>();
			sounds[Sound.Buzzy] = buzzyCheckBox;
			sounds[Sound.Chatter] = chatterCheckBox;
			sounds[Sound.Chirp] = chirpCheckBox;
			sounds[Sound.Falling] = fallingCheckBox;
			sounds[Sound.Flat] = flatCheckBox;
			sounds[Sound.Honk] = honkCheckBox;
			sounds[Sound.Hoot] = hootCheckBox;
			sounds[Sound.Musical] = musicalCheckBox;
			sounds[Sound.Quack] = quackCheckBox;
			sounds[Sound.Rattle] = rattleCheckBox;
			sounds[Sound.Rising] = risingCheckBox;
			sounds[Sound.Scream] = screamCheckBox;
			sounds[Sound.SingSong] = singSongCheckBox;
			sounds[Sound.Squawk] = squawkCheckBox;
			sounds[Sound.Squeek] = squeekCheckBox;
			sounds[Sound.Trill] = trillCheckBox;
			sounds[Sound.Unusual] = unusualCheckBox;
			sounds[Sound.Whistle] = whistleCheckBox;

			// Set tooltip text for sound buttons
			toolTip.SetToolTip(buzzyButton, Sound.Buzzy.ToolTip);
			toolTip.SetToolTip(chatterButton, Sound.Chatter.ToolTip);
			toolTip.SetToolTip(chirpButton, Sound.Chirp.ToolTip);
			toolTip.SetToolTip(fallingButton, Sound.Falling.ToolTip);
			toolTip.SetToolTip(flatButton, Sound.Flat.ToolTip);
			toolTip.SetToolTip(honkButton, Sound.Honk.ToolTip);
			toolTip.SetToolTip(hootButton, Sound.Hoot.ToolTip);
			toolTip.SetToolTip(musicalButton, Sound.Musical.ToolTip);
			toolTip.SetToolTip(quackButton, Sound.Quack.ToolTip);
			toolTip.SetToolTip(rattleButton, Sound.Rattle.ToolTip);
			toolTip.SetToolTip(risingButton, Sound.Rising.ToolTip);
			toolTip.SetToolTip(screamButton, Sound.Scream.ToolTip);
			toolTip.SetToolTip(singSongButton, Sound.SingSong.ToolTip);
			toolTip.SetToolTip(squawkButton, Sound.Squawk.ToolTip);
			toolTip.SetToolTip(squeekButton, Sound.Squeek.ToolTip);
			toolTip.SetToolTip(trillButton, Sound.Trill.ToolTip);
			toolTip.SetToolTip(unusualButton, Sound.Unusual.ToolTip);
			toolTip.SetToolTip(whistleButton, Sound.Whistle.ToolTip);

			// Restore any previously selected locations
			List<int> locations = UserSettings.Instance.IDWizardSelectedLocations;
			List<Location> selectedLocations = new List<Location>();
			foreach (int locationID in locations)
			{
				Location location = new Location();
				location.ID = locationID;
				selectedLocations.Add(location);
			}
			locationTreeView.SelectedLocations = selectedLocations.ToArray();

			Search();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			UserSettings.Instance.DisplayNameChanged -= UserSettings_DisplayNameChanged;
			UserSettings.Instance.SortOrderChanged -= UserSettings_SortOrderChanged;

			// Save the selected locations for the ID Wizard
			List<int> selectedLocations = new List<int>();
			Location[] locations = ((IIdentificationForm)this).GetLocationsSelected();
			foreach (Location location in locations)
			{
				selectedLocations.Add(location.ID);
			}
			UserSettings.Instance.IDWizardSelectedLocations = selectedLocations;
		}

		private void UserSettings_DisplayNameChanged(object sender, EventArgs e)
		{
			UpdateResults(this.results, true);
		}

		private void UserSettings_SortOrderChanged(object sender, EventArgs e)
		{
			UpdateResults(this.results, true);
		}

		private void Search(object sender, TreeViewEventArgs e)
		{
			Search();
		}

		int[] IIdentificationForm.SelectedResults
		{
			get
			{
				List<int> ids = new List<int>();

				foreach (ListViewItem item in resultsListView.Items)
				{
					if (item.Checked)
					{
						OrganismListItem thing = item.Tag as OrganismListItem;
						ids.Add(thing.ID);
					}
				}

				return ids.ToArray();
			}
		}

		bool IIdentificationForm.CommonOnly
		{
			get
			{
				return locationTreeView.ExcludeRareBirds;
			}
		}

		ITaxonomy[] IIdentificationForm.GetClassificationsSelected()
		{
			return taxonomyTreeView.SelectedClassifications;
		}

		Location[] IIdentificationForm.GetLocationsSelected()
		{
			return locationTreeView.SelectedLocations;
		}

		bool IIdentificationForm.IsPredominantColorSelected
		{
			get
			{
				return predominantColorRadioButton.Checked;
			}
		}

		bool IIdentificationForm.IsColorSelected(Color color)
		{
			CheckBox checkBox = colors[color];

			return checkBox.Checked;
		}

		bool IIdentificationForm.IsFieldMarkSelected(FieldMark fieldMark)
		{
			CheckBox checkBox = fieldMarks[fieldMark];

			return checkBox.Checked;
		}

		bool IIdentificationForm.IsHabitatSelected(Habitat habitat)
		{
			CheckBox checkBox = habitats[habitat];

			return checkBox.Checked;
		}

		bool IIdentificationForm.IsSizeSelected(Thayer.Birding.Size size)
		{
			CheckBox checkBox = sizes[size];

			return checkBox.Checked;
		}

		bool IIdentificationForm.IsSoundSelected(Sound sound)
		{
			CheckBox checkBox = sounds[sound];

			return checkBox.Checked;
		}

		void IIdentificationForm.OpenQuizWizard(CustomList customList)
		{
			QuizSettings quizSettings = UserSettings.Instance.QuizSettings;
			quizSettings.WizardStartupType = QuizSettings.WizardStartupTypes.CustomList;
			quizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.CustomList;
			quizSettings.QuizSource.CustomList.CustomListID = customList.ID;
			quizSettings.QuizLength = customList.Length;
			QuizLauncher.Instance.RunQuizWizard(quizSettings, this.Collection);
		}

		private void UpdateResultsColumnHeader()
		{
			resultsListView.Columns[0].Text = UserSettings.Instance.DisplayName.ToString();
		}

		private void UpdateResults(List<OrganismListItem> results)
		{
			UpdateResults(results, false);
		}

		private void UpdateResults(List<OrganismListItem> results, bool restoreSelected)
		{
			isUpdating = true;

			try
			{
				List<int> selectedOrganisms = null;
				if (restoreSelected)
				{
					selectedOrganisms = new List<int>(((IIdentificationForm)this).SelectedResults);
				}

				// Sort the results
				results.Sort();

				resultsListView.BeginUpdate();
				UpdateResultsColumnHeader();
				resultsTabPage.Text = "Results (" + results.Count + ")";
				resultsListView.Items.Clear();
				foreach (OrganismListItem organism in results)
				{
					ListViewItem item = new ListViewItem(organism.ToString());
					if (restoreSelected)
					{
						item.Checked = selectedOrganisms.Contains(organism.ID);
					}
					else
					{
						item.Checked = true;
					}
					item.Tag = organism;

					resultsListView.Items.Add(item);
				}

				resultsListView.EndUpdate();
			}
			finally
			{
				isUpdating = false;
				RefreshButtons();
			}
		}

		private void musicalButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Musical);
		}

		void IPlaysSound.PlaySound(string path, bool loop)
		{
			Utility.PlaySound(path);
		}

		private void CheckColorCheckBox(CheckBox checkBox)
		{
			if (!isUpdating)
			{
				isUpdating = true;

				if (checkBox.Checked && predominantColorRadioButton.Checked)
				{
					ClearColorCheckBoxes(checkBox);
				}

				isUpdating = false;
			}
		}

		private void ClearCheckBoxes(ICollection<CheckBox> checkBoxes, CheckBox exclude)
		{
			foreach (CheckBox checkBox in checkBoxes)
			{
				if (exclude == null || checkBox != exclude)
				{
					checkBox.Checked = false;
				}
			}
		}

		private void ClearSizeCheckBoxes()
		{
			ClearCheckBoxes(sizes.Values, null);
		}

		private void ClearHabitatCheckBoxes()
		{
			ClearCheckBoxes(habitats.Values, null);
		}

		private void ClearColorCheckBoxes()
		{
			ClearColorCheckBoxes(null);
		}

		private void ClearColorCheckBoxes(CheckBox exclude)
		{
			ClearCheckBoxes(colors.Values, exclude);
		}

		private void ClearFieldMarkCheckBoxes()
		{
			ClearCheckBoxes(fieldMarks.Values, null);
		}

		private void ClearSoundCheckBoxes()
		{
			ClearCheckBoxes(sounds.Values, null);
		}

		private void colorCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckColorCheckBox((CheckBox)sender);

			Search();
		}

		private void rufousLabel_Click(object sender, EventArgs e)
		{
			chestnutCheckBox.Checked = !chestnutCheckBox.Checked;
		}

		private void pinkLabel_Click(object sender, EventArgs e)
		{
			redCheckBox.Checked = !redCheckBox.Checked;
		}
		private void buffLabel_Click(object sender, EventArgs e)
		{
			yellowCheckBox.Checked = !yellowCheckBox.Checked;
		}

		private void oliveLabel_Click(object sender, EventArgs e)
		{
			greenCheckBox.Checked = !greenCheckBox.Checked;
		}

		private void indigoLabel_Click(object sender, EventArgs e)
		{
			blueCheckBox.Checked = !blueCheckBox.Checked;
		}

		private void Search(object sender, EventArgs e)
		{
			Search();
		}

		private void photoGalleryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowPhotoGallery();
		}

		private void ShowPhotoGallery()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				Application.DoEvents();

				List<int> organismIDs = new List<int>();

				int count = resultsListView.Items.Count;
				for (int i = 0; i < count; i++)
				{
					ListViewItem item = resultsListView.Items[i];
					if (item.Checked)
					{
						OrganismListItem organism = item.Tag as OrganismListItem;
						organismIDs.Add(organism.ID);
					}
				}

				PhotoGalleryForm form = new PhotoGalleryForm();
				form.OrganismIDs = organismIDs.ToArray();
				form.WindowState = FormWindowState.Maximized;
				form.Collection = this.Collection;
				form.ShowsBirdProvider = this.ShowsBirdProvider;
				form.Show();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void photoGalleryToolStripButton_Click(object sender, EventArgs e)
		{
			ShowPhotoGallery();
		}

		private void resultsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			RefreshButtons();
		}

		private void RefreshButtons()
		{
			if (!isUpdating)
			{
				bool enabled = false;
				foreach (ListViewItem item in resultsListView.Items)
				{
					if (item.Checked)
					{
						enabled = true;
						break;
					}
				}

				photoGalleryToolStripButton.Enabled = enabled;
				photoGalleryToolStripMenuItem.Enabled = enabled;
				saveAsCustomListToolStripButton.Enabled = enabled;
				saveAsCustomListToolStripMenuItem.Enabled = enabled;
				takeQuizOnResultsToolStripMenuItem.Enabled = enabled;
				takeQuizToolStripButton.Enabled = enabled;
				UpdateResultsListContextMenuItemStatus();
			}
		}

		private void clearSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClearSelectionsOnAllTabs();
		}

		private void clearAllTabsToolStripButton_Click(object sender, EventArgs e)
		{
			ClearSelectionsOnAllTabs();
		}

		private void ClearSelectionsOnAllTabs()
		{
			isUpdating = true;

			try
			{
				locationTreeView.ClearChecks();

				ClearSizeCheckBoxes();
				ClearHabitatCheckBoxes();
				ClearColorCheckBoxes();
				ClearFieldMarkCheckBoxes();

				taxonomyTreeView.ClearChecks();

				ClearSoundCheckBoxes();
			}
			finally
			{
				isUpdating = false;

				Search();
			}
		}

		private void predominantColorRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (predominantColorRadioButton.Checked)
			{
				List<CheckBox> checkedList = new List<CheckBox>();
				
				foreach (CheckBox checkBox in colors.Values)
				{
					if (checkBox.Checked && !checkedList.Contains(checkBox))
					{
						checkedList.Add(checkBox);
					}

					if (checkedList.Count > 1)
					{
						break;
					}
				}

				if (checkedList.Count > 1)
				{
					isUpdating = true;
					ClearColorCheckBoxes();
					isUpdating = false;
				}
			}

			Search();
		}

		private void clearTabSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			isUpdating = true;

			try
			{
				Application.DoEvents();

				TabPage tabPage = criteriaTabControl.SelectedTab;
				if (tabPage == locationTabPage)
				{
					locationTreeView.ClearChecks();
				}
				else if (tabPage == sizeTabPage)
				{
					ClearSizeCheckBoxes();
				}
				else if (tabPage == habitatTabPage)
				{
					ClearHabitatCheckBoxes();
				}
				else if (tabPage == colorTabPage)
				{
					ClearColorCheckBoxes();
				}
				else if (tabPage == fieldMarksTabPage)
				{
					ClearFieldMarkCheckBoxes();
				}
				else if (tabPage == groupTabPage)
				{
					taxonomyTreeView.ClearChecks();
				}
				else if (tabPage == soundTabPage)
				{
					ClearSoundCheckBoxes();
				}
			}
			finally
			{
				isUpdating = false;

				Search();
			}
		}

		private void selectAllResultsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectAllResults(true);
		}

		private void SelectAllResults(bool check)
		{
			Application.DoEvents();

			Cursor = Cursors.WaitCursor;
			resultsListView.BeginUpdate();

			try
			{
				foreach (ListViewItem item in resultsListView.Items)
				{
					item.Checked = check;
				}
			}
			finally
			{
				resultsListView.EndUpdate();

				Cursor = Cursors.Default;
			}
		}

		private void Search()
		{
			if (!isUpdating)
			{
				Cursor = Cursors.WaitCursor;

				try
				{
					this.results = wizard.Search();
					UpdateResults(this.results);

					string query = wizard.GetEnglishQuery();

					webBrowser1.DocumentText = query;
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void saveAsCustomListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveAsCustomList();
		}

		private void deselectAllResultsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectAllResults(false);
		}

		private void invertResultSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();

			Cursor = Cursors.WaitCursor;
			resultsListView.BeginUpdate();

			try
			{
				foreach (ListViewItem item in resultsListView.Items)
				{
					item.Checked = !item.Checked;
				}
			}
			finally
			{
				resultsListView.EndUpdate();

				Cursor = Cursors.Default;
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void oneOrMoreColorsRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			Search();
		}

		private void saveAsCustomListToolStripButton_Click(object sender, EventArgs e)
		{
			SaveAsCustomList();
		}

		private void SaveAsCustomList()
		{
			CustomList customList = new CustomList();
			customList.CollectionID = Collection.ID;
			customList.Length = resultsListView.Items.Count;

			CustomListEditForm form = new CustomListEditForm();
			form.CustomList = customList;
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Application.DoEvents();

				Cursor = Cursors.WaitCursor;

				try
				{
					wizard.SaveResultsInCustomList(customList);
					CustomListForm.RefreshForm();
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void takeQuizOnResultsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			wizard.RunQuiz();
		}

		private void takeQuizToolStripButton_Click(object sender, EventArgs e)
		{
			wizard.RunQuiz();
		}

		private void whistleButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Whistle);
		}

		private void trillButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Trill);
		}

		private void buzzyButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Buzzy);
		}

		private void chirpButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Chirp);
		}

		private void chatterButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Chatter);
		}

		private void screamButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Scream);
		}

		private void quackButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Quack);
		}

		private void squawkButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Squawk);
		}

		private void squeekButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Squeek);
		}

		private void honkButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Honk);
		}

		private void rattleButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Rattle);
		}

		private void hootButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Hoot);
		}

		private void unusualButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Unusual);
		}

		private void risingButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Rising);
		}

		private void flatButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Flat);
		}

		private void fallingButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.Falling);
		}

		private void singSongButton_Click(object sender, EventArgs e)
		{
			wizard.PlaySound(Sound.SingSong);
		}

		private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
		{
			// Needed for proper repainting of all controls in the form
			this.Refresh();
		}

		private void IdentificationForm_ResizeEnd(object sender, EventArgs e)
		{
			// Needed for proper repainting of all controls in the form
			this.Refresh();
		}

		private void viewEFieldGuideContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (int selectedIndex in resultsListView.SelectedIndices)
			{
				OrganismListItem organism = resultsListView.Items[selectedIndex].Tag as OrganismListItem;
				ViewEFieldGuide(organism.ID);
			}
		}

		private void compareSelectedResultsContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (resultsListView.SelectedIndices.Count == 2)
			{
				int selectedIndex1 = resultsListView.SelectedIndices[0];
				int selectedIndex2 = resultsListView.SelectedIndices[1];

				OrganismListItem organism1 = resultsListView.Items[selectedIndex1].Tag as OrganismListItem;
				OrganismListItem organism2 = resultsListView.Items[selectedIndex2].Tag as OrganismListItem;

				Compare(organism1.ID, organism2.ID);
			}
		}

		private void ViewEFieldGuide(int organismID)
		{
			if (this.ShowsBirdProvider != null && this.Collection != null)
			{
				this.ShowsBirdProvider.ShowNewBird(this.Collection, organismID);
			}
		}

		private void Compare(int organismID1, int organismID2)
		{
			CompareForm form = new CompareForm();
			form.CollectionID = this.Collection.ID;
			form.LanguageID = UserSettings.Instance.Language.ID;
			form.SelectedLeftOrganismID = organismID1;
			form.SelectedRightOrganismID = organismID2;
			form.ViewEFieldGuide += new ViewEFieldGuideEventHandler(form_ViewEFieldGuide);
			form.ShowDialog();
		}

		void form_ViewEFieldGuide(object sender, ViewEFieldGuideEventArgs e)
		{
			ViewEFieldGuide(e.OrganismID);
		}

		private void resultsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateResultsListContextMenuItemStatus();
		}

		private void UpdateResultsListContextMenuItemStatus()
		{
			UpdateViewEFieldGuideStatus();
			UpdateCompareSelectedStatus();
		}

		private void UpdateViewEFieldGuideStatus()
		{
			bool isResultSelected = resultsListView.SelectedIndices.Count > 0;
			viewEFieldGuideContextMenuToolStripMenuItem.Enabled = isResultSelected;
		}

		private void UpdateCompareSelectedStatus()
		{
			// Allow compare only if 2 organisms are selected
			compareSelectedResultsContextMenuToolStripMenuItem.Enabled = resultsListView.SelectedIndices.Count == 2;
		}
	}
}
