using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace BinaryTree
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
       
        public List<MemberFamily> GetChartData()
        {
            string query = "SELECT MemberId, Name, ParentId";
            query += " FROM FamilyHierarchy";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["str"]))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    List<MemberFamily> chartData = new List<MemberFamily>();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new MemberFamily() { 
                                MemberId = Convert.ToInt32(sdr["MemberId"]), 
                                Name = sdr["Name"].ToString(), 
                                ParentId = (Convert.IsDBNull(sdr["ParentId"])? null : (int?)Convert.ToInt32(sdr["ParentId"])
                                ) 
                            });
                        }
                    }
                    con.Close();
                    return chartData;

                }
            }
        }


        [WebMethod]
        public List<object> GetChartData_obj()
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
    }




    public class MemberFamily
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
