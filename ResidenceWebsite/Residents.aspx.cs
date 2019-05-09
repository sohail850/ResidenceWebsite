using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ResidenceWebsite
{
    public partial class Residents : System.Web.UI.Page
    {
        public DataSet ds;
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataAdapter adap;

        public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Git\ResidenceWebsite\ResidenceWebsite\App_Data\ResidenceDB.mdf;Integrated Security=True";
        public string sql;

        protected void Page_Load(object sender, EventArgs e)
        {
            sql = @"SELECT * FROM ResidentTable";

            conn = new SqlConnection(connString);
            conn.Open();

            comm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adap = new SqlDataAdapter();

            adap.SelectCommand = comm;
            adap.Fill(ds, "ResidentTable");
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Residents.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Events.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }
    }
}