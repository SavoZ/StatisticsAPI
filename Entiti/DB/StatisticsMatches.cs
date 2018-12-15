using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class StatisticsMatches
    {
        public long RecordId { get; set; }
        public string MatchId { get; set; }
        public string SportName { get; set; }
        public DateTime StartTime { get; set; }
        public string SeasonName { get; set; }
        public int? CompentitionId { get; set; }
        public string EventGroupName { get; set; }
        public int HomeId { get; set; }
        public string HomeName { get; set; }
        public int AwayId { get; set; }
        public string AwayName { get; set; }
        public int HomePoints { get; set; }
        public int AwayPoints { get; set; }
        public bool HasWinner { get; set; }
        public int Winner { get; set; }
        public int ExtraTime { get; set; }
        public int ExtraTimeHomePoints { get; set; }
        public int ExtraTimeAwayPoints { get; set; }
        public int Statistics { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool Finished { get; set; }
    }
}
