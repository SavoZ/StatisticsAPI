using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StatisticsDataBase.DB;

namespace StatisticsService.Parser {
	public class SeasonParser : Parser<StatisticsSeason> {
		public override void Parse(string json) {
			try {
				//Log.Info("Parsing Seasons - Started");
				var loObject = JsonConvert.DeserializeObject<JObject>(json)["response"];
				foreach (var obj in loObject.Children()) {
					var season = new StatisticsSeason() {
						SportId = obj.Value<Int32>("sport_id"),
						CountryId = obj.Value<Int32>("country_id"),
						CompentitionId = obj.Value<Int32>("competition_id"),
						CompentitionName = obj.Value<String>("competitions_name"),
						WinerId = obj.Value<Int32>("winner_id"),
						WinerName = obj.Value<String>("winner_name"),
						HasTable = obj.Value<Boolean>("has_table"),
						Rivals = obj.Value<Int32>("rivals"),
						Events = obj.Value<Int32>("events"),
						Finished = obj.Value<Boolean>("finished")
					};
					Records.Add(season);
				}
				//Log.Info("Parsing Seasons - Started");
			} catch (Exception e) {
				//Log.Error(e.Message);
				//Log.Error(e.StackTrace);
			}
		}
	}
}
