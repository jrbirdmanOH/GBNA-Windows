using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class ScreenSaverForm : Form
	{
		public enum PhotographType { Best, Random };

		public ScreenSaverForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		public PhotographType PhotographTypeSelected
		{
			get
			{
				return randomPhotoRadioButton.Checked ? ScreenSaverForm.PhotographType.Random : ScreenSaverForm.PhotographType.Best;
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			Close();
		}
	}
}