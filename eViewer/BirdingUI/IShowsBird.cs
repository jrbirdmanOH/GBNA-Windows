namespace Thayer.Birding.UI
{
	public interface IShowsBird
	{
		void ShowBird(int organismID);
		void ShowNewBird(Collection collection, int organismID);
		void SetImagePreference(ImagePreferenceType imagePreference);
	}
}
