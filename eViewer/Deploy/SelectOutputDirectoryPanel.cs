using System;
using System.Windows.Forms;
using Thayer.Birding.Updates;

namespace Deploy
{
	public partial class SelectOutputDirectoryPanel : UserControl
	{
		public SelectOutputDirectoryPanel()
		{
			InitializeComponent();
		}

		public string SelectedPath
		{
			get
			{
				return fileNameTextBox.Text;
			}
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				fileNameTextBox.Text = folderBrowserDialog.SelectedPath;
			}
		}
	}
}
