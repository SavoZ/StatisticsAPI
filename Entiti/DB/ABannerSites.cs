using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ABannerSites
    {
        public long AId { get; set; }
        public int BannerId { get; set; }
        public int SiteId { get; set; }
        public string Sid { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
