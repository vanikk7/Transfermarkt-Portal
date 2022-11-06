namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class players
    {
        [Key]
        public int id_player { get; set; }

        [Required]
        [StringLength(255)]
        public string player_name { get; set; }

        public int player_number { get; set; }

        public int player_id_team { get; set; }

        public double player_value { get; set; }

        [Column(TypeName = "date")]
        public DateTime player_birth_date { get; set; }

        [Required]
        [StringLength(255)]
        public string player_position { get; set; }

        public int player_height { get; set; }

        public int player_id_national_team { get; set; }

        public virtual countries countries { get; set; }

        public virtual teams teams { get; set; }
    }
}
