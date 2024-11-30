using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Doc.Documents;
//using Spire.Presentation;
using Spire.Xls;
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
    public partial class Index : Form
    {
        private int currentPage = 1;
        private int pageSize = 10; // Kích thước mỗi trang (số lượng đơn hàng mỗi trang)
        private int totalPage;
        private IEnumerable<Order> allOrders;
        private readonly ShopContext context;

        // Constructor now correctly assigns the context
        public Index(ShopContext _context)
        {
            InitializeComponent();
            context = _context;  // Properly initialize the context
        }

        private void LoadData()
        {
            // Lấy dữ liệu đơn hàng từ cơ sở dữ liệu
            allOrders = GetOrderData();

            // Thực hiện sắp xếp dữ liệu dựa trên lựa chọn của người dùng
            SortOrder();

            // Tính toán tổng số trang dựa trên tổng số đơn hàng và kích thước trang
            totalPage = (int)Math.Ceiling(allOrders.Count() / (double)pageSize);

            // Lấy đơn hàng cho trang hiện tại
            var pagedOrders = allOrders.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            // Xóa tất cả các hàng cũ trước khi thêm dữ liệu mới
            dgvShow.Rows.Clear();

            // Kiểm tra nếu có dữ liệu để hiển thị
            if (pagedOrders.Any())
            {
                // Thêm các cột cho DataGridView nếu chưa có
                if (dgvShow.Columns.Count == 0)
                {
                    dgvShow.Columns.Add("OrderId", "Order ID");
                    dgvShow.Columns["OrderId"].Visible = false; // Cột này ẩn đi
                    dgvShow.Columns.Add("TenKhachHang", "Tên Khách Hàng");
                    dgvShow.Columns.Add("TongSoLuong", "Tổng Số Lượng");
                    dgvShow.Columns.Add("TongTien", "Tổng Tiền");

                    // Thêm cột Button cho Chi Tiết
                    DataGridViewButtonColumn btnChiTiet = new DataGridViewButtonColumn();
                    btnChiTiet.HeaderText = "Chi Tiết";
                    btnChiTiet.Text = "Xem Chi Tiết";
                    btnChiTiet.UseColumnTextForButtonValue = true;
                    dgvShow.Columns.Add(btnChiTiet);
                }

                // Lặp qua dữ liệu và thêm vào DataGridView
                foreach (var order in pagedOrders)
                {
                    int rowIndex = dgvShow.Rows.Add();
                    dgvShow.Rows[rowIndex].Cells["OrderId"].Value = order.Id;
                    dgvShow.Rows[rowIndex].Cells["TenKhachHang"].Value = order.Customer.FirstName + " " + order.Customer.LastName;
                    dgvShow.Rows[rowIndex].Cells["TongSoLuong"].Value = order.OrderItems.Sum(c => c.Quantity);
                    dgvShow.Rows[rowIndex].Cells["TongTien"].Value = order.TotalAmount;
                }
            }

            // Hiển thị thông tin phân trang
            lblNumberPage.Text = $"Trang {currentPage} của {totalPage}";
        }




        private IEnumerable<Order> GetOrderData()
        {
            var orders = (from o in context.Orders
                          join oi in context.OrderItems on o.Id equals oi.OrderId
                          join c in context.Customers on o.CustomerId equals c.Id
                          group new { oi.Quantity, oi.UnitPrice, c.FirstName, c.LastName, o.TotalAmount, o.OrderNumber } by o.Id into orderGroup
                          select new Order
                          {
                              Id = orderGroup.Key,
                              Customer = new Customer
                              {
                                  FirstName = orderGroup.First().FirstName,
                                  LastName = orderGroup.First().LastName
                              },
                              TotalAmount = orderGroup.First().TotalAmount,
                              OrderNumber = orderGroup.First().OrderNumber,
                              OrderItems = orderGroup.Select(og => new OrderItem
                              {
                                  Quantity = og.Quantity,
                                  UnitPrice = og.UnitPrice
                              }).ToList()
                          }).ToList();

            return orders;
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products productForm = new Products(context);  // Pass the existing ShopContext
            this.Hide();
            productForm.Show();
            productForm.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers customerForm = new Customers(context);  // Pass the existing ShopContext
            this.Hide();
            customerForm.Show();
            customerForm.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void Index_Load(object sender, EventArgs e)
        {
            // Đặt chỉ mục mặc định cho cbSort và cbColumn nếu có ít nhất một mục
            if (cbSort.Items.Count > 0)
            {
                cbSort.SelectedIndex = 0; // Chọn chỉ mục đầu tiên của cbSort
            }

            if (cbColumn.Items.Count > 0)
            {
                cbColumn.SelectedIndex = 0; // Chọn chỉ mục đầu tiên của cbColumn
            }

            LoadData(); // Tải dữ liệu ban đầu
        }

        private void tệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Index_Load(sender, e);
        }


        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadData();
            }
        }

        private void SortOrder()
        {
            if (allOrders == null || !allOrders.Any()) return;

            // Kiểm tra nếu người dùng chưa chọn cột hoặc kiểu sắp xếp
            if (cbColumn.SelectedItem == null || cbSort.SelectedItem == null)
            {
                //MessageBox.Show("Vui lòng chọn cột và kiểu sắp xếp.");
                return;
            }

            string selectedColumn = cbColumn.SelectedItem.ToString(); // Tên cột
            bool ascending = cbSort.SelectedItem.ToString() == "Tăng dần"; // Kiểm tra kiểu sắp xếp

            // Ánh xạ cột với thuộc tính của Order
            var sortExpressions = new Dictionary<string, Func<Order, object>>()
            {
                { "Tên khách hàng", o => o.Customer.FirstName + " " + o.Customer.LastName },
                { "Tổng số lượng", o => o.OrderItems.Sum(oi => oi.Quantity) },
                { "Tổng tiền", o => o.TotalAmount }
            };

            // Kiểm tra xem cột có hợp lệ hay không
            if (!sortExpressions.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột sắp xếp không hợp lệ.");
                return;
            }

            // Lọc và sắp xếp theo cột đã chọn
            var sortedOrders = ascending
                ? allOrders.OrderBy(sortExpressions[selectedColumn]).ToList()
                : allOrders.OrderByDescending(sortExpressions[selectedColumn]).ToList();

            allOrders = sortedOrders;

            // Cập nhật tổng số trang và hiển thị dữ liệu sau khi sắp xếp
            totalPage = (int)Math.Ceiling((double)allOrders.Count() / pageSize);
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();  // Tải lại dữ liệu với sắp xếp mới
        }

        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();  // Tải lại dữ liệu với sắp xếp mới
        }

        private void cbNumberRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một mục hợp lệ trong cbNumberRow
            if (cbNumberRow.SelectedItem != null && int.TryParse(cbNumberRow.SelectedItem.ToString(), out int newSize))
            {
                pageSize = newSize;  // Cập nhật số dòng mỗi trang
                currentPage = 1;  // Trở về trang đầu tiên

                // Tính toán lại tổng số trang với số dòng mỗi trang mới
                totalPage = (int)Math.Ceiling((double)allOrders.Count() / pageSize);

                // Tải lại dữ liệu với số dòng mỗi trang mới
                LoadData();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Tạo một Workbook (Sổ làm việc Excel)
            IWorkbook workbook = new XSSFWorkbook();

            // Tạo một sheet (Trang tính)
            ISheet sheet = workbook.CreateSheet("Orders");

            // Tạo dòng tiêu đề
            IRow headerRow = sheet.CreateRow(0);

            // Thêm các cột vào dòng tiêu đề
            headerRow.CreateCell(0).SetCellValue("Tên Khách Hàng");
            headerRow.CreateCell(1).SetCellValue("Tổng Số Lượng");
            headerRow.CreateCell(2).SetCellValue("Tổng Tiền");

            // Duyệt qua tất cả các hàng trong DataGridView và thêm vào sheet Excel
            int rowIndex = 1;
            foreach (DataGridViewRow row in dgvShow.Rows)
            {
                // Đảm bảo không thêm dòng trống
                if (row.IsNewRow) continue;

                IRow dataRow = sheet.CreateRow(rowIndex++);

                // Lấy giá trị từ các cột trong DataGridView và ghi vào sheet Excel
                dataRow.CreateCell(0).SetCellValue(row.Cells["TenKhachHang"].Value.ToString());
                dataRow.CreateCell(1).SetCellValue(Convert.ToDouble(row.Cells["TongSoLuong"].Value));
                dataRow.CreateCell(2).SetCellValue(Convert.ToDouble(row.Cells["TongTien"].Value));
            }

            // Lưu file Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "Orders.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);  // Ghi workbook vào file
                }
                MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng nhấn vào cột "Chi Tiết"
                if (e.RowIndex >= 0 && dgvShow.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    dgvShow.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    // Lấy OrderId từ hàng được chọn
                    var orderId = dgvShow.Rows[e.RowIndex].Cells["OrderId"].Value;

                    if (orderId == null || !(orderId is int))
                    {
                        MessageBox.Show("Không thể lấy thông tin OrderId. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Hiển thị thông tin OrderId (nếu cần kiểm tra)
                    // MessageBox.Show($"OrderId: {orderId}");

                    // Mở form OrderDetails với OrderId tương ứng
                    OrderDetails orderDetailsForm = new OrderDetails(context, (int)orderId);
                    orderDetailsForm.Show();

                    // Ẩn form hiện tại
                    this.Hide();

                    orderDetailsForm.FormClosed += (s, args) =>
                    {
                        this.Show();
                    };
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo cho người dùng
                MessageBox.Show($"Đã xảy ra lỗi khi mở chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo form AddOrderForm và truyền ShopContext
                AddOrder addOrderForm = new AddOrder(context);

                // Hiển thị form dưới dạng dialog
                var dialogResult = addOrderForm.ShowDialog();

                // Kiểm tra nếu người dùng đã thêm thành công đơn hàng
                if (dialogResult == DialogResult.OK)
                {
                    // Thông báo thành công
                    MessageBox.Show("Đơn hàng đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu để hiển thị đơn hàng mới
                    LoadData();
                }
                else
                {
                    // Trường hợp người dùng hủy hoặc đóng form mà không thêm đơn hàng
                    MessageBox.Show("Bạn đã hủy thao tác thêm đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, hiển thị thông báo nếu có lỗi xảy ra
                MessageBox.Show($"Đã xảy ra lỗi khi thêm đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchOrder();
        }


        private void SearchOrder()
        {
            string searchText = txtSearch.Text.Trim();

            using (var context = new ShopContext())
            {
                try
                {
                    // Kiểm tra nếu không có từ khóa tìm kiếm
                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        allOrders = context.Orders
                            .Include(o => o.Customer)  // Bao gồm thông tin khách hàng
                            .ToList(); // Lấy tất cả đơn hàng
                    }
                    else
                    {
                        decimal searchPrice;
                        bool isNumeric = decimal.TryParse(searchText, out searchPrice);

                        // Tìm kiếm đơn hàng theo các tiêu chí: Mã đơn hàng, tên khách hàng (FirstName + LastName), số lượng (Quantity), và tổng tiền (TotalAmount)
                        allOrders = context.Orders
                            .Include(o => o.Customer)  // Bao gồm thông tin khách hàng
                            .Include(o => o.OrderItems) // Bao gồm thông tin các mục đơn hàng (OrderItems)
                            .Where(o => (o.Customer.FirstName + " " + o.Customer.LastName).Contains(searchText) ||  // Tìm theo tên khách hàng
                                        o.OrderItems.Any(oi => oi.Quantity.ToString().Contains(searchText)) ||  // Tìm theo số lượng trong OrderItems
                                        (isNumeric && o.TotalAmount == searchPrice)) // Tìm theo tổng tiền
                            .ToList();

                    }

                    // Kiểm tra kết quả tìm kiếm
                    if (allOrders.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng nào khớp với từ khóa tìm kiếm.");
                    }

                    // Hiển thị dữ liệu trong DataGridView
                    dgvShow.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView

                    foreach (var order in allOrders)
                    {
                        string fullName = $"{order.Customer.FirstName} {order.Customer.LastName}"; // Nối tên khách hàng
                        dgvShow.Rows.Add(order.Id, fullName, order.OrderDate.ToString("dd/MM/yyyy"), order.TotalAmount);
                    }

                    // Thiết lập lại trang hiện tại và cập nhật thông tin hiển thị
                    currentPage = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi tìm kiếm đơn hàng: {ex.Message}");
                }
            }
        }




    }
}

