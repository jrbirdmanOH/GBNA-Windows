using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.Filtering;
using CrystalDecisions.CrystalReports.Engine;

namespace Thayer.Birding.UI.Windows
{
	public partial class SightingsReportsForm : BaseForm, IShowsWebBrowser
	{
		private bool doneLoading = false;
		IList<SightingsReportItemData> sightingsReportDataSource = null;
		IList<LifeListReportItemData> lifeListReportDataSource = null;
		bool sightingsReportDataSourceDirty = true;
		bool lifeListReportDataSourceDirty = true;
		bool needToRefreshReport = true;

		public SightingsReportsForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private IList<SightingsReportItemData> SightingsReportDataSource
		{
			get
			{
				if (sightingsReportDataSource == null || sightingsReportDataSourceDirty)
				{
					sightingsReportDataSource = SightingsReportItemData.GetFilteredList(this.SightingsReportFilter, this.SightingsReportSortColumn);
				}

				return sightingsReportDataSource;
			}
		}

		private IList<LifeListReportItemData> LifeListReportDataSource
		{
			get
			{
				if (lifeListReportDataSource == null || lifeListReportDataSourceDirty)
				{
					lifeListReportDataSource = LifeListReportItemData.GetFilteredList(this.LifeListReportFilter, this.LifeListReportSortColumn);
				}

				return lifeListReportDataSource;
			}
		}

		private bool SightingsReportDataSourceDirty
		{
			get
			{
				return sightingsReportDataSourceDirty;
			}

			set
			{
				sightingsReportDataSourceDirty = value;
				if (sightingsReportDataSourceDirty)
				{
					NeedToRefreshReport = true;
				}
			}
		}

		private bool LifeListReportDataSourceDirty
		{
			get
			{
				return lifeListReportDataSourceDirty;
			}

			set
			{
				lifeListReportDataSourceDirty = value;
				if (lifeListReportDataSourceDirty)
				{
					NeedToRefreshReport = true;
				}
			}
		}

		private bool NeedToRefreshReport
		{
			get
			{
				return needToRefreshReport;
			}

			set
			{
				if (needToRefreshReport != value)
				{
					needToRefreshReport = value;
					UpdatePreviewReportStatus();
				}
			}
		}

		private int ObserverID
		{
			get
			{
				int observerID = -1;
				Observer observer = observerComboBox.SelectedItem as Observer;
				if (observer != null)
				{
					observerID = observer.ID;
				}

				return observerID;
			}
		}

		private bool EnforceStartDate
		{
			get
			{
				return enforceStartDateCheckBox.Checked;
			}

			set
			{
				enforceStartDateCheckBox.Checked = value;
			}
		}

		private bool EnforceEndDate
		{
			get
			{
				return enforceEndDateCheckBox.Checked;
			}

			set
			{
				enforceEndDateCheckBox.Checked = value;
			}
		}

		private SightingsReportFilter SightingsReportFilter
		{
			get
			{
				SightingsReportFilter filter = new SightingsReportFilter();
				filter.ObserverID = this.ObserverID;
				filter.LanguageID = UserSettings.Instance.Language.ID;

				if (this.EnforceStartDate)
				{
					filter.StartDate = startDateTimePicker.Value;
				}
				filter.EnforceStartDate = this.EnforceStartDate;

				if (this.EnforceEndDate)
				{
					DateTime endDate = endDateTimePicker.Value;
					TimeSpan endOfDay = new TimeSpan(23, 59, 59);
					endDate = endDate.Add(endOfDay);
					filter.EndDate = endDate;
				}
				filter.EnforceEndDate = this.EnforceEndDate;

				return filter;
			}
		}

		private SightingsReportItem.SortableColumn SightingsReportSortColumn
		{
			get
			{
				SightingsReportItem.SortableColumn sortColumn = SightingsReportItem.SortableColumn.TaxonomicOrder;

				SightingsReportOrderComboBoxItem item = sightingsOrderComboBox.SelectedItem as SightingsReportOrderComboBoxItem;
				if (item != null)
				{
					sortColumn = item.SortColumn;
				}

				return sortColumn;
			}
		}

