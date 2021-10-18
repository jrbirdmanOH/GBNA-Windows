using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace Thayer.Birding.UI.Windows
{
	public class SingleInstanceApplication
	{
		private static Mutex mutex = null;
		private const int SW_RESTORE = 9;

		public SingleInstanceApplication()
		{
		}

		/// <summary>
		/// Imports 
		/// </summary>
		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern int IsIconic(IntPtr hWnd);

		/// <summary>
		/// GetCurrentInstanceWindowHandle
		/// </summary>
		/// <returns></returns>
		private static IntPtr GetCurrentInstanceWindowHandle()
		{    
			IntPtr hWnd = IntPtr.Zero;
			Process process = Process.GetCurrentProcess();
			Process[] processes = Process.GetProcessesByName(process.ProcessName);
			foreach(Process _process in processes)
			{
				// Get the first instance that is not this instance, has the
				// same process name and was started from the same file name
				// and location. Also check that the process has a valid
				// window handle in this session to filter out other user's
				// processes.
				if (_process.Id != process.Id &&
					_process.MainModule.FileName == process.MainModule.FileName &&
					_process.MainWindowHandle != IntPtr.Zero)    
				{
					hWnd = _process.MainWindowHandle;
					break;
				}
			}

			return hWnd;
		}

		/// <summary>
		/// Switch to the current instance of the application
		/// </summary>
		private static void SwitchToCurrentInstance()
		{    
			IntPtr hWnd = GetCurrentInstanceWindowHandle();
			if (hWnd != IntPtr.Zero)    
			{    
				// Restore window if minimized. Do not restore if already in
				// normal or maximised window state, since we don't want to
				// change the current state of the window.
				if (IsIconic(hWnd) != 0)
				{
					ShowWindow(hWnd, SW_RESTORE);
				}

				// Set foreground window.
				SetForegroundWindow(hWnd);
			}
		}

		/// <summary>
		/// Check to see if an instance of the application is already running
		/// </summary>
		/// <returns>returns true if already running</returns>
		public static bool IsAlreadyRunning()
		{
			bool bCreatedNew;

			string executableName = Path.GetFileName(Assembly.GetEntryAssembly().Location);
			mutex = new Mutex(true, "Global\\" + executableName, out bCreatedNew);
			if (bCreatedNew)
			{
				mutex.ReleaseMutex();
			}

			return !bCreatedNew;
		}

		/// <summary>
		/// Run the current instance
		/// </summary>
		public static void RunCurrentInstance()
		{
			// Set focus to previously running app
			SwitchToCurrentInstance();
		}
	}
}
