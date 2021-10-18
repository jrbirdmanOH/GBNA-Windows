namespace Thayer.Birding
{
	public class ThayerEncryptedData
	{
		private bool firstTimeRun;

		public ThayerEncryptedData()
		{
		}

		public bool FirstTimeRun
		{
			get
			{
				return firstTimeRun;
			}

			set
			{
				firstTimeRun = value;
			}
		}
	}
}
