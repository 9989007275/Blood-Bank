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
    public partial class UPDATE : System.Web.UI.Page
    {
        void getdata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "displayuser";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@a", Session["uname"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "displayuser");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                getdata();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getdata();
        }




        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            TextBox t1 = (TextBox)rows.FindControl("TextBox1");
            TextBox t2 = (TextBox)rows.FindControl("TextBox2");
            TextBox t3 = (TextBox)rows.FindControl("TextBox3");
            TextBox t4 = (TextBox)rows.FindControl("TextBox4");
            TextBox t5 = (TextBox)rows.FindControl("TextBox5");
            TextBox t6 = (TextBox)rows.FindControl("TextBox6");
            TextBox t7 = (TextBox)rows.FindControl("TextBox7");


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            string q = "proc_userupdate";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("g", t1.Text);
            com.Parameters.AddWithValue("a", t2.Text);
            com.Parameters.AddWithValue("b", t3.Text);
            com.Parameters.AddWithValue("c", t4.Text);
            com.Parameters.AddWithValue("d", t5.Text);
            com.Parameters.AddWithValue("e", t6.Text);
            com.Parameters.AddWithValue("f", t7.Text);


            int p = com.ExecuteNonQuery();
            con.Close();
            if (p != 0)
                Response.Write("RECORD UPDATED");
            else
                Response.Write("RECORD NOT UPDATED");
        }
    }
}