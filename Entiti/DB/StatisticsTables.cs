using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class StatisticsTables
    {
        public long RecordId { get; set; }
        public string SeasonName { get; set; }
        public int CompetitionId { get; set; }
        public string GroupName { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public int Position { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int WinsOvertime { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int LossesOvertime { get; set; }
        public int WinsPen { get; set; }
        public int TotalGoalsScored { get; set; }
        public int TotalGoalsAgaints { get; set; }
        public int Points { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int SeasonId { get; set; }
    }
}
