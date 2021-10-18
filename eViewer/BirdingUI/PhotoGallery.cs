using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;

namespace Thayer.Birding.UI
{
	public class PhotoGallery : Component
	{
		private const int NumberOrganismsPerRow = 4;
		private const int NumberRows = 5;
		private const int NumberOrganismsPerPage = 25;
		private const int PhotoSize = 325;

		private int[] organismIDs = null;
		private HTMLImageGenerator htmlImageGenerator = new HTMLImageGenerator();
		private IPhotoGalleryForm form = null;
		private int pageNumber = 1;
		private Dictionary<int, Organism> cache = new Dictionary<int, Organism>();

		public PhotoGallery()
		{
		}

		[DefaultValue(null)]
		public int[] OrganismIDs
		{
			get
			{
				return organismIDs;
			}

			set
			{
				organismIDs = value;
			}
		}

		[DefaultValue(1)]
		public int PageNumber
		{
			get
			{
				return pageNumber;
			}

			set
			{
				pageNumber = value;
			}
		}

		[DefaultValue(null)]
		public IPhotoGalleryForm PhotoGalleryForm
		{
			get
			{
				return form;
			}

			set
			{
				form = value;

				htmlImageGenerator.ImageGenerator = value;
			}
		}

		private Organism GetOrganism(int id)
		{
			Organism organism = null;

			if (!cache.TryGetValue(id, out organism))
			{
				organism = Organism.GetByID(id);
				cache[id] = organism;
			}

			return organism;
		}

		public string GeneratePhotoGalleryHTML()
		{
			return GeneratePhotoGalleryHTML(ImagePreferenceType.Primary);
		}

		public string GeneratePhotoGalleryHTML(ImagePreferenceType imagePreference)
		{
			// Calculate the number of pages
			int numberPages = organismIDs.Length / NumberOrganismsPerPage;
			if (organismIDs.Length % NumberOrganismsPerPage != 0)
			{
				numberPages++;
			}

			// Generate the paging html
			string pagingHtml = null;
			if (numberPages > 1)
			{
				StringBuilder pagingBuffer = new StringBuilder();

				pagingBuffer.Append("<span class=\"pagesLabel\">Pages:</span>&nbsp;&nbsp;");
				if (PageNumber > 1)
				{
					pagingBuffer.Append("<a href=\"bird://thayer.com/gallery?page=prev\">");
				}
				pagingBuffer.Append("[Previous]");
				if (PageNumber > 1)
				{
					pagingBuffer.Append("</a>");
				}
				for (int i = 0; i < numberPages; i++)
				{
					int currentPage = i + 1;
					pagingBuffer.Append("&nbsp;&nbsp;");
					if (PageNumber != currentPage)
					{
						pagingBuffer.AppendFormat("<a href=\"bird://thayer.com/gallery?page={0}", currentPage);
						pagingBuffer.Append("\">");
					}
					pagingBuffer.Append(currentPage);
					if (PageNumber != currentPage)
					{
						pagingBuffer.Append("</a>");
					}
				}
				pagingBuffer.Append("&nbsp;&nbsp;");
				if (PageNumber < numberPages)
				{
					pagingBuffer.Append("<a href=\"bird://thayer.com/gallery?page=next\">");
				}
				pagingBuffer.Append("[Next]");
				if (PageNumber < numberPages)
				{
					pagingBuffer.Append("</a>");
				}

				pagingHtml = pagingBuffer.ToString();
			}


			StringBuilder buffer = new StringBuilder("<html><head>");
			buffer.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">");
			buffer.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");

			buffer.Append("<style>");
			buffer.Append("body");
			buffer.Append("{");
			buffer.Append("font-family: Arial, \"Helvetica Neue\", Helvetica, sans-serif;");
			buffer.Append("background-color: #ffffff;");
			buffer.Append("}");

			buffer.Append("ul");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("margin: 0px;");
			buffer.Append("}");

