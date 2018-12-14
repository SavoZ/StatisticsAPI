using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class PredefinedCouponSites
    {
        public int PredefinedCouponId { get; set; }
        public int SiteId { get; set; }
        public bool AutoShowHide { get; set; }
        public string UserId { get; set; }
        public int? OrderNoForSite { get; set; }

        public PredefinedCoupons PredefinedCoupon { get; set; }
        public Sites Site { get; set; }
    }
}
