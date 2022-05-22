namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [Key]
        [StringLength(30)]
        public string OrderNumber { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        [Required]
        [StringLength(30)]
        public string ClientID { get; set; }

        
        [StringLength(30)]
        public string RunnerID { get; set; }

        [Required]
        [StringLength(30)]
        public string ClientPhone { get; set; }

        
        [StringLength(30)]
        public string RunnerPhone { get; set; }

        [StringLength(100)]
        public string Evaluate { get; set; }

        [StringLength(10)]
        public string Tip { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        public virtual client client { get; set; }

        public virtual runner runner { get; set; }
    }
}
