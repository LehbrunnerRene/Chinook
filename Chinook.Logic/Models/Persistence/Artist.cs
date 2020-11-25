
using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
	[DataClass(HasHeader = true, FileName = "CsvData/Artist.csv")]
	internal class Artist : IdentityObject, Contracts.Persistence.IArtist
	{
		[DataPropertyInfo(OrderPosition = 1)]
		public string Name { get; set; }
	}
}
