using System;
using System.IO;

namespace Thayer.Birding.DataUpdates
{
	public class Log
	{
		private static StreamWriter writer;

		static Log()
		{
			writer = new StreamWriter("DataUpdatesLog.txt");
			writer.AutoFlush = true;
		}

		public static void Write(bool value)
		{
			writer.Write(value);
		}

		public static void Write(int value)
		{
			writer.Write(value);
		}

		public static void Write(string value)
		{
			writer.Write(value);
		}

		public static void WriteLine()
		{
			writer.WriteLine();
		}

		public static void WriteLine(bool value)
		{
			writer.WriteLine(value);
		}

		public static void WriteLine(int value)
		{
			writer.WriteLine(value);
		}

		public static void WriteLine(string value)
		{
			writer.WriteLine(value);
		}
	}
}
