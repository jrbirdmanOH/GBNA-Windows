using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Thayer.Birding.Updates.Installer;

namespace UpdateInstaller
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

			InstallForm form = new InstallForm();

			bool canRun = false;
			switch (args.Length)
			{
				case 1:
					{
						form.Installer.ApplicationName = args[0];
						canRun = true;
					}
					break;
				case 2:
					{
						form.Installer.ApplicationName = args[0];

						int processID;
						if (Int32.TryParse(args[1], out processID))
						{
							form.Installer.ApplicationProcessID = processID;
							canRun = true;
						}
					}
					break;
			}

			if (canRun)
			{
				Application.Run(form);
			}
			else
			{
				MessageBox.Show("Invalid arguments.", "UpdateInstaller.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}