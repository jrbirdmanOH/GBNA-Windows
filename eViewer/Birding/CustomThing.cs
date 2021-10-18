using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;
using System.Data;

namespace Thayer.Birding
{
	public class CustomThing : IQuizThing
	{
		private int id = 0;
		private string name = string.Empty;
		private string alternateName = string.Empty;
		private MediaCollection media = null;

		public CustomThing()
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

		public string AlternateName
		{
			get
			{
				if (alternateName.Length == 0)
				{
					return name;
				}

				return alternateName;
			}

			set
			{
				alternateName = value;
			}
		}

		public string AlternateNameOriginal
		{
			get
			{
				return alternateName;
			}

			set
			{
				alternateName = value;
			}
		}

		public MediaCollection Media
		{
			get
			{
				if (media == null)
				{
					media = CustomMedia.GetListByCustomThingID(id);
				}

				return media;
			}
			set
			{
				media = value;
			}
		}

		public IMediaList Photos
		{
			get
			{
				return Media.Photos;
			}
		}

		public IMediaList Sounds
		{
			get
			{
				return Media.Sounds;
			}
		}

		public IMediaList Videos
		{
			get
			{
				return Media.Videos;
			}
		}

		public IMediaList AbundanceMaps
		{
			get
			{
				return Media.AbundanceMaps;
			}
		}

		public IMediaList RangeMaps
		{
			get
			{
				return Media.RangeMaps;
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

		public void Save(IDbTransaction trans)
		{
			if (trans != null)
			{
				CustomThingDM.Instance.Save(this, trans);

				List<int> previousMediaList = CustomMedia.GetIDListByCustomThingID(id, trans);
				List<int> newMediaList = new List<int>();

				int order = 1;
				foreach (CustomMedia media in this.Media.All)
				{
					// Save the media
					media.Save(trans);

					// Add relationship between custom thing and the media
					CustomThingMediaDM.Instance.Save(id, media.ID, order, trans);

					newMediaList.Add(media.ID);

					order++;
				}

				// Cleanup any previous media relationships and media that are no longer needed
				foreach (int mediaID in previousMediaList)
				{
					if (!newMediaList.Contains(mediaID))
					{
						CustomThingMediaDM.Instance.Delete(id, mediaID, trans);
						CustomMedia.DeleteByID(mediaID, trans);
					}
				}
			}
			else
			{
				Save();
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
				// Delete any relationships and corresponding entities
				CustomQuizCategoryThingDM.Instance.DeleteByCustomThingID(id, trans);
				CustomQuizThingDM.Instance.DeleteByCustomThingID(id, trans);
				CustomMedia.DeleteByCustomThingID(id, trans);

				CustomThingDM.Instance.Delete(id, trans);
			}
			else
			{
				Delete();
			}
		}

		public static CustomThing GetByID(int id)
		{
			return CustomThingDM.Instance.GetByID(id);
		}

		public static List<CustomThing> GetByQuizID(int quizID)
		{
			return CustomThingDM.Instance.GetByQuizID(quizID);
		}

		public static List<int> GetIDListByCategoryID(int categoryID)
		{
			return CustomThingDM.Instance.GetIDListByCategoryID(categoryID);
		}
	}
}
