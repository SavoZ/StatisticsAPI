using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class SiteMarketTemplates
    {
        public int SiteMarketTemplateId { get; set; }
        public int SiteId { get; set; }
        public int MarketTemplateId { get; set; }
        public string MarketTemplateName { get; set; }
        public int SportId { get; set; }
        public int? OrderNo { get; set; }
    }
}
