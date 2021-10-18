using System;
using System.IO;
using System.Text;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Updates
{
	internal class Utility
	{
		public static void DeleteDirectory(string directory)
		{
			if (Directory.Exists(directory))
			{
				string[] directories = Directory.GetDirectories(directory);
				foreach (string directoryName in directories)
				{
					DeleteDirectory(directoryName);
				}

				string[] files = Directory.GetFiles(directory);
				foreach (string file in files)
				{
					try
					{
						System.IO.File.Delete(file);
					}
					catch (UnauthorizedAccessException ex)
					{
						// There are cases where a file may be in use, but don't need to report error
					}
				}

				try
				{
					Directory.Delete(directory);
				}
				catch (IOException ex)
				{
					// There are cases where a directory may not be empty, but don't need to report error
				}
			}
		}

		public static string GetVirtualizedPath()
		{
			StringBuilder virtualPath = new StringBuilder();
			virtualPath.Append(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
			virtualPath.Append(Path.DirectorySeparatorChar);
			virtualPath.Append("VirtualStore");
			virtualPath.Append(Path.DirectorySeparatorChar);

			string applicationPath = BirdingAppSettings.ApplicationPath;
			applicationPath = Path.GetDirectoryName(applicationPath);
			if (Path.IsPathRooted(applicationPath))
			{
				applicationPath = applicationPath.Replace(Path.GetPathRoot(applicationPath), string.Empty);
			}
			virtualPath.Append(applicationPath);

			return virtualPath.ToString();
		}

		public static string GetVirtualizedFileName(string fileName)
		{
			return Path.Combine(GetVirtualizedPath(), fileName);
		}

		public static bool IsVirtualized(string fileName)
		{
			bool isVirtualized = false;

			if (System.IO.File.Exists(GetVirtualizedFileName(fileName)))
			{
				isVirtualized = true;
			}

			return isVirtualized;
		}
/*
		public static void WriteLogFileEntry(string logEntry)
		{
			using (StreamWriter writer = new StreamWriter("C:\\junk\\UpdateLog.txt", true))
			{
				writer.AutoFlush = true;
				writer.WriteLine(logEntry);
			}
		}
*/
	}
}
