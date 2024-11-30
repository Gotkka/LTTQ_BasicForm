using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCore.Models.Entities;

namespace WinFormsCore.Views
{
    public partial class Products : Form
    {
        private int currentPage = 1;
        private int pageSize;
        private IEnumerable<Product> allProducts;
        private int totalPage;

        private readonly ShopContext context;
        public Products(ShopContext _context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            //dgvShow.ClearSelection();
            LoadData();
        }
        private void DisplayCurrentPage()
        {
            if (allProducts == null || !allProducts.Any()) return;

            // Lọc khách hàng theo trang hiện tại
            var customersToDisplay = allProducts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new
                {
                    STT = c.Id,
                    Ten = c.ProductName,
                    NhaCungCap = GetSupplierNameById(c.SupplierId),
                    Gia = c.UnitPrice,
                    Goi = c.Package
                })
                .ToList();

            dgvShow.DataSource = customersToDisplay;

            // Cập nhật tiêu đề cột
            dgvShow.Columns["Ten"].HeaderText = "Tên";
            dgvShow.Columns["Gia"].HeaderText = "Giá";
            dgvShow.Columns["Goi"].HeaderText = "Gói";
            dgvShow.Columns["NhaCungCap"].HeaderText = "Nhà cung cấp";

            // Cập nhật thông tin trang
            lblNumberPage.Text = $"Trang {currentPage} / {totalPage}";
        }
        private string GetSupplierNameById(int supplierId)
        {
            using (var context = new ShopContext())
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.Id == supplierId);
                return supplier != null ? supplier.CompanyName : "Không xác định";
            }
        }

        private int GetSupplierIdByName(string supplierName)
        {
            using (var context = new ShopContext())
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.CompanyName == supplierName);
                return supplier != null ? supplier.Id : 0; // Giả sử 0 là giá trị mặc định nếu không tìm thấy
            }
        }

        private void LoadData()
        {
            using (var context = new ShopContext())
            {
                allProducts = context.Products.ToList();
            }

            cbColumn.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;

            pageSize = int.TryParse(cbNumberRow.SelectedItem?.ToString(), out var size) ? size : 10;
            UpdateTotalPages();
            DisplayCurrentPage();
        }

        private void UpdateTotalPages()
        {
            totalPage = (int)Math.Ceiling((double)allProducts.Count() / pageSize);
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

        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            bool isValid = true;

            isValid &= ValidateTextBox(txtProductName, "Tên không được để trống.");
            isValid &= ValidateTextBox(txtSupplierName, "Nhà cung cấp không được để trống.");
            isValid &= ValidateTextBox(txtUnitPrice, "Giá không được để trống.");
            isValid &= ValidateTextBox(txtPackage, "Gói không được để trống.");

            return isValid;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                using (var context = new ShopContext())
                {
                    var supplier = context.Suppliers.FirstOrDefault(s => s.CompanyName == txtSupplierName.Text);
                    if (supplier == null)
                    {
                        supplier = new Supplier
                        {
                            CompanyName = txtSupplierName.Text,
                        };

                        context.Suppliers.Add(supplier);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Nhà cung cấp mới đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng thêm sản phẩm nếu xảy ra lỗi
                        }
                    }

                    var newProduct = new Product
                    {
                        ProductName = txtProductName.Text,
                        SupplierId = supplier.Id,
                        UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                        Package = txtPackage.Text,
                    };

                    context.Products.Add(newProduct);
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sản phẩm mới đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                var selectedRow = dgvShow.SelectedRows[0];
                int productId = (int)selectedRow.Cells["STT"].Value;

                using (var context = new ShopContext())
                {
                    var product = context.Products.FirstOrDefault(c => c.Id == productId);
                    if (product != null)
                    {
                        txtProductName.Text = product.ProductName;
                        txtSupplierName.Text = GetSupplierNameById(product.SupplierId);
                        txtUnitPrice.Text = product.UnitPrice.ToString();
                        txtPackage.Text = product.Package;

                        // Kích hoạt nút cập nhật
                        btnUpdate.Enabled = true; // Kích hoạt nút cập nhật
                    }
                }
            }
            else
            {
                btnUpdate.Enabled = false; // Vô hiệu hóa nút cập nhật nếu không có hàng nào được chọn
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvShow.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                var selectedRow = dgvShow.SelectedRows[0];
                int productId = (int)selectedRow.Cells["STT"].Value; // Giả sử STT là cột chứa Id sản phẩm

                using (var context = new ShopContext())
                {
                    // Tìm sản phẩm trong cơ sở dữ liệu
                    var productToUpdate = context.Products.FirstOrDefault(p => p.Id == productId);

                    if (productToUpdate != null)
                    {
                        // Cập nhật thông tin từ các TextBox
                        productToUpdate.ProductName = txtProductName.Text;
                        var supplier = context.Suppliers.FirstOrDefault(s => s.CompanyName == txtSupplierName.Text);
                        if (supplier == null)
                        {
                            supplier = new Supplier
                            {
                                CompanyName = txtSupplierName.Text,
                            };

                            context.Suppliers.Add(supplier);
                            try
                            {
                                context.SaveChanges();
                                MessageBox.Show("Nhà cung cấp mới đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Dừng thêm sản phẩm nếu xảy ra lỗi
                            }
                        }
                        productToUpdate.SupplierId = GetSupplierIdByName(txtSupplierName.Text); // Hàm lấy SupplierId từ tên
                        productToUpdate.UnitPrice = decimal.TryParse(txtUnitPrice.Text, out var price) ? price : 0;
                        productToUpdate.Package = txtPackage.Text;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Thông tin sản phẩm đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SortProduct()
        {
            if (allProducts == null || !allProducts.Any()) return;

            // Kiểm tra nếu người dùng chưa chọn cột hoặc kiểu sắp xếp
            if (cbColumn.SelectedItem == null || cbSort.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cột và kiểu sắp xếp.");
                return;
            }

            string selectedColumn = cbColumn.SelectedItem.ToString(); // Tên cột
            bool ascending = cbSort.SelectedItem.ToString() == "Tăng dần"; // Kiểm tra kiểu sắp xếp

            // Ánh xạ cột với thuộc tính của Product
            var sortExpressions = new Dictionary<string, Func<Product, object>>()
            {
                { "STT", p => p.Id },
                { "Tên sản phẩm", p => p.ProductName },
                { "Nhà Cung Cấp", p => GetSupplierNameById(p.SupplierId) },
                { "Giá", p => p.UnitPrice },
                { "Gói", p => p.Package }
            };

            // Kiểm tra xem cột có hợp lệ hay không
            if (!sortExpressions.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột sắp xếp không hợp lệ.");
                return;
            }

            // Lọc và sắp xếp theo cột đã chọn
            var sortedProducts = ascending
                ? allProducts.OrderBy(sortExpressions[selectedColumn]).ToList()
                : allProducts.OrderByDescending(sortExpressions[selectedColumn]).ToList();

            allProducts = sortedProducts;

            // Cập nhật tổng số trang và hiển thị dữ liệu sau khi sắp xếp
            totalPage = (int)Math.Ceiling((double)allProducts.Count() / pageSize);
            DisplayCurrentPage();
        }


        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColumn.SelectedItem != null && cbSort.SelectedItem != null)
            {
                SortProduct();
            }
        }

        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColumn.SelectedItem != null && cbSort.SelectedItem != null)
            {
                SortProduct();
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }

        private void cbNumberRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNumberRow.SelectedItem != null && int.TryParse(cbNumberRow.SelectedItem.ToString(), out int newSize))
            {
                pageSize = newSize;
                currentPage = 1; // Trở lại trang đầu
                totalPage = (int)Math.Ceiling((double)allProducts.Count() / pageSize); // Cập nhật tổng số trang
                DisplayCurrentPage();
            }
        }

        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvShow.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                var selectedRow = dgvShow.SelectedRows[0];
                int productId = (int)selectedRow.Cells["STT"].Value; // Giả sử STT là cột chứa Id sản phẩm

                using (var context = new ShopContext())
                {
                    // Tìm sản phẩm trong cơ sở dữ liệu
                    var productToUpdate = context.Products.FirstOrDefault(p => p.Id == productId);

                    if (productToUpdate != null)
                    {
                        // Cập nhật thông tin từ các TextBox
                        productToUpdate.ProductName = txtProductName.Text;
                        var supplier = context.Suppliers.FirstOrDefault(s => s.CompanyName == txtSupplierName.Text);
                        if (supplier == null)
                        {
                            supplier = new Supplier
                            {
                                CompanyName = txtSupplierName.Text,
                            };

                            context.Suppliers.Add(supplier);
                            try
                            {
                                context.SaveChanges();
                                MessageBox.Show("Nhà cung cấp mới đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Dừng thêm sản phẩm nếu xảy ra lỗi
                            }
                        }
                        productToUpdate.SupplierId = GetSupplierIdByName(txtSupplierName.Text); // Hàm lấy SupplierId từ tên
                        productToUpdate.UnitPrice = decimal.TryParse(txtUnitPrice.Text, out var price) ? price : 0;
                        productToUpdate.Package = txtPackage.Text;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Thông tin sản phẩm đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvShow.SelectedRows.Count > 0)
            {
                var selectedRow = dgvShow.SelectedRows[0];
                int productId = (int)selectedRow.Cells["STT"].Value; // Giả sử "STT" là cột chứa Id sản phẩm

                using (var context = new ShopContext())
                {
                    // Tìm sản phẩm trong cơ sở dữ liệu
                    var productToDelete = context.Products.FirstOrDefault(p => p.Id == productId);
                    if (productToDelete != null)
                    {
                        // Xóa sản phẩm
                        context.Products.Remove(productToDelete);

                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Sản phẩm đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại DataGridView sau khi xóa thành công
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Đã xảy ra lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file Excel
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Chọn tệp Excel";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Đọc dữ liệu từ file Excel
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                ISheet sheet = workbook.GetSheetAt(0); // Chọn sheet đầu tiên trong workbook

                // Chèn dữ liệu vào cơ sở dữ liệu
                InsertDataIntoDatabase(sheet);

                // Đóng tệp Excel
                fileStream.Close();

                MessageBox.Show("Dữ liệu đã được nhập vào cơ sở dữ liệu thành công!");
                LoadData();
            }
        }

        private void InsertDataIntoDatabase(ISheet sheet)
        {
            // Sử dụng Entity Framework để thêm dữ liệu vào cơ sở dữ liệu
            using (var context = new ShopContext())
            {
                // Lặp qua từng dòng trong sheet Excel và chèn dữ liệu vào cơ sở dữ liệu
                for (int i = 1; i <= sheet.LastRowNum; i++) // Bắt đầu từ dòng 1 (dòng 0 là tiêu đề)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    // Lấy giá trị của từng ô trong dòng
                    string productName = row.GetCell(1)?.ToString();  // Cột 1: Tên sản phẩm
                    string supplierName = row.GetCell(2)?.ToString(); // Cột 2: Tên nhà cung cấp
                    string unitPrice = row.GetCell(3)?.ToString();    // Cột 3: Giá
                    string package = row.GetCell(4)?.ToString();      // Cột 4: Gói

                    // Nếu các giá trị không null hoặc rỗng, tiến hành chèn vào cơ sở dữ liệu
                    if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(supplierName) && !string.IsNullOrEmpty(unitPrice) && !string.IsNullOrEmpty(package))
                    {
                        // Kiểm tra xem nhà cung cấp đã tồn tại chưa
                        var supplier = context.Suppliers.FirstOrDefault(s => s.CompanyName == supplierName);

                        // Nếu nhà cung cấp chưa tồn tại, thêm mới vào bảng Suppliers
                        if (supplier == null)
                        {
                            supplier = new Supplier
                            {
                                CompanyName = supplierName
                            };
                            context.Suppliers.Add(supplier);
                            context.SaveChanges();  // Lưu nhà cung cấp mới vào cơ sở dữ liệu
                        }

                        // Chuyển đổi giá trị đơn giá sang decimal
                        decimal parsedUnitPrice = decimal.TryParse(unitPrice, out decimal result) ? result : 0;

                        // Tạo đối tượng Product từ dữ liệu Excel
                        var product = new Product
                        {
                            ProductName = productName,
                            SupplierId = supplier.Id,  // Sử dụng supplier.Id để chèn vào database
                            UnitPrice = parsedUnitPrice,
                            Package = package
                        };

                        // Thêm đối tượng Product vào DbSet<Product> (chưa lưu ngay vào database)
                        context.Products.Add(product);
                    }
                }

                // Lưu tất cả thay đổi vào cơ sở dữ liệu chỉ một lần sau khi đã thêm tất cả sản phẩm
                context.SaveChanges();
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một Workbook mới
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                // Tạo hàng tiêu đề từ DataGridView
                IRow headerRow = sheet.CreateRow(0);
                for (int i = 0; i < dgvShow.Columns.Count; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(dgvShow.Columns[i].HeaderText);
                }

                // Thêm dữ liệu từ DataGridView vào các hàng Excel
                for (int i = 0; i < dgvShow.Rows.Count; i++)
                {
                    if (dgvShow.Rows[i].IsNewRow) continue;  // Bỏ qua dòng trống

                    IRow row = sheet.CreateRow(i + 1); // Bắt đầu từ dòng 1 (dòng 0 là tiêu đề)
                    for (int j = 0; j < dgvShow.Columns.Count; j++)
                    {
                        var cellValue = dgvShow.Rows[i].Cells[j].Value;
                        if (cellValue != null)
                        {
                            row.CreateCell(j).SetCellValue(cellValue.ToString());
                        }
                    }
                }

                // Lưu tệp Excel
                string filePath = @"D:\LAPTRINHTRUCQUAN\LTTQ_19102024\WinFormsCore (1)\WinFormsCore\ProductsExcel\ProductsExport.xlsx";  // Đảm bảo rằng đường dẫn tồn tại
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                MessageBox.Show("Dữ liệu đã được xuất ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void SearchProduct()
        {
            string searchText = txtSearch.Text.Trim();

            using(var context = new ShopContext())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        allProducts = context.Products.ToList();
                    }
                    else
                    {
                        decimal searchPrice;
                        bool isNumeric = decimal.TryParse(searchText, out searchPrice);

                        allProducts = context.Products
                            .Where(c => c.ProductName.Contains(searchText) ||
                                        (c.Supplier != null && c.Supplier.CompanyName.Contains(searchText)) ||
                                        (isNumeric && c.UnitPrice == searchPrice) ||  // Kiểm tra trực tiếp giá trị số
                                        c.Package.Contains(searchText))
                            .ToList();

                    }

                    if (allProducts.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm nào khớp với từ khóa tìm kiếm.");
                    }

                    currentPage = 1;
                    UpdateTotalPages();
                    DisplayCurrentPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during search: {ex.Message}");
                }
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct();
        }
    }

}