using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualTech.DataAccess;

namespace VisualTech
{
    public partial class InvoiceReportForm : Form
    {
        private readonly int _invoiceId;
        private ReportViewer reportViewer1;

        public InvoiceReportForm(int invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            InitializeReportViewer();
        }

        private void InitializeReportViewer()
        {
            reportViewer1 = new ReportViewer();
            reportViewer1.Name = "reportViewer1";
            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);
        }

        private void InvoiceReportForm_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            InvoiceInfoService invoiceInfoService = new InvoiceInfoService();
            InvoiceDetailService invoiceDetailService = new InvoiceDetailService();

            DataTable dtHeader = invoiceInfoService.GetInvoiceHeaderById(_invoiceId);
            DataTable dtDetails = invoiceDetailService.GetInvoiceDetailsByInvoiceId(_invoiceId);

            string reportPath = Path.Combine(Application.StartupPath, "RDLC", "Report1.rdlc");

            if (!File.Exists(reportPath))
            {
                MessageBox.Show("RDLC file not found:\n" + reportPath);
                return;
            }

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = reportPath;

            reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("dsInvoiceHeader", dtHeader));

            reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("dsInvoiceDetail", dtDetails));

            reportViewer1.RefreshReport();
        }
    }
}
