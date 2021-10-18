using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.DataUpdates
{
	public class DatabaseUpdates : IDatabaseUpdater
	{
		private enum DatabaseVersion
		{
			Unknown,
			Version3_0,
			Version3_1,
			Version3_5,
			Version3_9,
			Version4_0,
			Version5_0,
			Version4_1,
			Version5_1,
			Version4_5,
			Version5_5,
			Version7_0,
			Version7_5,
			Version7_7
        }

		private Dictionary<int, int> customListIDs = null;
		private Dictionary<int, int> observerIDs = null;
		private Dictionary<int, int> oldThingIDMapping = null;

		public DatabaseUpdates()
		{
		}

		public void UpgradeFromPreviousVersion(string originalDatabase)
		{
			if (File.Exists(originalDatabase))
			{
				string versionString = ApplicationSettings.GetDatabaseVersion(originalDatabase);
				DatabaseVersion databaseVersion = GetDatabaseVersion(versionString);
				if (IsUpgradable(databaseVersion))
				{
					string previousDatabase = ApplicationSettings.DatabaseName + ".pre";
					if (File.Exists(previousDatabase))
					{
						File.Delete(previousDatabase);
					}

					File.Copy(originalDatabase, previousDatabase);

					try
					{
						UpgradeDatabase(previousDatabase, databaseVersion);
					}
					finally
					{
						File.Delete(previousDatabase);
					}
				}
				else
				{
					// Throw exception
					StringBuilder message = new StringBuilder("The selected Thayer Birding Software eField Guide Viewer ");
					message.Append("database file has a version of ");
					message.Append(versionString);
					message.Append(", which is not supported by the import process.  The supported versions are ");
		
					OperatingSystem operatingSystem = ApplicationSettings.OperatingSystem;
					if (operatingSystem == OperatingSystem.Windows)
					{
						message.Append("3.0.x, 3.1.x, 3.5.x, 3.9.x, 4.0.x, 4.1.x, 4.5.x, 5.0.x, 5.1.x, 5.5.x, 7.0.x, 7.5.x and 7.7.x");
					}
					else if (operatingSystem == OperatingSystem.MacOSX)
					{
						message.Append("3.9.x, 4.0.x, 4.1.x, 4.5.x, 7.0.x, 7.5.x and 7.7.x");
					}

					throw new DatabaseUpdateException(message.ToString());
				}
			}
		}

		private DatabaseVersion GetDatabaseVersion(string versionString)
		{
			DatabaseVersion version = DatabaseVersion.Unknown;

            if (versionString.StartsWith("3.0"))
            {
                version = DatabaseVersion.Version3_0;
            }
            else if (versionString.StartsWith("3.1"))
            {
                version = DatabaseVersion.Version3_1;
            }
            else if (versionString.StartsWith("3.5"))
            {
                version = DatabaseVersion.Version3_5;
            }
            else if (versionString.StartsWith("3.9"))
            {
                version = DatabaseVersion.Version3_9;
            }
            else if (versionString.StartsWith("4.0"))
            {
                version = DatabaseVersion.Version4_0;
            }
            else if (versionString.StartsWith("5.0"))
            {
                version = DatabaseVersion.Version5_0;
            }
            else if (versionString.StartsWith("4.1"))
            {
                version = DatabaseVersion.Version4_1;
            }
            else if (versionString.StartsWith("5.1"))
            {
                version = DatabaseVersion.Version5_1;
            }
            else if (versionString.StartsWith("4.5"))
            {
                version = DatabaseVersion.Version4_5;
            }
            else if (versionString.StartsWith("5.5"))
            {
                version = DatabaseVersion.Version5_5;
            }
			else if (versionString.StartsWith("7.0"))
			{
				version = DatabaseVersion.Version7_0;
			}
			else if (versionString.StartsWith("7.5"))
			{
				version = DatabaseVersion.Version7_5;
			}
			else if (versionString.StartsWith("7.7"))
			{
				version = DatabaseVersion.Version7_7;
			}
			else
			{
                version = DatabaseVersion.Unknown;
            }

			return version;
		}

		private bool IsUpgradable(DatabaseVersion version)
		{
			bool isUpgradable = false;

			OperatingSystem operatingSystem = ApplicationSettings.OperatingSystem;
			if (operatingSystem == OperatingSystem.Windows)
			{
				switch (version)
				{
					case DatabaseVersion.Version3_0:
					case DatabaseVersion.Version3_1:
					case DatabaseVersion.Version3_5:
					case DatabaseVersion.Version3_9:
					case DatabaseVersion.Version4_0:
					case DatabaseVersion.Version4_1:
					case DatabaseVersion.Version4_5:
					case DatabaseVersion.Version5_0:
					case DatabaseVersion.Version5_1:
					case DatabaseVersion.Version5_5:
					case DatabaseVersion.Version7_0:
					case DatabaseVersion.Version7_5:
					case DatabaseVersion.Version7_7:
						isUpgradable = true;
						break;
					default:
						isUpgradable = false;
						break;
				}
			}
			else if (operatingSystem == OperatingSystem.MacOSX)
			{
				switch (version)
				{
					case DatabaseVersion.Version3_9:
					case DatabaseVersion.Version4_0:
					case DatabaseVersion.Version4_1:
					case DatabaseVersion.Version4_5:
					case DatabaseVersion.Version7_0:
					case DatabaseVersion.Version7_5:
					case DatabaseVersion.Version7_7:
						isUpgradable = true;
						break;
					default:
						isUpgradable = false;
						break;
				}
			}

			return isUpgradable;
		}

		private void UpgradeDatabase(string previousDatabase, DatabaseVersion previousDatabaseVersion)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(previousDatabase);
				conn.Open();
				trans = conn.BeginTransaction();

				SetThingIDMappings(previousDatabaseVersion);
				RestoreCustomLists(trans, previousDatabaseVersion);
				RestoreCustomListThings(trans, previousDatabaseVersion);
				RestoreNotes(trans, previousDatabaseVersion);
				RestoreObservers(trans, previousDatabaseVersion);
				RestoreSightings(trans, previousDatabaseVersion);
				RestoreHallOfFame(trans, previousDatabaseVersion);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		private bool IsUpdateAvailable(string currentDatabase, string previousDatabase)
		{
			bool isUpdateAvailable = false;

			if (File.Exists(previousDatabase))
			{
				if (ApplicationSettings.GetDatabaseVersion(previousDatabase) != ApplicationSettings.GetDatabaseVersion(currentDatabase))
				{
					isUpdateAvailable = true;
				}
			}

			return isUpdateAvailable;
		}

		private void SwitchFileLocations(string currentDatabase, string previousDatabase)
		{
			if (File.Exists(previousDatabase) && File.Exists(currentDatabase))
			{
				string tempFile = currentDatabase + ".temp";
				File.Move(currentDatabase, tempFile);
				File.Move(previousDatabase, currentDatabase);
				File.Move(tempFile, previousDatabase);
			}
		}

		public void UpdateCustom()
		{
			string currentDatabase = ApplicationSettings.CustomDatabaseName;
			string previousDatabase = ApplicationSettings.CustomDatabaseName + ".pre";

			if (IsUpdateAvailable(currentDatabase, previousDatabase))
			{
				// Switch the current and previous files because the custom database
				// update is going to be an in-place update of the existing database.
				SwitchFileLocations(currentDatabase, previousDatabase);

				// After switching file locations, the previous database location contains the new database
				string newDatabaseVersion = ApplicationSettings.GetDatabaseVersion(previousDatabase);

				// Update the existing custom database with any new version/schema information
				CustomDatabase.Update(newDatabaseVersion);

				// Cannot delete the file here due to Vista security.
				// File will now get deleted the next time a Check for Updates is run.
				// See IsUpdateAvailable() in UpdateDownloader.cs
				try
				{
					// Try deleting the file for the benefit of all other OS's
					File.Delete(previousDatabase);
				}
				catch (Exception ex)
				{
					// Exception should only happen on Vista due to access rights issues.
				}
			}
		}

		public void Update()
		{
			string currentDatabase = ApplicationSettings.DatabaseName;
			string previousDatabase = ApplicationSettings.DatabaseName + ".pre";

			if (IsUpdateAvailable(currentDatabase, previousDatabase))
			{
				UpdateDatabase(previousDatabase);

				// Cannot delete the file here due to Vista security.
				// File will now get deleted the next time a Check for Updates is run.
				// See IsUpdateAvailable() in UpdateDownloader.cs
				try
				{
					// Try deleting the file for the benefit of all other OS's
					File.Delete(previousDatabase);
				}
				catch (Exception ex)
				{
					// Exception should only happen on Vista due to access rights issues.
				}
			}
		}

		private void UpdateDatabase(string previousDatabase)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(previousDatabase);
				conn.Open();
				trans = conn.BeginTransaction();

				string versionString = ApplicationSettings.GetDatabaseVersion(previousDatabase);
				DatabaseVersion databaseVersion = GetDatabaseVersion(versionString);

				SetThingIDMappings(databaseVersion);
				RestoreCustomLists(trans, databaseVersion);
				RestoreCustomListThings(trans, databaseVersion);
				RestoreNotes(trans, databaseVersion);
				RestoreObservers(trans, databaseVersion);
				RestoreSightings(trans, databaseVersion);
				RestoreQuizEntries(trans, databaseVersion);
				RestoreHallOfFame(trans, databaseVersion);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		private void RestoreCustomLists(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			customListIDs = new Dictionary<int, int>();

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				StringBuilder sql = new StringBuilder();

				if (databaseVersion == DatabaseVersion.Version3_0)
				{
					// Version 3.0 database does not have the internal field
					sql.Append("SELECT CustomListID, Name, Author, Length, CollectionID, DateCreated, DateModified, Hide, TemporaryList FROM CustomLists WHERE Name<>'(Quick Save List)' AND Author<>'Thayer Birding Software' ORDER BY CustomListID");
				}
				else
				{
					// Need to check for null on internal field in sqlite on Mac
					sql.Append("SELECT CustomListID, Name, Author, Length, CollectionID, DateCreated, DateModified, Hide, TemporaryList, internal FROM CustomLists WHERE (internal=");
					sql.Append(ApplicationSettings.GetDBBooleanValue(false));
					sql.Append(" OR internal IS NULL)");
					sql.Append(" AND Name<>'(Quick Save List)' AND Author<>'Thayer Birding Software' ORDER BY CustomListID");
				}

				IDbConnection conn = trans.Connection;
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomList customList = new CustomList();
					int customListID = reader.GetInt32(0);
					customList.Name = reader.GetString(1);
					customList.Author = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					customList.Length = reader.GetInt32(3);
					customList.CollectionID = reader.GetInt32(4);
					customList.DateCreated = reader.GetDateTime(5);
					customList.DateModified = !reader.IsDBNull(6) ? (DateTime?)reader.GetDateTime(6) : null;

					if (customList.CollectionID != Collection.GuideToBirdsOfNorthAmerica)
					{
						// If user is licensed for Guide to Birds of North America, then import all custom lists to that collection (per Pete Thayer)
						if (ThayerLicenseManager.Instance.Licenses.ContainsProduct(new Product(Product.GuideToBirdsOfNorthAmerica)))
						{
							customList.CollectionID = Collection.GuideToBirdsOfNorthAmerica;
						}
					}

					if (!customList.Exists())
					{
						customList.Save();
						customListIDs[customListID] = customList.ID;
					}
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
			}
		}

		private void RestoreCustomListThings(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				StringBuilder sql = new StringBuilder();

				if (databaseVersion == DatabaseVersion.Version3_0 || databaseVersion == DatabaseVersion.Version3_1)
				{
					sql.Append("SELECT CustomListID, ThingID FROM CustomListsThings ORDER BY CustomListID, CustomListEntryID");
				}
				else
				{
					sql.Append("SELECT CustomListID, ThingID FROM CustomListsThings ORDER BY CustomListID, [order], CustomListEntryID");
				}

				IDbConnection conn = trans.Connection;
				cmd = conn.CreateCommand();
				cmd.CommandText = sql.ToString();
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				int order = 0;
				int prevCustomListID = 0;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomListItem item = new CustomListItem();
					int oldID = reader.GetInt32(0);
					int newID;
					if (!customListIDs.TryGetValue(oldID, out newID))
					{
						continue;
					}

					if (newID != prevCustomListID)
					{
						order = 0;
						prevCustomListID = newID;
					}

					item.CustomListID = newID;
					item.Organism.ID = GetThingID(reader.GetInt32(1));

					// Check to make sure that the bird exists in the database before saving
					if (item.Organism.Exists)
					{
						item.Order = ++order;
						item.Save();
					}
					else
					{
						// Bird cannot be added, so update the custom list length accordingly
						CustomList customList = CustomList.GetByID(item.CustomListID);
						customList.Length--;
						customList.Save();
					}
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
			}
		}

		private void RestoreNotes(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			// Notes are not supported in version 3.0 and 3.1
			if (databaseVersion == DatabaseVersion.Version3_0 || databaseVersion == DatabaseVersion.Version3_1)
			{
				return;
			}

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				IDbConnection conn = trans.Connection;
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ThingID, Note FROM Notes ORDER BY ThingID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Note note = new Note();
					note.ThingID = GetThingID(reader.GetInt32(0));
					note.Text = reader.GetString(1);

					if (Organism.Exists(note.ThingID) && !note.Exists())
					{
						note.Save();
					}
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
			}
		}

		private void RestoreObservers(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			observerIDs = new Dictionary<int, int>();

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				IDbConnection conn = trans.Connection;
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ObserverID, FirstName, MI, LastName, Initials FROM Observers ORDER BY ObserverID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Observer observer = new Observer();
					int oldID = reader.GetInt32(0);

					observer.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
					observer.MiddleInitial = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
					observer.LastName = reader.GetString(3);
					observer.Initials = reader.GetString(4);

					Observer existingObserver = Observer.GetByName(observer.FirstName, observer.MiddleInitial, observer.LastName);
					if (existingObserver != null)
					{
						observerIDs[oldID] = existingObserver.ID;
					}
					else
					{
						observer.Save();
						observerIDs[oldID] = observer.ID;
					}
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
			}
		}

		private void RestoreSightings(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				IDbConnection conn = trans.Connection;
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ObserverID, ThingID, LocationID, DateAndTime, Comments FROM Sightings ORDER BY SightingID";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int oldObserverID = reader.GetInt32(0);

					Sighting sighting = new Sighting();
					sighting.Observer.ID = observerIDs[oldObserverID];
					sighting.Organism.ID = GetThingID(reader.GetInt32(1));
					sighting.Location.ID = reader.GetInt32(2);
					sighting.Date = reader.GetDateTime(3);
					sighting.Comments = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;

					if (Organism.Exists(sighting.Organism.ID) && !sighting.Exists())
					{
						sighting.Save();
					}
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
			}
		}

		private void RestoreQuizEntries(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				List<QuizEntry> quizEntries = new List<QuizEntry>();

				if (SupportsCustomMedia(databaseVersion))
				{
					IDbConnection conn = trans.Connection;
					cmd = conn.CreateCommand();
					cmd.CommandText = "SELECT Answered, ThingID, MediaID, IsMediaCustom, SecondaryMediaID, IsSecondaryMediaCustom, AltThing1, AltThing2, AltThing3, AltThing4, Response FROM QuizEntries ORDER BY SortOrder";
					cmd.CommandType = CommandType.Text;
					cmd.Transaction = trans;

					int sortOrder = 0;

					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						QuizEntry entry = new QuizEntry();
						entry.Answered = !reader.IsDBNull(0) ? reader.GetString(0) : null;
						entry.ThingID = GetThingID(reader.GetInt32(1));
						entry.MediaID = reader.GetInt32(2);
						entry.IsMediaCustom = reader.GetBoolean(3);
						entry.SecondaryMediaID = !reader.IsDBNull(4) ? (int?)reader.GetInt32(4) : null;
						entry.IsSecondaryMediaCustom = reader.GetBoolean(5);
						entry.SortOrder = ++sortOrder;
						entry.AlternateThings.Add(reader.GetInt32(6));
						entry.AlternateThings.Add(reader.GetInt32(7));
						entry.AlternateThings.Add(reader.GetInt32(8));
						entry.AlternateThings.Add(reader.GetInt32(9));
						entry.Response = !reader.IsDBNull(10) ? reader.GetString(10) : null;

						quizEntries.Add(entry);
					}
				}
				else
				{
					IDbConnection conn = trans.Connection;
					cmd = conn.CreateCommand();
					cmd.CommandText = "SELECT Answered, ThingID, MediaID, SecondaryMediaID, AltThing1, AltThing2, AltThing3, AltThing4, Response FROM QuizEntries ORDER BY SortOrder";
					cmd.CommandType = CommandType.Text;
					cmd.Transaction = trans;

					int sortOrder = 0;

					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						QuizEntry entry = new QuizEntry();
						entry.Answered = !reader.IsDBNull(0) ? reader.GetString(0) : null;
						entry.ThingID = GetThingID(reader.GetInt32(1));
						entry.MediaID = reader.GetInt32(2);
						// Custom media did not exist before v5.0, so set to false
						entry.IsMediaCustom = false;
						entry.SecondaryMediaID = !reader.IsDBNull(3) ? (int?)reader.GetInt32(3) : null;
						// Custom media did not exist before v5.0, so set to false
						entry.IsSecondaryMediaCustom = false;
						entry.SortOrder = ++sortOrder;
						entry.AlternateThings.Add(reader.GetInt32(4));
						entry.AlternateThings.Add(reader.GetInt32(5));
						entry.AlternateThings.Add(reader.GetInt32(6));
						entry.AlternateThings.Add(reader.GetInt32(7));
						entry.Response = !reader.IsDBNull(8) ? reader.GetString(8) : null;

						quizEntries.Add(entry);
					}
				}

				QuizEntry.Save(quizEntries);
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
			}
		}

		private void RestoreHallOfFame(IDbTransaction trans, DatabaseVersion databaseVersion)
		{
			// Hall of Fame is not supported in version 3.0
			if (databaseVersion == DatabaseVersion.Version3_0)
			{
				return;
			}

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				IDbConnection conn = trans.Connection;
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT [QuizName], [Name], [QuizType], [DifficultyLevel], [Language], [Date], [Score], [Max Possible] FROM [Hall Of Fame] ORDER BY [HOFid]";
				cmd.CommandType = CommandType.Text;
				cmd.Transaction = trans;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					HallOfFame hallOfFame = new HallOfFame();
					hallOfFame.QuizName = reader.GetString(0);
					hallOfFame.Name = reader.GetString(1);
					hallOfFame.QuizType = reader.GetString(2);
					hallOfFame.DifficultyLevel = reader.GetString(3);
					hallOfFame.Language = reader.GetString(4);
					hallOfFame.Date = reader.GetDateTime(5);
					hallOfFame.Score = reader.GetInt32(6);
					hallOfFame.MaxPossible = reader.GetInt32(7);

					if (!hallOfFame.Exists())
					{
						hallOfFame.Save();
					}
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
			}
		}

		private void SetThingIDMappings(DatabaseVersion databaseVersion)
		{
			// Only convert for versions prior to 3.9
			if ((int)databaseVersion < (int)DatabaseVersion.Version3_9)
			{
				// Create mapping of old thing ID's to new thing ID's
				oldThingIDMapping = new Dictionary<int, int>(6);

				// Great Egret
				oldThingIDMapping.Add(315, 19242);

				// Whimbrel
				oldThingIDMapping.Add(1554, 10136);

				// Wilson's Snipe
				oldThingIDMapping.Add(1601, 10131);

				// Northern Pygmy-Owl
				oldThingIDMapping.Add(2797, 2804);
				oldThingIDMapping.Add(2799, 2804);

				// Yellow Warbler
				oldThingIDMapping.Add(9351, 19813);
			}
			else
			{
				oldThingIDMapping = new Dictionary<int, int>();
			}
		}

		private int GetThingID(int oldThingID)
		{
			int newThingID;

			if (!oldThingIDMapping.TryGetValue(oldThingID, out newThingID))
			{
				newThingID = oldThingID;
			}

			return newThingID;
		}

        private bool SupportsCustomMedia(DatabaseVersion databaseVersion)
        {
            bool supportsCustomMedia = false;

            switch (databaseVersion)
            {
                case DatabaseVersion.Version5_0:
                case DatabaseVersion.Version5_1:
                case DatabaseVersion.Version5_5:
				case DatabaseVersion.Version7_0:
				case DatabaseVersion.Version7_5:
				case DatabaseVersion.Version7_7:
					supportsCustomMedia = true;
                    break;
            }

			return supportsCustomMedia;
        }
    }
}
