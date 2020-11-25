using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models
{
	internal abstract class IdentityObject : Contracts.IIdentifiable
	{
		[DataPropertyInfo(OrderPosition = 0)]
		public int Id { get; set; }
	}
}
