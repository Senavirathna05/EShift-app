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
    public partial class MyJobs : Form
    {
        
        private int _customerId;

        public MyJobs(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void MyJobs_Load(object sender, EventArgs e)
        {
            LoadCustomerJobs(); // Load all jobs for this customer
        }

        // Load Jobs of Customer
        private void LoadCustomerJobs()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT JobID, StartLocation, Destination, RequestedDate, Description, Status FROM Jobs WHERE CustomerID = @custId";
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            CustomerDashboard frm = new CustomerDashboard(_customerId);
            frm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);
            string status = dgvJobs.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status != "Accepted")
            {
                MessageBox.Show("Only Accepted jobs can be canceled.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to cancel this job?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Jobs WHERE JobID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", jobId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Job canceled.");
                LoadCustomerJobs();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvJobs.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status != "Accepted")
            {
                MessageBox.Show("Only Accepted jobs can be edited.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedJobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);

            EditJobsForms editForm = new EditJobsForms(selectedJobId);
            editForm.ShowDialog();
            LoadCustomerJobs(); // Refresh list after editing
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadCustomerJobs();
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            // Optional: Reload jobs
            LoadCustomerJobs();
        }

        private void dgvJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell clicks if needed
        }
    }

}

