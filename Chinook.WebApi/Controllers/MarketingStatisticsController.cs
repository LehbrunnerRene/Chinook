using System;
using System.Collections.Generic;
using Chinook.Contracts.Persistence;
using Chinook.Contracts.Report.Marketing;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingStatisticsController : ControllerBase
    {
        [HttpGet("/api/[controller]/TrackStatistics")]
        public ITrackStatistic GetTrackStatistics()
        {
            return Report.MarketingReports.GetTrackStatistics();
        }

        [HttpGet("/api/[controller]/CustomerStatistics")]
        public ICustomerSaleStatistic GetCustomerStatistics()
        {
            return Report.MarketingReports.GetCustomerSaleStatistics();
        }

        [HttpGet("/api/[controller]/ArtistStatistics")]
        public IEnumerable<IArtistStatistic> GetArtistStatistics()
        {
            return Report.MarketingReports.GetArtistStatistics();
        }

        [HttpGet("/api/[controller]/AlbumStatistics")]
        public IAlbumStatistic GetAlbumStatistics()
        {
            return Report.MarketingReports.GetAlbumStatistics();
        }
    }
}