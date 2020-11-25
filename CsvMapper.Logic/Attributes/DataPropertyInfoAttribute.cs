using System;

namespace CsvMapper.Logic.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DataPropertyInfoAttribute : Attribute
	{
		public bool NotMapped { get; set; } = false;
		public bool IsRequired { get; set; } = false;
		public int OrderPosition { get; set; } = 10000;
	}
}
