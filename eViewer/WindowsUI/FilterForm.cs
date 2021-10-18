using System;
using System.Windows.Forms;
using Thayer.Birding.Filtering;

namespace Thayer.Birding.UI.Windows
{
	public partial class FilterForm : BaseForm
	{
		private int collectionID = 0;
		private FilterCollection selectedFilters = null;

		public FilterForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public int CollectionID
		{
			get
			{
				return collectionID;
			}

			set
			{
				collectionID = value;
			}
		}

		public FilterCollection SelectedFilters
		{
			get
			{
				return selectedFilters;
			}

			set
			{
				selectedFilters = value;

				if (selectedFilters == null)
				{
					selectedFilters = new FilterCollection();
				}

				this.FilterType = this.SelectedFilters.FilterType;
				if (selectedFilters.CommonOnly)
				{
					commonBirdsRadioButton.Checked = true;
				}
				else
				{
					allBirdsRadioButton.Checked = true;
				}

				if (selectedFilters.Count > 0)
				{
					if (selectedFilters.FilterType == FilterCollection.FilterTypes.CustomList)
					{
						foreach (ListViewItem item in filterListView.Items)
						{
							IFilter filter = item.Tag as IFilter;
							if (selectedFilters.Contains(filter))
							{
								item.Focused = true;
								item.Selected = true;
							}
						}
					}
					else
					{
						foreach (ListViewItem item in filterListView.Items)
						{
							IFilter filter = item.Tag as IFilter;
							if (selectedFilters.Contains(filter))
							{
								item.Checked = true;
							}
						}
					}
				}
			}
		}

		private FilterCollection.FilterTypes FilterType
		{
			get
			{
				FilterCollection.FilterTypes filterType = FilterCollection.FilterTypes.None;

				if (noFilterRadioButton.Checked)
				{
					filterType = FilterCollection.FilterTypes.None;
				}
				else if(stateRadioButton.Checked)
				{
					filterType = FilterCollection.FilterTypes.State;
				}
				else if (provinceRadioButton.Checked)
				{
					filterType = FilterCollection.FilterTypes.Province;
				}
				else if (regionRadioButton.Checked)
				{
					filterType = FilterCollection.FilterTypes.Region;
				}
				else if (familyRadioButton.Checked)
				{
					filterType = FilterCollection.FilterTypes.Family;
				}
				else if (customListRadioButton.Checked)
				{
					filterType = FilterCollection.FilterTypes.CustomList;
				}

				return filterType;
			}

			set
			{
				switch (value)
				{
					case FilterCollection.FilterTypes.None:
						noFilterRadioButton.Checked = true;
						break;
					case FilterCollection.FilterTypes.State:
						stateRadioButton.Checked = true;
						break;
					case FilterCollection.FilterTypes.Province:
						provinceRadioButton.Checked = true;
						break;
					case FilterCollection.FilterTypes.Region:
						regionRadioButton.Checked = true;
						break;
					case FilterCollection.FilterTypes.Family:
						familyRadioButton.Checked = true;
						break;
					case FilterCollection.FilterTypes.CustomList:
						customListRadioButton.Checked = true;
						break;
					default:
						noFilterRadioButton.Checked = true;
						break;
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Set status of filters based on the collection
			bool enableGeographicalFilters = this.CollectionID == Collection.GuideToBirdsOfNorthAmerica ? true : false;
			stateRadioButton.Enabled = enableGeographicalFilters;
			provinceRadioButton.Enabled = enableGeographicalFilters;
			regionRadioButton.Enabled = enableGeographicalFilters;

			restoreFilterAtStartupCheckBox.Checked = UserSettings.Instance.FilterSettings.RestoreFilterAtStartup;

			// Make sure first checked item (if any) is visible
			foreach (ListViewItem item in filterListView.Items)
			{
				if (item.Checked)
				{
					item.EnsureVisible();
					break;
				}
			}
		}

		private void SetDataSource(FilterCollection dataSource)
		{
			if (dataSource == null)
			{
				dataSource = new FilterCollection();
			}

			filterListView.BeginUpdate();
			filterListView.Items.Clear();
			foreach (IFilter filter in dataSource)
			{
				ListViewItem item = new ListViewItem(filter.DisplayName);
				item.Tag = filter;

				filterListView.Items.Add(item);
			}

			filterListView.EndUpdate();
		}

		private void noFilterRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (noFilterRadioButton.Checked)
			{
				filterListView.Visible = false;
				filterOptionsGroupBox.Visible = false;
				SetDataSource(null);
			}
		}

		private void stateRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (stateRadioButton.Checked)
			{
				filterListView.Visible = true;
				filterListView.CheckBoxes = true;
				filterOptionsGroupBox.Visible = true;
				SetDataSource(Filters.Instance.UnitedStatesFilters);
			}
		}

		private void provinceRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (provinceRadioButton.Checked)
			{
				filterListView.Visible = true;
				filterListView.CheckBoxes = true;
				filterOptionsGroupBox.Visible = true;
				SetDataSource(Filters.Instance.CanadaFilters);
			}
		}

		private void regionRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (regionRadioButton.Checked)
			{
				filterListView.Visible = true;
				filterListView.CheckBoxes = true;
				filterOptionsGroupBox.Visible = true;
				SetDataSource(Filters.Instance.RegionFilters);
			}
		}

		private void familyRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (familyRadioButton.Checked)
			{
				filterListView.Visible = true;
				filterListView.CheckBoxes = true;
				filterOptionsGroupBox.Visible = false;
				SetDataSource(Filters.Instance.FamilyFilters);
			}
		}

		private void customListRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (customListRadioButton.Checked)
			{
				filterListView.Visible = true;
				filterListView.CheckBoxes = false;
				filterListView.MultiSelect = false;
				filterOptionsGroupBox.Visible = false;
				SetDataSource(Filters.Instance.GetCustomListFilters(collectionID));
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			selectedFilters = new FilterCollection();

			// Set the filter type based on user's selection
			selectedFilters.FilterType = this.FilterType;

			if (customListRadioButton.Checked)
			{
				// Get selected custom list (only one custom list selection is allowed)
				if (filterListView.SelectedItems.Count > 0)
				{
					IFilter selectedFilter = filterListView.SelectedItems[0].Tag as IFilter;
					selectedFilters.Add(selectedFilter);
				}
				else
				{
					MessageBox.Show("Please select a custom list.", "Filters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			else
			{
				// Set CommonOnly flag
				if (stateRadioButton.Checked || provinceRadioButton.Checked || regionRadioButton.Checked)
				{
					selectedFilters.CommonOnly = commonBirdsRadioButton.Checked;
				}

				// Get selected filters
				foreach (ListViewItem item in filterListView.Items)
				{
					if (item.Checked)
					{
						selectedFilters.Add(item.Tag as IFilter);
					}
				}
			}

			// Update the filter settings
			FilterSettings filterSettings = UserSettings.Instance.FilterSettings;
			filterSettings.RestoreFilterAtStartup = restoreFilterAtStartupCheckBox.Checked;
			filterSettings.FilterCollection = selectedFilters;
			UserSettings.Instance.FilterSettings = filterSettings;

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}