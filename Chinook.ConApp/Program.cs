using System;
using System.Linq;

namespace Chinook.ConApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Chinook-Marketing!");



			var trackStatistic = Report.MarketingReports.GetTrackStatistics();
            Console.WriteLine("\nTrack Statistic");
            Console.WriteLine($"Max Time: {trackStatistic.MaxTime}");
            Console.WriteLine($"Min Time: {trackStatistic.MinTime}");
            Console.WriteLine($"Average Time: {trackStatistic.AverageTime}");


			var albumStatistic = Report.MarketingReports.GetAlbumStatistics();
			Console.WriteLine("\nAlbum Statistic");
			Console.WriteLine($"Max Time: {albumStatistic.MaxTime}");
			Console.WriteLine($"Min Time: {albumStatistic.MinTime}");
			Console.WriteLine($"Average Time: {albumStatistic.AverageTime}");


		}
	}
}
