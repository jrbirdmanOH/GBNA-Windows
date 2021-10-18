using System;
using System.Threading;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class SplashForm : Form
	{
		private string statusInfo = string.Empty;

		private SplashForm()
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

			// Parse product version to get major and minor values only.
			string[] parsedProductVersion = Application.ProductVersion.Split(new string[] { "." }, StringSplitOptions.None);
			infoLabel.Text = string.Format("Version {0}.{1}", parsedProductVersion[0], parsedProductVersion[1]);
		}

		public string StatusInfo
		{
			get
			{
				return statusLabel.Text;
			}

			set
			{
				statusLabel.Text = value != null ? value : string.Empty;
			}
		}
	}
}