﻿using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class Templates
    {
        public Templates()
        {
            PredefinedCoupons = new HashSet<PredefinedCoupons>();
            TemplateAutogeneratedItems = new HashSet<TemplateAutogeneratedItems>();
            TemplateSites = new HashSet<TemplateSites>();
            TemplateSports = new HashSet<TemplateSports>();
        }

        public long TemplateId { get; set; }
        public int TemplateTypeId { get; set; }
        public string Sid { get; set; }
        public string NameCode { get; set; }
        public string Description { get; set; }
        public string TemplateCode { get; set; }
        public bool Generated { get; set; }
        public bool Published { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public bool Landscape { get; set; }

        public TemplateTypes TemplateType { get; set; }
        public ICollection<PredefinedCoupons> PredefinedCoupons { get; set; }
        public ICollection<TemplateAutogeneratedItems> TemplateAutogeneratedItems { get; set; }
        public ICollection<TemplateSites> TemplateSites { get; set; }
        public ICollection<TemplateSports> TemplateSports { get; set; }
    }
}