using System;
using System.Collections.Generic;
using System.Text;
using Entiti.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StatisticsService.Parser {
	public class MatchParser : Parser<StatisticsMatches> {
		public override void Parse(string json) {
			try {
				var loObjects = JsonConvert.DeserializeObject<JObject>(json)["response"];
				foreach (var obj in loObjects.Children()) {
					var match = new StatisticsMatches() {
						MatchId = obj.Value<String>("id"),
						SportName = obj.Value<String>("sport"),
						StartTime = obj.Value<DateTime>("start_time"),
						SeasonName = obj.Value<String>("season_name"),
						CompentitionId = obj.Value<Int32?>("competition_id"),
						EventGroupName = obj.Value<String>("event_group_name"),
						HomeId = obj.Value<Int32>("home_id"),
						HomeName = obj.Value<String>("home_name"),
						AwayId = obj.Value<Int32>("away_id"),
						AwayName = obj.Value<String>("away_name"),
						HomePoints = obj.Value<Int32>("home_points"),
						AwayPoints = obj.Value<Int32>("away_points"),
						HasWinner = obj.Value<Boolean>("has_winner"),
						Winner = obj.Value<Int32>("winner"),
						ExtraTime = obj.Value<Int32>("extra_time"),
						ExtraTimeHomePoints = obj.Value<Int32>("extra_time_home_points"),
						ExtraTimeAwayPoints = obj.Value<Int32>("extra_time_away_points"),
						Statistics = obj.Value<Int32>("statistics"),
						Finished = obj.Value<bool>("finished"),
						DateCreated = DateTime.Now
					};
					Records.Add(match);
				}
			} catch (Exception e) {
				//Log.Error(e.Message);
				//Log.Error(e.StackTrace);
			}
		}
	}
}
