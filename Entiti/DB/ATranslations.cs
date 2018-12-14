using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ATranslations
    {
        public long AId { get; set; }
        public long Id { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public int TranslationGroupId { get; set; }
        public string TranslationGroupCode { get; set; }
        public string WordCode { get; set; }
        public string FullWordCode { get; set; }
        public string Translation { get; set; }
        public string ChangedByUserId { get; set; }
        public DateTime Created { get; set; }
    }
}
