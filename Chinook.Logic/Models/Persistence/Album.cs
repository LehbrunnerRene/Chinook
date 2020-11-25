
using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
	[DataClass(HasHeader = true, FileName = "CsvData/Album.csv")]
	internal class Album : IdentityObject, Contracts.Persistence.IAlbum
	{
		[DataPropertyInfo(OrderPosition = 2)]
		public int ArtistId { get; set; }
		[DataPropertyInfo(OrderPosition = 1)]
		public string Title { get; set; }
	}
}
