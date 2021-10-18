using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding.UI.Quiz;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class HallOfFameForm : BaseForm
	{
		public HallOfFameForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		private void HallOfFameForm_Load(object sender, EventArgs e)
		{
			LoadHallOfFame();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void printButton_Click(object sender, EventArgs e)
		{
			HtmlDocument doc = hallOfFameWebBrowser.Document;
			doc.ExecCommand("Print", true, null);
		}

		private void clearScoresButton_Click(object sender, EventArgs e)
		{
			HallOfFameClearScoresForm clearScoresForm = new HallOfFameClearScoresForm();
			clearScoresForm.HallOfFameListChanged += new EventHandler(clearScoresForm_HallOfFameListChanged);
			clearScoresForm.ShowDialog();
			clearScoresForm.HallOfFameListChanged -= clearScoresForm_HallOfFameListChanged;
		}

		public void clearScoresForm_HallOfFameListChanged(object sender, EventArgs e)
		{
			// Need to update contents because the Hall of Fame list has changed
			LoadHallOfFame();
		}

		private void LoadHallOfFame()
		{
			bool hasEntries;
			hallOfFameWebBrowser.DocumentText = HallOfFameUI.GenerateHTML(out hasEntries);
			clearScoresButton.Enabled = hasEntries;
		}

		private void hallOfFameWebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				Help.ShowHelp(this, helpProvider.HelpNamespace, HelpNavigator.TopicId, helpProvider.GetHelpKeyword(this));
			}
		}
	}
}