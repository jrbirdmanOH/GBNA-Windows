using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class ErrorDetailsForm : Form
	{
		public ErrorDetailsForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		public string Details
		{
			get
			{
				return detailsTextBox.Text;
			}

			set
			{
				detailsTextBox.Text = value;
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}