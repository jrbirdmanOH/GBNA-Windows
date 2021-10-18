using System;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class NarrativeForm : BaseForm
	{
		public NarrativeForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public string Narrative
		{
			get
			{
				return narrativeTextBox.Text;
			}

			set
			{
				narrativeTextBox.Text = value;
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}