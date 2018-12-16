using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StatisticsDataBase.DB;

namespace StatisticsService.Parser {
	public class CountriesParser : Parser<StatisticsCountry> {
		public override void Parse(string json) {
			try {
				//Log.Info("Parsing Countries - Started");
				var loObject = JsonConvert.DeserializeObject<JObject>(json)["response"];
				foreach (var obj in loObject.Children()) {
					var country = new StatisticsCountry() {
						SportId = obj.Value<Int32>("sport_id"),
						SportName = obj.Value<String>("sport"),
						CountryId = obj.Value<Int32>("country_id"),
						CountryName = obj.Value<String>("country_name"),
						DateCreated = DateTime.Now
					};
					Records.Add(country);
				}
				//Log.Info("Parsing Countries - Finished");
			} catch (Exception e) {
				//Log.Error(e.Message);
				//Log.Error(e.StackTrace);
			}
		}
	}
}
