using Ionic.Zip;
using System.IO;

namespace Thayer.Birding
{
	public class BackupRestore
	{
		public static void Backup(string fileName, bool includeCustomData)
		{
			using (ZipFile zip = new ZipFile())
			{
				ZipEntry databaseZipDirectory = zip.AddDirectoryByName("Database");
				zip.AddFile(ApplicationSettings.DatabaseName, databaseZipDirectory.FileName);

				if (includeCustomData)
				{
					zip.AddFile(ApplicationSettings.CustomDatabaseName, databaseZipDirectory.FileName);

					ZipEntry customMediaZipDirectory = zip.AddDirectoryByName("CustomMedia");
					zip.AddDirectory(ApplicationSettings.CustomMediaPath, customMediaZipDirectory.FileName);
				}

				zip.Save(fileName);
			}
		}

		public static void Restore(IDatabaseUpdater databaseUpdater, string fileName, bool includeCustomData)
		{
			// Determine if the file is a backup or database file
			if (ZipFile.IsZipFile(fileName))
			{
				RestoreBackupFile(databaseUpdater, fileName, includeCustomData);
			}
			else
			{
				RestoreDatabase(databaseUpdater, fileName);
			}
		}

		public static bool HasCustomData(string fileName)
		{
			bool hasCustomData = false;

			if (ZipFile.IsZipFile(fileName))
			{
				using (ZipFile zip = ZipFile.Read(fileName))
				{
					foreach (string entry in zip.EntryFileNames)
					{
						if (entry.StartsWith("CustomMedia"))
						{
							hasCustomData = true;
							break;
						}
					}
				}
			}

			return hasCustomData;
		}

		private static void RestoreBackupFile(IDatabaseUpdater databaseUpdater, string fileName, bool includeCustomData)
		{
			// Define temporary path to place extracted files
			string tempRestorePath = Path.Combine(ApplicationSettings.TemporaryDirectory, "Restore");

			try
			{
				// Cleanup temporary directory if it exists
				if (Directory.Exists(tempRestorePath))
				{
					Directory.Delete(tempRestorePath, true);
				}

				// Create the temporary directory
				Directory.CreateDirectory(tempRestorePath);

				// Extract all files to temporary directory
				using (ZipFile zip = ZipFile.Read(fileName))
				{
					if (includeCustomData)
					{
						zip.ExtractAll(tempRestorePath);
					}
					else
					{
						// Only extract the main database file
						zip.Extract(string.Format("Database/{0}", Path.GetFileName(ApplicationSettings.DatabaseName)), tempRestorePath);
					}
				}

				// Restore the main eViewer database file
				string backupDatabaseFileName = Path.Combine(Path.Combine(tempRestorePath, "Database"), Path.GetFileName(ApplicationSettings.DatabaseName));
				RestoreDatabase(databaseUpdater, backupDatabaseFileName);

				if (includeCustomData)
				{
					// Restore the custom database by copying file.  This will overwrite any changes since the backup.
					string backupCustomDatabaseFileName = Path.Combine(Path.Combine(tempRestorePath, "Database"), Path.GetFileName(ApplicationSettings.CustomDatabaseName));
					if (File.Exists(backupCustomDatabaseFileName))
					{
						File.Copy(backupCustomDatabaseFileName, ApplicationSettings.CustomDatabaseName, true);
					}

					// Copy all media files to application CustomMedia folder
					DirectoryInfo sourceCustomMediaPath = new DirectoryInfo(Path.Combine(tempRestorePath, "CustomMedia"));
					if (Directory.Exists(sourceCustomMediaPath.FullName))
					{
						DirectoryInfo destinationCustomMediaPath = new DirectoryInfo(ApplicationSettings.CustomMediaPath);
						CopyDirectory(sourceCustomMediaPath, destinationCustomMediaPath, true);
					}
				}
			}
			finally
			{
				// Cleanup temporary directory
				if (Directory.Exists(tempRestorePath))
				{
					Directory.Delete(tempRestorePath, true);
				}
			}
		}

		private static void RestoreDatabase(IDatabaseUpdater databaseUpdater, string fileName)
		{
			databaseUpdater.UpgradeFromPreviousVersion(fileName);
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
	}
}
