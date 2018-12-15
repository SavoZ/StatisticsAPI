using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ATemplates
    {
        public long AId { get; set; }
        public long Id { get; set; }
        public int TemplateTypeId { get; set; }
        public string NameCode { get; set; }
        public string Description { get; set; }
        public string TemplateCode { get; set; }
        public bool? Generated { get; set; }
        public bool? Published { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
