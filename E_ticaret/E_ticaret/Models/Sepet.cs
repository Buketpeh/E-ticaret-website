namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sepet")]
    public partial class Sepet
    {
        public int ID { get; set; }

        public int? KullaniciID { get; set; }

        public int? UrunID { get; set; }

        public decimal? AlisFiyati { get; set; }

        public decimal? Miktari { get; set; }

        public decimal? ToplamFiyati { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public DateTime? Saat { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual urunler urunler { get; set; }
    }
}
