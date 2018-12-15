using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class StatisticsYesterdaysResults
    {
        public long ResultId { get; set; }
        public long EventId { get; set; }
        public DateTime PlayedOn { get; set; }
        public string EventName { get; set; }
        public string Code { get; set; }
        public string Period1 { get; set; }
        public string Period2 { get; set; }
        public string Period3 { get; set; }
        public string Period4 { get; set; }
        public string Period5 { get; set; }
        public string Period6 { get; set; }
        public string Period7 { get; set; }
        public long SportId { get; set; }
        public long LeagueId { get; set; }
        public int Fgs { get; set; }
        public DateTime InsertedOn { get; set; }
        public string SportName { get; set; }
        public string LeagueName { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public string Region { get; set; }
        public bool? Ignore { get; set; }
        public int? StateId { get; set; }
        public string StateChangedBy { get; set; }
        public DateTime? StateChangedOn { get; set; }

        public StatisticsResultState State { get; set; }
        public AspNetUsers StateChangedByNavigation { get; set; }
    }
}
