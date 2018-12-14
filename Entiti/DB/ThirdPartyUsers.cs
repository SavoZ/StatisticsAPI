using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ThirdPartyUsers
    {
        public int ThirdPartyId { get; set; }
        public string ApiKey { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public bool SaOdds { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
