using System;
using System.Windows.Forms;
using Thayer.Birding.Updates;

namespace Deploy
{
	public partial class FileListPanel : UserControl
	{
		private Manifest manifest = null;

		public FileListPanel()
		{
			InitializeComponent();
		}

		public Manifest Manifest
		{
			get
			{
				return manifest;
			}

			set
			{
				manifest = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.manifestBindingSource.DataSource = manifest;
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			foreach(DataGridViewRow row in fileListView.SelectedRows)
			{
				manifestBindingSource.RemoveAt(row.Index);
			}
		}
	}
}
