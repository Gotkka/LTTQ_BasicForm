﻿using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Drawing.Printing;
using System.Windows.Forms;
using WinFormsCore.Models.Entities;

namespace WinFormsCore.Views
{
    public partial class MainForm : Form
    {
        private int currentPage = 1;
        private int pageSize;
        private IEnumerable<Customer> allCustomers;
        private int totalPage;

        private readonly ShopContext _context;

        public MainForm(ShopContext context)
        {
            InitializeComponent();
            _context = context;
            var filterCustomers = _context.Customers.Where(t => t.FirstName == "Maria").ToList();
            int a = 3;
        }

        private void DisplayCurrentPage()
        {
            if (allCustomers == null || !allCustomers.Any()) return;

            // Lọc khách hàng theo trang hiện tại
            var customersToDisplay = allCustomers
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new
                {
                    STT = c.Id,
                    Ho = c.FirstName,
                    Ten = c.LastName,
                    TinhTP = c.City,
                    QuocGia = c.Country,
                    DienThoai = c.Phone
                })
                .ToList();

            dgvShow.DataSource = customersToDisplay;

            // Cập nhật tiêu đề cột
            dgvShow.Columns["Ho"].HeaderText = "Họ";
            dgvShow.Columns["Ten"].HeaderText = "Tên";
            dgvShow.Columns["TinhTP"].HeaderText = "Tỉnh/TP";
            dgvShow.Columns["QuocGia"].HeaderText = "Quốc Gia";
            dgvShow.Columns["DienThoai"].HeaderText = "Điện thoại";

            // Cập nhật thông tin trang
            lblTrang.Text = $"Trang {currentPage} / {totalPage}";
        }


        private void LoadData()
        {
            // Lấy tất cả khách hàng từ cơ sở dữ liệu
            using (var context = new ShopContext())
            {
                allCustomers = context.Customers.ToList();
            }

            // Cập nhật cài đặt mặc định cho các ComboBox
            cbCot.SelectedIndex = 0;
            cbSapXep.SelectedIndex = 0;

            // Cập nhật số dòng mỗi trang và tính tổng số trang
            pageSize = int.TryParse(cbSoDong.SelectedItem?.ToString(), out var size) ? size : 10;
            UpdateTotalPages();
            DisplayCurrentPage();
        }

        private void UpdateTotalPages()
        {
            totalPage = (int)Math.Ceiling((double)allCustomers.Count() / pageSize);
        }


        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            bool isValid = true;

            isValid &= ValidateTextBox(txbHo, "Họ không được để trống.");
            isValid &= ValidateTextBox(txbTen, "Tên không được để trống.");
            isValid &= ValidateTextBox(txbQuocGia, "Quốc gia không được để trống.");
            isValid &= ValidatePhoneNumber();

