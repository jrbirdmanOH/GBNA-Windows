using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;

namespace Thayer.Birding
{
	public sealed class FormSettings : ApplicationSettingsBase
	{
		[UserScopedSetting()]
		[DefaultSettingValueAttribute("")]
		public string SettingsVersion
		{
			get { return (string)(this["SettingsVersion"]); }
			set { this["SettingsVersion"] = value; }
		}

		[UserScopedSetting()]
		[DefaultSettingValueAttribute("0, 0")]
		public Point FormLocation
		{
			get { return (Point)(this["FormLocation"]); }
			set { this["FormLocation"] = value; }
		}

		[UserScopedSetting()]
		[DefaultSettingValueAttribute("0, 0")]
		public System.Drawing.Size FormSize
		{
			get { return (System.Drawing.Size)this["FormSize"]; }
			set { this["FormSize"] = value; }
		}

		[UserScopedSetting()]
		public int? FormWindowState
		{
			get { return (int?)this["FormWindowState"]; }
			set { this["FormWindowState"] = value; }
		}
	}
}
