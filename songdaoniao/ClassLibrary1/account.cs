namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            client = new HashSet<client>();
            EvaluationForm = new HashSet<EvaluationForm>();
            runner = new HashSet<runner>();
        }

        [Key]
        [StringLength(30)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(30)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(80)]
        public string Address { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string ApplyFor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluationForm> EvaluationForm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<runner> runner { get; set; }
    }
}
