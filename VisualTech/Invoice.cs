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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
            LoadCategoriesIntoComboBox();


        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadCategoriesIntoComboBox()
        {
            List<ProductSubCategory> subcategories = new ProductSubCategoryService().GetAll();

            // Bind data to the ComboBox
            cmbCategory.DataSource = subcategories;
            cmbCategory.DisplayMember = "Category";  // The property to display
            cmbCategory.ValueMember = "UId";

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
    }
}
