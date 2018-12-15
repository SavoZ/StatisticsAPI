using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ATemplateSports
    {
        public long AId { get; set; }
        public long TemplateId { get; set; }
        public int SportId { get; set; }
        public DateTime Created { get; set; }
    }
}
