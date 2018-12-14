using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models {
	public class StatisticsMatchModel {
		public string HomeName { get; set; }
		public string AwayName { get; internal set; }
		public int HomeGoalsScored { get; internal set; }
		public int AwayGoalsScored { get; internal set; }
		public int HomeGoalsAgaints { get; internal set; }
		public int AwayGoalsAgaints { get; internal set; }
		public string HomeAvrg => ((decimal) (HomeGoalsScored + HomeGoalsAgaints) / MatchPlayed).ToString("#.##");
		public string AwayAvrg => ((decimal) (AwayGoalsScored + AwayGoalsAgaints) / MatchPlayed).ToString("#.##");
		public string Total => ((decimal) ((HomeGoalsScored + HomeGoalsAgaints) + (AwayGoalsScored + AwayGoalsAgaints)) / (MatchPlayed*2)).ToString("#.##");
		public int MatchPlayed { get; internal set; }
		public int HomeThreePlus { get; set; }
		public int AwayThreePlus { get; internal set; }
	}
}
