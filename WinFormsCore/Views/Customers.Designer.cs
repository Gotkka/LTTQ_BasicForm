namespace WinFormsCore.Views
{
    partial class Customers
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnCapNhat = new Button();
            btnThemMoi = new Button();
            panel5 = new Panel();
            txbDienThoai = new TextBox();
            label6 = new Label();
            panel4 = new Panel();
            txbQuocGia = new TextBox();
            label5 = new Label();
            panel3 = new Panel();
            txbTen = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            cbTinhTP = new ComboBox();
            label3 = new Label();
            panel1 = new Panel();
            txbHo = new TextBox();
            label2 = new Label();
            dgvShow = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            chỉnhSửaToolStripMenuItem = new ToolStripMenuItem();
            xóaToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            label7 = new Label();
            cbSoDong = new ComboBox();
            btnTrangTruoc = new Button();
            btnTrangSau = new Button();
            label9 = new Label();
            cbSapXep = new ComboBox();
            label10 = new Label();
            cbCot = new ComboBox();
            label11 = new Label();
            txbTimKiem = new TextBox();
            lblTrang = new Label();
            groupBox1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(259, 9);
            label1.Name = "label1";
            label1.Size = new Size(278, 76);
            label1.TabIndex = 0;
            label1.Text = "Quản lý khách hàng\r\n\r\n";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCapNhat);
            groupBox1.Controls.Add(btnThemMoi);
            groupBox1.Controls.Add(panel5);
            groupBox1.Controls.Add(panel4);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(38, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(723, 270);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khách hàng";
            // 
            // btnCapNhat
            // 
            btnCapNhat.Enabled = false;
            btnCapNhat.Location = new Point(514, 185);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(125, 45);
            btnCapNhat.TabIndex = 6;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Location = new Point(360, 185);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(124, 45);
            btnThemMoi.TabIndex = 5;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = true;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(txbDienThoai);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(67, 182);
            panel5.Name = "panel5";
            panel5.Size = new Size(287, 55);
            panel5.TabIndex = 4;
            // 
            // txbDienThoai
            // 
            txbDienThoai.Location = new Point(88, 7);
            txbDienThoai.Name = "txbDienThoai";
            txbDienThoai.Size = new Size(153, 27);
            txbDienThoai.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 10);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 0;
            label6.Text = "Điện thoại";
            // 
            // panel4
            // 
            panel4.Controls.Add(txbQuocGia);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(352, 117);
            panel4.Name = "panel4";
            panel4.Size = new Size(287, 55);
            panel4.TabIndex = 3;
            // 
            // txbQuocGia
            // 
            txbQuocGia.Location = new Point(79, 7);
            txbQuocGia.Name = "txbQuocGia";
            txbQuocGia.Size = new Size(168, 27);
            txbQuocGia.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 10);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 0;
            label5.Text = "Quốc gia";
            // 
            // panel3
            // 
            panel3.Controls.Add(txbTen);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(67, 117);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 55);
            panel3.TabIndex = 2;
            // 
            // txbTen
            // 
            txbTen.Location = new Point(70, 7);
            txbTen.Name = "txbTen";
            txbTen.Size = new Size(171, 27);
            txbTen.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 10);
            label4.Name = "label4";
            label4.Size = new Size(32, 20);
            label4.TabIndex = 0;
            label4.Text = "Tên";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbTinhTP);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(352, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(287, 55);
            panel2.TabIndex = 1;
            // 
            // cbTinhTP
            // 
            cbTinhTP.FormattingEnabled = true;
            cbTinhTP.Items.AddRange(new object[] { "An Giang", "Bà Rịa - Vũng Tàu", "Bạc Liêu", "Bắc Giang", "Bắc Kạn", "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "TP Hồ Chí Minh", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái" });
            cbTinhTP.Location = new Point(79, 8);
            cbTinhTP.Name = "cbTinhTP";
            cbTinhTP.Size = new Size(168, 28);
            cbTinhTP.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 10);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 0;
            label3.Text = "Tỉnh/TP";
            // 
            // panel1
            // 
            panel1.Controls.Add(txbHo);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(67, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 55);
            panel1.TabIndex = 0;
            // 
            // txbHo
            // 
            txbHo.Location = new Point(70, 7);
            txbHo.Name = "txbHo";
            txbHo.Size = new Size(171, 27);
            txbHo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 10);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 0;
            label2.Text = "Họ";
            // 
            // dgvShow
            // 
            dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.ContextMenuStrip = contextMenuStrip1;
            dgvShow.Location = new Point(38, 422);
            dgvShow.Name = "dgvShow";
            dgvShow.RowHeadersVisible = false;
            dgvShow.RowHeadersWidth = 51;
            dgvShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShow.Size = new Size(723, 262);
            dgvShow.TabIndex = 2;
            dgvShow.SelectionChanged += dgvShow_SelectionChanged;
            dgvShow.MouseUp += dgvShow_MouseUp;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { chỉnhSửaToolStripMenuItem, xóaToolStripMenuItem, exportToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 76);
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
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(142, 24);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(38, 726);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 3;
            label7.Text = "Số dòng";
            // 
            // cbSoDong
            // 
            cbSoDong.FormattingEnabled = true;
            cbSoDong.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "100" });
            cbSoDong.Location = new Point(129, 723);
            cbSoDong.Name = "cbSoDong";
            cbSoDong.Size = new Size(74, 28);
            cbSoDong.TabIndex = 4;
            cbSoDong.SelectedIndexChanged += cbSoDong_SelectedIndexChanged;
            // 
            // btnTrangTruoc
            // 
            btnTrangTruoc.Location = new Point(291, 718);
            btnTrangTruoc.Name = "btnTrangTruoc";
            btnTrangTruoc.Size = new Size(115, 36);
            btnTrangTruoc.TabIndex = 5;
            btnTrangTruoc.Text = "Trang trước";
            btnTrangTruoc.UseVisualStyleBackColor = true;
            btnTrangTruoc.Click += btnTrangTruoc_Click;
            // 
            // btnTrangSau
            // 
            btnTrangSau.Location = new Point(487, 717);
            btnTrangSau.Name = "btnTrangSau";
            btnTrangSau.Size = new Size(115, 36);
            btnTrangSau.TabIndex = 6;
            btnTrangSau.Text = "Trang kế";
            btnTrangSau.UseVisualStyleBackColor = true;
            btnTrangSau.Click += btnTrangSau_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(487, 383);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 8;
            label9.Text = "Tìm kiếm";
            // 
            // cbSapXep
            // 
            cbSapXep.FormattingEnabled = true;
            cbSapXep.Items.AddRange(new object[] { "Tăng dần", "Giảm " });
            cbSapXep.Location = new Point(109, 380);
            cbSapXep.Name = "cbSapXep";
            cbSapXep.Size = new Size(138, 28);
            cbSapXep.TabIndex = 10;
            cbSapXep.SelectedIndexChanged += cbSapXep_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(38, 383);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 9;
            label10.Text = "Sắp xếp";
            // 
            // cbCot
            // 
            cbCot.FormattingEnabled = true;
            cbCot.Items.AddRange(new object[] { "STT", "Họ", "Tên", "Tỉnh/TP", "Quốc gia" });
            cbCot.Location = new Point(314, 380);
            cbCot.Name = "cbCot";
            cbCot.Size = new Size(138, 28);
            cbCot.TabIndex = 12;
            cbCot.SelectedIndexChanged += cbCot_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(276, 383);
            label11.Name = "label11";
            label11.Size = new Size(32, 20);
            label11.TabIndex = 11;
            label11.Text = "Cột";
            // 
            // txbTimKiem
            // 
            txbTimKiem.Location = new Point(563, 379);
            txbTimKiem.Name = "txbTimKiem";
            txbTimKiem.Size = new Size(198, 27);
            txbTimKiem.TabIndex = 13;
            txbTimKiem.TextChanged += txbTimKiem_TextChanged;
            // 
            // lblTrang
            // 
            lblTrang.AutoSize = true;
            lblTrang.Location = new Point(628, 726);
            lblTrang.Name = "lblTrang";
            lblTrang.Size = new Size(58, 20);
            lblTrang.TabIndex = 14;
            lblTrang.Text = "label12";
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 842);
            Controls.Add(lblTrang);
            Controls.Add(txbTimKiem);
            Controls.Add(cbCot);
            Controls.Add(label11);
            Controls.Add(cbSapXep);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(btnTrangSau);
            Controls.Add(btnTrangTruoc);
            Controls.Add(cbSoDong);
            Controls.Add(label7);
            Controls.Add(dgvShow);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Customers";
            Text = "Main";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Panel panel1;
        private Panel panel5;
        private TextBox txbDienThoai;
        private Label label6;
        private Panel panel4;
        private TextBox txbQuocGia;
        private Label label5;
        private Panel panel3;
        private TextBox txbTen;
        private TextBox textBox3;
        private Label label4;
        private Panel panel2;
        private TextBox textBox2;
        private Label label3;
        private TextBox txbHo;
        private Label label2;
        private Button btnCapNhat;
        private Button btnThemMoi;
        private ComboBox cbTinhTP;
        private DataGridView dgvShow;
        private ErrorProvider errorProvider1;
        private Button btnTrangTruoc;
        private ComboBox cbSoDong;
        private Label label7;
        private Label label9;
        private Button btnTrangSau;
        private Label lblTrang;
        private TextBox txbTimKiem;
        private ComboBox cbCot;
        private Label label11;
        private ComboBox cbSapXep;
        private Label label10;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem chỉnhSửaToolStripMenuItem;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
    }
}
