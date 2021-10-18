using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Updates
{
	public class UpdateDownloader : Component
	{
		private readonly object eventLock = new object();
		private EventHandler<FileDownloadingEventArgs> fileDownloading;
		private EventHandler<FileDownloadedEventArgs> fileDownloaded;
		private EventHandler<EventArgs> downloadComplete;
		private EventHandler<DownloadCompletedEventArgs> downloadCompleted;

		private OperatingSystem os = OperatingSystem.Windows;
		private string source = null;
		private int? applicationProcessID = null;
		private string applicationName = string.Empty;
		private Manifest manifest = null;
		private IVersionInfoProvider versionInfoProvider = null;
		private bool cancellationPending = false;

		private Dictionary<string, string> installerFiles = null;
		private const string DownloaderExecutable = "UpdateDownloader.exe";
		private const string InstallerExecutable = "UpdateInstaller.exe";
		private const string UpdateLibrary = "Thayer.Birding.Updates.dll";
		private const string VersionLibrary = "Thayer.Birding.Versioning.dll";
		private const int BufferLength = 4096;

		public UpdateDownloader() : this(OperatingSystem.Windows)
		{
		}

		public UpdateDownloader(OperatingSystem os)
		{
			this.os = os;

			switch (os)
			{
				case OperatingSystem.Mac:
					installerFiles = new Dictionary<string, string>(2);
					installerFiles[UpdateLibrary] = Path.Combine(BirdingAppSettings.ApplicationFilesDirectoryName, UpdateLibrary);
					installerFiles[VersionLibrary] = Path.Combine(BirdingAppSettings.ApplicationFilesDirectoryName, VersionLibrary);
					break;
				case OperatingSystem.Windows:
				default:
					installerFiles = new Dictionary<string, string>(4);
					installerFiles[DownloaderExecutable] = Path.Combine(BirdingAppSettings.ApplicationFilesDirectoryName, DownloaderExecutable);
					installerFiles[InstallerExecutable] = Path.Combine(BirdingAppSettings.ApplicationFilesDirectoryName, InstallerExecutable);
					installerFiles[UpdateLibrary] = Path.Combine(BirdingAppSettings.ApplicationFilesDirectoryName, UpdateLibrary);
					installerFiles[VersionLibrary] = Path.Combine(BirdingAppSettings.ApplicationFilesDirectoryName, VersionLibrary);
					break;
			}
		}

		public OperatingSystem OperatingSystem
		{
			get
			{
				return os;
			}
		}

		private Manifest Manifest
		{
			get
			{
				if (manifest == null)
				{
					manifest = GetManifest(true);
				}

				return manifest;
			}
		}

		public string Source
		{
			get
			{
				return source;
			}

			set
			{
				source = value;

				if (source != null && !source.EndsWith("/"))
				{
					source += "/";
				}
			}
		}

		public int? ApplicationProcessID
		{
			get
			{
				return applicationProcessID;
			}

			set
			{
				applicationProcessID = value;
			}
		}

		public string ApplicationName
		{
			get
			{
				return applicationName;
			}

			set
			{
				applicationName = value;
				if (applicationName != null && applicationName.Length > 0)
				{
					BirdingAppSettings.Init(applicationName);
				}
			}
		}

		public string ApplicationDirectory
		{
			get
			{
				return System.IO.Path.GetDirectoryName(this.ApplicationName);
			}
		}

		public string ApplicationDataDirectory
		{
			get
			{
				return BirdingAppSettings.AppDataPath;
			}
		}

		internal Uri ManifestLocation
		{
			get
			{
				return new Uri(source + "Manifest.xml");
			}
		}

		public string UpdateDirectory
		{
			get
			{
				return BirdingAppSettings.UpdateDirectory;
			}
		}

		[DefaultValue(null)]
		public IVersionInfoProvider VersionInfoProvider
		{
			get
			{
				return versionInfoProvider;
			}

			set
			{
				versionInfoProvider = value;
			}
		}

		public bool CancellationPending
		{
			get
			{
				return cancellationPending;
			}
		}

		public event EventHandler<EventArgs> DownloadComplete
		{
			add
			{
				lock (eventLock)
				{
					downloadComplete += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					downloadComplete -= value;
				}
			}
		}

		public event EventHandler<DownloadCompletedEventArgs> DownloadCompleted
		{
			add
			{
				lock (eventLock)
				{
					downloadCompleted += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					downloadCompleted -= value;
				}
			}
		}

		public event EventHandler<FileDownloadingEventArgs> FileDownloading
		{
			add
			{
				lock (eventLock)
				{
					fileDownloading += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					fileDownloading -= value;
				}
			}
		}

		public event EventHandler<FileDownloadedEventArgs> FileDownloaded
		{
			add
			{
				lock (eventLock)
				{
					fileDownloaded += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					fileDownloaded -= value;
				}
			}
		}

		public bool IsUpdateAvailable()
		{
			try
			{
				// Cleanup update directory when a check for updates is performed
				CleanupUpdateDirectory();

				// Delete previous database used for updates
				StringBuilder previousDatabase = new StringBuilder(BirdingAppSettings.DatabaseName);
				previousDatabase.Append(".pre");
				System.IO.File.Delete(previousDatabase.ToString());

				if (this.OperatingSystem == OperatingSystem.Windows)
				{
					// Support Vista virtualization
					string previousDatabaseFileName = Utility.GetVirtualizedFileName(BirdingAppSettings.DatabaseNameWithRelativePath + ".pre");
					if (System.IO.File.Exists(previousDatabaseFileName))
					{
						System.IO.File.Delete(previousDatabaseFileName);
					}
				}
			}
			catch (Exception ex)
			{
				// Not necessary to report an exception here
			}

			return Manifest.UpdateAvailable;
		}

		public void CleanupUpdateDirectory()
		{
			// Cleanup update directory
			Utility.DeleteDirectory(UpdateDirectory);
		}

		public void DownloadUpdates()
		{
			cancellationPending = false;

			Utility.DeleteDirectory(UpdateDirectory);

			if (!Directory.Exists(UpdateDirectory))
			{
				Directory.CreateDirectory(UpdateDirectory);
			}

			// Save the manifest to the download directory.
			Manifest.Save(Path.Combine(UpdateDirectory, "Manifest.xml"));

			try
			{
				DownloadInstallerFiles();

				// If the files that govern the update process requires an update,
				// don't download the other updates at this time.
				if (!InstallerRequiresUpdate)
				{
					DownloadFiles();
				}

				OnDownloadCompleted(new DownloadCompletedEventArgs(this.CancellationPending));

				// Needed to maintain backward compatibility
				OnDownloadComplete(EventArgs.Empty);
			}
			catch (FileNotFoundException)
			{
				throw new UpdateException("Update service not available.");
			}
		}

		public void CancelDownload()
		{
			cancellationPending = true;
		}

		public bool InstallerRequiresUpdate
		{
			get
			{
				bool requiresUpdate = false;

				foreach (string installerFile in installerFiles.Keys)
				{
					if (Manifest.RequiresUpdate(installerFile))
					{
						requiresUpdate = true;
						break;
					}
				}

				return requiresUpdate;
			}
		}

		private void DownloadFile(string fileName)
		{
			long totalBytes = 0;

			DownloadFile(fileName, 0, ref totalBytes);
		}

		private void DownloadFile(string fileName, long totalBytes, ref long bytesDownloaded)
		{
			WebRequest request = WebRequest.Create(Source + fileName.Replace('\\', '/'));
			string localPath = Path.Combine(UpdateDirectory, fileName);
			WebResponse response = null;
			FileStream localFile = null;

			try
			{
				if (!Directory.Exists(UpdateDirectory))
				{
					Directory.CreateDirectory(UpdateDirectory);
				}

				string directoryName = Path.GetDirectoryName(localPath);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}

				try
				{
					localFile = new FileStream(localPath, FileMode.Create);

					OnFileDownloading(new FileDownloadingEventArgs(fileName, bytesDownloaded, totalBytes));

					byte[] buffer = new byte[BufferLength];
					response = request.GetResponse();
					Stream stream = response.GetResponseStream();
					int bytesRead;
					do
					{
						if (this.CancellationPending)
						{
							return;
						}

						bytesRead = stream.Read(buffer, 0, buffer.Length);
						localFile.Write(buffer, 0, bytesRead);

						bytesDownloaded += bytesRead;

						OnFileDownloading(new FileDownloadingEventArgs(fileName, bytesDownloaded, totalBytes));
					}
					while (bytesRead > 0);
				}
				finally
				{
					if (localFile != null)
					{
						localFile.Close();
					}
				}

				OnFileDownloaded(new FileDownloadedEventArgs(fileName));
				System.IO.File.SetLastWriteTimeUtc(localPath, DateTime.Parse(response.Headers["Last-Modified"], CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					throw new FileNotFoundException(fileName + " could not be found.");
				}
				else
				{
					throw;
				}
			}
			finally
			{
				if (response != null)
				{
					response.Close();
				}
			}
		}

		private void DownloadInstallerFiles()
		{
			foreach (string installerFile in installerFiles.Values)
			{
				if (this.CancellationPending)
				{
					return;
				}

				DownloadFile(installerFile);
			}
		}

		private void DownloadFiles()
		{
			long bytes = 0;
			FileCollection files = manifest.UpdateFiles;
			long totalBytes = files.TotalBytes;
			foreach (File file in manifest.UpdateFiles)
			{
				if (this.CancellationPending)
				{
					return;
				}

				DownloadFile(file.StrippedNameWithDestinationPath, totalBytes, ref bytes);
			}
		}

		public void Install()
		{
			if (this.OperatingSystem == OperatingSystem.Windows)
			{
				StringBuilder arguments = new StringBuilder("\"");
				arguments.Append(this.ApplicationName);
				arguments.Append("\"");
				if (this.ApplicationProcessID != null)
				{
					arguments.Append(" ");
					arguments.Append(this.ApplicationProcessID.Value.ToString());
				}

				try
				{
					Process process = new Process();
					process.StartInfo.FileName = Path.Combine(UpdateDirectory, installerFiles[InstallerExecutable]);
					process.StartInfo.WorkingDirectory = Path.GetDirectoryName(process.StartInfo.FileName);
					process.StartInfo.Arguments = arguments.ToString();
					process.Start();
				}
				catch (System.ComponentModel.Win32Exception)
				{
					// User has cancelled the operation
				}
			}
		}

		protected virtual void OnDownloadComplete(EventArgs e)
		{
			EventHandler<EventArgs> temp = downloadComplete;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected virtual void OnDownloadCompleted(DownloadCompletedEventArgs e)
		{
			EventHandler<DownloadCompletedEventArgs> temp = downloadCompleted;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected virtual void OnFileDownloading(FileDownloadingEventArgs e)
		{
			EventHandler<FileDownloadingEventArgs> temp = fileDownloading;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected virtual void OnFileDownloaded(FileDownloadedEventArgs e)
		{
			EventHandler<FileDownloadedEventArgs> temp = fileDownloaded;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		private Manifest GetManifest(bool tryNewUpdateLocationOnFailure)
		{
			Manifest manifest = null;
			WebRequest request = WebRequest.Create(ManifestLocation);
			WebResponse response = null;

			try
			{
				response = request.GetResponse();
				manifest = Manifest.Load(response.GetResponseStream());
				manifest.ApplicationDirectory = ApplicationDirectory;
				manifest.ApplicationDataDirectory = ApplicationDataDirectory;
				manifest.UpdateDirectory = UpdateDirectory;
				manifest.VersionInfoProvider = VersionInfoProvider;
			}
			catch (Exception ex)
			{
				if (tryNewUpdateLocationOnFailure)
				{
					if (manifest == null)
					{
						// Transparently try new update location
						source = source.Replace("http://birding.lightshipinc.com", "http://updates.thayerbirding.com");
						manifest = GetManifest(false);
					}
					else
					{
						throw;
					}
				}
				else
				{
					throw;
				}
			}
			finally
			{
				if (response != null)
				{
					response.Close();
				}
			}

			return manifest;
		}
	}
}
