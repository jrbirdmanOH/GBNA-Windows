using System;
using System.Media;
using System.Windows.Forms;
using System.Text;

namespace Thayer.Birding.UI.Windows
{
	public partial class SoundForm : BaseForm
	{
		private string path;
		private Microsoft.DirectX.AudioVideoPlayback.Audio audio;
		private delegate void UpdateProgressBarCallback();

		public SoundForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public string Path
		{
			get
			{
				return path;
			}

			set
			{
				path = value;
			}
		}

		public bool Loop
		{
			get
			{
				return loopCheckBox.Checked;
			}

			set
			{
				loopCheckBox.Checked = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			try
			{
				audio = new Microsoft.DirectX.AudioVideoPlayback.Audio(path, true);
				progressBar1.Maximum = (int)audio.Duration;
				System.Threading.Thread audioPositionThread = new System.Threading.Thread(new System.Threading.ThreadStart(AudioPositionUpdate));
				audioPositionThread.Start();
			}
			catch (Exception ex)
			{
				StringBuilder message = new StringBuilder("Error playing sound - ");
				message.Append(ex.Message);
				MessageBox.Show(message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void UpdateProgressBar()
		{
			progressBar1.Value = (int)audio.CurrentPosition;
		}

		private void AudioPositionUpdate()
		{
			while (audio != null)
			{
				if (audio.CurrentPosition == audio.Duration)
				{
					if (loopCheckBox.Checked)
					{
						audio.CurrentPosition = 0.0;
						audio.Play();
					}
					else
					{
						BeginInvoke(new UpdateProgressBarCallback(Close));
						break;
					}
				}
				BeginInvoke(new UpdateProgressBarCallback(UpdateProgressBar));
				System.Threading.Thread.Sleep(1000);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			if (audio != null)
			{
				audio.Stop();
				audio.Dispose();
				audio = null;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (audio != null)
				{
					audio.Dispose();
					audio = null;
				}

				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
