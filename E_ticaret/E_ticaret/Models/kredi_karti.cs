namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class kredi_karti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kredi_karti()
        {
            odemes = new HashSet<odeme>();
        }

        [Key]
        public int kart_id { get; set; }

        public int? kullanici_id { get; set; }

        public int? kart_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? son_kullanma_tarih { get; set; }

        public int? cvv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<odeme> odemes { get; set; }
    }
}
