using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class CouponListCouponTypes
    {
        public CouponListCouponTypes()
        {
            CouponListLeagueSettings = new HashSet<CouponListLeagueSettings>();
        }

        public int CouponTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<CouponListLeagueSettings> CouponListLeagueSettings { get; set; }
    }
}
