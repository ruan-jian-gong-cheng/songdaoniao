namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("runner")]
    public partial class runner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public runner()
        {
            order = new HashSet<order>();
        }

        [StringLength(30)]
        public string RunnerID { get; set; }

        [Required]
        [StringLength(30)]
        public string CardNumber { get; set; }

        public int? Ranking { get; set; }

        [StringLength(10)]
        public string TipSum { get; set; }

        [StringLength(10)]
        public string Effective { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
    }
}
