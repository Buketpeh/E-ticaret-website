namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sipari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sipari()
        {
            faturas = new HashSet<fatura>();
        }

        [Key]
        public int siparis_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? siparis_talep_tarih { get; set; }

        public int? urun_id { get; set; }

        public int? kargo_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? cikis_tarih { get; set; }

        [Column(TypeName = "date")]
        public DateTime? teslim_tarih { get; set; }

        public int? kargo_ucret { get; set; }

        public int? odeme_id { get; set; }

        public int? adres_id { get; set; }

        public virtual Adre Adre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fatura> faturas { get; set; }

        public virtual kargo kargo { get; set; }

        public virtual odeme odeme { get; set; }

        public virtual urunler urunler { get; set; }
    }
}
