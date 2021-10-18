namespace Thayer.Birding
{
	public interface IDatabaseUpdater
	{
		void UpgradeFromPreviousVersion(string fileName);
	}
}
