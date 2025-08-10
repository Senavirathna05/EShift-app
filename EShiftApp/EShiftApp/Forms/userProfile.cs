using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShiftApp.Forms
{
    public partial class userProfile : Form
    {
        private int _customerId;
        public userProfile(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void userProfile_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';

            // Get connection string
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @id", conn);
                cmd.Parameters.AddWithValue("@id", _customerId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["FullName"].ToString();
                    txtContactNumber.Text = reader["ContactNumber"].ToString();
                    txtAddress.Text = reader["Address"].ToString() ;
                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();


                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get connection string
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open ();
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET FullName=@name, ContactNumber=@phone, Address=@addr, Email=@email, Password=@pass WHERE CustomerID=@id", conn);

                cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                cmd.Parameters.AddWithValue("@phone", txtContactNumber.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@id", _customerId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Profile Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );

                this.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char maskChar = '●'; // or '*'

            if (chbxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = maskChar;
            }
        }
    }
}
