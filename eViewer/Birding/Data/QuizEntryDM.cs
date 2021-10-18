using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Thayer.Birding.Data
{
	internal class QuizEntryDM
	{
		private static QuizEntryDM instance = new QuizEntryDM();

		private QuizEntryDM()
		{
		}

		public static QuizEntryDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<QuizEntry> GetList(QuizSource.QuizSourceTypes quizSource)
		{
			List<QuizEntry> list = new List<QuizEntry>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM QuizEntries ORDER BY SortOrder";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					QuizEntry quizEntry = new QuizEntry();

					quizEntry.ID = reader.GetInt32(0);
					quizEntry.Answered = reader.IsDBNull(1) ? null : reader.GetString(1);
					quizEntry.ThingID = reader.GetInt32(2);
					quizEntry.MediaID = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
					quizEntry.IsMediaCustom = reader.GetBoolean(4);
					quizEntry.SecondaryMediaID = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
					quizEntry.IsSecondaryMediaCustom = reader.GetBoolean(6);
					quizEntry.SortOrder = Convert.ToInt32(reader.GetDouble(7));
					for (int readerIndex = 8; readerIndex < 12; readerIndex++)
					{
						int alternateThingID = reader.GetInt32(readerIndex);
						if (alternateThingID != 0)
						{
							quizEntry.AlternateThings.Add(alternateThingID);
						}
					}
					quizEntry.Response = reader.IsDBNull(12) ? null : reader.GetString(12);

					quizEntry.IsCustom = quizSource == QuizSource.QuizSourceTypes.CustomQuiz ? true : false;

					list.Add(quizEntry);
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

		public int GetNumberOfUnansweredQuestions()
		{
			int numberOfUnansweredQuestions = 0;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(*) AS NumUnanswered FROM QuizEntries WHERE QuizEntries.Answered IS NULL";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				numberOfUnansweredQuestions = Convert.ToInt32(cmd.ExecuteScalar());
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

			return numberOfUnansweredQuestions;
		}

		public int GetQuizLength()
		{
			int quizLength = 0;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT COUNT(*) AS QuizLength FROM QuizEntries";
				cmd.CommandType = CommandType.Text;

				conn.Open();
				quizLength = Convert.ToInt32(cmd.ExecuteScalar());
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

			return quizLength;
		}

		public void DeleteAll(IDbTransaction trans)
		{
			IDbConnection conn = trans.Connection;
			IDbCommand cmd = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "DELETE FROM QuizEntries";
				cmd.CommandType = CommandType.Text;

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

		public List<QuizEntry> GetEntriesForQuiz(QuizSource.PredefinedQuizSource quizSource, int collectionID)
		{
			List<QuizEntry> list = new List<QuizEntry>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Quizzes.ThingID, Quizzes.MediaID FROM Quizzes WHERE ((Quizzes.QuizID = :QuizID) AND ThingID IN (SELECT ThingID FROM CollectionThings WHERE CollectionID = :CollectionID))";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter quizIDParam = cmd.CreateParameter();
				quizIDParam.ParameterName = ":QuizID";
				quizIDParam.Value = quizSource.QuizID;
				cmd.Parameters.Add(quizIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					QuizEntry quizEntry = new QuizEntry();

					quizEntry.ThingID = reader.GetInt32(0);
					if (reader.IsDBNull(1))
					{
						quizEntry.MediaID = null;
					}
					else
					{
						quizEntry.MediaID = reader.GetInt32(1);
					}
					quizEntry.IsMediaCustom = false;

					list.Add(quizEntry);
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

		public List<QuizEntry> GetEntriesForLocation(QuizSource.LocationQuizSource locationQuizSource, int collectionID)
		{
			List<QuizEntry> list = new List<QuizEntry>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();

				StringBuilder sqlText = new StringBuilder("SELECT DISTINCT MediaThings.ThingID FROM MediaThings, CheckList, CollectionThings WHERE ((CheckList.ThingID = MediaThings.ThingID AND CheckList.ThingID = CollectionThings.ThingID) AND CollectionThings.CollectionID = :CollectionID");

				if (locationQuizSource.Locations.Length > 0)
				{
					StringBuilder locationClause = new StringBuilder(" AND CheckList.LocationID IN (");

					int locationIndex = 0;
					foreach (Location location in locationQuizSource.Locations)
					{
						if (locationIndex > 0)
						{
							locationClause.Append(", ");
						}
						locationClause.Append(location.ID.ToString());
						locationIndex++;
					}

					locationClause.Append(")");
					sqlText.Append(locationClause);
				}

				if (locationQuizSource.CommonOnly)
				{
					sqlText.Append(" AND (Checklist.Common = ");
					sqlText.Append(ApplicationSettings.GetDBBooleanValue(true));
					sqlText.Append(")");
				}

				sqlText.Append(")");

				cmd.CommandText = sqlText.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					QuizEntry quizEntry = new QuizEntry();
					quizEntry.ThingID = reader.GetInt32(0);
					list.Add(quizEntry);
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

		public List<QuizEntry> GetEntriesForTaxonomicGroup(QuizSource.TaxonomicGroupQuizSource taxonomicGroupQuizSource, int collectionID)
		{
			List<QuizEntry> list = new List<QuizEntry>();

			Kingdom[] kingdoms;
			Phylum[] phyla;
			Class[] classes;
			Order[] orders;
			Family[] families;
			Genus[] genera;
			Taxonomy.GetClassifications(taxonomicGroupQuizSource.Classifications, out kingdoms, out phyla, out classes, out orders, out families, out genera);

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();

				StringBuilder sqlText = new StringBuilder("SELECT DISTINCT MediaThings.ThingID FROM MediaThings, CollectionThings, Classifications WHERE ((Classifications.ThingID = MediaThings.ThingID AND Classifications.ThingID = CollectionThings.ThingID) AND CollectionThings.CollectionID = :CollectionID");

				StringBuilder taxonomyClause = new StringBuilder();
				ThingsDM.Instance.AppendKingdom(taxonomyClause, kingdoms);
				ThingsDM.Instance.AppendPhyla(taxonomyClause, phyla);
				ThingsDM.Instance.AppendClass(taxonomyClause, classes);
				ThingsDM.Instance.AppendOrder(taxonomyClause, orders);
				ThingsDM.Instance.AppendFamilies(taxonomyClause, families);
				ThingsDM.Instance.AppendGenus(taxonomyClause, genera);

				if (taxonomyClause.Length > 0)
				{
					sqlText.Append(" AND (");
					sqlText.Append(taxonomyClause);
					sqlText.Append(")");
				}

				sqlText.Append(")");

				cmd.CommandText = sqlText.ToString();
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					QuizEntry quizEntry = new QuizEntry();
					quizEntry.ThingID = reader.GetInt32(0);
					list.Add(quizEntry);
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

		public List<QuizEntry> GetEntriesForCustomList(QuizSource.CustomListQuizSource customListQuizSource, int collectionID)
		{
			List<QuizEntry> list = new List<QuizEntry>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ThingID FROM (SELECT DISTINCT MediaThings.ThingID AS ThingID, CustomListsThings.[Order] FROM MediaThings, CustomListsThings, CollectionThings WHERE ((MediaThings.ThingID = CustomListsThings.ThingID AND CollectionThings.ThingID = CustomListsThings.ThingID) AND CollectionThings.CollectionID = :CollectionID AND CustomListsThings.CustomListID = :CustomListID) ORDER BY CustomListsThings.[Order])";
				
				cmd.CommandType = CommandType.Text;

				IDbDataParameter collectionIDParam = cmd.CreateParameter();
				collectionIDParam.ParameterName = ":CollectionID";
				collectionIDParam.Value = collectionID;
				cmd.Parameters.Add(collectionIDParam);

				IDbDataParameter customListIDParam = cmd.CreateParameter();
				customListIDParam.ParameterName = ":CustomListID";
				customListIDParam.Value = customListQuizSource.CustomListID;
				cmd.Parameters.Add(customListIDParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					QuizEntry quizEntry = new QuizEntry();
					quizEntry.ThingID = reader.GetInt32(0);
					list.Add(quizEntry);
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

		public List<QuizEntry> GetEntriesForCustomQuiz(QuizSource.CustomQuizSource customQuizSource)
		{
			List<QuizEntry> list = new List<QuizEntry>();

			CustomQuiz customQuiz = CustomQuiz.GetByID(customQuizSource.QuizID);
			foreach (CustomThing entry in customQuiz.Entries)
			{
				QuizEntry quizEntry = new QuizEntry();
				quizEntry.ThingID = entry.ID;
				quizEntry.IsCustom = true;
				list.Add(quizEntry);
			}

			return list;
		}

		public void Save(List<QuizEntry> quizEntries, IDbTransaction trans)
		{
			IDbConnection conn = trans.Connection;
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.Transaction = trans;
				cmd.CommandText = "INSERT INTO QuizEntries (Answered, ThingID, MediaID, IsMediaCustom, SecondaryMediaID, IsSecondaryMediaCustom, SortOrder, AltThing1, AltThing2, AltThing3, AltThing4, Response) VALUES (:Answered, :ThingID, :MediaID, :IsMediaCustom, :SecondaryMediaID, :IsSecondaryMediaCustom, :SortOrder, :AltThing1, :AltThing2, :AltThing3, :AltThing4, :Response)";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter answeredParam = cmd.CreateParameter();
				answeredParam.ParameterName = ":Answered";
				answeredParam.DbType = DbType.String;
				answeredParam.Size = 1;
				cmd.Parameters.Add(answeredParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.DbType = DbType.Int32;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				mediaIDParam.DbType = DbType.Int32;
				cmd.Parameters.Add(mediaIDParam);

				IDbDataParameter isMediaCustomParam = cmd.CreateParameter();
				isMediaCustomParam.ParameterName = ":IsMediaCustom";
				isMediaCustomParam.DbType = DbType.Boolean;
				cmd.Parameters.Add(isMediaCustomParam);

				IDbDataParameter secondaryMediaIDParam = cmd.CreateParameter();
				secondaryMediaIDParam.ParameterName = ":SecondaryMediaID";
				secondaryMediaIDParam.DbType = DbType.Int32;
				cmd.Parameters.Add(secondaryMediaIDParam);

				IDbDataParameter isSecondaryMediaCustomParam = cmd.CreateParameter();
				isSecondaryMediaCustomParam.ParameterName = ":IsSecondaryMediaCustom";
				isSecondaryMediaCustomParam.DbType = DbType.Boolean;
				cmd.Parameters.Add(isSecondaryMediaCustomParam);

				IDbDataParameter sortOrderParam = cmd.CreateParameter();
				sortOrderParam.ParameterName = ":SortOrder";
				sortOrderParam.DbType = DbType.Double;
				cmd.Parameters.Add(sortOrderParam);

				IDbDataParameter altThing1Param = cmd.CreateParameter();
				altThing1Param.ParameterName = ":AltThing1";
				altThing1Param.DbType = DbType.Int32;
				cmd.Parameters.Add(altThing1Param);

				IDbDataParameter altThing2Param = cmd.CreateParameter();
				altThing2Param.ParameterName = ":AltThing2";
				altThing2Param.DbType = DbType.Int32;
				cmd.Parameters.Add(altThing2Param);

				IDbDataParameter altThing3Param = cmd.CreateParameter();
				altThing3Param.ParameterName = ":AltThing3";
				altThing3Param.DbType = DbType.Int32;
				cmd.Parameters.Add(altThing3Param);

				IDbDataParameter altThing4Param = cmd.CreateParameter();
				altThing4Param.ParameterName = ":AltThing4";
				altThing4Param.DbType = DbType.Int32;
				cmd.Parameters.Add(altThing4Param);

				IDbDataParameter responseParam = cmd.CreateParameter();
				responseParam.ParameterName = ":Response";
				responseParam.DbType = DbType.String;
				responseParam.Size = 100;
				cmd.Parameters.Add(responseParam);

				cmd.Prepare();

				foreach (QuizEntry quizEntry in quizEntries)
				{
					if (quizEntry.Answered == null)
					{
						answeredParam.Value = DBNull.Value;
					}
					else
					{
						answeredParam.Value = quizEntry.Answered;
					}

					thingIDParam.Value = quizEntry.ThingID;

					if (quizEntry.MediaID == null)
					{
						mediaIDParam.Value = DBNull.Value;
					}
					else
					{
						mediaIDParam.Value = quizEntry.MediaID;
					}

					isMediaCustomParam.Value = quizEntry.IsMediaCustom;

					if (quizEntry.SecondaryMediaID == null)
					{
						secondaryMediaIDParam.Value = DBNull.Value;
					}
					else
					{
						secondaryMediaIDParam.Value = quizEntry.SecondaryMediaID;
					}

					isSecondaryMediaCustomParam.Value = quizEntry.IsSecondaryMediaCustom;
					sortOrderParam.Value = quizEntry.SortOrder;

					int alternateIndex = 0;
					foreach (int alternateThingID in quizEntry.AlternateThings)
					{
						IDbDataParameter altThingParam = (IDbDataParameter)cmd.Parameters[":AltThing" + Convert.ToString(++alternateIndex)];
						altThingParam.Value = alternateThingID;
					}

					// Set default parameter value for any alternates not already defined
					for (alternateIndex++; alternateIndex <= 4; alternateIndex++)
					{
						IDbDataParameter altThingParam = (IDbDataParameter)cmd.Parameters[":AltThing" + Convert.ToString(alternateIndex)];
						altThingParam.Value = 0;
					}

					if (quizEntry.Response == null)
					{
						responseParam.Value = DBNull.Value;
					}
					else
					{
						responseParam.Value = quizEntry.Response;
					}

					cmd.ExecuteNonQuery();

					quizEntry.ID = ApplicationSettings.GetIdentityValue(trans);
				}
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Dispose();
				}
			}
		}

		public void Save(QuizEntry quizEntry)
		{
			if (quizEntry.ID == 0)
			{
				Insert(quizEntry);
			}
			else
			{
				Update(quizEntry);
			}
		}

		protected void Insert(QuizEntry quizEntry)
		{
			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "INSERT INTO QuizEntries (Answered, ThingID, MediaID, IsMediaCustom, SecondaryMediaID, IsSecondaryMediaCustom, SortOrder, AltThing1, AltThing2, AltThing3, AltThing4, Response) VALUES (:Answered, :ThingID, :MediaID, :IsMediaCustom, :SecondaryMediaID, :IsSecondaryMediaCustom, :SortOrder, :AltThing1, :AltThing2, :AltThing3, :AltThing4, :Response)";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter answeredParam = cmd.CreateParameter();
				answeredParam.ParameterName = ":Answered";
				if (quizEntry.Answered == null)
				{
					answeredParam.Value = DBNull.Value;
				}
				else
				{
					answeredParam.Value = quizEntry.Answered;
				}
				cmd.Parameters.Add(answeredParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = quizEntry.ThingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				if (quizEntry.MediaID == null)
				{
					mediaIDParam.Value = DBNull.Value;
				}
				else
				{
					mediaIDParam.Value = quizEntry.MediaID;
				}
				cmd.Parameters.Add(mediaIDParam);

				IDbDataParameter isMediaCustomParam = cmd.CreateParameter();
				isMediaCustomParam.ParameterName = ":IsMediaCustom";
				isMediaCustomParam.DbType = DbType.Boolean;
				isMediaCustomParam.Value = quizEntry.IsMediaCustom;
				cmd.Parameters.Add(isMediaCustomParam);

				IDbDataParameter secondaryMediaIDParam = cmd.CreateParameter();
				secondaryMediaIDParam.ParameterName = ":SecondaryMediaID";
				if (quizEntry.SecondaryMediaID == null)
				{
					secondaryMediaIDParam.Value = DBNull.Value;
				}
				else
				{
					secondaryMediaIDParam.Value = quizEntry.SecondaryMediaID;
				}
				cmd.Parameters.Add(secondaryMediaIDParam);

				IDbDataParameter isSecondaryMediaCustomParam = cmd.CreateParameter();
				isSecondaryMediaCustomParam.ParameterName = ":IsSecondaryMediaCustom";
				isSecondaryMediaCustomParam.DbType = DbType.Boolean;
				isSecondaryMediaCustomParam.Value = quizEntry.IsSecondaryMediaCustom;
				cmd.Parameters.Add(isSecondaryMediaCustomParam);

				IDbDataParameter sortOrderParam = cmd.CreateParameter();
				sortOrderParam.ParameterName = ":SortOrder";
				sortOrderParam.Value = quizEntry.SortOrder;
				cmd.Parameters.Add(sortOrderParam);

				int alternateIndex = 0;
				foreach (int alternateThingID in quizEntry.AlternateThings)
				{
					IDbDataParameter altThingParam = cmd.CreateParameter();
					altThingParam.ParameterName = ":AltThing" + Convert.ToString(++alternateIndex);
					altThingParam.Value = alternateThingID;
					cmd.Parameters.Add(altThingParam);
				}

				// Set default parameter value for any alternates not already defined
				for (alternateIndex++; alternateIndex <= 4; alternateIndex++)
				{
					IDbDataParameter altThingParam = cmd.CreateParameter();
					altThingParam.ParameterName = ":AltThing" + Convert.ToString(alternateIndex);
					altThingParam.Value = 0;
					cmd.Parameters.Add(altThingParam);
				}

				IDbDataParameter responseParam = cmd.CreateParameter();
				responseParam.ParameterName = ":Response";
				if (quizEntry.Response == null)
				{
					responseParam.Value = DBNull.Value;
				}
				else
				{
					responseParam.Value = quizEntry.Response;
				}
				cmd.Parameters.Add(responseParam);

				conn.Open();
				cmd.ExecuteNonQuery();

				quizEntry.ID = ApplicationSettings.GetIdentityValue(conn);
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

		protected void Update(QuizEntry quizEntry)
		{
			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE QuizEntries SET Answered=:Answered, ThingID=:ThingID, MediaID=:MediaID, IsMediaCustom=:IsMediaCustom, SecondaryMediaID=:SecondaryMediaID, IsSecondaryMediaCustom=:IsSecondaryMediaCustom, SortOrder=:SortOrder, AltThing1=:AltThing1, AltThing2=:AltThing2, AltThing3=:AltThing3, AltThing4=:AltThing4, Response=:Response WHERE QuizEntryID=:QuizEntryID";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter answeredParam = cmd.CreateParameter();
				answeredParam.ParameterName = ":Answered";
				if (quizEntry.Answered == null)
				{
					answeredParam.Value = DBNull.Value;
				}
				else
				{
					answeredParam.Value = quizEntry.Answered;
				}
				cmd.Parameters.Add(answeredParam);

				IDbDataParameter thingIDParam = cmd.CreateParameter();
				thingIDParam.ParameterName = ":ThingID";
				thingIDParam.Value = quizEntry.ThingID;
				cmd.Parameters.Add(thingIDParam);

				IDbDataParameter mediaIDParam = cmd.CreateParameter();
				mediaIDParam.ParameterName = ":MediaID";
				if (quizEntry.MediaID == null)
				{
					mediaIDParam.Value = DBNull.Value;
				}
				else
				{
					mediaIDParam.Value = quizEntry.MediaID;
				}
				cmd.Parameters.Add(mediaIDParam);

				IDbDataParameter isMediaCustomParam = cmd.CreateParameter();
				isMediaCustomParam.ParameterName = ":IsMediaCustom";
				isMediaCustomParam.DbType = DbType.Boolean;
				isMediaCustomParam.Value = quizEntry.IsMediaCustom;
				cmd.Parameters.Add(isMediaCustomParam);

				IDbDataParameter secondaryMediaIDParam = cmd.CreateParameter();
				secondaryMediaIDParam.ParameterName = ":SecondaryMediaID";
				if (quizEntry.SecondaryMediaID == null)
				{
					secondaryMediaIDParam.Value = DBNull.Value;
				}
				else
				{
					secondaryMediaIDParam.Value = quizEntry.SecondaryMediaID;
				}
				cmd.Parameters.Add(secondaryMediaIDParam);

				IDbDataParameter isSecondaryMediaCustomParam = cmd.CreateParameter();
				isSecondaryMediaCustomParam.ParameterName = ":IsSecondaryMediaCustom";
				isSecondaryMediaCustomParam.DbType = DbType.Boolean;
				isSecondaryMediaCustomParam.Value = quizEntry.IsSecondaryMediaCustom;
				cmd.Parameters.Add(isSecondaryMediaCustomParam);

				IDbDataParameter sortOrderParam = cmd.CreateParameter();
				sortOrderParam.ParameterName = ":SortOrder";
				sortOrderParam.Value = quizEntry.SortOrder;
				cmd.Parameters.Add(sortOrderParam);

				int alternateIndex = 0;
				foreach (int alternateThingID in quizEntry.AlternateThings)
				{
					IDbDataParameter altThingParam = cmd.CreateParameter();
					altThingParam.ParameterName = ":AltThing" + Convert.ToString(++alternateIndex);
					altThingParam.Value = alternateThingID;
					cmd.Parameters.Add(altThingParam);
				}

				// Set default parameter value for any alternates not already defined
				for (alternateIndex++; alternateIndex <= 4; alternateIndex++)
				{
					IDbDataParameter altThingParam = cmd.CreateParameter();
					altThingParam.ParameterName = ":AltThing" + Convert.ToString(alternateIndex);
					altThingParam.Value = 0;
					cmd.Parameters.Add(altThingParam);
				}

				IDbDataParameter responseParam = cmd.CreateParameter();
				responseParam.ParameterName = ":Response";
				if (quizEntry.Response == null)
				{
					responseParam.Value = DBNull.Value;
				}
				else
				{
					responseParam.Value = quizEntry.Response;
				}
				cmd.Parameters.Add(responseParam);

				IDbDataParameter quizEntryIDParam = cmd.CreateParameter();
				quizEntryIDParam.ParameterName = ":QuizEntryID";
				quizEntryIDParam.Value = quizEntry.ID;
				cmd.Parameters.Add(quizEntryIDParam);

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
	}
}
