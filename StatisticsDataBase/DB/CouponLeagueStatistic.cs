using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    [Table("Coupon.LeagueStatistics")]
    public partial class CouponLeagueStatistic
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
    }
}
