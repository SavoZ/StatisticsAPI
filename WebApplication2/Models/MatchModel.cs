using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatisticsAPI.Models {
	public class MatchModel {
		public Int32 HomeID { get; set; }
		public Int32 AwayID { get; set; }
		public String HomeName { get; set; }
		public String AwayName { get; set; }
		public Int32 HomeGoals { get; set; }
		public Int32 AwayGoals { get; set; }
		public String Round { get; set; }
		public String Result { get { return $"{HomeGoals} - {AwayGoals}"; } }
		public DateTime StartTime { get; set; }
		public Boolean? Finished { get; set; }
		public DateTime? DateModified { get; set; }
	}
}
