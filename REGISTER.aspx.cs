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
    public partial class REGISTER : System.Web.UI.Page
    {
        string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            s = Session["d"].ToString();

            if (IsPostBack==false)
            {
                getstate();
                getbgrp();
                DropDownList2.Items.Insert(0, "--select--");
                DropDownList3.Items.Insert(0, "--select--");
                if (s == "REGISTER")
                {
                    ;
                }
                else if (s == "update")
                {

                    TextBox1.Text = Session["uname"].ToString();
                    DropDownList1.SelectedItem.Text = Session["state"].ToString();
                    DropDownList2.SelectedItem.Text = Session["city"].ToString();
                    DropDownList3.SelectedItem.Text = Session["bgroup"].ToString();
                    TextBox4.Text = Session["phno"].ToString();
                    TextBox5.Text = Session["email"].ToString();

                    TextBox2.Enabled = TextBox3.Enabled = false;
                    RadioButton1.Enabled = RadioButton2.Enabled = false;
                    CheckBox1.Enabled = CheckBox2.Enabled = CheckBox3.Enabled = false;
                    RequiredFieldValidator1.Enabled = RequiredFieldValidator2.Enabled = false;
                    CompareValidator1.Enabled = false;

                    Button1.Text = "UPDATE";
                }
                
                
            }

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
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
        void getclear()
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = "";
            RadioButton1.Checked = RadioButton2.Checked = false;
            CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = false;


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
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            if (Button1.Text == "REGISTER")
            {
                
                string q = "proc_insertuser";
                SqlCommand com = new SqlCommand(q, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@a", TextBox1.Text);
                com.Parameters.AddWithValue("@b", TextBox2.Text);
                string s = "";
                if (RadioButton1.Checked == true)
                    s = RadioButton1.Text;
                else
                    s = RadioButton2.Text;
                com.Parameters.AddWithValue("@c", s);
                string t = "";
                if (CheckBox1.Checked == true)
                    t = CheckBox1.Text;
                if (CheckBox2.Checked == true)
                    t = t + " " + CheckBox2.Text;
                if (CheckBox3.Checked == true)
                    t = t + " " + CheckBox3.Text;
                com.Parameters.AddWithValue("@d", t);
                com.Parameters.AddWithValue("@e", DropDownList1.SelectedItem.Text);
                com.Parameters.AddWithValue("f", DropDownList2.SelectedItem.Text);
                com.Parameters.AddWithValue("g", DropDownList3.SelectedItem.Text);
                com.Parameters.AddWithValue("h", TextBox4.Text);
                com.Parameters.AddWithValue("i", TextBox5.Text);
                int p = com.ExecuteNonQuery();
                if (p != 0)
                    Response.Write("RECORD REGISTERED");
                else
                    Response.Write("RECORD NOT INSERTED");
            }
            else
            {
                
                Button1.Text = "UPDATE";
                 string q = "proc_update";
                SqlCommand com = new SqlCommand(q, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("a", DropDownList3.SelectedItem.Text);
                com.Parameters.AddWithValue("b", TextBox4.Text);
                com.Parameters.AddWithValue("c", TextBox5.Text);
                com.Parameters.AddWithValue("d", DropDownList1.SelectedItem.Text);
                com.Parameters.AddWithValue("e", DropDownList2.SelectedItem.Text);
                com.Parameters.AddWithValue("f", Session["uid"].ToString());
                int p = com.ExecuteNonQuery();
                if (p != 0)
                    Response.Write("RECORD UPDATED");
                else
                    Response.Write("RECORD NOT UPDATED");

                
            }
            Button1.Text = "REGISTER";
            con.Close();
            getclear();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = "";
            RadioButton1.Checked = RadioButton2.Checked = false;
            CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = false;
        }
    }
}