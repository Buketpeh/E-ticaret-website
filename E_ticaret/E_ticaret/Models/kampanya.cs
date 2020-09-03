namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kampanya")]
    public partial class kampanya
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kampanya_id { get; set; }

        [StringLength(50)]
        public string kampanya_adi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? baslangic_tarih { get; set; }

        [Column(TypeName = "date")]
        public DateTime? bitis_tarih { get; set; }

        public string aciklama { get; set; }

        public virtual urun_kampanya urun_kampanya { get; set; }
    }
}
