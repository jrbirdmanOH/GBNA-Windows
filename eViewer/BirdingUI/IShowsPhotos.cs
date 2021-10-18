namespace Thayer.Birding.UI
{
	public interface IShowsPhotos
	{
		void ShowPhotos(string organismName, IMedia[] photos, IMedia[] sounds, int initialPhotoIndex);
	}
}
