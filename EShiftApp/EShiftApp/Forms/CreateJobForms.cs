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
    public partial class CreateJobForms : Form
    {
        private int _customerId;
        private DataTable productTable = new DataTable();
        public CreateJobForms(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStart.Text) || string.IsNullOrWhiteSpace(txtEnd.Text))
            {
                MessageBox.Show("Start and End location are required");
                return;
            }
            //  Get connection string
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Jobs (CustomerID, StartLocation, Destination, RequestedDate, Status, Description)" + "VALUES (@cust,@start,@end,@date,'Pending',@des)", conn);

                cmd.Parameters.AddWithValue("@cust", _customerId);
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
                cmd.Parameters.AddWithValue("@date", dtpJobDate.Value);
                cmd.Parameters.AddWithValue("@des", txtDescription.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Job Request Submitted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                

            }
        }
        private void CreateJobForms_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
