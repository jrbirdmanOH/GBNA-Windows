using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class SimilarThingsDM
	{
		private static SimilarThingsDM instance = new SimilarThingsDM();

		private SimilarThingsDM()
		{
		}

		public static SimilarThingsDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<SimilarSpecies> GetSimilarSpecies(int thingID, int collectionID)
		{
			List<SimilarSpecies> list = new List<SimilarSpecies>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT SimilarThings.ThingID2, SimilarThings.MediaID FROM CollectionThings, SimilarThings WHERE SimilarThings.ThingID1=:ThingID AND SimilarThings.ThingID2=CollectionThings.ThingID AND CollectionThings.CollectionID=:CollectionID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = thingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					SimilarSpecies similar = new SimilarSpecies();

					similar.ThingID = reader.GetInt32(0);
					similar.MediaID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

					list.Add(similar);
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
