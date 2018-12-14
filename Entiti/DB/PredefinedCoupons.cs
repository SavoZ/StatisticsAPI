using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class PredefinedCoupons
    {
        public PredefinedCoupons()
        {
            PredefinedCouponLeagues = new HashSet<PredefinedCouponLeagues>();
            PredefinedCouponSites = new HashSet<PredefinedCouponSites>();
            PredefinedCouponSports = new HashSet<PredefinedCouponSports>();
        }

        public int PredefinedCouponId { get; set; }
        public string Sid { get; set; }
        public string CouponCode { get; set; }
        public string Description { get; set; }
        public string TimeFilter { get; set; }
        public long TemplateId { get; set; }
        public bool Landscape { get; set; }
        public bool MultiSport { get; set; }
        public bool GroupByLeague { get; set; }
        public bool IncludeAntepost { get; set; }
        public bool IncludeScorers { get; set; }
        public int StartOfDay { get; set; }
        public int FilterType { get; set; }
        public bool AutoHide { get; set; }
        public bool Active { get; set; }
        public int NumberOfItems { get; set; }
        public string AutoHideScript { get; set; }
        public int? OrderNo { get; set; }

        public Templates Template { get; set; }
        public ICollection<PredefinedCouponLeagues> PredefinedCouponLeagues { get; set; }
        public ICollection<PredefinedCouponSites> PredefinedCouponSites { get; set; }
        public ICollection<PredefinedCouponSports> PredefinedCouponSports { get; set; }
    }
}
