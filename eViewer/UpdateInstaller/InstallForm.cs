using System;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.Updates;

namespace Thayer.Birding.Updates.Installer
{
	public partial class InstallForm : Form, IRetryInstall
	{
		private delegate UpdateInstaller.InstallResult InstallUpdates();
		private delegate void InstallUpdatesCompletedCallback(UpdateInstaller.InstallResult result);
		private delegate void FileInstallingCallback(object sender, FileInstallingEventArgs e);
		private delegate void DisplayInstallErrorCallback(string message);
		private delegate bool RetryInstallCallback(string text, string caption);

		private bool isInstalling = false;

		public InstallForm()
		{
			InitializeComponent();
		}

		private bool IsInstalling
		{
			get
			{
				return isInstalling;
			}

			set
			{
				isInstalling = value;

				// Don't allow user to close while installing and
				// enable the close button when installing is done
				Utility.SetCloseButtonState(this, !isInstalling);
			}
		}

		internal Thayer.Birding.Updates.UpdateInstaller Installer
		{
			get
			{
				return installer;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Don't show in taskbar - can't toggle ShowInTaskbar state or modality of MessageBox is lost
			this.ShowInTaskbar = false;

			// Activate the form so it is shown and has focus
			this.Activate();

			// Start installing the updates
			StartInstall();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool bResult = false;

			// Don't allow user to close while installing
			if (isInstalling && keyData == (Keys.Alt | Keys.F4))
			{
				bResult = true;
			}
			else
			{
				bResult = base.ProcessCmdKey(ref msg, keyData);
			}

			return bResult;
		}

		private void StartInstall()
		{
			// Mark the start of installing the updates
			this.IsInstalling = true;
			notifyIcon.Text = "Installing updates...";

			installer.FileInstalling += new EventHandler<FileInstallingEventArgs>(installer_FileInstalling);

			InstallUpdates installUpdates = new InstallUpdates(Install);
			IAsyncResult result = installUpdates.BeginInvoke(new AsyncCallback(InstallUpdatesCompleted), null);
		}

		void installer_FileInstalling(object sender, FileInstallingEventArgs e)
		{
			if (this.InvokeRequired)
			{
				Invoke(new FileInstallingCallback(FileInstalling), new object[] {sender, e});
			}
			else
			{
				FileInstalling(sender, e);
			}
		}

		public void FileInstalling(object sender, FileInstallingEventArgs e)
		{
			StringBuilder text = new StringBuilder("Installing updates...");

			if (e.PercentComplete >= 0)
			{
				text.Append("\n");
				text.Append(e.PercentComplete);
				text.Append("% Complete");

				installProgressBar.Value = e.PercentComplete;

				StringBuilder labelText = new StringBuilder(e.PercentComplete.ToString());
				labelText.Append("% Complete");
				percentCompleteLabel.Text = labelText.ToString();
			}

			notifyIcon.Text = text.ToString();
		}

		private UpdateInstaller.InstallResult Install()
		{
			UpdateInstaller.InstallResult result = UpdateInstaller.InstallResult.Error;

			try
			{
				result = installer.InstallUpdates(this);
			}
			catch (UpdateException ue)
			{
				if (this.InvokeRequired)
				{
					this.Invoke(new DisplayInstallErrorCallback(DisplayInstallError), new object[] { ue.Message });
				}
				else
				{
					DisplayInstallError(ue.Message);
				}
			}

			return result;
		}

		private void DisplayInstallError(string message)
		{
			// Make sure form is visible and active so user sees the message
			ShowApplication();

			MessageBox.Show(this, message, "Thayer Birding Software Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void InstallUpdatesCompleted(IAsyncResult ar)
		{
			// Get the calling delegate
			InstallUpdates caller = (InstallUpdates)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;

			// Call EndInvoke
			UpdateInstaller.InstallResult result = caller.EndInvoke(ar);

			if (this.InvokeRequired)
			{
				this.Invoke(new InstallUpdatesCompletedCallback(InstallUpdatesCompleted), new object[] { result });
			}
			else
			{
				InstallUpdatesCompleted(result);
			}
		}

		private void InstallUpdatesCompleted(UpdateInstaller.InstallResult result)
		{
			// Mark the end of installing the updates
			this.IsInstalling = false;

			// Make sure form is visible and active so user sees the message
			ShowApplication();

			switch (result)
			{
				case UpdateInstaller.InstallResult.Successful:
					notifyIcon.Text = "Updates have been installed successfully";
					MessageBox.Show(this, "Updates have been installed successfully.", "Thayer Birding Software Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
					installer.StartApplication();
					break;
				case UpdateInstaller.InstallResult.Error:
					notifyIcon.Text = "An error occurred while installing the updates";
					MessageBox.Show(this, "An error occurred while installing the updates.  Please contact Thayer Birding Software if this error continues.", "Thayer Birding Software Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
				case UpdateInstaller.InstallResult.Cancelled:
					notifyIcon.Text = "Installation of the updates has been cancelled";
					MessageBox.Show(this, "Installation of the updates has been cancelled.", "Thayer Birding Software Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
			}

			this.Close();
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

		private void hideButton_Click(object sender, EventArgs e)
		{
			HideApplication();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowApplication();
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ShowApplication();
			}
		}

		public bool GetRetryInstall(string text, string caption)
		{
			bool retry = false;

			// Make sure form is visible and active so user sees the message
			ShowApplication();

			DialogResult result = MessageBox.Show(this, text, caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Retry)
			{
				retry = true;
			}
			else
			{
				retry = false;
			}

			return retry;
		}

		#region IRetryInstall Members
		public bool RetryInstall(string text, string caption)
		{
			bool retry = false;

			if (this.InvokeRequired)
			{
				retry = (bool)this.Invoke(new RetryInstallCallback(GetRetryInstall), new object[] { text, caption });
			}
			else
			{
				retry = GetRetryInstall(text, caption);
			}

			return retry;
		}
		#endregion
	}
}