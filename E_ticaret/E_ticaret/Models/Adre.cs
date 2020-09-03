namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adre()
        {
            siparis = new HashSet<sipari>();
        }

        [Key]
        public int adres_id { get; set; }

        public int? kullanici_id { get; set; }

        [StringLength(50)]
        public string ulke { get; set; }

        [StringLength(50)]
        public string sehir { get; set; }

        [StringLength(50)]
        public string mahllle { get; set; }

        [StringLength(50)]
        public string cadde { get; set; }

        [StringLength(50)]
        public string sokak { get; set; }

        public int? apt_no { get; set; }

        public int? daire_no { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sipari> siparis { get; set; }
    }
}
