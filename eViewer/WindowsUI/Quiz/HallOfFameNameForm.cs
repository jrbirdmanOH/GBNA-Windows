using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class HallOfFameNameForm : Form
	{
		public string UserName
		{
			get
			{
				string name = nameTextBox.Text;
				name = name.Trim();

				return name;
			}
		}

		public HallOfFameNameForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		private void HallOfFameNameForm_Load(object sender, EventArgs e)
		{
			UpdateOKButtonStatus();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			string name = nameTextBox.Text;
			name = name.Trim();
			if (name.Length < 1 || name.Length > 30)
			{
				MessageBox.Show(this, "Please enter a name with a length between 1 and 30 characters.", "Hall of Fame Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.DialogResult = DialogResult.None;
			}
		}

		private void nameTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateOKButtonStatus();
		}

		private void UpdateOKButtonStatus()
		{
			okButton.Enabled = UserName.Length > 0;
		}
	}
}