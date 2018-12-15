using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SatisticsAPI.Models;

namespace SatisticsAPI.Helper {
	public class StatisticsCalculator {
		#region CalculateThreePlusGoalsPercentage(List<MatchModel> aoMatches)
		public int CalculateThreePlusGoalsPercentage(List<MatchModel> aoMatches) {
			if (CalculateNPlusGoals(aoMatches, 3) == 0) {
				return 0;
			} else {
				double percentage = CalculateNPlusGoals(aoMatches, 3);
				percentage = (percentage / aoMatches.Count) * 100;
				var per = (int) Math.Round(percentage);
				return per;
			}
		}
		#endregion

		#region CalculateGGThreePlusPercentage
		public int CalculateGGThreePlusPercentage(List<MatchModel> aoMatches) {
			if (CalculateNPlusGoals(aoMatches, 3) == 0) {
				return 0;
			} else {
				double percentage = CalculateGGNPlusGoals(aoMatches, 3);
				percentage = (percentage / aoMatches.Count) * 100;
				var per = (int) Math.Round(percentage);
				return per;
			}
		}
		#endregion

		#region CalculateGGorThreePlusPercentage
		public int CalculateGGorThreePlusPercentage(List<MatchModel> aoMatches) {
			if (CalculateNPlusGoals(aoMatches, 3) == 0 || (aoMatches.Count(m => m.HomeGoals > 0 && m.AwayGoals > 0) == 0)) {
				return 0;
			} else {
				double percentage = CalculateGGorThreePlusGoals(aoMatches, 3);
				percentage = (percentage / aoMatches.Count) * 100;
				var per = (int) Math.Round(percentage);
				return per;
			}
		}
		#endregion

		#region CalculateZeroToN(List<MatchModel> aoMatches, int limit)
		/// <summary>
		/// Returns number of matches which meets the condition
		/// </summary>
		/// <param name="aoMatches">List of matches the team has played</param>
		/// <param name="limit">Limit for the calculation, 0-1,0-2,0-3</param>
		/// <returns></returns>
		public int CalculateZeroToNGoals(List<MatchModel> aoMatches, int limit) {
			return aoMatches.Count(c => c.HomeGoals + c.AwayGoals <= limit);
		}
		#endregion

		#region CalculateNPlusGoals(List<MatchModel> aoMatches, int limit)
		/// <summary>
		/// Returns number of matches which meets the condition
		/// </summary>
		/// <param name="aoMatches">List of matches the team has played</param>
		/// <param name="limit">1+2+3+4+5+</param>
		/// <returns></returns>
		public int CalculateNPlusGoals(List<MatchModel> aoMatches, int limit) {
			return aoMatches.Count(c => c.HomeGoals + c.AwayGoals >= limit);
		}
		#endregion

		#region CalculateGGNPlusGoals(List<MatchModel> aoMatches, int limit)
		/// <summary>
		/// Returns number of matches which meets the condition
		/// </summary>
		/// <param name="aoMatches">List of matches the team has played</param>
		/// <param name="limit">1+2+3+4+5+</param>
		/// <returns></returns>
		public int CalculateGGNPlusGoals(List<MatchModel> aoMatches, int limit) {
			return aoMatches.Count(c => (c.HomeGoals + c.AwayGoals >= limit) && c.HomeGoals >= 1 && c.AwayGoals >= 1);
		}
		#endregion

		#region CalculateGGorThreePlusGoals(List<MatchModel> aoMatches, int limit)
		/// <summary>
		/// Returns number of matches which meets the condition
		/// </summary>
		/// <param name="aoMatches">List of matches the team has played</param>
		/// <param name="limit">1+2+3+4+5+</param>
		/// <returns></returns>
		public int CalculateGGorThreePlusGoals(List<MatchModel> aoMatches, int limit) {
			return aoMatches.Count(c => (c.HomeGoals + c.AwayGoals >= limit) || (c.HomeGoals > 0 && c.AwayGoals > 0));
		}
		#endregion

		#region CalculateGoalsRange(List<MatchModel> aoMatches, int aoFromGoal, int aoToGoal)
		public int CalculateGoalsRange(List<MatchModel> aoMatches, int aoFromGoal, int aoToGoal) {
			return aoMatches.Count(c => c.HomeGoals + c.AwayGoals >= aoFromGoal && c.HomeGoals + c.AwayGoals <= aoToGoal);
		}
		#endregion

		#region CalculateAvgGoalsPerMatch(List<MatchModel> aoMatches)
		public double CalculateAvgGoalsPerMatch(List<MatchModel> aoMatches) {
			if (aoMatches.Any()) {
				var totalGoals = 0.00;
				foreach (var match in aoMatches) {
					totalGoals += (double) match.HomeGoals + match.AwayGoals;
				}
				return totalGoals / aoMatches.Count();
			} else {
				return 0;
			}
		}
		#endregion

		#region CalculateZeroToTwoGoalsPercentage(List<MatchModel> aoMatches)
		public int CalculateZeroToTwoGoalsPercentage(List<MatchModel> aoMatches) {
			if (CalculateZeroToNGoals(aoMatches, 2) == 0) {
				return 0;
			} else {
				double percentage = CalculateZeroToNGoals(aoMatches, 2);
				percentage = (percentage / aoMatches.Count) * 100;
				var per = (int) Math.Round(percentage);
				return per;
			}
		}
		#endregion

		#region CalculateZeroAndGoalsRange(List<MatchModel> aoMatches, int aoFromGoal, int aoToGoal)
		public int CalculateZeroAndGoalsRange(List<MatchModel> aoMatches, int teamId, int aoFromGoal, int aoToGoal) {
			var matches = aoMatches.Where(c => c.HomeID == teamId).ToList();
			var matchPlayed = matches.Count == 0 ? 1 : matches.Count;

			var count = matches.Count(c => c.HomeGoals + c.AwayGoals >= aoFromGoal && c.HomeGoals + c.AwayGoals <= aoToGoal && c.HomeGoals > c.AwayGoals);

			return (count * 100) / matchPlayed;
		}
		#endregion

		#region CalculateTwoAndGoalsRange(List<MatchModel> aoMatches, int aoFromGoal, int aoToGoal)
		public int CalculateTwoAndGoalsRange(List<MatchModel> aoMatches, int teamId, int aoFromGoal, int aoToGoal) {
			var matches = aoMatches.Where(c => c.AwayID == teamId).ToList();
			var matchPlayed = matches.Count == 0 ? 1 : matches.Count;

			var count = matches.Count(c => c.HomeGoals + c.AwayGoals >= aoFromGoal && c.HomeGoals + c.AwayGoals <= aoToGoal && c.AwayGoals > c.HomeGoals);

			return (count * 100) / matchPlayed;
		}
		#endregion


		#region CalculateNotTwoAndGoalsRange(List<MatchModel> aoMatches, int aoFromGoal)
		public int CalculateNotTwoAndGoalsRange(List<MatchModel> aoMatches, int teamId, int aoFromGoal) {
			var matches = aoMatches.Where(c => c.HomeID == teamId).ToList();
			var matchPlayed = matches.Count == 0 ? 1 : matches.Count;

			var count = matches.Count(c => c.HomeGoals + c.AwayGoals >= aoFromGoal && c.HomeGoals >= c.AwayGoals);

			return (count * 100) / matchPlayed;
		}
		#endregion
	}
}
