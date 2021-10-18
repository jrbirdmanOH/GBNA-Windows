using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class GenerateQuizProgressForm : Form
	{
		public GenerateQuizProgressForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		private void OnProgressUpdate(ProgressUpdateEventArgs e)
		{
			if(e.TaskDescription.Length > 0)
			{
				taskDescriptionLabel.Text = e.TaskDescription;
			}

			progressBar.Value = e.PercentComplete;
			percentCompleteLabel.Text = e.PercentComplete.ToString() + "% Complete";

			Update();
		}

		private void GenerateQuizProgressForm_Load(object sender, EventArgs e)
		{
			QuizEntry.ProgressUpdate += this.OnProgressUpdate;
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			QuizEntry.ProgressUpdate -= this.OnProgressUpdate;

			base.OnHandleDestroyed(e);
		}
	}
}