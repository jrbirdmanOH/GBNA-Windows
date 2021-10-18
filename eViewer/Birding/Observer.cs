using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Observer
	{
		private int id = 0;
		private string firstName = string.Empty;
		private string middleInitial = string.Empty;
		private string lastName = string.Empty;
		private string initials = string.Empty;

		public Observer()
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

		public string FirstName
		{
			get
			{
				return firstName;
			}

			set
			{
				firstName = value;
			}
		}

		public string MiddleInitial
		{
			get
			{
				return middleInitial;
			}

			set
			{
				middleInitial = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}

			set
			{
				lastName = value;
			}
		}

		public string Initials
		{
			get
			{
				if (initials.Length == 0)
				{
					StringBuilder generatedInitials = new StringBuilder();

					if (this.FirstName.Length > 0)
					{
						generatedInitials.Append(this.FirstName[0]);
					}

					if (this.MiddleInitial.Length > 0)
					{
						generatedInitials.Append(this.MiddleInitial[0]);
					}

					if (this.LastName.Length > 0)
					{
						generatedInitials.Append(this.LastName[0]);
					}

					initials = generatedInitials.ToString();
				}

				return initials;
			}

			set
			{
				initials = value;
			}
		}

		public string FullName
		{
			get
			{
				StringBuilder text = new StringBuilder(firstName);
				text.Append(" ");
				if (middleInitial != null && middleInitial.Length > 0)
				{
					text.Append(middleInitial);
					text.Append(". ");
				}
				text.Append(lastName);

				return text.ToString();
			}
		}

		public bool NameExists
		{
			get
			{
				return ObserverDM.Instance.NameExists(this);
			}
		}

		public void Delete()
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
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
				Sighting.DeleteByObserver(this.ID, trans);
				ObserverDM.Instance.Delete(id, trans);
			}
			else
			{
				Delete();
			}
		}

		public void Save()
		{
			Save(null);
		}

		public void Save(IDbTransaction trans)
		{
			ObserverDM.Instance.Save(this, trans);
		}

		public override string ToString()
		{
			return FullName;
		}

		public static Observer GetByID(int id)
		{
			return ObserverDM.Instance.GetByID(id);
		}

		public static Observer GetByName(string firstName, string middleInitial, string lastName)
		{
			return ObserverDM.Instance.GetByName(firstName, middleInitial, lastName);
		}

		public static List<Observer> GetList()
		{
			return ObserverDM.Instance.GetList();
		}

		public static void DeleteList(List<Observer> observers)
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				foreach (Observer observer in observers)
				{
					observer.Delete(trans);
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
	}
}
