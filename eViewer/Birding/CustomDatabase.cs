using System;
using System.Collections.Generic;
using System.Text;
using Ionic.Zip;
using System.IO;
using System.Data;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class CustomDatabase
	{
		public static void Import(string fileName)
		{
			// Define temporary path to place extracted files
			string tempImportPath = Path.Combine(ApplicationSettings.TemporaryDirectory, "Import");
			if (Directory.Exists(tempImportPath))
			{
				Directory.Delete(tempImportPath, true);
			}

			// Extract all files to temporary directory
			using (ZipFile zip = ZipFile.Read(fileName))
			{
				zip.ExtractAll(tempImportPath);
			}

			// Copy all media files to application CustomMedia folder
			DirectoryInfo sourcePath = new DirectoryInfo(Path.Combine(tempImportPath, "CustomMedia"));
			DirectoryInfo destinationPath = new DirectoryInfo(ApplicationSettings.CustomMediaPath);
			CopyDirectory(sourcePath, destinationPath, true);

			// Copy database records
			bool failed = true;
			IDbConnection connImport = null;
			IDbConnection conn = null;
			IDbTransaction trans = null;
			try
			{
				// Open connection to the database to import
				string importDatabase = Path.Combine(tempImportPath, "Database");
				importDatabase = Path.Combine(importDatabase, "CustomDatabase.mdb");
				bool isDatabaseNewFormat = IsDatabaseNewFormat(importDatabase);
				connImport = ApplicationSettings.CreateConnection(importDatabase);
				connImport.Open();

				// Open connection and start transaction to user's custom database
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();
				trans = conn.BeginTransaction();

				// Import the database data
				Dictionary<int, int> mediaIDMapping = ImportMedia(connImport, trans, isDatabaseNewFormat);
				Dictionary<int, int> customThingIDMapping = ImportCustomThings(connImport, trans);
				ImportCustomThingMedia(connImport, trans, customThingIDMapping, mediaIDMapping);
				ImportThingMedia(connImport, trans, mediaIDMapping);
				Dictionary<int, int> categoryIDMapping = ImportQuizCategories(connImport, trans);
				Dictionary<int, int> quizIDMapping = ImportQuizzes(connImport, trans, categoryIDMapping);
				ImportQuizCustomThing(connImport, trans, quizIDMapping, customThingIDMapping);
				ImportCategoryCustomThing(connImport, trans, categoryIDMapping, customThingIDMapping);

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

				if (connImport != null)
				{
					connImport.Close();
				}

				// Cleanup extracted files
				if (Directory.Exists(tempImportPath))
				{
					Directory.Delete(tempImportPath, true);
				}
			}
		}

		public static void Update(string newDatabaseVersion)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				// Open connection and start transaction to user's custom database
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();
				trans = conn.BeginTransaction();

				UpdateVersion(newDatabaseVersion, trans);
				UpdateSchema(trans);

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

		private static void CopyDirectory(DirectoryInfo sourcePath, DirectoryInfo destinationPath, bool recursive)
		{
			if (!destinationPath.Exists)
			{
				destinationPath.Create();
			}

			// Copy files 
			foreach (FileInfo fi in sourcePath.GetFiles())
			{
				fi.CopyTo(Path.Combine(destinationPath.FullName, fi.Name), true);
			}

			// Copy directories 
			if (recursive)
			{
				foreach (DirectoryInfo di in sourcePath.GetDirectories())
				{
					CopyDirectory(di, new DirectoryInfo(Path.Combine(destinationPath.FullName, di.Name)), recursive);
				}
			}
		}

		private static bool IsDatabaseNewFormat(string databasePath)
		{
			bool isDatabaseNewFormat = false;

			string databaseVersion = MdfDM.Instance.GetDatabaseVersion(databasePath);
			isDatabaseNewFormat = databaseVersion.StartsWith("7.5");

			return isDatabaseNewFormat;
		}

		private static Dictionary<int, int> ImportMedia(IDbConnection conn, IDbTransaction trans, bool isDatabaseNewFormat)
		{
			Dictionary<int, int> originalNewIDMapping = new Dictionary<int, int>();

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				StringBuilder commandText = new StringBuilder("SELECT Media.ID, Media.Type, Media.FileName, Media.Caption");
				if (isDatabaseNewFormat)
				{
					commandText.Append(", Media.OwnerName");
				}
				commandText.Append(" FROM Media");
				cmd.CommandText = commandText.ToString();
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomMedia media = new CustomMedia();
					media.ID = reader.GetInt32(0);
					media.Type = reader.GetString(1);
					media.FileName = reader.GetString(2);
					media.Caption = reader.GetString(3);
					if (isDatabaseNewFormat)
					{
						media.Owner = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
					}

					// Keep track of the original ID
					int originalID = media.ID;

					// Save into user's database
					media.ID = 0;
					media.OriginalPath = Path.GetDirectoryName(Path.Combine(ApplicationSettings.CustomMediaPath, media.Path));
					media.Save(trans);

					// Keep track of original and new ID mapping
					originalNewIDMapping.Add(originalID, media.ID);
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

			return originalNewIDMapping;
		}

		private static Dictionary<int, int> ImportCustomThings(IDbConnection conn, IDbTransaction trans)
		{
			Dictionary<int, int> originalNewIDMapping = new Dictionary<int, int>();

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomThing.ID, CustomThing.Name, CustomThing.AlternateName FROM CustomThing";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomThing thing = new CustomThing();
					thing.ID = reader.GetInt32(0);
					thing.Name = reader.GetString(1);
					thing.AlternateName = reader.GetString(2);

					// Keep track of the original ID
					int originalID = thing.ID;

					// Save into user's database
					thing.ID = 0;
					thing.Save(trans);

					// Keep track of original and new ID mapping
					originalNewIDMapping.Add(originalID, thing.ID);
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

			return originalNewIDMapping;
		}

		private static void ImportCustomThingMedia(IDbConnection conn, IDbTransaction trans, Dictionary<int, int> customThingIDMapping, Dictionary<int, int> mediaIDMapping)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CustomThingMedia.CustomThingID, CustomThingMedia.MediaID, CustomThingMedia.[Order] FROM CustomThingMedia";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int customThingID = reader.GetInt32(0);
					int mediaID = reader.GetInt32(1);
					int order = reader.GetInt32(2);

					// Save into user's database
					CustomThingMediaDM.Instance.Save(customThingIDMapping[customThingID], mediaIDMapping[mediaID], order, trans);
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

		private static void ImportThingMedia(IDbConnection conn, IDbTransaction trans, Dictionary<int, int> mediaIDMapping)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT ThingMedia.ThingID, ThingMedia.MediaID, ThingMedia.[Order] FROM ThingMedia ORDER BY ThingID, [Order]";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int thingID = reader.GetInt32(0);
					int mediaID = reader.GetInt32(1);
					int order = reader.GetInt32(2);

					// Save into user's database
					ThingCustomMediaDM.Instance.Save(thingID, mediaIDMapping[mediaID], trans);
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

		private static Dictionary<int, int> ImportQuizCategories(IDbConnection conn, IDbTransaction trans)
		{
			Dictionary<int, int> originalNewIDMapping = new Dictionary<int, int>();

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT QuizCategory.ID, QuizCategory.Name FROM QuizCategory";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomQuizCategory category = new CustomQuizCategory();
					category.ID = reader.GetInt32(0);
					category.Name = reader.GetString(1);

					// Keep track of the original ID
					int originalID = category.ID;

					// Check for existing category with the same name
					CustomQuizCategory existingCategory = CustomQuizCategory.GetByName(category.Name);
					if (existingCategory != null)
					{
						// Use existing category
						category = existingCategory;
					}
					else
					{
						// Save into user's database
						category.ID = 0;
						category.Save(trans);
					}

					// Keep track of original and new ID mapping
					originalNewIDMapping.Add(originalID, category.ID);
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

			return originalNewIDMapping;
		}

		private static Dictionary<int, int> ImportQuizzes(IDbConnection conn, IDbTransaction trans, Dictionary<int, int> categoryIDMapping)
		{
			Dictionary<int, int> originalNewIDMapping = new Dictionary<int, int>();

			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT Quiz.ID, Quiz.Name, Quiz.Author, Quiz.CategoryID FROM Quiz";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CustomQuiz quiz = new CustomQuiz();
					quiz.ID = reader.GetInt32(0);
					quiz.Name = reader.GetString(1);
					quiz.Author = reader.GetString(2);
					quiz.CategoryID = reader.GetInt32(3);

					// Keep track of the original ID
					int originalID = quiz.ID;

					// Save into user's database
					quiz.ID = 0;
					quiz.CategoryID = categoryIDMapping[quiz.CategoryID];
					quiz.Save(trans);

					// Keep track of original and new ID mapping
					originalNewIDMapping.Add(originalID, quiz.ID);
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

			return originalNewIDMapping;
		}

		private static void ImportQuizCustomThing(IDbConnection conn, IDbTransaction trans, Dictionary<int, int> quizIDMapping, Dictionary<int, int> customThingIDMapping)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT QuizCustomThing.QuizID, QuizCustomThing.CustomThingID FROM QuizCustomThing";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int quizID = reader.GetInt32(0);
					int customThingID = reader.GetInt32(1);

					// Save into user's database
					CustomQuizThingDM.Instance.Save(quizIDMapping[quizID], customThingIDMapping[customThingID], trans);
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

		private static void ImportCategoryCustomThing(IDbConnection conn, IDbTransaction trans, Dictionary<int, int> categoryIDMapping, Dictionary<int, int> customThingIDMapping)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CategoryCustomThing.CategoryID, CategoryCustomThing.CustomThingID FROM CategoryCustomThing";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int categoryID = reader.GetInt32(0);
					int customThingID = reader.GetInt32(1);

					// Save into user's database
					CustomQuizCategoryThingDM.Instance.Save(categoryIDMapping[categoryID], customThingIDMapping[customThingID], trans);
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

		private static void UpdateVersion(string databaseVersion, IDbTransaction trans)
		{
			MdfDM.Instance.Save(databaseVersion, trans);
		}

		private static void UpdateSchema(IDbTransaction trans)
		{
			IDbCommand cmd = null;
			IDataReader reader = null;

			try
			{
				cmd = trans.Connection.CreateCommand();
				cmd.Transaction = trans;
				// NOTE: This is NOT compatible with Sqlite, but custom functionality is not implemented on the Mac.
				cmd.CommandText = "ALTER TABLE Media ADD COLUMN OwnerName TEXT(70)";
				cmd.CommandType = CommandType.Text;
				cmd.ExecuteNonQuery();
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
	}
}
