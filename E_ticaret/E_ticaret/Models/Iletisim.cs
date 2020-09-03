namespace E_ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Iletisim")]
    public partial class Iletisim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Iletisim_id { get; set; }

        public string Adres { get; set; }

        [StringLength(10)]
        public string Telefon { get; set; }

        [StringLength(10)]
        public string fax { get; set; }

        [StringLength(10)]
        public string Whatsapp { get; set; }
    }
}
