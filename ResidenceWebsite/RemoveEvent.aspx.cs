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
    public partial class RemoveEvent : System.Web.UI.Page
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
            conn.Open();

            sql = @"SELECT * FROM EventsTable";
            comm = new SqlCommand(sql, conn);

            try
            {
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    eventsListBox.Items.Add(string.Format("{0, -3}\t{1, -50}\t{2, -10}\t{3, -5}\t{4, -50}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4)));
                }
            }
            catch (Exception er)
            {
                lblOutput.Text = "An unknown error occurred";
            }

            reader.Close();
            conn.Close();
        }

        protected void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            conn.Open();

            string eventID = eventsListBox.SelectedItem.ToString().Split(' ')[0];

            sql = @"DELETE FROM EventsTable WHERE EventID = '" + eventID + "'";
            comm = new SqlCommand(sql, conn);

            comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Events.aspx");
        }
    }
}