namespace WebApiApodikseis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Category
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cat_name { get; set; }

        public string cat_desc { get; set; }

        public int languageid { get; set; }

    }
}
