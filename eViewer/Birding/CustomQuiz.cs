using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;
using System.Data;

namespace Thayer.Birding
{
	public class CustomQuiz
	{
		private int id = 0;
		private string name = string.Empty;
		private string description = string.Empty;
		private string author = string.Empty;
		private int categoryID = 0;
		private List<CustomThing> entries = null;

		public CustomQuiz()
		{
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

		public string Author
		{
			get
			{
				return author;
			}

			set
			{
				author = value;
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

		public List<CustomThing> Entries
		{
			get
			{
				if (entries == null)
				{
					entries = CustomThing.GetByQuizID(id);
				}

				return entries;
			}

			set
			{
				entries = value;
			}
		}

		public bool HasSounds
		{
			get
			{
				bool hasSounds = false;

				foreach (CustomThing customThing in this.Entries)
				{
					if (customThing.Sounds.Count > 0)
					{
						hasSounds = true;
						break;
					}
				}

				return hasSounds;
			}
		}

/*
		public void Save()
		{
			Save(null);
		}
*/
		public void Save(IDbTransaction trans)
		{
			if (trans != null)
			{
				CustomQuizDM.Instance.Save(this, trans);
				CustomQuizThingDM.Instance.DeleteByQuizID(id, trans);
				foreach (CustomThing entry in this.Entries)
				{
					CustomQuizThingDM.Instance.Save(id, entry.ID, trans);
				}
			}
			else
			{
				Save();
			}
		}

		public void Save()
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				Save(trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void Delete()
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				Delete(trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

		}

		public void Delete(IDbTransaction trans)
		{
			if (trans != null)
			{
				CustomQuizThingDM.Instance.DeleteByQuizID(id, trans);
				CustomQuizDM.Instance.Delete(id, trans);
			}
			else
			{
				Delete();
			}
		}

		public static void DeleteByCategoryID(int categoryID)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				CustomQuiz.DeleteByCategoryID(categoryID, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public static void DeleteByCategoryID(int categoryID, IDbTransaction trans)
		{
			if (trans != null)
			{
				List<CustomQuiz> quizzes = CustomQuizDM.Instance.GetList(categoryID);
				foreach (CustomQuiz quiz in quizzes)
				{
					quiz.Delete(trans);
				}
			}
			else
			{
				CustomQuiz.DeleteByCategoryID(categoryID);
			}
		}

		public static CustomQuiz GetByID(int id)
		{
			return CustomQuizDM.Instance.GetByID(id);
		}

		public static List<CustomQuiz> GetList(int categoryID)
		{
			return CustomQuizDM.Instance.GetList(categoryID);
		}
/*
		public static Dictionary<string, List<CustomQuiz>> GetCategorizedList(int collectionID)
		{
			return QuizDM.Instance.GetCategorizedList(collectionID);
		}
*/
	}
}
