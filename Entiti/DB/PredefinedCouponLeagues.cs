using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class PredefinedCouponLeagues
    {
        public int PredefinedCouponId { get; set; }
        public int LeagueId { get; set; }
        public string UserId { get; set; }

        public PredefinedCoupons PredefinedCoupon { get; set; }
    }
}
