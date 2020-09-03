namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("urunler")]
    public partial class urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urunler()
        {
            faturas = new HashSet<fatura>();
            Favorilerims = new HashSet<Favorilerim>();
            Sepets = new HashSet<Sepet>();
            siparis = new HashSet<sipari>();
            urun_kampanya = new HashSet<urun_kampanya>();
        }

        [Key]
      
        public int urun_id { get; set; }

        [StringLength(50)]
        public string urun_adı { get; set; }

        public int? kategori_id { get; set; }

        public int? renk_id { get; set; }

        public int? marka_id { get; set; }

        public int? miktar { get; set; }

        [StringLength(250)]
        public string ResimURL { get; set; }

        public string aciklama { get; set; }

        public int? fiyat { get; set; }

        [StringLength(250)]
        public string ResimURL1 { get; set; }

        [StringLength(250)]
        public string ResimURL2 { get; set; }

        [StringLength(250)]
        public string ResimURL3 { get; set; }

        public int? Tedarikci_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fatura> faturas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorilerim> Favorilerims { get; set; }

        public virtual kategori kategori { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual marka marka { get; set; }

        public virtual renk renk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sipari> siparis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<urun_kampanya> urun_kampanya { get; set; }
    }
}
