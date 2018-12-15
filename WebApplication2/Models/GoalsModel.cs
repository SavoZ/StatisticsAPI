using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatisticsAPI.Models {
	public class GoalsModel {
		public Int32 ThreePlus { get; set; }
		public Int32 GG { get; set; }
		public Int32 TDG { get; set; }
		public Int32 FourPlusGoals { get; set; }
		public Double AvgGoalsPerMatch { get; set; }
		public Int32 NoDraw { get; set; }
	}
}
