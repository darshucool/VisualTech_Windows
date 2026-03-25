namespace VisualTech
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            categoryToolStripMenuItem = new ToolStripMenuItem();
            subCategoryToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            productManagementToolStripMenuItem = new ToolStripMenuItem();
            customerToolStripMenuItem = new ToolStripMenuItem();
            customerManagementToolStripMenuItem = new ToolStripMenuItem();
            invoiceToolStripMenuItem = new ToolStripMenuItem();
            createInvoiceToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, productToolStripMenuItem, customerToolStripMenuItem, invoiceToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(963, 36);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoryToolStripMenuItem, subCategoryToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(97, 32);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // categoryToolStripMenuItem
            // 
            categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            categoryToolStripMenuItem.Size = new Size(217, 32);
            categoryToolStripMenuItem.Text = "Category";
            categoryToolStripMenuItem.Click += categoryToolStripMenuItem_Click;
            // 
            // subCategoryToolStripMenuItem
            // 
            subCategoryToolStripMenuItem.Name = "subCategoryToolStripMenuItem";
            subCategoryToolStripMenuItem.Size = new Size(217, 32);
            subCategoryToolStripMenuItem.Text = "Sub Category";
            subCategoryToolStripMenuItem.Click += subCategoryToolStripMenuItem_Click;
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productManagementToolStripMenuItem });
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(95, 32);
            productToolStripMenuItem.Text = "Product";
            // 
            // productManagementToolStripMenuItem
            // 
            productManagementToolStripMenuItem.Name = "productManagementToolStripMenuItem";
            productManagementToolStripMenuItem.Size = new Size(288, 32);
            productManagementToolStripMenuItem.Text = "Product Management";
            productManagementToolStripMenuItem.Click += productManagementToolStripMenuItem_Click;
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerManagementToolStripMenuItem });
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(110, 32);
            customerToolStripMenuItem.Text = "Customer";
            // 
            // customerManagementToolStripMenuItem
            // 
            customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            customerManagementToolStripMenuItem.Size = new Size(303, 32);
            customerManagementToolStripMenuItem.Text = "Customer Management";
            customerManagementToolStripMenuItem.Click += customerManagementToolStripMenuItem_Click;
            // 
            // invoiceToolStripMenuItem
            // 
            invoiceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createInvoiceToolStripMenuItem });
            invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            invoiceToolStripMenuItem.Size = new Size(88, 32);
            invoiceToolStripMenuItem.Text = "Invoice";
            // 
            // createInvoiceToolStripMenuItem
            // 
            createInvoiceToolStripMenuItem.Name = "createInvoiceToolStripMenuItem";
            createInvoiceToolStripMenuItem.Size = new Size(224, 32);
            createInvoiceToolStripMenuItem.Text = "Create Invoice";
            createInvoiceToolStripMenuItem.Click += createInvoiceToolStripMenuItem_Click;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(963, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmDashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem categoryToolStripMenuItem;
        private ToolStripMenuItem subCategoryToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem productManagementToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem customerManagementToolStripMenuItem;
        private ToolStripMenuItem invoiceToolStripMenuItem;
        private ToolStripMenuItem createInvoiceToolStripMenuItem;
    }
}