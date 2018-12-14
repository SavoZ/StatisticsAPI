using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class SportVisibility
    {
        public int SiteId { get; set; }
        public int SportId { get; set; }

        public Sites Site { get; set; }
    }
}
