using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class Translations
    {
        public long TranslationId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public long TranslationGroupId { get; set; }
        public string TranslationGroupCode { get; set; }
        public string WordCode { get; set; }
        public string FullWordCode { get; set; }
        public string Translation { get; set; }
        public string UserId { get; set; }
        public bool FromApi { get; set; }
        public DateTime? UsedOn { get; set; }

        public Languages Language { get; set; }
        public TranslationGroups TranslationGroup { get; set; }
    }
}
