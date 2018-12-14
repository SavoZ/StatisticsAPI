using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ABannerTemplates
    {
        public long AId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateCode { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
