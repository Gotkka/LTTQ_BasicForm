namespace WinFormsCore.Views
{
    partial class Products
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
            components = new System.ComponentModel.Container();
            lblNumberPage = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            chỉnhSửaToolStripMenuItem = new ToolStripMenuItem();
            xóaToolStripMenuItem = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            txtSearch = new TextBox();
            cbColumn = new ComboBox();
            label11 = new Label();
            cbSort = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            btnNextPage = new Button();
            btnPreviousPage = new Button();
            cbNumberRow = new ComboBox();
            label7 = new Label();
            dgvShow = new DataGridView();
            groupBox1 = new GroupBox();
            btnExport = new Button();
            btnImport = new Button();
            btnAddNew = new Button();
            panel1 = new Panel();
            txtSupplierName = new TextBox();
            label2 = new Label();
            btnUpdate = new Button();
            panel5 = new Panel();
            txtPackage = new TextBox();
            label6 = new Label();
            panel4 = new Panel();
            txtUnitPrice = new TextBox();
            label5 = new Label();
            panel3 = new Panel();
            txtProductName = new TextBox();
            label4 = new Label();
            label1 = new Label();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblNumberPage
            // 
            lblNumberPage.AutoSize = true;
            lblNumberPage.Location = new Point(629, 733);
            lblNumberPage.Name = "lblNumberPage";
            lblNumberPage.Size = new Size(58, 20);
            lblNumberPage.TabIndex = 28;
            lblNumberPage.Text = "label12";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { chỉnhSửaToolStripMenuItem, xóaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 52);
            // 
            // chỉnhSửaToolStripMenuItem
            // 
            chỉnhSửaToolStripMenuItem.Name = "chỉnhSửaToolStripMenuItem";
            chỉnhSửaToolStripMenuItem.Size = new Size(142, 24);
            chỉnhSửaToolStripMenuItem.Text = "Chỉnh sửa";
            chỉnhSửaToolStripMenuItem.Click += chỉnhSửaToolStripMenuItem_Click;
            // 
            // xóaToolStripMenuItem
            // 
            xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            xóaToolStripMenuItem.Size = new Size(142, 24);
            xóaToolStripMenuItem.Text = "Xóa";
            xóaToolStripMenuItem.Click += xóaToolStripMenuItem_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(564, 386);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(198, 27);
            txtSearch.TabIndex = 27;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbColumn
            // 
            cbColumn.FormattingEnabled = true;
            cbColumn.Items.AddRange(new object[] { "STT", "Tên", "Giá", "Gói", "Nhà Cung Cấp" });
            cbColumn.Location = new Point(315, 387);
            cbColumn.Name = "cbColumn";
            cbColumn.Size = new Size(138, 28);
            cbColumn.TabIndex = 26;
            cbColumn.SelectedIndexChanged += cbColumn_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(277, 390);
            label11.Name = "label11";
            label11.Size = new Size(32, 20);
            label11.TabIndex = 25;
            label11.Text = "Cột";
            // 
            // cbSort
            // 
            cbSort.FormattingEnabled = true;
            cbSort.Items.AddRange(new object[] { "Tăng dần", "Giảm " });
            cbSort.Location = new Point(110, 387);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(138, 28);
            cbSort.TabIndex = 24;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(39, 390);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 23;
            label10.Text = "Sắp xếp";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(488, 390);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 22;
            label9.Text = "Tìm kiếm";
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(488, 724);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(115, 36);
            btnNextPage.TabIndex = 21;
            btnNextPage.Text = "Trang kế";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(292, 725);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(115, 36);
            btnPreviousPage.TabIndex = 20;
            btnPreviousPage.Text = "Trang trước";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // cbNumberRow
            // 
            cbNumberRow.FormattingEnabled = true;
            cbNumberRow.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "100" });
            cbNumberRow.Location = new Point(130, 730);
            cbNumberRow.Name = "cbNumberRow";
            cbNumberRow.Size = new Size(74, 28);
            cbNumberRow.TabIndex = 19;
            cbNumberRow.SelectedIndexChanged += cbNumberRow_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 733);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 18;
            label7.Text = "Số dòng";
            // 
            // dgvShow
            // 
            dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.ContextMenuStrip = contextMenuStrip1;
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.Location = new Point(47, 429);
            dgvShow.MultiSelect = false;
            dgvShow.Name = "dgvShow";
            dgvShow.RowHeadersVisible = false;
            dgvShow.RowHeadersWidth = 51;
            dgvShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShow.Size = new Size(779, 262);
            dgvShow.TabIndex = 17;
            dgvShow.SelectionChanged += dgvShow_SelectionChanged;
            dgvShow.MouseUp += dgvShow_MouseUp;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExport);
            groupBox1.Controls.Add(btnImport);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(panel5);
            groupBox1.Controls.Add(panel4);
            groupBox1.Controls.Add(panel3);
            groupBox1.Location = new Point(47, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(723, 259);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(558, 197);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(125, 45);
            btnExport.TabIndex = 9;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(386, 197);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(125, 45);
            btnImport.TabIndex = 8;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(63, 197);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(125, 45);
            btnAddNew.TabIndex = 7;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSupplierName);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(352, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 55);
            panel1.TabIndex = 4;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(121, 15);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(193, 27);
            txtSupplierName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 18);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 0;
            label2.Text = "Nhà cung cấp";
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(225, 197);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(125, 45);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtPackage);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(352, 58);
            panel5.Name = "panel5";
            panel5.Size = new Size(331, 55);
            panel5.TabIndex = 4;
            // 
            // txtPackage
            // 
            txtPackage.Location = new Point(121, 15);
            txtPackage.Name = "txtPackage";
            txtPackage.Size = new Size(193, 27);
            txtPackage.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 18);
            label6.Name = "label6";
            label6.Size = new Size(32, 20);
            label6.TabIndex = 0;
            label6.Text = "Gói";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtUnitPrice);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(63, 125);
            panel4.Name = "panel4";
            panel4.Size = new Size(287, 55);
            panel4.TabIndex = 3;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(79, 15);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(168, 27);
            txtUnitPrice.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 18);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 0;
            label5.Text = "Giá";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtProductName);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(63, 58);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 55);
            panel3.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(70, 15);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(171, 27);
            txtProductName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 18);
            label4.Name = "label4";
            label4.Size = new Size(32, 20);
            label4.TabIndex = 0;
            label4.Text = "Tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 27);
            label1.Name = "label1";
            label1.Size = new Size(253, 38);
            label1.TabIndex = 15;
            label1.Text = "Quản lý sản phẩm";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 779);
            Controls.Add(lblNumberPage);
            Controls.Add(txtSearch);
            Controls.Add(cbColumn);
            Controls.Add(label11);
            Controls.Add(cbSort);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(btnNextPage);
            Controls.Add(btnPreviousPage);
            Controls.Add(cbNumberRow);
            Controls.Add(label7);
            Controls.Add(dgvShow);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Products";
            Text = "Products";
            Load += Products_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumberPage;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem chỉnhSửaToolStripMenuItem;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private ErrorProvider errorProvider1;
        private TextBox txtSearch;
        private ComboBox cbColumn;
        private Label label11;
        private ComboBox cbSort;
        private Label label10;
        private Label label9;
        private Button btnNextPage;
        private Button btnPreviousPage;
        private ComboBox cbNumberRow;
        private Label label7;
        private DataGridView dgvShow;
        private GroupBox groupBox1;
        private Button btnUpdate;
        private Panel panel5;
        private TextBox txtPackage;
        private Label label6;
        private Panel panel4;
        private TextBox txtUnitPrice;
        private Label label5;
        private Panel panel3;
        private TextBox txtProductName;
        private Label label4;
        private Label label1;
        private Panel panel1;
        private TextBox txtSupplierName;
        private Label label2;
        private Button btnAddNew;
        private Button btnExport;
        private Button btnImport;
    }
}