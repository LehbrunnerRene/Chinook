using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Report.Marketing
{
    public interface IAlbumStatistic
    {
        public int MaxTime { get; }
        public int MinTime { get; }
        public double AverageTime { get; }
    }
}
