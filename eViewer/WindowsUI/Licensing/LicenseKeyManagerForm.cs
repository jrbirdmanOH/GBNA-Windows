using System;
using System.Windows.Forms;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.UI.Windows.Licensing
{
	public partial class LicenseKeyManagerForm : Form
	{
		public LicenseKeyManagerForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			foreach (ThayerLicense license in ThayerLicenseManager.Instance.Licenses)
			{
				AddLicense(license);
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void addLicenseKeyButton_Click(object sender, EventArgs e)
		{
			LicenseKeyForm form = new LicenseKeyForm();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				ThayerLicense license = form.License;
				if (license != null)
				{
					try
					{
						ThayerLicenseManager.Instance.AddLicense(ref license, new ProductSelector());
						AddLicense(license);
					}
					catch (ThayerLicenseException tle)
					{
						MessageBox.Show(tle.Message, "License Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		private void AddLicense(ThayerLicense license)
		{
			ListViewItem item = new ListViewItem(license.Product.Collection.Name);
			item.SubItems.Add(license.LicenseKey);
			item.Tag = license;

			licenseListView.Items.Add(item);
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to delete the selected license key(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				foreach (ListViewItem item in licenseListView.SelectedItems)
				{
					ThayerLicense license = item.Tag as ThayerLicense;
					ThayerLicenseManager.Instance.RemoveLicense(license);

					item.Remove();
				}
			}
		}

		private void licenseListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			deleteButton.Enabled = licenseListView.SelectedItems.Count > 0;
		}
	}
}