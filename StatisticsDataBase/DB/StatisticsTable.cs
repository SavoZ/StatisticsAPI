using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    [Table("Statistics.Tables")]
    public partial class StatisticsTable
    {
        [Key]
        [Column("RecordID")]
        public long RecordId { get; set; }
        [Required]
        [StringLength(255)]
        public string SeasonName { get; set; }
        [Column("CompetitionID")]
        public int CompetitionId { get; set; }
        [Required]
        [StringLength(255)]
        public string GroupName { get; set; }
        [Required]
        [StringLength(255)]
        public string TeamName { get; set; }
        [Column("TeamID")]
        public int TeamId { get; set; }
        public int Position { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int WinsOvertime { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int LossesOvertime { get; set; }
        public int WinsPen { get; set; }
        public int TotalGoalsScored { get; set; }
        public int TotalGoalsAgaints { get; set; }
        public int Points { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
        [Column("SeasonID")]
        public int SeasonId { get; set; }
    }
}
