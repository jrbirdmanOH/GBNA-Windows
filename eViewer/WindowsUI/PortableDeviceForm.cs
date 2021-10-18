using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class PortableDeviceForm : BaseForm
	{
		private CustomList customList = null;

		public PortableDeviceForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public CustomList CustomList
		{
			get
			{
				return customList;
			}

			set
			{
				customList = value;

				customListLabel.Text = customList.Name;
				recordingsLabel.Text = customList.GetCountWithSounds().ToString();
			}
		}

		public string Path
		{
			get
			{
				return directoryTextBox.Text;
			}
		}

		public CustomList.PortableDeviceNameDisplay FileNameDisplay
		{
			get
			{
				if (lastFirstRadioButton.Checked)
				{
					return CustomList.PortableDeviceNameDisplay.LastFirst;
				}
				else
				{
					return CustomList.PortableDeviceNameDisplay.FirstLast;
				}
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			Close();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				directoryTextBox.Text = dialog.SelectedPath;
			}
		}
	}
}