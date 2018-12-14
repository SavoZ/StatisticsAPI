using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class BannerGames
    {
        public int BannerId { get; set; }
        public long EventId { get; set; }
        public string UserId { get; set; }

        public Banners Banner { get; set; }
    }
}
