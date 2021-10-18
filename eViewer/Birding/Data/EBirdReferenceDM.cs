using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
    internal class EBirdReferenceDM
    {
        private static EBirdReferenceDM instance = null;

        private EBirdReferenceDM()
        {
        }

        public static EBirdReferenceDM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EBirdReferenceDM();
                }

                return instance;
            }
        }

        public EBirdReference GetByThingID(int thingID)
        {
			EBirdReference ebirdReference = null;

            IDbConnection conn = ApplicationSettings.CreateConnection();
            IDbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ThingID, TaxonCode FROM EBirdReference WHERE ThingID=:ThingID";
                cmd.CommandType = CommandType.Text;

                IDbDataParameter thingIDParam = cmd.CreateParameter();
                thingIDParam.ParameterName = ":ThingID";
                thingIDParam.Value = thingID;
                cmd.Parameters.Add(thingIDParam);

                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
					ebirdReference = new EBirdReference();
					ebirdReference.ThingID = reader.GetInt32(0);
					ebirdReference.TaxonCode = reader.GetString(1);
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

            return ebirdReference;
        }
    }
}
