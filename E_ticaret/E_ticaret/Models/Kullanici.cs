namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Adres = new HashSet<Adre>();
            Favorilerims = new HashSet<Favorilerim>();
            odemes = new HashSet<odeme>();
            Sepets = new HashSet<Sepet>();
            urunlers = new HashSet<urunler>();
        }

        [Key]
      
        public int Kullanici_id { get; set; }

        [StringLength(50)]
        public string Kullanici_adi { get; set; }

        [StringLength(50)]
        public string kullanici_soyadi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? kayit_tarih { get; set; }

        [StringLength(10)]
        public string parola { get; set; }

        [Required]
        [StringLength(50)]
        public string Eposta { get; set; }

        [StringLength(10)]
        public string Rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adre> Adres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorilerim> Favorilerims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<odeme> odemes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<urunler> urunlers { get; set; }
    }
}
