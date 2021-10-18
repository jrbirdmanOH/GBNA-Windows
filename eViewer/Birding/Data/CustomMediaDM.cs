using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class CustomMediaDM
	{
		private static CustomMediaDM instance = new CustomMediaDM();

		private CustomMediaDM()
		{
		}

		public static CustomMediaDM Instance
		{
			get
			{
				return instance;
			}
		}

		public void Save(CustomMedia media, IDbTransaction trans)
		{
			// TODO: Rethink what happens when same file name is used for media!

			// Make sure media with same file and type only get updated if already exists
			CustomMedia savedMedia = GetByFileNameAndType(media.FileName, media.Type);
			if (savedMedia != null)
			{
				media.ID = savedMedia.ID;
			}

			if (media.ID == 0)
			{
				Insert(media, trans);
			}
			else
			{
				Update(media, trans);
			}
		}

		protected void Insert(CustomMedia media, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				StringBuilder sql = new StringBuilder("INSERT INTO Media (Type, FileName, Caption, OwnerName) VALUES (:Type, :FileName, :Caption, :OwnerName)");
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter typeParam = cmd.CreateParameter();
				typeParam.ParameterName = ":Type";
				typeParam.Value = media.Type;
				cmd.Parameters.Add(typeParam);

				IDbDataParameter fileNameParam = cmd.CreateParameter();
				fileNameParam.ParameterName = ":FileName";
				fileNameParam.Value = media.FileName;
				cmd.Parameters.Add(fileNameParam);

				IDbDataParameter captionParam = cmd.CreateParameter();
				captionParam.ParameterName = ":Caption";
				captionParam.Value = media.Caption;
				cmd.Parameters.Add(captionParam);

				// Custom media owners are intended to only be set manually in the database
				IDbDataParameter ownerNameParam = cmd.CreateParameter();
				ownerNameParam.ParameterName = ":OwnerName";
				ownerNameParam.Value = media.Owner ?? (object)DBNull.Value;
				cmd.Parameters.Add(ownerNameParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();

				media.ID = ApplicationSettings.GetIdentityValue(conn, trans);
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		protected void Update(CustomMedia media, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE Media SET Type=:Type, FileName=:FileName, Caption=:Caption, OwnerName=:OwnerName WHERE Media.ID=:MediaID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter typeParam = cmd.CreateParameter();
				typeParam.ParameterName = ":Type";
				typeParam.Value = media.Type;
				cmd.Parameters.Add(typeParam);

				IDbDataParameter fileNameParam = cmd.CreateParameter();
				fileNameParam.ParameterName = ":FileName";
				fileNameParam.Value = media.FileName;
				cmd.Parameters.Add(fileNameParam);

				IDbDataParameter captionParam = cmd.CreateParameter();
				captionParam.ParameterName = ":Caption";
				captionParam.Value = media.Caption;
				cmd.Parameters.Add(captionParam);

				IDbDataParameter ownerNameParam = cmd.CreateParameter();
				ownerNameParam.ParameterName = ":OwnerName";
				ownerNameParam.Value = media.Owner ?? (object)DBNull.Value;
				cmd.Parameters.Add(ownerNameParam);

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":MediaID";
				idParam.Value = media.ID;
				cmd.Parameters.Add(idParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		public void Delete(int id, IDbTransaction trans)
		{
			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "DELETE FROM Media WHERE Media.ID=:MediaID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":MediaID";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);


				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}
		}

		public CustomMedia GetByID(int id)
		{
			CustomMedia media = null;

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID, Media.Type, Media.FileName, Media.Caption, Media.OwnerName FROM Media WHERE Media.ID=:MediaID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.Value = id;
				cmd.Parameters.Add(mediaIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					media = new CustomMedia();

					media.ID = reader.GetInt32(0);
					media.Type = reader.GetString(1);
					media.FileName = reader.GetString(2);
					media.Caption = reader.GetString(3);
					media.Owner = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
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

		private CustomMedia GetByFileNameAndType(string fileName, string type)
		{
			CustomMedia media = null;

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID, Media.Type, Media.FileName, Media.Caption, Media.OwnerName FROM Media WHERE Media.FileName=:FileName AND Media.Type=:Type";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter fileNameParam = cmd.CreateParameter();
				fileNameParam.ParameterName = ":FileName";
				fileNameParam.Value = fileName;
				cmd.Parameters.Add(fileNameParam);

				IDbDataParameter typeParam = cmd.CreateParameter();
				typeParam.ParameterName = ":Type";
				typeParam.Value = type;
				cmd.Parameters.Add(typeParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					media = new CustomMedia();

					media.ID = reader.GetInt32(0);
					media.Type = reader.GetString(1);
					media.FileName = reader.GetString(2);
					media.Caption = reader.GetString(3);
					media.Owner = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
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

		public MediaCollection GetListByCustomThingID(int thingID)
		{
			MediaCollection list = new MediaCollection();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID, Media.Type, Media.FileName, Media.Caption, Media.OwnerName FROM Media, CustomThingMedia WHERE CustomThingMedia.CustomThingID=:CustomThingID AND CustomThingMedia.MediaID=Media.ID ORDER BY CustomThingMedia.[Order]";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
				idParam.Value = thingID;
				cmd.Parameters.Add(idParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomMedia media = new CustomMedia();

					media.ID = reader.GetInt32(0);
					media.Type = reader.GetString(1);
					media.FileName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					media.Caption = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
					media.Owner = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

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

		public List<int> GetIDListByCustomThingID(int thingID, IDbTransaction trans)
		{
			List<int> list = new List<int>();

			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID FROM Media, CustomThingMedia WHERE CustomThingMedia.CustomThingID=:CustomThingID AND CustomThingMedia.MediaID=Media.ID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
				idParam.Value = thingID;
				cmd.Parameters.Add(idParam);
				cmd.Transaction = trans;

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
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

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public List<int> GetIDListByCustomThingAndType(int thingID, string mediaType)
		{
			List<int> list = new List<int>();

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID FROM Media, CustomThingMedia WHERE CustomThingMedia.CustomThingID=:CustomThingID AND CustomThingMedia.MediaID=Media.ID AND Media.Type=:MediaType ORDER BY CustomThingMedia.[Order]";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":CustomThingID";
				idParam.Value = thingID;
				cmd.Parameters.Add(idParam);

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

		public MediaCollection GetListByThingID(int thingID, IDbTransaction trans)
		{
			MediaCollection list = new MediaCollection();

			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID, Media.Type, Media.FileName, Media.Caption, Media.OwnerName FROM Media, ThingMedia WHERE ThingMedia.ThingID=:ThingID AND ThingMedia.MediaID=Media.ID ORDER BY ThingMedia.[Order]";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":ThingID";
				idParam.Value = thingID;
				cmd.Parameters.Add(idParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomMedia media = new CustomMedia();

					media.ID = reader.GetInt32(0);
					media.Type = reader.GetString(1);
					media.FileName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
					media.Caption = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
					media.Owner = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

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

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public List<int> GetIDListByThingID(int thingID, IDbTransaction trans)
		{
			List<int> list = new List<int>();

			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.ID FROM Media, ThingMedia WHERE ThingMedia.ThingID=:ThingID AND ThingMedia.MediaID=Media.ID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":ThingID";
				idParam.Value = thingID;
				cmd.Parameters.Add(idParam);
				cmd.Transaction = trans;

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
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

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public string GetTypeByID(int id)
		{
			string type = "";

			IDbConnection conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Media.Type FROM Media WHERE Media.MediaID=:MediaID";
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

		public bool IsFileNameReferenced(string fileName, IDbTransaction trans)
		{
			bool bExists = false;

			IDbConnection conn;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
			}

			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(Media.ID) FROM Media WHERE Media.FileName=:FileName";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				IDbDataParameter fileNameParam = cmd.CreateParameter();
				fileNameParam.ParameterName = ":FileName";
				fileNameParam.Value = fileName;
				cmd.Parameters.Add(fileNameParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				bExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (trans == null && conn != null)
				{
					conn.Close();
				}
			}

			return bExists;
		}
	}
}
