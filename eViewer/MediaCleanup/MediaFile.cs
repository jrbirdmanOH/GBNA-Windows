using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding;

namespace Thayer.MediaCleanup
{
	public class MediaFile
	{
		protected int mediaID = 0;
		protected string path = string.Empty;
		protected string absolutePath = string.Empty;
		protected string commonName = string.Empty;
		protected string type = string.Empty;
		protected int thingID = 0;

		public MediaFile()
		{
		}

		public int MediaID
		{
			get
			{
				return mediaID;
			}

			set
			{
				mediaID = value;
			}
		}

		public string Path
		{
			get
			{
				return path;
			}

			set
			{
				path = value;
			}
		}

		public string AbsolutePath
		{
			get
			{
				return System.IO.Path.Combine(ApplicationSettings.MediaPath, path);
			}
		}

		public string DirectoryName
		{
			get
			{
				return System.IO.Path.GetDirectoryName(AbsolutePath);
			}
		}

		public string CommonName
		{
			get
			{
				return commonName;
			}

			set
			{
				commonName = value;
			}
		}

		public string Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
			}
		}

		public int ThingID
		{
			get
			{
				return thingID;
			}

			set
			{
				thingID = value;
			}
		}

		public string FileName
		{
			get
			{
				return System.IO.Path.GetFileName(path);
			}
		}

		public string FileNameWithoutExtension
		{
			get
			{
				return System.IO.Path.GetFileNameWithoutExtension(path);
			}
		}

		public string FileExtension
		{
			get
			{
				return System.IO.Path.GetExtension(path);
			}
		}

		public void Save()
		{
			MediaFileDM.Instance.Save(this);
		}

		public static List<MediaFileCollection> GetMediaFileCollectionList()
		{
			return MediaFileDM.Instance.GetMediaFileCollectionList();
		}
	}
}
