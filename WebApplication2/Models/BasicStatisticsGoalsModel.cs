using SatisticsAPI.Helper;
using StatisticsDataBase.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatisticsAPI.Models
{
	public class BasicStatisticsGoalsModel
	{
		protected StatisticsCalculator calculator = new StatisticsCalculator();

		public string Home { get; set; }
		public string Away { get; internal set; }
		public string HomeName => $"({HomeStats.FirstOrDefault()?.Position}.) {Home} ";
		public string AwayName => $"({AwayStats.FirstOrDefault()?.Position}.) {Away}";
		public int HomeGoalsScored => HomeMatches.Sum(b => b.HomeGoals);
		public int AwayGoalsScored => AwayMatches.Sum(a => a.AwayGoals);
		public int HomeGoalsAgaints => HomeMatches.Sum(b => b.AwayGoals);
		public int AwayGoalsAgaints => AwayMatches.Sum(a => a.HomeGoals);
		public decimal HomeAvrage => ((decimal)(HomeGoalsScored + HomeGoalsAgaints) / Math.Max(HomeMatches.Count, 1));
		public decimal AwayAvraage => ((decimal)(AwayGoalsScored + AwayGoalsAgaints) / Math.Max(AwayMatches.Count, 1));
		public string HomeAvrg => HomeAvrage.ToString("#.##");
		public string AwayAvrg => AwayAvraage.ToString("#.##");
		public decimal TotalGoals => ((HomeAvrage + AwayAvraage) / 2);
		public string Total => TotalGoals.ToString("#.##");
		public decimal Average => (((decimal)HomeGoalsScored / Math.Max(HomeMatches.Count,1)) + ((decimal)AwayGoalsScored / Math.Max(AwayMatches.Count, 1)));
		public string Avrg => Average.ToString("#.##");
		public int MatchPlayed { get; internal set; }
		public String StartTime { get; internal set; }
		public List<MatchModel> HomeMatches { get; internal set; }
		public List<MatchModel> AwayMatches { get; internal set; }
		public List<StatisticsTable> HomeStats { get; internal set; }
		public List<StatisticsTable> AwayStats { get; internal set; }
		public string LeagueName { get; internal set; }
		public string HomeGoals => $"{HomeGoalsScored}-{HomeGoalsAgaints}";
		public string AwayGoals => $"{AwayGoalsScored}-{AwayGoalsAgaints}";
	}
}
