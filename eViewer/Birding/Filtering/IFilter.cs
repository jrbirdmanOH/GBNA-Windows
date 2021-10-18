namespace Thayer.Birding.Filtering
{
	public interface IFilter
	{
		int ID { get; }
		string Name { get; }
		string DisplayName { get; }
		string Query { get; }
	}
}
