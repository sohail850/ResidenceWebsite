using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResidenceWebsite
{
    public partial class ContactUs : System.Web.UI.Page
    {

        public string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                username = Session["Username"].ToString();
                Label1.Text = username;
                btnLogout.Visible = true;
            }
            catch (Exception)
            {
                Label1.Text = "You are not logged in!";
                btnLogout.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (username != null)
            {
                Response.Redirect("Residents.aspx");
            }
            else
            {
                Label1.Text = "You are not logged in!";
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (username != null)
            {
                Response.Redirect("Events.aspx");
            }
            else
            {
                Label1.Text = "You are not logged in!";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact Us.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            username = null;
            Session["Username"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}