using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using CsvMapper.Logic.Attributes;
using System.Text.RegularExpressions;

namespace CsvMapper.Logic
{
	public class CsvHelper
	{
		private static string NullLabel => "<NULL>";
		public static void Write(IEnumerable<object> models)
		{
			if (models == null)
				throw new ArgumentNullException(nameof(models));

			var first = models.FirstOrDefault();
			var lines = new List<string>();

			if (first != null)
			{
				var metaData = GetModelData(first);

				if (metaData.IsDataClass)
				{
					foreach (var item in models)
					{
						var line = CreateCsvLine(item, metaData.Separator);

						lines.Add(line);
					}
					File.WriteAllLines(metaData.FileName, lines, Encoding.Default);
				}
			}
		}

		public static IEnumerable<T> Read<T>() where T : new()
		{
			var result = new List<T>();
			var metaData = GetModelData<T>();

			if (metaData.IsDataClass)
			{
				var lines = File.ReadAllLines(metaData.FileName, Encoding.Default)
								.Skip(metaData.HasHeader ? 1 : 0);

				foreach (var line in lines)
				{
					result.Add(ReadCsvLine<T>(line, metaData.Separator));
				}
			}
			return result;
		}

		private static T ReadCsvLine<T>(string line, string separator)
			where T : new()
		{
			if (line == null)
				throw new ArgumentNullException(nameof(line));

			var result = new T();
			var type = typeof(T);
            Regex regex = new Regex("\".*\"");
            Match match = regex.Match(line);
            if (match.Success)
            {
				string help = match.Value.Replace(";", ",");
				help = help.Substring(1,help.Length-2);
				line = line.Replace(match.Value, help);
            }
            var data = line.Split(new [] { separator }, StringSplitOptions.None);

			var impProps = type.GetProperties()
							   .Where(p =>
							   {
								   var a = p.GetCustomAttribute<DataPropertyInfoAttribute>();

								   return a != null && a.NotMapped == false && p.CanWrite;
							   })
								.OrderBy(e => e.GetCustomAttribute<DataPropertyInfoAttribute>().OrderPosition);

			for (int i = 0; i < data.Length; i++)
			{
				var value = data[i];
				var item = impProps.SingleOrDefault(e => 
				{
					var a = e.GetCustomAttribute<DataPropertyInfoAttribute>();

					return a.OrderPosition == i;
				});
				if (item != null)
				{
					if (value == NullLabel)
					{
						item.SetValue(result, null);
					}
					else
					{
						item.SetValue(result, Convert.ChangeType(value, item.PropertyType));
					}
				}
			}
			return result;
		}

		private static (bool IsDataClass, bool HasHeader, string FileName, string Separator) GetModelData<T>()
		{
			var type = typeof(T);
			var dca = type.GetCustomAttribute<DataClassAttribute>();

			if (dca != null)
				return (true, dca.HasHeader, dca.FileName, dca.Separator);

			return (false, false, null, null);
		}
		private static (bool IsDataClass, string FileName, string Separator) GetModelData(object model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			var type = model.GetType();
			var dca = type.GetCustomAttribute<DataClassAttribute>();

			if (dca != null)
				return (true, dca.FileName, dca.Separator);

			return (false, null, null);
		}
		private static string CreateCsvLine(object model, string separator)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			var result = new StringBuilder();
			var type = model.GetType();
			var expProps = type.GetProperties()
							   .Where(p =>
								{
									var a = p.GetCustomAttribute<DataPropertyInfoAttribute>();

									return a != null && a.NotMapped == false && p.CanRead;
								})
								.OrderBy(e => e.GetCustomAttribute<DataPropertyInfoAttribute>().OrderPosition);

			foreach (var item in expProps)
			{
				var value = item.GetValue(model);

				if (result.Length > 0)
					result.Append(separator);

				if (value != null)
					result.Append(value.ToString());
				else
					result.Append(NullLabel);
			}
			return result.ToString();
		}
	}
}
