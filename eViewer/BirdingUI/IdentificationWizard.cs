using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI
{
	public class IdentificationWizard
	{
		private Collection collection;
		private IIdentificationForm form;
		private Sound previousSound = null;
		private int soundIndex = 0;

		public IdentificationWizard(IIdentificationForm form)
		{
			this.form = form;
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

		public List<OrganismListItem> Search()
		{
			if (form == null)
			{
				return new List<OrganismListItem>();
			}

			bool commonOnly = form.CommonOnly;
			Location[] locations = GetLocationsSelected();
			Size[] sizes = GetSizesSelected();
			Habitat[] habitats = GetHabitatsSelected();
			Color[] colors = GetColorsSelected();
			FieldMark[] fieldMarks = GetFieldMarksSelected();
			Sound[] sounds = GetSoundsSelected();
			ITaxonomy[] taxonomies = GetClassificationsSelected();

			Kingdom[] kingdoms;
			Phylum[] phyla;
			Class[] classes;
			Order[] orders;
			Family[] families;
			Genus[] genera;
			Taxonomy.GetClassifications(taxonomies, out kingdoms, out phyla, out classes, out orders, out families, out genera);

			return OrganismListItem.Search(Collection.ID, Collection.TaxonomyID, locations, commonOnly, sizes, habitats, IsPredominantColorSelected, colors, fieldMarks, sounds, kingdoms, phyla, classes, orders, families, genera);
		}

		private ITaxonomy[] GetClassificationsSelected()
		{
			return form.GetClassificationsSelected();
		}

		private Location[] GetLocationsSelected()
		{
			return form.GetLocationsSelected();
		}

		private bool IsPredominantColorSelected
		{
			get
			{
				return form.IsPredominantColorSelected;
			}
		}

		private Color[] GetColorsSelected()
		{
			List<Color> colors = new List<Color>();

			foreach (Color color in Color.Colors)
			{
				if (form.IsColorSelected(color))
				{
					colors.Add(color);
				}
			}

			return colors.ToArray();
		}

		private FieldMark[] GetFieldMarksSelected()
		{
			List<FieldMark> fieldMarks = new List<FieldMark>();

			foreach (FieldMark fieldMark in FieldMark.FieldMarks)
			{
				if(form.IsFieldMarkSelected(fieldMark))
				{
					fieldMarks.Add(fieldMark);
				}
			}

			return fieldMarks.ToArray();
		}

		private Habitat[] GetHabitatsSelected()
		{
			List<Habitat> habitats = new List<Habitat>();

			foreach (Habitat habitat in Habitat.Habitats)
			{
				if (form.IsHabitatSelected(habitat))
				{
					habitats.Add(habitat);
				}
			}

			return habitats.ToArray();
		}

		private Size[] GetSizesSelected()
		{
			List<Size> sizes = new List<Size>();

			foreach (Size size in Size.Sizes)
			{
				if (form.IsSizeSelected(size))
				{
					sizes.Add(size);
				}
			}

			return sizes.ToArray();
		}

		private Sound[] GetSoundsSelected()
		{
			List<Sound> sounds = new List<Sound>();

			foreach (Sound sound in Sound.Sounds)
			{
				if (form.IsSoundSelected(sound))
				{
					sounds.Add(sound);
				}
			}

			return sounds.ToArray();
		}

		public void RunQuiz()
		{
			CustomList customList = CustomList.GetTemporaryList();
			customList.DeleteContents();

			SaveResultsInCustomList(customList);

			form.OpenQuizWizard(customList);
		}

		public void SaveResultsInCustomList(CustomList customList)
		{
			int order = 0;
			foreach (int thingID in form.SelectedResults)
			{
				CustomListItem item = new CustomListItem();
				item.CustomListID = customList.ID;
				item.Order = ++order;
				item.Organism.ID = thingID;
				customList.Contents.Add(item);
			}

			customList.SaveContents();
		}

		public string GetEnglishQuery()
		{
			bool commonOnly = form.CommonOnly;
			Location[] locations = GetLocationsSelected();
			Size[] sizes = GetSizesSelected();
			Habitat[] habitats = GetHabitatsSelected();
			Color[] colors = GetColorsSelected();
			FieldMark[] fieldMarks = GetFieldMarksSelected();
			Sound[] sounds = GetSoundsSelected();
			ITaxonomy[] taxonomies = GetClassificationsSelected();

			Kingdom[] kingdoms;
			Phylum[] phyla;
			Class[] classes;
			Order[] orders;
			Family[] families;
			Genus[] genera;
			Taxonomy.GetClassifications(taxonomies, out kingdoms, out phyla, out classes, out orders, out families, out genera);

			string queryString;
			StringBuilder query = new StringBuilder();

			queryString = GetEnglishQuery(kingdoms);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(phyla);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(classes);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(orders);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(families);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(genera);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(locations, commonOnly);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(sizes);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(habitats);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(colors, IsPredominantColorSelected);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(fieldMarks);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			queryString = GetEnglishQuery(sounds);
			if (queryString.Length > 0)
			{
				if (query.Length > 0)
				{
					query.Append(" AND </li>");
				}
				query.Append("<li>");
				query.Append(queryString);
			}

			query.Insert(0, "<html><body bottommargin=\"0\" leftmargin=\"0\" rightmargin=\"0\" topmargin=\"0\"><font face=\"Arial\" size=\"1\">The wizard has selected all things in the eField Guide that...<ul>");
			query.Append("</li></ul></font></body></html>");

			return query.ToString();
		}

		private string GetEnglishQuery(Kingdom[] kingdoms)
		{
			int count = kingdoms.Length;

			if (count == 0)
			{
				return string.Empty;
			}

			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				Kingdom kingdom = kingdoms[i];
				if (i == 0)
				{
					buffer.Append("are in the ");
				}
				else if (i == count - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(kingdom.Description);
				buffer.Append("\"");
			}

			if (count == 1)
			{
				buffer.Append(" kingdom");
			}
			else
			{
				buffer.Append(" kingdoms");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Phylum[] phyla)
		{
			int count = phyla.Length;

			if (count == 0)
			{
				return string.Empty;
			}

			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				Phylum phylum = phyla[i];
				if (i == 0)
				{
					buffer.Append("are in the ");
				}
				else if (i == count - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(phylum.Description);
				buffer.Append("\"");
			}

			if (count == 1)
			{
				buffer.Append(" phylum");
			}
			else
			{
				buffer.Append(" phyla");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Class[] classes)
		{
			int count = classes.Length;

			if (count == 0)
			{
				return string.Empty;
			}

			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				Class taxClass = classes[i];
				if (i == 0)
				{
					buffer.Append("are in the ");
				}
				else if (i == count - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(taxClass.Description);
				buffer.Append("\"");
			}

			if (count == 1)
			{
				buffer.Append(" class");
			}
			else
			{
				buffer.Append(" classes");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Order[] orders)
		{
			int count = orders.Length;

			if (count == 0)
			{
				return string.Empty;
			}

			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				Order order = orders[i];
				if (i == 0)
				{
					buffer.Append("are in the ");
				}
				else if (i == count - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(order.Description);
				buffer.Append("\"");
			}

			if (count == 1)
			{
				buffer.Append(" order");
			}
			else
			{
				buffer.Append(" orders");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Family[] families)
		{
			int count = families.Length;

			if (count == 0)
			{
				return string.Empty;
			}

			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				Family family = families[i];
				if (i == 0)
				{
					buffer.Append("are in the ");
				}
				else if (i == count - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(family.Description);
				buffer.Append("\"");
			}

			if (count == 1)
			{
				buffer.Append(" family");
			}
			else
			{
				buffer.Append(" families");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Genus[] genera)
		{
			int count = genera.Length;

			if (count == 0)
			{
				return string.Empty;
			}

			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				Genus genus = genera[i];
				if (i == 0)
				{
					buffer.Append("are in the ");
				}
				else if (i == count - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(genus.Name);
				buffer.Append("\"");
			}

			if (count == 1)
			{
				buffer.Append(" genus");
			}
			else
			{
				buffer.Append(" genera");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Location[] locations, bool commonOnly)
		{
			int locationCount = locations.Length;
			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < locationCount; i++)
			{
				Location location = locations[i];
				if (i == 0)
				{
					if (commonOnly)
					{
						buffer.Append("are commonly found in ");
					}
					else
					{
						buffer.Append("have been sighted in ");
					}
				}
				else if (i == locationCount - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(location.Name);
				buffer.Append("\"");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Size[] sizes)
		{
			int sizeCount = sizes.Length;
			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < sizeCount; i++)
			{
				Size size = sizes[i];
				if (i == 0)
				{
					buffer.Append("are the size of ");
				}
				else if (i == sizeCount - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append("\"");
				buffer.Append(size.RelativeSize);
				buffer.Append("\"");
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Habitat[] habitats)
		{
			int habitatCount = habitats.Length;
			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < habitatCount; i++)
			{
				Habitat habitat = habitats[i];
				if (i == 0)
				{
					buffer.Append("live in ");
				}
				else if (i == habitatCount - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append(habitat.Name);
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Color[] colors, bool predominantColor)
		{
			int colorCount = colors.Length;
			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < colorCount; i++)
			{
				Color color = colors[i];
				if (i == 0)
				{
					if (predominantColor)
					{
						buffer.Append("are predominantly ");
					}
					else
					{
						if (colorCount == 1)
						{
							buffer.Append("include the color ");
						}
						else
						{
							buffer.Append("include the colors ");
						}
					}
				}
				else if (i == colorCount - 1)
				{
					buffer.Append(" and ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append(color.Name);
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(FieldMark[] fieldMarks)
		{
			int fieldMarkCount = fieldMarks.Length;
			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < fieldMarkCount; i++)
			{
				FieldMark fieldMark = fieldMarks[i];
				if (i == 0)
				{
					buffer.Append("have ");
				}
				else if (i == fieldMarkCount - 1)
				{
					buffer.Append(" and ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append(fieldMark.Name);
			}

			return buffer.ToString();
		}

		private string GetEnglishQuery(Sound[] sounds)
		{
			int soundCount = sounds.Length;
			StringBuilder buffer = new StringBuilder();
			for (int i = 0; i < soundCount; i++)
			{
				Sound sound = sounds[i];
				if (i == 0)
				{
					buffer.Append("have ");
				}
				else if (i == soundCount - 1)
				{
					buffer.Append(" or ");
				}
				else
				{
					buffer.Append(", ");
				}
				buffer.Append(sound.Name);
			}

			if(soundCount == 1)
			{
				buffer.Append(" song");
			}
			else if (soundCount > 0)
			{
				buffer.Append(" songs");
			}

			return buffer.ToString();
		}

		public void PlaySound(Sound sound)
		{
			if (sound == previousSound)
			{
				soundIndex = ++soundIndex % sound.MediaIDs.Length;
			}
			else
			{
				previousSound = sound;
				soundIndex = 0;
			}

			IMedia media = Media.GetByID(sound.MediaIDs[soundIndex]);

			form.PlaySound(media.AbsolutePath, false);
		}
	}
}
