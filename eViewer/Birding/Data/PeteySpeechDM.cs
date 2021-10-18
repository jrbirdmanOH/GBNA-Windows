using System;
using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class PeteySpeechDM
	{
		private static PeteySpeechDM instance = new PeteySpeechDM();

		private PeteySpeechDM()
		{
		}

		public static PeteySpeechDM Instance
		{
			get
			{
				return instance;
			}
		}

		public int GetCount(string key)
		{
			int retVal = 0;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Count(*) FROM (SELECT DISTINCT Key FROM PeteySpeech WHERE Key LIKE '" + key + "%')";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				retVal = Convert.ToInt32(cmd.ExecuteScalar());
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

			return retVal;
		}

		public PeteySpeech GetSpeech(string key, int index)
		{
			PeteySpeech speech = new PeteySpeech();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Speech FROM PeteySpeech WHERE Key=:Key ORDER BY Index";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter keyParam = cmd.CreateParameter();
				keyParam.ParameterName = ":Key";
				keyParam.Value = key + index;
				cmd.Parameters.Add(keyParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					speech.Lines.Add(reader.GetString(0));
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

			return speech;
		}
	}
}
