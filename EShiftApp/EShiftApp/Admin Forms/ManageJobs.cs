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
    public partial class Manage_jobs : Form
    {
       
        public Manage_jobs()
        {
            InitializeComponent();

        }
        private DataTable jobTable = new DataTable();

        private void Manage_jobs_Load(object sender, EventArgs e)
        {
            LoadJobData();
        }
        private void LoadJobData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT JobID, CustomerID, StartLocation, Destination, RequestedDate, Description, Status FROM Jobs";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                jobTable.Clear();
                adapter.Fill(jobTable);
                dgvJobs.DataSource = jobTable;

                // Color-code job rows by status
                foreach (DataGridViewRow row in dgvJobs.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    if (status == "Completed")
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (status == "Decline")
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }

                // Friendly column headers
                dgvJobs.Columns["JobID"].HeaderText = "Job ID";
                dgvJobs.Columns["CustomerID"].HeaderText = "Customer ID";
                dgvJobs.Columns["StartLocation"].HeaderText = "From";
                dgvJobs.Columns["Destination"].HeaderText = "To";
                dgvJobs.Columns["RequestedDate"].HeaderText = "Date";
                dgvJobs.Columns["Description"].HeaderText = "Job Description";
                dgvJobs.Columns["Status"].HeaderText = "Status";
            }

        }

        private void UpdateJobStatus(int jobId, string newStatus)
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Get current status
                SqlCommand checkCmd = new SqlCommand("SELECT Status FROM Jobs WHERE JobID = @id", conn);
                checkCmd.Parameters.AddWithValue("@id", jobId);
                string currentStatus = checkCmd.ExecuteScalar()?.ToString();

                if (currentStatus == "Decline" && newStatus == "Completed")
                {
                    MessageBox.Show("You can't Complete a job that has already been Decline.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStatus == "Completed" && newStatus == "Decline")
                {
                    MessageBox.Show("You can't Reject a job that has already been Completed.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStatus == "Completed" && newStatus == "Completed")
                {
                    MessageBox.Show("Job is already Completed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (currentStatus == "Decline" && newStatus == "Decline")
                {
                    MessageBox.Show("Job is already Decline.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // All other transitions are allowed
                SqlCommand cmd = new SqlCommand("UPDATE Jobs SET Status = @status WHERE JobID = @id", conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", jobId);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Job marked as {newStatus}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJobData();
            }
        }

        private void ApplyJobFilters()
        {
            string status = cmbJobfilter.SelectedItem?.ToString() ?? "All";

            string filter = "";

            if (status != "All")
            {
                if (!string.IsNullOrEmpty(filter))
                    filter = $"({filter}) AND ";

                filter += $"Status = '{status}'";
            }

            DataView dv = new DataView(jobTable);
            dv.RowFilter = filter;
            dgvJobs.DataSource = dv;
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnManageJobs_Click(object sender, EventArgs e)
        {

        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct frm = new ManageProduct();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashBoard frm = new AdminDashBoard();
            frm.Show();
            this.Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUser frm = new ManageUser();
            frm.Show();
            this.Hide();
        }

        private void cmbJobfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyJobFilters();

        }

        private void btnJobCancel_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to decline this job?", "Confirm Decline", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);
                    UpdateJobStatus(jobId, "Decline");
                }
            }
        }

        private void btnJobAccept_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to accept this job?", "Confirm Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);
                    UpdateJobStatus(jobId, "Completed");
                }
            }
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            var form = new AddNewJobAdmin();
            form.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadJobData();
        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            TransportUnits frm = new TransportUnits();
            frm.Show();
            this.Hide();
        }
    }
}
