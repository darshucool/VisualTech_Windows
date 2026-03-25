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
    public partial class frmProduct : Form
    {
        private int? _editingUid = null; // Store the uid of the record being edited
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Font = new Font("Arial", 12);
            AddButtonColumns();
            LoadData();
            LoadCategoriesIntoComboBox();
        }
        private void LoadCategoriesIntoComboBox()
        {
            // Retrieve the data from the repository
            ProductCategoryService service = new ProductCategoryService();
            List<ProductCategory> categories = new ProductCategoryService().GetAll();

            // Bind data to the ComboBox
            cmbCat.DataSource = categories;
            cmbCat.DisplayMember = "Category";  // The property to display
            cmbCat.ValueMember = "UId";         // The property to use as the value

            
            List<ProductSubCategory> subcategories = new ProductSubCategoryService().GetAll();

            // Bind data to the ComboBox
            cmbCat.DataSource = subcategories;
            cmbCat.DisplayMember = "Category";  // The property to display
            cmbCat.ValueMember = "UId";

            List<Brand> brands = new BrandService().GetAll();

            // Bind data to the ComboBox
            cmbBrand.DataSource = brands;
            cmbBrand.DisplayMember = "BrandName";  // The property to display
            cmbBrand.ValueMember = "UId";
        }
        private void AddButtonColumns()
        {
            // Create Edit button column
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(editButtonColumn);

            // Create Remove button column
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Remove",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(removeButtonColumn);
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a button column
            if (e.RowIndex >= 0 && (dataGridView1.Columns[e.ColumnIndex].Name == "Edit" || dataGridView1.Columns[e.ColumnIndex].Name == "Remove"))
            {
                // Get the UId of the selected row
                int uid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UId"].Value);

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    // Call your edit method here
                    EditRecord(uid);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Remove")
                {
                    // Call your remove method here
                    RemoveRecord(uid);
                }
            }
        }

        private void EditRecord(int uid)
        {
            // Set _editingUid to the uid of the record being edited
            _editingUid = uid;

            // Fetch record details and load them into the TextBox
            Product product = new ProductService().GetById(uid);
            if (product != null)
            {
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtSellingPrice.Text = product.SellingPrice.ToString();
                txtCostPrice.Text = product.CostPrice.ToString();
                txtMRP.Text = product.MRPPrice.ToString();
                cmbCat.SelectedValue = product.CategoryId;
                cmbBrand.SelectedValue = product.BrandUId;
                cmbSubCat.SelectedValue = product.SubCatUId;
                MessageBox.Show($"Loaded record with UId: {uid} for editing.");
            }
            else
            {
                MessageBox.Show("Record not found.");
            }
        }


        private void RemoveRecord(int uid)
        {
            // Ask for confirmation before removing
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                new ProductService().DeactivateById(uid, "admin");
                LoadData();
                // Refresh the DataGridView after deletion

            }
        }
        private void LoadData()
        {
            // Replace this with your method to load data into a DataTable

            DataTable dataTable = new ProductService().LoadDataTable();
            dataGridView1.DataSource = dataTable;
        }
        public Product AssignValues()
        {
            Product product = new Product();
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.CostPrice = decimal.Parse(txtCostPrice.Text);
            product.SellingPrice = decimal.Parse(txtSellingPrice.Text);
            product.MRPPrice = decimal.Parse(txtMRP.Text);
            product.CategoryId= (int)cmbCat.SelectedValue;
            product.SubCatUId= (int)cmbSubCat.SelectedValue;
            product.BrandUId= (int)cmbBrand.SelectedValue;
            product.CreatedDate=DateTime.Now;
            product.CreatedBy = "admin";
            product.ModifiedDate = DateTime.Now;
            product.ModifiedBy = "admin";
            product.Active = true;
            return product;
         }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string description = txtDescription.Text.Trim();
                string costPriceText = txtCostPrice.Text.Trim();
                string sellingPriceText = txtSellingPrice.Text.Trim();
                string mrpText = txtMRP.Text.Trim();

                // Validate Name
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a category name.");
                    return;
                }

                // Validate Cost Price
                if (string.IsNullOrEmpty(costPriceText) || !decimal.TryParse(costPriceText, out decimal costPrice) || costPrice < 0)
                {
                    MessageBox.Show("Please enter a valid cost price (non-negative number).");
                    return;
                }

                // Validate Selling Price
                if (string.IsNullOrEmpty(sellingPriceText) || !decimal.TryParse(sellingPriceText, out decimal sellingPrice) || sellingPrice < 0)
                {
                    MessageBox.Show("Please enter a valid selling price (non-negative number).");
                    return;
                }

                // Validate MRP
                if (string.IsNullOrEmpty(mrpText) || !decimal.TryParse(mrpText, out decimal mrp) || mrp < 0)
                {
                    MessageBox.Show("Please enter a valid MRP (non-negative number).");
                    return;
                }
                if (cmbCat.SelectedItem == null)
                {
                    MessageBox.Show("Please select a category.");
                    return;
                }
                // Validate SubCategory Selection
                if (cmbSubCat.SelectedItem == null)
                {
                    MessageBox.Show("Please select a subcategory.");
                    return;
                }

                // Validate Brand Selection
                if (cmbBrand.SelectedItem == null)
                {
                    MessageBox.Show("Please select a brand.");
                    return;
                }

                // Assign values to the category
                Product product = AssignValues();

                if (_editingUid.HasValue)
                {
                    // Update existing record
                    product.UId = _editingUid.Value;
                    new ProductService().Update(product);
                    MessageBox.Show("Product successfully updated");
                    _editingUid = null; // Reset after update
                }
                else
                {
                    // Insert new record
                    new ProductService().Insert(product);
                    MessageBox.Show("Product successfully added");
                }

                // Clear the form and reload data
                txtName.Clear();
                txtCostPrice.Clear();
                txtSellingPrice.Clear();
                txtMRP.Clear();
                txtDescription.Clear();
                cmbSubCat.SelectedIndex = -1;
                cmbBrand.SelectedIndex = -1;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
