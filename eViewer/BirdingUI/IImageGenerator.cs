namespace Thayer.Birding.UI
{
	public interface IImageGenerator
	{
		void GenerateImage(string source, int width, int height, string destination);
	}
}
