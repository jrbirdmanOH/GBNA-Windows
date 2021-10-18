using System;

namespace Thayer.Birding.Licensing
{
	public class LicenseChangedEventArgs : EventArgs
	{
		public enum LicenseChangeType { Added, Removed };

		private string licenseKey = string.Empty;
		private LicenseChangeType type = LicenseChangeType.Added;

		public LicenseChangedEventArgs(string licenseKey, LicenseChangeType type) : base()
		{
			this.licenseKey = licenseKey;
			this.type = type;
		}

		public string LicenseKey
		{
			get
			{
				return licenseKey;
			}
		}

		public LicenseChangeType Type
		{
			get
			{
				return type;
			}
		}
	}
}
