using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShiftApp.Report
{
    public partial class JobReportViewer : Form
    {
        private ReportDocument rptDoc;
        private DateTime _fromDate;
        private DateTime _toDate;
        private string _status;
        public JobReportViewer()
        {
            InitializeComponent();
            this.Load += JobReportViewer_Load;
            this.FormClosed += JobsReportViewer_FormClosed;
        }
        public void SetFilters(DateTime fromDate, DateTime toDate, string status)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _status = status;
        }

        private void JobReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report", "JobReport.rpt");

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Report file not found: " + reportPath, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);

                // Set Crystal Report parameters
                rptDoc.SetParameterValue("from", _fromDate);
                rptDoc.SetParameterValue("to", _toDate);
                rptDoc.SetParameterValue("status", _status);

                // DB Login details (replace with your actual credentials)
                string dbUser = "your_db_username";
                string dbPass = "your_db_password";
                string dbServer = "your_sql_server";
                string dbName = "EShiftDB";

                rptDoc.SetDatabaseLogon(dbUser, dbPass, dbServer, dbName);

                crystalReportViewer1.ReportSource = rptDoc;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Jobs Report.\n\n" + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void JobsReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rptDoc != null)
            {
                rptDoc.Close();
                rptDoc.Dispose();
            }
        }
    }
}
