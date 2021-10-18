using System;
using System.Windows.Forms;

namespace Thayer.Birding.ScreenSaver
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			LoadSettings();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			SaveSettings();
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void playSoundCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateLoopCheckBoxStatus();
		}

		private void LoadSettings()
		{
			ScreenSaverSettings settings = ScreenSaverSettings.Load();

			imageDisplayTimeNumericUpDown.Value = settings.ImageDisplayTime;
			randomOrderCheckBox.Checked = settings.RandomOrder;
			commonNameCheckBox.Checked = settings.DisplayCommonName;
			captionCheckBox.Checked = settings.DisplayCaption;
			playSoundCheckBox.Checked = settings.PlaySound;
			loopSoundCheckBox.Checked = settings.LoopSound;

			UpdateLoopCheckBoxStatus();
		}

		private void SaveSettings()
		{
			ScreenSaverSettings settings = new ScreenSaverSettings();

			settings.ImageDisplayTime = Convert.ToInt32(imageDisplayTimeNumericUpDown.Value);
			settings.RandomOrder = randomOrderCheckBox.Checked;
			settings.DisplayCommonName = commonNameCheckBox.Checked;
			settings.DisplayCaption = captionCheckBox.Checked;
			settings.PlaySound = playSoundCheckBox.Checked;
			settings.LoopSound = loopSoundCheckBox.Checked;

			settings.Save();
		}

		private void UpdateLoopCheckBoxStatus()
		{
			loopSoundCheckBox.Enabled = playSoundCheckBox.Checked;
		}
	}
}