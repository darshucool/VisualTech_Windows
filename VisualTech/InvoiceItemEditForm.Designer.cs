namespace VisualTech
{
    partial class InvoiceItemEditForm
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
            txtProductName = new TextBox();
            txtUnitPrice = new TextBox();
            label2 = new Label();
            txtQty = new TextBox();
            label3 = new Label();
            txtTotalPrice = new TextBox();
            label4 = new Label();
            txtWarrenty = new TextBox();
            label5 = new Label();
            txtBarcode = new TextBox();
            label6 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(62, 30);
            label1.Name = "label1";
            label1.Size = new Size(64, 28);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 14F);
            txtProductName.Location = new Point(176, 26);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(406, 39);
            txtProductName.TabIndex = 1;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Font = new Font("Segoe UI", 14F);
            txtUnitPrice.Location = new Point(176, 91);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(406, 39);
            txtUnitPrice.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(62, 95);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 2;
            label2.Text = "Unit Price";
            // 
            // txtQty
            // 
            txtQty.Font = new Font("Segoe UI", 14F);
            txtQty.Location = new Point(176, 153);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(406, 39);
            txtQty.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(62, 157);
            label3.Name = "label3";
            label3.Size = new Size(44, 28);
            label3.TabIndex = 4;
            label3.Text = "Qty";
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Font = new Font("Segoe UI", 14F);
            txtTotalPrice.Location = new Point(176, 215);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.Size = new Size(406, 39);
            txtTotalPrice.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(62, 219);
            label4.Name = "label4";
            label4.Size = new Size(101, 28);
            label4.TabIndex = 6;
            label4.Text = "Total Price";
            // 
            // txtWarrenty
            // 
            txtWarrenty.Font = new Font("Segoe UI", 14F);
            txtWarrenty.Location = new Point(176, 277);
            txtWarrenty.Name = "txtWarrenty";
            txtWarrenty.Size = new Size(406, 39);
            txtWarrenty.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(62, 281);
            label5.Name = "label5";
            label5.Size = new Size(92, 28);
            label5.TabIndex = 8;
            label5.Text = "Warrenty";
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 14F);
            txtBarcode.Location = new Point(176, 335);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(406, 39);
            txtBarcode.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(62, 339);
            label6.Name = "label6";
            label6.Size = new Size(83, 28);
            label6.TabIndex = 10;
            label6.Text = "Barcode";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.Font = new Font("Segoe UI", 14F);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(12, 387);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(224, 51);
            btnSave.TabIndex = 18;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.Font = new Font("Segoe UI", 14F);
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(393, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(224, 51);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // InvoiceItemEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtBarcode);
            Controls.Add(label6);
            Controls.Add(txtWarrenty);
            Controls.Add(label5);
            Controls.Add(txtTotalPrice);
            Controls.Add(label4);
            Controls.Add(txtQty);
            Controls.Add(label3);
            Controls.Add(txtUnitPrice);
            Controls.Add(label2);
            Controls.Add(txtProductName);
            Controls.Add(label1);
            Name = "InvoiceItemEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InvoiceItemEditForm";
            Load += InvoiceItemEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductName;
        private TextBox txtUnitPrice;
        private Label label2;
        private TextBox txtQty;
        private Label label3;
        private TextBox txtTotalPrice;
        private Label label4;
        private TextBox txtWarrenty;
        private Label label5;
        private TextBox txtBarcode;
        private Label label6;
        private Button btnSave;
        private Button btnCancel;
    }
}