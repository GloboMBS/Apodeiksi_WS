namespace WebApiApodikseis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Company
    {

        public int id { get; set; }

        public string afm { get; set; }

        [StringLength(50)]
        public string company_name { get; set; }

        public int categoryid { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public int langid { get; set; }

    }
}
