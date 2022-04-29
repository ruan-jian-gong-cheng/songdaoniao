namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EvaluationForm")]
    public partial class EvaluationForm
    {
        [Key]
        [StringLength(30)]
        public string RunnerID { get; set; }

        [Required]
        [StringLength(30)]
        public string RunnerName { get; set; }

        [Required]
        [StringLength(30)]
        public string CardNumber { get; set; }

        [StringLength(10)]
        public string Summary { get; set; }

        [StringLength(10)]
        public string Positive { get; set; }

        [StringLength(10)]
        public string Negative { get; set; }

        public virtual account account { get; set; }
    }
}
