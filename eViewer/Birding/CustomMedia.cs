using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thayer.Birding.Data;
using System.Data;

namespace Thayer.Birding
{
	public class CustomMedia : IMedia
	{
		private int id = 0;
		private string type = string.Empty;
		private string fileName = string.Empty;
		private string caption = string.Empty;
		private string originalPath = string.Empty;
		private string path = string.Empty;
		private string primaryPath = string.Empty;
		private string owner = string.Empty;
		private int order = 0;
		private string absolutePath = null;

		public CustomMedia()
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
				return true;
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

		public string FileName
		{
			get
			{
				return fileName;
			}

			set
			{
				fileName = value;
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

		public string OriginalPath
		{
			get
			{
				return originalPath;
			}

			set
			{
				originalPath = value;
			}
		}

		public string Path
		{
			get
			{
				return System.IO.Path.Combine(GetPathByType(this.Type), this.FileName);
			}
		}

		public string PrimaryPath
		{
			get
			{
				return ApplicationSettings.CustomMediaPath;
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

		public string AbsolutePath
		{
			get
			{
				if (id == 0)
				{
					// Use original path if not saved to database
					absolutePath = System.IO.Path.Combine(OriginalPath, FileName);
				}
				else
				{
					absolutePath = GetAbsolutePath();
				}

				return absolutePath;
			}
		}

		public string Copyright
		{
			get
			{
				StringBuilder copyright = new StringBuilder();

				if (Owner.Length > 0)
				{
					copyright.Append("Copyright © 2018, ");
					copyright.Append(Owner);

					if (!copyright.ToString().EndsWith("."))
					{
						copyright.Append(".");
					}

					copyright.Append(" All rights reserved.");
				}

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
				string filename = System.IO.Path.GetFileNameWithoutExtension(Path);
				string thumbnailPath = System.IO.Path.Combine(thumbDirectory, filename + ".jpg");

				return File.Exists(thumbnailPath) ? thumbnailPath : string.Empty;
			}
		}

		public int Width
		{
			get
			{
				return 0;
			}
		}

		public int Height
		{
			get
			{
				return 0;
			}
		}

		public bool NeedToOverwrite
		{
			get
			{
				bool needToOverwrite = false;

				// Detect condition that requires whether or not the
				// media file exists and needs to be overwritten
				if (File.Exists(GetAbsolutePath()))
				{
					// See if the path of the media file is not the
					// application defined CustomMedia folder
					if (this.OriginalPath != System.IO.Path.GetDirectoryName(GetAbsolutePath()))
					{
						needToOverwrite = true;
					}
				}

				return needToOverwrite;
			}
		}

		private string GetPathByType(string type)
		{
			string path = string.Empty;

			if (type == MediaType.Photo)
			{
				path = "photos";
			}
			else if (type == MediaType.Sound)
			{
				path = "sounds";
			}
			else if (type == MediaType.AbundanceMap || type == MediaType.RangeMap)
			{
				path = "maps";
			}
			else if (type == MediaType.Video)
			{
				path = "videos";
			}

			return path;
		}

		private string GetAbsolutePath()
		{
			return System.IO.Path.Combine(PrimaryPath, Path);
		}

		public void Save(IDbTransaction trans)
		{
			CustomMediaDM.Instance.Save(this, trans);

			string sourceFile = System.IO.Path.Combine(this.OriginalPath, this.FileName);
			string destinationFile = this.AbsolutePath;

			if (sourceFile != destinationFile)
			{
				File.Copy(sourceFile, destinationFile, true);
			}

			// Delete media file if media exists and file is changing
			// Note: The GetByID method is not part of the existing
			//       transaction so it can still retrieve old version
			//       of the custom media data even though the new
			//       version has been saved in the transaction which
			//       has not yet been committed.
			CustomMedia savedMedia = CustomMedia.GetByID(this.id);
			if (savedMedia != null)
			{
				if (savedMedia.FileName != this.FileName)
				{
					savedMedia.DeleteMediaFile(trans);
				}
			}
		}

		public void Delete()
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				Delete(trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void Delete(IDbTransaction trans)
		{
			if (trans != null)
			{
				DeleteByID(this.ID, trans);
			}
			else
			{
				Delete();
			}
		}

		public void DeleteByThingID(int thingID)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				// Delete record linking the thing to the custom media
				ThingCustomMediaDM.Instance.Delete(thingID, this.ID, trans);

				DeleteByID(this.ID, trans);

				// Update the order for linked/related records
				int order = 1;
				MediaCollection mediaCollection = CustomMedia.GetListByThingID(thingID, trans);
				foreach (IMedia media in mediaCollection.All)
				{
					ThingCustomMediaDM.Instance.Save(thingID, media.ID, order, trans);
					order++;
				}

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void SaveAndLinkToThing(int thingID)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				Save(trans);
				ThingCustomMediaDM.Instance.Save(thingID, this.ID, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		private bool IsMediaReferenced(IDbTransaction trans)
		{
			bool isReferenced = true;

			// See if media belongs to a custom thing or is referenced by a thing as My Media
			if (!CustomThingMediaDM.Instance.IsMediaReferenced(this.ID, trans) && !ThingCustomMediaDM.Instance.IsMediaReferenced(this.ID, trans))
			{
				isReferenced = false;
			}

			return isReferenced;
		}

		private void DeleteMediaFile(IDbTransaction trans)
		{
			DeleteMediaFile(this.FileName, this.AbsolutePath, trans);
		}

		private static void DeleteMediaFile(string fileName, string absolutePath, IDbTransaction trans)
		{
			// See if file can be deleted
			if (!CustomMediaDM.Instance.IsFileNameReferenced(fileName, trans))
			{
				if (File.Exists(absolutePath))
				{
					try
					{
						File.Delete(absolutePath);
					}
					catch (IOException ex)
					{
						// Don't need to worry about case where file is possibly in use
					}
				}
			}
		}

		public static void DeleteByID(int id)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				CustomMedia.DeleteByID(id, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public static void DeleteByID(int id, IDbTransaction trans)
		{
			if (trans != null)
			{
				CustomMedia media = CustomMedia.GetByID(id);

				// Make sure the media is not referenced before deleting
				if (!media.IsMediaReferenced(trans))
				{
					// Delete the media database record
					CustomMediaDM.Instance.Delete(media.ID, trans);

					// Delete the media file
					media.DeleteMediaFile(trans);
				}
			}
			else
			{
				CustomMedia.DeleteByID(id);
			}
		}

		public static void DeleteByCustomThingID(int customThingID, IDbTransaction trans)
		{
			if (trans != null)
			{
				List<int> mediaList = CustomMediaDM.Instance.GetIDListByCustomThingID(customThingID, trans);
				CustomThingMediaDM.Instance.DeleteByCustomThingID(customThingID, trans);
				foreach (int mediaID in mediaList)
				{
					CustomMedia.DeleteByID(mediaID, trans);
				}
			}
			else
			{
				CustomMedia.DeleteByCustomThingID(customThingID);
			}
		}

		public static void DeleteByCustomThingID(int customThingID)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				CustomMedia.DeleteByCustomThingID(customThingID, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public static CustomMedia GetByID(int id)
		{
			return CustomMediaDM.Instance.GetByID(id);
		}

		public static MediaCollection GetListByCustomThingID(int thingID)
		{
			return CustomMediaDM.Instance.GetListByCustomThingID(thingID);
		}

		public static MediaCollection GetListByThingID(int thingID)
		{
			return GetListByThingID(thingID, null);
		}

		public static MediaCollection GetListByThingID(int thingID, IDbTransaction trans)
		{
			return CustomMediaDM.Instance.GetListByThingID(thingID, trans);
		}

		public static List<int> GetIDListByCustomThingID(int thingID, IDbTransaction trans)
		{
			return CustomMediaDM.Instance.GetIDListByCustomThingID(thingID, trans);
		}

		public static List<int> GetIDListByCustomThingAndType(int thingID, string mediaType)
		{
			return CustomMediaDM.Instance.GetIDListByCustomThingAndType(thingID, mediaType);
		}

		public static string GetTypeByID(int id)
		{
			return CustomMediaDM.Instance.GetTypeByID(id);
		}
	}
}
