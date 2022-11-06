namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rounds
    {
        [Key]
        public int id_round { get; set; }

        public int round_number { get; set; }

        public int round_id_team { get; set; }

        public int round_scored { get; set; }

        public int round_conceded { get; set; }

        public virtual teams teams { get; set; }
    }
}
