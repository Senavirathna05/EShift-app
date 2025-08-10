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
    public partial class AddNewProduct : Form
    {
        private int productId = -1; // Stores Product ID if editing an existing product (-1 means new product)
        public bool IsSaved { get; private set; } = false; // Tracks whether the product was saved successfully

        // Default constructor (for adding a new product)
        public AddNewProduct()
        {
            InitializeComponent();
        }

        // Overloaded constructor (for editing an existing product)
        public AddNewProduct(int id) : this()
        {
            productId = id;
            LoadProductDetails(); // Load product data for editing
        }

        /// <summary>
        /// Loads product details from the database into form fields for editing.
        /// </summary>
        private void LoadProductDetails()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@id", productId);
                SqlDataReader reader = cmd.ExecuteReader();

                // Populate fields if product exists
                if (reader.Read())
                {
                    txtProductName.Text = reader["ProductName"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                    txtPrice.Text = reader["Price"].ToString();
                    txtProductType.Text = reader["ProductType"].ToString();
                    txtQuantity.Text = reader["Quantity"].ToString();
                    txtWeight.Text = reader["Weight"].ToString();
                }
            }
        }

        /// <summary>
        /// Handles saving a new product or updating an existing one.
        /// Includes validation for required fields and numeric values.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Read input values
            string name = txtProductName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string producttype = txtProductType.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string weightText = txtWeight.Text.Trim();

            // Validation: Required fields
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(producttype))
            {
                MessageBox.Show("Please fill in all required fields (Name, Price, Description, ProductType, Quantity).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation: Price must be a valid number
            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Invalid price value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation: Quantity must be a valid number
            if (!decimal.TryParse(quantityText, out decimal quantity))
            {
                MessageBox.Show("Invalid quantity value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd;

                // If productId is -1, this is a new product (INSERT)
                if (productId == -1)
                {
                    cmd = new SqlCommand(
                        "INSERT INTO Products (ProductName, Description, Price, ProductType, Quantity, Weight) VALUES (@n, @d, @p, @pt, @q, @w)", conn);
                }
                else
                {
                    // Otherwise, it's an existing product (UPDATE)
                    cmd = new SqlCommand(
                        "UPDATE Products SET ProductName=@n, Description=@d, Price=@p, ProductType=@pt, Quantity=@q, Weight=@w WHERE ProductID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", productId);
                }

                // Assign parameter values
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@d", description);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@pt", producttype);
                cmd.Parameters.AddWithValue("@q", quantity);
                cmd.Parameters.AddWithValue("@w", weightText);

                // Execute the insert or update
                cmd.ExecuteNonQuery();
            }

            // Notify user of success
            MessageBox.Show("Product saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsSaved = true;
            this.Close(); 
        }

        private void AddNewProduct_Load(object sender, EventArgs e)
        {
            
        }
    }
}
