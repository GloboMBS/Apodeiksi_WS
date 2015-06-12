namespace WebApiApodikseis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Complaint
    {
        public int id { get; set; }

        public int userid { get; set; }

        public string description { get; set; }

        public DateTime? date { get; set; }

    }
}
