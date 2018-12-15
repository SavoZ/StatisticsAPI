using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entiti.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisticsAPI.Helper;
using SatisticsAPI.Models;

namespace SatisticsAPI.Controllers {
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class StatisticsController : ControllerBase {
		//private readonly List<int> leagues = new List<int> { 80, 87, 92, 93, 95, 96, 103, 107, 108, 109, 110, 111, 112, 113, 115, 116, 117, 122, 123, 124, 125 };
		private readonly List<int> leagues = new List<int> { 80, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 99, 102, 103, 104, 105, 107, 108, 109, 110,
			111, 112, 113, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 132, 133, 134, 135, 136, 139, 142, 144, 145,
			146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 157, 159, 198, 215, 236, 237, 243, 245, 247, 248, 252, 253, 262, 264, 271, 272, 273, 300,
			304, 305, 310, 330, 331, 333, 341, 343, 379, 385, 416, 418, 485, 490, 527, 655, 656, 657, 658, 676, 684, 715, 716 };

		[HttpGet]
		public async Task<IActionResult> GetStatistics() {
			IActionResult loResult = BadRequest();
			var calculator = new StatisticsCalculator();

			using (var db = new CouponAdminContext()) {

				var model = new List<StatisticsMatchModel>();
				foreach (var league in leagues) {

					var matches = db.StatisticsMatches.Where(l => l.CompentitionId == league);
					var tables = db.StatisticsTables.Where(l => l.CompetitionId == league);
					var matchPlayed = await tables.FirstOrDefaultAsync();

					var round = await matches.OrderBy(r => r.StartTime).FirstOrDefaultAsync(r => r.Finished == false);

					if (round != null) {
						var match = await matches.Where(r => r.EventGroupName == round.EventGroupName).Select(a =>
												new StatisticsMatchModel {
													HomeName = a.HomeName,
													AwayName = a.AwayName,
													HomeGoalsScored = tables.Where(t => t.TeamId == a.HomeId).Sum(b => b.TotalGoalsScored),
													AwayGoalsScored = tables.Where(t => t.TeamId == a.AwayId).Sum(b => b.TotalGoalsScored),
													HomeGoalsAgaints = tables.Where(t => t.TeamId == a.HomeId).Sum(b => b.TotalGoalsAgaints),
													AwayGoalsAgaints = tables.Where(t => t.TeamId == a.AwayId).Sum(b => b.TotalGoalsAgaints),
													MatchPlayed = matchPlayed.MatchesPlayed,
													HomeThreePlus = calculator.CalculateThreePlusGoalsPercentage
													(matches.Where(m => (m.HomeId == a.HomeId || m.AwayId == a.HomeId) &&
																		m.Finished).Select(m => new MatchModel() {
																			AwayID = m.AwayId,
																			AwayGoals = m.AwayPoints,
																			AwayName = m.AwayName,
																			HomeID = m.HomeId,
																			HomeGoals = m.HomePoints,
																			HomeName = m.HomeName
																		}).ToList()),
													AwayThreePlus = calculator.CalculateThreePlusGoalsPercentage
													(matches.Where(m => (m.HomeId == a.AwayId || m.AwayId == a.AwayId) &&
																		m.Finished).Select(m => new MatchModel() {
																			AwayID = m.AwayId,
																			AwayGoals = m.AwayPoints,
																			AwayName = m.AwayName,
																			HomeID = m.HomeId,
																			HomeGoals = m.HomePoints,
																			HomeName = m.HomeName
																		}).ToList())

												}).ToListAsync();

						model.AddRange(match);
					}
				}

				return Ok(model);
			}
		}

		public async Task<GoalsModel> CalculateGoalsStats(Int64 aoLeague, Int32 aoTeam) {
			var loModel = new GoalsModel();
			var loEntities = new CouponAdminContext();

			var loMatches = await (from m in loEntities.StatisticsMatches
								   where m.CompentitionId == aoLeague &&
										 (m.HomeId == aoTeam || m.AwayId == aoTeam) &&
										 m.Finished
								   orderby m.StartTime
								   select new MatchModel {
									   HomeID = m.HomeId,
									   HomeGoals = m.HomePoints,
									   AwayID = m.AwayId,
									   AwayGoals = m.AwayPoints,
								   }).ToListAsync();

			var loHomeMatches = loMatches.FindAll(m => m.HomeID == aoTeam);
			var loAwayMatches = loMatches.FindAll(m => m.AwayID == aoTeam);

			loModel.TDG = loHomeMatches.Count(n => n.HomeGoals > 0) + loAwayMatches.Count(n => n.AwayGoals > 0);
			loModel.ThreePlus = loMatches.Count(n => n.HomeGoals + n.AwayGoals > 2);
			loModel.GG = loMatches.Count(m => m.HomeGoals > 0 && m.AwayGoals > 0);
			loModel.FourPlusGoals = loMatches.Count(n => n.HomeGoals + n.AwayGoals > 3);
			//loModel.AvgGoalsPerMatch = CalculateAvgGoalsPerMatch(loMatches);

			return loModel;
		}

		[HttpGet]
		public async Task<IActionResult> GetGoalsStatistics() {
			IActionResult loResult = BadRequest();
			var calculator = new StatisticsCalculator();

			using (var db = new CouponAdminContext()) {

				var model = new List<TeamGoalsModel>();

				foreach (var league in leagues) {
					try {

						var statsTables = db.StatisticsTables.Where(t => t.CompetitionId == league).Select(t =>
								new TeamGoalsModel() { Position = t.Position, TeamName = t.TeamName, TeamID = t.TeamId })
							.ToList();

						foreach (var team in statsTables) {
							var teamMatches = await (db.StatisticsMatches
								.Where(m => m.CompentitionId == league &&
											(m.HomeId == team.TeamID || m.AwayId == team.TeamID) &&
											m.Finished).Select(m => new MatchModel() {
												AwayID = m.AwayId,
												AwayGoals = m.AwayPoints,
												AwayName = m.AwayName,
												HomeID = m.HomeId,
												HomeGoals = m.HomePoints,
												HomeName = m.HomeName
											})).ToListAsync();
							team.TotalGames = teamMatches.Count;
							if (team.TotalGames == 0)
								continue;

							team.ZeroToTwoPercentage = calculator.CalculateZeroToTwoGoalsPercentage(teamMatches);
							team.ThreePlusPercentage = calculator.CalculateThreePlusGoalsPercentage(teamMatches);
							team.OneToThreeGoals = calculator.CalculateGoalsRange(teamMatches, 1, 3);
							team.TwoToThreeGoals = calculator.CalculateGoalsRange(teamMatches, 2, 3);
							team.TwoToFourGoals = calculator.CalculateGoalsRange(teamMatches, 2, 4);
							team.OneToThreeGoalsPercentage = team.OneToThreeGoals * 100 / team.TotalGames;
							team.TwoToThreeGoalsPercentage = team.TwoToThreeGoals * 100 / team.TotalGames;
							team.ZeroThreeToFive =
								calculator.CalculateZeroAndGoalsRange(teamMatches, team.TeamID, 3, 5);
							team.ZeroTwoToFive = calculator.CalculateZeroAndGoalsRange(teamMatches, team.TeamID, 2, 5);
							team.TwoToFourGoalsPercentage = team.TwoToFourGoals * 100 / team.TotalGames;

							model.Add(team);
						}
					} catch (Exception e) {
						Console.WriteLine(e);
						throw e;
					}
				}

				return Ok(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetDoubleChanceStatistics() {
			IActionResult loResult = BadRequest();
			var calculator = new StatisticsCalculator();

			using (var db = new CouponAdminContext()) {

				var model = new List<DoubleChanceModel>();

				foreach (var league in leagues) {

					var statsTables = db.StatisticsTables.Where(t => t.CompetitionId == league).Select(t =>
							new DoubleChanceModel() { Position = t.Position, TeamName = t.TeamName, TeamID = t.TeamId }).ToList();

					foreach (var team in statsTables) {
						var teamMatches = await (db.StatisticsMatches
							.Where(m => m.CompentitionId == league && (m.HomeId == team.TeamID || m.AwayId == team.TeamID) &&
										m.Finished).Select(m => new MatchModel() {
											AwayID = m.AwayId,
											AwayGoals = m.AwayPoints,
											AwayName = m.AwayName,
											HomeID = m.HomeId,
											HomeGoals = m.HomePoints,
											HomeName = m.HomeName
										})).ToListAsync();
						team.TotalGames = teamMatches.Count;

						team.ZeroTwoToThreeGoals = calculator.CalculateZeroAndGoalsRange(teamMatches, team.TeamID, 2, 3);
						team.ZeroTwoToFourGoals = calculator.CalculateZeroAndGoalsRange(teamMatches, team.TeamID, 2, 4);
						team.TwoTwoToFourGoals = calculator.CalculateTwoAndGoalsRange(teamMatches, team.TeamID, 2, 4);
						team.TwoTwoToThreeGoals = calculator.CalculateTwoAndGoalsRange(teamMatches, team.TeamID, 2, 3);
						team.NotTwoAndThreeGoals = calculator.CalculateNotTwoAndGoalsRange(teamMatches, team.TeamID, 3);
						team.NotTwoAndTwoGoals = calculator.CalculateNotTwoAndGoalsRange(teamMatches, team.TeamID, 2);
						team.GGThreePlusPercentage = calculator.CalculateGGThreePlusPercentage(teamMatches);
						team.GGorThreePlusPercentage = calculator.CalculateGGorThreePlusPercentage(teamMatches);
						model.Add(team);
					}
				}

				return Ok(model);
			}
		}



	}
}
