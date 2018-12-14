using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class BannerSportTemplates
    {
        public BannerSportTemplates()
        {
            BannerSelectedTemplates = new HashSet<BannerSelectedTemplates>();
        }

        public int BannerSportTemplateId { get; set; }
        public int SportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateCode { get; set; }
        public string UserId { get; set; }

        public ICollection<BannerSelectedTemplates> BannerSelectedTemplates { get; set; }
    }
}
