using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Thayer.Birding.UI
{
	internal class HTMLImageGenerator : Component
	{
		public const int SmallSize = 160;

		private IImageGenerator imageGenerator = null;
		private StringCollection temporaryFiles = new StringCollection();

		public HTMLImageGenerator()
		{
		}

		[DefaultValue(null)]
		public IImageGenerator ImageGenerator
		{
			get
			{
				return imageGenerator;
			}

			set
			{
				imageGenerator = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			while (temporaryFiles.Count > 0)
			{
				File.Delete(temporaryFiles[0]);
				temporaryFiles.RemoveAt(0);
			}

			base.Dispose(disposing);
		}

		public string GenerateAbundanceMapLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive)
		{
			return GenerateImageLink("am", organismID, image, maxSize, zoomLinkActive, false, null, null);
		}

		public string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive)
		{
			return GenerateImageLink("ph", organismID, image, maxSize, zoomLinkActive, false, null, null);
		}

		public string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			return GenerateImageLink("ph", organismID, image, maxSize, zoomLinkActive, guideLinkActive, sound, commonName);
		}

		public string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool zoomListLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			return GenerateImageLink("ph", organismID, image, maxSize, zoomLinkActive, zoomListLinkActive, guideLinkActive, sound, commonName);
		}

		private string GenerateImageLink(string type, int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			StringBuilder buffer = new StringBuilder("<a href=\"bird://thayer.com/zoom?t=");
			buffer.Append(type);
			buffer.Append("&MediaID=");
			buffer.Append(image.ID);
			buffer.Append("&IsMediaCustom=");
			buffer.Append(image.IsCustom.ToString());
			buffer.Append("&ThingID=");
			buffer.Append(organismID);
			buffer.Append("\">");

			string zoomLink = buffer.ToString();

			StringBuilder links = new StringBuilder();

			buffer = new StringBuilder(zoomLink);
			buffer.Append("<img border=\"0\" src=\"file://");
			buffer.Append(CreateTemporaryThumbnailImage(image, maxSize));
			buffer.Append("\" alt=\"");
			buffer.Append(image.FullCopyright);
			buffer.Append("\" />");
			buffer.Append("</a>");
			buffer.Append("<br />");
	
			buffer.Append("<div class=\"caption\">");
			if (commonName != null && commonName.Length > 0)
			{
				buffer.Append(commonName);
				buffer.Append(", ");
			}
			buffer.Append(image.Caption);
			buffer.Append("</div>");

			if (zoomLinkActive)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append(zoomLink);
				links.Append("zoom");
				links.Append("</a>");
			}

			if (guideLinkActive)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append("<a href=\"bird://thayer.com/jump?ThingID=");
				links.Append(organismID);
				links.Append("\">");
				links.Append("eField Guide");
				links.Append("</a>");
			}

			if (sound != null)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append("<a href=\"bird://thayer.com/zoom?t=snd&MediaID=");
				links.Append(sound.ID);
				links.Append("&IsMediaCustom=");
				links.Append(sound.IsCustom.ToString());
				links.Append("&ThingID=");
				links.Append(organismID);
				links.Append("\">");
				links.Append("sound");
				links.Append("</a>");
			}

			if (links.Length > 0)
			{
				buffer.Append("<span class=\"smallLink\">(");
				buffer.Append(links.ToString());
				buffer.Append(")</span>");
			}

			return buffer.ToString();
		}

		private string GenerateImageLink(string type, int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool zoomListLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			StringBuilder buffer = new StringBuilder("<a href=\"bird://thayer.com/zoom?t=");
			buffer.Append(type);
			buffer.Append("&MediaID=");
			buffer.Append(image.ID);
			buffer.Append("&IsMediaCustom=");
			buffer.Append(image.IsCustom.ToString());
			buffer.Append("&ThingID=");
			buffer.Append(organismID);
			buffer.Append("\">");

			string zoomLink = buffer.ToString();

			StringBuilder links = new StringBuilder();

			buffer = new StringBuilder(zoomLink);
			buffer.Append("<img border=\"0\" src=\"file://");
			buffer.Append(CreateTemporaryThumbnailImage(image, maxSize));
			buffer.Append("\" alt=\"");
			buffer.Append(image.FullCopyright);
			buffer.Append("\" />");
			buffer.Append("</a>");
			buffer.Append("<br />");

			buffer.Append("<div class=\"caption\">");
			if (commonName != null && commonName.Length > 0)
			{
				buffer.Append(commonName);
				buffer.Append(", ");
			}
			buffer.Append(image.Caption);
			buffer.Append("</div>");
	
			if (zoomLinkActive)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append(zoomLink);
				links.Append("zoom");
				links.Append("</a>");
			}

			if (zoomListLinkActive)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append("<a href=\"bird://thayer.com/zoomlist?t=");
				links.Append(type);
				links.Append("&MediaID=");
				links.Append(image.ID);
				links.Append("&IsMediaCustom=");
				links.Append(image.IsCustom.ToString());
				links.Append("&ThingID=");
				links.Append(organismID);
				links.Append("\">");
				links.Append("zoom list");
				links.Append("</a>");
			}

			if (guideLinkActive)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append("<a href=\"bird://thayer.com/jump?ThingID=");
				links.Append(organismID);
				links.Append("\">");
				links.Append("eField Guide");
				links.Append("</a>");
			}

			if (sound != null)
			{
				if (links.Length > 0)
				{
					links.Append(" | ");
				}

				links.Append("<a href=\"bird://thayer.com/zoom?t=snd&MediaID=");
				links.Append(sound.ID);
				links.Append("&IsMediaCustom=");
				links.Append(sound.IsCustom.ToString());
				links.Append("&ThingID=");
				links.Append(organismID);
				links.Append("\">");
				links.Append("sound");
				links.Append("</a>");
			}

			if (links.Length > 0)
			{
				buffer.Append("<span class=\"smallLink\">(");
				buffer.Append(links.ToString());
				buffer.Append(")</span>");
			}

			return buffer.ToString();
		}

		private string CreateTemporaryThumbnailImage(IMedia media, int maxSize)
		{
			string destination = Path.Combine(ApplicationSettings.TemporaryDirectory, Guid.NewGuid().ToString() + ".jpg");

			string mediaPath = media.AbsolutePath;
			if (!File.Exists(mediaPath))
			{
				throw new MediaNotFoundException();
			}

			ImageGenerator.GenerateImage(mediaPath, maxSize, maxSize, destination);
			temporaryFiles.Add(destination);

			return destination;
		}
	}
}
