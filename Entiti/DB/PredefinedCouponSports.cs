using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class PredefinedCouponSports
    {
        public int PredefinedCouponId { get; set; }
        public int SportId { get; set; }
        public string UserId { get; set; }

        public PredefinedCoupons PredefinedCoupon { get; set; }
    }
}
