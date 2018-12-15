using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class BannerSites
    {
        public int BannerId { get; set; }
        public int SiteId { get; set; }
        public string Sid { get; set; }
        public string UserId { get; set; }

        public Banners Banner { get; set; }
        public Sites Site { get; set; }
    }
}
