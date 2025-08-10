using EShiftApp.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShiftApp.Admin_Forms
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadStatuses();
        }
        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Rejected");
            cmbStatus.Items.Add("Completed");
            cmbStatus.SelectedIndex = 0;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpForm.Value;
            DateTime toDate = dtpTo.Value;
            string status = cmbStatus.SelectedItem?.ToString();

            var viewer = new JobReportViewer();
            viewer.SetFilters(fromDate, toDate, status);
            viewer.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            TransportUnits frm = new TransportUnits();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashBoard frm = new AdminDashBoard();
            frm.Show();
            this.Hide();
        }

        private void bntManageJobs_Click(object sender, EventArgs e)
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
    }
}
