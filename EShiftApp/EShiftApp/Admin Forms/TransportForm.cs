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
    public partial class TransportForm : Form
    {
        private int? _unitId = null;
        public bool IsSaved = false;
        public TransportForm() // Add mode
        {
            InitializeComponent();
        }

        public TransportForm(int unitId) // Edit mode
        {
            InitializeComponent();
            _unitId = unitId;
            LoadTransportData();
        }
        private void LoadTransportData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM TransportUnits WHERE UnitID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _unitId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtLorryNumber.Text = reader["LorryNumber"].ToString();
                    txtDriverName.Text = reader["DriverName"].ToString();
                    txtAssistantName.Text = reader["AssistantName"].ToString();
                    txtLorryNumber.Text = reader["ContainerDetails"].ToString();
                }
            }
        }


        private void TransportForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLorryNumber.Text) ||
                string.IsNullOrWhiteSpace(txtDriverName.Text) ||
                string.IsNullOrWhiteSpace(txtAssistantName.Text) ||
                string.IsNullOrWhiteSpace(txtContainerDetails.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["EShiftDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query;
                SqlCommand cmd;

                if (_unitId == null)
                {
                    query = "INSERT INTO TransportUnits (LorryNumber, DriverName, AssistantName, ContainerDetails) VALUES (@lorry, @driver, @assistant, @container)";
                    cmd = new SqlCommand(query, conn);
                }
                else
                {
                    query = "UPDATE TransportUnits SET LorryNumber=@lorry, DriverName=@driver, AssistantName=@assistant, ContainerDetails=@container WHERE UnitID=@id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _unitId);
                }

                cmd.Parameters.AddWithValue("@lorry", txtLorryNumber.Text);
                cmd.Parameters.AddWithValue("@driver", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@assistant", txtAssistantName.Text);
                cmd.Parameters.AddWithValue("@container", txtContainerDetails.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Transport unit saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                this.Close();
            }

        }
    }
}
