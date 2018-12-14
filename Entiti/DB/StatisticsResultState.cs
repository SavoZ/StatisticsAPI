using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class StatisticsResultState
    {
        public StatisticsResultState()
        {
            StatisticsYesterdaysResults = new HashSet<StatisticsYesterdaysResults>();
        }

        public int StateId { get; set; }
        public string State { get; set; }

        public StatisticsResultState StateNavigation { get; set; }
        public StatisticsResultState InverseStateNavigation { get; set; }
        public ICollection<StatisticsYesterdaysResults> StatisticsYesterdaysResults { get; set; }
    }
}
