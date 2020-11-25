using Chinook.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Report.Marketing.Models
{
    internal class TrackStatistic : Contracts.Report.Marketing.ITrackStatistic
    {
        public int MaxTime { get; set; }
        public int MinTime { get; set; }
        public double AverageTime { get; set; }
    }
}
