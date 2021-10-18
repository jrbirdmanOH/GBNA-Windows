using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace Thayer.Birding.UI.Windows
{
	public partial class BaseForm : Form
	{
		protected FormSettings formSettings = null;

		protected string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public BaseForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		protected FormSettings FormSettings
		{
			get
			{
				if (formSettings == null)
				{
					formSettings = new FormSettings();
				}

				return formSettings;
			}
		}

		protected string SettingsKey
		{
			get
			{
				return this.FormSettings.SettingsKey;
			}

			set
			{
				this.FormSettings.SettingsKey = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (this.FormSettings.SettingsVersion != this.AssemblyVersion)
			{
				this.FormSettings.Upgrade();
			}

			if (this.FormSettings.FormWindowState != null)
			{
				FormWindowState windowState = (FormWindowState)this.FormSettings.FormWindowState;
				if (windowState == FormWindowState.Normal)
				{
					SetSize();
					SetLocation();
				}

				this.WindowState = windowState;
				this.Refresh();
			}
		}

		protected void SetSize()
		{
			System.Drawing.Size size = this.FormSettings.FormSize;
			if (size.Height > 0 && size.Width > 0)
			{
				this.Size = size;
			}
		}

		protected void SetLocation()
		{
			Point location = this.FormSettings.FormLocation;
			location.X = location.X < 0 ? 0 : location.X;
			location.Y = location.Y < 0 ? 0 : location.Y;
			this.Location = location;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			this.FormSettings.SettingsVersion = this.AssemblyVersion;

			if (this.WindowState != FormWindowState.Minimized)
			{
				this.FormSettings.FormSize = this.Size;
				this.FormSettings.FormLocation = this.Location;
				this.FormSettings.FormWindowState = (int)this.WindowState;
			}

			this.FormSettings.Save();
		}
	}
}