			buffer.Append("li");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("vertical-align: top;");
			buffer.Append("text-align: center;");
			buffer.Append("margin: 10px;");
			buffer.Append("}");

			buffer.Append(".mainContainer");
			buffer.Append("{");
			buffer.Append("width: 100%;");
			buffer.Append("}");

			buffer.Append(".pagingContentTop, .pagingContentBottom, .pagesLabel");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("}");

			buffer.Append(".pagingContentTop, .pagingContentBottom");
			buffer.Append("{");
			buffer.Append("margin-bottom: 10px;");
			buffer.Append("}");

			buffer.Append(".pagingContentBottom");
			buffer.Append("{");
			buffer.Append("margin-top: 10px;");
			buffer.Append("}");

			buffer.Append(".pagesLabel");
			buffer.Append("{");
			buffer.Append("font-weight: bold;");
			buffer.Append("}");

			buffer.Append(".photoContent");
			buffer.Append("{");
			buffer.Append("text-align: center;");
			buffer.Append("}");

			buffer.Append(".caption");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("text-align: center;");
			buffer.AppendFormat("max-width: {0}px;", PhotoSize);
			buffer.Append("}");

			buffer.Append(".smallLink");
			buffer.Append("{");
			buffer.Append("font-size: 9pt;");
			buffer.Append("}");

			buffer.Append("</style>");
			buffer.Append("</head>");

			buffer.Append("<body>");
			buffer.Append("<div class=\"mainContainer\">");

			// Show the paging information
			if (pagingHtml != null)
			{
				buffer.Append("<div class=\"pagingContentTop\">");
				buffer.Append(pagingHtml);
				buffer.Append("</div>");
			}

			buffer.Append("<ul>");

			// Show the photos
			int startIndex = (PageNumber - 1) * NumberOrganismsPerPage;
			int endIndex = NumberOrganismsPerPage * PageNumber;
			for (int i = startIndex; i < endIndex; i++)
			{
				if (i >= organismIDs.Length)
				{
					break;
				}

				int id = organismIDs[i];
				Organism organism = GetOrganism(id);

				// Get the image index based on the image type requested by user
				int imageIndex = 0;
				switch (imagePreference)
				{
					case ImagePreferenceType.Primary:
						imageIndex = 0;
						break;
					case ImagePreferenceType.Secondary:
						if (organism.Photos.Count > 1)
						{
							imageIndex = 1;
						}
						else
						{
							imageIndex = 0;
						}
						break;
				}

				buffer.Append("<li>");
				buffer.Append("<div class=\"photoContent\">");
				buffer.Append(GeneratePhotoLink(organism.ID, organism.Photos[imageIndex], PhotoSize, true, true, true, organism.Sounds.Count > 0 ? organism.Sounds[0] : null, organism.CommonName.Name));
				buffer.Append("</div>");
				buffer.Append("</li>");
			}

			buffer.Append("</ul>");

			// Show the paging information
			if (pagingHtml != null)
			{
				buffer.Append("<div class=\"pagingContentBottom\">");
				buffer.Append(pagingHtml);
				buffer.Append("</div>");
			}

			buffer.Append("</div>");
			buffer.Append("</body>");
			buffer.Append("</html>");

			string htmlFilename = Path.Combine(ApplicationSettings.TemporaryDirectory, Guid.NewGuid().ToString() + ".html");
			using (StreamWriter writer = new StreamWriter(htmlFilename))
			{
				writer.Write(buffer.ToString());
			}

			return htmlFilename;
		}

