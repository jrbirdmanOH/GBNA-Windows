using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Thayer.Birding.Versioning;
using Thayer.Birding.Updates.Settings;

namespace Thayer.Birding.Updates.Downloader
{
	public partial class DownloadForm : Form
	{
		private delegate bool CheckForUpdates();
		private delegate void CheckForUpdatesCompletedCallback(bool result);
		private delegate void FileDownloadingCallback(object sender, FileDownloadingEventArgs e);
		private delegate void DisplayUpdateErrorCallback(string message);

		private Thread updateThread = null;
		private bool installUpdates = false;
		private bool updatesDownloaded = false;
		private bool balloonTipShown = false;


		public DownloadForm()
		{
			InitializeComponent();
		}

		public bool InstallUpdates
		{
			get
			{
				return installUpdates;
			}
		}

		internal UpdateDownloader Downloader
		{
			get
			{
				return downloader;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Don't show in taskbar - can't toggle ShowInTaskbar state or modality of MessageBox is lost
			this.ShowInTaskbar = false;

			checkForUpdatesPictureBox.Image = Properties.Resources.Search;
			checkForUpdatesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			availableUpdatesPictureBox.Image = Properties.Resources.UpdateDownloader;
			availableUpdatesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			downloadPictureBox.Image = Properties.Resources.FileCopy;
			downloadPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			installPictureBox.Image = Properties.Resources.eViewer;
			installPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			checkForUpatesPanel.Visible = true;
			updatesAvailablePanel.Visible = false;
			downloadUpdatesPanel.Visible = false;
			installPanel.Visible = false;

			installButton.Visible = false;
			installButton.Enabled = false;
			installToolStripMenuItem.Enabled = false;

			// Activate the form so it is shown and has focus
			this.Activate();

			// Start checking for updates
			StartUpdate();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			if (updateThread != null)
			{
				updateThread.Abort();
			}
		}

		private void StartUpdate()
		{
			downloader.Source = BirdingAppSettings.UpdateLocation;
			downloader.VersionInfoProvider = new BirdingVersionProvider(downloader.ApplicationName);

			notifyIcon.Text = "Checking for updates...";

			CheckForUpdates checkForUpdates = new CheckForUpdates(IsUpdateAvailable);
			IAsyncResult result = checkForUpdates.BeginInvoke(new AsyncCallback(CheckForUpdatesCompleted), null);
		}

		private bool IsUpdateAvailable()
		{
			return downloader.IsUpdateAvailable();
		}

		private void CheckForUpdatesCompleted(IAsyncResult ar)
		{
			try
			{
				// Get the calling delegate
				CheckForUpdates caller = (CheckForUpdates)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;

				// Call EndInvoke
				bool result = caller.EndInvoke(ar);

				if (this.InvokeRequired)
				{
					this.BeginInvoke(new CheckForUpdatesCompletedCallback(CheckForUpdatesCompleted), new object[] { result });
				}
				else
				{
					CheckForUpdatesCompleted(result);
				}
			}
			catch (Exception ex)
			{
				this.Invoke(new DisplayUpdateErrorCallback(DisplayDownloadError), new object[] { ex.Message });
			}
		}

		private void CheckForUpdatesCompleted(bool updatesAvailable)
		{
			checkForUpatesPanel.Visible = false;
			downloadUpdatesPanel.Visible = false;
			installPanel.Visible = false;

			// Make sure form is visible and active so user sees the message
			ShowApplication();

			if (updatesAvailable)
			{
				updatesAvailableLabel.Text = "Updates for eField Guide Viewer are available for download";
				updatesAvailablePanel.Visible = true;

				notifyIcon.Text = "Updates are available";
				if (MessageBox.Show(this, "Updates are available for eField Guide Viewer.  Would you like to download them now?", "Thayer Birding Software Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					UpdateApplication();
				}
				else
				{
					this.Close();
				}
			}
			else
			{
				updatesAvailableLabel.Text = "No updates are available for eField Guide Viewer";
				updatesAvailablePanel.Visible = true;

				notifyIcon.Text = "No updates are available";
				MessageBox.Show(this, "No updates are available for eField Guide Viewer.", "Thayer Birding Software Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void UpdateApplication()
		{
			if (updateThread == null)
			{
				updatesDownloaded = false;

				downloader.FileDownloading += new EventHandler<FileDownloadingEventArgs>(downloader_FileDownloading);
				downloader.DownloadCompleted += new EventHandler<DownloadCompletedEventArgs>(downloader_DownloadCompleted);

				updateThread = new Thread(new ThreadStart(DownloadUpdates));
				updateThread.Start();

				checkForUpatesPanel.Visible = false;
				updatesAvailablePanel.Visible = false;
				downloadUpdatesPanel.Visible = true;
				installPanel.Visible = false;

				percentCompleteLabel.Text = "0% Complete";
				notifyIcon.Text = "Downloading updates...";
			}
		}

		void downloader_FileDownloading(object sender, FileDownloadingEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new FileDownloadingCallback(FileDownloading), new object[] { sender, e });
			}
			else
			{
				FileDownloading(sender, e);
			}
		}

		private void FileDownloading(object sender, FileDownloadingEventArgs e)
		{
			StringBuilder text = new StringBuilder("Downloading updates...");

			if (e.PercentComplete >= 0)
			{
				text.Append("\n");
				text.Append(e.PercentComplete);
				text.Append("% Complete");

				downloadProgressBar.Value = e.PercentComplete;

				StringBuilder labelText = new StringBuilder(e.PercentComplete.ToString());
				labelText.Append("% Complete");
				percentCompleteLabel.Text = labelText.ToString();
			}

			notifyIcon.Text = text.ToString();
		}

		void downloader_DownloadCompleted(object sender, DownloadCompletedEventArgs e)
		{
			this.Invoke(new MethodInvoker(DownloadCompleted));
		}

		private void DownloadCompleted()
		{
			checkForUpatesPanel.Visible = false;
			downloadUpdatesPanel.Visible = false;
			installPanel.Visible = true;

			installButton.Visible = true;
			installButton.Enabled = true;
			installToolStripMenuItem.Enabled = true;

			// Make sure form is visible and active so user sees the message
			ShowApplication();

			if (downloader.InstallerRequiresUpdate)
			{
				StringBuilder labelText = new StringBuilder("System updates for the eField Guide Viewer update process have been downloaded from Thayer Birding Software.\n\n");
				labelText.Append("NOTE:  Please check for updates again after installing the system updates to make sure you get the latest application updates.");
				installLabel.Text = labelText.ToString();

				notifyIcon.BalloonTipText = "System updates for the eField Guide Viewer update process have been downloaded from Thayer Birding Software.  Click here to review these updates and install them.";
			}
			else
			{
				StringBuilder labelText = new StringBuilder("Updates for the eField Guide Viewer application have been downloaded from Thayer Birding Software.\n\n");
				labelText.Append("It is recommended that you install these updates to receive the latest application enhancements and bug fixes.");
				installLabel.Text = labelText.ToString();

				notifyIcon.BalloonTipText = "Application updates for eField Guide Viewer have been downloaded from Thayer Birding Software.  Click here to review these updates and install them.";
			}

			balloonTipShown = false;
			notifyIcon.Text = "New updates are ready to install";
			notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
			notifyIcon.BalloonTipTitle = "New updates are ready to install";
			notifyIcon.ShowBalloonTip(5000);

			downloadCompletedTimer.Enabled = true;
		}

		private void DownloadUpdates()
		{
			try
			{
				downloader.DownloadUpdates();
				updatesDownloaded = true;
			}
			catch (UpdateException ex)
			{
				this.Invoke(new DisplayUpdateErrorCallback(DisplayDownloadError), new object[] { ex.Message });
			}

			updateThread = null;
		}

		private void DisplayDownloadError(string message)
		{
			// Make sure form is visible and active so user sees the message
			ShowApplication();

			StringBuilder messageText = new StringBuilder("The following error has occurred:\n\n");
			messageText.Append(message);
			MessageBox.Show(this, messageText.ToString(), "Thayer Birding Software Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			this.Close();
		}

		private void InstallUpdatesNow()
		{
			if (updatesDownloaded)
			{
				installUpdates = true;
				this.Close();
			}
		}

		private void HideApplication()
		{
			this.Visible = false;
		}

		private void ShowApplication()
		{
			this.Visible = true;
			this.Activate();
		}

		private void installToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InstallUpdatesNow();
		}

		private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
		{
			ShowApplication();
		}

		private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
		{
			balloonTipShown = false;
		}

		private void notifyIcon_BalloonTipShown(object sender, EventArgs e)
		{
			balloonTipShown = true;
		}

		private void downloadCompletedTimer_Tick(object sender, EventArgs e)
		{
			if (updatesDownloaded && !balloonTipShown)
			{
				downloadCompletedTimer.Enabled = false;

				// Make sure form is visible and active so user sees the message
				ShowApplication();

				if (MessageBox.Show(this, "Updates have been successfully downloaded for Thayer Birding Software's eField Guide Viewer.\n\nWould you like to install them now?", "Thayer Birding Software Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				{
					InstallUpdatesNow();
				}
				else
				{
					downloadCompletedTimer.Enabled = true;
				}
			}
		}

		private void hideButton_Click(object sender, EventArgs e)
		{
			HideApplication();
		}

		private void installButton_Click(object sender, EventArgs e)
		{
			InstallUpdatesNow();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowApplication();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ShowApplication();
			}
		}
	}
}