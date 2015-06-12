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
    public class BadgesController : ApiController
    {
        public string connectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public List<Badge> getBages(int userid, int langid)
        {
            List<Badge> badgeResponse = new List<Badge>();
            dbTransaction _dbActions = new dbTransaction();

            badgeResponse = _dbActions.GetBages(userid, langid);

            return badgeResponse;

        }
        

    }
}
