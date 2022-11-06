namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [Key]
        public int id_news { get; set; }

        [Required]
        [StringLength(255)]
        public string news_name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string news_text { get; set; }
    }
}
