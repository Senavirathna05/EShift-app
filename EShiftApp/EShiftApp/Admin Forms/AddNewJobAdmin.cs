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

namespace EShiftApp.Admin_Forms
{
    public partial class AddNewJobAdmin : Form
    {
        public AddNewJobAdmin()
        {
            InitializeComponent();
        }

        // When the form loads, load customer data into the dropdown list
        private void AddNewJobAdmin_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

      
        /// Loads all customers from the Customers table into the ComboBox.
        /// The display format is "CustomerID - FullName".
        private void LoadCustomers()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Query to get customer ID and Name
                string query = "SELECT CustomerID, FullName FROM Customers ORDER BY CustomerID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Create a combined display column for better readability in ComboBox
                dt.Columns.Add("DisplayText", typeof(string), "CONVERT(CustomerID, 'System.String') + ' - ' + FullName");

                // Bind data to ComboBox
                cmbCustomerId.DataSource = dt;
                cmbCustomerId.DisplayMember = "DisplayText"; 
                cmbCustomerId.ValueMember = "CustomerID";    
                cmbCustomerId.SelectedIndex = -1;          
            }
        }

        /// Handles the submission of a new job request from the admin panel.
        /// Includes form validation and inserts data into the Jobs table.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation: Ensure a customer is selected
            if (cmbCustomerId.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation: Start and End locations must be filled
            if (string.IsNullOrWhiteSpace(txtStart.Text) || string.IsNullOrWhiteSpace(txtEnd.Text))
            {
                MessageBox.Show("Please enter both start and end locations.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation: Job description must not be empty
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a job description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"INSERT INTO Jobs (CustomerID, StartLocation, Destination, RequestedDate, Description, Status)
                                     VALUES (@CustomerID, @StartLocation, @Destination, @RequestedDate, @Description, 'Accepted')";

                    SqlCommand cmd = new SqlCommand(query, conn);


                    cmd.Parameters.AddWithValue("@CustomerID", cmbCustomerId.SelectedValue);
                    cmd.Parameters.AddWithValue("@StartLocation", txtStart.Text.Trim());
                    cmd.Parameters.AddWithValue("@Destination", txtEnd.Text.Trim());
                    cmd.Parameters.AddWithValue("@RequestedDate", dtpJobDate.Value);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                    int rows = cmd.ExecuteNonQuery();

                    // Check if insertion was successful
                    if (rows > 0)
                    {
                        MessageBox.Show("Job created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to create job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any database or runtime errors
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
