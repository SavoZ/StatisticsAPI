using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class Banners
    {
        public Banners()
        {
            BannerGames = new HashSet<BannerGames>();
            BannerSelectedTemplates = new HashSet<BannerSelectedTemplates>();
            BannerSites = new HashSet<BannerSites>();
        }

        public int BannerId { get; set; }
        public int BannerTemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MatchNumber { get; set; }
        public string EmptyBannerImageUrl { get; set; }
        public string UserId { get; set; }

        public BannerTemplates BannerTemplate { get; set; }
        public ICollection<BannerGames> BannerGames { get; set; }
        public ICollection<BannerSelectedTemplates> BannerSelectedTemplates { get; set; }
        public ICollection<BannerSites> BannerSites { get; set; }
    }
}
