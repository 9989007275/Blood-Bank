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
    public partial class SEARCH : System.Web.UI.Page
    {
        void getdata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "search";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@a",DropDownList1.SelectedItem.Text);
            com.Parameters.AddWithValue("@b", DropDownList2.SelectedItem.Text);
            com.Parameters.AddWithValue("@c", DropDownList3.SelectedItem.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "search");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        void getstate()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "proc_getstate";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "state");
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "sname";
            DropDownList1.DataValueField = "sid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--select--");
        }
        void getbgrp()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "proc_getbgrp";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "bgrp");
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "grpname";
            DropDownList3.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                
                getstate();
                getbgrp();
                DropDownList2.Items.Insert(0, "--select--");
                DropDownList3.Items.Insert(0, "--select--");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getdata();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string s = DropDownList1.SelectedValue;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "proc_getcity";
            SqlCommand com = new SqlCommand(q, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@a", s);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "state");
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "cname";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--select--");

        }
    }
}