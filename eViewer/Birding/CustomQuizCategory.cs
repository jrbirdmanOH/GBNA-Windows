using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;
using System.Data;

namespace Thayer.Birding
{
	public class CustomQuizCategory
	{
		private int id = 0;
		private string name = string.Empty;

		public CustomQuizCategory()
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

		public void Save()
		{
			Save(null);
		}

		public void Save(IDbTransaction trans)
		{
			CustomQuizCategoryDM.Instance.Save(this, trans);
		}

		public void SaveCategoryItem(CustomThing thing)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				thing.Save(trans);
				CustomQuizCategoryThingDM.Instance.Save(id, thing.ID, trans);

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

		public void CopyCategoryItems(List<CustomThing> things)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				foreach (CustomThing thing in things)
				{
					CustomQuizCategoryThingDM.Instance.Save(id, thing.ID, trans);
				}

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
				// Delete any quizzes for this category
				CustomQuiz.DeleteByCategoryID(id);

				// Delete category items for this category
				List<CustomThing> items = CustomThingDM.Instance.GetByCategoryID(id);
				DeleteCategoryItems(items);

				// Delete the category itself
				CustomQuizCategoryDM.Instance.Delete(id, trans);
			}
			else
			{
				Delete();
			}
		}

		public void DeleteCategoryItem(CustomThing item)
		{
			List<CustomThing> items = new List<CustomThing>(1);
			items.Add(item);
			DeleteCategoryItems(items);
		}

		public void DeleteCategoryItems(List<CustomThing> items)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				DeleteCategoryItems(items, trans);

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

		public void DeleteCategoryItems(List<CustomThing> items, IDbTransaction trans)
		{
			if (trans != null)
			{
				foreach (CustomThing thing in items)
				{
					// Delete the relationship
					CustomQuizCategoryThingDM.Instance.Delete(id, thing.ID, trans);

					if (!CustomQuizCategoryThingDM.Instance.IsCustomThingReferenced(thing.ID, trans))
					{
						// Delete custom thing if no more references to it exist
						thing.Delete(trans);
					}
				}
			}
			else
			{
				DeleteCategoryItems(items);
			}
		}

		public static void DeleteList(List<CustomQuizCategory> categories)
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;

			try
			{
				conn = ApplicationSettings.CreateConnection(DataSourceType.Custom);
				conn.Open();

				trans = conn.BeginTransaction();

				DeleteList(categories, trans);

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

		public static void DeleteList(List<CustomQuizCategory> categories, IDbTransaction trans)
		{
			if (trans != null)
			{
				foreach (CustomQuizCategory category in categories)
				{
					category.Delete(trans);
				}
			}
			else
			{
				DeleteList(categories);
			}
		}
/*
		public static void DeleteList(List<CustomQuizCategory> categories)
		{
			CustomQuizCategoryDM.Instance.DeleteList(categories);
		}
*/
		public static CustomQuizCategory GetByID(int id)
		{
			return CustomQuizCategoryDM.Instance.GetByID(id);
		}

		public static CustomQuizCategory GetByName(string name)
		{
			return CustomQuizCategoryDM.Instance.GetByName(name);
		}

		public static List<CustomQuizCategory> GetList()
		{
			return CustomQuizCategoryDM.Instance.GetList();
		}

		public List<CustomThing> GetItems()
		{
			return CustomQuizCategory.GetItems(id);
		}

		public static List<CustomThing> GetItems(int categoryID)
		{
			return CustomThingDM.Instance.GetByCategoryID(categoryID);
		}
	}
}
