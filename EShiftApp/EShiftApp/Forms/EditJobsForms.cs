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

    public partial class EditJobsForms : Form
    {
        private int jobId;

        public EditJobsForms(int jobId)
        {
            InitializeComponent();
            this.jobId = jobId;
        }

        private void EditJobsForms_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Jobs WHERE JobID = @id", conn);
                cmd.Parameters.AddWithValue("@id", jobId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtStart.Text = reader["StartLocation"].ToString();
                    txtEnd.Text = reader["Destination"].ToString();
                    dtpJobDate.Value = Convert.ToDateTime(reader["RequestedDate"]);
                    txtDescription.Text = reader["Description"].ToString();
                }

                reader.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Input validation (optional but recommended)
            if (string.IsNullOrWhiteSpace(txtStart.Text) ||
                string.IsNullOrWhiteSpace(txtEnd.Text) ||
                string.IsNullOrWhiteSpace(dtpJobDate.Text)||
                string.IsNullOrWhiteSpace(txtDescription.Text)) 
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                UPDATE Jobs 
                SET 
                    StartLocation = @start,
                    Destination = @end,
                    RequestedDate = @date,
                    Description = @des
                WHERE JobID = @id", conn);

                cmd.Parameters.AddWithValue("@start", txtStart.Text.Trim());
                cmd.Parameters.AddWithValue("@end", txtEnd.Text.Trim());
                cmd.Parameters.AddWithValue("@date", dtpJobDate.Value);
                cmd.Parameters.AddWithValue("@des", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@id", jobId);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Job updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}

