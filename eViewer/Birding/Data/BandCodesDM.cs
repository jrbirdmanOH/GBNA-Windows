using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class BandCodesDM
	{
		private static BandCodesDM instance = new BandCodesDM();

		private BandCodesDM()
		{
		}

		public static BandCodesDM Instance
		{
			get
			{
				return instance;
			}
		}

		public BandCode GetByThingID(int thingID, IDbConnection conn)
		{
			BandCode bandCode = null;

			bool closeConnection = false;
			if (conn == null)
			{
				conn = ApplicationSettings.CreateConnection();
				closeConnection = true;
			}
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT BandCodeList.Name, BandCodes.BandCode FROM BandCodeList,BandCodes WHERE BandCodeList.BandCodeListID=BandCodes.BandCodeListID AND ThingID=:ThingID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}

				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					bandCode = new BandCode();

					bandCode.Name = reader.GetString(0);
					bandCode.Code = reader.GetString(1);
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

				if (conn != null && closeConnection)
				{
					conn.Close();
				}
			}

			return bandCode;
		}

		public BandCode GetByThingID(int thingID)
		{
			return GetByThingID(thingID, null);
		}
	}
}
