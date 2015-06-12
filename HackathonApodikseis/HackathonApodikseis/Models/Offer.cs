namespace WebApiApodikseis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Offer
    {

        public int id { get; set; }
        public int categoryid { get; set; }
        public int companyid { get; set; }

        public string company_name { get; set; }

        public int? points_required { get; set; }
        
        public int languageid { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        public string description { get; set; }
        public string photourlList { get; set; }

        public bool achieved { get; set; }

        [StringLength(10)]
        public string photourl { get; set; }

    }
}
