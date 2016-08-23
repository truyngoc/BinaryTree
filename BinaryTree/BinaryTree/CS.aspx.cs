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

public partial class _Default : System.Web.UI.Page
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
}