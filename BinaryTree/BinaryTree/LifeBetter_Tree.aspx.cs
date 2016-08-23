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
    public partial class LifeBetter_Tree : System.Web.UI.Page
    {


        [WebMethod]
        public static List<object> GetChartData(string ma_cay)
        {
            // ko nhap ma_cay vao textbox thi mac dinh la root
            if (string.IsNullOrEmpty(ma_cay)) ma_cay = "0";
            // bo luon luon hien thi root cua ma_cay dang tim kiem
            object ma_cay_tt;

            //string query = "SELECT ID";
            //query += ", MA_KH";
            //query += ", MA_CAY";
            //query += ", MA_BAO_TRO";
            //query += ", TEN";
            //query += ", MA_BAO_TRO_TT";
            //query += ", MA_CAY_TT";
            //query += ", NHANH_CAY_TT";
            //query += ", NGAY_THAM_GIA";
            //query += ", TRANG_THAI";
            //query += ", MA_GOI_DAU_TU";
            //query += ", MA_DANH_HIEU";
            //query += " FROM MEMBERS";
            //query += " WHERE MA_CAY ='" + ma_cay + "' OR MA_CAY_TT like '" + ma_cay + "%'";
            //query += " ORDER BY NHANH_CAY_TT";

            string query = get_Chart_Data(ma_cay);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["LifeBetter"]))
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
                            if (sdr["MA_CAY"].ToString() == ma_cay) ma_cay_tt = null; else ma_cay_tt = sdr["MA_CAY_TT"];

                            chartData.Add(new object[]
                            {
                                sdr["ID"], sdr["MA_KH"], sdr["MA_CAY"]
                                ,sdr["MA_BAO_TRO"], sdr["TEN"], sdr["MA_BAO_TRO_TT"]
                                ,ma_cay_tt
                                ,sdr["NHANH_CAY_TT"], sdr["NGAY_THAM_GIA"]
                                ,sdr["TRANG_THAI"], sdr["MA_GOI_DAU_TU"], sdr["MA_DANH_HIEU"]
                            });
                        }
                    }
                    con.Close();           

                    return chartData;

                }
            }            
        }

        public static List<object> get_List_Node_Miss(string ma_cay)
        {
            string query = "select ma_cay, ma_cay_tt,nhanh_cay_tt ";
            query += "from members ";
            query += "where ";
            query += "(ma_cay='" + ma_cay + "' or ma_cay_tt like '"  + ma_cay + "%') ";
            query += "and ma_cay_tt in (";
            query += "select a.ma_cay_tt ";
            query += "from ";
            query += "(";
            query += "select count(*) col_no, ma_cay_tt ";
            query += "from MEMBERS ";
            query += "where ma_cay <> 0 ";
            query += "group by ma_cay_tt ";
            query += "having count(*) < 2";
            query += ") a";
            query += ")";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["LifeBetter"]))
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
                            var _ma_cay_tt = sdr["ma_cay_tt"];
                            var _nhanh = sdr["nhanh_cay_tt"];
                            var _miss_Node = "";

                            if (Convert.ToInt32(_nhanh) == 1)
                            {
                                _miss_Node = _ma_cay_tt + "02";
                            }
                            else
                            {
                                _miss_Node = _ma_cay_tt + "01";
                            }

                            chartData.Add(new object[]
                            {
                                null, null, _miss_Node
                                ,null,"Trống", null
                                ,_ma_cay_tt
                                ,Convert.ToInt32(_nhanh) > 1 ? 1 : 2, null
                                ,null,0,null
                            });
                        }
                    }
                    con.Close();
                    return chartData;

                }
            }
        }

        public static string get_Chart_Data(string ma_cay)
        {
            string query = "select * from (";
            query += "SELECT ID";
            query += ", MA_KH";
            query += ", MA_CAY";
            query += ", MA_BAO_TRO";
            query += ", TEN";
            query += ", MA_BAO_TRO_TT";
            query += ", MA_CAY_TT";
            query += ", NHANH_CAY_TT";
            query += ", NGAY_THAM_GIA";
            query += ", TRANG_THAI";
            query += ", MA_GOI_DAU_TU";
            query += ", MA_DANH_HIEU";
            query += " FROM MEMBERS";
            query += " WHERE MA_CAY ='" + ma_cay + "' OR MA_CAY_TT like '" + ma_cay + "%'";
            

            query += " UNION ";

            query += "select null ID ";
            query += ",null MA_KH";
            query += ",case NHANH_CAY_TT when 1 then MA_CAY_TT + '02' else MA_CAY_TT + '01' end MA_CAY";
            query += ",null MA_BAO_TRO";
            query += ",N'Trống' TEN";
            query += ",null MA_BAO_TRO_TT";
            query += ",MA_CAY_TT";
            query += ",case NHANH_CAY_TT when 1 then 2 else 1 end NHANH_CAY_TT";
            query += ",null NGAY_THAM_GIA";
            query += ",null TRANG_THAI";
            query += ",0 MA_GOI_DAU_TU";
            query += ",null MA_DANH_HIEU ";
            query += "from members ";
            query += "where ";
            query += "(ma_cay='" + ma_cay + "' or ma_cay_tt like '" + ma_cay + "%') ";
            query += "and ma_cay_tt in (";
            query += "select a.ma_cay_tt ";
            query += "from ";
            query += "(";
            query += "select count(*) col_no, ma_cay_tt ";
            query += "from MEMBERS ";
            query += "where ma_cay <> 0 ";
            query += "group by ma_cay_tt ";
            query += "having count(*) < 2";
            query += ") a";
            query += ")";
            query += ") k";
            query += " ORDER BY NHANH_CAY_TT";

            return query;
        }
    }
}