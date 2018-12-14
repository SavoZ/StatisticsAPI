using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class CouponListStatisticTypes
    {
        public CouponListStatisticTypes()
        {
            CouponListLeagueSettings = new HashSet<CouponListLeagueSettings>();
        }

        public int StatisticId { get; set; }
        public string Name { get; set; }

        public ICollection<CouponListLeagueSettings> CouponListLeagueSettings { get; set; }
    }
}
