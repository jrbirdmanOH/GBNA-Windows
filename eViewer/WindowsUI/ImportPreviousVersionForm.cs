using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.DataUpdates;

namespace Thayer.Birding.UI.Windows
{
	public partial class ImportPreviousVersionForm : Form
	{
		public ImportPreviousVersionForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			SetImportButtonStatus();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			string fileName = GetDatabaseFileName();
			if (fileName.Length > 0)
			{
				databaseNameTextBox.Text = fileName;
			}
		}

		private void importButton_Click(object sender, EventArgs e)
		{
			try
			{
				bool includeCustomData = false;
				string backupFileName = databaseNameTextBox.Text;

				if (Path.GetExtension(backupFileName).ToLower() == ".zip")
				{
					if (BackupRestore.HasCustomData(backupFileName))
					{
						StringBuilder customDataMessage = new StringBuilder("This backup file contains custom data (My Media, My Quizzes, etc.).  Restoring the custom data will overwrite any custom data changes since the backup was created.  Would you like to restore the custom data?");
						customDataMessage.Append("\n\nClick \"Yes\" to restore the custom data.");
						customDataMessage.Append("\n\nClick \"No\" to only restore the application database (includes custom lists, sightings, observers, notes, and hall of fame entries).");
						customDataMessage.Append("\n\nClick \"Cancel\" to cancel the restore.");
						customDataMessage.Append("\n\nNOTE: Restoring a backup file with a large amount of custom data may take a few minutes.");
						DialogResult customDataDialogResult = MessageBox.Show(customDataMessage.ToString(), "eViewer Restore Backup", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (customDataDialogResult != DialogResult.Cancel)
						{
							includeCustomData = customDataDialogResult == DialogResult.Yes ? true : false;
						}
						else
						{
							return;
						}
					}
				}

				// Set wait cursor and disable buttons
				this.UseWaitCursor = true;
				restoringMessageLabel.Visible = true;
				databaseNameTextBox.Enabled = false;
				browseButton.Enabled = false;
				importButton.Enabled = false;
				importButton.Visible = false;
				cancelButton.Enabled = false;
				cancelButton.Visible = false;
				Application.DoEvents();

				IDatabaseUpdater databaseUpdater = new DatabaseUpdates();
				BackupRestore.Restore(databaseUpdater, backupFileName, includeCustomData);

				// Restore wait cursor and button state
				restoringMessageLabel.Visible = false;
				databaseNameTextBox.Enabled = true;
				browseButton.Enabled = true;
				importButton.Enabled = true;
				importButton.Visible = true;
				cancelButton.Enabled = true;
				cancelButton.Visible = true;
				this.UseWaitCursor = false;

				StringBuilder message = new StringBuilder("The eViewer backup file has been restored successfully.");
				message.Append("\n\nIt is recommended that you restart the application after restoring to ensure that the restored data is loaded.");
				message.Append("\n\nWould you like to restart the application now?");
				message.Append("\n\nClick \"Yes\" to restart the application.");
				message.Append("\nClick \"No\" to continue using the application without restarting.");
				DialogResult dialogResult = MessageBox.Show(message.ToString(), "eViewer Restore Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (dialogResult == DialogResult.Yes)
				{
					// Restart the application
					Application.Restart();
					Environment.Exit(0);
				}
				else
				{
					// Close the dialog box
					Close();
				}
			}
			catch (Exception ex)
			{
				this.UseWaitCursor = false;
				MessageBox.Show(string.Format("An error occurred restoring the eViewer backup file. {0}", ex.Message), "eViewer Restore Backup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				restoringMessageLabel.Visible = false;
				databaseNameTextBox.Enabled = true;
				browseButton.Enabled = true;
				importButton.Enabled = true;
				importButton.Visible = true;
				cancelButton.Enabled = true;
				cancelButton.Visible = true;
				this.UseWaitCursor = false;
			}
		}

		private void databaseNameTextBox_TextChanged(object sender, EventArgs e)
		{
			SetImportButtonStatus();
		}

		private void SetImportButtonStatus()
		{
			importButton.Enabled = File.Exists(databaseNameTextBox.Text);
		}

		private string GetDatabaseFileName()
		{
			string fileName = "";

			// Default to My Documents folder
			string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "eViewer Restore Backup";
			dialog.Filter = "eViewer Backup File (*.zip)|*.zip|eViewer Database File (*.mdb)|*.mdb";
			if (initialDirectory.Length > 0)
			{
				dialog.InitialDirectory = initialDirectory;
			}
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.Multiselect = false;
			dialog.ShowReadOnly = false;
			dialog.RestoreDirectory = true;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = dialog.FileName;
			}

			return fileName;
		}
	}
}