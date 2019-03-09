namespace SatisticsAPI.Models
{
	public class StatisticsThreePlusModel : BasicStatisticsGoalsModel
	{
		public int HomeThreePlus => calculator.CalculateThreePlusGoalsPercentage(HomeMatches);
		public int AwayThreePlus => calculator.CalculateThreePlusGoalsPercentage(AwayMatches);
		public int HomeThreePlusInRow => calculator.CalculateThreePlusCount(HomeMatches);
		public int AwayThreePlusInRow => calculator.CalculateThreePlusCount(AwayMatches);
		public double HomeLastThree => calculator.CalculateAvgGoalsPerMatch(HomeMatches, 3);
		public double AwayLastThree => calculator.CalculateAvgGoalsPerMatch(AwayMatches, 3);
		public string HomeLastThreeArg => HomeLastThree.ToString("#.##");
		public string AwayLastThreeArg => AwayLastThree.ToString("#.##");
		public int Goals { get; set; }
		public bool IsGood => Goals >= 3;
	}
}
