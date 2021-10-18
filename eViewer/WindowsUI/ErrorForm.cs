using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class ErrorForm : Form
	{
		private string details = string.Empty;

		public ErrorForm()
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
				return details;
			}

			set
			{
				details = value;
			}
		}

		private void detailsButton_Click(object sender, EventArgs e)
		{
			ErrorDetailsForm form = new ErrorDetailsForm();
			form.Details = details;
			form.ShowDialog();
		}

		public static void Show(string details)
		{
			ErrorForm form = new ErrorForm();
			form.details = details;
			form.ShowDialog();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}