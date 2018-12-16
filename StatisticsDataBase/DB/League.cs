using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatisticsDataBase.DB
{
    public partial class League
    {
        [Column("LeagueID")]
        public int LeagueId { get; set; }
        [Required]
        [StringLength(38)]
        public string LeagueName { get; set; }
    }
}
