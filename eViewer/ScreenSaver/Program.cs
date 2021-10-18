using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Thayer.Birding.ScreenSaver;

namespace ScreenSaver
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

			try
			{
				if (args.Length > 0)
				{
					if (args[0].ToLower().Trim().Substring(0, 2) == "/c")
					{
						Application.Run(new SettingsForm());
					}
					if (args[0].ToLower() == "/s")
					{
						for (int i = Screen.AllScreens.GetLowerBound(0); i <= Screen.AllScreens.GetUpperBound(0); i++)
						{
							System.Windows.Forms.Application.Run(new ScreenSaverForm(i));
						}
					}
				}
				else
				{
					for (int i = Screen.AllScreens.GetLowerBound(0); i <= Screen.AllScreens.GetUpperBound(0); i++)
					{
						System.Windows.Forms.Application.Run(new ScreenSaverForm(i));
					}
				}
			}
			catch (ScreenSaverException sse)
			{
				// Make sure all sounds have stopped
				ScreenSaverSound.Stop();

				// Show cursor before message box
				Cursor.Show();

				MessageBox.Show(sse.Message, "Thayer Screen Saver Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			catch (Exception ex)
			{
				// Make sure all sounds have stopped
				ScreenSaverSound.Stop();

				// Show cursor before message box
				Cursor.Show();

				MessageBox.Show(ex.Message, "Unknown Thayer Screen Saver Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
	}
}