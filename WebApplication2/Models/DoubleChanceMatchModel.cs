using SatisticsAPI.Helper;
using StatisticsDataBase.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatisticsAPI.Models
{
	public class DoubleChanceMatchModel : BasicStatisticsGoalsModel
	{
		public int HomeZeroTwoToThreeGoals => calculator.CalculateZeroAndGoalsRange(HomeMatches, HomeId, 2, 3);
		public int AwayZeroTwoToThreeGoals => calculator.CalculateZeroAndGoalsRange(AwayMatches, AwayId, 2, 3);
		public int HomeZeroTwoToFourGoals => calculator.CalculateZeroAndGoalsRange(HomeMatches, HomeId, 2, 4);
		public int AwayZeroTwoToFourGoals => calculator.CalculateZeroAndGoalsRange(AwayMatches, AwayId, 2, 4);
		public int AwayGGThreePlusPercentage => calculator.CalculateGGThreePlusPercentage(AwayMatches);
		public int HomeGGThreePlusPercentage => calculator.CalculateGGThreePlusPercentage(HomeMatches);
		public int HomeAndGGPercentage => calculator.CalculateHomeWinAndGG(HomeMatches, HomeId);
		public int AwayAndGGPercentage => calculator.CalculateAwayWinAndGG(AwayMatches, AwayId);
		public int HomeId { get; internal set; }
		public int AwayId { get; internal set; }
	}
}
