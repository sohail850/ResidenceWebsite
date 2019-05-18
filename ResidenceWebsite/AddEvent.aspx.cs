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
    public partial class AddEvent : System.Web.UI.Page
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
            //username = Session["Username"].ToString();
            conn = new SqlConnection(connString);

            int lastIndex = getLastIndex();
            txtID.Text = (lastIndex + 1).ToString();
        }

        public int getLastIndex()
        {
            conn.Open();
            sql = "SELECT TOP 1 * FROM EventsTable ORDER BY EventID DESC";
            comm = new SqlCommand(sql, conn);

            reader = comm.ExecuteReader();
            int id = 0;

            while (reader.Read())
            {
                id = int.Parse(reader.GetValue(0).ToString());
            }

            reader.Close();
            conn.Close();

            return id;
        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            conn.Open();
            sql = "INSERT INTO EventsTable VALUES(@ID, @Description, @Date, @Time, @Venue)";
            comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("ID", txtID.Text);
            comm.Parameters.AddWithValue("Description", txtDescription.Text);
            comm.Parameters.AddWithValue("Date", txtDate.Text);
            comm.Parameters.AddWithValue("Time", txtTime.Text);
            comm.Parameters.AddWithValue("Venue", txtVenue.Text);

            comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Events.aspx");
        }
    }
}