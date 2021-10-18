namespace Thayer.Birding.UI
{
	public interface IIdentificationForm : IPlaysSound
	{
		int[] SelectedResults { get; }

		bool CommonOnly { get; }
		ITaxonomy[] GetClassificationsSelected();
		Location[] GetLocationsSelected();
		bool IsPredominantColorSelected { get; }
		bool IsColorSelected(Color color);
		bool IsFieldMarkSelected(FieldMark fieldMark);
		bool IsHabitatSelected(Habitat habitat);
		bool IsSizeSelected(Size size);
		bool IsSoundSelected(Sound sound);

		void OpenQuizWizard(CustomList customList);
	}
}
