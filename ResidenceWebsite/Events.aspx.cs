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
    public partial class Events : System.Web.UI.Page
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
            eventsListBox.Items.Clear();
            Calendar1.SelectedDates.Clear();
            username = Session["Username"].ToString();
            Label1.Text = username;
            conn = new SqlConnection(connString);
            PopulateCalendar();
        }

        // This method selects all the dates in the calendar for which an event is scheduled
        public void PopulateCalendar()
        {
            conn.Open();
            sql = @"SELECT * FROM EventsTable";
            comm = new SqlCommand(sql, conn);

            try
            {
                reader = comm.ExecuteReader();
                string dateString;
                DateTime date;
                while (reader.Read())
                {
                    dateString = reader.GetValue(2).ToString();
                    date = DateTime.Parse(dateString);

                    Calendar1.SelectedDates.Add(date);
                    // eventsListBox.Items.Add(string.Format("{0, -10}\t{1, -5}\t{2, -50}\t{3, -50}", dateString, reader.GetValue(3), reader.GetValue(1), reader.GetValue(4)));
                }
            }
            catch (Exception er)
            {
                lblOutput.Text = "An unknown error occurred";
            }

            reader.Close();
            conn.Close();
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            eventsListBox.Items.Clear();

            string checkDate = Calendar1.SelectedDate.ToShortDateString().Replace("/", "-");
            // lblOutput.Text = checkDate;

            conn.Open();
            sql = @"SELECT * FROM EventsTable";
            comm = new SqlCommand(sql, conn);

            try
            {
                reader = comm.ExecuteReader();
                string dateString;
                DateTime date;
                while (reader.Read())
                {
                    if (reader.GetValue(2).ToString() == checkDate)
                    {
                        dateString = reader.GetValue(2).ToString();
                        eventsListBox.Items.Add(string.Format("{0, -10}\t{1, -5}\t{2, -50}\t{3, -50}", dateString, reader.GetValue(3), reader.GetValue(1), reader.GetValue(4)));
                    }
                }
            }
            catch (Exception er)
            {
                // Do nothing
            }

            reader.Close();
            conn.Close();

            PopulateCalendar();
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



        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (isAdmin(username))
            {
                Response.Redirect("AddEvent.aspx");
            }
            else
            {
                lblOutput.Text = "Only admin users can add events.";
            }
        }

        protected void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            if (isAdmin(username))
            {
                Response.Redirect("RemoveEvent.aspx");
            }
            else
            {
                lblOutput.Text = "Only admin users can remove events.";
            }
        }

        protected void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (isAdmin(username))
            {
                Response.Redirect("EditEvent.aspx");
            }
            else
            {
                lblOutput.Text = "Only admin users can remove events.";
            }
        }
    }
}