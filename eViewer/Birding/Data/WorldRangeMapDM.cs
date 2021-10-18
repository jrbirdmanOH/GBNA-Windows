using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
    internal class WorldRangeMapDM
    {
        private static WorldRangeMapDM instance = null;

		private WorldRangeMapDM()
        {
        }

		public static WorldRangeMapDM Instance
        {
            get
            {
                if (instance == null)
                {
					instance = new WorldRangeMapDM();
                }

                return instance;
            }
        }

		public WorldRangeMap GetByThingID(int thingID)
        {
            WorldRangeMap worldRangeMap = null;

            IDbConnection conn = ApplicationSettings.CreateConnection();
            IDbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ThingID, Link FROM WorldRangeMap WHERE ThingID=:ThingID";
                cmd.CommandType = CommandType.Text;

                IDbDataParameter thingIDParam = cmd.CreateParameter();
                thingIDParam.ParameterName = ":ThingID";
                thingIDParam.Value = thingID;
                cmd.Parameters.Add(thingIDParam);

                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    worldRangeMap = new WorldRangeMap();
                    worldRangeMap.ThingID = reader.GetInt32(0);
                    worldRangeMap.Link = reader.GetString(1);
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

            return worldRangeMap;
        }
    }
}
