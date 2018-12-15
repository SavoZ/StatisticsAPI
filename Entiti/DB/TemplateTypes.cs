using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class TemplateTypes
    {
        public TemplateTypes()
        {
            Templates = new HashSet<Templates>();
        }

        public int TemplateTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Templates> Templates { get; set; }
    }
}
