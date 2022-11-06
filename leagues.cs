namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class leagues
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public leagues()
        {
            teams = new HashSet<teams>();
        }

        [Key]
        public int id_league { get; set; }

        [Required]
        [StringLength(255)]
        public string league_name { get; set; }

        [Required]
        [StringLength(255)]
        public string league_country { get; set; }

        public int league_value { get; set; }

        public int league_country_place { get; set; }

        public int league_teams_number { get; set; }

        public int? league_uefa_place { get; set; }

        public double? league_uefa_points { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teams> teams { get; set; }
    }
}
