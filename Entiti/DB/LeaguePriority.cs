using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class LeaguePriority
    {
        public int SiteId { get; set; }
        public int LeagueId { get; set; }
        public int SportId { get; set; }
        public int OrderNo { get; set; }
        public string UserId { get; set; }

        public Sites Site { get; set; }
    }
}
