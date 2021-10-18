using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Thayer.Birding
{
	public class QuizSource
	{
		public enum QuizSourceTypes
		{
			PredefinedQuiz,
			Location,
			TaxonomicGroup,
			CustomList,
			CustomQuiz
		}

		private QuizSourceTypes type;
		private PredefinedQuizSource predefinedQuiz = null;
		private LocationQuizSource location = null;
		private TaxonomicGroupQuizSource taxonomicGroup = null;
		private CustomListQuizSource customList = null;
		private CustomQuizSource customQuiz = null;

		public QuizSource()
		{
		}

		public QuizSourceTypes Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
			}
		}

		public PredefinedQuizSource PredefinedQuiz
		{
			get
			{
				if (type == QuizSourceTypes.PredefinedQuiz)
				{
					if (predefinedQuiz == null)
					{
						predefinedQuiz = new PredefinedQuizSource();
					}
				}
				else
				{
					predefinedQuiz = null;
				}

				return predefinedQuiz;
			}

			set
			{
				predefinedQuiz = value;
			}
		}

		public LocationQuizSource Location
		{
			get
			{
				if (type == QuizSourceTypes.Location)
				{
					if (location == null)
					{
						location = new LocationQuizSource();
					}
				}
				else
				{
					location = null;
				}

				return location;
			}

			set
			{
				location = value;
			}
		}

		public TaxonomicGroupQuizSource TaxonomicGroup
		{
			get
			{
				if (type == QuizSourceTypes.TaxonomicGroup)
				{
					if (taxonomicGroup == null)
					{
						taxonomicGroup = new TaxonomicGroupQuizSource();
					}
				}
				else
				{
					taxonomicGroup = null;
				}

				return taxonomicGroup;
			}

			set
			{
				taxonomicGroup = value;
			}
		}

		public CustomListQuizSource CustomList
		{
			get
			{
				if (type == QuizSourceTypes.CustomList)
				{
					if (customList == null)
					{
						customList = new CustomListQuizSource();
					}
				}
				else
				{
					customList = null;
				}

				return customList;
			}

			set
			{
				customList = value;
			}
		}

		public CustomQuizSource CustomQuiz
		{
			get
			{
				if (type == QuizSourceTypes.CustomQuiz)
				{
					if (customQuiz == null)
					{
						customQuiz = new CustomQuizSource();
					}
				}
				else
				{
					customQuiz = null;
				}

				return customQuiz;
			}

			set
			{
				customQuiz = value;
			}
		}

		public string Name
		{
			get
			{
				string name = string.Empty;

				switch (type)
				{
					case QuizSourceTypes.PredefinedQuiz:
						name = predefinedQuiz.Name;
						break;
					case QuizSourceTypes.Location:
						name = location.Name;
						break;
					case QuizSourceTypes.TaxonomicGroup:
						name = taxonomicGroup.Name;
						break;
					case QuizSourceTypes.CustomList:
						name = customList.Name;
						break;
					case QuizSourceTypes.CustomQuiz:
						name = customQuiz.Name;
						break;
				}

				return name;
			}
		}

		public class PredefinedQuizSource
		{
			private int quizID = 0;
			private string name = null;
			private string category = null;

			public PredefinedQuizSource()
			{
			}

			public int QuizID
			{
				get
				{
					return quizID;
				}

				set
				{
					quizID = value;
					SetValues(quizID);
				}
			}

			public string Name
			{
				get
				{
					return name != null ? name : string.Empty;
				}
			}

			public string Category
			{
				get
				{
					return category != null ? category : string.Empty;
				}
			}

			private void SetValues(int quizID)
			{
				Quiz quiz = Quiz.GetByID(quizID);
				if (quiz != null)
				{
					name = "Predefined Quiz: " + quiz.Name;
					category = quiz.Category;
				}
			}
		}

		public class LocationQuizSource
		{
			private bool commonOnly = true;
			private Location[] locations = null;

			public LocationQuizSource()
			{
			}

			public bool CommonOnly
			{
				get
				{
					return commonOnly;
				}

				set
				{
					commonOnly = value;
				}
			}

			public Location[] Locations
			{
				get
				{
					return locations;
				}

				set
				{
					locations = value;
				}
			}

			public string Name
			{
				get
				{
					StringBuilder name = new StringBuilder("Locations: ");
					int index = 0;
					foreach (Location location in locations)
					{
						if(index > 0)
						{
							name.Append(", ");
						}

						name.Append(location.Name);
						index++;
					}

					return name.ToString();
				}
			}
		}

		public class TaxonomicGroupQuizSource
		{
			private int taxonomyID = 0;
			private List<SelectedClassification> selectedClassifications = null;

			public TaxonomicGroupQuizSource()
			{
			}

			public int TaxonomyID
			{
				get
				{
					return taxonomyID;
				}

				set
				{
					taxonomyID = value;
				}
			}

			public SelectedClassification[] SelectedClassifications
			{
				get
				{
					return selectedClassifications == null ? null : selectedClassifications.ToArray();
				}

				set
				{
					selectedClassifications = new List<SelectedClassification>(value);
				}
			}

			[XmlIgnore]
			public ITaxonomy[] Classifications
			{
				get
				{
					List<ITaxonomy> classificationList = new List<ITaxonomy>();
					if (selectedClassifications != null)
					{
						foreach (SelectedClassification classification in selectedClassifications)
						{
							classificationList.Add(classification.ITaxonomy);
						}
					}

					return classificationList.ToArray();
				}

				set
				{
					if (value != null)
					{
						selectedClassifications = new List<SelectedClassification>(value.Length);

						foreach (ITaxonomy classification in value)
						{
							selectedClassifications.Add(new SelectedClassification(classification));
						}
					}
					else
					{
						selectedClassifications = null;
					}
				}
			}

			public string Name
			{
				get
				{
					StringBuilder name = new StringBuilder();

					Kingdom[] kingdoms;
					Phylum[] phyla;
					Class[] classes;
					Order[] orders;
					Family[] families;
					Genus[] genera;
					Taxonomy.GetClassifications(Classifications, out kingdoms, out phyla, out classes, out orders, out families, out genera);

					int index = 0;
					foreach (Kingdom kingdom in kingdoms)
					{
						if (index == 0)
						{
							if (name.Length > 0)
							{
								name.Append("; ");
							}
							name.Append("Kingdom: ");
						}
						else
						{
							name.Append(", ");
						}

						name.Append(kingdom.Description);
						index++;
					}

					index = 0;
					foreach (Phylum phylum in phyla)
					{
						if (index == 0)
						{
							if (name.Length > 0)
							{
								name.Append("; ");
							}
							name.Append("Phyla: ");
						}
						else
						{
							name.Append(", ");
						}

						name.Append(phylum.Description);
						index++;
					}

					index = 0;
					foreach (Class taxonomyClass in classes)
					{
						if (index == 0)
						{
							if (name.Length > 0)
							{
								name.Append("; ");
							}
							name.Append("Class: ");
						}
						else
						{
							name.Append(", ");
						}

						name.Append(taxonomyClass.Description);
						index++;
					}

					index = 0;
					foreach (Order order in orders)
					{
						if (index == 0)
						{
							if (name.Length > 0)
							{
								name.Append("; ");
							}
							name.Append("Order: ");
						}
						else
						{
							name.Append(", ");
						}

						name.Append(order.Description);
						index++;
					}

					index = 0;
					foreach (Family family in families)
					{
						if (index == 0)
						{
							if (name.Length > 0)
							{
								name.Append("; ");
							}
							name.Append("Family: ");
						}
						else
						{
							name.Append(", ");
						}

						name.Append(family.Description);
						index++;
					}

					index = 0;
					foreach (Genus genus in genera)
					{
						if (index == 0)
						{
							if (name.Length > 0)
							{
								name.Append("; ");
							}
							name.Append("Genus: ");
						}
						else
						{
							name.Append(", ");
						}

						name.Append(genus.Description.Length > 0 ? genus.Description : genus.Name);
						index++;
					}

					return name.ToString();
				}
			}

			public class SelectedClassification
			{
				public enum ClassificationTypes
				{
					None,
					Kingdom,
					Phylum,
					Class,
					Order,
					Family,
					Genus
				}

				private ClassificationTypes type = ClassificationTypes.None;
				private int id = 0;
				private string name = string.Empty;
				private string description = string.Empty;

				public ClassificationTypes Type
				{
					get
					{
						return type;
					}

					set
					{
						type = value;
					}
				}

				public int ID
				{
					get
					{
						return id;
					}

					set
					{
						id = value;
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

				public string Description
				{
					get
					{
						return description;
					}

					set
					{
						description = value;
					}
				}

				[XmlIgnore]
				public ITaxonomy ITaxonomy
				{
					get
					{
						return GetClassification();
					}

					set
					{
						SetClassification(value);
					}
				}

				public SelectedClassification()
				{
				}

				public SelectedClassification(ITaxonomy classification)
				{
					SetClassification(classification);
				}

				private void SetClassification(ITaxonomy classification)
				{
					if (classification is Kingdom)
					{
						type = ClassificationTypes.Kingdom;
						Kingdom kingdom = classification as Kingdom;
						id = kingdom.ID;
						name = kingdom.Name;
						description = kingdom.Description;
					}
					else if (classification is Phylum)
					{
						type = ClassificationTypes.Phylum;
						Phylum phylum = classification as Phylum;
						id = phylum.ID;
						name = phylum.Name;
						description = phylum.Description;
					}
					else if (classification is Class)
					{
						type = ClassificationTypes.Class;
						Class taxonomyClass = classification as Class;
						id = taxonomyClass.ID;
						name = taxonomyClass.Name;
						description = taxonomyClass.Description;
					}
					else if (classification is Order)
					{
						type = ClassificationTypes.Order;
						Order order = classification as Order;
						id = order.ID;
						name = order.Name;
						description = order.Description;
					}
					else if (classification is Family)
					{
						type = ClassificationTypes.Family;
						Family family = classification as Family;
						id = family.ID;
						name = family.Name;
						description = family.Description;
					}
					else if (classification is Genus)
					{
						type = ClassificationTypes.Genus;
						Genus genus = classification as Genus;
						id = genus.ID;
						name = genus.Name;
						description = genus.Description;
					}
				}

				private ITaxonomy GetClassification()
				{
					ITaxonomy classification = null;

					switch(type)
					{
						case ClassificationTypes.Kingdom:
							Kingdom kingdom = new Kingdom();
							kingdom.ID = this.id;
							kingdom.Name = this.name;
							kingdom.Description = this.description;
							classification = kingdom;
							break;
						case ClassificationTypes.Phylum:
							Phylum phylum = new Phylum();
							phylum.ID = this.id;
							phylum.Name = this.name;
							phylum.Description = this.description;
							classification = phylum;
							break;
						case ClassificationTypes.Class:
							Class taxonomyClass = new Class();
							taxonomyClass.ID = this.id;
							taxonomyClass.Name = this.name;
							taxonomyClass.Description = this.description;
							classification = taxonomyClass;
							break;
						case ClassificationTypes.Order:
							Order order = new Order();
							order.ID = this.id;
							order.Name = this.name;
							order.Description = this.description;
							classification = order;
							break;
						case ClassificationTypes.Family:
							Family family = new Family();
							family.ID = this.id;
							family.Name = this.name;
							family.Description = this.description;
							classification = family;
							break;
						case ClassificationTypes.Genus:
							Genus genus = new Genus();
							genus.ID = this.id;
							genus.Name = this.name;
							genus.Description = this.description;
							classification = genus;
							break;
					}

					return classification;
				}
			}
		}

		public class CustomListQuizSource
		{
			private int customListID = 0;

			public CustomListQuizSource()
			{
			}

			public int CustomListID
			{
				get
				{
					return customListID;
				}

				set
				{
					customListID = value;
				}
			}

			public string Name
			{
				get
				{
					StringBuilder name = new StringBuilder("Custom List: ");
					CustomList customList = Thayer.Birding.CustomList.GetByID(customListID);
					name.Append(customList == null ? string.Empty : customList.Name);
					return name.ToString();
				}
			}
		}

		public class CustomQuizSource
		{
			private int quizID = 0;
			private int categoryID = 0;

			public CustomQuizSource()
			{
			}

			public int QuizID
			{
				get
				{
					return quizID;
				}

				set
				{
					quizID = value;
				}
			}

			public int CategoryID
			{
				get
				{
					return categoryID;
				}

				set
				{
					categoryID = value;
				}
			}

			public string Name
			{
				get
				{
					StringBuilder name = new StringBuilder("My Quiz: ");
					CustomQuiz quiz = Thayer.Birding.CustomQuiz.GetByID(quizID);
					name.Append(quiz == null ? string.Empty : quiz.Name);
					return name.ToString();
				}
			}
		}
	}
}
