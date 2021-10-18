using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.DataUpdates;
using Thayer.Birding.Licensing;
using System.Collections.Specialized;

namespace Thayer.Birding.UI.Windows
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				if (!SingleInstanceApplication.IsAlreadyRunning())
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);

					bool firstTimeRun = true;

					try
					{
						// Get first time run flag
						firstTimeRun = ApplicationSettings.FirstTimeRun;
					}
					catch (Exception ex)
					{
						StringBuilder error = new StringBuilder();
						while (ex != null)
						{
							if (error.Length > 0)
							{
								error.Append(Environment.NewLine);
							}

							error.Append(ex.Message);
							error.Append(Environment.NewLine);
							error.Append(ex.StackTrace);

							ex = ex.InnerException;
						}
						Log.Write(error.ToString());
						MessageBox.Show(error.ToString(), "Application Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					try
					{
						// Validate the license
						ThayerLicenseManager.Instance.Validate(new Thayer.Birding.UI.Windows.Licensing.ProductSelector());
					}
					catch (ThayerLicenseException tle)
					{
						StringCollection messages = new StringCollection();
						messages.Add("ThayerLicenseException");
						messages.Add(tle.Message);
						messages.Add("");
						messages.Add(tle.StackTrace);
						messages.Add("");
						messages.Add("License file contents");
						messages.Add("=====================");
						messages.Add(ThayerLicenseManager.Instance.LicenseFile.DecryptedString);
						Log.Write(messages);

						MessageBox.Show(tle.Message, "License Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					catch (Exception ex)
					{
						StringBuilder error = new StringBuilder();
						while (ex != null)
						{
							if (error.Length > 0)
							{
								error.Append(Environment.NewLine);
							}

							error.Append(ex.Message);
							error.Append(Environment.NewLine);
							error.Append(ex.StackTrace);

							ex = ex.InnerException;
						}
						StringCollection messages = new StringCollection();
						messages.Add("Unexpected License Error");
						messages.Add(error.ToString());
						messages.Add("");
						messages.Add("License file contents");
						messages.Add("=====================");
						messages.Add(ThayerLicenseManager.Instance.LicenseFile.DecryptedString);
						Log.Write(messages);
						MessageBox.Show(error.ToString(), "Unexpected License Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					try
					{
						if (firstTimeRun)
						{
							Log.Write("First time run flag is true.");

							// Set first time run flag
							ApplicationSettings.FirstTimeRun = false;

							StringCollection messages = new StringCollection();
							messages.Add("License file contents");
							messages.Add("=====================");
							messages.Add(ThayerLicenseManager.Instance.LicenseFile.DecryptedString);
							Log.Write(messages);

							Log.Write("First time run flag set to false.");
						}
					}
					catch (Exception ex)
					{
						StringBuilder error = new StringBuilder();
						while (ex != null)
						{
							if (error.Length > 0)
							{
								error.Append(Environment.NewLine);
							}

							error.Append(ex.Message);
							error.Append(Environment.NewLine);
							error.Append(ex.StackTrace);

							ex = ex.InnerException;
						}
						Log.Write(error.ToString());
						MessageBox.Show(error.ToString(), "Application Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					Splasher.Show(typeof(SplashForm));

					MainForm form = new MainForm();
					Application.Run(form);
				}
				else
				{
					SingleInstanceApplication.RunCurrentInstance();
				}
			}
			catch (Exception ex)
			{
				StringBuilder error = new StringBuilder();
				while (ex != null)
				{
					if (error.Length > 0)
					{
						error.Append(Environment.NewLine);
					}

					error.Append(ex.Message);
					error.Append(Environment.NewLine);
					error.Append(ex.StackTrace);

					ex = ex.InnerException;
				}

				ErrorForm.Show(error.ToString());

				String source = Assembly.GetExecutingAssembly().ToString();

				if (!EventLog.SourceExists(source))
				{
					EventLog.CreateEventSource(source, "Thayer Birding Software");
				}
				EventLog.WriteEntry(source, error.ToString(), EventLogEntryType.Error);
			}
		}
	}
}