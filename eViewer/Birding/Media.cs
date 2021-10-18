using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Media : IMedia
	{
		private int id = 0;
		private string caption = string.Empty;
		private string path = string.Empty;
		private int width = 0;
		private int height = 0;
		private string primaryPath = string.Empty;
		private string type = string.Empty;
		private string owner = string.Empty;
		private string recorder = string.Empty;
		private int order = 0;
		private string absolutePath = null;

		private const string Thayer = "Thayer Birding Software";

		public Media()
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

		public bool IsCustom
		{
			get
			{
				return false;
			}
		}

		public string Caption
		{
			get
			{
				return caption;
			}

			set
			{
				caption = value;
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

		public int Width
		{
			get
			{
				return width;
			}

			set
			{
				width = value;
			}
		}

		public int Height
		{
			get
			{
				return height;
			}

			set
			{
				height = value;
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

		public string TypeDescription
		{
			get
			{
				return MediaType.GetDescription(this.Type);
			}
		}

		public string Owner
		{
			get
			{
				return owner;
			}

			set
			{
				owner = value;
			}
		}

		public string Recorder
		{
			get
			{
				return recorder;
			}

			set
			{
				recorder = value;
			}
		}

		public int Order
		{
			get
			{
				return order;
			}

			set
			{
				order = value;
			}
		}

		public string FileName
		{
			get
			{
				return System.IO.Path.GetFileName(Path);
			}
		}

		public string AbsolutePath
		{
			get
			{
				if(absolutePath == null)
				{
					absolutePath = System.IO.Path.Combine(ApplicationSettings.MediaPath, Path);

					if (!File.Exists(absolutePath))
					{
						absolutePath = System.IO.Path.Combine(PrimaryPath, Path);

						if (!File.Exists(absolutePath))
						{
							absolutePath = null;
						}
					}
				}

				return absolutePath;
			}
		}

		public string Copyright
		{
			get
			{
				StringBuilder copyright = new StringBuilder("Copyright © 2018, ");

				if (Recorder.Length > 0)
				{
					if (Recorder.Equals(Owner) || Owner.Length == 0)
					{
						copyright.Append(Recorder);
					}
					else
					{
						copyright.AppendFormat("{0}/{1}", Recorder, Owner);
					}
				}
				else if (Owner.Length > 0)
				{
					copyright.Append(Owner);
				}
				else
				{
					copyright.Append(Thayer);
				}

				if (!copyright.ToString().EndsWith("."))
				{
					copyright.Append(".");
				}

				copyright.Append(" All rights reserved.");

				return copyright.ToString();
			}
		}

		public string FullCopyright
		{
			get
			{
				return this.Copyright;
			}
		}

		public string ThumbnailPath
		{
			get
			{
				string directory = System.IO.Path.GetDirectoryName(AbsolutePath);
				string thumbDirectory = System.IO.Path.Combine(directory, "thumbs");
				string filename = System.IO.Path.GetFileNameWithoutExtension(path);
				string thumbnailPath = System.IO.Path.Combine(thumbDirectory, filename + ".jpg");

				return File.Exists(thumbnailPath) ? thumbnailPath : string.Empty;
			}
		}

		public static Media GetByID(int id)
		{
			return MediaDM.Instance.GetByID(id);
		}

		public static MediaCollection GetListByThingID(int thingID)
		{
			return MediaDM.Instance.GetListByThingID(thingID);
		}

		public static List<int> GetListByThingAndType(int thingID, string mediaType)
		{
			return MediaDM.Instance.GetListByThingAndType(thingID, mediaType, false);
		}

		public static List<int> GetListByThingAndType(int thingID, string mediaType, bool excludeEggAndNestPhotos)
		{
			return MediaDM.Instance.GetListByThingAndType(thingID, mediaType, excludeEggAndNestPhotos);
		}

		public static string GetTypeByID(int id)
		{
			return MediaDM.Instance.GetTypeByID(id);
		}
	}
}
