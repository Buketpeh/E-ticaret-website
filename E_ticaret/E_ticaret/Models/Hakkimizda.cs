namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hakkimizda")]
    public partial class Hakkimizda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hakkimizda_id { get; set; }

        [StringLength(50)]
        public string Baslik { get; set; }

        public string Aciklama { get; set; }
    }
}
