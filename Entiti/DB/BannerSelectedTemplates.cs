using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class BannerSelectedTemplates
    {
        public int BannerId { get; set; }
        public int SportId { get; set; }
        public int BannerSportTemplateId { get; set; }
        public string UserId { get; set; }

        public Banners Banner { get; set; }
        public BannerSportTemplates BannerSportTemplate { get; set; }
    }
}
