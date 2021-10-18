using System.Data;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class MediaDirectory
	{
		private int id;
		private string primaryPath;

		internal MediaDirectory()
		{
		}

		public int ID
		{
			get
			{
				return id;
			}

			set
			{
				id = value;
			}
		}

		public string PrimaryPath
		{
			get
			{
				return primaryPath;
			}

			set
			{
				primaryPath = value;
			}
		}

		public void Save()
		{
			MediaDirectoryDM.Instance.Save(this);
		}

		public static MediaDirectory GetByID(int id)
		{
			return MediaDirectoryDM.Instance.GetByID(id);
		}
	}
}
