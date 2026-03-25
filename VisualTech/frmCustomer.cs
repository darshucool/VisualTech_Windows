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
    public partial class frmCustomer : Form
    {
        private int? _editingUid = null; // Store the uid of the record being edited
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Font = new Font("Arial", 12);
            AddButtonColumns();
            LoadData();
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
            Customer customer = new CustomerService().GetById(uid);
            if (customer != null)
            {
                txtCompanyName.Text = customer.CompanyName;
                txtCutomerName.Text = customer.CutomerName;
                txtOfficeAddress.Text = customer.OfficeAddress;
                txtHomeAddress.Text = customer.HomeAddress;
                txtMobileNo.Text = customer.MobileNo;
                txtLandline.Text = customer.Landline;
                txtEmail.Text = customer.Email;
                txtCurrentBalance.Text = customer.CurrentBalance.ToString();
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
                new CustomerService().DeactivateById(uid, "admin");
                LoadData();
                // Refresh the DataGridView after deletion

            }
        }
        private void LoadData()
        {
            // Replace this with your method to load data into a DataTable

            DataTable dataTable = new CustomerService().LoadDataTable();
            dataGridView1.DataSource = dataTable;
        }
        public Customer AssignValues()
        {
            Customer customer = new Customer();
            customer.OfficeAddress= txtOfficeAddress.Text.Trim();
            customer.CutomerName = txtCutomerName.Text.Trim();
            customer.CompanyName = txtCompanyName.Text.Trim();
            customer.HomeAddress = txtHomeAddress.Text.Trim();
            customer.MobileNo = txtMobileNo.Text.Trim();
            customer.Landline = txtLandline.Text.Trim();
            customer.Email = txtEmail.Text.Trim();
            customer.CurrentBalance = decimal.Parse(txtCurrentBalance.Text.Trim());
            customer.CreatedDate=DateTime.Now;
            customer.CreatedBy = "admin";
            customer.ModifiedDate = DateTime.Now;
            customer.ModifiedBy = "admin";
            customer.Active = true;
            return customer;
         }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string OfficeAddress = txtOfficeAddress.Text.Trim();
                string CutomerName = txtCutomerName.Text.Trim();
                string CompanyName = txtCompanyName.Text.Trim();
                string HomeAddress = txtHomeAddress.Text.Trim();
                string MobileNo = txtMobileNo.Text.Trim();
                string Landline = txtMobileNo.Text.Trim();
                string Email = txtEmail.Text.Trim();
                decimal CurrentBalance = decimal.Parse(txtCurrentBalance.Text.Trim());

                // Validate Name
                if (string.IsNullOrEmpty(CutomerName))
                {
                    MessageBox.Show("Please enter a customer name.");
                    return;
                }
                

                // Validate Selling Price
                
                

                // Assign values to the category
                Customer customer = AssignValues();

                if (_editingUid.HasValue)
                {
                    // Update existing record
                    customer.UId = _editingUid.Value;
                    new CustomerService().Update(customer);
                    MessageBox.Show("Customer successfully updated");
                    _editingUid = null; // Reset after update
                }
                else
                {
                    // Insert new record
                    new CustomerService().Insert(customer);
                    MessageBox.Show("Customer successfully added");
                }

                // Clear the form and reload data
                txtOfficeAddress.Clear();
                txtMobileNo.Clear();
                txtLandline.Clear();
                txtEmail.Clear();
                txtCutomerName.Clear();
                txtCompanyName.Clear();
                txtCurrentBalance.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
