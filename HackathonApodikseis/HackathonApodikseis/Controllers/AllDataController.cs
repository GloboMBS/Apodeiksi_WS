using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApodikseis.Models;

namespace HackathonApodikseis.Controllers
{
    public class AllDataController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public allData GetAllData(int userid, int langid)
        {
            allData allDataResp = new allData();

            dbTransaction _dbActions = new dbTransaction();

            allDataResp.UserTotal = _dbActions.getusersTotal(userid);
            allDataResp.allRec = _dbActions.getAllReceipts(userid,langid);
            allDataResp.allOff = _dbActions.getOffers(userid, langid);
            allDataResp.allBadg = _dbActions.GetBages(userid, langid);
            allDataResp.totalExpensesUser = _dbActions.getExpensesPerUser(userid);
            allDataResp.listOfCategories = _dbActions.getCategories();

            return allDataResp;
        }

        public class allData
        
        {
            public int UserTotal { get; set; }
            public List<Receipt> allRec { get; set; }
            public List<Offer> allOff { get; set; }
            public List<Badge> allBadg { get; set; }
            public List<expense> totalExpensesUser { get; set; }
            public List<Category> listOfCategories { get; set; }
        }


    }
}
