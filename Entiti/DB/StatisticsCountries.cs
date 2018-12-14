using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class StatisticsCountries
    {
        public long RecordId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
