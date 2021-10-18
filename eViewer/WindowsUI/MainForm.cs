using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Thayer.Birding.DataUpdates;
using Thayer.Birding.Filtering;
using Thayer.Birding.UI.Windows.Licensing;
using Thayer.Birding.UI.Windows.Quiz;
using Thayer.Birding.Archiving;

namespace Thayer.Birding.UI.Windows
{
	internal partial class MainForm : BaseForm, IBirdingApplication, IShowsWebBrowser, IShowsBird
	{
		private delegate string SpectrogramMethodInvoker();
		private delegate void SetSplashMessageInvoker(string message);

		private ProgressForm progressDialog = null;

		public MainForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Check for any downloaded updates that need to be processed
			DataUpdate update = new DataUpdate(this);
			update.CheckForUpdates();

			// Add web links menu items
			AddWebLinks();

			ShowNewEGuide();

			this.Activate();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			Splasher.Close();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenEGuide();
		}

		private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();

			StringBuilder message = new StringBuilder("If you created any \"My Media\" or \"My Quizzes\" data, it is recommended that you include it in your backup file.  You will have the option to exclude it when restoring.  Would you like to include custom data in your backup file?");
			message.Append("\n\nClick \"Yes\" to include custom data in the backup file along with the application database.");
			message.Append("\n\nClick \"No\" to only backup the application database (includes custom lists, sightings, observers, notes, and hall of fame entries.");
			message.Append("\n\nClick \"Cancel\" to cancel the backup.");
			message.Append("\n\nNOTE: Generating a backup file with a large amount of custom data may take a few minutes.");
			DialogResult result = MessageBox.Show(message.ToString(), "eViewer Backup", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result != DialogResult.Cancel)
			{
				bool includeCustomData = result == DialogResult.Yes ? true : false;

				SaveFileDialog dialog = new SaveFileDialog();
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				dialog.AddExtension = true;
				dialog.DefaultExt = "zip";
				dialog.FileName = string.Format("eViewer Backup ({0}).zip", DateTime.Now.ToString("yyyy-MM-dd"));
				dialog.Filter = "eViewer Backup File (*.zip)|*.zip";
				dialog.OverwritePrompt = true;
				dialog.RestoreDirectory = true;
				dialog.Title = "eViewer Backup";
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					Application.DoEvents();
					Cursor = Cursors.WaitCursor;
					Application.DoEvents();

					try
					{
						// Create backup file
						BackupRestore.Backup(dialog.FileName, includeCustomData);

						Cursor = Cursors.Default;
						MessageBox.Show("The eViewer backup file has been created successfully.", "eViewer Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						Cursor = Cursors.Default;
						MessageBox.Show(string.Format("An error occurred creating the eViewer backup file. {0}", ex.Message), "eViewer Backup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void restoreBackUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//string fileName = @"C:\Junk\CustomerBackupFiles\Thayer Birding Backup (2009-01-04).xml";
			//Archive archive = Archiver.OpenArchive(fileName);
			//archive.Restore();

			ImportPreviousVersionForm importForm = new ImportPreviousVersionForm();
			importForm.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolbarToolStripMenuItem.Checked = !toolbarToolStripMenuItem.Checked;

			mainToolBar.Visible = toolbarToolStripMenuItem.Checked;
		}

		private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			statusBarToolStripMenuItem.Checked = !statusBarToolStripMenuItem.Checked;

			statusBar.Visible = statusBarToolStripMenuItem.Checked;
		}

		private void AddWebLinks()
		{
			// Add menu items to Web Links menu
			ToolStripItem menuItem = null;
			foreach (WebLink link in WebLink.MenuLinks)
			{
				if (link.IsSeparator)
				{
					menuItem = new ToolStripSeparator();
				}
				else
				{
					menuItem = new ToolStripMenuItem(link.Caption);
					menuItem.Tag = link;
					menuItem.Click += WebLinkClick;
				}

				webLinksToolStripMenuItem.DropDownItems.Add(menuItem);
			}

			// Add FAQ/Knowledgebase menu item to Help menu
			WebLink faqWebLink = WebLink.GetByCode("FAQ");
			if (faqWebLink != null)
			{
				faqToolStripMenuItem.Text = faqWebLink.Caption;
				faqToolStripMenuItem.Tag = faqWebLink;
				faqToolStripMenuItem.Click += WebLinkClick;
			}

			// Add Video Tutorials menu item to Help menu
			WebLink tutorialWebLink = WebLink.GetByCode("TUTORIAL");
			if (tutorialWebLink != null)
			{
				videoTutorialsToolStripMenuItem.Text = tutorialWebLink.Caption;
				videoTutorialsToolStripMenuItem.Tag = tutorialWebLink;
				videoTutorialsToolStripMenuItem.Click += WebLinkClick;
			}

			// Add I Need Help...NOW! menu item to Help menu
			WebLink helpNowWebLink = WebLink.GetByCode("HELPNOW");
			if (helpNowWebLink != null)
			{
				needHelpNowToolStripMenuItem.Text = helpNowWebLink.Caption;
				needHelpNowToolStripMenuItem.Tag = helpNowWebLink;
				needHelpNowToolStripMenuItem.Click += WebLinkClick;
			}

			// Add Free Birding eNewsletter menu item to Help menu
			WebLink newsletterWebLink = WebLink.GetByCode("NEWSLETTERS");
			if (newsletterWebLink != null)
			{
				freeThayerENewsletterToolStripMenuItem.Text = newsletterWebLink.Caption;
				freeThayerENewsletterToolStripMenuItem.Tag = newsletterWebLink;
				freeThayerENewsletterToolStripMenuItem.Click += WebLinkClick;
			}
		}

		private void WebLinkClick(object sender, EventArgs e)
		{
			ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

			WebLink link = menuItem.Tag as WebLink;

			link.Navigate(this);
		}

		private void identificationWizardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowIdentificationWizard();
		}

		private void quizzesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowQuizzes();
		}

