using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class ABannerGames
    {
        public long AId { get; set; }
        public int BannerId { get; set; }
        public long EventId { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