		private LifeListReportFilter LifeListReportFilter
		{
			get
			{
				LifeListReportFilter filter = new LifeListReportFilter();
				filter.ObserverID = this.ObserverID;
				filter.LanguageID = UserSettings.Instance.Language.ID;

				return filter;
			}
		}

		private LifeListReportItem.SortableColumn LifeListReportSortColumn
		{
			get
			{
				LifeListReportItem.SortableColumn sortColumn = LifeListReportItem.SortableColumn.LifeListNumber;

				LifeListOrderComboBoxItem item = lifeListOrderComboBox.SelectedItem as LifeListOrderComboBoxItem;
				if (item != null)
				{
					sortColumn = item.SortColumn;
				}

				return sortColumn;
			}
		}

		private void SightingsReportsForm_Load(object sender, EventArgs e)
		{
			// Populate the combo boxes
			LoadObservers();
			LoadSightingSortOrders();
			LoadLifeListSortOrders();

			// Set the link for the Birder's Diary link label
			string webLinkCode = "DIARY";
			WebLink link = WebLink.GetByCode(webLinkCode);
			if (link != null)
			{
				birdersDiaryLinkLabel.Text = link.Caption;
				birdersDiaryLinkLabel.Links.Add(0, birdersDiaryLinkLabel.Text.Length, webLinkCode);
			}
			else
			{
				birdersDiaryLinkLabel.Enabled = false;
				birdersDiaryLinkLabel.Visible = false;
			}

			// Set any default values
			SetDefaultValues();

			// Format the Crystal Reports viewer object
			FormatReportViewer();

			// Set flag indicating the form is done loading
			doneLoading = true;
		}

		private void FormatReportViewer()
		{
			crystalReportViewer.EnableDrillDown = false;

			foreach (Control control in crystalReportViewer.Controls)
			{
				if (control is System.Windows.Forms.ToolStrip)
				{
					// Hide the Business Objects image
					ToolStrip toolStrip = (ToolStrip)control;
					if (toolStrip.Items.Count == 15)
					{
						toolStrip.Items[14].Visible = false;
					}
				}

				if (control is CrystalDecisions.Windows.Forms.PageView)
				{
					// Hide the one and only tab
					if (control.Controls.Count > 0)
					{
						TabControl tab = (TabControl)((CrystalDecisions.Windows.Forms.PageView)control).Controls[0];
						tab.ItemSize = new System.Drawing.Size(0, 1);
						tab.SizeMode = TabSizeMode.Fixed;
						tab.Appearance = TabAppearance.Buttons;

						printButton.Enabled = true;
					}
					else
					{
						printButton.Enabled = false;
					}
				}
			}
		}

		private void LoadObservers()
		{
			List<Observer> observers = Observer.GetList();
			observerComboBox.Items.AddRange(observers.ToArray());
		}

		private void LoadSightingSortOrders()
		{
			sightingsOrderComboBox.Items.AddRange(SightingsReportOrderComboBoxItem.GetList().ToArray());
		}

		private void LoadLifeListSortOrders()
		{
			lifeListOrderComboBox.Items.AddRange(LifeListOrderComboBoxItem.GetList().ToArray());
		}

		private void SetDefaultValues()
		{
			sightingsReportRadioButton.Checked = true;
			noneRadioButton.Checked = true;

			if (observerComboBox.Items.Count > 0)
			{
				observerComboBox.SelectedIndex = 0;
			}

			foreach (SightingsReportOrderComboBoxItem item in sightingsOrderComboBox.Items)
			{
				if (item.SortColumn == SightingsReportItem.SortableColumn.TaxonomicOrder)
				{
					sightingsOrderComboBox.SelectedItem = item;
					break;
				}
			}

			foreach (LifeListOrderComboBoxItem item in lifeListOrderComboBox.Items)
			{
				if (item.SortColumn == LifeListReportItem.SortableColumn.LifeListNumber)
				{
					lifeListOrderComboBox.SelectedItem = item;
					break;
				}
			}

			// Initialize end date to today
			endDateTimePicker.Value = DateTime.Today;
			this.EnforceEndDate = true;

			// Initialize start date to 7 days (1 week) before today
			startDateTimePicker.Value = endDateTimePicker.Value.Subtract(new TimeSpan(7, 0, 0, 0));
			this.EnforceStartDate = true;
		}

