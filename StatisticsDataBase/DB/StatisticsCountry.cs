using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    [Table("Statistics.Countries")]
    public partial class StatisticsCountry
    {
        [Key]
        [Column("RecordID")]
        public long RecordId { get; set; }
        [Column("SportID")]
        public int SportId { get; set; }
        [Required]
        [StringLength(255)]
        public string SportName { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [StringLength(255)]
        public string CountryName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
    }
}
