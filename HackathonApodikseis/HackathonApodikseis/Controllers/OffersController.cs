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
    public class OffersController : ApiController
    {
        public string connectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public List<Offer> GetOffers(int userid, int langid)
        {
            List<Offer> offerResponse = new List<Offer>();
            dbTransaction _dbActions = new dbTransaction();

            offerResponse = _dbActions.getOffers(userid, langid);

            return offerResponse;
        }

    }
}
