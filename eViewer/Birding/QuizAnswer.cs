using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public class QuizAnswer
	{
		public enum QuizAnswerStatus
		{
			Unanswered,
			Unknown,
			Correct,
			Incorrect,
			ShowAnswer
		}

		private int thingID = 0;
		private string response = null;
		private QuizAnswerStatus status = QuizAnswerStatus.Unanswered;

		public QuizAnswer()
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

		public string Response
		{
			get
			{
				return response;
			}

			set
			{
				response = value;
			}
		}

		public QuizAnswerStatus Status
		{
			get
			{
				return status;
			}

			set
			{
				status = value;
			}
		}
	}
}
