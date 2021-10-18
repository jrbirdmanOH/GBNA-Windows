using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Text;

namespace Thayer.Birding.UI.Windows
{
	class Splasher
	{
		private static Form splashForm = null;
		private static Thread splashThread = null;
		private static object lockObj = new object();

		private Splasher()
		{
		}

		public static Form SplashForm
		{
			get
			{
				return splashForm;
			}
		}

		public static void Show(Type splashFormType)
		{
			if (splashThread != null)
			{
				return;
			}

			if (splashFormType == null)
			{
				throw new NullReferenceException("splashFormType cannot be null.");
			}

			CreateInstance(splashFormType);

			splashThread = new Thread(new ThreadStart(delegate()
			{
				Application.Run(splashForm);
			}));
			splashThread.IsBackground = true;
			splashThread.SetApartmentState(ApartmentState.STA);
			splashThread.Start();
		}

		public static void Close()
		{
			if (splashThread == null || splashForm == null)
			{
				return;
			}

			lock (lockObj)
			{
				try
				{
					// Make sure the handle for the splash form has been created before calling Invoke
					if (!splashForm.IsHandleCreated)
					{
						// Calling the Handle property will force the handle to be created
						IntPtr handle = splashForm.Handle;
						Log.Write("Forcing creation of handle for splash screen form.");
					}

					splashForm.Invoke(new MethodInvoker(splashForm.Close));
				}
				catch (NullReferenceException nre)
				{
					// Catch NullReferenceException to prevent bug/issue when running on Windows 2000
				}
				catch (Exception ex)
				{
					StringBuilder message = new StringBuilder();
					message.Append("Error closing splash screen.  Splash screen thread will be aborted.");
					message.Append(Environment.NewLine);
					message.Append(ex.ToString());
					Log.Write(message.ToString());

					// Make sure the splash screen is closed
					if (splashThread != null)
					{
						splashThread.Abort();
					}
				}
				finally
				{
					splashThread = null;
					splashForm = null;
				}
			}
		}

		private static void CreateInstance(Type formType)
		{
			object obj = formType.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
			splashForm = obj as Form;

			if (splashForm == null)
			{
				throw new InvalidCastException("Splash screen must be of type System.Windows.Forms.Form");
			}
		}
	}
}