		private string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			return htmlImageGenerator.GeneratePhotoLink(organismID, image, maxSize, zoomLinkActive, guideLinkActive, sound, commonName);
		}

		private string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool zoomListLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			return htmlImageGenerator.GeneratePhotoLink(organismID, image, maxSize, zoomLinkActive, zoomListLinkActive, guideLinkActive, sound, commonName);
		}

		public bool OnLinkClick(string link, out bool htmlDirty)
		{
			htmlDirty = false;
			bool handled = false;
			Uri uri = new Uri(link);
			string localPath = uri.LocalPath.Substring(uri.LocalPath.LastIndexOf('/') + 1);

			if (uri.Scheme == "bird")
			{
				NameValueCollection query = Utility.GetQueryNameValueCollection(uri.Query);
				handled = true;

				if (localPath == "gallery")
				{
					string page = query["page"];
					if (page == "prev")
					{
						PageNumber--;
					}
					else if (page == "next")
					{
						PageNumber++;
					}
					else
					{
						PageNumber = Convert.ToInt32(page);
					}

					htmlDirty = true;
				}
				else if (localPath == "zoom")
				{
					string type = query["t"];
					int mediaID = Convert.ToInt32(query["MediaID"]);
					bool isMediaCustom = Convert.ToBoolean(query["IsMediaCustom"]);
					int thingID = Convert.ToInt32(query["ThingID"]);
					Organism organism = GetOrganism(thingID);
					if (type == "snd")
					{
						form.PlaySound(organism.Sounds.GetByMediaID(mediaID, isMediaCustom).AbsolutePath, false);
					}
					else if (type == "ph")
					{
						ShowPhotos(organism, mediaID);
					}
				}
				else if (localPath == "zoomlist")
				{
					string type = query["t"];
					int mediaID = Convert.ToInt32(query["MediaID"]);
					bool isMediaCustom = Convert.ToBoolean(query["IsMediaCustom"]);
					int thingID = Convert.ToInt32(query["ThingID"]);
					Organism organism = GetOrganism(thingID);
					if (type == "snd")
					{
						form.PlaySound(organism.Sounds.GetByMediaID(mediaID, isMediaCustom).AbsolutePath, false);
					}
					else if (type == "ph")
					{
						ShowPhotoList(thingID, form.GetImagePreference());
					}
				}
				else if (localPath == "jump")
				{
					// Keep this functionality consistent throughout the application.  Either open up a new tab or not.  Also see EGuide.cs
					int thingID = Convert.ToInt32(query["ThingID"]);
					form.ShowNewBird(null, thingID);
				}
			}

			return handled;
		}

		private void ShowPhotos(Organism organism, int mediaID)
		{
			IMediaList list = organism.Photos;
			int count = list.Count;
			int index = 0;
			for (int i = 0; i < count; i++)
			{
				IMedia media = list[i];
				if (!File.Exists(media.AbsolutePath))
				{
					throw new MediaNotFoundException();
				}

				if (media.ID == mediaID)
				{
					index = i;
				}
			}

			form.ShowPhotos(organism.CommonName.Name, list.ToArray(), organism.Sounds.ToArray(), index);
		}

		private void ShowPhotoList(int selectedOrganismID, ImagePreferenceType imageType)
		{
			if (this.OrganismIDs != null)
			{
				int selectedListIndex = 0;
				List<PhotoListItem> photoListItems = new List<PhotoListItem>();

				try
				{
					form.ShowWorking(true);

					int index = 0;
					foreach (int id in this.OrganismIDs)
					{
						Organism organism = GetOrganism(id);
						if (id == selectedOrganismID)
						{
							selectedListIndex = index;
						}

						// Get the image index based on the image type requested by user
						int imageIndex = 0;
						switch (imageType)
						{
							case ImagePreferenceType.Primary:
								imageIndex = 0;
								break;
							case ImagePreferenceType.Secondary:
								if (organism.Photos.Count > 1)
								{
									imageIndex = 1;
								}
								else
								{
									imageIndex = 0;
								}
								break;
						}

						PhotoListItem photoListItem = new PhotoListItem();
						photoListItem.OrganismName = organism.CommonName.Name;
						photoListItem.Photo = organism.Photos[imageIndex];
						photoListItem.Sounds = organism.Sounds;

						photoListItems.Add(photoListItem);
						index++;
					}
				}
				finally
				{
					form.ShowWorking(false);
				}

				form.ShowPhotoList(photoListItems, selectedListIndex);
			}
		}
	}
}
