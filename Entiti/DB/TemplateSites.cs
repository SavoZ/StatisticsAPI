using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class TemplateSites
    {
        public long TemplateId { get; set; }
        public int SiteId { get; set; }
        public string UserId { get; set; }

        public Sites Site { get; set; }
        public Templates Template { get; set; }
    }
}
