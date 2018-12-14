using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class LeaguePromotion
    {
        public int LeaguePromotionId { get; set; }
        public int? Promotion { get; set; }
        public int? PromotionQualification { get; set; }
        public int? Promotion2 { get; set; }
        public int? Promotion2Qualification { get; set; }
        public int? Relegation { get; set; }
        public int? DropOut { get; set; }
        public int LeagueId { get; set; }
    }
}
