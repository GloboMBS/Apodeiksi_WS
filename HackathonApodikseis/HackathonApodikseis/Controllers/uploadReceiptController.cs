using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HackathonApodikseis.Controllers
{
    public class uploadReceiptController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public string uploadReceipt(int id)
        {
            
            return "OK " + id;
        }
        

    }
}
