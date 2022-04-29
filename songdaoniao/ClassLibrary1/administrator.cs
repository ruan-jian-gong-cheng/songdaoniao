namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("administrator")]
    public partial class administrator
    {
        [Key]
        [StringLength(30)]
        public string AdminID { get; set; }

        [Required]
        [StringLength(30)]
        public string AdminName { get; set; }
    }
}
