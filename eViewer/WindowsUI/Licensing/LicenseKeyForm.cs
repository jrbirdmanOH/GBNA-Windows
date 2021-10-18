using System;
using System.Windows.Forms;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.UI.Windows.Licensing
{
	public partial class LicenseKeyForm : Form
	{
		private ThayerLicense license = null;

		public LicenseKeyForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		public ThayerLicense License
		{
			get
			{
				return license;
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			try
			{
				license = new ThayerLicense(licenseKeyTextBox.Text);
				string reason;
				if (!license.IsValid(out reason, false))
				{
					MessageBox.Show(this, reason, "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (ThayerLicenseException tle)
			{
				MessageBox.Show(this, tle.Message, "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			license = null;
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}