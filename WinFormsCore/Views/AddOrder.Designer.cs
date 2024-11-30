namespace WinFormsCore.Views
{
    partial class AddOrder
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
            lblCustomer = new Label();
            dgvProducts = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            lblTotalAmount = new Label();
            txtTotalAmount = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtFirstName = new TextBox();
            label1 = new Label();
            cbProduct = new ComboBox();
            btnAdd = new Button();
            label2 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            txtQuantity = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtLastName = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.Location = new Point(20, 20);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(100, 23);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "First name:";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { ProductName, UnitPrice, Quantity, TotalAmount });
            dgvProducts.Location = new Point(20, 156);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(740, 300);
            dgvProducts.TabIndex = 2;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Tên Sản Phẩm";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "Giá";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Số Lượng";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Thành Tiền";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Location = new Point(20, 476);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(100, 23);
            lblTotalAmount.TabIndex = 3;
            lblTotalAmount.Text = "Tổng tiền:";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Enabled = false;
            txtTotalAmount.Location = new Point(150, 476);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(200, 27);
            txtTotalAmount.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(550, 516);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 31);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(650, 516);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 31);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(117, 17);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(196, 27);
            txtFirstName.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(410, 25);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 8;
            label1.Text = "Sản phẩm:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbProduct
            // 
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(507, 20);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(196, 28);
            cbProduct.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(150, 101);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 36);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Thêm";
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(419, 57);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 11;
            label2.Text = "Số lượng";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(507, 54);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(75, 27);
            txtQuantity.TabIndex = 12;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(311, 101);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(88, 36);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Sửa";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(451, 101);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 36);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.Click += btnDelete_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(117, 50);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(196, 27);
            txtLastName.TabIndex = 16;
            // 
            // label3
            // 
            label3.Location = new Point(20, 53);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 15;
            label3.Text = "Last name ";
            // 
            // AddOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(txtLastName);
            Controls.Add(label3);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtQuantity);
            Controls.Add(label2);
            Controls.Add(cbProduct);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(txtFirstName);
            Controls.Add(lblCustomer);
            Controls.Add(dgvProducts);
            Controls.Add(lblTotalAmount);
            Controls.Add(txtTotalAmount);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AddOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Đơn Hàng";
            Load += AddOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private DataGridView dgvProducts;
        private Label lblTotalAmount;
        private TextBox txtTotalAmount;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtFirstName;
        private Label label1;
        private ComboBox cbProduct;
        private Button btnAdd;
        private Label label2;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TextBox txtQuantity;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtLastName;
        private Label label3;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn TotalAmount;
    }
}