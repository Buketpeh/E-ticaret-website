namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class urun_kampanya
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int u_k_id { get; set; }

        public int? urun_id { get; set; }

        public int? kampanya { get; set; }

        public virtual kampanya kampanya1 { get; set; }

        public virtual urunler urunler { get; set; }
    }
}
