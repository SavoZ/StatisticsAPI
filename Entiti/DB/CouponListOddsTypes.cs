using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class CouponListOddsTypes
    {
        public CouponListOddsTypes()
        {
            CouponListLeagueSettings = new HashSet<CouponListLeagueSettings>();
        }

        public int OddsId { get; set; }
        public string Name { get; set; }

        public ICollection<CouponListLeagueSettings> CouponListLeagueSettings { get; set; }
    }
}
