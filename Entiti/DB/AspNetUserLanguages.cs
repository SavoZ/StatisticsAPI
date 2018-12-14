using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class AspNetUserLanguages
    {
        public string UserId { get; set; }
        public int LanguageId { get; set; }

        public Languages Language { get; set; }
    }
}
