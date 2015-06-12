using HackathonApodikseis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace HackathonApodikseis.Controllers
{
    public class LoginController : ApiController
    {
        public string connectionString()
        {    
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public LoginResponse UserLogin(string username, string password)
        {
            dbTransaction _dbActions = new dbTransaction();
            LoginResponse loginResponse = new LoginResponse();
            int res = 0;
            int userid = 0;

            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string oString = "SELECT count(*) as result, Users.id as userid FROM Users WHERE Users.username = @user AND Users.password = @pwd GROUP BY Users.id";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@user", username);
                oCmd.Parameters.AddWithValue("@pwd", password);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        res = (int)(oReader["result"]);
                        userid = (int)(oReader["userid"]);
                    }
                    myConnection.Close();
                }
            }
            if (res == 1)
            {
                loginResponse.success = true;
                loginResponse.userInfo = _dbActions.getUserInfo(userid);
            }
            else
            {
                loginResponse.success = false;
            }
            return loginResponse;

        }

              
        public class LoginResponse
        {
            public bool success { get; set; }
            public User_info userInfo { get; set; }
        }

    }
}
