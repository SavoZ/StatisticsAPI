using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    [Table("Statistics.Matches")]
    public partial class StatisticsMatch
    {
        [Key]
        [Column("RecordID")]
        public long RecordId { get; set; }
        [Required]
        [Column("MatchID")]
        [StringLength(150)]
        public string MatchId { get; set; }
        [Required]
        [StringLength(255)]
        public string SportName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }
        [Required]
        [StringLength(255)]
        public string SeasonName { get; set; }
        [Column("CompentitionID")]
        public int? CompentitionId { get; set; }
        [Required]
        [StringLength(255)]
        public string EventGroupName { get; set; }
        [Column("HomeID")]
        public int HomeId { get; set; }
        [Required]
        [StringLength(255)]
        public string HomeName { get; set; }
        [Column("AwayID")]
        public int AwayId { get; set; }
        [Required]
        [StringLength(255)]
        public string AwayName { get; set; }
        public int HomePoints { get; set; }
        public int AwayPoints { get; set; }
        public bool HasWinner { get; set; }
        public int Winner { get; set; }
        public int ExtraTime { get; set; }
        public int ExtraTimeHomePoints { get; set; }
        public int ExtraTimeAwayPoints { get; set; }
        public int Statistics { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
        public bool? Finished { get; set; }
    }
}
