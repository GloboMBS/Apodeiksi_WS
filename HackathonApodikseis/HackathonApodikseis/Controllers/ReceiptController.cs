using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApodikseis.Models;

namespace HackathonApodikseis.Controllers
{
    public class ReceiptController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public List<Receipt> GetReceipts(int userid, int langid)
        {
            List<Receipt> receiptResponse = new List<Receipt>();
            dbTransaction _dbActions = new dbTransaction();
            receiptResponse = _dbActions.getAllReceipts(userid, langid);

            return receiptResponse;
        }            

    }
}
