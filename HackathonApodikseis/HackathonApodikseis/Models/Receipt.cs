namespace WebApiApodikseis.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Receipt
    {
        public int id { get; set; }

        public string afm { get; set; }

        public int receipt_no { get; set; }

        public DateTime? date_issued { get; set; }

        public double? amount { get; set; }

        public double? vat { get; set; }

        public int? ccn { get; set; }

        public int categoryid { get; set; }

        public int? user_registration_id { get; set; }

        public int? company_reg_id { get; set; }

        public int langid { get; set; }

    }
}
