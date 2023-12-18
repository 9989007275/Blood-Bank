using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HELPINGHANDS
{
    public partial class ULOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["uname"] = TextBox1.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            string q = "proc_ulogin";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@a", Session["uname"].ToString());
            com.Parameters.AddWithValue("@b", TextBox2.Text);
            object p=com.ExecuteScalar();
            con.Close();
            if ((int)p != 0)
                Server.Transfer("UWELCOME.aspx");
            else
                Response.Write("INVALID USER");
        }
    }
}