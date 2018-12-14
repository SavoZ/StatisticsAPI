using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class TranslationGroups
    {
        public TranslationGroups()
        {
            Translations = new HashSet<Translations>();
        }

        public long TranslationGroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }

        public ICollection<Translations> Translations { get; set; }
    }
}
