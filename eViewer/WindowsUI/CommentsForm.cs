using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class CommentsForm : BaseForm
	{
		public CommentsForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public string Comments
		{
			get
			{
				return winHTMLEditorControl.BodyHtml;
			}

			set
			{
				winHTMLEditorControl.BodyHtml = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			winHTMLEditorControl.EditorToolStripFirst.Items[0].Visible = false;
			winHTMLEditorControl.EditorToolStripFirst.Items[1].Visible = false;
			winHTMLEditorControl.EditorToolStripFirst.Items[2].Visible = false;
			winHTMLEditorControl.EditorToolStripFirst.Items[3].Visible = false;
			winHTMLEditorControl.EditorToolStripFirst.Items[4].AutoSize = false;
			winHTMLEditorControl.EditorToolStripFirst.Items[4].Width = 200;
			winHTMLEditorControl.EditorToolStripFirst.Items[14].Visible = false;


			winHTMLEditorControl.EditorToolStripSecond.Items[0].Visible = false;
			winHTMLEditorControl.EditorToolStripSecond.Items[22].Visible = false;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (tabControl.SelectedIndex == 1)
			{
				winHTMLEditorControl.BodyHtml = sourceTextBox.Text;
			}
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabControl.SelectedIndex)
			{
				case 0:
					winHTMLEditorControl.BodyHtml = sourceTextBox.Text;
					break;
				case 1:
					sourceTextBox.Text = winHTMLEditorControl.BodyHtml;
					break;
			}
		}
	}
}