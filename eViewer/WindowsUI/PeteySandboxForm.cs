using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class PeteySandboxForm : Form
	{
		private int jokeCount = -1;
		private int[] jokeIDs = null;
		private int jokeIndex = -1;

		private int tipCount = -1;
		private int[] tipIDs = null;
		private int tipIndex = -1;

		private bool visibleAtStartup = false;

		public PeteySandboxForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			RefreshButtons();

			Petey petey = Petey.Instance;
			visibleAtStartup = petey.Visible;
			if (visibleAtStartup)
			{
				Point point = this.DesktopLocation;
				petey.MoveTo((short)point.X, (short)point.Y);
				petey.Play(Petey.Animation.LookDown);
				petey.Play(Petey.Animation.LookDownBlink);
				petey.Play(Petey.Animation.LookDownBlink);
				petey.Play(Petey.Animation.LookDownReturn);
				petey.Speak("Hey!  Who's the good looking bird?");
				petey.Play(Petey.Animation.Pleased);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			ShowPetey(visibleAtStartup);
		}

		private int JokeCount
		{
			get
			{
				if (jokeCount == -1)
				{
					jokeCount = PeteySpeech.GetCount("Joke");
				}

				return jokeCount;
			}
		}

		private int TipCount
		{
			get
			{
				if (tipCount == -1)
				{
					tipCount = PeteySpeech.GetCount("Tip");
				}

				return tipCount;
			}
		}

		private int GetNextJokeIndex()
		{
			jokeIndex++;
			if (jokeIndex >= JokeCount)
			{
				jokeIndex = 0;
				jokeIDs = null;
			}

			return jokeIndex;
		}

		private int GetNextTipIndex()
		{
			tipIndex++;
			if (tipIndex >= TipCount)
			{
				tipIndex = 0;
				tipIDs = null;
			}

			return tipIndex;
		}

		private int[] JokeIDs
		{
			get
			{
				if (jokeIDs == null)
				{
					int jokeCount = JokeCount;

					Random random = new Random();
					List<int> ids = new List<int>(jokeCount);
					for (int i = 1; i <= jokeCount; i++)
					{
						ids.Add(i);
					}

					jokeIDs = new int[jokeCount];
					for(int i=0; i < jokeCount; i++)
					{
						int idIndex = random.Next(0, ids.Count);
						jokeIDs[i] = ids[idIndex];
						ids.RemoveAt(idIndex);
					}
				}

				return jokeIDs;
			}
		}

		private int[] TipIDs
		{
			get
			{
				if (tipIDs == null)
				{
					int tipCount = TipCount;

					Random random = new Random();
					List<int> ids = new List<int>(tipCount);
					for (int i = 1; i <= tipCount; i++)
					{
						ids.Add(i);
					}

					tipIDs = new int[tipCount];
					for (int i = 0; i < tipCount; i++)
					{
						int idIndex = random.Next(0, ids.Count);
						tipIDs[i] = ids[idIndex];
						ids.RemoveAt(idIndex);
					}
				}

				return tipIDs;
			}
		}

		private void speakButton_Click(object sender, EventArgs e)
		{
			ShowPetey(true);

			Petey.Instance.Speak(sandboxTextBox.Text);
		}

		private void showButton_Click(object sender, EventArgs e)
		{
			Petey petey = Petey.Instance;
			ShowPetey(!petey.Visible);
		}

		private void RefreshButtons()
		{
			if (Petey.Instance.Visible)
			{
				showButton.Text = "Hide &Petey";
			}
			else
			{
				showButton.Text = "Show &Petey";
			}
		}

		private void ShowPetey(bool visible)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				Petey petey = Petey.Instance;

				if (visible)
				{
					Point point = this.DesktopLocation;
					petey.Show();
					petey.MoveTo((short)point.X, (short)point.Y);
				}
				else
				{
					petey.Hide();
				}

				RefreshButtons();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void jokeButton_Click(object sender, EventArgs e)
		{
			ShowPetey(true);

			PeteySpeech speech = PeteySpeech.GetByID("Joke", JokeIDs[GetNextJokeIndex()]);
			Petey.Instance.PeteySpeech(speech);
		}

		private void tipButton_Click(object sender, EventArgs e)
		{
			ShowPetey(true);

			PeteySpeech speech = PeteySpeech.GetByID("Tip", TipIDs[GetNextTipIndex()]);
			Petey.Instance.PeteySpeech(speech);
		}

		private void optionsButton_Click(object sender, EventArgs e)
		{
			Petey.Instance.ShowAdvancedCharacterOptions();
		}
	}
}