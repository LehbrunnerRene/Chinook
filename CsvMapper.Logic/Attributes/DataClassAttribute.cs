using System;

namespace CsvMapper.Logic.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class DataClassAttribute : Attribute
	{
		public bool HasHeader { get; set; }
		public string Separator { get; set; } = ";";
		public string FileName { get; set; }
	}
}
