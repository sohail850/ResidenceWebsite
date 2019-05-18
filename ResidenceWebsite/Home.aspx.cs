using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ResidenceWebsite
{
    public partial class home : System.Web.UI.Page
    {
        public DataSet ds;
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataAdapter adap;
        public SqlDataReader reader;

        public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahatt\Documents\MyProjects\ResidenceWebsite\ResidenceWebsite\App_Data\ResidenceDB.mdf;Integrated Security=True";
        public string sql = "";
        public string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString);
            HttpCookie userCookie = Request.Cookies["UserCookie"];

            try
            {
                if (userCookie != null)
                {
                    username = userCookie["Username"].ToString();
                    lblUsername.Text = username;
                    Session["Username"] = username;
                    HideLogin();
                }
            }
            catch (Exception error)
            {
                lblUsername.Text = "You are not logged in!";
            }
        }

        public void ShowLogin()
        {
            btnLogin.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;
        }

        public void HideLogin()
        {
            btnLogin.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            txtUsername.Visible = false;
            txtPassword.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (username != null)
                Response.Redirect("Residents.aspx");
            else
                lblUsername.Text = "You are not logged in!";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (username != null)
                Response.Redirect("Events.aspx");
            else
                lblUsername.Text = "You are not logged in!";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            string username;
            
            
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (user == "" || pass == "")
            {
                lblUsername.Text = "Enter a username & password!";
            }
            else
            {
                conn.Open();
                sql = @"SELECT * FROM ResidentTable";

                comm = new SqlCommand(sql, conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if (user == reader.GetValue(1).ToString())
                    {
                        if (pass == reader.GetValue(2).ToString())
                        {
                            username = user;
                            userCookie = new HttpCookie("UserCookie");
                            userCookie["Username"] = username;
                            lblUsername.Text = username;
                            Session["Username"] = username;
                                
                            Response.Cookies.Add(userCookie);
                            break;
                        }
                    }
                }
                reader.Close();

                conn.Close();
            }
            
        }
    }
}