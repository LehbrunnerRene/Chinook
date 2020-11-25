using CsvMapper.Logic.Attributes;

namespace CsvMapper.Logic.Models
{
	public abstract class ModelObject
	{
		[DataPropertyInfo(OrderPosition = 0)]
		public int Id { get; set; }
	}
}
