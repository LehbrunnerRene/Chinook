
namespace Chinook.Contracts.Persistence
{
	public interface IAlbum : IIdentifiable
	{
		int ArtistId { get; set; }
		string Title { get; set; }
	}
}
