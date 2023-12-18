using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HELPINGHANDS
{
    public partial class ADETAILS : System.Web.UI.Page
    {
        void getdata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "display1";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "display1");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
                getdata();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="cmddelete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                Label l1 = (Label)row.FindControl("Label1");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
                con.Open();
                string q = "proc_delete";
                SqlCommand com = new SqlCommand(q, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@a", l1.Text);
                int p = com.ExecuteNonQuery();
                con.Close();
                if (p != 0)
                    Response.Write("RECORD DELETED");
                else
                    Response.Write("RECORD NOT DELETED");
                getdata();
            }
            else if(e.CommandName=="cmdedit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                Label l1 = (Label)row.FindControl("Label1");
                Label l2 = (Label)row.FindControl("Label2");
                Label l3 = (Label)row.FindControl("Label3");
                Label l4 = (Label)row.FindControl("Label4");
                Label l5 = (Label)row.FindControl("Label5");
                Label l6 = (Label)row.FindControl("Label6");
                Label l7 = (Label)row.FindControl("Label7");
                Session["uid"] = l1.Text;
                Session["uname"] = l2.Text;
                Session["bgroup"] = l3.Text;
                Session["phno"] = l4.Text;
                Session["email"] = l5.Text;
                Session["state"] = l6.Text;
                Session["city"] = l7.Text;
                Session["d"] = "update";
                Server.Transfer("REGISTER.aspx");
                
            }
        }
    }
}