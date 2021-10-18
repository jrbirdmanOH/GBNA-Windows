using System.Collections.Generic;

namespace Thayer.Birding
{
	public class Size
	{
		public static Size SmallerThanSparrow;
		public static Size Sparrow;
		public static Size Robin;
		public static Size Pigeon;
		public static Size Crow;
		public static Size Goose;
		public static Size LargerThanGoose;

		private static List<Size> sizes;

		private string relativeSize;
		private string approximateSize;
		private double smallestSize;
		private double largestSize;

		static Size()
		{
			sizes = new List<Size>();

			SmallerThanSparrow = Create("Smaller than a sparrow", "Less than 5 in. (12.7 cm.)", 0.0, 5.25);
			Sparrow = Create("Sparrow", "Between 5 to 7 in. (12.7 - 17.8 cm.)", 4.75, 7.5);
			Robin = Create("Robin", "Between 7 and 12 in. (17.8 - 30.5 cm)", 6.75, 13.5);
			Pigeon = Create("Pigeon", "Between 12 and 16 in. (30.5 - 33 cm.)", 11.5, 17.0);
			Crow = Create("Crow", "Between 16 and 24 in. (33 - 61 cm.)", 14.0, 27.0);
			Goose = Create("Goose", "Between 24 and 36 in. (61 - 91.4 cm.)", 22.0, 39.0);
			LargerThanGoose = Create("Larger than goose", "Greater than 36 in. (91.4 cm.)", 33.0, 999.0);
		}

		private static Size Create(string relativeSize, string approximateSize, double smallestSize, double largestSize)
		{
			Size size = new Size(relativeSize, approximateSize, smallestSize, largestSize);

			sizes.Add(size);

			return size;
		}

		private Size(string relativeSize, string approximateSize, double smallestSize, double largestSize)
		{
			this.relativeSize = relativeSize;
			this.approximateSize = approximateSize;
			this.smallestSize = smallestSize;
			this.largestSize = largestSize;
		}

		public string RelativeSize
		{
			get
			{
				return relativeSize;
			}
		}

		public string ApproximateSize
		{
			get
			{
				return approximateSize;
			}
		}

		public double SmallestSize
		{
			get
			{
				return smallestSize;
			}
		}

		public double LargestSize
		{
			get
			{
				return largestSize;
			}
		}

		public static Size[] Sizes
		{
			get
			{
				return sizes.ToArray();
			}
		}
	}
}
