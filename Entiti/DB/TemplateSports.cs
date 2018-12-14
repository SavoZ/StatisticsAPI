using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class TemplateSports
    {
        public long TemplateId { get; set; }
        public long SportId { get; set; }

        public Templates Template { get; set; }
    }
}
