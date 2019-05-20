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
    public partial class AddResident : System.Web.UI.Page
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
            conn = new SqlConnection(connString);
            username = Session["Username"].ToString();
        }

        protected void PrimaryKeyValidate(object source, ServerValidateEventArgs args)
        {
            conn.Open();
            sql = "SELECT * FROM ResidentTable";
            comm = new SqlCommand(sql, conn);

            reader = comm.ExecuteReader();
            string sNum;
            args.IsValid = true;

            while (reader.Read())
            {
                sNum = reader.GetValue(0).ToString();
                if (args.Value.ToString() == sNum)
                {
                    args.IsValid = false;
                    break;
                }
            }
            reader.Close();
            conn.Close();      
        }

        protected void UsernameValidate(object source, ServerValidateEventArgs args)
        {
            conn.Open();
            sql = "SELECT * FROM ResidentTable";
            comm = new SqlCommand(sql, conn);

            reader = comm.ExecuteReader();
            string uName;
            args.IsValid = true;

            while (reader.Read())
            {
                uName = reader.GetValue(1).ToString();
                if (args.Value.ToString() == uName)
                {
                    args.IsValid = false;
                    break;
                }
            }
            reader.Close();
            conn.Close();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string newPass = getSHA1Hash(txtPass.Text);
            string admin = ddListAdmin.SelectedValue.ToString();

            conn.Open();
            sql = "INSERT INTO ResidentTable VALUES(@sNum, @User, @Pass, @Name, @Surname, @Room, @Cell, @Email, @Degree, @Year, @Average, @Admin)";
            comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("sNum", txtStudents.Text);
            comm.Parameters.AddWithValue("User", txtUsername.Text);
            comm.Parameters.AddWithValue("Pass", newPass);
            comm.Parameters.AddWithValue("Name", txtName.Text);
            comm.Parameters.AddWithValue("Surname", txtSurname.Text);
            comm.Parameters.AddWithValue("Room", txtRoom.Text);
            comm.Parameters.AddWithValue("Cell", txtCell.Text);
            comm.Parameters.AddWithValue("Email", txtEmail.Text);
            comm.Parameters.AddWithValue("Degree", txtDegree.Text);
            comm.Parameters.AddWithValue("Year", txtYear.Text);
            comm.Parameters.AddWithValue("Average", txtAverage.Text);
            comm.Parameters.AddWithValue("Admin", admin);

            comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Residents.aspx");
        }
    }
}