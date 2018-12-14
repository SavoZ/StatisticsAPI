using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class CouponListLeagueSettings
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public int SportId { get; set; }
        public int SiteId { get; set; }
        public int? OddsId { get; set; }
        public int? StatisticId { get; set; }
        public int? OrderNo { get; set; }
        public int? CouponTypeId { get; set; }
        public bool ShouldPrint { get; set; }
        public string SettingsChangedBy { get; set; }
        public int RowHeightId { get; set; }

        public CouponListCouponTypes CouponType { get; set; }
        public CouponListOddsTypes Odds { get; set; }
        public CouponListStatisticTypes Statistic { get; set; }
    }
}
