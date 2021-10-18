using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

namespace Deploy
{
	public class FileTextBox : EditorWithText
	{
		public FileTextBox()
		{
			EditorButton browseButton = new EditorButton();
			browseButton.Text = "...";
			browseButton.Click += new EditorButtonEventHandler(browseButton_Click);

			ButtonsRight.Add(browseButton);
		}

		void browseButton_Click(object sender, EditorButtonEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.ShowDialog();
		}
	}
}
