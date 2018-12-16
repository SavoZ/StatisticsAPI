using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    [Table("Statistics.Seasons")]
    public partial class StatisticsSeason
    {
        [Key]
        [Column("RecordID")]
        public long RecordId { get; set; }
        [Column("SportID")]
        public int SportId { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Column("CompentitionID")]
        public int CompentitionId { get; set; }
        [Required]
        [StringLength(255)]
        public string CompentitionName { get; set; }
        [Required]
        [StringLength(512)]
        public string SeasonName { get; set; }
        [Column("WinerID")]
        public int WinerId { get; set; }
        [Required]
        [StringLength(255)]
        public string WinerName { get; set; }
        public bool HasTable { get; set; }
        public int Rivals { get; set; }
        public int Events { get; set; }
        public bool Finished { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
    }
}
