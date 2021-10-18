namespace Thayer.Birding.UI
{
	public interface IPhotoGalleryForm : IImageGenerator, IShowsPhotos, IShowsPhotoList, IPlaysSound, IShowsBird
	{
		ImagePreferenceType GetImagePreference();

		void ShowWorking(bool isWorking);
	}
}
