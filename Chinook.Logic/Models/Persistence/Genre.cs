
namespace Chinook.Logic.Models.Persistence
{
	[CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/Genre.csv")]
	internal class Genre : IdentityObject, Contracts.Persistence.IGenre
	{
		[CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 1)]
		public string Name { get; set; }
	}
}
