using HackathonApodikseis.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiApodikseis.Models;
using HackathonApodikseis.Controllers;
using System.Data;

namespace HackathonApodikseis
{
    public class dbTransaction
    {
        public string connectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<Receipt> getAllReceipts(int uid, int lid)
        {
            List<Receipt> rs = new List<Receipt>();
            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string oString = "SELECT Receipts.id, Receipts.afm, Receipts.receipt_no, Receipts.date_issued, Receipts.amount, Receipts.vat, Receipts.ccn, Receipts.categoryid, Receipts.user_registration_id, Receipts.company_reg_id, Categories.cat_name " + 
                                 "FROM Receipts " +
                                 "INNER JOIN Categories ON Receipts.categoryid = Categories.id " +
                                 "WHERE user_registration_id = @user AND langid = @lang";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@user", uid);
                oCmd.Parameters.AddWithValue("@lang", lid);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var _tmpReceipt = new Receipt()
                        {
                            id = (int)oReader["id"],
                            afm = ((oReader["afm"] != DBNull.Value) ? (string)oReader["afm"] : String.Empty),
                            receipt_no = ((oReader["receipt_no"] != DBNull.Value) ? (int)oReader["receipt_no"] : 0),
                            date_issued = (DateTime)((oReader["date_issued"] == System.DBNull.Value) ? null : (oReader["date_issued"])),
                            amount = ((oReader["amount"] != DBNull.Value) ? (double)oReader["amount"] : 0),
                            vat = ((oReader["vat"] != DBNull.Value) ? (double)oReader["vat"] : 0),
                            ccn = ((oReader["ccn"] != DBNull.Value) ? (int)oReader["ccn"] : 0),
                            categoryid = (int)oReader["categoryid"],
                            user_registration_id = ((oReader["user_registration_id"] != DBNull.Value) ? (int)oReader["user_registration_id"] : 0),
                            company_reg_id = ((oReader["company_reg_id"] != DBNull.Value) ? (int)oReader["company_reg_id"] : 0)
                        };


                        rs.Add(_tmpReceipt);
                    }
                    myConnection.Close();
                }

