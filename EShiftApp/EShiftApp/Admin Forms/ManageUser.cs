using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace EShiftApp.Admin_Forms
{
    public partial class ManageUser : Form
    {
 
        public ManageUser()
        {
            InitializeComponent();
            
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT CustomerID, FullName, Address, ContactNumber, Email FROM Customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvCustomers.DataSource = table;

                dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                dgvCustomers.Columns["Address"].HeaderText = "Address";
                dgvCustomers.Columns["ContactNumber"].HeaderText = "Phone";
                dgvCustomers.Columns["Email"].HeaderText = "Email";
            }

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            // Create an instance of the AdminAddCustomer form
            AdminAddCustomer addCustomerForm = new AdminAddCustomer();

            // Show it as a dialog (modal)
            addCustomerForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                var form = new AdminAddCustomer();
                form.ShowDialog();
                if (form.IsSaved)
                {
                    LoadCustomerData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                var confirm = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", customerId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomerData();
                    }
                }
            }


        }

        private void btnReload_Click(object sender, EventArgs e)
        {
       
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

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            TransportUnits frm = new TransportUnits();
            frm.Show();
            this.Hide();
        }
    }
    
}