            if (cbTinhTP.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbTinhTP, "Vui lòng chọn Tỉnh/TP.");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateTextBox(TextBox textBox, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, errorMessage);
                return false;
            }
            return true;
        }

        private bool ValidatePhoneNumber()
        {
            if (string.IsNullOrWhiteSpace(txbDienThoai.Text))
            {
                errorProvider1.SetError(txbDienThoai, "Điện thoại không được để trống.");
                return false;
            }
            if (!txbDienThoai.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(txbDienThoai, "Điện thoại chỉ được chứa số.");
                return false;
            }
            if (txbDienThoai.Text.Length != 10)
            {
                errorProvider1.SetError(txbDienThoai, "Điện thoại phải có 10 số.");
                return false;
            }
            return true;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var newCustomer = new Customer
                {
                    FirstName = txbHo.Text,
                    LastName = txbTen.Text,
                    City = cbTinhTP.SelectedItem.ToString(),
                    Country = txbQuocGia.Text,
                    Phone = txbDienThoai.Text,
                };

                using (var context = new ShopContext())
                {
                    context.Customers.Add(newCustomer);
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                MessageBox.Show("Khách hàng đã được thêm thành công!");
                LoadData();
            }
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }

        private void cbSoDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSoDong.SelectedItem != null && int.TryParse(cbSoDong.SelectedItem.ToString(), out int newSize))
            {
                pageSize = newSize;
                currentPage = 1; // Trở lại trang đầu
                totalPage = (int)Math.Ceiling((double)allCustomers.Count() / pageSize); // Cập nhật tổng số trang
                DisplayCurrentPage();
            }
        }

        private void cbSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCot.SelectedItem != null && cbSapXep.SelectedItem != null)
            {
                SortCustomers();
            }
        }

        private void cbCot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCot.SelectedItem != null && cbSapXep.SelectedItem != null)
            {
                SortCustomers();
            }
        }

        private void SortCustomers()
        {
            if (allCustomers == null || !allCustomers.Any()) return;

            if (cbCot.SelectedItem == null || cbSapXep.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cột và kiểu sắp xếp.");
                return;
            }

            string selectedColumn = cbCot.SelectedItem.ToString();
            bool ascending = cbSapXep.SelectedItem.ToString() == "Tăng dần";

            // Dùng từ điển để ánh xạ cột với thuộc tính của đối tượng
            var sortExpressions = new Dictionary<string, Func<Customer, object>>()
            {
                { "STT", c => c.Id },
                { "Họ", c => c.FirstName },
                { "Tên", c => c.LastName },
                { "Tỉnh/TP", c => c.City },
                { "Quốc gia", c => c.Country }
            };

            // Kiểm tra xem cột có hợp lệ hay không
            if (!sortExpressions.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột sắp xếp không hợp lệ.");
                return;
            }

            // Lọc và sắp xếp theo cột đã chọn
            var sortedCustomers = ascending
                ? allCustomers.OrderBy(sortExpressions[selectedColumn]).ToList()
                : allCustomers.OrderByDescending(sortExpressions[selectedColumn]).ToList();

            allCustomers = sortedCustomers;

            // Cập nhật tổng số trang và hiển thị dữ liệu sau khi sắp xếp
            totalPage = (int)Math.Ceiling((double)allCustomers.Count() / pageSize);
            DisplayCurrentPage();
        }

        private void SearchCustomers()
        {
            string searchText = txbTimKiem.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    // Nếu không có giá trị tìm kiếm, lấy lại tất cả khách hàng
                    allCustomers = _context.Customers.ToList();
                }
                else
                {
                    // Tìm kiếm trực tiếp từ cơ sở dữ liệu
                    allCustomers = _context.Customers
                        .Where(c => c.FirstName.Contains(searchText) ||
                                    c.LastName.Contains(searchText) ||
                                    c.City.Contains(searchText) ||
                                    c.Country.Contains(searchText) ||
                                    c.Phone.Contains(searchText))
                        .ToList();
                }

                currentPage = 1; // Đặt lại trang đầu
                UpdateTotalPages();
                DisplayCurrentPage();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or show an error message to the user)
                MessageBox.Show($"Error during search: {ex.Message}");
            }
        }


        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            SearchCustomers();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvShow.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                var selectedRow = dgvShow.SelectedRows[0];
                int customerId = (int)selectedRow.Cells["STT"].Value; // Giả sử STT là cột chứa Id khách hàng

                // Tìm khách hàng trong cơ sở dữ liệu
                var customerToUpdate = _context.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customerToUpdate != null)
                {
                    // Cập nhật thông tin từ các TextBox và ComboBox
                    customerToUpdate.FirstName = txbHo.Text;
                    customerToUpdate.LastName = txbTen.Text;
                    customerToUpdate.City = cbTinhTP.SelectedItem?.ToString(); // Kiểm tra nếu có giá trị trong ComboBox
                    customerToUpdate.Country = txbQuocGia.Text;
                    customerToUpdate.Phone = txbDienThoai.Text;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    try
                    {
                        _context.SaveChanges();
                        MessageBox.Show("Thông tin khách hàng đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView sau khi cập nhật thành công
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                var selectedRow = dgvShow.SelectedRows[0];
                int customerId = (int)selectedRow.Cells["STT"].Value; // Giả sử STT là cột chứa Id khách hàng

                // Tìm khách hàng trong cơ sở dữ liệu
                var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customer != null)
                {
                    // Hiển thị thông tin khách hàng vào các TextBox và ComboBox
                    txbHo.Text = customer.FirstName;
                    txbTen.Text = customer.LastName;
                    if (cbTinhTP.Items.Contains(customer.City))
                    {
                        cbTinhTP.SelectedItem = customer.City; // Nếu có, chọn thành phố
                    }
                    else
                    {
                        cbTinhTP.SelectedItem = null; // Nếu không có, để trống ComboBox
                    }

                    txbQuocGia.Text = customer.Country;
                    txbDienThoai.Text = customer.Phone;

                    // Kích hoạt nút cập nhật
                    btnCapNhat.Enabled = true; // Kích hoạt nút cập nhật
                }
            }
            else
            {
                btnCapNhat.Enabled = false; // Vô hiệu hóa nút cập nhật nếu không có hàng nào được chọn
            }
        }


        private void dgvShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Kiểm tra xem có phải nhấp chuột phải không
            {
                // Lấy chỉ mục của hàng được chọn
                var hitTest = dgvShow.HitTest(e.X, e.Y);

                if (hitTest.RowIndex > 0) // Kiểm tra nếu nhấp vào một hàng hợp lệ
                {
                    contextMenuStrip1.Show(dgvShow, e.Location); // Hiển thị ContextMenuStrip tại vị trí chuột
                }
            }
        }


        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                var selectedRow = dgvShow.SelectedRows[0];
                int customerId = (int)selectedRow.Cells["STT"].Value; // Giả sử STT là cột chứa Id khách hàng

                // Tìm khách hàng trong cơ sở dữ liệu
                var customerToUpdate = _context.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customerToUpdate != null)
                {
                    // Cập nhật thông tin từ các TextBox và ComboBox
                    customerToUpdate.FirstName = txbHo.Text;
                    customerToUpdate.LastName = txbTen.Text;
                    customerToUpdate.City = cbTinhTP.SelectedItem?.ToString(); // Kiểm tra nếu có giá trị trong ComboBox
                    customerToUpdate.Country = txbQuocGia.Text;
                    customerToUpdate.Phone = txbDienThoai.Text;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    try
                    {
                        _context.SaveChanges();
                        MessageBox.Show("Thông tin khách hàng đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView sau khi cập nhật thành công
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvShow.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                var selectedRow = dgvShow.SelectedRows[0];
                int customerId = (int)selectedRow.Cells["STT"].Value; // Giả sử STT là cột chứa Id khách hàng

                // Tìm khách hàng trong cơ sở dữ liệu
                var customerToDelete = _context.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customerToDelete != null)
                {
                    // Tạo thông báo xác nhận xóa với họ và tên của khách hàng
                    string message = $"Bạn có chắc chắn muốn xóa khách hàng {customerToDelete.FirstName} {customerToDelete.LastName}?";
                    var confirmResult = MessageBox.Show(message, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Xóa khách hàng khỏi cơ sở dữ liệu
                        _context.Customers.Remove(customerToDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        try
                        {
                            _context.SaveChanges();
                            MessageBox.Show("Khách hàng đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại DataGridView sau khi xóa thành công
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Đã xảy ra lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}