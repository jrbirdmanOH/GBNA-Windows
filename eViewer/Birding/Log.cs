using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.IO;

namespace Thayer.Birding
{
	public class Log
	{
		private const int maxFileSize = 1000000;

		static Log()
		{
			Trace.Listeners.Clear();

			string logFileName = Path.Combine(ApplicationSettings.AppDataPath, "eViewerLog.txt");
			if (File.Exists(logFileName))
			{
				FileInfo fi = new FileInfo(logFileName);
				if (fi.Length > maxFileSize)
				{
					fi.Delete();
				}
			}

			DefaultTraceListener listener = new DefaultTraceListener();
			listener.LogFileName = logFileName;
			Trace.Listeners.Add(listener);
		}

		private static void WriteHeader()
		{
			Trace.WriteLine(DateTime.Now.ToString());
		}

		private static void WriteFooter()
		{
			Trace.WriteLine("");
		}

		public static void Write(string message)
		{
			WriteHeader();
			Trace.WriteLine(message);
			WriteFooter();

			Trace.Close();
		}

		public static void Write(StringCollection messages)
		{
			WriteHeader();
			foreach (string message in messages)
			{
				Trace.WriteLine(message);
			}
			WriteFooter();

			Trace.Close();
		}
	}
}
