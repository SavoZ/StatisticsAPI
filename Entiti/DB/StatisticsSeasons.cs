using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class StatisticsSeasons
    {
        public long RecordId { get; set; }
        public int SportId { get; set; }
        public int CountryId { get; set; }
        public int CompentitionId { get; set; }
        public string CompentitionName { get; set; }
        public string SeasonName { get; set; }
        public int WinerId { get; set; }
        public string WinerName { get; set; }
        public bool HasTable { get; set; }
        public int Rivals { get; set; }
        public int Events { get; set; }
        public bool Finished { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
