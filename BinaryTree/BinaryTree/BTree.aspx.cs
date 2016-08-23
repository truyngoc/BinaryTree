using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BinaryTree
{
    public partial class BTree : System.Web.UI.Page
    {
        string L = "0", R = "";
        ArrayList bk;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["str"]);
        SqlCommand cmd;
        SqlDataReader dr;
        string jointype, reduserid, redside;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                detail("100000");
                Lb1.Text = "100000";
                bk = new ArrayList();
                bk.Add(Lb1.Text);
                Session["temp"] = bk;
            }
        }


        protected void Lb1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string val = btn.Text;
            bk = ((ArrayList)Session["temp"]);
            bk.Add(val);
            Session["temp"] = bk;
            detail(btn.Text);
        }

        public void check()
        {
            Lb2L.Text = "Blank";
            Lb3R.Text = "Blank";
            Lb4L.Text = "Blank";
            Lb5R.Text = "Blank";
            Lb6L.Text = "Blank";
            Lb7R.Text = "Blank";
            Lb8L.Text = "Blank";
            Lb9R.Text = "Blank";
            Lb10L.Text = "Blank";
            Lb11R.Text = "Blank";
            Lb12L.Text = "Blank";
            Lb13R.Text = "Blank";
            Lb14L.Text = "Blank";
            Lb15R.Text = "Blank";
            i2.Src = "TreeImages/R.jpg";
            i3.Src = "TreeImages/R.jpg";
            i4.Src = "TreeImages/R.jpg";
            i5.Src = "TreeImages/R.jpg";
            i6.Src = "TreeImages/R.jpg";
            i7.Src = "TreeImages/R.jpg";
            i8.Src = "TreeImages/R.jpg";
            i9.Src = "TreeImages/R.jpg";
            i10.Src = "TreeImages/R.jpg";
            i11.Src = "TreeImages/R.jpg";
            i12.Src = "TreeImages/R.jpg";
            i13.Src = "TreeImages/R.jpg";
            i14.Src = "TreeImages/R.jpg";
            i15.Src = "TreeImages/R.jpg";
        }

        public void detail(string usr)
        {                        
            DataTable userD = new DataTable();
            TreeShow ss = new TreeShow();
            userD = ss.fillUserDetail(usr);
            if (userD.Rows.Count != 0)
            {
                Lb1.Text = usr;
                lblname.Text = userD.Rows[0]["name"].ToString();
                lblljoin.Text = userD.Rows[0]["ljoining"].ToString();
                lblrjoin.Text = userD.Rows[0]["rjoining"].ToString();
                lblpair.Text = userD.Rows[0]["pair"].ToString();
                string jointype = userD.Rows[0]["jointype"].ToString();
                if (jointype == "Paid")
                {
                    i1.Src = "TreeImages/B.jpg";
                }
                else
                {
                    i1.Src = "TreeImages/G.jpg";
                }
            }

            check();
            ss.find(Lb1.Text, out L, out R);
            string l2 = L.ToString();
            string r3 = R.ToString();
            if (l2 != "")
            {
                Lb2L.Visible = true;
                Lb2L.Text = l2;
                cmd = new SqlCommand("select jointype from User_Detail where userid='" + l2 + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    jointype = dr[0].ToString();
                }
                con.Close();
                if (jointype == "Paid")
                {
                    i2.Src = "TreeImages/B.jpg";
                }
                else
                {
                    i2.Src = "TreeImages/G.jpg";
                }
                ss.find(l2, out L, out R);
                string l4 = L.ToString();
                string r5 = R.ToString();

                if (l4 != "")
                {
                    Lb4L.Visible = true;
                    Lb4L.Text = l4;
                    cmd = new SqlCommand("select jointype from User_Detail where userid='" + l4 + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        jointype = dr[0].ToString();
                    }
                    con.Close();
                    if (jointype == "Paid")
                    {
                        i4.Src = "TreeImages/B.jpg";
                    }
                    else
                    {
                        i4.Src = "TreeImages/G.jpg";
                    }
                    ss.find(l4, out L, out R);
                    string l8 = L.ToString();
                    string r9 = R.ToString();

                    if (l8 != "")
                    {
                        Lb8L.Visible = true;
                        Lb8L.Text = l8;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + l8 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i8.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i8.Src = "TreeImages/G.jpg";
                        }
                    }
                    if (r9 != "")
                    {
                        Lb9R.Visible = true;
                        Lb9R.Text = r9;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + r9 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i9.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i9.Src = "TreeImages/G.jpg";
                        }
                    }
                }
                if (r5 != "")
                {
                    Lb5R.Visible = true;
                    Lb5R.Text = r5;
                    cmd = new SqlCommand("select jointype from User_Detail where userid='" + r5 + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        jointype = dr[0].ToString();
                    }
                    con.Close();
                    if (jointype == "Paid")
                    {
                        i5.Src = "TreeImages/B.jpg";
                    }
                    else
                    {
                        i5.Src = "TreeImages/G.jpg";
                    }
                    ss.find(r5, out L, out R);
                    string l10 = L.ToString();
                    string r11 = R.ToString();

                    if (l10 != "")
                    {
                        Lb10L.Visible = true;
                        Lb10L.Text = l10;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + l10 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i10.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i10.Src = "TreeImages/G.jpg";
                        }
                    }
                    if (r11 != "")
                    {
                        Lb11R.Visible = true;
                        Lb11R.Text = r11;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + r11 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i11.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i11.Src = "TreeImages/G.jpg";
                        }
                    }
                }
            }
            if (r3 != "")
            {
                Lb3R.Visible = true;
                Lb3R.Text = r3;
                cmd = new SqlCommand("select jointype from User_Detail where userid='" + r3 + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    jointype = dr[0].ToString();
                }
                con.Close();
                if (jointype == "Paid")
                {
                    i3.Src = "TreeImages/B.jpg";
                }
                else
                {
                    i3.Src = "TreeImages/G.jpg";
                }
                ss.find(r3, out L, out R);
                string l6 = L.ToString();
                string r7 = R.ToString();
                if (l6 != "")
                {
                    Lb6L.Visible = true;
                    Lb6L.Text = l6;
                    cmd = new SqlCommand("select jointype from User_Detail where userid='" + l6 + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        jointype = dr[0].ToString();
                    }
                    con.Close();
                    if (jointype == "Paid")
                    {
                        i6.Src = "TreeImages/B.jpg";
                    }
                    else
                    {
                        i6.Src = "TreeImages/G.jpg";
                    }
                    ss.find(l6, out L, out R);
                    string l12 = L.ToString();
                    string r13 = R.ToString();
                    if (l12 != "")
                    {
                        Lb12L.Visible = true;
                        Lb12L.Text = l12;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + l12 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i12.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i12.Src = "TreeImages/G.jpg";
                        }
                    }
                    if (r13 != "")
                    {
                        Lb13R.Visible = true;
                        Lb13R.Text = r13;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + r13 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i13.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i13.Src = "TreeImages/G.jpg";
                        }
                    }
                }
                if (r7 != "")
                {
                    Lb7R.Visible = true;
                    Lb7R.Text = r7;
                    cmd = new SqlCommand("select jointype from User_Detail where userid='" + r7 + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        jointype = dr[0].ToString();
                    }
                    con.Close();
                    if (jointype == "Paid")
                    {
                        i7.Src = "TreeImages/B.jpg";
                    }
                    else
                    {
                        i7.Src = "TreeImages/G.jpg";
                    }
                    ss.find(r7, out L, out R);
                    string l14 = L.ToString();
                    string r15 = R.ToString();
                    if (l14 != "")
                    {
                        Lb14L.Visible = true;
                        Lb14L.Text = l14;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + l14 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i14.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i14.Src = "TreeImages/G.jpg";
                        }
                    }
                    if (r15 != "")
                    {
                        Lb15R.Visible = true;
                        Lb15R.Text = r15;
                        cmd = new SqlCommand("select jointype from User_Detail where userid='" + r15 + "'", con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jointype = dr[0].ToString();
                        }
                        con.Close();
                        if (jointype == "Paid")
                        {
                            i15.Src = "TreeImages/B.jpg";
                        }
                        else
                        {
                            i15.Src = "TreeImages/G.jpg";
                        }
                    }
                }
            }
        }

        protected void ImgBack_Click(object sender, ImageClickEventArgs e)
        {
            bk = ((ArrayList)Session["temp"]);
            int count = bk.Count;
            if (count > 0)
            {
                string last = bk[count - 1].ToString();
                bk.Remove(last);
                Session["temp"] = bk;
                detail(last);
            }
            else if (count == 0)
            {
                detail("100000");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('This is Last User ID');", true);
            }
        }
        protected void Lb2L_Click(object sender, EventArgs e)
        {
            if (Lb2L.Text == "Blank")
            {
                if (Lb1.Text != "Blank")
                {
                    reduserid = Lb1.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }

            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb2L.Text);
                Session["temp"] = bk;
                detail(Lb2L.Text);
            }
        }
        protected void Lb3R_Click(object sender, EventArgs e)
        {
            if (Lb3R.Text == "Blank")
            {
                if (Lb1.Text != "Blank")
                {
                    reduserid = Lb1.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb3R.Text);
                Session["temp"] = bk;
                detail(Lb3R.Text);
            }
        }
        protected void Lb4L_Click(object sender, EventArgs e)
        {
            if (Lb4L.Text == "Blank")
            {
                if (Lb2L.Text != "Blank")
                {
                    reduserid = Lb2L.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }

            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb4L.Text);
                Session["temp"] = bk;
                detail(Lb4L.Text);
            }
        }
        protected void Lb5R_Click(object sender, EventArgs e)
        {
            if (Lb5R.Text == "Blank")
            {
                if (Lb2L.Text != "Blank")
                {
                    reduserid = Lb2L.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb5R.Text);
                Session["temp"] = bk;
                detail(Lb5R.Text);
            }
        }
        protected void Lb6L_Click(object sender, EventArgs e)
        {
            if (Lb6L.Text == "Blank")
            {
                if (Lb3R.Text != "Blank")
                {
                    reduserid = Lb3R.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb6L.Text);
                Session["temp"] = bk;
                detail(Lb6L.Text);
            }
        }
        protected void Lb7R_Click(object sender, EventArgs e)
        {
            if (Lb7R.Text == "Blank")
            {
                if (Lb3R.Text != "Blank")
                {
                    reduserid = Lb3R.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb7R.Text);
                Session["temp"] = bk;
                detail(Lb7R.Text);
            }
        }
        protected void Lb8L_Click(object sender, EventArgs e)
        {
            if (Lb8L.Text == "Blank")
            {
                if (Lb4L.Text != "Blank")
                {
                    reduserid = Lb4L.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb8L.Text);
                Session["temp"] = bk;
                detail(Lb8L.Text);
            }
        }
        protected void Lb9R_Click(object sender, EventArgs e)
        {
            if (Lb9R.Text == "Blank")
            {
                if (Lb4L.Text != "Blank")
                {
                    reduserid = Lb4L.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb9R.Text);
                Session["temp"] = bk;
                detail(Lb9R.Text);
            }
        }
        protected void Lb10L_Click(object sender, EventArgs e)
        {
            if (Lb10L.Text == "Blank")
            {
                if (Lb5R.Text != "Blank")
                {
                    reduserid = Lb5R.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb10L.Text);
                Session["temp"] = bk;
                detail(Lb10L.Text);
            }
        }
        protected void Lb11R_Click(object sender, EventArgs e)
        {
            if (Lb11R.Text == "Blank")
            {
                if (Lb5R.Text != "Blank")
                {
                    reduserid = Lb5R.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb11R.Text);
                Session["temp"] = bk;
                detail(Lb11R.Text);
            }
        }
        protected void Lb12L_Click(object sender, EventArgs e)
        {
            if (Lb12L.Text == "Blank")
            {
                if (Lb6L.Text != "Blank")
                {
                    reduserid = Lb6L.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb12L.Text);
                Session["temp"] = bk;
                detail(Lb12L.Text);
            }
        }
        protected void Lb13R_Click(object sender, EventArgs e)
        {
            if (Lb13R.Text == "Blank")
            {
                if (Lb6L.Text != "Blank")
                {
                    reduserid = Lb6L.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb13R.Text);
                Session["temp"] = bk;
                detail(Lb13R.Text);
            }
        }
        protected void Lb14L_Click(object sender, EventArgs e)
        {
            if (Lb14L.Text == "Blank")
            {
                if (Lb7R.Text != "Blank")
                {
                    reduserid = Lb7R.Text;
                    redside = "Left";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb14L.Text);
                Session["temp"] = bk;
                detail(Lb14L.Text);
            }
        }
        protected void Lb15R_Click(object sender, EventArgs e)
        {
            if (Lb15R.Text == "Blank")
            {
                if (Lb7R.Text != "Blank")
                {
                    reduserid = Lb7R.Text;
                    redside = "Right";
                    string url = "Registration.aspx?reduserid=" + reduserid + "&redside=" + redside;
                    Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Binary Tree Demo", "alert('For registration Parent should not be blank');", true);
                }
            }
            else
            {
                bk = ((ArrayList)Session["temp"]);
                bk.Add(Lb15R.Text);
                Session["temp"] = bk;
                detail(Lb15R.Text);
            }
        }
    }






    #region "Tree show"
    public class TreeShow
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        SqlDataReader dr;
        string sql;

        int status;
        public TreeShow()
        {
            con = new SqlConnection(ConfigurationSettings.AppSettings["str"]);
        }

        string msg;

        public void find(string apid, out string Left, out string Right)
        {
            Left = "";
            Right = "";
            cmd = new SqlCommand("select lleg,rleg from User_Detail where userid='" + apid + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    Left = dr[0].ToString();
                }
                if (dr[1].ToString() != "")
                {

                    Right = dr[1].ToString();
                }
            }
            con.Close();
        }

        public DataTable fillUserDetail(string apid)
        {
            DataTable ufill = new DataTable();
            da = new SqlDataAdapter("select name,ljoining,rjoining,pair,jointype from User_Detail where userid='" + apid + "'", con);
            da.Fill(ufill);
            return ufill;

        }

    }

    #endregion
}