namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ana_kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ana_kategori()
        {
            kategoris = new HashSet<kategori>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int a_kat_id { get; set; }

        [StringLength(50)]
        public string a_kat_adi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kategori> kategoris { get; set; }
    }
}
