using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SatisticsAPI.Helper;
using StatisticsDataBase.DB;

namespace SatisticsAPI.Models {
	public class StatisticsMatchModel {
		StatisticsCalculator calculator = new StatisticsCalculator();

		public string Home { get; set; }
		public string Away { get; internal set; }
		public string HomeName => $"({HomeStats.FirstOrDefault()?.Position}.) {Home} ";
		public string AwayName => $"({AwayStats.FirstOrDefault()?.Position}.) {Away}";
		public int HomeGoalsScored => HomeStats.Sum(b => b.TotalGoalsScored);
		public int AwayGoalsScored => AwayStats.Sum(a => a.TotalGoalsScored);
		public int HomeGoalsAgaints => HomeStats.Sum(b => b.TotalGoalsAgaints);
		public int AwayGoalsAgaints => AwayStats.Sum(a => a.TotalGoalsAgaints);
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

		public List<StatisticsTable> HomeStats { get; internal set; }
		public List<StatisticsTable> AwayStats { get; internal set; }
	}
}
