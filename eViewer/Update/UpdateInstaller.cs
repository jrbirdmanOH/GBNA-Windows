using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Updates
{
	public partial class UpdateInstaller : Component
	{
		public enum InstallResult
		{
			Successful,
			Error,
			Cancelled
		}

		private const string ProcessName = "eViewer";

		private readonly object eventLock = new object();
		private event EventHandler<FileInstallingEventArgs> fileInstalling;
		private event EventHandler<EventArgs> installComplete;

		private OperatingSystem os = OperatingSystem.Windows;
		private int? applicationProcessID = null;
		private string applicationName = string.Empty;

		public UpdateInstaller() : this(OperatingSystem.Windows)
		{
		}

		public UpdateInstaller(OperatingSystem os)
		{
			this.os = os;
		}

		public OperatingSystem OperatingSystem
		{
			get
			{
				return os;
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

		private string UpdateDirectory
		{
			get
			{
				return BirdingAppSettings.UpdateDirectory;
			}
		}

		public event EventHandler<FileInstallingEventArgs> FileInstalling
		{
			add
			{
				lock (eventLock)
				{
					fileInstalling += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					fileInstalling -= value;
				}
			}
		}

		public event EventHandler<EventArgs> InstallComplete
		{
			add
			{
				lock (eventLock)
				{
					installComplete += value;
				}
			}

			remove
			{
				lock (eventLock)
				{
					installComplete -= value;
				}
			}
		}

		protected void OnFileInstalling(FileInstallingEventArgs e)
		{
			EventHandler<FileInstallingEventArgs> temp = fileInstalling;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		protected void OnInstallComplete(EventArgs e)
		{
			EventHandler<EventArgs> temp = installComplete;

			if (temp != null)
			{
				temp(this, e);
			}
		}

		private bool IsApplicationRunning()
		{
			// Try stopping the eField Guide Viewer application if running
			if (StopApplication())
			{
				// Give the system time to update the processes list.  Without this pause,
				// the additional check below will report a false positive answer.
				Thread.Sleep(1000);
			}

			// Add additional check to make sure the application was stopped and is not running
			Process[] eViewerProcesses = Process.GetProcessesByName(ProcessName);

			return eViewerProcesses.Length > 0;
		}

		public InstallResult InstallUpdates(IRetryInstall retryInstall)
		{
			InstallResult result = InstallResult.Error;

			try
			{
				if (retryInstall != null)
				{
					if (this.OperatingSystem == OperatingSystem.Windows)
					{
						// On Windows, make sure the application is not running when installing
						while (IsApplicationRunning())
						{
							StringBuilder text = new StringBuilder("The update process has detected that the ");
							text.Append("eField Guide Viewer application is running or is in the process of ");
							text.Append("shutting down.  Please exit the application if it is still running ");
							text.Append("and click \"Retry\" to try installing again.");

							string caption = "Thayer Birding Software Update";

							if (!retryInstall.RetryInstall(text.ToString(), caption))
							{
								result = InstallResult.Cancelled;
								return result;
							}
						}
					}
				}
				
				Manifest manifest = Manifest.Load(Path.Combine(this.UpdateDirectory, "Manifest.xml"));

				string applicationDirectory = manifest.ApplicationDirectory;
				string sourceDirectory = manifest.UpdateDirectory;
				if (sourceDirectory == null || sourceDirectory.Length == 0)
				{
					sourceDirectory = Environment.CurrentDirectory;
				}

				int fileIndex = 1;
				int numFiles = manifest.Files.Count;

				foreach (Thayer.Birding.Updates.File file in manifest.Files)
				{
					string destination = file.FullPath;
					string destinationPath = Path.GetDirectoryName(destination);
					if (!Directory.Exists(destinationPath))
					{
						Directory.CreateDirectory(destinationPath);
					}
					string source = file.GetFullUpdatePath(sourceDirectory);
					switch (file.Action)
					{
						case FileAction.Copy:
							if (System.IO.File.Exists(source))
							{
								if (file.Retain)
								{
									FileInfo fileInfo = new FileInfo(destination);
									fileInfo.MoveTo(destination + ".pre");
								}

								if (this.OperatingSystem == OperatingSystem.Mac)
								{
									// Attempt to delete the destination file before
									// copying so that the owner will be the current
									// user and the SetLastWriteTimeUtc method call
									// will succeed on the Mac.  See note below.
									System.IO.File.Delete(destination);
								}
								
								System.IO.File.Copy(source, destination, true);
								FileInfo sourceFile = new FileInfo(source);

								// NOTE: On Mac OS X running Mono v1.2.6, calling SetLastWriteTimeUtc on a
								//       file where the current user is not the owner of the file will
								//       throw a System.IO.IOException with a message of "Invalid parameter"
								System.IO.File.SetLastWriteTimeUtc(destination, sourceFile.LastWriteTimeUtc);

								if (this.OperatingSystem == OperatingSystem.Windows)
								{
									// Support Vista virtualization
									if (Utility.IsVirtualized(file.StrippedName))
									{
										string virtualizedFileName = Utility.GetVirtualizedFileName(file.StrippedName);

										if (file.Retain)
										{
											FileInfo fileInfo = new FileInfo(virtualizedFileName);
											fileInfo.MoveTo(virtualizedFileName + ".pre");
										}
										System.IO.File.Copy(source, virtualizedFileName, true);
										System.IO.File.SetLastWriteTimeUtc(virtualizedFileName, sourceFile.LastWriteTimeUtc);
									}
								}
							}
							break;
						case FileAction.Delete:
							System.IO.File.Delete(destination);

							if (this.OperatingSystem == OperatingSystem.Windows)
							{
								// Support Vista virtualization
								System.IO.File.Delete(Utility.GetVirtualizedFileName(file.StrippedName));
							}
							break;
					}

					OnFileInstalling(new FileInstallingEventArgs(file.StrippedName, fileIndex, numFiles));
					fileIndex++;
				}

				result = InstallResult.Successful;
				OnInstallComplete(EventArgs.Empty);
			}
			catch (Exception ex)
			{
				result = InstallResult.Error;

				throw new UpdateException(ex.Message);
			}
			finally
			{
				Utility.DeleteDirectory(this.UpdateDirectory);
			}

			return result;
		}

		public void StartApplication()
		{
			// Don't start the application back up since it will always
			// be restarted with elevated privileges in Vista
/*
			if (this.ApplicationName != null)
			{
				Process process = new Process();
				process.StartInfo.WorkingDirectory = Path.GetDirectoryName(this.ApplicationName);
				process.StartInfo.FileName = this.ApplicationName;
				process.Start();
			}
*/
		}

		public bool StopApplication()
		{
			bool didStop = false;

			if (this.ApplicationProcessID != null)
			{
				// Get the running eField Guide Viewer process
				Process process = null;
				try
				{
					process = Process.GetProcessById(this.ApplicationProcessID.Value);
					didStop = StopProcess(process);
				}
				catch (ArgumentException)
				{
					// A running process does not exist for the specified process ID
				}
			}
			else
			{
				Process[] eViewerProcesses = Process.GetProcessesByName(ProcessName);
				foreach (Process process in eViewerProcesses)
				{
					if (StopProcess(process))
					{
						didStop = true;
					}
				}
			}

			return didStop;
		}

		private bool StopProcess(Process process)
		{
			bool didStop = false;

			// Close eField Guide Viewer if running
			if (process != null)
			{
				if (process.CloseMainWindow())
				{
					process.Close();
					didStop = true;
				}
			}

			return didStop;
		}
	}
}
