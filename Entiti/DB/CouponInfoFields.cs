using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class CouponInfoFields
    {
        public int InfoFieldId { get; set; }
        public long EventId { get; set; }
        public int LeagueId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HomeResult { get; set; }
        public int? AwayResult { get; set; }
        public string GroupName { get; set; }
    }
}
