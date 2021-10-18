using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public interface IMedia
	{
		int ID { get; }
		bool IsCustom { get; }
		string Type { get; }
		string TypeDescription { get; }
		string FileName { get; }
		string AbsolutePath { get; }
		string ThumbnailPath { get; }
		string Caption { get; }
		string Copyright { get; }
		string FullCopyright { get; }
		int Width { get; }
		int Height { get; }
		int Order { get; }
	}
}
