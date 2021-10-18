namespace Thayer.Birding.DataUpdates
{
	public class DataUpdate
	{
		private IBirdingApplication birdingApp;
		private ConfigFileUpdates configUpdates;
		private DatabaseUpdates databaseUpdates;

		public DataUpdate(IBirdingApplication birdingApp)
		{
			this.birdingApp = birdingApp;
			configUpdates = new ConfigFileUpdates(birdingApp);
			databaseUpdates = new DatabaseUpdates();
		}

		public void UpgradeFromPreviousVersion(string previousDatabase)
		{
			databaseUpdates.UpgradeFromPreviousVersion(previousDatabase);
		}

		public void CheckForUpdates()
		{
			configUpdates.Update();
			databaseUpdates.Update();
			databaseUpdates.UpdateCustom();
		}

		public void UpdateSpectrogramLocation()
		{
			configUpdates.Update();
		}
	}
}
