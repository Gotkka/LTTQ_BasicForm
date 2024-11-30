namespace WinFormsCore.Views
{
    partial class OrderDetails
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
            lblOrderNumber = new Label();
            lblCustomerName = new Label();
            dgvShow = new DataGridView();
            lblOrderDate = new Label();
            lblTotalAmount = new Label();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            SuspendLayout();
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.AutoSize = true;
            lblOrderNumber.Location = new Point(86, 47);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(101, 20);
            lblOrderNumber.TabIndex = 0;
            lblOrderNumber.Text = "OrderNumber";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(86, 97);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(112, 20);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "CustomerName";
            // 
            // dgvShow
            // 
            dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShow.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.Location = new Point(86, 175);
            dgvShow.Name = "dgvShow";
            dgvShow.RowHeadersWidth = 51;
            dgvShow.Size = new Size(616, 180);
            dgvShow.TabIndex = 2;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(402, 47);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(79, 20);
            lblOrderDate.TabIndex = 3;
            lblOrderDate.Text = "OrderDate";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(402, 97);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(95, 20);
            lblTotalAmount.TabIndex = 4;
            lblTotalAmount.Text = "TotalAmount";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(608, 61);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 43);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // OrderDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExport);
            Controls.Add(lblTotalAmount);
            Controls.Add(lblOrderDate);
            Controls.Add(dgvShow);
            Controls.Add(lblCustomerName);
            Controls.Add(lblOrderNumber);
            Name = "OrderDetails";
            Text = "OrderDetails";
            Load += OrderDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderNumber;
        private Label lblCustomerName;
        private DataGridView dgvShow;
        private Label lblOrderDate;
        private Label lblTotalAmount;
        private Button btnExport;
    }
}