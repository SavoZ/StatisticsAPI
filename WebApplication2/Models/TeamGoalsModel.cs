using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatisticsAPI.Models {
	public class TeamGoalsModel  {
		public Int32 TotalGames { get; set; }
		public Int32 ZeroToTwoPercentage { get; set; }
		public Int32 ThreePlusPercentage { get; set; }
		public Int32 OneToThreeGoals { get; set; }
		public Int32 OneToThreeGoalsPercentage { get; set; }
		public Int32 TwoToThreeGoals { get; set; }
		public Int32 TwoToThreeGoalsPercentage { get; set; }
		public Int32 TwoToFourGoals { get; set; }
		public Int32 TwoToFourGoalsPercentage { get; set; }
		public int Position { get; internal set; }
		public string TeamName { get; internal set; }
		public int TeamID { get; internal set; }
		public Int32 ZeroTwoToFive { get; set; }
		public Int32 ZeroThreeToFive { get; set; }
	}
}
