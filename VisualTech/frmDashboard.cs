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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.Show();
        }

        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubCategory frm = new frmSubCategory();
            frm.Show();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.Show();
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.Show();
        }

        private void createInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm = new Invoice();
            frm.Show();
        }

        private void customerPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerPayment frm = new frmCustomerPayment();
            frm.Show();
        }
    }
}
