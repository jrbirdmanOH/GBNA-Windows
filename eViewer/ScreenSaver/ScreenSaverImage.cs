using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Thayer.Birding.ScreenSaver
{
	public class ScreenSaverImage
	{
		private string fileName = string.Empty;
		private string name = string.Empty;
		private int width = 0;
		private int height = 0;
		private string caption = string.Empty;
		private string copyright = string.Empty;

		public string FileName
		{
			get
			{
				return fileName;
			}

			set
			{
				fileName = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public int Width
		{
			get
			{
				return width;
			}

			set
			{
				width = value;
			}
		}

		public int Height
		{
			get
			{
				return height;
			}

			set
			{
				height = value;
			}
		}

		public string Caption
		{
			get
			{
				return caption;
			}

			set
			{
				caption = value;
			}
		}

		public string Copyright
		{
			get
			{
				return copyright;
			}

			set
			{
				copyright = value;
			}
		}

		public ScreenSaverImage()
		{
		}

		public Bitmap GetImage()
		{
			Bitmap image = null;

			if (File.Exists(this.FileName))
			{
				image = new Bitmap(this.FileName);
			}
			else
			{
				StringBuilder message = new StringBuilder("The Thayer Birding Software screen saver could ");
				message.Append("not find the image file \"");
				message.Append(this.FileName);
				message.Append("\".  If this problem continues, try recreating the screen saver by using the ");
				message.Append("\"Save As Screen Saver...\" menu option in the Custom List Manager ");
				message.Append("of the eField Guide Viewer application.");

				throw new ScreenSaverException(message.ToString());
			}

			return image;
		}
	}
}