		private void sightingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowSightings();
		}

		private void customListsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowCustomLists();
		}

		private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void aboutEFieldGuideViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		private void openEGuideToolStripButton_Click(object sender, EventArgs e)
		{
			OpenEGuide();
		}

		private void idWizardToolStripButton_Click(object sender, EventArgs e)
		{
			ShowIdentificationWizard();
		}

		private void quizzesToolStripButton_Click(object sender, EventArgs e)
		{
			ShowQuizzes();
		}

		private void sightingsToolStripButton_Click(object sender, EventArgs e)
		{
			ShowSightings();
		}

		private void customListsToolStripButton_Click(object sender, EventArgs e)
		{
			ShowCustomLists();
		}

		private void OpenEGuide()
		{
			OpenForm openForm = new OpenForm();
			if (openForm.ShowDialog() == DialogResult.OK && openForm.SelectedCollection != null)
			{
				ShowNewEGuide(openForm.SelectedCollection);
			}
		}

		void IShowsBird.ShowBird(int organismID)
		{
			EGuideForm form = ActiveMdiChild as EGuideForm;
			if (form == null)
			{
				OpenEGuide();
			}

			form.ShowBird(organismID);
		}

		void IShowsBird.ShowNewBird(Collection collection, int organismID)
		{
			ShowNewEGuide(collection, organismID);
		}

		void IShowsBird.SetImagePreference(ImagePreferenceType imagePreference)
		{
			EGuideForm form = ActiveMdiChild as EGuideForm;
			if (form != null)
			{
				((IShowsBird)form).SetImagePreference(imagePreference);
			}
		}

		private void ShowCustomLists()
		{
			Application.DoEvents();

			Cursor = Cursors.WaitCursor;

			try
			{
				bool bIsOpen = false;
				foreach (Form form in Application.OpenForms)
				{
					if (form is CustomListForm)
					{
						bIsOpen = true;
						form.Activate();
						break;
					}
				}

				if (!bIsOpen)
				{
					CustomListForm form = new CustomListForm();
					form.Language = UserSettings.Instance.Language;
					form.ShowsBirdProvider = this;
					form.Show();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void ShowIdentificationWizard()
		{
			Application.DoEvents();

			Cursor = Cursors.WaitCursor;

			try
			{
				EGuideForm eGuideForm = ActiveMdiChild as EGuideForm;
				if (eGuideForm != null)
				{
					IdentificationForm form = new IdentificationForm();
					form.Collection = eGuideForm.Collection;
					form.ShowsBirdProvider = this;
					form.Show();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		public void ShowQuizzes()
		{
            EGuideForm eGuideForm = ActiveMdiChild as EGuideForm;
            if (eGuideForm != null)
            {
				UserSettings.Instance.Reload();
				QuizSettings quizSettings = UserSettings.Instance.QuizSettings;
				quizSettings.WizardStartupType = QuizSettings.WizardStartupTypes.Default;
				QuizLauncher.Instance.RunQuizWizard(UserSettings.Instance.QuizSettings, eGuideForm.Collection);
            }
		}

        private void ShowSightings()
        {
            EGuideForm eGuideForm = ActiveMdiChild as EGuideForm;
            if (eGuideForm != null)
            {
                SightingsForm openForm = Utility.GetOpenForm<SightingsForm>();
                if (openForm != null)
                {
                    openForm.Activate();
                }
                else
                {
                    SightingsForm form = new SightingsForm();
                    form.Collection = eGuideForm.Collection;
                    form.Language = eGuideForm.Language;
                    form.SightingsChanged += new EventHandler<EventArgs>(sightingsForm_SightingsChanged);
                    form.FormClosed += new FormClosedEventHandler(sightingsForm_FormClosed);
                    form.Show();
                }
            }
        }

        void sightingsForm_SightingsChanged(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                // Refresh form when sightings have been changed
                if (form is EGuideForm)
                {
                    ((EGuideForm)form).RefreshHTML();
                }
            }
        }

        void sightingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup event handlers after form is closed
            SightingsForm form = sender as SightingsForm;
            if (form != null)
            {
                form.SightingsChanged -= sightingsForm_SightingsChanged;
                form.FormClosed -= sightingsForm_FormClosed;
            }
        }

		private void MainForm_MdiChildActivate(object sender, EventArgs e)
		{
			bool childWindowExists = ActiveMdiChild != null;

			identificationWizardToolStripMenuItem.Enabled = childWindowExists;
			quizzesToolStripMenuItem.Enabled = childWindowExists;
			sightingsToolStripMenuItem.Enabled = childWindowExists;
			customListsToolStripMenuItem.Enabled = childWindowExists;

			idWizardToolStripButton.Enabled = childWindowExists;
			quizzesToolStripButton.Enabled = childWindowExists;
			sightingsToolStripButton.Enabled = childWindowExists;
			customListsToolStripButton.Enabled = childWindowExists;

			// Update the filter label in the status bar
			// when an EGuideForm is activated
			EGuideForm eGuideForm = ActiveMdiChild as EGuideForm;
			if (eGuideForm != null)
			{
				UpdateFilterStatusLabel(eGuideForm.Filters, eGuideForm.OrganismCount);
			}
		}

		private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, helpProvider.HelpNamespace);
		}

		private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowNewEGuide();
		}

		private void ShowNewEGuide()
		{
			ShowNewEGuide(UserSettings.Instance.Collection, UserSettings.Instance.OrganismID);
		}

		private void ShowNewEGuide(Collection collection)
		{
			ShowNewEGuide(collection, UserSettings.Instance.OrganismID);
		}

		private void ShowNewEGuide(Collection collection, int organismID)
		{
			if (collection != null)
			{
				// Keep track of last opened collection
				UserSettings.Instance.Collection = collection;

				// Set organism ID so new EGuideForm opens up with correct bird
				UserSettings.Instance.OrganismID = organismID;

				EGuideForm form = new EGuideForm();
				form.TextChanged += new EventHandler(EGuideForm_TextChanged);
				form.FilterChanged += new EventHandler<EventArgs>(EGuideForm_FilterChanged);
				form.MdiParent = this;
				form.StartPosition = FormStartPosition.WindowsDefaultBounds;
				form.Collection = collection;
				form.Language = UserSettings.Instance.Language;
				form.Show();
			}
		}

		void EGuideForm_TextChanged(object sender, EventArgs e)
		{
			ActivateMdiChild(null);
			ActivateMdiChild(sender as Form);
		}

		void EGuideForm_FilterChanged(object sender, EventArgs e)
		{
			// Update the filter label in the status bar
			// when an EGuideForm is activated
			EGuideForm eGuideForm = ActiveMdiChild as EGuideForm;
			if (eGuideForm != null)
			{
				UpdateFilterStatusLabel(eGuideForm.Filters, eGuideForm.OrganismCount);
			}
		}

		private void UpdateFilterStatusLabel(FilterCollection filters, int organismCount)
		{
			// Set the filter label in the status bar
			StringBuilder filterStatusLabel = new StringBuilder();
			if (filters != null && filters.Count > 0)
			{
				filterStatusLabel.Append("Filter: ");
				filterStatusLabel.Append(filters.Name);
				filterStatusLabel.Append(" (");
				filterStatusLabel.Append(organismCount.ToString());
				filterStatusLabel.Append(")");
			}

			filterToolStripStatusLabel.Text = filterStatusLabel.ToString();
		}

		private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process currentProcess = Process.GetCurrentProcess();

			StringBuilder arguments = new StringBuilder("\"");
			arguments.Append(currentProcess.MainModule.FileName);
			arguments.Append("\" ");
			arguments.Append(currentProcess.Id.ToString());

			try
			{
				Process process = new Process();
				// TODO - Add update executable name to ApplicationSettings class
				process.StartInfo.FileName = Path.Combine(ApplicationSettings.AssemblyPath, "UpdateDownloader.exe");
				process.StartInfo.WorkingDirectory = ApplicationSettings.AssemblyPath;
				process.StartInfo.Arguments = arguments.ToString();

				if (File.Exists(process.StartInfo.FileName))
				{
					process.Start();
				}
				else
				{
					StringBuilder message = new StringBuilder("A file required to check for updates \"");
					message.Append(process.StartInfo.FileName);
					message.Append("\" could not be found.");
					MessageBox.Show(message.ToString(), "Check for Updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (System.ComponentModel.Win32Exception)
			{
				// User has cancelled the operation
			}
		}

		private void manageLicenseKeysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LicenseKeyManagerForm form = new LicenseKeyManagerForm();
			form.ShowDialog(this);
		}

		private void theBirdersHandbookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowBirdersHandbook();
		}

		private void birdersHandbookToolStripButton_Click(object sender, EventArgs e)
		{
			ShowBirdersHandbook();
		}

		private void ShowBirdersHandbook()
		{
			EGuideForm form = ActiveMdiChild as EGuideForm;
			if (form != null)
			{
				form.EGuide.ShowBirdersHandbook();
			}
			else
			{
				Help.ShowHelp(this, "The Birder's Handbook.chm");
			}
		}

		private void peteysSandboxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowPeteysSandbox();
		}

		private void peteyToolStripButton_Click(object sender, EventArgs e)
		{
			ShowPeteysSandbox();
		}

		private void ShowPeteysSandbox()
		{
			Application.DoEvents();

			Cursor = Cursors.WaitCursor;

			try
			{
				bool bIsOpen = false;
				foreach (Form form in Application.OpenForms)
				{
					if (form is PeteySandboxForm)
					{
						bIsOpen = true;
						form.Activate();
						break;
					}
				}

				if (!bIsOpen)
				{
					PeteySandboxForm form = new PeteySandboxForm();
					form.Show();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		string IBirdingApplication.GetSpectrogramLocation()
		{
			return (string)Splasher.SplashForm.Invoke(new SpectrogramMethodInvoker(GetSpectrogramLocation));
		}

		void IBirdingApplication.SetSplashMessage(string message)
		{
			Splasher.SplashForm.Invoke(new SetSplashMessageInvoker(SetSplasherInfoMessage), new object[] { message });
		}

		private void SetSplasherInfoMessage(string message)
		{
			((SplashForm)Splasher.SplashForm).StatusInfo = message;
		}

		private string GetSpectrogramLocation()
		{
			string path = null;

			StringBuilder message = new StringBuilder();
			message.Append(Application.ProductName);
			message.Append(" can optionally be configured to view spectrograms, which are visual representations of a bird's song.  ");
			message.Append("Please see the \"Using the Spectrogram\" help topic in the \"Field Guide\" section of the help contents ");
			message.Append("for details on how to download and integrate with a spectrogram application.");
			message.Append("\n\nDo you already have a spectrogram application installed that you wish to integrate now?");

			if (MessageBox.Show(Splasher.SplashForm, message.ToString(), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				path = Utility.BrowseForSpectrogram(Splasher.SplashForm, null);
			}

			return path;
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OptionsForm optionsForm = new OptionsForm();
			if (optionsForm.ShowDialog(this) == DialogResult.OK)
			{
				RefreshEGuideForms();
			}
		}

		private void RefreshEGuideForms()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				foreach (Form form in this.MdiChildren)
				{
					EGuideForm eGuideForm = form as EGuideForm;
					if (eGuideForm != null)
					{
						eGuideForm.RefreshHTML(true);
					}
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		void IShowsWebBrowser.OpenBrowser(string url)
		{
			Utility.ShowWebBrowser(url);
		}

		private void importMyMediaPackageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Utility.ImportMyMediaPackage();
		}
	}
}
