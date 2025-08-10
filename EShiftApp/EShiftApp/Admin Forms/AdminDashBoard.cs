using EShiftApp.Forms;
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
    public partial class AdminDashBoard : Form
    {
        private int _customerId;
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bntManageJobs_Click(object sender, EventArgs e)
        {
            Manage_jobs frm = new Manage_jobs();
            frm.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct frm = new ManageProduct();
            frm.Show();
            this.Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUser frm = new ManageUser();
            frm.Show();
            this.Hide();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports frm = new Reports();
            frm.Show();
            this.Hide();


        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            LoadAdminDashboardStats();
        }
        private void LoadAdminDashboardStats()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // =====================
                // Total Jobs
                // =====================
                string totalJobsQuery = "SELECT COUNT(*) FROM Jobs";
                SqlCommand cmd = new SqlCommand(totalJobsQuery, conn);
                lblTotalJobs.Text = cmd.ExecuteScalar().ToString();

                // =====================
                // Completed Jobs
                // =====================
                string completedJobsQuery = "SELECT COUNT(*) FROM Jobs WHERE Status = 'Completed'";
                cmd = new SqlCommand(completedJobsQuery, conn);
                lblCompletedJobs.Text = cmd.ExecuteScalar().ToString();

             

                // =====================
                // Rejected Jobs
                // =====================
                string declineJobsQuery = "SELECT COUNT(*) FROM Jobs WHERE Status = 'Decline'";
                cmd = new SqlCommand(declineJobsQuery, conn);
                lblDecline.Text = cmd.ExecuteScalar().ToString();

                // =====================
                // Total Products
                // =====================
                string totalProductsQuery = "SELECT COUNT(*) FROM Products";
                cmd = new SqlCommand(totalProductsQuery, conn);
                lblTotalProducts.Text = cmd.ExecuteScalar().ToString();

                // =====================
                // Total Transport Units
                // =====================
                string acceptedJobsQuery = "SELECT COUNT(*) FROM Jobs WHERE Status = 'Accepted'";
                cmd = new SqlCommand(acceptedJobsQuery, conn);
                lblAcceptedJobs.Text = cmd.ExecuteScalar().ToString();

                // =====================
                // Total Customers
                // =====================
                string totalCustomersQuery = "SELECT COUNT(*) FROM Customers";
                cmd = new SqlCommand(totalCustomersQuery, conn);
                lblTotalCustomers.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                new CustomerLogin().Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            TransportUnits frm = new TransportUnits();
            frm.Show();
            this.Hide();
        }
    }
}
