using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text;
using Thayer.Birding.Filtering;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.UI
{
	public class EGuide : Component
	{
		private Collection collection = null;
		private Language language = null;
		private Organism bird = null;
		private IEGuideForm form = null;
		private List<SimilarSpecies> similarSpecies = null;
		private List<Organism> relatedSpecies = null;
		private HTMLImageGenerator htmlImageGenerator = new HTMLImageGenerator();
		private FilterCollection filters = null;

		private const int PrimarySize = 450;
		private const int AdditionalSize = 400;
		private const int RangeMapSize = 300;
		private const int AbundanceMapSize = 350;
		private const int VideoThumbnailSize = 175;
		private const int VideoCaptionSize = 225;
		private const int SimilarRelatedSize = 325;

		private const int LargeSize = 300;
		private const int MediumSize = 270;
		private const int NumberBirdColumns = 2;
		private const int NumberRelatedColumns = 4;
		private const int NumberSimilarColumns = 4;

		private StringCollection temporaryFiles = new StringCollection();

		public EGuide()
		{
		}

		public EGuide(int thingID, IEGuideForm form)
		{
			bird = Organism.GetByIDAndLanguage(thingID, Language.ID);
			EGuideForm = form;
		}

		public Collection Collection
		{
			get
			{
				return collection;
			}

			set
			{
				collection = value;
			}
		}

		[DefaultValue(null)]
		public Language Language
		{
			get
			{
				if (language == null)
				{
					language = Language.Default;
				}

				return language;
			}

			set
			{
				language = value;
			}
		}

		[DefaultValue(null)]
		public FilterCollection Filters
		{
			get
			{
				return filters;
			}

			set
			{
				filters = value;
			}
		}

		[DefaultValue(0)]
		public int OrganismID
		{
			get
			{
				return bird != null ? bird.ID : 0;
			}

			set
			{
				if (!DesignMode)
				{
					bird = Organism.GetByIDAndLanguage(value, Language.ID);
					similarSpecies = null;
					relatedSpecies = null;
				}
			}
		}

		public void RefreshOrganism()
		{
			bird = Organism.GetByIDAndLanguage(bird.ID, Language.ID);
		}

		[DefaultValue(null)]
		public IEGuideForm EGuideForm
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

		protected override void Dispose(bool disposing)
		{
			while(temporaryFiles.Count > 0)
			{
				File.Delete(temporaryFiles[0]);
				temporaryFiles.RemoveAt(0);
			}

			base.Dispose(disposing);
		}

		private List<SimilarSpecies> SimilarSpecies
		{
			get
			{
				if (similarSpecies == null)
				{
					similarSpecies = bird.GetSimilarSpecies(Collection.ID);
				}

				return similarSpecies;
			}
		}

		private List<Organism> RelatedSpecies
		{
			get
			{
				if (relatedSpecies == null)
				{
					relatedSpecies = new List<Organism>();
					List<int> list = bird.GetRelatedSpecies(Collection.ID, Collection.TaxonomyID);
					foreach (int organismID in list)
					{
						Organism organism = Organism.GetByIDAndLanguage(organismID, Language.ID);
						relatedSpecies.Add(organism);
					}
				}

				return relatedSpecies;
			}
		}

		public List<OrganismListItem> GetOrganismList()
		{
			return OrganismListItem.GetList(collection.ID, Language.ID, filters);
		}

		public string GenerateHTML()
		{
			OperatingSystem operatingSystem = ApplicationSettings.OperatingSystem;

			List<Sighting> sightings = Sighting.GetList(bird.ID);
			sightings.Sort(new SightingComparer(SightingComparer.SortableColumn.Date, SortOrder.Descending));

			StringBuilder buffer = new StringBuilder("<html><head>");
			buffer.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">");
			buffer.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
			buffer.Append("<title>");
			buffer.Append("GBNA - Guide to Birds of North America eField Guide: ");
			buffer.Append(bird.GetCommonName(Language.ID).Name);
			buffer.Append("</title>");


			buffer.Append("<style>");
			buffer.Append("body");
			buffer.Append("{");
			buffer.Append("font-family: Arial, \"Helvetica Neue\", Helvetica, sans-serif;");
			buffer.Append("background-color: #ffffff;");
			buffer.Append("}");

			buffer.Append("ul");
			buffer.Append("{");
			buffer.Append("font-size: 11pt;");
			buffer.Append("list-style-type: disc;");
			buffer.Append("}");

			buffer.Append("ul.inline");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("margin: 0px;");
			buffer.Append("}");

			buffer.Append("li.inline");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("vertical-align: top;");
			buffer.Append("text-align: center;");
			buffer.Append("margin: 10px;");
			buffer.Append("}");

			buffer.Append("li.inlineFullSection");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("vertical-align: top;");
			buffer.Append("width: 100%;");
			buffer.Append("}");

			buffer.Append("li.inlineSplitSection");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("vertical-align: top;");
			buffer.Append("width: 50%;");
			buffer.Append("}");

			buffer.Append(".mainContainer");
			buffer.Append("{");
			buffer.Append("width: 100%;");
			buffer.Append("min-width: 1000px;");
			buffer.Append("}");

			buffer.Append(".leftContentContainer");
			buffer.Append("{");
			buffer.Append("width: 500px;");
			buffer.Append("float: left;");
			buffer.Append("margin-left: -100%;");
			buffer.Append("}");

			buffer.Append(".rightContentContainer");
			buffer.Append("{");
			buffer.Append("width: 100%;");
			buffer.Append("float: left;");
			buffer.Append("}");

			buffer.Append(".rightContent");
			buffer.Append("{");
			buffer.Append("margin-left: 520px;");
			buffer.Append("}");

			buffer.Append(".leftHeadingContainer");
			buffer.Append("{");
			buffer.Append("width: 100%;");
			buffer.Append("}");

			buffer.Append(".sectionContainer");
			buffer.Append("{");
			buffer.Append("width: 100%;");
			buffer.Append("}");

			buffer.Append(".nameContainer");
			buffer.Append("{");
			buffer.Append("margin-bottom: 20px;");
			buffer.Append("}");

			buffer.Append(".commonName");
			buffer.Append("{");
			buffer.Append("font-size: 18pt;");
			buffer.Append("font-weight: bold;");
			buffer.Append("}");

			buffer.Append(".scientificName");
			buffer.Append("{");
			buffer.Append("font-size: 14pt;");
			buffer.Append("font-style: italic;");
			buffer.Append("}");

			buffer.Append(".photoContent, .mapContent, .videoContent");
			buffer.Append("{");
			buffer.Append("text-align: center;");
			buffer.Append("}");

			buffer.Append(".blue");
			buffer.Append("{");
			buffer.Append("background-color: #0090C2;");
			buffer.Append("}");

			buffer.Append(".orange");
			buffer.Append("{");
			buffer.Append("background-color: #d24400;");
			buffer.Append("}");

			buffer.Append(".leftSectionHeading, .fullSectionHeading, .splitSectionHeading");
			buffer.Append("{");
			buffer.Append("color: #ffffff;");
			buffer.Append("height: 30px;");
			buffer.Append("line-height: 30px;");
			buffer.Append("font-weight: bold;");
			buffer.Append("font-size: 14pt;");
			buffer.Append("}");

			buffer.Append(".fullSectionHeading");
			buffer.Append("{");
			buffer.Append("width: 100%;");
			buffer.Append("}");

			buffer.Append(".splitSectionHeading");
			buffer.Append("{");
			buffer.Append("width: 99%;");
			buffer.Append("}");

			buffer.Append(".fullSectionContent");
			buffer.Append("{");
			buffer.Append("margin-top: 7px;");
			buffer.Append("width: 100%;");
			buffer.Append("font-size: 11pt;");
			buffer.Append("}");

			buffer.Append(".splitSectionContent");
			buffer.Append("{");
			buffer.Append("margin-top: 7px;");
			buffer.Append("width: 99%;");
			buffer.Append("font-size: 11pt;");
			buffer.Append("}");

			buffer.Append(".fixedSectionContent");
			buffer.Append("{");
			buffer.Append("clear: both;");
			buffer.Append("}");

			buffer.Append(".fixedSectionRow");
			buffer.Append("{");
			buffer.Append("margin-top: 6px;");
			buffer.Append("}");

			buffer.Append(".fixedSectionRowLabel");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("font-size: 11pt;");
			buffer.Append("font-weight: bold;");
			buffer.Append("text-align: top;");
			buffer.Append("vertical-align: top;");
			buffer.Append("width: 126px;");
			buffer.Append("}");

			buffer.Append(".myInfoRowLabel");
			buffer.Append("{");
			buffer.Append("margin-bottom: 5px;");
			buffer.Append("}");

			buffer.Append(".fixedSectionRowContent");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("font-size: 11pt;");
			buffer.Append("width: 369px;");
			buffer.Append("margin-left: 5px;");
			buffer.Append("}");

			buffer.Append(".myInfoRowContent");
			buffer.Append("{");
			buffer.Append("margin-bottom: 5px;");
			buffer.Append("}");

			buffer.Append(".fixedSectionRowFull");
			buffer.Append("{");
			buffer.Append("display: inline-block;");
			buffer.Append("font-size: 11pt;");
			buffer.Append("width: 500px;");
			buffer.Append("}");

			buffer.Append(".sectionHeadingMarginSmall");
			buffer.Append("{");
			buffer.Append("margin-top: 5px;");
			buffer.Append("}");

			buffer.Append(".sectionHeadingMarginLarge");
			buffer.Append("{");
			buffer.Append("margin-top: 20px;");
			buffer.Append("}");

			buffer.Append(".identificationTipList, .characteristicList");
			buffer.Append("{");
			buffer.Append("margin-top: 0px;");
			buffer.Append("padding-left: 15px;");
			buffer.Append("padding-top: 0px;");
			buffer.Append("}");

			buffer.Append(".soundList");
			buffer.Append("{");
			buffer.Append("margin-top: 0px;");
			buffer.Append("margin-bottom: 10px;");
			buffer.Append("padding-bottom: 0px;");
			buffer.Append("}");

			buffer.Append(".habitatAndBehaviorContent");
			buffer.Append("{");
			buffer.Append("margin-left: 5px;");
			buffer.Append("margin-right: 5px;");
			buffer.Append("margin-bottom: 10px;");
			buffer.Append("}");

			buffer.Append(".titleHeading");
			buffer.Append("{");
			buffer.Append("margin-left: 10px;");
			buffer.Append("}");

			buffer.Append(".headingLink, .headingLink a");
			buffer.Append("{");
			buffer.Append("color: #ffffff;");
			buffer.Append("font-weight: bold;");
			buffer.Append("font-size: 10pt;");
			buffer.Append("vertical-align: top;");
			buffer.Append("}");

			buffer.Append(".headingLink");
			buffer.Append("{");
			buffer.Append("margin-left: 15px;");
			buffer.Append("}");

			buffer.Append(".caption");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("text-align: center;");
			buffer.AppendFormat("max-width: {0}px;", PrimarySize);
			buffer.Append("}");

			buffer.Append(".videoCaption");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("text-align: center;");
			buffer.AppendFormat("max-width: {0}px;", VideoCaptionSize);
			buffer.Append("}");

			buffer.Append(".smallLink");
			buffer.Append("{");
			buffer.Append("font-size: 9pt;");
			buffer.Append("}");

			buffer.Append(".referenceList, .languageList");
			buffer.Append("{");
			buffer.Append("margin-top: 0px;");
			buffer.Append("margin-bottom: 0px;");
			buffer.Append("padding-top: 0px;");
			buffer.Append("padding-bottom: 0px;");
			buffer.Append("}");

			buffer.Append(".referenceList li, .languageList li");
			buffer.Append("{");
			buffer.Append("padding-bottom: 4px;");
			buffer.Append("}");

			buffer.Append(".videoThumbnailImage");
			buffer.Append("{");
			buffer.AppendFormat("width: {0}px;", VideoThumbnailSize);
			buffer.Append("height: auto;");
			buffer.Append("border: none;");
			buffer.Append("}");

			buffer.Append(".sightingsTable");
			buffer.Append("{");
			buffer.Append("border-collapse: collapse;");
			buffer.Append("border-spacing: 0px;");
			buffer.Append("font-size: 11pt;");
			buffer.Append("}");

			buffer.Append(".sightingsTable td");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("}");

			buffer.Append(".sightingsTableRowSpacer");
			buffer.Append("{");
			buffer.Append("line-height: 10px;");
			buffer.Append("}");

			buffer.Append("</style>");
			
			buffer.Append("<script type=\"text/javascript\">");
			buffer.Append("var allSightingsVisible = false;");
			buffer.Append("function ToggleAdditionalSightings()");
			buffer.Append("{");
			buffer.Append("var partialSightings = document.getElementById('partialSightings');");
			buffer.Append("var allSightings = document.getElementById('allSightings');");
			buffer.Append("var sightingsLink = document.getElementById('sightingsLink');");
			buffer.Append("if(allSightingsVisible == true)");
			buffer.Append("{");
			buffer.Append("allSightingsVisible = false;");
			buffer.Append("allSightings.style.display = 'none';");
			buffer.Append("partialSightings.style.display = 'inline';");
			buffer.Append("sightingsLink.firstChild.data = 'show all';");
			buffer.Append("}");
			buffer.Append("else");
			buffer.Append("{");
			buffer.Append("allSightingsVisible = true;");
			buffer.Append("allSightings.style.display = 'inline';");
			buffer.Append("partialSightings.style.display = 'none';");
			buffer.Append("sightingsLink.firstChild.data = 'show less';");
			buffer.Append("}");
			buffer.Append("}");
			buffer.Append("</script>");

			buffer.Append("</head>");
			buffer.Append("<body>");
			buffer.Append("<div class=\"mainContainer\">");
			buffer.Append("<div class=\"rightContentContainer\">");
			buffer.Append("<div class=\"rightContent\">");

			buffer.Append("<ul class=\"inline\">");
			buffer.Append("<li class=\"inlineFullSection\">");
			buffer.Append("<div class=\"sectionContainer\">");
			buffer.Append("<div id=\"photoHeading\" class=\"fullSectionHeading blue\">");
			buffer.Append("<span class=\"titleHeading\">Photos</span>");
			if (bird.Photos.Count > 2)
			{
				buffer.Append("<span class=\"headingLink\">(<a href=\"#additionalPhotos\">Additional Photos</a>)</span>");
			}
			buffer.Append("</div>");
			buffer.Append("<div class=\"fullSectionContent\">");

			buffer.Append("<ul class=\"inline\">");

			// Show first two photos as the primary photos
			if (bird.Photos.Count == 1)
			{
				IMedia photo = bird.Photos[0];
				buffer.Append("<li class=\"inline\">");
				buffer.Append("<div class=\"photoContent\">");
				buffer.Append(GeneratePhotoLink(bird.ID, photo, PrimarySize, true));
				buffer.Append("</div>");
				buffer.Append("</li>");
			}
			else if (bird.Photos.Count > 1)
			{
				IMedia photo1 = bird.Photos[0];
				buffer.Append("<li class=\"inline\">");
				buffer.Append("<div class=\"photoContent\">");
				buffer.Append(GeneratePhotoLink(bird.ID, photo1, PrimarySize, true));
				buffer.Append("</div>");
				buffer.Append("</li>");

				IMedia photo2 = bird.Photos[1];
				buffer.Append("<li class=\"inline\">");
				buffer.Append("<div class=\"photoContent\">");
				buffer.Append(GeneratePhotoLink(bird.ID, photo2, PrimarySize, true));
				buffer.Append("</div>");
				buffer.Append("</li>");
			}
			buffer.Append("</ul>");

			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</li>");

			if (bird.Sounds.Count > 0)
			{
				buffer.Append("<li class=\"inlineSplitSection\">");
				buffer.Append("<div class=\"sectionContainer\">");
				buffer.Append("<div id=\"soundHeading\" class=\"splitSectionHeading sectionHeadingMarginSmall blue\">");
				buffer.Append("<span class=\"titleHeading\">Sounds</span>");
				buffer.Append("</div>");

				buffer.Append("<div class=\"splitSectionContent\">");
				buffer.Append("<ul class=\"soundList\">");
				foreach (IMedia media in bird.Sounds)
				{
					buffer.Append("<li>");
					buffer.Append(media.Caption);
					buffer.Append("&nbsp;<span class=\"smallLink\">");
					buffer.Append("(<a href=\"bird://thayer.com/zoom?t=snd&MediaID=");
					buffer.Append(media.ID);
					buffer.Append("&IsMediaCustom=");
					buffer.Append(media.IsCustom.ToString());
					buffer.Append("&ThingID=");
					buffer.Append(bird.ID);
					buffer.Append("\">play</a>&nbsp;|&nbsp;");
					buffer.Append("<a href=\"bird://thayer.com/zoom?t=sndloop&MediaID=");
					buffer.Append(media.ID);
					buffer.Append("&IsMediaCustom=");
					buffer.Append(media.IsCustom.ToString());
					buffer.Append("&ThingID=");
					buffer.Append(bird.ID);
					buffer.Append("\">loop</a>");
					if (form.SpectrogramSupported)
					{
						buffer.Append("&nbsp;|&nbsp;<a href=\"bird://thayer.com/zoom?t=spec&MediaID=");
						buffer.Append(media.ID);
						buffer.Append("&IsMediaCustom=");
						buffer.Append(media.IsCustom.ToString());
						buffer.Append("&ThingID=");
						buffer.Append(bird.ID);
						buffer.Append("\">spectrogram");
						buffer.Append("</a>");
					}
					buffer.Append(")");
					buffer.Append("</li>");
				}
				buffer.Append("</ul>");
				buffer.Append("</div>");
				buffer.Append("</div>");
				buffer.Append("</li>");
			}

			buffer.Append("<li class=\"inlineSplitSection\">");
			buffer.Append("<div class=\"sectionContainer\">");
			buffer.Append("<div id=\"habitatAndBehaviorHeading\" class=\"splitSectionHeading sectionHeadingMarginSmall blue\">");
			buffer.Append("<span class=\"titleHeading\">Habitat and Behavior</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"splitSectionContent\">");
			buffer.Append("<div class=\"habitatAndBehaviorContent\">");
			foreach (string characteristic in bird.Characteristics[CharacteristicType.Habitat])
			{
				buffer.Append(characteristic);
			}
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</li>");

			if (bird.Videos.Count > 0)
			{
				buffer.Append("<li class=\"inlineSplitSection\">");
				buffer.Append("<div class=\"sectionContainer\">");
				buffer.Append("<div id=\"videoHeading\" class=\"splitSectionHeading sectionHeadingMarginSmall blue\">");
				buffer.Append("<span class=\"titleHeading\">Videos</span>");
				buffer.Append("</div>");
				buffer.Append("<div class=\"splitSectionContent\">");
				buffer.Append("<ul class=\"inline\">");
				foreach (IMedia media in bird.Videos)
				{
					buffer.Append("<li class=\"inline\">");
					buffer.Append("<div class=\"videoContent\">");
					if (!File.Exists(media.AbsolutePath))
					{
						throw new MediaNotFoundException();
					}

					if (media.ThumbnailPath.Length > 0)
					{
						buffer.Append("<a href=\"bird://thayer.com/zoom?t=vid&MediaID=");
						buffer.Append(media.ID);
						buffer.Append("&IsMediaCustom=");
						buffer.Append(media.IsCustom.ToString());
						buffer.Append("&ThingID=");
						buffer.Append(bird.ID);
						buffer.Append("\">");
						buffer.Append("<img class=\"videoThumbnailImage\" src=\"file://");
						buffer.Append(Path.Combine(Environment.CurrentDirectory, media.ThumbnailPath));
						buffer.Append("\" /></a>");
					}

					buffer.Append("<br />");
					buffer.Append("<div class=\"videoCaption\">");
					if (media.Caption.Length > 0)
					{
						buffer.Append(media.Caption);
					}
					else
					{
						buffer.Append("video");
					}
					buffer.Append("</div>");
					buffer.Append("<span class=\"smallLink\">");
					buffer.Append("(<a href=\"bird://thayer.com/zoom?t=vid&MediaID=");
					buffer.Append(media.ID);
					buffer.Append("&IsMediaCustom=");
					buffer.Append(media.IsCustom.ToString());
					buffer.Append("&ThingID=");
					buffer.Append(bird.ID);
					buffer.Append("\">play</a>)");
					buffer.Append("</span>");
					buffer.Append("</div>");
					buffer.Append("</li>");
				}
				buffer.Append("</ul>");
				buffer.Append("</div>");
				buffer.Append("</div>");
				buffer.Append("</li>");
			}

			buffer.Append("<li class=\"inlineSplitSection\">");
			buffer.Append("<div class=\"sectionContainer\">");
			buffer.Append("<div id=\"rangeMapHeading\" class=\"splitSectionHeading sectionHeadingMarginSmall blue\">");
			buffer.Append("<span class=\"titleHeading\">Range Map</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"splitSectionContent\">");
			buffer.Append("<ul class=\"inline\">");
			buffer.Append("<li class=\"inline\">");
			buffer.Append("<div class=\"mapContent\">");
			IMedia rangeMap = bird.RangeMaps[0];
			StringBuilder zoomLink = new StringBuilder();
			zoomLink.Append("<a href=\"bird://thayer.com/zoom?t=rm&MediaID=");
			zoomLink.Append(rangeMap.ID);
			zoomLink.Append("&IsMediaCustom=");
			zoomLink.Append(rangeMap.IsCustom.ToString());
			zoomLink.Append("&ThingID=");
			zoomLink.Append(bird.ID);
			zoomLink.Append("\">");
			string rangeMapZoomLink = zoomLink.ToString();
			buffer.Append(rangeMapZoomLink);
			buffer.Append("<img border=\"0\" src=\"file://");
			buffer.Append(CreateTemporaryThumbnailImage(rangeMap, RangeMapSize));
			buffer.Append("\" alt=\"");
			buffer.Append(rangeMap.FullCopyright);
			buffer.Append("\" />");
			buffer.Append("</a>");
			buffer.Append("<br />");
			buffer.Append("<div class=\"caption\">");
			if (rangeMap.Caption.Length > 0)
			{
				// For now, do not show the range map caption
//				buffer.Append(rangeMap.Caption);
				buffer.Append("range map");
			}
			else
			{
				buffer.Append("range map");
			}
			buffer.Append("</div>");
			buffer.Append("<span class=\"smallLink\">");
			buffer.Append("(");
			buffer.Append(rangeMapZoomLink);
			buffer.Append("zoom</a>)");
			buffer.Append("</span>");
			if (bird.WorldRangeMap != null)
			{
				buffer.Append("<br />");
				buffer.Append("<span class=\"smallLink\">");
				buffer.Append("(<a href=\"");
				buffer.Append(bird.WorldRangeMap.Link);
				buffer.Append("\" />");
				buffer.Append("eBird world map</a>)");
				buffer.Append("</span>");
			}
			if (bird.AnimatedRangeMap != null)
			{
				buffer.Append("<br />");
				buffer.Append("<span class=\"smallLink\">");
				buffer.Append("(<a href=\"");
				buffer.Append(bird.AnimatedRangeMap.Link);
				buffer.Append("\" />");
				buffer.Append("animated range map</a>)");
				buffer.Append("</span>");
			}
			buffer.Append("</div>");
			buffer.Append("</li>");
			buffer.Append("</ul>");
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</li>");



			if (bird.AbundanceMaps.Count > 0)
			{
				buffer.Append("<li class=\"inlineFullSection\">");
				buffer.Append("<div class=\"sectionContainer\">");
				buffer.Append("<div id=\"abundanceMapHeading\" class=\"fullSectionHeading sectionHeadingMarginSmall blue\">");
				buffer.Append("<span class=\"titleHeading\">Abundance Maps</span>");
				buffer.Append("</div>");
				buffer.Append("<div class=\"fullSectionContent\">");

				buffer.Append("<ul class=\"inline\">");
				foreach (IMedia abundanceMap in bird.AbundanceMaps)
				{
					buffer.Append("<li class=\"inline\">");
					buffer.Append("<div class=\"mapContent\">");
					buffer.Append(GenerateAbundanceMapLink(bird.ID, abundanceMap, AbundanceMapSize, true));
					buffer.Append("</div>");
					buffer.Append("</li>");
				}
				buffer.Append("</ul>");
				buffer.Append("</div>");
				buffer.Append("</div>");
				buffer.Append("</li>");
			}

			if (bird.Photos.Count > 2)
			{
				buffer.Append("<li class=\"inlineFullSection\">");
				buffer.Append("<div class=\"sectionContainer\">");
				buffer.Append("<div id=\"additionalPhotosHeading\" class=\"fullSectionHeading sectionHeadingMarginSmall blue\">");
				buffer.Append("<span class=\"titleHeading\">Additional Photos</span><a name=\"additionalPhotos\"></a>");
				buffer.Append("</div>");
				buffer.Append("<div class=\"fullSectionContent\">");

				buffer.Append("<ul class=\"inline\">");
				for (int photoIndex = 2; photoIndex < bird.Photos.Count; photoIndex++)
				{
					IMedia photo = bird.Photos[photoIndex];
					buffer.Append("<li class=\"inline\">");
					buffer.Append("<div class=\"photoContent\">");
					buffer.Append(GeneratePhotoLink(bird.ID, photo, AdditionalSize, true));
					buffer.Append("</div>");
					buffer.Append("</li>");
				}
				buffer.Append("</ul>");
				buffer.Append("</div>");
				buffer.Append("</div>");
				buffer.Append("</li>");
			}

			buffer.Append("</div>");
			buffer.Append("</div>");



			buffer.Append("<div class=\"leftContentContainer\">");

			buffer.Append("<div class=\"nameContainer\">");
			buffer.Append("<span class=\"commonName\">");
			buffer.Append(bird.GetCommonName(Language.ID).Name);
			buffer.Append("</span>");
			if (Language.IsEnglish && operatingSystem == OperatingSystem.Windows)
			{
				buffer.Append("<span class=\"smallLink\">");
				buffer.Append("&nbsp;(<a href=\"bird://thayer.com/speech?ThingID=");
				buffer.Append(bird.ID);
				buffer.Append("\">pronounce</a>)");
				buffer.Append("</span>");
			}
			buffer.Append("<br />");
			buffer.Append("<span class=\"scientificName\">");
			buffer.Append("(");
			buffer.Append(bird.ScientificName);
			buffer.Append(")");
			buffer.Append("</span>");
			buffer.Append("</div>");

			buffer.Append("<div class=\"leftHeadingContainer\">");
			buffer.Append("<div id=\"classificationHeading\" class=\"leftSectionHeading orange\">");
			buffer.Append("<span class=\"titleHeading\">Classification</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionContent\">");

			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowLabel\">");
			buffer.Append("<span>Order</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionRowContent\">");
			buffer.Append("<span>");
			buffer.Append(bird.Order.Name);
			buffer.Append("&nbsp;--&nbsp;");
			buffer.Append(bird.Order.Description);
			buffer.Append("</span>");
			buffer.Append("<br />");
			buffer.Append("<span class=\"smallLink\">");
			buffer.Append("(<a href=\"bird://thayer.com/tax?t=ORDER&ThingID=");
			buffer.Append(bird.ID);
			buffer.Append("\">full description</a>)");
			buffer.Append("</span>");
			buffer.Append("</div>");
			buffer.Append("</div>");

			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowLabel\">");
			buffer.Append("<span>Family</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionRowContent\">");
			buffer.Append("<span>");
			buffer.Append(bird.Family.Name);
			buffer.Append("&nbsp;--&nbsp;");
			buffer.Append(bird.Family.Description);
			buffer.Append("</span>");
			buffer.Append("<br />");
			buffer.Append("<span class=\"smallLink\">");
			buffer.Append("(<a href=\"bird://thayer.com/tax?t=FAMILYNAR&ThingID=");
			buffer.Append(bird.ID);
			buffer.Append("\">full description</a>)");
			buffer.Append("</span>");
			buffer.Append("</div>");
			buffer.Append("</div>");

			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowLabel\">");
			buffer.Append("<span>Size</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionRowContent\">");
			buffer.Append("<span>");
			foreach (string characteristic in bird.Characteristics[CharacteristicType.Size])
			{
				buffer.Append(characteristic);
			}
			buffer.Append("</span>");
			buffer.Append("</div>");
			buffer.Append("</div>");

			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowLabel\">");
			buffer.Append("<span>Abundance</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionRowContent\">");
			buffer.Append("<span>");
			foreach (string characteristic in bird.Characteristics[CharacteristicType.Abundance])
			{
				buffer.Append(characteristic);
			}
			buffer.Append("</span>");
			buffer.Append("</div>");
			buffer.Append("</div>");

			BandCode bandCode = bird.BandCode;
			if (bandCode != null)
			{
				buffer.Append("<div class=\"fixedSectionRow\">");
				buffer.Append("<div class=\"fixedSectionRowLabel\">");
				buffer.Append("<span>Bird Codes</span>");
				buffer.Append("</div>");
				buffer.Append("<div class=\"fixedSectionRowContent\">");
				buffer.Append("<span>");
				buffer.Append(bandCode.Code);
				buffer.Append("</span>");
				buffer.Append("</div>");
				buffer.Append("</div>");
			}

			buffer.Append("</div>");
			buffer.Append("</div>");



			bool showIdentificationSection = false;
			CharacteristicCollection identificationTips = bird.Characteristics[CharacteristicType.IdentificationTips];
			if (identificationTips.Count > 0)
			{
				showIdentificationSection = true;
			}
			else
			{
				foreach (string key in bird.Characteristics.Keys)
				{
					if (key != CharacteristicType.Abundance &&
						key != CharacteristicType.Habitat &&
						key != CharacteristicType.IdentificationTips &&
						key != CharacteristicType.Reference &&
						key != CharacteristicType.Size)
					{
						CharacteristicCollection characteristics = bird.Characteristics[key];
						if (characteristics.Count > 0)
						{
							showIdentificationSection = true;
							break;
						}
					}
				}
			}

			if (showIdentificationSection)
			{
				buffer.Append("<div class=\"leftHeadingContainer\">");
				buffer.Append("<div id=\"identificationHeading\" class=\"leftSectionHeading sectionHeadingMarginLarge orange\">");
				buffer.Append("<span class=\"titleHeading\">Identification</span>");
				buffer.Append("</div>");
				buffer.Append("<div class=\"fixedSectionContent\">");

				if (identificationTips.Count > 0)
				{
					buffer.Append("<div class=\"fixedSectionRow\">");
					buffer.Append("<div class=\"fixedSectionRowLabel\">");
					buffer.Append("<span>Identification<br/>Tips</span>");
					buffer.Append("</div>");
					buffer.Append("<div class=\"fixedSectionRowContent\">");
					buffer.Append("<ul class=\"identificationTipList\">");
					foreach (string identificationTip in identificationTips)
					{
						buffer.Append("<li>");
						buffer.Append(identificationTip);
						buffer.Append("</li>");
					}
					buffer.Append("</ul>");
					buffer.Append("</div>");
					buffer.Append("</div>");
				}

				foreach (string key in bird.Characteristics.Keys)
				{
					if (key != CharacteristicType.Abundance &&
						key != CharacteristicType.Habitat &&
						key != CharacteristicType.IdentificationTips &&
						key != CharacteristicType.Reference &&
						key != CharacteristicType.Size)
					{
						CharacteristicCollection characteristics = bird.Characteristics[key];
						if (characteristics.Count > 0)
						{
							buffer.Append("<div class=\"fixedSectionRow\">");
							buffer.Append("<div class=\"fixedSectionRowLabel\">");
							buffer.Append("<span>");
							buffer.Append(key);
							buffer.Append("</span>");
							buffer.Append("</div>");
							buffer.Append("<div class=\"fixedSectionRowContent\">");
							if (characteristics.Count == 1)
							{
								buffer.Append("<span>");
								foreach (string characteristic in characteristics)
								{
									buffer.Append(characteristic);
								}
								buffer.Append("</span>");
							}
							else if (characteristics.Count > 1)
							{
								buffer.Append("<ul class=\"characteristicList\">");
								foreach (string characteristic in characteristics)
								{
									buffer.Append("<li>");
									buffer.Append(characteristic);
									buffer.Append("</li>");
								}
								buffer.Append("</ul>");
							}
							buffer.Append("</div>");
							buffer.Append("</div>");
						}
					}
				}

				buffer.Append("</div>");
				buffer.Append("</div>");
			}



			buffer.Append("<div class=\"leftHeadingContainer\">");
			buffer.Append("<div id=\"myInfoHeading\" class=\"leftSectionHeading sectionHeadingMarginLarge orange\">");
			buffer.Append("<span class=\"titleHeading\">My Info</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionContent\">");

			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowLabel myInfoRowLabel\">");
			buffer.Append("<span>My Sightings</span>");
			buffer.Append("<br />");
			buffer.Append("<span class=\"smallLink\">(<a href=\"bird://thayer.com/sightings?t=ADD&ThingID=");
			buffer.Append(bird.ID);
			buffer.Append("\">Add</a>)</span>");
			buffer.Append("<span class=\"smallLink\">&nbsp;(<a href=\"bird://thayer.com/sightings?t=MANAGE&ThingID=");
			buffer.Append(bird.ID);
			buffer.Append("\">Edit</a>)</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionRowContent myInfoRowContent\">");

			int sightingsCount = sightings.Count;
			if (sightingsCount > 0)
			{
				bool hideSightingsComments = UserSettings.Instance.HideSightingsComments;
				bool limitSightings = UserSettings.Instance.LimitNumberOfSightingsToDisplay;
				int maxNumberOfSightings = UserSettings.Instance.NumberOfSightingsToDisplayLimit;
				bool hasMoreSightings = false;
				if (limitSightings && sightingsCount > maxNumberOfSightings)
				{
					hasMoreSightings = true;
				}
				buffer.Append("<div id=\"partialSightings\">");
				buffer.Append("<table class=\"sightingsTable\">");
				int numSightingsToDisplay = hasMoreSightings == true ? maxNumberOfSightings : sightingsCount;
				for (int i = 0; i < numSightingsToDisplay; i++)
				{
					if (i > 0)
					{
						buffer.Append("<tr class=\"sightingsTableRowSpacer\">");
						buffer.Append("<td colspan=\"3\">");
						buffer.Append("&nbsp;");
						buffer.Append("</td>");
						buffer.Append("</tr>");
					}

					Sighting sighting = sightings[i];
					buffer.Append("<tr>");
					buffer.Append("<td>");
					buffer.Append(sighting.Date.ToShortDateString());
					buffer.Append("</td>");
					buffer.Append("<td>");
					buffer.Append("&nbsp;&nbsp;&nbsp;");
					buffer.Append("</td>");
					buffer.Append("<td>");
					buffer.Append(sighting.Location.Text);
					buffer.Append("</td>");
					buffer.Append("</tr>");
					if (!hideSightingsComments)
					{
						if (sighting.Comments.Length > 0)
						{
							buffer.Append("<tr>");
							buffer.Append("<td colspan=\"3\">");
							buffer.Append(sighting.Comments);
							buffer.Append("</td>");
							buffer.Append("</tr>");
						}
					}
				}
				buffer.Append("</table>");
				buffer.Append("</div>");

				if (hasMoreSightings)
				{
					buffer.Append("<div id=\"allSightings\" style=\"display:none\">");
					buffer.Append("<table class=\"sightingsTable\">");
					for (int i = 0; i < sightingsCount; i++)
					{
						if (i > 0)
						{
							buffer.Append("<tr class=\"sightingsTableRowSpacer\">");
							buffer.Append("<td colspan=\"3\">");
							buffer.Append("&nbsp;");
							buffer.Append("</td>");
							buffer.Append("</tr>");
						}
						Sighting sighting = sightings[i];
						buffer.Append("<tr>");
						buffer.Append("<td>");
						buffer.Append(sighting.Date.ToShortDateString());
						buffer.Append("</td>");
						buffer.Append("<td>");
						buffer.Append("&nbsp;&nbsp;&nbsp;");
						buffer.Append("</td>");
						buffer.Append("<td>");
						buffer.Append(sighting.Location.Text);
						buffer.Append("</td>");
						buffer.Append("</tr>");
						if (!hideSightingsComments)
						{
							if (sighting.Comments.Length > 0)
							{
								buffer.Append("<tr>");
								buffer.Append("<td colspan=\"3\">");
								buffer.Append(sighting.Comments);
								buffer.Append("</td>");
								buffer.Append("</tr>");
							}
						}
					}
					buffer.Append("</table>");
					buffer.Append("</div>");
					buffer.Append("<table class=\"sightingsTable\">");
					buffer.Append("<tr>");
					buffer.Append("<td colspan=\"3\">");
					buffer.Append("<span class=\"smallLink\">(<a href=\"javascript:ToggleAdditionalSightings();\" id=\"sightingsLink\">show all</a>)</span>");
					buffer.Append("</td>");
					buffer.Append("</tr>");
					buffer.Append("</table>");
				}
			}

			buffer.Append("</div>");
			buffer.Append("</div>");

			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowLabel myInfoRowLabel\">");
			buffer.Append("<span>My Comments</span>");
			buffer.Append("<br />");
			buffer.Append("<span class=\"smallLink\">(<a href=\"bird://thayer.com/notes?ThingID=");
			buffer.Append(bird.ID);
			buffer.Append("\">Add/Edit</a>)</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionRowContent myInfoRowContent\">");
			buffer.Append("<span>");
			buffer.Append(bird.Notes);
			buffer.Append("</span>");
			buffer.Append("</div>");
			buffer.Append("</div>");

			if (ApplicationSettings.OperatingSystem == OperatingSystem.Windows)
			{
				buffer.Append("<div class=\"fixedSectionRow\">");
				buffer.Append("<div class=\"fixedSectionRowLabel\">");
				buffer.Append("<span>My Media</span>");
				buffer.Append("<br />");
				buffer.Append("<span class=\"smallLink\">(<a href=\"bird://thayer.com/media?ThingID=");
				buffer.Append(bird.ID);
				buffer.Append("\">Add/Edit</a>)</span>");
				buffer.Append("</div>");
				buffer.Append("</div>");
			}

			buffer.Append("</div>");
			buffer.Append("</div>");



			buffer.Append("<div class=\"leftHeadingContainer\">");
			buffer.Append("<div id=\"referencesHeading\" class=\"leftSectionHeading sectionHeadingMarginLarge orange\">");
			buffer.Append("<span class=\"titleHeading\">References</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionContent\">");
			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowFull\">");

			buffer.Append("<ul class=\"referenceList\">");

			foreach (Reference reference in bird.References)
			{
				// Do not show Thayer Birding reference link
				if (reference.Code != Reference.ThayerBirding.Code)
				{
					buffer.Append("<li>");
					buffer.Append("<a href=\"bird://thayer.com/ref?t=");
					buffer.Append(reference.Code);
					buffer.Append("&ThingID=");
					buffer.Append(bird.ID);
					buffer.Append("\">");
					buffer.Append(reference.Text);
					buffer.Append("</a>");
					buffer.Append("</li>");
				}
			}
			buffer.Append("</ul>");
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</div>");



			buffer.Append("<div class=\"leftHeadingContainer\">");
			buffer.Append("<div id=\"languagesHeading\" class=\"leftSectionHeading sectionHeadingMarginLarge orange\">");
			buffer.Append("<span class=\"titleHeading\">Languages</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"fixedSectionContent\">");
			buffer.Append("<div class=\"fixedSectionRow\">");
			buffer.Append("<div class=\"fixedSectionRowFull\">");

			buffer.Append("<ul class=\"languageList\">");

			foreach (LanguageString value in bird.Languages)
			{
				buffer.Append("<li>");
				buffer.Append(value.Text);
				buffer.Append(" (");
				buffer.Append(value.Language);
				buffer.Append(")");
				buffer.Append("</li>");
			}
			buffer.Append("</ul>");
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</div>");



			buffer.Append("</div>");
			buffer.Append("</div>");
			buffer.Append("</body></html>");

			string htmlFilename = Path.Combine(ApplicationSettings.TemporaryDirectory, Guid.NewGuid().ToString() + ".html");
			using (StreamWriter writer = new StreamWriter(htmlFilename))
			{
				writer.Write(buffer.ToString());
			}

			return htmlFilename;
		}

		public bool OnLinkClick(string link)
		{
			bool handled = false;
			Uri uri = new Uri(link);
			string localPath = uri.LocalPath.Substring(uri.LocalPath.LastIndexOf('/') + 1);

			NameValueCollection query = Utility.GetQueryNameValueCollection(uri.Query);
			if (uri.Scheme == "bird")
			{
				handled = true;

				if (localPath == "zoom")
				{
					string type = query["t"];
					int mediaID = Convert.ToInt32(query["MediaID"]);
					bool isMediaCustom = Convert.ToBoolean(query["IsMediaCustom"]);
					int thingID = Convert.ToInt32(query["ThingID"]);
					Organism organism = null;
					if (bird.ID == thingID)
					{
						organism = bird;
					}
					else
					{
						foreach (SimilarSpecies species in SimilarSpecies)
						{
							if (species.ThingID == thingID)
							{
								organism = species.Organism;
								break;
							}
						}

						if (organism == null)
						{
							foreach (Organism species in RelatedSpecies)
							{
								if (species.ID == thingID)
								{
									organism = species;
									break;
								}
							}
						}
					}

					if (type == "snd")
					{
						form.PlaySound(organism.Sounds.GetByMediaID(mediaID, isMediaCustom).AbsolutePath, false);
					}
					else if (type == "sndloop")
					{
						form.PlaySound(organism.Sounds.GetByMediaID(mediaID, isMediaCustom).AbsolutePath, true);
					}
					else if (type == "ph")
					{
						ShowPhotos(organism, mediaID,isMediaCustom);
					}
					else if (type == "am")
					{
						ShowAbundanceMap(organism, mediaID, isMediaCustom);
					}
					else if (type == "rm")
					{
						ShowRangeMap(organism, mediaID, isMediaCustom);
					}
					else if (type == "vid")
					{
						form.PlayVideo(organism.GetCommonName(Language.ID).Name, organism.Videos.GetByMediaID(mediaID, isMediaCustom));
					}
					else if (type == "spec")
					{
						form.OpenSpectrogram(organism.Sounds.GetByMediaID(mediaID, isMediaCustom).AbsolutePath);
					}
				}
				else if (localPath == "speech")
				{
					CommonName commonName = bird.GetCommonName(Language.ID);

					StringBuilder actualPhrase = new StringBuilder(commonName.Name);
					actualPhrase.Append(". ");
					actualPhrase.Append(bird.ScientificName);
					actualPhrase.Append(". ");

					StringBuilder speakPhrase = new StringBuilder(commonName.Pronunciation);
					speakPhrase.Append(". ");
					speakPhrase.Append(bird.ScientificNamePronunciation);
					speakPhrase.Append(". ");

					form.Pronounce(actualPhrase.ToString(), speakPhrase.ToString());
				}
				else if (localPath == "notes")
				{
					form.ShowNotes(bird.Notes);
				}
				else if (localPath == "media")
				{
					form.ManageMedia(bird);
				}
				else if (localPath == "sightings")
				{
					string type = query["t"];
					if (type == "ADD")
					{
						Sighting sighting = new Sighting();
						sighting.Organism.ID = bird.ID;
						form.AddSighting(sighting);
					}
					else if (type == "MANAGE")
					{
						form.ManageSightings(bird);
					}
				}
				else if (localPath == "tax")
				{
					string type = query["t"];
					if (type == "ORDER")
					{
						form.ShowNarrative("Order - " + bird.Order.Name, bird.Order.Narrative);
					}
					else if (type == "FAMILYNAR")
					{
						form.ShowNarrative("Family - " + bird.Family.Name, bird.Family.Narrative);
					}
				}
				else if (localPath == "ref")
				{
					string type = query["t"];
					if (type == Reference.BirdersHandbook.Code)
					{
						ShowBirdersHandbook();
					}
					else if (type == Reference.SibleysBirdsOfTheWorld.Code)
					{
						form.ShowSibleysBirdsOfTheWorld(bird.ScientificName);
					}
					else if (type == Reference.ThayerBirding.Code)
					{
						string licenseKey = string.Empty;
						string password = string.Empty;

						// TODO Generate valid License Key and Password
						if (ThayerLicenseManager.Instance.Licenses.Count > 0)
						{
							licenseKey = ThayerLicenseManager.Instance.Licenses[0].LicenseKey;
						}

						StringBuilder url = new StringBuilder("http://www.thayerbirding.com/eFieldGuides/redir.asp?ThingID=");
						url.Append(bird.ID);
						url.Append("&LicenseKey=");
						url.Append(licenseKey);
						url.Append("&Password=");
						url.Append(password);

						form.OpenBrowser(url.ToString());
					}
					else if (type == Reference.Flickr.Code)
					{
						StringBuilder url = new StringBuilder("http://www.flickr.com/search?q=");
						url.Append(bird.Genus.Name);
						url.Append("+");
						url.Append(bird.Species.Name);

						form.OpenBrowser(url.ToString());
					}
					else if (type == Reference.Bing.Code)
					{
						StringBuilder url = new StringBuilder("http://www.bing.com/images/search?q=");
						if (bird.CommonName.First.Length > 0)
						{
							url.Append(bird.CommonName.First);
							url.Append("+");
						}
						url.Append(bird.CommonName.Last);
						url.Append("+");
						url.Append("bird");

						form.OpenBrowser(url.ToString());
					}
					else if (type == Reference.GoogleCommonName.Code)
					{
						StringBuilder url = new StringBuilder("http://www.google.com/search?q=");
						if (bird.CommonName.First.Length > 0)
						{
							url.Append(bird.CommonName.First);
							url.Append("+");
						}
						url.Append(bird.CommonName.Last);
						url.Append("+");
						url.Append("bird");

						form.OpenBrowser(url.ToString());
					}
					else if (type == Reference.GoogleScientificName.Code)
					{
						StringBuilder url = new StringBuilder("http://www.google.com/search?q=");
						url.Append(bird.Genus.Name);
						url.Append("+");
						url.Append(bird.Species.Name);

						form.OpenBrowser(url.ToString());
					}
					else if (type == Reference.Wikipedia.Code)
					{
						StringBuilder url = new StringBuilder("http://en.wikipedia.org/wiki/");
						if (bird.CommonName.First.Length > 0)
						{
							url.Append(bird.CommonName.First);
							url.Append("_");
						}
						url.Append(bird.CommonName.Last);

						form.OpenBrowser(url.ToString());
					}
					else if (type == Reference.InternetBirdCollection.Code)
					{
						StringBuilder url = new StringBuilder("http://ibc.lynxeds.com/species/");
						if (bird.CommonName.First.Length > 0)
						{
							url.Append(bird.CommonName.First.Replace("'", "").Replace(" ", "-"));
							url.Append("-");
						}
						url.Append(bird.CommonName.Last.Replace("'", "").Replace(" ", "-"));
						url.Append("-");
						url.Append(bird.Genus.Name);
						url.Append("-");
						url.Append(bird.Species.Name);

						form.OpenBrowser(url.ToString().ToLower());
					}
					else if (type == Reference.XenoCanto.Code)
					{
						StringBuilder url = new StringBuilder("http://www.xeno-canto.org/species/");
						url.Append(bird.Genus.Name);
						url.Append("-");
						url.Append(bird.Species.Name);

						form.OpenBrowser(url.ToString().ToLower());
					}
					else if (type == Reference.AllAboutBirds.Code)
					{
						StringBuilder url = new StringBuilder("http://www.allaboutbirds.org/guide/");
						if (bird.CommonName.First.Length > 0)
						{
							url.Append(bird.CommonName.First.Replace("'", "").Replace(" ", "_"));
							url.Append("_");
						}
						url.Append(bird.CommonName.Last.Replace("'", "").Replace(" ", "_"));
						url.Append("/id");

						form.OpenBrowser(url.ToString().ToLower());
					}
					else if (type == Reference.EBird.Code)
					{
						StringBuilder url = new StringBuilder("http://ebird.org/media/catalog?taxonCode=");
						url.Append(bird.EBirdReference.TaxonCode);

						form.OpenBrowser(url.ToString());
					}
				}
				else if (localPath == "jump")
				{
					// Keep this functionality consistent throughout the application.  Either open up a new tab or not.  Also see PhotoGallery.cs
					int thingID = Convert.ToInt32(query["ThingID"]);
					form.ShowNewBird(this.Collection, thingID);
				}
				else if (localPath == "imagepref")
				{
					ImagePreferenceType imagePreference = (ImagePreferenceType)Enum.Parse(typeof(ImagePreferenceType), query["type"]);
					form.SetImagePreference(imagePreference);
				}
			}
			else if (uri.Scheme == "http")
			{
                handled = true;
                form.OpenBrowser(link);
			}
			else if (uri.Scheme == "file")
			{
				if (!File.Exists(uri.LocalPath))
				{
					handled = true;
				}
			}

			return handled;
		}

		protected void ShowAbundanceMap(Organism organism, int mediaID, bool isMediaCustom)
		{
			IMedia media = organism.AbundanceMaps.GetByMediaID(mediaID, isMediaCustom);

			StringBuilder caption = new StringBuilder(organism.ToString());
			caption.Append(": ");
			if (media.Caption.Length > 0)
			{
				caption.Append(media.Caption);
			}
			else
			{
				caption.Append("abundance map");
			}

			form.ShowMap(caption.ToString(), media);
		}

		protected void ShowRangeMap(Organism organism, int mediaID, bool isMediaCustom)
		{
			IMedia media = organism.RangeMaps.GetByMediaID(mediaID, isMediaCustom);

			StringBuilder caption = new StringBuilder(organism.ToString());
			caption.Append(": ");
			if (media.Caption.Length > 0)
			{
				caption.Append(media.Caption);
			}
			else
			{
				caption.Append("range map");
			}

			form.ShowMap(caption.ToString(), media);
		}

		public void ShowBirdersHandbook()
		{
			// Check to see if the bird is contained in the Birder's Handbook
			if (bird.References.Contains(Reference.BirdersHandbook))
			{
				form.ShowBirdersHandbook(bird.ScientificName);
			}
			else
			{
				form.ShowBirdersHandbook(null);
			}
		}

		public void ShowPhotos()
		{
			if (bird != null && bird.Photos[0] != null)
			{
				int mediaID = bird.Photos[0].ID;
				bool isMediaCustom = bird.Photos[0].IsCustom;
				ShowPhotos(bird, mediaID, isMediaCustom);
			}
		}

		private void ShowPhotos(Organism organism, int mediaID, bool isMediaCustom)
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

				if (media.ID == mediaID && media.IsCustom == isMediaCustom)
				{
					index = i;
				}
			}
			form.ShowPhotos(organism.GetCommonName(Language.ID).Name, list.ToArray(), organism.Sounds.ToArray(), index);
		}

		public void SaveNotes(string notes)
		{
			bird.SaveNotes(notes);
			bird.Notes = notes;
		}

		private string GenerateAbundanceMapLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive)
		{
			return htmlImageGenerator.GenerateAbundanceMapLink(organismID, image, maxSize, zoomLinkActive);
		}

		private string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive)
		{
			return htmlImageGenerator.GeneratePhotoLink(organismID, image, maxSize, zoomLinkActive, false, null, null);
		}

		private string GeneratePhotoLink(int organismID, IMedia image, int maxSize, bool zoomLinkActive, bool guideLinkActive, IMedia sound, string commonName)
		{
			return htmlImageGenerator.GeneratePhotoLink(organismID, image, maxSize, zoomLinkActive, guideLinkActive, sound, commonName);
		}

		private string CreateTemporaryThumbnailImage(IMedia media, int maxSize)
		{
			string destination = Path.Combine(ApplicationSettings.TemporaryDirectory, Guid.NewGuid().ToString() + ".jpg");

			string mediaPath = media.AbsolutePath;
			if (!File.Exists(mediaPath))
			{
				throw new MediaNotFoundException();
			}

			htmlImageGenerator.ImageGenerator.GenerateImage(mediaPath, maxSize, maxSize, destination);
			temporaryFiles.Add(destination);

			return destination;
		}

		public string GenerateViewSimilarHTML(ImagePreferenceType imagePreference)
		{
			StringBuilder buffer = new StringBuilder("<html><head>");
			buffer.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">");
			buffer.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
			buffer.Append("<title>");
			buffer.Append("GBNA - Guide to Birds of North America eField Guide: ");
			buffer.Append(bird.GetCommonName(Language.ID).Name);
			buffer.Append("</title>");

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

			buffer.Append(".heading");
			buffer.Append("{");
			buffer.Append("font-size: 18pt;");
			buffer.Append("font-weight: bold;");
			buffer.Append("margin-bottom: 5px;");
			buffer.Append("}");

			buffer.Append(".photoContent");
			buffer.Append("{");
			buffer.Append("text-align: center;");
			buffer.Append("}");

			buffer.Append(".caption");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("text-align: center;");
			buffer.AppendFormat("max-width: {0}px;", SimilarRelatedSize);
			buffer.Append("}");

			buffer.Append(".smallLink");
			buffer.Append("{");
			buffer.Append("font-size: 9pt;");
			buffer.Append("}");

			buffer.Append(".imageType");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("}");

			buffer.Append(".radioContainer");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("margin: 0px 0px 0px 5px;");
			buffer.Append("}");

			buffer.Append(".radio");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("margin: 0px 10px 0px 0px;");
			buffer.Append("}");

			buffer.Append("</style>");
			buffer.Append("</head>");

			buffer.Append("<body>");

			// Javascript for image type preference
			buffer.Append("<script>");
			buffer.Append("function onImagePreferenceSelected(imageType){");
			buffer.Append("location.href=\"bird://thayer.com/imagepref?type=\" + imageType;");
			buffer.Append("");
			buffer.Append("");
			buffer.Append("");
			buffer.Append("}");
			buffer.Append("</script>");

			buffer.Append("<div class=\"mainContainer\">");

			buffer.Append("<div class=\"heading\">");
			buffer.Append("Similar Species");
			buffer.Append("</div>");

			// Image type preference
			buffer.Append("<div class=\"imageType\">");
			buffer.Append("<fieldset>");
			buffer.Append("<legend>Image Type</legend>");
			buffer.Append("<div class=\"radioContainer\">");
			buffer.AppendFormat("<span class=\"radio\"><input type=\"radio\" name=\"imagePreference\" value=\"{0}\" onclick=\"onImagePreferenceSelected('{0}');\"", ImagePreferenceType.Primary);
			if (imagePreference == ImagePreferenceType.Primary)
			{
				buffer.Append(" checked");
			}
			buffer.Append(">Primary</input></span>");
			buffer.AppendFormat("<span class=\"radio\"><input type=\"radio\" name=\"imagePreference\" value=\"{0}\" onclick=\"onImagePreferenceSelected('{0}');\"", ImagePreferenceType.Secondary);
			if (imagePreference == ImagePreferenceType.Secondary)
			{
				buffer.Append(" checked");
			}
			buffer.Append(">Secondary</input></span>");
			buffer.Append("</div>");
			buffer.Append("</fieldset>");
			buffer.Append("</div>");

			buffer.Append("<ul>");

			// Show current bird
			buffer.Append("<li>");
			buffer.Append("<div class=\"photoContent\">");

			// Image type preference
			int imageIndex = 0;
			if (imagePreference == ImagePreferenceType.Secondary && bird.Photos.Count > 1)
			{
				imageIndex = 1;
			}

			IMedia sound = bird.Sounds.Count > 0 ? bird.Sounds[0] : null;
			buffer.Append(GeneratePhotoLink(bird.ID, bird.Photos[imageIndex], SimilarRelatedSize, true, true, sound, bird.GetCommonName(Language.ID).Name));
			buffer.Append("</div>");
			buffer.Append("</li>");

			// Show similar species
			foreach (SimilarSpecies species in SimilarSpecies)
			{
				species.ImagePreference = imagePreference;
				buffer.Append("<li>");
				buffer.Append("<div class=\"photoContent\">");
				buffer.Append(GeneratePhotoLink(species.ThingID, species.Photo, SimilarRelatedSize, true, true, species.Sound, species.Organism.GetCommonName(Language.ID).Name));
				buffer.Append("</div>");
				buffer.Append("</li>");
			}
			buffer.Append("</ul>");

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

		public string GenerateViewRelatedHTML(ImagePreferenceType imagePreference)
		{
			StringBuilder buffer = new StringBuilder("<html><head>");
			buffer.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">");
			buffer.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
			buffer.Append("<title>");
			buffer.Append("GBNA - Guide to Birds of North America eField Guide: ");
			buffer.Append(bird.GetCommonName(Language.ID).Name);
			buffer.Append("</title>");


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

			buffer.Append(".familyName");
			buffer.Append("{");
			buffer.Append("font-size: 18pt;");
			buffer.Append("font-weight: bold;");
			buffer.Append("}");

			buffer.Append(".familyDescription");
			buffer.Append("{");
			buffer.Append("font-size: 14pt;");
			buffer.Append("}");

			buffer.Append(".comments");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("margin-top: 10px;");
			buffer.Append("margin-bottom: 10px;");
			buffer.Append("}");

			buffer.Append(".photoContent");
			buffer.Append("{");
			buffer.Append("text-align: center;");
			buffer.Append("}");

			buffer.Append(".caption");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("text-align: center;");
			buffer.AppendFormat("max-width: {0}px;", SimilarRelatedSize);
			buffer.Append("}");

			buffer.Append(".smallLink");
			buffer.Append("{");
			buffer.Append("font-size: 9pt;");
			buffer.Append("}");

			buffer.Append(".imageType");
			buffer.Append("{");
			buffer.Append("font-size: 10pt;");
			buffer.Append("}");

			buffer.Append(".radioContainer");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("margin: 0px 0px 0px 5px;");
			buffer.Append("}");

			buffer.Append(".radio");
			buffer.Append("{");
			buffer.Append("padding: 0px;");
			buffer.Append("margin: 0px 10px 0px 0px;");
			buffer.Append("}");

			buffer.Append("</style>");
			buffer.Append("</head>");

			// Javascript for image type preference
			buffer.Append("<script>");
			buffer.Append("function onImagePreferenceSelected(imageType){");
			buffer.Append("location.href=\"bird://thayer.com/imagepref?type=\" + imageType;");
			buffer.Append("");
			buffer.Append("");
			buffer.Append("");
			buffer.Append("}");
			buffer.Append("</script>");

			buffer.Append("<body>");
			buffer.Append("<div class=\"mainContainer\">");

			buffer.Append("<div class=\"familyName\">");
			buffer.Append(bird.Family.Name);
			buffer.Append("</div>");
			buffer.Append("<div class=\"familyDescription\">");
			buffer.Append(bird.Family.Description);
			buffer.Append("&nbsp;");
			buffer.Append("<span class=\"smallLink\">");
			buffer.Append("(<a href=\"bird://thayer.com/tax?t=FAMILYNAR&ThingID=");
			buffer.Append(bird.ID);
			buffer.Append("\">full description</a>)");
			buffer.Append("</span>");
			buffer.Append("</div>");
			buffer.Append("<div class=\"comments\">");
			buffer.Append("All members of the family are shown below...");
			buffer.Append("</div>");

			// Image type preference
			buffer.Append("<div class=\"imageType\">");
			buffer.Append("<fieldset>");
			buffer.Append("<legend>Image Type</legend>");
			buffer.Append("<div class=\"radioContainer\">");
			buffer.AppendFormat("<span class=\"radio\"><input type=\"radio\" name=\"imagePreference\" value=\"{0}\" onclick=\"onImagePreferenceSelected('{0}');\"", ImagePreferenceType.Primary);
			if (imagePreference == ImagePreferenceType.Primary)
			{
				buffer.Append(" checked");
			}
			buffer.Append(">Primary</input></span>");
			buffer.AppendFormat("<span class=\"radio\"><input type=\"radio\" name=\"imagePreference\" value=\"{0}\" onclick=\"onImagePreferenceSelected('{0}');\"", ImagePreferenceType.Secondary);
			if (imagePreference == ImagePreferenceType.Secondary)
			{
				buffer.Append(" checked");
			}
			buffer.Append(">Secondary</input></span>");
			buffer.Append("</div>");
			buffer.Append("</fieldset>");
			buffer.Append("</div>");

			buffer.Append("<ul>");

			// Image type preference
			int imageIndex = 0;
			if (imagePreference == ImagePreferenceType.Secondary && bird.Photos.Count > 1)
			{
				imageIndex = 1;
			}

			// Show related species
			foreach (Organism organism in RelatedSpecies)
			{
				IMedia sound = organism.Sounds.Count > 0 ? organism.Sounds[0] : null;
				buffer.Append("<li>");
				buffer.Append("<div class=\"photoContent\">");
				buffer.Append(GeneratePhotoLink(organism.ID, organism.Photos[imageIndex], SimilarRelatedSize, true, true, sound, organism.GetCommonName(Language.ID).Name));
				buffer.Append("</div>");
				buffer.Append("</li>");
			}

			buffer.Append("</ul>");

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
	}
}
