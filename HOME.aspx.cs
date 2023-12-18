using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HELPINGHANDS
{
    public partial class HOME : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["d"] = "REGISTER";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("SEARCH.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("REGISTER.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("LOGIN.aspx");
            //Button5.Visible = true;
            //Button6.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("ALOGIN.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("ULOGIN.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}