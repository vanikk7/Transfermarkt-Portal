namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(255)]
        public string user_login { get; set; }

        [Required]
        [StringLength(255)]
        public string user_password { get; set; }

        public bool user_is_admin { get; set; }
    }
}
