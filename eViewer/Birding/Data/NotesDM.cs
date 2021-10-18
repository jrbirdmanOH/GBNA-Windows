using System;
using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class NotesDM
	{
		private static NotesDM instance = new NotesDM();

		private NotesDM()
		{
		}

		public static NotesDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<Note> GetList()
		{
			List<Note> list = new List<Note>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ThingID, Note FROM Notes";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Note note = new Note();

					note.ThingID = reader.GetInt32(0);
					note.Text = reader.GetString(1);

					list.Add(note);
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

		public string GetByThingID(int thingID)
		{
			string notes = string.Empty;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Note FROM Notes WHERE ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					notes = reader.GetString(0).Replace(System.Environment.NewLine, "<br />");
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

			return notes;
		}

		public void Delete(int thingID, IDbTransaction trans)
		{
			IDbConnection conn = trans.Connection;
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "DELETE FROM Notes WHERE ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}
			}
		}

		public void DeleteAll(IDbTransaction trans)
		{
			IDbConnection conn = null;
			if (trans != null)
			{
				conn = trans.Connection;
			}
			else
			{
				conn = ApplicationSettings.CreateConnection();
			}
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "DELETE FROM Notes";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

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

		public void Save(int thingID, string notes, IDbTransaction trans)
		{
			IDbConnection conn = trans.Connection;
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "INSERT INTO Notes (ThingID, [Note]) VALUES (:ThingID, :Note)";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter noteParam = cmd.CreateParameter();
				noteParam.ParameterName = ":Note";
				noteParam.Value = notes;
				cmd.Parameters.Add(noteParam);

				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}
			}
		}

		public bool Exists(Note note)
		{
			bool bExists = false;

			IDbConnection conn = null;
			IDbCommand cmd = null;

			try
			{
				conn = ApplicationSettings.CreateConnection();

				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(ThingID) FROM Notes WHERE ThingID=:ThingID AND Note=:Note";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = note.ThingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter noteParam = cmd.CreateParameter();
				noteParam.ParameterName = ":Note";
				noteParam.Value = note.Text;
				cmd.Parameters.Add(noteParam);

				conn.Open();

				bExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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

			return bExists;
		}
	}
}
