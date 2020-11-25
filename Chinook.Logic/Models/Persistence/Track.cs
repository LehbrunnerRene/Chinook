using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Logic.Models.Persistence
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/Track.csv")]
    internal class Track : IdentityObject,Contracts.Persistence.ITrack
    {
        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 1)]
        public string Name { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 2)]
        public int AlbumId { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 3)]
        public int MediaTypeId { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 4)]
        public int GenreId { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 5)]
        public string Composer { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 6)]
        public int Milliseconds { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 7)]
        public int Bytes { get; set; }

        [CsvMapper.Logic.Attributes.DataPropertyInfo(OrderPosition = 8)]
        public string UnitPrice { get; set; }
    }
}
