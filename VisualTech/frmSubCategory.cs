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
    public partial class frmSubCategory : Form
    {
        private int? _editingUid = null; // Store the uid of the record being edited
        public frmSubCategory()
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
            ProductSubCategory category = new ProductSubCategoryService().GetById(uid);
            if (category != null)
            {
                txtCategory.Text = category.Category;
                cmbCat.SelectedValue = category.MainCategoryUId;
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
                new ProductSubCategoryService().DeactivateById(uid, "admin");
                LoadData();
                // Refresh the DataGridView after deletion

            }
        }
        private void LoadData()
        {
            // Replace this with your method to load data into a DataTable

            DataTable dataTable = new ProductCategoryService().LoadDataTable();
            dataGridView1.DataSource = dataTable;
        }
        public ProductSubCategory AssignValues()
        {
            ProductSubCategory productCategory = new ProductSubCategory();
            productCategory.MainCategoryUId= (int)cmbCat.SelectedValue;
            productCategory.Category= txtCategory.Text.Trim();
            productCategory.CreatedDate=DateTime.Now;
            productCategory.CreatedBy = "admin";
            productCategory.ModifiedDate = DateTime.Now;
            productCategory.ModifiedBy = "admin";
            productCategory.Active = true;
            return productCategory;
         }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtCategory.Text.Trim(); // Trim any leading/trailing whitespace

                // Validate that the name is not empty
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a category name."); // Show message if the name is empty
                    return; // Exit the method early
                }
                if (_editingUid.HasValue)
                {
                    // Update record if _editingUid is set
                    ProductSubCategory category = AssignValues();
                    category.UId = _editingUid.Value; // Assign the UId of the record being edited
                    new ProductSubCategoryService().Update(category);

                    MessageBox.Show("Sub Category successfully updated");
                    _editingUid = null; // Reset _editingUid after updating
                }
                else
                {
                    // Insert new record if no record is being edited
                    ProductSubCategory productCategory = AssignValues();
                    new ProductSubCategoryService().Insert(productCategory);

                    MessageBox.Show("Sub Category successfully added");
                }

                txtCategory.Clear(); // Clear TextBox after insert/update
                LoadData(); // Reload data in DataGridView
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
