﻿using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class TemplateAutogeneratedItems
    {
        public long TemplateAutogeneratedItemId { get; set; }
        public long TemplateId { get; set; }
        public int SiteId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public int TimezoneOffset { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public bool LeagueGrouping { get; set; }

        public Languages Language { get; set; }
        public Sites Site { get; set; }
        public Templates Template { get; set; }
    }
}
