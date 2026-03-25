namespace VisualTech
{
    partial class frmCustomer
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
            CutomerName = new DataGridViewTextBoxColumn();
            CompanyName = new DataGridViewTextBoxColumn();
            MobileNo = new DataGridViewTextBoxColumn();
            CurrentBalance = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            txtOfficeAddress = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            txtMobileNo = new TextBox();
            txtLandline = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtCurrentBalance = new TextBox();
            label8 = new Label();
            label6 = new Label();
            txtHomeAddress = new TextBox();
            label1 = new Label();
            txtCutomerName = new TextBox();
            label5 = new Label();
            txtCompanyName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { UId, CutomerName, CompanyName, MobileNo, CurrentBalance, CreatedDate });
            dataGridView1.Location = new Point(1, 261);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1354, 413);
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
            UId.Width = 50;
            // 
            // CutomerName
            // 
            CutomerName.DataPropertyName = "CutomerName";
            CutomerName.FillWeight = 150F;
            CutomerName.HeaderText = "Cutomer Name";
            CutomerName.MinimumWidth = 6;
            CutomerName.Name = "CutomerName";
            CutomerName.Width = 200;
            // 
            // CompanyName
            // 
            CompanyName.DataPropertyName = "CompanyName";
            CompanyName.HeaderText = "Company Name";
            CompanyName.MinimumWidth = 6;
            CompanyName.Name = "CompanyName";
            CompanyName.ReadOnly = true;
            CompanyName.Width = 250;
            // 
            // MobileNo
            // 
            MobileNo.DataPropertyName = "MobileNo";
            MobileNo.FillWeight = 250F;
            MobileNo.HeaderText = "Mobile No";
            MobileNo.MinimumWidth = 6;
            MobileNo.Name = "MobileNo";
            MobileNo.Width = 150;
            // 
            // CurrentBalance
            // 
            CurrentBalance.DataPropertyName = "CurrentBalance";
            CurrentBalance.HeaderText = "Current Balance";
            CurrentBalance.MinimumWidth = 6;
            CurrentBalance.Name = "CurrentBalance";
            CurrentBalance.Width = 125;
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
            // txtOfficeAddress
            // 
            txtOfficeAddress.Font = new Font("Segoe UI", 12F);
            txtOfficeAddress.Location = new Point(881, 71);
            txtOfficeAddress.Name = "txtOfficeAddress";
            txtOfficeAddress.Size = new Size(454, 34);
            txtOfficeAddress.TabIndex = 2;
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
            label2.Text = "Office Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(106, 28);
            label3.TabIndex = 6;
            label3.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            txtMobileNo.Font = new Font("Segoe UI", 12F);
            txtMobileNo.Location = new Point(211, 132);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(454, 34);
            txtMobileNo.TabIndex = 7;
            // 
            // txtLandline
            // 
            txtLandline.Font = new Font("Segoe UI", 12F);
            txtLandline.Location = new Point(881, 129);
            txtLandline.Name = "txtLandline";
            txtLandline.Size = new Size(454, 34);
            txtLandline.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(683, 135);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 8;
            label4.Text = "Landline";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(211, 181);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(454, 34);
            txtEmail.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(13, 187);
            label7.Name = "label7";
            label7.Size = new Size(59, 28);
            label7.TabIndex = 14;
            label7.Text = "Email";
            // 
            // txtCurrentBalance
            // 
            txtCurrentBalance.Font = new Font("Segoe UI", 12F);
            txtCurrentBalance.Location = new Point(881, 181);
            txtCurrentBalance.Name = "txtCurrentBalance";
            txtCurrentBalance.Size = new Size(454, 34);
            txtCurrentBalance.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(683, 187);
            label8.Name = "label8";
            label8.Size = new Size(148, 28);
            label8.TabIndex = 16;
            label8.Text = "Current Balance";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(13, 71);
            label6.Name = "label6";
            label6.Size = new Size(140, 28);
            label6.TabIndex = 19;
            label6.Text = "Home Address";
            // 
            // txtHomeAddress
            // 
            txtHomeAddress.Font = new Font("Segoe UI", 12F);
            txtHomeAddress.Location = new Point(211, 71);
            txtHomeAddress.Name = "txtHomeAddress";
            txtHomeAddress.Size = new Size(454, 34);
            txtHomeAddress.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(145, 28);
            label1.TabIndex = 23;
            label1.Text = "Cutomer Name";
            // 
            // txtCutomerName
            // 
            txtCutomerName.Font = new Font("Segoe UI", 12F);
            txtCutomerName.Location = new Point(211, 12);
            txtCutomerName.Name = "txtCutomerName";
            txtCutomerName.Size = new Size(454, 34);
            txtCutomerName.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(683, 12);
            label5.Name = "label5";
            label5.Size = new Size(153, 28);
            label5.TabIndex = 21;
            label5.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Font = new Font("Segoe UI", 12F);
            txtCompanyName.Location = new Point(881, 12);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(454, 34);
            txtCompanyName.TabIndex = 20;
            // 
            // frmCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1356, 674);
            Controls.Add(label1);
            Controls.Add(txtCutomerName);
            Controls.Add(label5);
            Controls.Add(txtCompanyName);
            Controls.Add(label6);
            Controls.Add(txtHomeAddress);
            Controls.Add(txtCurrentBalance);
            Controls.Add(label8);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(txtLandline);
            Controls.Add(label4);
            Controls.Add(txtMobileNo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtOfficeAddress);
            Controls.Add(dataGridView1);
            Name = "frmCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCustomer";
            Load += frmCategory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtOfficeAddress;
        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox txtMobileNo;
        private TextBox txtLandline;
        private Label label4;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtCurrentBalance;
        private Label label8;
        private Label label6;
        private TextBox txtHomeAddress;
        private Label label1;
        private TextBox txtCutomerName;
        private Label label5;
        private TextBox txtCompanyName;
        private DataGridViewTextBoxColumn UId;
        private DataGridViewTextBoxColumn CutomerName;
        private DataGridViewTextBoxColumn CompanyName;
        private DataGridViewTextBoxColumn MobileNo;
        private DataGridViewTextBoxColumn CurrentBalance;
        private DataGridViewTextBoxColumn CreatedDate;
    }
}