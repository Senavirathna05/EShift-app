using System;
using System.Windows.Forms;

namespace EShiftApp.Admin_Forms
{
    public partial class CreateNewLoadForm : Form
    {
        private int _unitID;

        // Constructor accepting jobId
        public CreateNewLoadForm(int unitID)
        {
            InitializeComponent();
            _unitID = unitID;
        }

        private void CreateNewLoadForm_Load(object sender, EventArgs e)
        {
            // Set the Job ID textbox value (assuming you have a textbox named txtJobId)
            txtJobId.Text = _unitID.ToString();
        }
    }
}