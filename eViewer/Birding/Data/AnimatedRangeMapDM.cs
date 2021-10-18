using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
    internal class AnimatedRangeMapDM
    {
        private static AnimatedRangeMapDM instance = null;

        private AnimatedRangeMapDM()
        {
        }

        public static AnimatedRangeMapDM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnimatedRangeMapDM();
                }

                return instance;
            }
        }

        public AnimatedRangeMap GetByThingID(int thingID)
        {
            AnimatedRangeMap animatedRangeMap = null;

            IDbConnection conn = ApplicationSettings.CreateConnection();
            IDbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ThingID, Link FROM AnimatedRangeMap WHERE ThingID=:ThingID";
                cmd.CommandType = CommandType.Text;

                IDbDataParameter thingIDParam = cmd.CreateParameter();
                thingIDParam.ParameterName = ":ThingID";
                thingIDParam.Value = thingID;
                cmd.Parameters.Add(thingIDParam);

                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    animatedRangeMap = new AnimatedRangeMap();
                    animatedRangeMap.ThingID = reader.GetInt32(0);
                    animatedRangeMap.Link = reader.GetString(1);
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

            return animatedRangeMap;
        }
    }
}