                return rs;
            }
        }


        public User_info getUserInfo(int userid)
        {
            User_info user = new User_info();
            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string infoString = "SELECT * FROM User_info WHERE User_info.userid = @userinfoid";
                SqlCommand infoCmd = new SqlCommand(infoString, myConnection);
                infoCmd.Parameters.AddWithValue("@userinfoid", userid);
                myConnection.Open();
                using (SqlDataReader infoReader = infoCmd.ExecuteReader())
                {
                    while (infoReader.Read())
                    {
                        user.id = (int)infoReader["userid"];
                        user.fname = ((infoReader["fname"] != DBNull.Value) ? (string)infoReader["fname"] : String.Empty);
                        user.lname = ((infoReader["lname"] != DBNull.Value) ? (string)infoReader["lname"] : String.Empty);
                        user.dob = (DateTime)((infoReader["dob"] == System.DBNull.Value) ? null : (infoReader["dob"]));
                        user.gender = ((infoReader["gender"] != DBNull.Value) ? (string)infoReader["gender"] : String.Empty);
                        user.email = ((infoReader["email"] != DBNull.Value) ? (string)infoReader["email"] : String.Empty);
                        user.phone = ((infoReader["phone"] != DBNull.Value) ? (string)infoReader["phone"] : String.Empty);
                        user.country = ((infoReader["country"] != DBNull.Value) ? (string)infoReader["country"] : String.Empty);
                        user.city = ((infoReader["city"] != DBNull.Value) ? (string)infoReader["city"] : String.Empty);
                        user.address = ((infoReader["address"] != DBNull.Value) ? (string)infoReader["address"] : String.Empty);
                        user.postcode = ((infoReader["postcode"] != DBNull.Value) ? (int)infoReader["postcode"] : 0);
                        user.afm = ((infoReader["afm"] != DBNull.Value) ? (string)infoReader["afm"] : String.Empty);
                        user.points = ((infoReader["user_points"] != DBNull.Value) ? (int)infoReader["user_points"] : 0);

                    }
                    myConnection.Close();
                }
            }
            return user;
        }


        public int getusersTotal(int userid)
        {
            int totalPoints = 0;
            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string infoString = "SELECT * FROM User_info WHERE User_info.userid = @userinfoid";
                SqlCommand infoCmd = new SqlCommand(infoString, myConnection);
                infoCmd.Parameters.AddWithValue("@userinfoid", userid);
                myConnection.Open();
                using (SqlDataReader infoReader = infoCmd.ExecuteReader())
                {
                    while (infoReader.Read())
                    {
                        totalPoints = ((infoReader["user_points"] != DBNull.Value) ? (int)infoReader["user_points"] : 0);

                    }
                    myConnection.Close();
                }
            }
            return totalPoints;
        }


        public List<Category> getCategories()
        {
            List<Category> listCat = new List<Category>();
            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string infoString = "SELECT * FROM Categories";
                SqlCommand infoCmd = new SqlCommand(infoString, myConnection);
                myConnection.Open();
                using (SqlDataReader infoReader = infoCmd.ExecuteReader())
                {
                    while (infoReader.Read())
                    {
                        var _tmpCategory = new Category() 
                        {
                            cat_desc = ((infoReader["cat_desc"] != DBNull.Value) ? (string)infoReader["cat_desc"] : String.Empty),
                            cat_name = ((infoReader["cat_name"] != DBNull.Value) ? (string)infoReader["cat_name"] : String.Empty),
                            id = (int)infoReader["id"]
                        };

                        listCat.Add(_tmpCategory);

                    }
                    myConnection.Close();
                }
            }
            return listCat;
        }



        public List<Offer> getOffers(int userid, int langid)
        {
            int totalPoints = getusersTotal(userid);
            List<Offer> offerResponse = new List<Offer>();
            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string oString = "SELECT Offers.id, Offers.companyid, Offers.points_required, Companies.categoryid, Companies.company_name, Offer_details.title, Offer_details.description, Offer_details.photourl, Offer_details.photourlList " +
                                 "FROM Offers " +
                                 "INNER JOIN Companies ON Offers.companyid = Companies.id " +
                                 "INNER JOIN Offer_details ON Offers.id = Offer_details.offerid " +
                                 "WHERE Offers.isActive = 'true' AND Offer_details.languageid = @lang";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@lang", langid);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var _tmpOffer = new Offer()
                        {
                            id = (int)oReader["id"],
                            title = ((oReader["title"] != DBNull.Value) ? (string)oReader["title"] : String.Empty),
                            description = ((oReader["description"] != DBNull.Value) ? (string)oReader["description"] : String.Empty),
                            photourl = ((oReader["photourl"] != DBNull.Value) ? (string)oReader["photourl"] : String.Empty),
                            points_required = ((oReader["points_required"] != DBNull.Value) ? (int)oReader["points_required"] : 0),
                            companyid = (int)oReader["companyid"],
                            company_name = ((oReader["company_name"] != DBNull.Value) ? (string)oReader["company_name"] : String.Empty),
                            categoryid = (int)oReader["categoryid"],
                            photourlList = ((oReader["photourlList"] != DBNull.Value) ? (string)oReader["photourlList"] : String.Empty)
                        };

                        if (totalPoints >= _tmpOffer.points_required)
                        {
                            _tmpOffer.photourlList = _tmpOffer.photourlList + "_UNLOCKED.png";
                            _tmpOffer.achieved = true;
                        }
                        else
                        {
                            _tmpOffer.photourlList = _tmpOffer.photourlList + "_LOCKED.png";
                            _tmpOffer.achieved = false;
                        }

                        offerResponse.Add(_tmpOffer);
                    }
                    myConnection.Close();
                }
            }

            return offerResponse;
        }


        public List<Badge> GetBages(int userid, int langid)
        {
            List<Badge> badgeResponse = new List<Badge>();

            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {
                string oString = "SELECT Badges.id, Badges.title, Badges.descriptionbefore, Badges.descriptionafter, Badges.photourl,Badges.points,Badges.langid, User_info.user_points as totalpoints " +
                                 "FROM Badges " +
                                 "INNER JOIN user_badge on Badges.id = user_badge.badgeid "+
                                 "INNER JOIN Users on user_badge.userid = Users.id "+
                                 "INNER JOIN User_info on Users.id = User_info.userid "+
                                 "WHERE Users.id = @userid AND Badges.langid = @lang";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@userid", userid);
                oCmd.Parameters.AddWithValue("@lang", langid);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var _tmpBadge = new Badge()
                        {
                            id = (int)oReader["id"],
                            title = ((oReader["title"] != DBNull.Value) ? (string)oReader["title"] : String.Empty),                            
                            photourl = ((oReader["photourl"] != DBNull.Value) ? (string)oReader["photourl"] : String.Empty),
                            points = ((oReader["points"] != DBNull.Value) ? (int)oReader["points"] : 0)
                        };

                        var descBefore = ((oReader["descriptionbefore"] != DBNull.Value) ? (string)oReader["descriptionbefore"] : String.Empty);
                        var descAfter = ((oReader["descriptionafter"] != DBNull.Value) ? (string)oReader["descriptionafter"] : String.Empty);
                        var totalPoints = ((oReader["totalpoints"] != DBNull.Value) ? (int)oReader["totalpoints"] : 0);        
                                                
                        if (totalPoints >= _tmpBadge.points)
                        {
                            _tmpBadge.description = descAfter;
                            _tmpBadge.photourl = _tmpBadge.photourl + "_ON.png";
                            _tmpBadge.achieved = true;
                        }
                        else
                        {
                            _tmpBadge.description = descBefore;
                            _tmpBadge.photourl = _tmpBadge.photourl + "_OFF.png";
                            _tmpBadge.achieved = false;
                        }

                        badgeResponse.Add(_tmpBadge);
                    }
                    myConnection.Close();
                }
            }
            return badgeResponse;
        }

        public List<expense> getExpensesPerUser(int userid)
        {
            List<expense> allExpsenses = new List<expense>();

            using (SqlConnection myConnection = new SqlConnection(connectionString()))
            {         
                SqlCommand oCmd = new SqlCommand();
                //oCmd.Parameters.AddWithValue("@uid", userid);

                oCmd.CommandText = "getExpensesPerUser";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@userid",userid);
                oCmd.Connection = myConnection;

                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var _tmpExpe = new expense() {
                            catid = (int)oReader["categoryid"],
                            catamount = (double)oReader["catAmount"],
                            catdesc = ((oReader["cat_name"] != DBNull.Value) ? (string)oReader["cat_name"] : String.Empty)
                        };

                        allExpsenses.Add(_tmpExpe);
                    }
                    myConnection.Close();
                }
            }

            return allExpsenses;
        }
        
    }
}