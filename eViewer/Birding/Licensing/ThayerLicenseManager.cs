using System;

namespace Thayer.Birding.Licensing
{
	public class ThayerLicenseManager
	{
		private static ThayerLicenseManager instance = null;

		private readonly object eventLock = new object();
		private event EventHandler<LicenseChangedEventArgs> licenseChanged;

		protected ThayerLicenseManager()
		{
		}

		public static ThayerLicenseManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ThayerLicenseManager();
				}

				return instance;
			}
		}

		public ThayerLicenseFile LicenseFile
		{
			get
			{
				return ThayerLicenseFile.Instance;
			}
		}

		public ThayerLicenseCollection Licenses
		{
			get
			{
				return ThayerLicenseFile.Instance.Licenses;
			}
		}

		public event EventHandler<LicenseChangedEventArgs> LicenseChanged
		{
			add
			{
				lock (eventLock)
				{
					licenseChanged += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					licenseChanged -= value;
				}
			}
		}

		protected virtual void OnLicenseChanged(LicenseChangedEventArgs e)
		{
			EventHandler<LicenseChangedEventArgs> temp = licenseChanged;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		public void Validate(IProductSelector productSelector)
		{
			this.LicenseFile.Validate(productSelector);
		}

		public void AddLicense(ref ThayerLicense license, IProductSelector productSelector)
		{
			this.LicenseFile.AddLicense(ref license, productSelector);
			OnLicenseChanged(new LicenseChangedEventArgs(license.LicenseKey, LicenseChangedEventArgs.LicenseChangeType.Added));
		}

		public void RemoveLicense(ThayerLicense license)
		{
			this.LicenseFile.RemoveLicense(license);
			OnLicenseChanged(new LicenseChangedEventArgs(license.LicenseKey, LicenseChangedEventArgs.LicenseChangeType.Removed));
		}
	}
}
