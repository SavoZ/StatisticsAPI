using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsDataBase.DB;

namespace StatisticsService.DB {
	public class DBHelper {

		public void UpdateTable(List<StatisticsTable> aoTables) {
			var loEntities = new StatisticsContext();
			var competitionID = -1;
			if (aoTables.Any()) {
				competitionID = aoTables.First().CompetitionId;
			}
			if (competitionID != -1) {
				var listForRemove = loEntities.StatisticsTables.Where(s => s.CompetitionId == competitionID).ToList();
				loEntities.StatisticsTables.RemoveRange(listForRemove);
				loEntities.StatisticsTables.AddRange(aoTables);
				loEntities.SaveChanges();
			}
		}

		public void UpdateMatches(List<StatisticsMatch> aoMatches) {
			var loEntities = new StatisticsContext();
			var loMatches = loEntities.StatisticsMatches.ToList();

			foreach (var loMatch in aoMatches) {
				if (loMatches.Any(o => o.MatchId == loMatch.MatchId)) {
					StatisticsMatch match = getMatch(loMatches, loMatch.MatchId);
					if (match.AwayId != loMatch.AwayId || match.HomeId != loMatch.HomeId || match.AwayPoints != loMatch.AwayPoints
						|| match.HomePoints != loMatch.HomePoints || match.CompentitionId != loMatch.CompentitionId || match.Finished != loMatch.Finished
						|| match.HomeName != loMatch.HomeName || match.AwayName != loMatch.AwayName || match.StartTime != loMatch.StartTime) {
						match.AwayId = loMatch.AwayId;
						match.AwayName = loMatch.AwayName;
						match.HomeId = loMatch.HomeId;
						match.HomeName = loMatch.HomeName;
						match.AwayPoints = loMatch.AwayPoints;
						match.HomePoints = loMatch.HomePoints;
						match.CompentitionId = loMatch.CompentitionId;
						match.Finished = loMatch.Finished;
						match.DateModified = DateTime.Now;
						match.StartTime = loMatch.StartTime;
					}
				} else {
					loMatch.DateCreated = DateTime.Now;
					loEntities.StatisticsMatches.Add(loMatch);
				}

			}
			loEntities.SaveChangesAsync();
		}

		#region private methods
		private StatisticsMatch getMatch(List<StatisticsMatch> aoMatches, String matchID) {
			return aoMatches.First(m => m.MatchId == matchID);
		}
		#endregion
	}
}
