using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatisticsAPI.Models {
	public class DoubleChanceModel {
		public Int32 TotalGames { get; set; }
		public int Position { get; internal set; }
		public string TeamName { get; internal set; }
		public int TeamID { get; internal set; }
		public Int32 ZeroTwoToThreeGoals { get; set; }
		public Int32 ZeroTwoToFourGoals { get; set; }
		public Int32 GGThreePlusPercentage { get; set; }
		public Int32 GGorThreePlusPercentage { get; set; }
		public Int32 TwoTwoToFourGoals { get; set; }
		public Int32 TwoTwoToThreeGoals { get; set; }
		public Int32 NotTwoAndThreeGoals { get; set; }
		public Int32 NotTwoAndTwoGoals { get; set; }
		public string LeagueName { get; internal set; }
	}
}
