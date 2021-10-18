using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
    public class Quiz
    {
		public static readonly string QUIZ_CATEGORY_VIDEO = "Video Quizzes";

        private int id = 0;
        private string name = string.Empty;
        private string description = string.Empty;
		private string category = string.Empty;
		private List<int> thingIDList = null;

        public Quiz()
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

		public string Category
		{
			get
			{
				return category;
			}

			set
			{
				category = value;
			}
		}

		public List<int> Things
		{
			get
			{
				if (thingIDList == null)
				{
					thingIDList = QuizDM.Instance.GetThingsInQuiz(this.ID);
				}

				return thingIDList;
			}

			set
			{
				thingIDList = value;
			}
		}

		public static Quiz GetByID(int id)
		{
			return QuizDM.Instance.GetByID(id);
		}

        public static List<Quiz> GetList(int collectionID)
        {
            return QuizDM.Instance.GetList(collectionID);
        }

        public static Dictionary<string, List<Quiz>> GetCategorizedList(int collectionID)
        {
            return QuizDM.Instance.GetCategorizedList(collectionID);
        }
    }
}
