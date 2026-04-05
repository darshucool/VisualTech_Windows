using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
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
                new ReportDataSource("dsInvoiceHeader", dtHeader));

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("dsInvoiceDetail", dtDetails));
            var headerModel = invoiceInfoService.GetInvoiceHeaderModelById(_invoiceId);

            string dueAmountText = "";
            if (headerModel != null && headerModel.ShowDueAmount)
            {
                dueAmountText = headerModel.DueAmount.ToString("N2");
            }
            if (dtHeader.Rows.Count > 0)
            {
                DataRow row = dtHeader.Rows[0];

                int invoiceTypeId = row["InvoiceTypeId"] != DBNull.Value
                    ? Convert.ToInt32(row["InvoiceTypeId"])
                    : 1;

                decimal grandTotal = row["GrandTotal"] != DBNull.Value
                    ? Convert.ToDecimal(row["GrandTotal"])
                    : 0m;

                decimal discount = row["Discount"] != DBNull.Value
                    ? Convert.ToDecimal(row["Discount"])
                    : 0m;

                decimal paidAmount = row["PaidAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["PaidAmount"])
                    : 0m;

                

                string heading = invoiceTypeId == 2 ? "INVOICE" : "ESTIMATE";

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("Heading", heading),
                    new ReportParameter("GrandTotal", grandTotal.ToString("N2")),
                    new ReportParameter("Discount", discount.ToString("N2")),
                    new ReportParameter("PaidAmount", paidAmount.ToString("N2")),
                    new ReportParameter("DueAmount", dueAmountText)
                };

                reportViewer1.LocalReport.SetParameters(parameters);
            }

            reportViewer1.RefreshReport();
        }
    }
}