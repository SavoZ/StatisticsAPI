using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ABanners
    {
        public long AId { get; set; }
        public int Id { get; set; }
        public int BannerTemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MatchNumber { get; set; }
        public string EmptyBannerImageUrl { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
