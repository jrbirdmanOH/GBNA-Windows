using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.Updates.Installer
{
	public class Utility
	{
		private const uint MF_BYCOMMAND = 0x00000000;
		private const uint MF_BYPOSITION = 0x00000400;

		private const uint MF_ENABLED = 0x00000000;
		private const uint MF_GRAYED = 0x00000001;
		private const uint MF_DISABLED = 0x00000002;

		private const uint MF_REMOVE = 0x1000;

		private const uint SC_SIZE = 0xF000;
		private const uint SC_MOVE = 0xF010;
		private const uint SC_MINIMIZE = 0xF020;
		private const uint SC_MAXIMIZE = 0xF030;
		private const uint SC_CLOSE = 0xF060;

		[DllImport("user32.dll")]
		private static extern int DrawMenuBar(IntPtr hWnd);

		[DllImport("user32.dll")]
		static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

		[DllImport("user32.dll")]
		private static extern int GetMenuItemCount(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll")]
		private static extern int RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);


		public static void SetCloseButtonState(Form form, bool bEnable)
		{
			IntPtr hMenu;
			hMenu = GetSystemMenu(form.Handle, false);
			if (hMenu != IntPtr.Zero)
			{
				int menuItemCount = GetMenuItemCount(hMenu);
				if (menuItemCount > 0)
				{
					uint menuState = bEnable ? MF_ENABLED : MF_DISABLED;
					EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | menuState);
				}

				DrawMenuBar(form.Handle);
			}
		}
	}
}
