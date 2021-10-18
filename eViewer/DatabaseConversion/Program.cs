using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

using Mono.Data.SqliteClient;

namespace DatabaseConversion
{
	class Program
	{
		private static string[] tables = new string[] { "AliasCommonNames", "AliasLanguageRegion", "AnimatedRangeMap", "BandCodeList", "BandCodes", "Characteristics", "CheckList", "Class", "Classifications", "CollectionLocations", "Collections", "CollectionsQuiz", "CollectionThings", "CommonNames", "CustomLists", "CustomListsThings", "EBirdReference", "Family", "Genus", "Hall Of Fame", "Kingdom", "LanguageRegionList", "LocationDescendants", "LocationParents", "Locations", "MDF", "Media", "MediaDirectory", "MediaThings", "Notes", "Observers", "Order", "Owners", "Phyla", "Quiz", "QuizEntries", "Quizzes", "Recorders", "Sightings", "SimilarThings", "Species", "TaxonomyList", "ThingCharacteristics", "ThingsDescriptions", "WorldRangeMap" };

		static void Main(string[] args)
		{
			OleDbConnection accessConn = null;
			SqliteConnection sqliteConn = null;

			try
			{
				sqliteConn = new SqliteConnection("URI=file:Birding.db,version=3");
				sqliteConn.Open();

				accessConn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Projects\Thayer\v7.0\Database\database.mdb;");
				accessConn.Open();

				foreach (string table in tables)
				{
					SqliteCommand sqliteCmd = null;
					OleDbDataReader accessReader = null;
					OleDbCommand accessCmd = null;
					IDbTransaction trans = null;

					try
					{
						trans = sqliteConn.BeginTransaction();

						Console.WriteLine("Working on table: " + table);

						accessCmd = accessConn.CreateCommand();
						accessCmd.CommandText = "SELECT * FROM [" + table + "]";
						accessReader = accessCmd.ExecuteReader();

						sqliteCmd = sqliteConn.CreateCommand();

						StringBuilder insert = null;
						while (accessReader.Read())
						{
							if (insert == null)
							{
								insert = new StringBuilder("INSERT INTO [");
								insert.Append(table);
								insert.Append("] (");
								for (int i = 0; i < accessReader.FieldCount; i++)
								{
									if (i > 0)
									{
										insert.Append(",");
									}
									insert.Append("[");
									insert.Append(accessReader.GetName(i));
									insert.Append("]");
								}
								insert.Append(") VALUES (");
								for (int i = 0; i < accessReader.FieldCount; i++)
								{
									if (i > 0)
									{
										insert.Append(",");
									}
									insert.Append(GetParameterName(accessReader.GetName(i)));
								}
								insert.Append(")");
							}
							sqliteCmd.CommandText = insert.ToString();
							sqliteCmd.Parameters.Clear();
							for (int i = 0; i < accessReader.FieldCount; i++)
							{
								SqliteParameter param = sqliteCmd.CreateParameter();
								param.ParameterName = GetParameterName(accessReader.GetName(i));

								// Preserve NULL values
								if (accessReader[i] == DBNull.Value)
								{
									param.Value = DBNull.Value;
								}
								else
								{
									if (accessReader[i] is DateTime)
									{
										DateTime date = (DateTime)accessReader[i];
										param.Value = date.ToString("yyyy-MM-dd HH:mm:ss");
									}
									else
									{
										param.Value = Convert.ToString(accessReader[i]);
									}
								}
								sqliteCmd.Parameters.Add(param);
							}
							sqliteCmd.ExecuteNonQuery();
						}

						trans.Commit();
					}
					catch (Exception)
					{
						trans.Rollback();

						throw;
					}
					finally
					{
						if (sqliteCmd != null)
						{
							sqliteCmd.Dispose();
						}

						if (accessReader != null)
						{
							accessReader.Close();
						}

						if (accessCmd != null)
						{
							accessCmd.Dispose();
						}
					}
				}
			}
			finally
			{
				if (sqliteConn != null)
				{
					sqliteConn.Close();
				}

				if (accessConn != null)
				{
					accessConn.Close();
				}
			}
		}

		private static string GetParameterName(string fieldName)
		{
			string parameterName = ":" + fieldName;

			parameterName = parameterName.Replace("?", string.Empty);
			parameterName = parameterName.Replace(" ", string.Empty);

			return parameterName;
		}
	}
}
