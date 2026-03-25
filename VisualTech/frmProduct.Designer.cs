namespace VisualTech
{
    partial class frmProduct
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtName = new TextBox();
            button1 = new Button();
            label2 = new Label();
            cmbCat = new ComboBox();
            label3 = new Label();
            txtCostPrice = new TextBox();
            txtSellingPrice = new TextBox();
            label4 = new Label();
            cmbSubCat = new ComboBox();
            label5 = new Label();
            cmbBrand = new ComboBox();
            label6 = new Label();
            txtMRP = new TextBox();
            label7 = new Label();
            txtDescription = new TextBox();
            label8 = new Label();
            UId = new DataGridViewTextBoxColumn();
            Brand = new DataGridViewTextBoxColumn();
            ProductCategory = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CostPrice = new DataGridViewTextBoxColumn();
            SellingPrice = new DataGridViewTextBoxColumn();
            MRPPrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { UId, Brand, ProductCategory, Category, ProductName, CostPrice, SellingPrice, MRPPrice });
            dataGridView1.Location = new Point(1, 261);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1354, 462);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += DataGridView_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(92, 28);
            label1.TabIndex = 1;
            label1.Text = "Category";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(881, 71);
            txtName.Name = "txtName";
            txtName.Size = new Size(454, 34);
            txtName.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(1193, 221);
            button1.Name = "button1";
            button1.Size = new Size(142, 34);
            button1.TabIndex = 3;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(683, 71);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 4;
            label2.Text = "Product Name";
            // 
            // cmbCat
            // 
            cmbCat.Font = new Font("Segoe UI", 12F);
            cmbCat.FormattingEnabled = true;
            cmbCat.Location = new Point(211, 19);
            cmbCat.Name = "cmbCat";
            cmbCat.Size = new Size(457, 36);
            cmbCat.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(48, 28);
            label3.TabIndex = 6;
            label3.Text = "DPP";
            // 
            // txtCostPrice
            // 
            txtCostPrice.Font = new Font("Segoe UI", 12F);
            txtCostPrice.Location = new Point(211, 132);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new Size(454, 34);
            txtCostPrice.TabIndex = 7;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Font = new Font("Segoe UI", 12F);
            txtSellingPrice.Location = new Point(881, 129);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(454, 34);
            txtSellingPrice.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(683, 135);
            label4.Name = "label4";
            label4.Size = new Size(118, 28);
            label4.TabIndex = 8;
            label4.Text = "Selling Price";
            // 
            // cmbSubCat
            // 
            cmbSubCat.Font = new Font("Segoe UI", 12F);
            cmbSubCat.FormattingEnabled = true;
            cmbSubCat.Location = new Point(878, 19);
            cmbSubCat.Name = "cmbSubCat";
            cmbSubCat.Size = new Size(457, 36);
            cmbSubCat.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(679, 19);
            label5.Name = "label5";
            label5.Size = new Size(131, 28);
            label5.TabIndex = 10;
            label5.Text = "Sub Category";
            // 
            // cmbBrand
            // 
            cmbBrand.Font = new Font("Segoe UI", 12F);
            cmbBrand.FormattingEnabled = true;
            cmbBrand.Location = new Point(211, 71);
            cmbBrand.Name = "cmbBrand";
            cmbBrand.Size = new Size(457, 36);
            cmbBrand.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 71);
            label6.Name = "label6";
            label6.Size = new Size(63, 28);
            label6.TabIndex = 12;
            label6.Text = "Brand";
            // 
            // txtMRP
            // 
            txtMRP.Font = new Font("Segoe UI", 12F);
            txtMRP.Location = new Point(211, 181);
            txtMRP.Name = "txtMRP";
            txtMRP.Size = new Size(454, 34);
            txtMRP.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(13, 187);
            label7.Name = "label7";
            label7.Size = new Size(53, 28);
            label7.TabIndex = 14;
            label7.Text = "MRP";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(881, 181);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(454, 34);
            txtDescription.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(683, 187);
            label8.Name = "label8";
            label8.Size = new Size(112, 28);
            label8.TabIndex = 16;
            label8.Text = "Description";
            // 
            // UId
            // 
            UId.DataPropertyName = "UId";
            UId.HeaderText = "UId";
            UId.MinimumWidth = 6;
            UId.Name = "UId";
            UId.ReadOnly = true;
            UId.Width = 50;
            // 
            // Brand
            // 
            Brand.DataPropertyName = "Brand";
            Brand.HeaderText = "Brand";
            Brand.MinimumWidth = 6;
            Brand.Name = "Brand";
            Brand.Width = 125;
            // 
            // ProductCategory
            // 
            ProductCategory.DataPropertyName = "ProductCategory";
            ProductCategory.FillWeight = 150F;
            ProductCategory.HeaderText = "Parent Category";
            ProductCategory.MinimumWidth = 6;
            ProductCategory.Name = "ProductCategory";
            ProductCategory.Width = 150;
            // 
            // Category
            // 
            Category.DataPropertyName = "Category";
            Category.HeaderText = "Category";
            Category.MinimumWidth = 6;
            Category.Name = "Category";
            Category.ReadOnly = true;
            Category.Width = 200;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "Name";
            ProductName.HeaderText = "Name";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Width = 300;
            // 
            // CostPrice
            // 
            CostPrice.DataPropertyName = "CostPrice";
            CostPrice.HeaderText = "DPP";
            CostPrice.MinimumWidth = 6;
            CostPrice.Name = "CostPrice";
            CostPrice.Width = 125;
            // 
            // SellingPrice
            // 
            SellingPrice.DataPropertyName = "SellingPrice";
            SellingPrice.HeaderText = "Selling Price";
            SellingPrice.MinimumWidth = 6;
            SellingPrice.Name = "SellingPrice";
            SellingPrice.Width = 125;
            // 
            // MRPPrice
            // 
            MRPPrice.DataPropertyName = "MRPPrice";
            MRPPrice.HeaderText = "MRP";
            MRPPrice.MinimumWidth = 6;
            MRPPrice.Name = "MRPPrice";
            MRPPrice.Width = 125;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1356, 724);
            Controls.Add(txtDescription);
            Controls.Add(label8);
            Controls.Add(txtMRP);
            Controls.Add(label7);
            Controls.Add(cmbBrand);
            Controls.Add(label6);
            Controls.Add(cmbSubCat);
            Controls.Add(label5);
            Controls.Add(txtSellingPrice);
            Controls.Add(label4);
            Controls.Add(txtCostPrice);
            Controls.Add(label3);
            Controls.Add(cmbCat);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "frmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCategory";
            Load += frmCategory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtName;
        private Button button1;
        private Label label2;
        private ComboBox cmbCat;
        private Label label3;
        private TextBox txtCostPrice;
        private TextBox txtSellingPrice;
        private Label label4;
        private ComboBox cmbSubCat;
        private Label label5;
        private ComboBox cmbBrand;
        private Label label6;
        private TextBox txtMRP;
        private Label label7;
        private TextBox txtDescription;
        private Label label8;
        private DataGridViewTextBoxColumn UId;
        private DataGridViewTextBoxColumn Brand;
        private DataGridViewTextBoxColumn ParentCategory;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CostPrice;
        private DataGridViewTextBoxColumn SellingPrice;
        private DataGridViewTextBoxColumn MRPPrice;
        private DataGridViewTextBoxColumn ProductCategory;
    }
}