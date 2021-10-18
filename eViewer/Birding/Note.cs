using System.Collections.Generic;
using System.Data;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Note
	{
		private int thingID = 0;
		private string text = string.Empty;

		public Note()
		{
		}

		public int ThingID
		{
			get
			{
				return thingID;
			}

			set
			{
				thingID = value;
			}
		}

		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		public bool Exists()
		{
			return NotesDM.Instance.Exists(this);
		}

		public void Save()
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
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

		public void Save(IDbTransaction trans)
		{
			NotesDM.Instance.Delete(thingID, trans);

			NotesDM.Instance.Save(thingID, text, trans);
		}

		public static List<Note> GetList()
		{
			return NotesDM.Instance.GetList();
		}

		public static void DeleteAll(IDbTransaction trans)
		{
			NotesDM.Instance.DeleteAll(trans);
		}
	}
}
