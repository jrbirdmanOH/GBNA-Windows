using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class ObserverEditForm : BaseForm
	{
		private Observer observer = null;

		public ObserverEditForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public Observer Observer
		{
			get
			{
				return observer;
			}

			set
			{
				observer = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			firstNameTextBox.Text = observer.FirstName;
			middleInitialTextBox.Text = observer.MiddleInitial;
			lastNameTextBox.Text = observer.LastName;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			observer.FirstName = firstNameTextBox.Text;
			observer.MiddleInitial = middleInitialTextBox.Text;
			observer.LastName = lastNameTextBox.Text;

			if (observer.FirstName.Length == 0)
			{
				ShowValidationError("Please enter your first name.");
				firstNameTextBox.Focus();
				return;
			}

			if (observer.LastName.Length == 0)
			{
				ShowValidationError("Please enter your last name.");
				lastNameTextBox.Focus();
				return;
			}

			if (observer.NameExists)
			{
				ShowValidationError("An observer already exists with this name.  Please specify a unique name.");
				firstNameTextBox.Focus();
				return;
			}

			observer.Save();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void ShowValidationError(string message)
		{
			MessageBox.Show(this, message, "Observer Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}
