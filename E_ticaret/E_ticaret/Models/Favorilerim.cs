namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorilerim")]
    public partial class Favorilerim
    {
        [Key]
       
        public int Favori_id { get; set; }

        public int? KullaniciID { get; set; }

        public int? UrunID { get; set; }

        public int? Fiyati { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual urunler urunler { get; set; }
    }
}
