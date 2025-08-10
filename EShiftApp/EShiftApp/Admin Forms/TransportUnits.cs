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

    public partial class TransportUnits : Form
    {
        private int _unitID;
        public TransportUnits()
        {
            InitializeComponent();
        }

        private void TransportUnits_Load(object sender, EventArgs e)
        {
            LoadTransportData();
        }
        private void LoadTransportData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM TransportUnits";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTransportUnits.DataSource = table;

                dgvTransportUnits.Columns["UnitID"].HeaderText = "ID";
                dgvTransportUnits.Columns["LorryNumber"].HeaderText = "Lorry No.";
                dgvTransportUnits.Columns["DriverName"].HeaderText = "Driver";
                dgvTransportUnits.Columns["AssistantName"].HeaderText = "Assistant";
                dgvTransportUnits.Columns["ContainerDetails"].HeaderText = "CO-ID No.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransportUnits.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTransportUnits.SelectedRows[0].Cells["UnitID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this transport unit?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM TransportUnits WHERE UnitID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transport unit deleted.");
                        LoadTransportData();
                    }
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTransportUnits.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTransportUnits.SelectedRows[0].Cells["UnitID"].Value);
                var form = new TransportForm(id);
                form.ShowDialog();
                if (form.IsSaved)
                    LoadTransportData();
            }

        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
                var form = new TransportForm();
                form.ShowDialog();
                if (form.IsSaved)
                 LoadTransportData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadTransportData();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashBoard frm = new AdminDashBoard();
            frm.Show();
            this.Hide();
        }

        private void btnManageJobs_Click(object sender, EventArgs e)
        {
            Manage_jobs frm = new Manage_jobs();
            frm.Show();
            this.Hide();
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

        private void btnCreateNewLoad_Click(object sender, EventArgs e)
        {
            if (dgvTransportUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transport unit with a Job ID.");
                return;
            }

            // Get JobID from the selected row
            int unitId = Convert.ToInt32(dgvTransportUnits.SelectedRows[0].Cells["UnitID"].Value);


            // Open CreateNewLoadForm and pass jobId
            var createLoadForm = new CreateNewLoadForm(_unitID);
            createLoadForm.ShowDialog();
        }
    }
}
