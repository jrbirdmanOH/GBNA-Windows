namespace Thayer.Birding
{
	public class MediaType
	{
		public const string AbundanceMap = "AM";
		public const string Photo = "PH";
		public const string RangeMap = "RM";
		public const string Sound = "SO";
		public const string Video = "VI";

		public static string GetDescription(string type)
		{
			string description = string.Empty;

			switch (type)
			{
				case AbundanceMap:
					description = "Abundance Map";
					break;
				case Photo:
					description = "Photo";
					break;
				case RangeMap:
					description = "Range Map";
					break;
				case Sound:
					description = "Sound";
					break;
				case Video:
					description = "Video";
					break;
				default:
					description = "Unknown";
					break;
			}

			return description;
		}
	}
}
