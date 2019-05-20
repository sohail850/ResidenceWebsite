using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
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
        public SqlDataReader reader;

        public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahatt\Documents\MyProjects\ResidenceWebsite\ResidenceWebsite\App_Data\ResidenceDB.mdf;Integrated Security=True;Connect Timeout=30";
        // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Git\ResidenceWebsite\ResidenceWebsite\App_Data\ResidenceDB.mdf;Integrated Security=True;Connect Timeout=30";
        public string sql = "";
        public string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                username = Session["Username"].ToString();
                Label1.Text = username;
                sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average FROM ResidentTable";
                conn = new SqlConnection(connString);
                conn.Open();

                comm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adap = new SqlDataAdapter();
                adap.SelectCommand = comm;
                adap.Fill(ds, "ResidentTable");
                GridView1.DataSource = ds;
                GridView1.DataBind();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ddListDelete.Items.Add(reader.GetValue(0).ToString());
                }
                reader.Close();

                conn.Close();
            }
            catch (Exception)
            {
                Response.Redirect("Home.aspx");
            }
        }

        public bool isAdmin(string user)
        {
            conn.Open();
            sql = "SELECT * FROM ResidentTable";
            comm = new SqlCommand(sql, conn);

            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetValue(1).ToString() == user)
                {
                    if (reader.GetValue(11).ToString() == "y")
                    {
                        return true;
                    }
                }
            }
            conn.Close();
            return false;
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

        protected void Button7_Click(object sender, EventArgs e)
        {
            sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average
                    FROM ResidentTable
                    WHERE Student_Number LIKE '%" + txtBoxSearch.Text + "%'" +
                    "OR First_Name LIKE '%" + txtBoxSearch.Text + "%'" +
                    "OR Last_Name LIKE '%" + txtBoxSearch.Text + "%'";

            conn = new SqlConnection(connString);
            conn.Open();

            comm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adap = new SqlDataAdapter();

            adap.SelectCommand = comm;
            adap.Fill(ds, "ResidentTable");

            GridView1.DataSource = ds;
            GridView1.DataBind();

            conn.Close();
        }

        //Add Resident
        protected void Button8_Click(object sender, EventArgs e)
        {
            if (isAdmin(username))
            {
                Response.Redirect("AddResident.aspx");
            }
            else
            {
                lblOutput.Text = "Only admin users can add residents.";
            }
        }

        //Edit Resident
        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditResident.aspx");
        }

        //Delete Resident
        protected void Button10_Click(object sender, EventArgs e)
        {
            if (isAdmin(username))
            {
                conn = new SqlConnection(connString);
                conn.Open();

                sql = @"DELETE FROM ResidentTable WHERE Student_Number = " + ddListDelete.SelectedValue;
                comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();

                sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average FROM ResidentTable";
                comm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adap = new SqlDataAdapter();
                adap.SelectCommand = comm;
                adap.Fill(ds, "ResidentTable");
                GridView1.DataSource = ds;
                GridView1.DataBind();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ddListDelete.Items.Add(reader.GetValue(0).ToString());
                }
                reader.Close();

                conn.Close();
            }
            else
            {
                lblOutput.Text = "Only admin users can remove residents.";
            }
        }

        //Show Distinctions
        protected void Button11_Click(object sender, EventArgs e)
        {
            sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average FROM ResidentTable " + 
                   "WHERE Academic_Average >= 75";
            conn = new SqlConnection(connString);
            conn.Open();

            comm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = comm;
            adap.Fill(ds, "ResidentTable");
            GridView1.DataSource = ds;
            GridView1.DataBind();

            conn.Close();
        }

        //Show Passes
        protected void Button12_Click(object sender, EventArgs e)
        {
            sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average FROM ResidentTable " +
                   "WHERE Academic_Average >= 50";
            conn = new SqlConnection(connString);
            conn.Open();

            comm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = comm;
            adap.Fill(ds, "ResidentTable");
            GridView1.DataSource = ds;
            GridView1.DataBind();

            conn.Close();
        }

        //Show Fails
        protected void Button13_Click(object sender, EventArgs e)
        {
            sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average FROM ResidentTable " +
                   "WHERE Academic_Average < 50";
            conn = new SqlConnection(connString);
            conn.Open();

            comm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = comm;
            adap.Fill(ds, "ResidentTable");
            GridView1.DataSource = ds;
            GridView1.DataBind();

            conn.Close();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            sql = @"SELECT Student_Number,First_Name,Last_Name,Room,Cell,Email,Degree,Academic_Year,Academic_Average FROM ResidentTable";
            conn = new SqlConnection(connString);
            conn.Open();

            comm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = comm;
            adap.Fill(ds, "ResidentTable");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            username = null;
            Session["Username"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}