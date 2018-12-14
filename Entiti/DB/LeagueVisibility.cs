using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class LeagueVisibility
    {
        public int SiteId { get; set; }
        public int LeagueId { get; set; }

        public Sites Site { get; set; }
    }
}
