using EShiftApp.Admin_Forms;
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
    public partial class CustomerLogin : Form
    {
        public CustomerLogin()
        {
            InitializeComponent();
        }

        private void CustomerLoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

   

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var regForm = new CustomerRegister();
            regForm.Show();
            this.Hide();
        }

        private void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            // 1. Get input
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 2. Validate input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Email and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Get connection string
                string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 4. SQL Query to check email and password
                    string query = "SELECT CustomerID, FullName FROM Customers WHERE Email = @Email AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // TODO: Hash check in real app

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 5. Successful login
                                int customerId = reader.GetInt32(0);
                                string fullName = reader.GetString(1);

                                MessageBox.Show("Login successful! Welcome, " + fullName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Open Customer Dashboard
                                CustomerDashboard dashboard = new CustomerDashboard(customerId);
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Admins WHERE Username = @u AND Password = @pw";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show($"Welcome Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var dashboard = new AdminDashBoard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Admin credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
