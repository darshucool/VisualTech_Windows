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
using VisualTech.Domain;

namespace VisualTech
{
    public partial class frmCustomerPayment : Form
    {
        private readonly CustomerPaymentService _paymentService;

        public frmCustomerPayment()
        {
            InitializeComponent();
            _paymentService = new CustomerPaymentService();
        }

        private void CustomerPayment_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            SetupGrid();
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
        private void LoadCustomers()
        {
            var customers = _paymentService.GetCustomers();

            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "CutomerName";
            cmbCustomer.ValueMember = "UId";
            cmbCustomer.SelectedIndex = -1;
        }
        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Increase font size
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 32;
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != -1 && cmbCustomer.SelectedValue != null)
            {
                int customerId;

                if (int.TryParse(cmbCustomer.SelectedValue.ToString(), out customerId))
                {
                    LoadPayments(customerId);
                    ShowCustomerBalance(customerId);
                }
            }
        }
        private void LoadPayments(int customerId)
        {
            DataTable dt = _paymentService.GetPaymentsByCustomerId(customerId);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Contains("UId"))
                dataGridView1.Columns["UId"].HeaderText = "ID";

            if (dataGridView1.Columns.Contains("Date"))
            {
                dataGridView1.Columns["Date"].HeaderText = "Payment Date";
                dataGridView1.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            if (dataGridView1.Columns.Contains("Amount"))
            {
                dataGridView1.Columns["Amount"].HeaderText = "Payment Amount";
                dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "N2";
            }
        }
        private void ShowCustomerBalance(int customerId)
        {
            decimal balance = _paymentService.GetCustomerCurrentBalance(customerId);
            txtBalance.Text = balance.ToString("N2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCustomer.SelectedValue == null)
                {
                    MessageBox.Show("Please select a customer.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPayment.Text))
                {
                    MessageBox.Show("Please enter payment amount.");
                    return;
                }

                decimal amount;
                if (!decimal.TryParse(txtPayment.Text, out amount))
                {
                    MessageBox.Show("Invalid amount.");
                    return;
                }

                CustomerPayment payment = new CustomerPayment
                {
                    CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue),
                    Amount = amount,
                    Date = dateTimePicker2.Value
                };

                CustomerPaymentService service = new CustomerPaymentService();
                service.SavePaymentAndReduceBalance(payment);

                MessageBox.Show("Payment saved successfully.");

                LoadPayments(Convert.ToInt32(cmbCustomer.SelectedValue));
                ShowCustomerBalance(Convert.ToInt32(cmbCustomer.SelectedValue));
                txtPayment.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
