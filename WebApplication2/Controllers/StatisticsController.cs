using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisticsAPI.Helper;
using SatisticsAPI.Models;
using StatisticsDataBase.DB;

namespace SatisticsAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetStatistics()
		{
			using (var db = new StatisticsContext())
			{
				var dateFrom = DateTime.Now.AddHours(2);
				var dateTo = DateTime.Now.AddDays(1);

				var model = new List<StatisticsThreePlusModel>();
				foreach (var league in db.Leagues)
				{
					var matches = db.StatisticsMatches.Where(l => l.CompentitionId == league.LeagueId).OrderBy(r => r.StartTime).ToList();
					var tables = db.StatisticsTables.Where(l => l.CompetitionId == league.LeagueId);
					var matchPlayed = await tables.FirstOrDefaultAsync();

					var round = matches.FirstOrDefault(r => r.StartTime >= dateFrom && r.Finished == false);
					if (round != null && matchPlayed.MatchesPlayed > 0)
					{
						var match = matches.Where(r => r.EventGroupName == round.EventGroupName
													   && r.StartTime < dateTo && r.StartTime > dateFrom)
										   .Select(a => new StatisticsThreePlusModel
										   {
											   Home = a.HomeName,
											   Away = a.AwayName,
											   LeagueName = league.LeagueName,
											   HomeStats = tables.Where(t => t.TeamId == a.HomeId).ToList(),
											   AwayStats = tables.Where(t => t.TeamId == a.AwayId).ToList(),
											   StartTime = a.StartTime.ToString("dd.MM.HH:mm"),
											   MatchPlayed = matchPlayed.MatchesPlayed,
											   HomeMatches = getMatches(matches, a.HomeId, true),
											   AwayMatches = getMatches(matches, a.AwayId, false),
										   }).ToList();
						model.AddRange(match);
					}
				}
				return Ok(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetGoalsStatistics()
		{
			BadRequest();
			var calculator = new StatisticsCalculator();
			using (var db = new StatisticsContext())
			{
				var model = new List<TeamGoalsModel>();
				foreach (var league in db.Leagues)
				{
					try
					{

						var statsTables = db.StatisticsTables.Where(t => t.CompetitionId == league.LeagueId)
															.Select(t => new TeamGoalsModel()
															{
																Position = t.Position,
																TeamName = t.TeamName,
																TeamID = t.TeamId
															}).ToList();

						foreach (var team in statsTables)
						{
							var teamMatches = await (db.StatisticsMatches
								.Where(m => m.CompentitionId == league.LeagueId &&
											(m.HomeId == team.TeamID || m.AwayId == team.TeamID) &&
											m.Finished == true).Select(m => new MatchModel()
											{
												AwayID = m.AwayId,
												AwayGoals = m.AwayPoints,
												AwayName = m.AwayName,
												HomeID = m.HomeId,
												HomeGoals = m.HomePoints,
												HomeName = m.HomeName
											})).ToListAsync();
							team.TotalGames = teamMatches.Count;
							team.LeagueName = league.LeagueName;
							if (team.TotalGames == 0)
								continue;

							team.ZeroToTwoPercentage = calculator.CalculateZeroToTwoGoalsPercentage(teamMatches);
							team.ThreePlusPercentage = calculator.CalculateThreePlusGoalsPercentage(teamMatches);
							team.OneToThreeGoals = calculator.CalculateGoalsRange(teamMatches, 1, 3);
							team.TwoToThreeGoals = calculator.CalculateGoalsRange(teamMatches, 2, 3);
							team.TwoToFourGoals = calculator.CalculateGoalsRange(teamMatches, 2, 4);
							team.OneToThreeGoalsPercentage = team.OneToThreeGoals * 100 / team.TotalGames;
							team.TwoToThreeGoalsPercentage = team.TwoToThreeGoals * 100 / team.TotalGames;
							team.ZeroThreeToFive = calculator.CalculateZeroAndGoalsRange(teamMatches, team.TeamID, 3, 5);
							team.ZeroTwoToFive = calculator.CalculateZeroAndGoalsRange(teamMatches, team.TeamID, 2, 5);
							team.TwoToFourGoalsPercentage = team.TwoToFourGoals * 100 / team.TotalGames;

							model.Add(team);
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
						throw e;
					}
				}
				return Ok(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetDoubleChanceStatistics()
		{
			var calculator = new StatisticsCalculator();
			using (var db = new StatisticsContext())
			{
				var model = new List<DoubleChanceModel>();
				foreach (var league in db.Leagues)
				{

					var statsTables = db.StatisticsTables.Where(t => t.CompetitionId == league.LeagueId)
														 .Select(t => new DoubleChanceModel()
														 {
															 Position = t.Position,
															 TeamName = t.TeamName,
															 TeamID = t.TeamId
														 }).ToList();

					foreach (var team in statsTables)
					{
						var teamMatches = await (db.StatisticsMatches
							.Where(m => m.CompentitionId == league.LeagueId && (m.HomeId == team.TeamID || m.AwayId == team.TeamID) &&
										m.Finished == true).Select(m => new MatchModel()
										{
											AwayID = m.AwayId,
											AwayGoals = m.AwayPoints,
											AwayName = m.AwayName,
											HomeID = m.HomeId,
											HomeGoals = m.HomePoints,
											HomeName = m.HomeName
										})).ToListAsync();
						team.TotalGames = teamMatches.Count;
						team.LeagueName = league.LeagueName;
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
		[HttpGet]
		public async Task<IActionResult> GetDoubleChanceMatchStatistics()
		{

			using (var db = new StatisticsContext())
			{

				var model = new List<DoubleChanceMatchModel>();
				foreach (var league in db.Leagues)
				{

					var matches = db.StatisticsMatches.Where(l => l.CompentitionId == league.LeagueId).OrderBy(r => r.StartTime).ToList();
					var tables = db.StatisticsTables.Where(l => l.CompetitionId == league.LeagueId);
					var matchPlayed = await tables.FirstOrDefaultAsync();

					var dateFrom = DateTime.Now;
					var dateTo = DateTime.Now.AddDays(5);

					var round = matches.FirstOrDefault(r => r.StartTime >= dateFrom && r.Finished == false);
					if (round != null && matchPlayed.MatchesPlayed > 0)
					{
						var match = matches.Where(r => r.EventGroupName == round.EventGroupName
													   && r.StartTime < dateTo && r.StartTime > dateFrom)
										   .Select(a => new DoubleChanceMatchModel
										   {
											   Home = a.HomeName,
											   Away = a.AwayName,
											   HomeId = a.HomeId,
											   AwayId = a.AwayId,
											   LeagueName = league.LeagueName,
											   HomeStats = tables.Where(t => t.TeamId == a.HomeId).ToList(),
											   AwayStats = tables.Where(t => t.TeamId == a.AwayId).ToList(),
											   StartTime = a.StartTime.ToString("dd.MM.yyyy. HH:mm"),
											   MatchPlayed = matchPlayed.MatchesPlayed,
											   HomeMatches = getMatches(matches, a.HomeId),
											   AwayMatches = getMatches(matches, a.AwayId),
										   }).ToList();
						model.AddRange(match);
					}
				}
				return Ok(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetLastRoundStatistics()
		{
			using (var db = new StatisticsContext())
			{
				var dateFrom = DateTime.Now.AddDays(-7);
				var dateTo = DateTime.Now.AddHours(-6);

				var model = new List<StatisticsThreePlusModel>();
				foreach (var league in db.Leagues)
				{
					var matches = db.StatisticsMatches.Where(l => l.CompentitionId == league.LeagueId)
													  .OrderBy(r => r.StartTime).ToList();

					var tables = db.StatisticsTables.Where(l => l.CompetitionId == league.LeagueId);
					var matchPlayed = await tables.FirstOrDefaultAsync();

					var round = matches.Where(m => m.Finished == true).OrderBy(r => r.StartTime).LastOrDefault();

					if (round != null && matchPlayed.MatchesPlayed > 0)
					{
						var match = matches.Where(r => r.EventGroupName == round.EventGroupName && r.Finished == true
												 && r.StartTime > dateFrom && r.StartTime < dateTo)
										   .Select(a => new StatisticsThreePlusModel
										   {
											   Home = a.HomeName,
											   Away = a.AwayName,
											   LeagueName = league.LeagueName,
											   HomeStats = tables.Where(t => t.TeamId == a.HomeId).ToList(),
											   AwayStats = tables.Where(t => t.TeamId == a.AwayId).ToList(),
											   StartTime = a.StartTime.ToString("dd.MM.HH:mm"),
											   MatchPlayed = matchPlayed.MatchesPlayed,
											   HomeMatches = getMatches(matches, a.HomeId, true),
											   AwayMatches = getMatches(matches, a.AwayId, false),
											   Goals = getResult(matches, a.HomeId, a.AwayId, round.EventGroupName),
										   }).ToList();
						model.AddRange(match);
					}
				}

				model = model.Where(m => (double)(m.TotalGoals + m.Average) > 6.5).ToList();
				return Ok(model);
			}
		}

		#region private methods
		private List<MatchModel> getMatches(List<StatisticsMatch> matches, int teamId)
		{
			var model = matches.Where(m => (m.HomeId == teamId || m.AwayId == teamId) &&
										   m.Finished == true).Select(m => new MatchModel()
										   {
											   AwayID = m.AwayId,
											   AwayGoals = m.AwayPoints,
											   AwayName = m.AwayName,
											   HomeID = m.HomeId,
											   HomeGoals = m.HomePoints,
											   HomeName = m.HomeName,
											   StartTime = m.StartTime
										   }).OrderBy(m => m.StartTime).ToList();
			return model;
		}

		private List<MatchModel> getMatches(List<StatisticsMatch> matches, int teamId, bool isHome)
		{
			var model = matches.Where(m => (isHome ? m.HomeId == teamId : m.AwayId == teamId) &&
										   m.Finished == true).Select(m => new MatchModel()
										   {
											   AwayID = m.AwayId,
											   AwayGoals = m.AwayPoints,
											   AwayName = m.AwayName,
											   HomeID = m.HomeId,
											   HomeGoals = m.HomePoints,
											   HomeName = m.HomeName,
											   StartTime = m.StartTime
										   }).OrderBy(m => m.StartTime).ToList();
			return model;
		}

		private int getResult(List<StatisticsMatch> matches, int homeId, int awayId, string eventGroupName)
		{
			var model = matches.FirstOrDefault(m => (m.HomeId == homeId && m.AwayId == awayId) &&
										   m.Finished == true &&
										   m.EventGroupName == eventGroupName);

			return model.HomePoints + model.AwayPoints;
		}

		public async Task<GoalsModel> CalculateGoalsStats(Int64 aoLeague, Int32 aoTeam)
		{
			var loModel = new GoalsModel();
			var loEntities = new StatisticsContext();

			var loMatches = await (from m in loEntities.StatisticsMatches
								   where m.CompentitionId == aoLeague &&
										 (m.HomeId == aoTeam || m.AwayId == aoTeam) &&
										 m.Finished == true
								   orderby m.StartTime
								   select new MatchModel
								   {
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

			return loModel;
		}

		#endregion
	}
}
