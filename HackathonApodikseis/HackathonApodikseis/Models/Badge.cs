namespace WebApiApodikseis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Badge
    {
        public int id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string description { get; set; }
        
        [StringLength(50)]
        public string photourl { get; set; }

        public int? points { get; set; }

        public int languageid { get; set; }
        public bool achieved { get; set; }
    }
}
