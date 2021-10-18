using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding.UI
{
	public static class Extensions
	{
		public static void Shuffle<T>(this IList<T> list, Random rnd)
		{
			for (var i = 0; i < list.Count; i++)
			{
				list.Swap(i, rnd.Next(i, list.Count));
			}
		}

		public static void Swap<T>(this IList<T> list, int i, int j)
		{
			var temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}
	}
}

namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class ExtensionAttribute : Attribute
	{
	}
}

