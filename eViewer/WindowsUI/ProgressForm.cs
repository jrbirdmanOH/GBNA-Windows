using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding;

namespace Thayer.Birding.UI.Windows
{
	public partial class ProgressForm : Form
	{
		public ProgressForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		public string TaskDescription
		{
			get
			{
				return taskDescriptionLabel.Text;
			}

			set
			{
				taskDescriptionLabel.Text = value;
			}
		}

		public int PercentComplete
		{
			get
			{
				return progressBar.Value;
			}

			set
			{
				if (value < 0)
				{
					value = 0;
				}
				else if (value > 100)
				{
					value = 100;
				}

				progressBar.Value = value;

				percentCompleteLabel.Text = value.ToString() + "% Complete";
			}
		}
	}
}
