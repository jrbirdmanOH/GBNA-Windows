using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Thayer.Birding.Updates;
using Thayer.Birding.Updates.Settings;

namespace Deploy
{
	public partial class DeploymentWizardForm : Form
	{
		private UserControl selectedPanel = null;
		private Manifest manifest = null;
		private IVersionInfoProvider versionInfoProvider = null;

		public DeploymentWizardForm()
		{
			InitializeComponent();

			string versionInfoProviderTypeString = ConfigurationManager.AppSettings["VersionInfoProvider"];
			if (versionInfoProviderTypeString != null)
			{
				Type versionInfoProviderType = Type.GetType(versionInfoProviderTypeString);
				if (versionInfoProviderType != null)
				{
//					versionInfoProvider = (IVersionInfoProvider)versionInfoProviderType.GetConstructor(Type.EmptyTypes).Invoke(null);
					string applicationPath = Assembly.GetEntryAssembly().Location;
					versionInfoProvider = (IVersionInfoProvider)versionInfoProviderType.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { applicationPath });
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			SelectedPanel = selectInputDirectoryPanel;
		}

		protected UserControl SelectedPanel
		{
			get
			{
				return selectedPanel;
			}

			set
			{
				if (selectedPanel != null)
				{
					selectedPanel.Visible = false;
				}
				value.Visible = true;

				selectedPanel = value;

				previousButton.Enabled = value != selectInputDirectoryPanel;
				nextButton.Enabled = value != selectOutputDirectoryPanel;
				finishButton.Enabled = value == selectOutputDirectoryPanel;
			}
		}

		private void previousButton_Click(object sender, EventArgs e)
		{
			if (SelectedPanel == fileListPanel)
			{
				SelectedPanel = selectInputDirectoryPanel;
			}
			else if (SelectedPanel == selectOutputDirectoryPanel)
			{
				SelectedPanel = fileListPanel;
			}
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				if (SelectedPanel == selectInputDirectoryPanel)
				{
					manifest = GenerateManifest(selectInputDirectoryPanel.SelectedPath);
					fileListPanel.Manifest = manifest;
					SelectedPanel = fileListPanel;
				}
				else if (SelectedPanel == fileListPanel)
				{
					SelectedPanel = selectOutputDirectoryPanel;
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private Manifest GenerateManifest(string directory)
		{
			Manifest manifest = null;

			if (Directory.Exists(directory))
			{
				manifest = new Manifest();

				GenerateManifestFiles(manifest, directory);
			}

			return manifest;
		}

		private void GenerateManifestFiles(Manifest manifest, string directory)
		{
			string[] directories = Directory.GetDirectories(directory);
			foreach (string directoryName in directories)
			{
				string[] directoryLevels = directoryName.Split(new char[] { Path.DirectorySeparatorChar });
				string name = directoryLevels[directoryLevels.Length - 1];
				if (name == BirdingAppSettings.ApplicationFilesDirectoryName)
				{
					GenerateManifestFiles(manifest, directoryName, directoryName, DestinationType.Application);
				}
				else if (name == BirdingAppSettings.ApplicationDataFilesDirectoryName)
				{
					GenerateManifestFiles(manifest, directoryName, directoryName, DestinationType.ApplicationData);
				}
				else if (name == BirdingAppSettings.SystemFilesDirectoryName)
				{
					GenerateManifestFiles(manifest, directoryName, directoryName, DestinationType.System);
				}
			}
		}

		private void GenerateManifestFiles(Manifest manifest, string root, string directory, DestinationType destinationType)
		{
			string prependDirectoryName = directory.Replace(root, string.Empty);
			if (prependDirectoryName.Length > 0 && prependDirectoryName[0] == Path.DirectorySeparatorChar)
			{
				prependDirectoryName = prependDirectoryName.Remove(0, 1);
			}

			string[] fileNames = Directory.GetFiles(directory);
			for (int i = 0; i < fileNames.Length; i++)
			{
				Application.DoEvents();

				FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(fileNames[i]);
				FileInfo fileInfo = new FileInfo(fileNames[i]);

				if ((fileInfo.Attributes & FileAttributes.System) == FileAttributes.System)
				{
					continue;
				}

				Thayer.Birding.Updates.File file = new Thayer.Birding.Updates.File();
				file.Name = Path.GetFileName(fileNames[i]);
				if (prependDirectoryName.Length > 0)
				{
					file.Name = Path.Combine(prependDirectoryName, file.Name);

					// Set the correct path separator for the target operating
					// system that the updates will be run on.
					file.Name = SetPathSeparator(file.Name);
				}

				file.Destination = destinationType;

				file.Action = FileAction.Copy;
				string fileVersion = null;
				if (versionInfoProvider != null)
				{
					fileVersion = versionInfoProvider.GetVersion(fileNames[i]);
				}
				else
				{
					fileVersion = versionInfo.FileVersion;
				}

				if (fileVersion != null)
				{
					file.Compare = CompareMethod.Version;
					file.Version = fileVersion.Replace(", ", ".");
				}
				else
				{
					file.Compare = CompareMethod.Date;
					file.Version = fileInfo.LastWriteTimeUtc.ToString("u");
				}

				file.Size = fileInfo.Length;
				manifest.Files.Add(file);
			}

			string[] directories = Directory.GetDirectories(directory);
			foreach (string directoryName in directories)
			{
				GenerateManifestFiles(manifest, root, directoryName, destinationType);
			}
		}

		private string SetPathSeparator(string path)
		{
			string updatedPath = path;

			if (BirdingAppSettings.TargetOperatingSystem == Thayer.Birding.Updates.OperatingSystem.Mac)
			{
				updatedPath = path.Replace(Path.DirectorySeparatorChar, '/');
			}

			return updatedPath;
		}

		private void finishButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				manifest.Save(Path.Combine(selectOutputDirectoryPanel.SelectedPath, "Manifest.xml"));

				foreach (Thayer.Birding.Updates.File file in manifest.Files)
				{
					Application.DoEvents();

					if (file.Action == FileAction.Copy)
					{
						string source = file.GetFullUpdatePath(selectInputDirectoryPanel.SelectedPath);
						string destination = file.GetFullUpdatePath(selectOutputDirectoryPanel.SelectedPath);

						FileInfo sourceFileInfo = new FileInfo(source);
						FileInfo destinationFileInfo = new FileInfo(destination);

						if (sourceFileInfo.LastWriteTimeUtc != destinationFileInfo.LastWriteTimeUtc ||
							sourceFileInfo.Length != destinationFileInfo.Length)
						{
							string destinationDirectory = Path.GetDirectoryName(destination);
							if (!Directory.Exists(destinationDirectory))
							{
								Directory.CreateDirectory(destinationDirectory);
							}
							System.IO.File.Copy(source, destination, true);
						}
					}
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}
	}
}