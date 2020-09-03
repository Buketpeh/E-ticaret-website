namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fatura")]
    public partial class fatura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fatura_id { get; set; }

        public int? siparis_id { get; set; }

        public int? urun_id { get; set; }

        public int? urun_fiyat { get; set; }

        public int? kdv { get; set; }

        public int? toplam_fiyat { get; set; }

        public virtual sipari sipari { get; set; }

        public virtual urunler urunler { get; set; }
    }
}
