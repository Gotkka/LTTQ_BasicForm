namespace WinFormsCore.Views
{
    partial class Index
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
            menuStrip1 = new MenuStrip();
            tệpToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            hàngHóaToolStripMenuItem = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new Button();
            orderBindingSource = new BindingSource(components);
            lblNumberPage = new Label();
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
            btnExport = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tệpToolStripMenuItem, hàngHóaToolStripMenuItem, kháchHàngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(853, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tệpToolStripMenuItem
            // 
            tệpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngXuấtToolStripMenuItem });
            tệpToolStripMenuItem.Name = "tệpToolStripMenuItem";
            tệpToolStripMenuItem.Size = new Size(48, 24);
            tệpToolStripMenuItem.Text = "Tệp";
            tệpToolStripMenuItem.Click += tệpToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(160, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // hàngHóaToolStripMenuItem
            // 
            hàngHóaToolStripMenuItem.Name = "hàngHóaToolStripMenuItem";
            hàngHóaToolStripMenuItem.Size = new Size(88, 24);
            hàngHóaToolStripMenuItem.Text = "Hàng hóa";
            hàngHóaToolStripMenuItem.Click += hàngHóaToolStripMenuItem_Click;
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(100, 24);
            kháchHàngToolStripMenuItem.Text = "Khách hàng";
            kháchHàngToolStripMenuItem.Click += kháchHàngToolStripMenuItem_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(41, 61);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 45);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Models.Entities.Order);
            // 
            // lblNumberPage
            // 
            lblNumberPage.AutoSize = true;
            lblNumberPage.Location = new Point(623, 476);
            lblNumberPage.Name = "lblNumberPage";
            lblNumberPage.Size = new Size(58, 20);
            lblNumberPage.TabIndex = 40;
            lblNumberPage.Text = "label12";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(558, 129);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(198, 27);
            txtSearch.TabIndex = 39;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbColumn
            // 
            cbColumn.FormattingEnabled = true;
            cbColumn.Items.AddRange(new object[] { "Tên khách hàng", "Tổng số lượng", "Tổng tiền" });
            cbColumn.Location = new Point(309, 130);
            cbColumn.Name = "cbColumn";
            cbColumn.Size = new Size(138, 28);
            cbColumn.TabIndex = 38;
            cbColumn.SelectedIndexChanged += cbColumn_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(271, 133);
            label11.Name = "label11";
            label11.Size = new Size(32, 20);
            label11.TabIndex = 37;
            label11.Text = "Cột";
            // 
            // cbSort
            // 
            cbSort.FormattingEnabled = true;
            cbSort.Items.AddRange(new object[] { "Tăng dần", "Giảm " });
            cbSort.Location = new Point(104, 130);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(138, 28);
            cbSort.TabIndex = 36;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(33, 133);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 35;
            label10.Text = "Sắp xếp";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(482, 133);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 34;
            label9.Text = "Tìm kiếm";
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(482, 467);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(115, 36);
            btnNextPage.TabIndex = 33;
            btnNextPage.Text = "Trang kế";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(286, 468);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(115, 36);
            btnPreviousPage.TabIndex = 32;
            btnPreviousPage.Text = "Trang trước";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // cbNumberRow
            // 
            cbNumberRow.FormattingEnabled = true;
            cbNumberRow.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "100" });
            cbNumberRow.Location = new Point(124, 473);
            cbNumberRow.Name = "cbNumberRow";
            cbNumberRow.Size = new Size(74, 28);
            cbNumberRow.TabIndex = 31;
            cbNumberRow.SelectedIndexChanged += cbNumberRow_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 476);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 30;
            label7.Text = "Số dòng";
            // 
            // dgvShow
            // 
            dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShow.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.Location = new Point(41, 172);
            dgvShow.MultiSelect = false;
            dgvShow.Name = "dgvShow";
            dgvShow.RowHeadersVisible = false;
            dgvShow.RowHeadersWidth = 51;
            dgvShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShow.Size = new Size(779, 241);
            dgvShow.TabIndex = 29;
            dgvShow.CellContentClick += dgvShow_CellContentClick;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(164, 61);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(106, 45);
            btnExport.TabIndex = 41;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 535);
            Controls.Add(btnExport);
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
            Controls.Add(btnAdd);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Index";
            Text = "Index";
            Load += Index_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tệpToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem hàngHóaToolStripMenuItem;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private Button btnAdd;
        private BindingSource orderBindingSource;
        private Label lblNumberPage;
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
        private Button btnExport;
    }
}