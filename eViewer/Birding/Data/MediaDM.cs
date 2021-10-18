using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class MediaDM
	{
		private static MediaDM instance = new MediaDM();

		private MediaDM()
		{
		}

		public static MediaDM Instance
		{
			get
			{
				return instance;
			}
		}

		public Media GetByID(int id)
		{
			Media media = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.MediaID, Media.Caption, Media.Type, MediaDirectory.PrimaryPath, Media.Path, Media.Width, Media.Height, Owners.Name, Recorders.Name, MediaThings.[Order] FROM Media, MediaDirectory, MediaThings, Owners, Recorders WHERE Media.MediaDirectoryID=MediaDirectory.MediaDirectoryID AND Media.MediaID=MediaThings.MediaID AND Owners.OwnerID=Media.OwnerID AND Recorders.RecorderID=Media.RecorderID AND Media.MediaID=:id ORDER BY [Order]";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":id";
				thingIDParam.Value = id;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					media = new Media();

					media.ID = reader.GetInt32(0);
					media.Caption = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
					media.Type = reader.GetString(2);
					media.PrimaryPath = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
					media.Path = reader.GetString(4).Replace('\\', Path.DirectorySeparatorChar);
					media.Width = !reader.IsDBNull(5) ? reader.GetInt32(5) : 0;
					media.Height = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0;
					media.Owner = reader.GetString(7);
					media.Recorder = reader.GetString(8);
					media.Order = !reader.IsDBNull(9) ? reader.GetInt16(9) : 0;
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

			return media;
		}

		public MediaCollection GetListByThingID(int thingID)
		{
			MediaCollection list = new MediaCollection();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.MediaID, Media.Caption, Media.Type, MediaDirectory.PrimaryPath, Media.Path, Media.Width, Media.Height, Owners.Name, Recorders.Name, MediaThings.[Order] FROM Media, MediaDirectory, MediaThings, Owners, Recorders WHERE MediaDirectory.MediaDirectoryID=Media.MediaDirectoryID AND Media.MediaID=MediaThings.MediaID AND Owners.OwnerID=Media.OwnerID AND Recorders.RecorderID=Media.RecorderID AND MediaThings.ThingID=:id ORDER BY [Order]";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":id";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Media media = new Media();

					media.ID = reader.GetInt32(0);
					media.Caption = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
					media.Type = reader.GetString(2);
					media.PrimaryPath = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
					media.Path = reader.GetString(4).Replace('\\', Path.DirectorySeparatorChar);
					media.Width = !reader.IsDBNull(5) ? reader.GetInt32(5) : 0;
					media.Height = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0;
					media.Owner = reader.GetString(7);
					media.Recorder = reader.GetString(8);
					media.Order = !reader.IsDBNull(9) ? reader.GetInt16(9) : 0;

					list.Add(media);
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

		public List<int> GetListByThingAndType(int thingID, string mediaType, bool excludeEggAndNestPhotos)
		{
			List<int> list = new List<int>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				StringBuilder commandText = new StringBuilder("SELECT MediaThings.MediaID FROM Media, MediaThings WHERE (Media.MediaID = MediaThings.MediaID) ");
				if (excludeEggAndNestPhotos)
				{
					commandText.AppendFormat("AND MediaThings.[Order] <> {0} AND MediaThings.[Order] <> {1} ", PhotoContentType.EGG_ORDER, PhotoContentType.NEST_ORDER);
				}
				commandText.Append("AND MediaThings.ThingID = :ThingID AND Media.Type = :MediaType ORDER BY MediaThings.[Order], Media.Keywords");

				cmd = conn.CreateCommand();
				cmd.CommandText = commandText.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter mediaTypeParam = cmd.CreateParameter();
				mediaTypeParam.ParameterName = ":MediaType";
				mediaTypeParam.Value = mediaType;
				cmd.Parameters.Add(mediaTypeParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					list.Add(reader.GetInt32(0));
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

		public string GetTypeByID(int id)
		{
			string type = "";

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.Type FROM Media WHERE Media.MediaID = :MediaID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = id;
				cmd.Parameters.Add(mediaIDParam);

				conn.Open();
				type = (string)cmd.ExecuteScalar();
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

			return type;
		}
	}
}
