namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trophies
    {
        [Key]
        public int id_trophy { get; set; }

        [Required]
        [StringLength(255)]
        public string trophy_name { get; set; }

        public int trophy_year { get; set; }

        public int trophy_id_team { get; set; }

        public virtual teams teams { get; set; }
    }
}
