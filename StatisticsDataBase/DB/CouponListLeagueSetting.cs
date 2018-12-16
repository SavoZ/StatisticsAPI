using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    [Table("CouponList.LeagueSettings")]
    public partial class CouponListLeagueSetting
    {
        public int Id { get; set; }
        [Column("LeagueID")]
        public int LeagueId { get; set; }
        [StringLength(250)]
        public string LeagueName { get; set; }
        [Column("SportID")]
        public int SportId { get; set; }
        [Column("SiteID")]
        public int SiteId { get; set; }
        [Column("OddsID")]
        public int? OddsId { get; set; }
        [Column("StatisticID")]
        public int? StatisticId { get; set; }
        public int? OrderNo { get; set; }
        [Column("CouponTypeID")]
        public int? CouponTypeId { get; set; }
        public bool ShouldPrint { get; set; }
        [StringLength(150)]
        public string SettingsChangedBy { get; set; }
        public int RowHeightId { get; set; }
    }
}
