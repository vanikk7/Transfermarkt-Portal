namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class teams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teams()
        {
            players = new HashSet<players>();
            rounds = new HashSet<rounds>();
            trophies = new HashSet<trophies>();
        }

        [Key]
        public int id_team { get; set; }

        [Required]
        [StringLength(255)]
        public string team_name { get; set; }

        public int team_id_league { get; set; }

        public double team_value { get; set; }

        [Required]
        [StringLength(255)]
        public string team_stadium { get; set; }

        public int team_league_points { get; set; }

        public int team_goals_diff { get; set; }

        public int team_games_played { get; set; }

        public virtual leagues leagues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<players> players { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rounds> rounds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trophies> trophies { get; set; }
    }
}
