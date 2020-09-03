namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class kart_
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int kart_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime son_kullanma_tarihi { get; set; }

        public int cvv { get; set; }
    }
}
