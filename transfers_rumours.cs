namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class transfers_rumours
    {
        [Key]
        public int id_tr { get; set; }

        [Required]
        [StringLength(255)]
        public string tr_name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string tr_description { get; set; }
    }
}
