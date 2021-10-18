using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding;

namespace Thayer.MediaCleanup
{
	internal class MediaFileDM
	{
		private static MediaFileDM instance = new MediaFileDM();

		private MediaFileDM()
		{
		}

		public static MediaFileDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(MediaFile mediaFile)
		{
			Update(mediaFile);
		}

		protected void Update(MediaFile mediaFile)
		{
			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE Media SET Path=:Path WHERE MediaID=:MediaID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter pathParam = cmd.CreateParameter();
				pathParam.ParameterName = ":Path";
				pathParam.Value = mediaFile.Path;
				cmd.Parameters.Add(pathParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = mediaFile.MediaID;
				cmd.Parameters.Add(mediaIDParam);

				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public List<MediaFileCollection> GetMediaFileCollectionList()
		{
			List<MediaFileCollection> list = new List<MediaFileCollection>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				StringBuilder query = new StringBuilder("SELECT Media.MediaID, Media.Path, Media.Type, CommonNames.CommonName, Classifications.ThingID FROM Classifications, CommonNames, Media, MediaThings WHERE Classifications.ThingID=MediaThings.ThingID AND CommonNames.CommonNameID=Classifications.CommonNameID AND Media.MediaID=MediaThings.MediaID ORDER BY MediaThings.ThingID, MediaThings.Order");
				cmd = conn.CreateCommand();
				cmd.CommandText = query.ToString();
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				int previousThingID = -1;
				MediaFileCollection collection = null;
				while (reader.Read())
				{
					MediaFile mediaFile = new MediaFile();
					mediaFile.MediaID = reader.GetInt32(0);
					mediaFile.Path = reader.GetString(1);
					mediaFile.Type = reader.GetString(2);
					mediaFile.CommonName = reader.GetString(3);
					mediaFile.ThingID = reader.GetInt32(4);

					if (mediaFile.ThingID != previousThingID)
					{
						if (collection != null)
						{
							list.Add(collection);
						}

						collection = new MediaFileCollection();
					}
					previousThingID = mediaFile.ThingID;

					collection.Add(mediaFile);
				}

				if (collection != null && collection.Count > 0)
				{
					list.Add(collection);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}
	}
}