		private void UpdateControlStatus()
		{
			groupByGroupBox.Enabled = sightingsReportRadioButton.Checked;
			sightingsOrderComboBox.Enabled = sightingsReportRadioButton.Checked;
			startDateTimePicker.Enabled = sightingsReportRadioButton.Checked;
			enforceStartDateCheckBox.Enabled = sightingsReportRadioButton.Checked;
			endDateTimePicker.Enabled = sightingsReportRadioButton.Checked;
			enforceEndDateCheckBox.Enabled = sightingsReportRadioButton.Checked;
			lifeListOrderComboBox.Enabled = lifeListReportRadioButton.Checked;
		}

		private void UpdatePreviewReportStatus()
		{
			previewReportButton.Enabled = NeedToRefreshReport;
		}

		private void LoadReport()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				if (doneLoading)
				{
					ReportDocument reportDocument = null;

					if (sightingsReportRadioButton.Checked)
					{
						string reportName = string.Empty;
						if (byFamilyRadioButton.Checked)
						{
							reportDocument = (ReportDocument)new SightingsGroupFamilyReport();
						}
						else if (byLocationRadioButton.Checked)
						{
							reportDocument = (ReportDocument)new SightingsGroupLocationReport();
						}
						else
						{
							reportDocument = (ReportDocument)new SightingsReport();
						}

						reportDocument.SetDataSource(this.SightingsReportDataSource);
						crystalReportViewer.ReportSource = reportDocument;
					}
					else if (lifeListReportRadioButton.Checked)
					{
						reportDocument = (ReportDocument)new LifeListReport();

						reportDocument.SetDataSource(this.LifeListReportDataSource);
						crystalReportViewer.ReportSource = reportDocument;
					}

					FormatReportViewer();

					SightingsReportDataSourceDirty = false;
					LifeListReportDataSourceDirty = false;
					NeedToRefreshReport = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void sightingsReportRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (sightingsReportRadioButton.Checked)
			{
				NeedToRefreshReport = true;
				UpdateControlStatus();
			}
		}

		private void lifeListReportRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (lifeListReportRadioButton.Checked)
			{
				NeedToRefreshReport = true;
				UpdateControlStatus();
			}
		}

		private void noneRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			NeedToRefreshReport = true;
		}

		private void byFamilyRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			NeedToRefreshReport = true;
		}

		private void byLocationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			NeedToRefreshReport = true;
		}

		private void sightingsOrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SightingsReportDataSourceDirty = true;
		}

		private void lifeListOrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LifeListReportDataSourceDirty = true;
		}

		private void observerComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SightingsReportDataSourceDirty = true;
			LifeListReportDataSourceDirty = true;
		}

		private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			SightingsReportDataSourceDirty = true;
			endDateTimePicker.MinDate = startDateTimePicker.Value;
		}

		private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			SightingsReportDataSourceDirty = true;
			startDateTimePicker.MaxDate = endDateTimePicker.Value;
		}

		private void previewReportButton_Click(object sender, EventArgs e)
		{
			LoadReport();
		}

		private void printButton_Click(object sender, EventArgs e)
		{
			if (this.NeedToRefreshReport)
			{
				LoadReport();
			}

			crystalReportViewer.PrintReport();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void enforceStartDateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SightingsReportDataSourceDirty = true;
		}

		private void enforceEndDateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SightingsReportDataSourceDirty = true;
		}

		private void birdersDiaryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string webLinkCode = e.Link.LinkData as string;
			WebLink link = WebLink.GetByCode(webLinkCode);
			if (link != null)
			{
				link.Navigate(this);
			}
			else
			{
				StringBuilder message = new StringBuilder("Web link with code \"");
				message.Append(webLinkCode);
				message.Append("\" cannot be found.");
				MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		void IShowsWebBrowser.OpenBrowser(string url)
		{
			Utility.ShowWebBrowser(url);
		}
	}
}