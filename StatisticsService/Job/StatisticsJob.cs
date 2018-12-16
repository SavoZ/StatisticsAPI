using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quartz;
using StatisticsDataBase.DB;
using StatisticsService.DB;
using StatisticsService.Parser;

namespace StatisticsService.Job {
	public class StatisticsJob : IJob {
		public Task Execute(IJobExecutionContext context) {
			return GetStats();
		}
		public async Task GetStats() {
			try {
				//BaseLogClass.Instance.InfoMessage("Started");
				var matchesParser = new MatchParser();
				var tablesParser = new TableParser();

				var loLeagues =  getStatisticsLeagues();

				var num = 0;
				foreach (var league in loLeagues) {
					try {
						var sWatch = Stopwatch.StartNew();
						sWatch.Start();
						var tParser = new TableParser();
						var mParser = new MatchParser();
						var t = GetTable(league.LeagueId);
						var m = GetMatches(league.LeagueId);
						tParser.Parse(t);
						mParser.Parse(m);
						new DBHelper().UpdateTable(tParser.Records);
						new DBHelper().UpdateMatches(mParser.Records);
						sWatch.Stop();
						//BaseLogClass.Instance.InfoMessage($"Finish - LeagueID: {tParser.Records.First().CompetitionID,4} | {sWatch.Elapsed} - {tParser.Records.First().SeasonName}");
						Console.WriteLine($"{tParser.Records.First().SeasonName} - {++num} - {sWatch.Elapsed} - league ID: {tParser.Records.First().CompetitionId}");
					} catch (Exception ex) {
						//BaseLogClass.Instance.ErrorMessage(ex.Message);
						//BaseLogClass.Instance.ErrorMessage($"Grabing data for league: {league.ID} - {league.Name} was unsuccessfull");
						Console.WriteLine($"Grabing data for league: {league.LeagueId} - {league.LeagueName} was unsuccessfull");
						if (ex.InnerException != null) {
							//BaseLogClass.Instance.FatalErrorMessage(ex.InnerException.Message);
							//BaseLogClass.Instance.FatalErrorMessage(ex.InnerException.StackTrace);
						}
					}
				}
				//BaseLogClass.Instance.InfoMessage($"Total leagues updated: {num}");
				Console.WriteLine(num);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				//BaseLogClass.Instance.ErrorMessage(ex.Message);
				//BaseLogClass.Instance.ErrorMessage(ex.StackTrace);
				if (ex.InnerException != null) {
					//BaseLogClass.Instance.FatalErrorMessage(ex.InnerException.Message);
					//BaseLogClass.Instance.FatalErrorMessage(ex.InnerException.StackTrace);
				}
			}

		}

		#region getStatisticsLeagues()
		private List<League> getStatisticsLeagues() {
			using (var db = new StatisticsContext()) {
				return db.Leagues.OrderBy(l => l.LeagueId).ToList();
			}
		}
		#endregion

		#region private HttpWebRequest CreateRequest(Object content)
		private HttpWebRequest CreateRequest(Object content) {
			var httpRequest = (HttpWebRequest) WebRequest.Create(Config.StatsConstants["URL"]);
			httpRequest.ContentType = Config.StatsConstants["CONTENT_TYPE"];
			httpRequest.Method = Config.StatsConstants["POST"];

			var jsonContent = JsonConvert.SerializeObject(content);

			using (var stream = new StreamWriter(httpRequest.GetRequestStream())) {
				stream.Write(jsonContent);
				stream.Flush();
				stream.Close();
			}

			return httpRequest;
		}
		#endregion

		#region private String GetResponse(HttpWebRequest request)
		private String GetResponse(HttpWebRequest request) {
			var httpResponse = (HttpWebResponse) request.GetResponse();
			var result = String.Empty;

			using (var stream = new StreamReader(httpResponse.GetResponseStream())) {
				result = stream.ReadToEnd();
			}

			return result;
		}
		#endregion

