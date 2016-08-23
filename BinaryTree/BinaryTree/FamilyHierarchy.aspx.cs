using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace BinaryTree
{


    public partial class FamilyHierarchy : System.Web.UI.Page
    {
        [WebMethod]
        public static List<object> GetChartData()
        {
            string query = "SELECT MemberId, Name, ParentId";
            query += " FROM FamilyHierarchy";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["str"]))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    List<object> chartData = new List<object>();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                        {
                            sdr["MemberId"], sdr["Name"], sdr["ParentId"]
                        });
                        }
                    }
                    con.Close();
                    return chartData;

                }
            }
        }


        //[WebMethod]
        //public static List<MemberFamily> GetChartData2()
        //{
        //    string query = "SELECT MemberId, Name, ParentId";
        //    query += " FROM FamilyHierarchy";

        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["str"]))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            List<MemberFamily> chartData = new List<MemberFamily>();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    chartData.Add(new MemberFamily() { MemberId = Convert.ToInt32(sdr["MemberId"]), Name = sdr["Name"].ToString(), ParentId = Convert.ToInt32(sdr["ParentId"]) });
        //                }
        //            }
        //            con.Close();
        //            return chartData;

        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            //var lst = GetChartData();

            //this.Response.Write(lst.Count.ToString());
        }




        [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}