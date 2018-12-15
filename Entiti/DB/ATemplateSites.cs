using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ATemplateSites
    {
        public long AId { get; set; }
        public long TemplateId { get; set; }
        public int SiteId { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
