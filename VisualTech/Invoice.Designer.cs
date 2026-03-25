namespace VisualTech
{
    partial class Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            menuStrip1 = new MenuStrip();
            newInvoiceToolStripMenuItem = new ToolStripMenuItem();
            txtProductName = new TextBox();
            panel1 = new Panel();
            groupBox7 = new GroupBox();
            radEstimate = new RadioButton();
            radInvoice = new RadioButton();
            groupBox6 = new GroupBox();
            txtUnitPrice = new TextBox();
            btnClear = new Button();
            label2 = new Label();
            label1 = new Label();
            txtCustomerName = new TextBox();
            cmbCustomer = new ComboBox();
            groupBox5 = new GroupBox();
            txtBarcode = new TextBox();
            groupBox4 = new GroupBox();
            txtWarrenty = new TextBox();
            btnAddToGrid = new Button();
            groupBox3 = new GroupBox();
            txtPrice = new TextBox();
            groupBox2 = new GroupBox();
            txtQty = new TextBox();
            groupBox1 = new GroupBox();
            txtProduct = new TextBox();
            cmbCategory = new ComboBox();
            dataGridView1 = new DataGridView();
            Category = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            SellingPrice = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            btnCancel = new Button();
            btnConfirm = new Button();
            groupBox13 = new GroupBox();
            txtBalance = new TextBox();
            groupBox12 = new GroupBox();
            txtPayment = new TextBox();
            groupBox11 = new GroupBox();
            txtNetPrice = new TextBox();
            groupBox10 = new GroupBox();
            txtDiscount = new TextBox();
            groupBox9 = new GroupBox();
            txtTax = new TextBox();
            groupBox8 = new GroupBox();
            txtGrossTotal = new TextBox();
            dataGridView2 = new DataGridView();
            UId = new DataGridViewTextBoxColumn();
            Warranty = new DataGridViewTextBoxColumn();
            Barcode = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Qty = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { newInvoiceToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1681, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // newInvoiceToolStripMenuItem
            // 
            newInvoiceToolStripMenuItem.Name = "newInvoiceToolStripMenuItem";
            newInvoiceToolStripMenuItem.Size = new Size(104, 24);
            newInvoiceToolStripMenuItem.Text = "New Invoice";
            newInvoiceToolStripMenuItem.Click += newInvoiceToolStripMenuItem_Click;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 16F);
            txtProductName.Location = new Point(301, 214);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(522, 43);
            txtProductName.TabIndex = 2;
            txtProductName.TextChanged += txtProductName_TextChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(groupBox7);
            panel1.Controls.Add(groupBox6);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtCustomerName);
            panel1.Controls.Add(cmbCustomer);
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(btnAddToGrid);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(cmbCategory);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(txtProductName);
            panel1.Location = new Point(9, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(830, 975);
            panel1.TabIndex = 3;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(radEstimate);
            groupBox7.Controls.Add(radInvoice);
            groupBox7.Location = new Point(3, 0);
            groupBox7.Margin = new Padding(3, 0, 3, 0);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(820, 50);
            groupBox7.TabIndex = 16;
            groupBox7.TabStop = false;
            // 
            // radEstimate
            // 
            radEstimate.AutoSize = true;
            radEstimate.Font = new Font("Segoe UI", 12F);
            radEstimate.Location = new Point(161, 13);
            radEstimate.Name = "radEstimate";
            radEstimate.Size = new Size(107, 32);
            radEstimate.TabIndex = 1;
            radEstimate.TabStop = true;
            radEstimate.Text = "Estimate";
            radEstimate.UseVisualStyleBackColor = true;
            // 
            // radInvoice
            // 
            radInvoice.AutoSize = true;
            radInvoice.Font = new Font("Segoe UI", 12F);
            radInvoice.Location = new Point(19, 12);
            radInvoice.Name = "radInvoice";
            radInvoice.Size = new Size(95, 32);
            radInvoice.TabIndex = 0;
            radInvoice.TabStop = true;
            radInvoice.Text = "Invoice";
            radInvoice.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(txtUnitPrice);
            groupBox6.Font = new Font("Segoe UI", 12F);
            groupBox6.Location = new Point(16, 609);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(265, 85);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Unit Price";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Font = new Font("Microsoft Sans Serif", 19.8000011F);
            txtUnitPrice.Location = new Point(6, 33);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(237, 45);
            txtUnitPrice.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(64, 64, 64);
            btnClear.BackgroundImage = (Image)resources.GetObject("btnClear.BackgroundImage");
            btnClear.BackgroundImageLayout = ImageLayout.Stretch;
            btnClear.Font = new Font("Segoe UI", 24F);
            btnClear.ForeColor = SystemColors.ButtonFace;
            btnClear.Location = new Point(777, 53);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(46, 49);
            btnClear.TabIndex = 15;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(10, 53);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(234, 41);
            label2.TabIndex = 14;
            label2.Text = "Select Customer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(10, 109);
            label1.Name = "label1";
            label1.Size = new Size(223, 41);
            label1.TabIndex = 13;
            label1.Text = "Enter Customer";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Segoe UI", 16F);
            txtCustomerName.Location = new Point(301, 109);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(522, 43);
            txtCustomerName.TabIndex = 12;
            // 
            // cmbCustomer
            // 
            cmbCustomer.Font = new Font("Segoe UI", 16F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(301, 55);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(470, 45);
            cmbCustomer.TabIndex = 11;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtBarcode);
            groupBox5.Font = new Font("Segoe UI", 12F);
            groupBox5.Location = new Point(10, 790);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(581, 156);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "Barcode";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(6, 33);
            txtBarcode.Multiline = true;
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(569, 105);
            txtBarcode.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtWarrenty);
            groupBox4.Font = new Font("Segoe UI", 12F);
            groupBox4.Location = new Point(16, 689);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(807, 98);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Warrenty";
            // 
            // txtWarrenty
            // 
            txtWarrenty.Font = new Font("Microsoft Sans Serif", 16.2F);
            txtWarrenty.Location = new Point(6, 33);
            txtWarrenty.Name = "txtWarrenty";
            txtWarrenty.Size = new Size(793, 38);
            txtWarrenty.TabIndex = 0;
            // 
            // btnAddToGrid
            // 
            btnAddToGrid.BackColor = Color.FromArgb(64, 64, 64);
            btnAddToGrid.Font = new Font("Segoe UI", 24F);
            btnAddToGrid.ForeColor = SystemColors.ButtonFace;
            btnAddToGrid.Location = new Point(599, 822);
            btnAddToGrid.Name = "btnAddToGrid";
            btnAddToGrid.Size = new Size(226, 106);
            btnAddToGrid.TabIndex = 7;
            btnAddToGrid.Text = "ADD >>";
            btnAddToGrid.UseVisualStyleBackColor = false;
            btnAddToGrid.Click += btnAddToGrid_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtPrice);
            groupBox3.Font = new Font("Segoe UI", 12F);
            groupBox3.Location = new Point(520, 609);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(295, 85);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(255, 255, 128);
            txtPrice.Font = new Font("Microsoft Sans Serif", 19.8000011F);
            txtPrice.Location = new Point(6, 30);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(272, 45);
            txtPrice.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtQty);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(287, 609);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(227, 85);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Qunatity";
            // 
            // txtQty
            // 
            txtQty.Font = new Font("Microsoft Sans Serif", 19.8000011F);
            txtQty.Location = new Point(6, 33);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(202, 45);
            txtQty.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtProduct);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(10, 505);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(805, 98);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Product Name";
            // 
            // txtProduct
            // 
            txtProduct.Font = new Font("Microsoft Sans Serif", 16.2F);
            txtProduct.Location = new Point(6, 33);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(766, 38);
            txtProduct.TabIndex = 0;
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("Segoe UI", 16F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(301, 161);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(522, 45);
            cmbCategory.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Category, Name, SellingPrice });
            dataGridView1.Location = new Point(10, 266);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(813, 230);
            dataGridView1.TabIndex = 3;
            // 
            // Category
            // 
            Category.DataPropertyName = "Category";
            Category.HeaderText = "Category";
            Category.MinimumWidth = 6;
            Category.Name = "Category";
            Category.Width = 200;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.Width = 300;
            // 
            // SellingPrice
            // 
            SellingPrice.DataPropertyName = "SellingPrice";
            SellingPrice.HeaderText = "SellingPrice";
            SellingPrice.MinimumWidth = 6;
            SellingPrice.Name = "SellingPrice";
            SellingPrice.Width = 150;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnConfirm);
            panel2.Controls.Add(groupBox13);
            panel2.Controls.Add(groupBox12);
            panel2.Controls.Add(groupBox11);
            panel2.Controls.Add(groupBox10);
            panel2.Controls.Add(groupBox9);
            panel2.Controls.Add(groupBox8);
            panel2.Controls.Add(dataGridView2);
            panel2.Location = new Point(845, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(830, 975);
            panel2.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.Font = new Font("Segoe UI", 24F);
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(445, 858);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(368, 73);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(0, 192, 0);
            btnConfirm.Font = new Font("Segoe UI", 24F);
            btnConfirm.ForeColor = SystemColors.ButtonFace;
            btnConfirm.Location = new Point(16, 856);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(368, 73);
            btnConfirm.TabIndex = 16;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(txtBalance);
            groupBox13.Font = new Font("Segoe UI", 18F);
            groupBox13.Location = new Point(445, 731);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(379, 120);
            groupBox13.TabIndex = 10;
            groupBox13.TabStop = false;
            groupBox13.Text = "BALANCE";
            // 
            // txtBalance
            // 
            txtBalance.Font = new Font("Segoe UI", 28F);
            txtBalance.Location = new Point(13, 41);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(348, 70);
            txtBalance.TabIndex = 1;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(txtPayment);
            groupBox12.Font = new Font("Segoe UI", 18F);
            groupBox12.Location = new Point(7, 731);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(379, 120);
            groupBox12.TabIndex = 9;
            groupBox12.TabStop = false;
            groupBox12.Text = "PAYMENT";
            // 
            // txtPayment
            // 
            txtPayment.Font = new Font("Segoe UI", 28F);
            txtPayment.Location = new Point(13, 41);
            txtPayment.Name = "txtPayment";
            txtPayment.Size = new Size(348, 70);
            txtPayment.TabIndex = 1;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(txtNetPrice);
            groupBox11.Font = new Font("Segoe UI", 18F);
            groupBox11.Location = new Point(8, 605);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(812, 120);
            groupBox11.TabIndex = 8;
            groupBox11.TabStop = false;
            groupBox11.Text = "NET TOTAL";
            // 
            // txtNetPrice
            // 
            txtNetPrice.Font = new Font("Segoe UI", 28F);
            txtNetPrice.Location = new Point(11, 41);
            txtNetPrice.Name = "txtNetPrice";
            txtNetPrice.Size = new Size(792, 70);
            txtNetPrice.TabIndex = 1;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(txtDiscount);
            groupBox10.Font = new Font("Segoe UI", 18F);
            groupBox10.Location = new Point(419, 476);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(406, 120);
            groupBox10.TabIndex = 9;
            groupBox10.TabStop = false;
            groupBox10.Text = "DISCOUNT";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 28F);
            txtDiscount.Location = new Point(11, 41);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(389, 70);
            txtDiscount.TabIndex = 1;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(txtTax);
            groupBox9.Font = new Font("Segoe UI", 18F);
            groupBox9.Location = new Point(7, 475);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(406, 120);
            groupBox9.TabIndex = 8;
            groupBox9.TabStop = false;
            groupBox9.Text = "TAX";
            // 
            // txtTax
            // 
            txtTax.Font = new Font("Segoe UI", 28F);
            txtTax.Location = new Point(11, 41);
            txtTax.Name = "txtTax";
            txtTax.Size = new Size(389, 70);
            txtTax.TabIndex = 1;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(txtGrossTotal);
            groupBox8.Font = new Font("Segoe UI", 18F);
            groupBox8.Location = new Point(8, 347);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(812, 120);
            groupBox8.TabIndex = 7;
            groupBox8.TabStop = false;
            groupBox8.Text = "GROSS TOTAL";
            // 
            // txtGrossTotal
            // 
            txtGrossTotal.Font = new Font("Segoe UI", 28F);
            txtGrossTotal.Location = new Point(11, 41);
            txtGrossTotal.Name = "txtGrossTotal";
            txtGrossTotal.Size = new Size(792, 70);
            txtGrossTotal.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { UId, Warranty, Barcode, ProductName, UnitPrice, Qty, TotalPrice });
            dataGridView2.Dock = DockStyle.Top;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(830, 322);
            dataGridView2.TabIndex = 2;
            // 
            // UId
            // 
            UId.DataPropertyName = "UId";
            UId.HeaderText = "UId";
            UId.MinimumWidth = 6;
            UId.Name = "UId";
            UId.Visible = false;
            UId.Width = 10;
            // 
            // Warranty
            // 
            Warranty.DataPropertyName = "Warranty";
            Warranty.HeaderText = "Warranty";
            Warranty.MinimumWidth = 6;
            Warranty.Name = "Warranty";
            Warranty.Visible = false;
            Warranty.Width = 125;
            // 
            // Barcode
            // 
            Barcode.DataPropertyName = "Barcode";
            Barcode.HeaderText = "Barcode";
            Barcode.MinimumWidth = 6;
            Barcode.Name = "Barcode";
            Barcode.Visible = false;
            Barcode.Width = 125;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Name";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            ProductName.Width = 350;
            // 
            // UnitPrice
            // 
            UnitPrice.DataPropertyName = "UnitPrice";
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            UnitPrice.Width = 150;
            // 
            // Qty
            // 
            Qty.DataPropertyName = "Qty";
            Qty.HeaderText = "Qty";
            Qty.MinimumWidth = 6;
            Qty.Name = "Qty";
            Qty.Resizable = DataGridViewTriState.True;
            Qty.Width = 125;
            // 
            // TotalPrice
            // 
            TotalPrice.DataPropertyName = "TotalPrice";
            TotalPrice.HeaderText = "Total Price";
            TotalPrice.MinimumWidth = 6;
            TotalPrice.Name = "TotalPrice";
            TotalPrice.Width = 150;
            // 
            // Invoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(1681, 1023);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Text = "Invoice";
            WindowState = FormWindowState.Maximized;
            Load += Invoice_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem newInvoiceToolStripMenuItem;
        private TextBox txtProductName;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private ComboBox cmbCategory;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn SellingPrice;
        private GroupBox groupBox1;
        private TextBox txtProduct;
        private GroupBox groupBox3;
        private TextBox txtPrice;
        private Button btnAddToGrid;
        private GroupBox groupBox4;
        private TextBox txtWarrenty;
        private GroupBox groupBox5;
        private TextBox txtBarcode;
        private DataGridView dataGridView2;
        private GroupBox groupBox8;
        private TextBox txtGrossTotal;
        private GroupBox groupBox10;
        private TextBox txtDiscount;
        private GroupBox groupBox9;
        private TextBox txtTax;
        private GroupBox groupBox11;
        private TextBox txtNetPrice;
        private ComboBox cmbCustomer;
        private TextBox txtCustomerName;
        private Label label1;
        private Label label2;
        private GroupBox groupBox13;
        private TextBox txtBalance;
        private GroupBox groupBox12;
        private TextBox txtPayment;
        private Button btnClear;
        private Button btnCancel;
        private Button btnConfirm;
        private DataGridViewTextBoxColumn UId;
        private DataGridViewTextBoxColumn Warranty;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Qty;
        private DataGridViewTextBoxColumn TotalPrice;
        private GroupBox groupBox6;
        private TextBox txtUnitPrice;
        private GroupBox groupBox2;
        private TextBox txtQty;
        private GroupBox groupBox7;
        private RadioButton radEstimate;
        private RadioButton radInvoice;
    }
}