		#region public String GetSports()
		/// <summary>
		/// Returns all sports
		/// </summary>
		/// <returns>Returns JSON string</returns>
		public String GetSports() {
			var loContent = new { type = "sports" };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetCountries(Int32 aoSport)
		/// <summary>
		/// returns countries per sport
		/// </summary>
		/// <param name="aoSport">Used to indicate sport ID</param>
		/// <returns></returns>
		public String GetCountries(Int32 aoSport) {
			var loContent = new { type = "countries", sport = aoSport };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetCountries(String aoOrder = "asc", Int32 aoLimit = 100)
		/// <summary>
		/// Returns countries
		/// </summary>
		/// <param name="aoOrder">Used to indicate order in which countries will be returned</param>
		/// <param name="aoLimit">Used to indicate number of countries which will be returned</param>
		/// <returns></returns>
		public String GetCountries(String aoOrder = "asc", Int32 aoLimit = 100) {
			var loContent = new { type = "countries", order = aoOrder, limit = aoLimit };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetCountries(Int32 aoSport, String aoOrder = "asc")
		/// <summary>
		/// Returns countries per sport in specified order
		/// </summary>
		/// <param name="aoSport">Used to indicate sport ID</param>
		/// <param name="aoOrder">Used to indicate order in which countries will be returned</param>
		/// <returns></returns>
		public String GetCountries(Int32 aoSport, String aoOrder = "asc") {
			var loContent = new { type = "countries", sport = aoSport, aoOrder };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetCompetitions(String aoOrder = "asc")
		/// <summary>
		/// Returns all competitions
		/// </summary>
		/// <param name="aoOrder">Used to indicate order in which competitions will be returned</param>
		/// <returns></returns>
		public String GetCompetitions(String aoOrder = "asc") {
			var loContent = new { type = "competitions", order = aoOrder };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetCompetitions(Int32 aoCountry, Int32 aoSport, String aoOrder = "asc", Int32 aoLimit = 100)
		/// <summary>
		/// Returnes competitions based on country and sport
		/// </summary>
		/// <param name="aoCountry">Used to indicate country ID</param>
		/// <param name="aoSport">Used to indicate sport ID</param>
		/// <param name="aoOrder">Used to indicate order in which competitions will be returned</param>
		/// <param name="aoLimit">Used to indicate number of competitions which will be returned</param>
		/// <returns></returns>
		public String GetCompetitions(Int32 aoCountry, Int32 aoSport, String aoOrder = "asc", Int32 aoLimit = 100) {
			var loContent = new { type = "competitions", country = aoCountry, sport = aoSport, order = aoOrder, limit = aoLimit };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetSeasons(Int32 aoCountry, Int32 aoSport, Int32 aoOffset, Int32 aoLimit = 100)
		/// <summary>
		/// Returns all seasons based on country, sport and offset
		/// </summary>
		/// <param name="aoCountry">Used to indicate country ID</param>
		/// <param name="aoSport">Used to indicate sport ID</param>
		/// <param name="aoOffset">Used to indicate offset</param>
		/// <param name="aoLimit">Used to indicate number of seasons which will be returned</param>
		/// <returns></returns>
		public String GetSeasons(Int32 aoCountry, Int32 aoSport, Int32 aoOffset, Int32 aoLimit = 100, String order = "desc") {
			var loContent = new { type = "seasons", county = aoCountry, sport = aoSport, offset = aoOffset, limit = aoLimit, order = "desc" };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetTable(Int32 aoCompetition, String aoSeason, String aoOrder = "asc")
		/// <summary>
		/// Returns standings for competition
		/// </summary>
		/// <param name="aoCompetition">Used to indicate competition ID</param>
		/// <param name="aoSeason">Used to indicate season name</param>
		/// <param name="aoOrder">Used to indicate order in which seasons will be returned</param>
		/// <returns></returns>
		public String GetTable(Int32 aoCompetition, String aoSeason, String aoOrder = "asc") {
			var loContent = new { type = "tables", competition = aoCompetition, season = aoSeason, order = aoOrder };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetTable(Int64 aoCompetition)
		/// <summary>
		/// Returns current season table based on forwarded competition ID
		/// </summary>
		/// <param name="aoCompetition">Competition ID</param>
		/// <returns></returns>
		public String GetTable(Int64 aoCompetition) {
			dynamic loContent = new { type = "tables", competition = aoCompetition, last = true, order = "asc" };

			if (aoCompetition == 295)
				loContent = new { type = "tables", competition = aoCompetition, last = true, order = "asc", special_search = "final tournament" };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetMatches(Int64 aoCompetition)
		/// <summary>
		/// Returns current season matches based on forwarded competition ID
		/// </summary>
		/// <param name="aoCompetition">Used to indicate in which competition matches will be returned</param>
		/// <returns></returns>
		public String GetMatches(Int64 aoCompetition) {
			dynamic loContent = new { type = "matches", competition = aoCompetition, last = true, order = "asc" };

			if (aoCompetition == 295)
				loContent = new { type = "matches", competition = aoCompetition, last = true, order = "asc", played = 30 };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetMatches(Int32 aoCompetition, String aoOrder = "asc", Int32 aoLimit = 100)
		/// <summary>
		/// Returns all matches for competition
		/// </summary>
		/// <param name="aoCompetition">Used to indicate competition ID</param>
		/// <param name="aoOrder">Used to indicate order in which matches will be returned</param>
		/// <param name="aoLimit">Used to indicate number of matches which will be returned</param>
		/// <returns></returns>
		public String GetMatches(Int32 aoCompetition, String aoSeason = "asc", String aoOrder = "asc") {
			var loContent = new { type = "matches", competition = aoCompetition, season = aoSeason, order = aoOrder };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetMatches(String aoSeason, String aoOrder = "asc")
		/// <summary>
		/// Returns all matches for season
		/// </summary>
		/// <param name="aoSeason">Used to indicate season name</param>
		/// <param name="aoOrder">Used to indicate in which order matches will be returned</param>
		/// <returns></returns>
		public String GetMatches(String aoSeason, String aoOrder = "asc") {
			var loContent = new { type = "matches", season = aoSeason, order = aoOrder };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetMatches(Int32 aoHome, Int32 aoAway, String aoOrder = "desc", Int32 aoLimit = 6)
		/// <summary>
		/// Returns matches between two teams
		/// </summary>
		/// <param name="aoHome">Used to indicate home team ID</param>
		/// <param name="aoAway">Used to indicate away team ID</param>
		/// <param name="aoOrder">Used to indicate in which order matches will be returned</param>
		/// <param name="aoLimit">Used to indicate number of matches which will be returned</param>
		/// <returns></returns>
		public String GetMatches(Int32 aoHome, Int32 aoAway, String aoOrder = "desc", Int32 aoLimit = 6) {
			var loContent = new { type = "rivals", rival1 = aoHome, rivatl2 = aoAway, order = aoOrder, limit = aoLimit };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

		#region public String GetTeamMatches(Int32 aoTeam, String aoOrder = "desc", Int32 aoLimit = 6)
		/// <summary>
		/// Returns last matches for team
		/// </summary>
		/// <param name="aoTeam">Used to indicate team ID</param>
		/// <param name="aoOrder">Used to indicate in which order matches will be returned</param>
		/// <param name="aoLimit">Used to indicate number of matches which will be returned</param>
		/// <returns></returns>
		public String GetTeamMatches(Int32 aoTeam, String aoOrder = "desc", Int32 aoLimit = 6) {
			var loContent = new { type = "rivals", rival1 = aoTeam, order = aoOrder, limit = aoLimit };

			var loRequest = CreateRequest(loContent);
			return GetResponse(loRequest);
		}
		#endregion

	}
}
