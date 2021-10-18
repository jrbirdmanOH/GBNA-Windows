namespace Thayer.Birding.UI
{
	public interface IEGuideForm : IShowsPhotos, IImageGenerator, IPlaysSound, IShowsBird, IShowsWebBrowser
	{
		void AddSighting(Sighting sighting);
		void ManageSightings(Organism organism);
		void OpenSpectrogram(string path);
		void PlayVideo(string organismName, IMedia video);
		void Pronounce(string actualPhrase, string speakPhrase);
		void ShowMap(string caption, IMedia map);
		void ShowBirdersHandbook(string scientificName);
		void ShowNarrative(string caption, string narrative);
		void ShowNotes(string notes);
		void ManageMedia(Organism organism);
		void ShowSibleysBirdsOfTheWorld(string scientificName);

		bool SpectrogramSupported { get; }
	}
}
