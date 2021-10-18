using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.ScreenSaver
{
	public partial class ScreenSaverForm : Form
	{
		private ScreenSaverConfiguration config = null;
		private ScreenSaverSettings settings = null;
		private Random random = null;
		private int currentEntry = -1;
		private int screenNumber = 0;
		private Point mouseLocation;

		public ScreenSaverForm() : this(0)
		{
		}

		public ScreenSaverForm(int screenNumber)
		{
			InitializeComponent();
			this.screenNumber = screenNumber;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			#if DEBUG
			this.TopMost = false;
			#else
			this.TopMost = true;
			#endif

			commonNameLabel.Visible = false;
			captionLabel.Visible = false;
			copyrightLabel.Visible = false;
			screenSaverPictureBox.Visible = false;

			foreach (Control control in this.Controls)
			{
				control.KeyDown += new KeyEventHandler(ScreenSaverForm_KeyDown);
				control.MouseMove += new MouseEventHandler(ScreenSaverForm_MouseMove);
				control.MouseDown += new MouseEventHandler(ScreenSaverForm_MouseDown);
			}

			try
			{
				settings = ScreenSaverSettings.Load();
				config = ScreenSaverConfiguration.Load();
			}
			catch (ScreenSaverException sse)
			{
				MessageBox.Show(sse.Message, "Thayer Screen Saver Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Close();
			}

			if (settings.RandomOrder)
			{
				random = new Random();
			}

			commonNameLabel.Visible = settings.DisplayCommonName;
			captionLabel.Visible = settings.DisplayCaption;
			copyrightLabel.Visible = true;
			screenSaverPictureBox.Visible = true;

			imageTimer.Interval = settings.ImageDisplayTime * 1000;
			imageTimer.Start();

			DisplayEntry(GetNextEntry());

			Cursor.Hide();
		}

		private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
		{
			Close();
		}

		private void ScreenSaverForm_MouseDown(object sender, MouseEventArgs e)
		{
			Close();
		}

		private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (!mouseLocation.IsEmpty)
			{
				if(Math.Abs(e.X - mouseLocation.X) >= 5 || Math.Abs(e.Y - mouseLocation.Y) >= 5)
				{
					Close();
				}
			}

			mouseLocation = new Point(e.X, e.Y);
		}

		private void imageTimer_Tick(object sender, EventArgs e)
		{
			DisplayEntry(GetNextEntry());
		}

		private ScreenSaverEntry GetNextEntry()
		{
			ScreenSaverEntry nextEntry = null;

			if (settings.RandomOrder)
			{
				// Randomly choose an entry
				currentEntry = random.Next(config.Entries.Count);
			}
			else
			{
				if (currentEntry < 0 || currentEntry >= config.Entries.Count - 1)
				{
					currentEntry = 0;
				}
				else
				{
					currentEntry++;
				}
			}

			nextEntry = config.Entries[currentEntry];

			return nextEntry;
		}

		private void DisplayEntry(ScreenSaverEntry entry)
		{
			if (settings.PlaySound && screenNumber == 0)
			{
				entry.Sound.Play(settings.LoopSound);
			}

			screenSaverPictureBox.Image = entry.Image.GetImage();
			commonNameLabel.Text = entry.Image.Name;
			captionLabel.Text = entry.Image.Caption;

			copyrightLabel.Text = entry.Image.Copyright;
		}

		private void copyrightLabel_Resize(object sender, EventArgs e)
		{
			copyrightLabel.Left = this.Right - copyrightLabel.Width;
		}
	}
}