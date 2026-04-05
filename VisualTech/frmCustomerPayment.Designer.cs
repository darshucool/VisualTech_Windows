namespace VisualTech
{
    partial class frmCustomerPayment
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
            label1 = new Label();
            cmbCustomer = new ComboBox();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            btnSave = new Button();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            txtPayment = new TextBox();
            label2 = new Label();
            txtBalance = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(25, 26);
            label1.Name = "label1";
            label1.Size = new Size(153, 28);
            label1.TabIndex = 3;
            label1.Text = "Select Customer";
            // 
            // cmbCustomer
            // 
            cmbCustomer.Font = new Font("Segoe UI", 16F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(184, 23);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(387, 45);
            cmbCustomer.TabIndex = 4;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(595, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(586, 393);
            dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPayment);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(25, 147);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(546, 262);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 14F);
            btnSave.Location = new Point(156, 176);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(367, 51);
            btnSave.TabIndex = 13;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 16F);
            dateTimePicker2.Location = new Point(156, 105);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(367, 43);
            dateTimePicker2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(20, 101);
            label3.Name = "label3";
            label3.Size = new Size(53, 28);
            label3.TabIndex = 9;
            label3.Text = "Date";
            // 
            // txtPayment
            // 
            txtPayment.Font = new Font("Segoe UI", 16F);
            txtPayment.Location = new Point(159, 23);
            txtPayment.Name = "txtPayment";
            txtPayment.Size = new Size(364, 43);
            txtPayment.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(20, 33);
            label2.Name = "label2";
            label2.Size = new Size(83, 28);
            label2.TabIndex = 7;
            label2.Text = "Amount";
            // 
            // txtBalance
            // 
            txtBalance.Font = new Font("Segoe UI", 16F);
            txtBalance.Location = new Point(184, 87);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(387, 43);
            txtBalance.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(25, 93);
            label4.Name = "label4";
            label4.Size = new Size(148, 28);
            label4.TabIndex = 14;
            label4.Text = "Current Balance";
            // 
            // CustomerPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1193, 450);
            Controls.Add(txtBalance);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(cmbCustomer);
            Controls.Add(label1);
            Name = "CustomerPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerPayment";
            Load += CustomerPayment_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ComboBox cmbCustomer;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtPayment;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private Button btnSave;
        private TextBox txtBalance;
        private Label label4;
    }
}