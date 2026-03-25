namespace VisualTech
{
    partial class frmCategory
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
            UId = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtCategory = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { UId, Category, CreatedDate });
            dataGridView1.Location = new Point(1, 98);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1010, 409);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += DataGridView_CellClick;
            // 
            // UId
            // 
            UId.DataPropertyName = "UId";
            UId.HeaderText = "UId";
            UId.MinimumWidth = 6;
            UId.Name = "UId";
            UId.ReadOnly = true;
            UId.Width = 125;
            // 
            // Category
            // 
            Category.DataPropertyName = "Category";
            Category.HeaderText = "Category";
            Category.MinimumWidth = 6;
            Category.Name = "Category";
            Category.ReadOnly = true;
            Category.Width = 350;
            // 
            // CreatedDate
            // 
            CreatedDate.DataPropertyName = "CreatedDate";
            CreatedDate.HeaderText = "Created Date";
            CreatedDate.MinimumWidth = 6;
            CreatedDate.Name = "CreatedDate";
            CreatedDate.ReadOnly = true;
            CreatedDate.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(38, 37);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 1;
            label1.Text = "Product Parent Category";
            // 
            // txtCategory
            // 
            txtCategory.Font = new Font("Segoe UI", 12F);
            txtCategory.Location = new Point(270, 37);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(454, 34);
            txtCategory.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(760, 37);
            button1.Name = "button1";
            button1.Size = new Size(142, 34);
            button1.TabIndex = 3;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1010, 504);
            Controls.Add(button1);
            Controls.Add(txtCategory);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "frmCategory";
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
        private TextBox txtCategory;
        private Button button1;
        private DataGridViewTextBoxColumn UId;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn CreatedDate;
    }
}