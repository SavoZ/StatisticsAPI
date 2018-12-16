using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StatisticsDataBase.DB;

namespace StatisticsService.Parser {
	public class TableParser : Parser<StatisticsTable> {
		public override void Parse(string json) {
			try {
				var loObjects = JsonConvert.DeserializeObject<JObject>(json)["response"];
				foreach (var obj in loObjects.Children()) {
					var table = new StatisticsTable() {
						SeasonName = obj.Value<String>("season_name"),
						CompetitionId = obj.Value<Int32>("competition_id"),
						GroupName = obj.Value<String>("group_name"),
						TeamId = obj.Value<Int32>("rival_id"),
						TeamName = obj.Value<String>("rival_name"),
						MatchesPlayed = obj.Value<Int32>("matches_played"),
						Wins = obj.Value<Int32>("wins"),
						WinsOvertime = obj.Value<Int32>("wins_overtime"),
						Draws = obj.Value<Int32>("draws"),
						Losses = obj.Value<Int32>("losses"),
						LossesOvertime = obj.Value<Int32>("losses_overtime"),
						WinsPen = obj.Value<Int32>("wins_pen"),
						TotalGoalsScored = obj.Value<Int32>("total_goals_in"),
						TotalGoalsAgaints = obj.Value<Int32>("total_goals_out"),
						Position = obj.Value<Int32>("position"),
						Points = obj.Value<Int32>("points"),
						DateCreated = DateTime.Now,
						SeasonId = obj.Value<Int32>("api_season_id"),
					};
					Records.Add(table);
				}
			} catch (Exception e) {
				//Log.Error(e.Message);
				//Log.Error(e.StackTrace);
			}
		}
	}
}
