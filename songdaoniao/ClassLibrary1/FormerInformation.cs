namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormerInformation")]
    public partial class FormerInformation
    {
        [Key]
        [StringLength(30)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string ClientName { get; set; }

        [StringLength(30)]
        public string PrimaryPhone { get; set; }

        [StringLength(50)]
        public string PrimaryAddress { get; set; }
    }
}
