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
    public partial class EditEvent : System.Web.UI.Page
    {
        public DataSet ds;
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataAdapter adap;
        public SqlDataReader reader;

        public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Git\ResidenceWebsite\ResidenceWebsite\App_Data\ResidenceDB.mdf;Integrated Security=True;Connect Timeout=30";
        public string sql = "";

        public string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            //eventsListBox.Items.Clear();
            //username = Session["Username"].ToString();
            //HttpCookie cookie = new HttpCookie("EditEventsCookie");
            //cookie["FirstLoad"] = "true";

            conn = new SqlConnection(connString);
            conn.Open();

            sql = @"SELECT * FROM EventsTable";
            comm = new SqlCommand(sql, conn);

            try
            {
                reader = comm.ExecuteReader();
                string output;

                while (reader.Read())
                {
                    output = string.Format("{0, -3}\t{1, -50}\t{2, -10}\t{3, -5}\t{4, -50}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    eventsListBox.Items.Add(output);
                }
            }
            catch (Exception er)
            {
                lblOutput.Text = "An unknown error occurred";
            }

            reader.Close();
            conn.Close();
        }

        protected void eventsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            string[] item = eventsListBox.SelectedValue.ToString().Split(' ');

            id = item[0];
            txtID.Text = id;
        }

        protected void btnEditEvent_Click(object sender, EventArgs e)
        {
            conn.Open();
            string eventID = txtID.Text;

            sql = @"DELETE FROM EventsTable WHERE EventID = '" + eventID + "'";
            comm = new SqlCommand(sql, conn);

            comm.ExecuteNonQuery();
            conn.Close();

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