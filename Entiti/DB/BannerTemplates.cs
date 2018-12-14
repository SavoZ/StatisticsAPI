using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class BannerTemplates
    {
        public BannerTemplates()
        {
            Banners = new HashSet<Banners>();
        }

        public int BannerTemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateCode { get; set; }
        public string UserId { get; set; }

        public ICollection<Banners> Banners { get; set; }
    }
}
