using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualTech.DataAccess;
using VisualTech.Domain;

namespace VisualTech
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
            LoadCategoriesIntoComboBox();
            SetupInvoiceGrid();

        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                LoadProductGrid();
                return;
            }

            ProductCategoryCombo selectedCategory = cmbCategory.SelectedItem as ProductCategoryCombo;

            if (selectedCategory == null)
            {
                LoadProductGrid();
                return;
            }

            if (selectedCategory.CategoryType == "MAIN")
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@CategoryId", selectedCategory.UId)
        };

                LoadProductGrid(parameters);
            }
            else if (selectedCategory.CategoryType == "SUB")
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@SubCategoryId", selectedCategory.UId)
        };

                LoadProductGrid(parameters);
            }
            else
            {
                LoadProductGrid();
            }
        }
        private void EditSelectedInvoiceRow()
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.IsNewRow)
                return;

            DataGridViewRow row = dataGridView2.CurrentRow;

            InvoiceItemEditForm editForm = new InvoiceItemEditForm();

            editForm.ProductNameValue = Convert.ToString(row.Cells["ProductName"].Value);
            editForm.UnitPriceValue = GetDecimalCellValue(row.Cells["UnitPrice"].Value);
            editForm.QtyValue = GetDecimalCellValue(row.Cells["Qty"].Value);
            editForm.TotalPriceValue = GetDecimalCellValue(row.Cells["TotalPrice"].Value);
            editForm.WarrantyValue = Convert.ToString(row.Cells["Warranty"].Value);
            editForm.BarcodeValue = Convert.ToString(row.Cells["Barcode"].Value);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                row.Cells["ProductName"].Value = editForm.ProductNameValue;
                row.Cells["UnitPrice"].Value = editForm.UnitPriceValue.ToString("N2");
                row.Cells["Qty"].Value = editForm.QtyValue.ToString("N2");
                row.Cells["TotalPrice"].Value = editForm.TotalPriceValue.ToString("N2");
                row.Cells["Warranty"].Value = editForm.WarrantyValue;
                row.Cells["Barcode"].Value = editForm.BarcodeValue;

                CalculateGrossTotal();
            }
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedInvoiceRow();
            }
        }
        private decimal GetDecimalCellValue(object value)
        {
            decimal result = 0;
            decimal.TryParse(Convert.ToString(value), out result);
            return result;
        }
        private void Invoice_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadCategories();
            LoadProductGrid();
            radInvoice.Checked = true;


            txtBalance.Text = "0.00";
            txtUnitPrice.KeyPress += DecimalTextBox_KeyPress;
            txtQty.KeyPress += DecimalTextBox_KeyPress;

            txtUnitPrice.TextChanged += txtUnitPrice_TextChanged;
            txtQty.TextChanged += txtQty_TextChanged;

            txtPrice.ReadOnly = true;
            dataGridView2.KeyDown += dataGridView2_KeyDown;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            txtGrossTotal.TextChanged += txtGrossTotal_TextChanged;
            txtTax.TextChanged += txtTax_TextChanged;
            txtDiscount.TextChanged += txtDiscount_TextChanged;

            txtNetPrice.ReadOnly = true;
        }
        private void CalculateNetPrice()
        {
            if (string.IsNullOrWhiteSpace(txtGrossTotal.Text))
            {
                txtNetPrice.Text = "";
                return;
            }

            decimal grossTotal = 0;
            decimal tax = 0;
            decimal discount = 0;

            decimal.TryParse(txtGrossTotal.Text.Trim(), out grossTotal);
            decimal.TryParse(txtTax.Text.Trim(), out tax);
            decimal.TryParse(txtDiscount.Text.Trim(), out discount);

            decimal netPrice = grossTotal + tax - discount;

            txtNetPrice.Text = netPrice.ToString("N2");
        }
        private void txtGrossTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateNetPrice();
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            CalculateNetPrice();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateNetPrice();
        }
        private void LoadCategoriesIntoComboBox()
        {
            List<ProductSubCategory> subcategories = new ProductSubCategoryService().GetAll();

            // Bind data to the ComboBox
            cmbCategory.DataSource = subcategories;
            cmbCategory.DisplayMember = "Category";  // The property to display
            cmbCategory.ValueMember = "UId";

        }
        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                DeleteSelectedInvoiceRow();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EditSelectedInvoiceRow();
            }
        }
        private void DeleteSelectedInvoiceRow()
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.IsNewRow)
                return;

            string productName = Convert.ToString(dataGridView2.CurrentRow.Cells["ProductName"].Value);

            DialogResult result = MessageBox.Show(
                "Do you want to delete this item?\n\n" + productName,
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                CalculateGrossTotal();
                CalculateNetPrice();
            }
        }
        private void LoadData()
        {
            // Replace this with your method to load data into a DataTable
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;

            DataTable dataTable = new ProductService().LoadDataTable();
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadCustomers();
            LoadCategories();
        }
        private void LoadProductGrid(SqlParameter[] parameters = null)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;

            DataTable dataTable = new ProductService().LoadDataTable(parameters);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.ColumnHeadersHeight = 35;
        }
        private void LoadCustomerBalance()
        {
            if (cmbCustomer.SelectedItem == null)
            {
                txtBalance.Text = "0.00";
                return;
            }

            Customer selectedCustomer = cmbCustomer.SelectedItem as Customer;

            if (selectedCustomer != null)
            {
                txtBalance.Text = selectedCustomer.CurrentBalance.ToString("N2");
            }
            else
            {
                txtBalance.Text = "0.00";
            }
        }
        private void LoadCustomers()
        {
            var customers = new CustomerService().GetAllActive();

            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "CutomerName";
            cmbCustomer.ValueMember = "UId";
            cmbCustomer.SelectedIndex = -1;
            cmbCustomer.SelectedIndexChanged -= cmbCustomer_SelectedIndexChanged;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerBalance();
        }
        private void LoadCategories()
        {
            var categories = new ProductCategoryService().GetCategorySubCategoryCombo();

            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "DisplayName";
            cmbCategory.ValueMember = "UId"; // this is ProductSubCategory UId
            cmbCategory.SelectedIndex = -1;

            cmbCategory.SelectedIndexChanged -= cmbCategory_SelectedIndexChanged;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
        }
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new ProductService().LoadDataTableBySearch(txtProductName.Text);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbCustomer.Text = "";
            txtBalance.Text = "0.00";
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
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }
        private void SetupInvoiceGrid()
        {
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void CalculateLineTotal()
        {
            if (string.IsNullOrWhiteSpace(txtUnitPrice.Text) || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                txtPrice.Text = "";
                return;
            }

            decimal unitPrice = 0;
            decimal qty = 0;

            decimal.TryParse(txtUnitPrice.Text.Trim(), out unitPrice);
            decimal.TryParse(txtQty.Text.Trim(), out qty);

            txtPrice.Text = (unitPrice * qty).ToString("N2");
        }
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateLineTotal();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalculateLineTotal();
        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProduct.Text))
                {
                    MessageBox.Show("Please enter product name.");
                    txtProduct.Focus();
                    return;
                }

                decimal unitPrice = 0;
                decimal qty = 0;

                if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out unitPrice))
                {
                    MessageBox.Show("Invalid unit price.");
                    txtUnitPrice.Focus();
                    return;
                }

                if (!decimal.TryParse(txtQty.Text.Trim(), out qty))
                {
                    MessageBox.Show("Invalid quantity.");
                    txtQty.Focus();
                    return;
                }

                decimal totalPrice = unitPrice * qty;

                object productId = txtProduct.Tag != null ? txtProduct.Tag : DBNull.Value;

                dataGridView2.Rows.Add(
                    productId,                    // UId
                    txtWarrenty.Text.Trim(),      // Warranty
                    txtBarcode.Text.Trim(),       // Barcode
                    txtProduct.Text.Trim(),       // ProductName
                    unitPrice.ToString("N2"),     // UnitPrice
                    qty.ToString("N2"),           // Qty
                    totalPrice.ToString("N2")     // TotalPrice
                );

                CalculateGrossTotal();
                ClearItemFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message);
            }
        }
        private void CalculateGrossTotal()
        {
            decimal grossTotal = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["TotalPrice"].Value != null)
                {
                    decimal rowTotal;
                    if (decimal.TryParse(row.Cells["TotalPrice"].Value.ToString(), out rowTotal))
                    {
                        grossTotal += rowTotal;
                    }
                }
            }

            txtGrossTotal.Text = grossTotal.ToString("N2");
            CalculateNetPrice();

        }
        private void ClearItemFields()
        {
            txtProduct.Text = "";
            txtProduct.Tag = null;
            txtUnitPrice.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtWarrenty.Text = "";
            txtBarcode.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0)
                {
                    MessageBox.Show("Please add invoice items.");
                    return;
                }

                decimal grossTotal = 0;
                decimal discount = 0;
                decimal netTotal = 0;
                decimal paidAmount = 0;

                decimal.TryParse(txtGrossTotal.Text.Trim(), out grossTotal);
                decimal.TryParse(txtDiscount.Text.Trim(), out discount);
                decimal.TryParse(txtNetPrice.Text.Trim(), out netTotal);
                decimal.TryParse(txtPayment.Text.Trim(), out paidAmount);

                if (netTotal <= 0)
                {
                    MessageBox.Show("Invalid net total.");
                    return;
                }

                if (paidAmount < 0)
                {
                    MessageBox.Show("Invalid payment amount.");
                    return;
                }

                if (paidAmount > netTotal)
                {
                    MessageBox.Show("Paid amount cannot be greater than net total.");
                    return;
                }

                int customerId = 0;
                string customerName = "";

                if (cmbCustomer.SelectedItem is Customer selectedCustomer)
                {
                    customerId = selectedCustomer.UId;
                    customerName = selectedCustomer.CutomerName;
                }
                else
                {
                    customerName = txtCustomerName.Text.Trim();

                    if (string.IsNullOrWhiteSpace(customerName))
                    {
                        MessageBox.Show("Please select a customer or enter customer name.");
                        txtCustomerName.Focus();
                        return;
                    }

                    customerId = 0;
                }

                InvoiceInfoService invoiceInfoService = new InvoiceInfoService();
                InvoiceDetailService invoiceDetailService = new InvoiceDetailService();
                CustomerService customerService = new CustomerService();

                int nextInvoiceNo = invoiceInfoService.GetNextInvoiceNo();

                InvoiceInfo invoice = new InvoiceInfo
                {
                    CustomerId = customerId,
                    InvoiceDate = DateTime.Now,
                    Status = 0,
                    Active = true,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    InvoiceTypeId = 1,
                    InvoiceNo = nextInvoiceNo.ToString(),
                    InvoiceLine1 = "",
                    InvoiceLine2 = "",
                    Discount = discount,
                    Total = grossTotal,
                    GrandTotal = netTotal,
                    CustomerName = customerName,
                    PaidAmount = paidAmount
                };

                int invoiceId = invoiceInfoService.Insert(invoice);

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = 0;
                    decimal unitPrice = 0;
                    decimal qty = 0;
                    decimal totalPrice = 0;

                    if (row.Cells["UId"].Value != null)
                    {
                        int.TryParse(Convert.ToString(row.Cells["UId"].Value), out productId);
                    }

                    decimal.TryParse(Convert.ToString(row.Cells["UnitPrice"].Value), out unitPrice);
                    decimal.TryParse(Convert.ToString(row.Cells["Qty"].Value), out qty);
                    decimal.TryParse(Convert.ToString(row.Cells["TotalPrice"].Value), out totalPrice);

                    InvoiceDetail detail = new InvoiceDetail
                    {
                        InvoiceId = invoiceId,
                        ProductId = productId,
                        ItemName = Convert.ToString(row.Cells["ProductName"].Value),
                        Warranty = Convert.ToString(row.Cells["Warranty"].Value),
                        UnitPrice = unitPrice,
                        TotalPrice = totalPrice,
                        BarcodeDetail = Convert.ToString(row.Cells["Barcode"].Value),
                        Active = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        Quantity = qty,
                        Qty = qty
                    };

                    invoiceDetailService.Insert(detail);
                }

                if (customerId > 0)
                {
                    Customer customer = customerService.GetById(customerId);

                    if (customer != null)
                    {
                        decimal remainingAmount = netTotal - paidAmount;

                        if (remainingAmount > 0)
                        {
                            decimal newBalance = customer.CurrentBalance + remainingAmount;
                            customerService.UpdateCurrentBalance(customer.UId, newBalance, "admin");
                            txtBalance.Text = newBalance.ToString("N2");
                        }
                    }
                }

                MessageBox.Show("Invoice saved successfully.");
                    InvoiceReportForm reportForm = new InvoiceReportForm(invoiceId);
                reportForm.ShowDialog();
                ClearInvoiceForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving invoice: " + ex.Message);
            }
        }
        private void ClearInvoiceForm()
        {
            cmbCustomer.SelectedIndex = -1;
            txtCustomerName.Text = "";
            txtBalance.Text = "0.00";

            txtProduct.Text = "";
            txtProduct.Tag = null;
            txtUnitPrice.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtWarrenty.Text = "";
            txtBarcode.Text = "";

            txtGrossTotal.Text = "";
            txtTax.Text = "";
            txtDiscount.Text = "";
            txtNetPrice.Text = "";
            txtPayment.Text = "";

            dataGridView2.Rows.Clear();
        }
    }
}
