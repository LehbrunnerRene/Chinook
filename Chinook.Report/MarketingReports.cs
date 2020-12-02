using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chinook.Report.Marketing.Models;
using Chinook.Contracts.Report.Marketing;
using System.Security.Cryptography.X509Certificates;

namespace Chinook.Report
{
	public class MarketingReports
	{
		public static IEnumerable<IArtistStatistic> GetArtistStatistics()
		{
			var albums = Logic.Factory.GetAllAlbums();
			var artists = Logic.Factory.GetAllArtists();
			var genres = Logic.Factory.GetAllGenres();

			// Abfrage 
			var result = from ar in artists
						 join al in albums on ar.Id equals al.ArtistId
						 group al by new { ar.Id } into g
						 select new ArtistStatistic
						 { 
							 AlbumCount = g.Count()
                         };

			return result;
		}

		public static ITrackStatistic GetTrackStatistics()
        {
			var tracks = Logic.Factory.GetAllTracks();

			TrackStatistic trackStatistic = new TrackStatistic();

			trackStatistic.MaxTime = tracks.Max(x=> x.Milliseconds/1000);

			trackStatistic.MinTime = tracks.Min(x => x.Milliseconds / 1000);

			trackStatistic.AverageTime = tracks.Average(x => x.Milliseconds / 1000);

			return trackStatistic;
		}

		public static IAlbumStatistic GetAlbumStatistics()
        {
			var albums = Logic.Factory.GetAllAlbums();
			var tracks = Logic.Factory.GetAllTracks();

			AlbumStatistic albumStatistic = new AlbumStatistic();

			var AlbumTime = from a in albums
								 join t in tracks on a.Id equals t.AlbumId
								 group t by new { a.Id } into g
								 select new
								 {
									 AlbumTime = g.Sum(x => x.Milliseconds)
								 };

			albumStatistic.MaxTime = AlbumTime.Max(x => x.AlbumTime);
			albumStatistic.MinTime = AlbumTime.Min(x => x.AlbumTime);
			albumStatistic.AverageTime = AlbumTime.Average(x => x.AlbumTime);

			return albumStatistic;

		}


		public static ICustomerSaleStatistic GetCustomerSaleStatistics()
		{
			var invoices = Logic.Factory.GetAllInvoices();
			var costumers = Logic.Factory.GetAllCustomers();

			var customerSaleStatistic = new CustomerSaleStatistic();

			var item = (from i in invoices
						join c in costumers on i.Id equals c.Id
						group i by c.LastName)
						  .Select(j => (j.Key, j.Sum(a => a.Total)))
						  .OrderBy(a => a.Item2);

			customerSaleStatistic.maxName = item.Last().Key;
			customerSaleStatistic.maxNumber = item.Last().Item2.ToString();
			customerSaleStatistic.minName = item.First().Key;
			customerSaleStatistic.minNumber = item.First().Item2.ToString();
			customerSaleStatistic.avgNumber = item.Average(k => k.Item2).ToString();

			return customerSaleStatistic;
		}
	}
}
