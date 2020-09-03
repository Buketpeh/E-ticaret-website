namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kargo")]
    public partial class kargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kargo()
        {
            siparis = new HashSet<sipari>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kargo_id { get; set; }

        [StringLength(50)]
        public string firma { get; set; }

        public string aciklama { get; set; }

        public int? telefon { get; set; }

        [StringLength(50)]
        public string website { get; set; }

        [StringLength(50)]
        public string e_posta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sipari> siparis { get; set; }
    }
}
