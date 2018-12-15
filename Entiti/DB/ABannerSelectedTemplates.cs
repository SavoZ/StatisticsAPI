using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ABannerSelectedTemplates
    {
        public long AId { get; set; }
        public int BannerId { get; set; }
        public int SportId { get; set; }
        public int BannerSportTemplateId { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
