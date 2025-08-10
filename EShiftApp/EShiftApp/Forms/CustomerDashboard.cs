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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EShiftApp.Forms
{
    public partial class CustomerDashboard : Form
    {
        private int _customerId;
       
        public CustomerDashboard(int customerId)

        {
            InitializeComponent();
            _customerId = customerId;
        }



        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            LoadCustomerJobs();     //Call method for load Custome Jobs
            LoadJobSummary();       //Call method for Dashboard Customer Card

            // 1. Get connection string
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 2. SQL Query to Get Welcome Note 
                SqlCommand cmd = new SqlCommand("SELECT FullName FROM Customers WHERE CustomerID = @id" , conn);
                cmd.Parameters.AddWithValue("@id", _customerId);
                var name = cmd.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(name))
                {
                    lblWelcome.Text = $"WELCOME, {name}!";
                    lblCustomerName.Text = name ;
                }
                else
                {
                    lblWelcome.Text = "WELCOME!";
                    lblCustomerName.Text = "User";
                }


            }


        }

        //method for load Custome Jobs
        private void LoadCustomerJobs() 
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT JobID, StartLocation, Destination, RequestedDate,Description, Status FROM Jobs WHERE CustomerID = @custId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@custId", _customerId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvJobs.DataSource = table;
            }

            //Apply row colours based on status
            foreach (DataGridViewRow row in dgvJobs.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Accepted":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Completed":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Decline":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
        }

        private void LoadJobSummary()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string baseQuery = "SELECT COUNT(*) FROM Jobs WHERE CustomerID = @custId AND Status = @status";
                string totalQuery = "SELECT COUNT(*) FROM Jobs WHERE CustomerID = @custId";

                // Total
                SqlCommand totalCmd = new SqlCommand(totalQuery, conn);
                totalCmd.Parameters.AddWithValue("@custId", _customerId);
                lblTotal.Text =  totalCmd.ExecuteScalar().ToString();

                // Completed
                SqlCommand acceptedCmd = new SqlCommand(baseQuery, conn);
                acceptedCmd.Parameters.AddWithValue("@custId", _customerId);
                acceptedCmd.Parameters.AddWithValue("@status", "Completed");
                lblCompleted.Text = acceptedCmd.ExecuteScalar().ToString();
                acceptedCmd.Parameters.Clear();

                // Accepted
                acceptedCmd.Parameters.AddWithValue("@custId", _customerId);
                acceptedCmd.Parameters.AddWithValue("@status", "Accepted");
                lblAccepted.Text = acceptedCmd.ExecuteScalar().ToString();
                acceptedCmd.Parameters.Clear();

                //Decline
                acceptedCmd.Parameters.AddWithValue("@custId", _customerId);
                acceptedCmd.Parameters.AddWithValue("@status", "Decline");
                lblReject.Text = acceptedCmd.ExecuteScalar().ToString();
            }
        }


        //Logout Code
        private void pbBack_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new CustomerLogin().Show();
                this.Hide();
            }
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            //Edit User Profile 
            var editProfile = new userProfile(_customerId);
            editProfile.ShowDialog();

        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            var createJob = new CreateJobForms(_customerId);
            createJob.Show();

            //Reload Jobs after adding
            LoadCustomerJobs();

      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            MyJobs frm = new MyJobs(_customerId);
            frm.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadCustomerJobs();
        }

        private void dgvJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
} 
