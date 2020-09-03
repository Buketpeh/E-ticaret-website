namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("odeme")]
    public partial class odeme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public odeme()
        {
            siparis = new HashSet<sipari>();
        }

        [Key]
        public int odeme_id { get; set; }

        public int? odeme_secenek_id { get; set; }

        public int? kredi_karti_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? odeme_zamani { get; set; }

        public int? musteri_id { get; set; }

        public int tutar { get; set; }

        public virtual kredi_karti kredi_karti { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sipari> siparis { get; set; }
    }
}
