using System.Collections;
using System.Collections.Generic;

namespace Thayer.Birding.Updates
{
	public class FileCollection : CollectionBase
	{
		private Manifest manifest = null;
		private long totalBytes = 0;

		public FileCollection(Manifest manifest)
		{
			this.manifest = manifest;
		}

		public File this[int index]
		{
			get
			{
				return List[index] as File;
			}
		}

		public long TotalBytes
		{
			get
			{
				return totalBytes;
			}
		}

		public void Add(File file)
		{
			file.manifest = manifest;
			List.Add(file);
			totalBytes += file.Size;
		}
	}
}
