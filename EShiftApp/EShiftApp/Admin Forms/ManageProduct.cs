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
    public partial class ManageProduct : Form
    {
        private int _customerId;
        public ManageProduct()
        {
            InitializeComponent();
        }
        private DataTable productTable = new DataTable();

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }
        private void LoadProductData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ProductID, ProductName, Description, Quantity, ProductType, Price FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                productTable.Clear();
                adapter.Fill(productTable);
                dgvProducts.DataSource = productTable;

                dgvProducts.Columns["ProductID"].HeaderText = "ID";
                dgvProducts.Columns["ProductName"].HeaderText = "Name";
                dgvProducts.Columns["Description"].HeaderText = "Description";
                dgvProducts.Columns["Quantity"].HeaderText = "Quantity";
                dgvProducts.Columns["ProductType"].HeaderText = "Product Type";
                dgvProducts.Columns["Price"].HeaderText = "Price (Rs.)";

                // Highlight out-of-stock products in red
                bool hasOutOfStock = false;
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty))
                    {
                        if (qty == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.DarkRed;
                            hasOutOfStock = true;
                        }
                        else if (qty <= 5)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightYellow; // low stock warning
                        }
                    }
                }

                // Show message if at least one product is out of stock
                if (hasOutOfStock)
                {
                    MessageBox.Show("⚠ Some products are out of stock!", "Product Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product deleted.");
                        LoadProductData();
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
                var form = new AddNewProduct(id);
                form.ShowDialog();
                if (form.IsSaved)
                    LoadProductData();
            }

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

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUser frm = new ManageUser();
            frm.Show();
            this.Hide();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var form = new AddNewProduct();
            form.ShowDialog();
            if (form.IsSaved)
                LoadProductData();
        }


    }
}
