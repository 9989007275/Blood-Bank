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
    public partial class ALOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            string q = "proc_alogin";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@a", TextBox1.Text);
            com.Parameters.AddWithValue("@b", TextBox2.Text);
            object p=com.ExecuteScalar();
            if ((int)p != 0)
                Server.Transfer("AWELCOME.aspx");
            else
                Response.Write("RECORD NOT MATCHED");
            con.Close();
        }
    }
}