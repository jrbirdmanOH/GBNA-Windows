using System.Collections.Generic;
namespace Thayer.Birding.UI
{
	public interface IShowsPhotoList
	{
		void ShowPhotoList(List<PhotoListItem> photoListItems, int selectedListIndex);
	}
}
