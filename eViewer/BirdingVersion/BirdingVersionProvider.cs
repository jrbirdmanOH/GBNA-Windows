using System;
using System.Configuration;
using Thayer.Birding.Updates;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Versioning
{
	public class BirdingVersionProvider : IVersionInfoProvider
	{
		private string applicationPath = null;

		public BirdingVersionProvider(string applicationPath)
		{
			this.applicationPath = applicationPath;
			BirdingAppSettings.ApplicationPath = applicationPath;
		}

		public string GetVersion(string fileName)
		{
			string version = null;

			if (fileName.EndsWith(BirdingAppSettings.DatabaseNameWithRelativePath) || fileName.EndsWith(BirdingAppSettings.CustomDatabaseNameWithRelativePath))
			{
				version = BirdingAppSettings.GetDatabaseVersion(fileName);
			}

			return version;
		}
	}
}
