using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTech
{
    public partial class InvoiceItemEditForm : Form
    {
        public string ProductNameValue { get; set; }
        public decimal UnitPriceValue { get; set; }
        public decimal QtyValue { get; set; }
        public decimal TotalPriceValue { get; set; }
        public string WarrantyValue { get; set; }
        public string BarcodeValue { get; set; }

        public InvoiceItemEditForm()
        {
            InitializeComponent();
        }

        private void InvoiceItemEditForm_Load(object sender, EventArgs e)
        {
            txtProductName.Text = ProductNameValue;
            txtUnitPrice.Text = UnitPriceValue.ToString("N2");
            txtQty.Text = QtyValue.ToString("N2");
            txtTotalPrice.Text = TotalPriceValue.ToString("N2");
            txtWarrenty.Text = WarrantyValue;
            txtBarcode.Text = BarcodeValue;

            txtTotalPrice.ReadOnly = true;

            txtUnitPrice.TextChanged += txtUnitPrice_TextChanged;
            txtQty.TextChanged += txtQty_TextChanged;
            txtUnitPrice.KeyPress += DecimalTextBox_KeyPress;
            txtQty.KeyPress += DecimalTextBox_KeyPress;
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal unitPrice = 0;
            decimal qty = 0;

            decimal.TryParse(txtUnitPrice.Text.Trim(), out unitPrice);
            decimal.TryParse(txtQty.Text.Trim(), out qty);

            txtTotalPrice.Text = (unitPrice * qty).ToString("N2");
        }

        private void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains("."))
                    e.Handled = true;
                return;
            }

            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal unitPrice = 0;
            decimal qty = 0;
            decimal totalPrice = 0;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product name is required.");
                txtProductName.Focus();
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out unitPrice))
            {
                MessageBox.Show("Invalid unit price.");
                txtUnitPrice.Focus();
                return;
            }

            if (!decimal.TryParse(txtQty.Text.Trim(), out qty))
            {
                MessageBox.Show("Invalid qty.");
                txtQty.Focus();
                return;
            }

            decimal.TryParse(txtTotalPrice.Text.Trim(), out totalPrice);

            ProductNameValue = txtProductName.Text.Trim();
            UnitPriceValue = unitPrice;
            QtyValue = qty;
            TotalPriceValue = totalPrice;
            WarrantyValue = txtWarrenty.Text.Trim();
            BarcodeValue = txtBarcode.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
