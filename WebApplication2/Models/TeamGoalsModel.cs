using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models {
	public class TeamGoalsModel  {
		public Int32 TotalGames { get; set; }
		public Int32 TotalGoals { get; set; }
		public Double GoalsPerMatch { get; set; }
		public Int32 ZeroToTwo { get; set; }
		public Int32 ZeroToTwoPercentage { get; set; }
		public Int32 ThreePlus { get; set; }
		public Int32 ThreePlusPercentage { get; set; }
		public Int32 ZeroGoals { get; set; }
		public Int32 OnePlusGoals { get; set; }
		public Int32 ZeroToOne { get; set; }
		public Int32 TwoPlusGoals { get; set; }
		public Int32 ZeroToThree { get; set; }
		public Int32 FourPlus { get; set; }
		public Int32 OneToTwoGoals { get; set; }
		public Int32 OneToThreeGoals { get; set; }
		public Int32 OneToThreeGoalsPercentage { get; set; }
		public Int32 TwoToThreeGoals { get; set; }
		public Int32 TwoToThreeGoalsPercentage { get; set; }
		public Int32 TwoToFourGoals { get; set; }
		public Int32 TwoToFourGoalsPercentage { get; set; }
		public int Position { get; internal set; }
		public string TeamName { get; internal set; }
		public int TeamID { get; internal set; }
		public Int32 ZeroTwoToThreeGoals { get; set; }
		public Int32 ZeroTwoToFourGoals { get; set; }
		public Int32 ZeroTwoToFive { get; set; }
		public Int32 ZeroThreeToFive { get; set; }
		public Int32 GGThreePlusPercentage { get; set; }

	}
}
