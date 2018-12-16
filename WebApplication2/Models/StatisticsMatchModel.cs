using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SatisticsAPI.Helper;

namespace SatisticsAPI.Models {
	public class StatisticsMatchModel {
		StatisticsCalculator calculator = new StatisticsCalculator();

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
		public int HomeThreePlus => calculator.CalculateThreePlusGoalsPercentage(HomeMatches);
		public int AwayThreePlus => calculator.CalculateThreePlusGoalsPercentage(AwayMatches);
		public String StartTime { get; internal set; }
		public List<MatchModel> HomeMatches { get; internal set; }
		public List<MatchModel> AwayMatches { get; internal set; }
		public int HomeThreePlusInRow => calculator.CalculateThreePlusCount(HomeMatches);
		public int AwayThreePlusInRow => calculator.CalculateThreePlusCount(AwayMatches);
	}
}
