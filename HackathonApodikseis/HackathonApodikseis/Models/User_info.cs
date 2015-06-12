using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HackathonApodikseis.Models
{
    public class User_info
    {
        public int id { get; set; }

        [StringLength(50)]
        public string fname { get; set; }

        [StringLength(50)]
        public string lname { get; set; }

        public DateTime? dob { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        public int? postcode { get; set; }

        public string afm { get; set; }
                
        public int? points { get; set; }
    }
}