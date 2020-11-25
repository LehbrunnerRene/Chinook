using Chinook.Contracts.Report.Marketing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Report.Marketing.Models
{
    internal class AlbumStatistic : IAlbumStatistic
    {
        public int MaxTime { get; set; }
        public int MinTime { get; set; }
        public double AverageTime { get; set; }
    }
}
