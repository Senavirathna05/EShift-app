using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Text.RegularExpressions;

namespace EShiftApp.Forms
{
    public partial class CustomerRegister : Form
    {
        public CustomerRegister()
        {
            InitializeComponent();
        }

        // Event triggered when the form loads
        private void CustomerRegister_Load(object sender, EventArgs e)
        {
            // Mask password fields with bullet character
            txtPassword.PasswordChar = '●';
            txtConfirmPassword.PasswordChar = '●';
        }

        // Method to clear all input fields
        private void ClearForm()
        {
            txtFullName.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        // Event handler for the "Register" button
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Check for empty fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate contact number (must be exactly 10 digits)
            if (!Regex.IsMatch(txtContactNumber.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Contact Number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validate email format (basic regex pattern)
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Check if passwords match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 5. Get database connection string from App.config
                string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 6. Check if the email is already registered
                    string checkEmailQuery = "SELECT COUNT(*) FROM Customers WHERE LOWER(Email) = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkEmailQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim().ToLower());
                        int emailExists = (int)checkCmd.ExecuteScalar();

                        if (emailExists > 0)
                        {
                            MessageBox.Show("An account with this email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 7. Insert new customer into database
                    string query = @"INSERT INTO Customers (FullName, ContactNumber, Address, Email, Password)
                                     VALUES (@FullName, @ContactNumber, @Address, @Email, @Password)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter values
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        // NOTE: In real applications, password should be hashed before saving

                        int result = cmd.ExecuteNonQuery();

                        // 8. Show result message
                        if (result > 0)
                        {
                            MessageBox.Show("Customer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm(); // Clear form after success
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 9. Handle unexpected errors
                MessageBox.Show("An error occurred: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler to show/hide password text
        private void chbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char maskChar = '●'; // Default masking character

            if (chbxShowPassword.Checked)
            {
                // Show passwords
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                // Hide passwords
                txtPassword.PasswordChar = maskChar;
                txtConfirmPassword.PasswordChar = maskChar;
            }
        }

        // Event handler to navigate back to login form
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new CustomerLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}
