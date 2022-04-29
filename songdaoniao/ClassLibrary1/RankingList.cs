namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RankingList")]
    public partial class RankingList
    {
        [Key]
        [StringLength(30)]
        public string RunnerID { get; set; }

        [Required]
        [StringLength(30)]
        public string RunnerName { get; set; }

        public int? Ranking { get; set; }

        [StringLength(10)]
        public string TipSum { get; set; }
    }
}
