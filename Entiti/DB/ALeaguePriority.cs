using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ALeaguePriority
    {
        public long AId { get; set; }
        public int SiteId { get; set; }
        public int LeagueId { get; set; }
        public int SportId { get; set; }
        public int OrderNo { get; set; }
        public DateTime Created { get; set; }
    }
}
