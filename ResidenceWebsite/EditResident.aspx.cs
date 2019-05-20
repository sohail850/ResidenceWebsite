using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace ResidenceWebsite
{
    public partial class EditResident : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                conn = new SqlConnection(connString);
                username = Session["Username"].ToString();

                conn.Open();
                sql = "SELECT * FROM ResidentTable";
                comm = new SqlCommand(sql, conn);

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(1).ToString() == username)
                    {
                        // Display all info in text boxes
                        txtStudents.Text = reader.GetValue(0).ToString();
                        txtUser.Text = reader.GetValue(1).ToString();
                        // txtPass.Text = reader.GetValue(2).ToString();
                        // txtConfirm.Text = reader.GetValue(2).ToString();
                        txtName.Text = reader.GetValue(3).ToString();
                        txtSurname.Text = reader.GetValue(4).ToString();
                        txtRoom.Text = reader.GetValue(5).ToString();
                        txtCell.Text = reader.GetValue(6).ToString();
                        txtEmail.Text = reader.GetValue(7).ToString();
                        txtDegree.Text = reader.GetValue(8).ToString();
                        txtYear.Text = reader.GetValue(9).ToString();
                        txtAverage.Text = reader.GetValue(10).ToString();
                        txtAdmin.Text = reader.GetValue(11).ToString();
                        break;
                    }
                }

                reader.Close();
                conn.Close();
            }
            else
            {
                conn = new SqlConnection(connString);
                username = Session["Username"].ToString();
            }
        }

        public string getSHA1Hash(string pw)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pw));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();

            sql = @"DELETE FROM ResidentTable WHERE Student_Number = " + txtStudents.Text;
            comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();

            sql = "INSERT INTO ResidentTable VALUES(@sNum, @User, @Pass, @Name, @Surname, @Room, @Cell, @Email, @Degree, @Year, @Average, @Admin)";
            comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("sNum", txtStudents.Text);
            comm.Parameters.AddWithValue("User", txtUser.Text);
            comm.Parameters.AddWithValue("Pass", getSHA1Hash(txtPass.Text));
            comm.Parameters.AddWithValue("Name", txtName.Text);
            comm.Parameters.AddWithValue("Surname", txtSurname.Text);
            comm.Parameters.AddWithValue("Room", txtRoom.Text);
            comm.Parameters.AddWithValue("Cell", txtCell.Text);
            comm.Parameters.AddWithValue("Email", txtEmail.Text);
            comm.Parameters.AddWithValue("Degree", txtDegree.Text);
            comm.Parameters.AddWithValue("Year", txtYear.Text);
            comm.Parameters.AddWithValue("Average", txtAverage.Text);
            comm.Parameters.AddWithValue("Admin", txtAdmin.Text);

            comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Residents.aspx");
        }
    }
}