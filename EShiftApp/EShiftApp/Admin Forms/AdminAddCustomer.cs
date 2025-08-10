using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EShiftApp.Admin_Forms
{
    public partial class AdminAddCustomer : Form
    {
        public bool IsSaved = false;
        public AdminAddCustomer()
        {
            InitializeComponent();
        }


        private void AdminAddCustomer_Load(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Get input values
            string fullName = txtFullName.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Basic validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(contactNumber) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Customers (FullName, ContactNumber, Address, Email, Password) 
                             VALUES (@FullName, @ContactNumber, @Address, @Email, @Password)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Consider hashing in real apps

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Close form after save
                        }
                        else
                        {
                            MessageBox.Show("Insert failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chbxShowPassword.Checked;
            txtPassword.PasswordChar = show ? '\0' : '•';
            txtConfirmPassword.PasswordChar = show ? '\0' : '•';
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
