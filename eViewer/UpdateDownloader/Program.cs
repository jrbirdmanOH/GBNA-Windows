using System;
using System.Windows.Forms;
using Thayer.Birding.Updates.Downloader;

namespace UpdateDownloader
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			DownloadForm form = new DownloadForm();

			bool canRun = false;
			switch (args.Length)
			{
				case 1:
					{
						form.Downloader.ApplicationName = args[0];
						canRun = true;
					}
					break;
				case 2:
					{
						form.Downloader.ApplicationName = args[0];

						int processID;
						if (Int32.TryParse(args[1], out processID))
						{
							form.Downloader.ApplicationProcessID = processID;
							canRun = true;
						}
					}
					break;
			}

			if (canRun)
			{
				Application.Run(form);

				if (form.InstallUpdates)
				{
					form.Downloader.Install();
				}
			}
			else
			{
				MessageBox.Show("Invalid arguments.", "UpdateDownloader.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}