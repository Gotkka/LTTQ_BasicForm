using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
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
    public partial class AddOrder : Form
    {
        private readonly ShopContext context;

        public AddOrder(ShopContext _context)
        {
            InitializeComponent();
            context = _context;
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProductData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            var products = context.Products.ToList();
            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "ProductName";
            cbProduct.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin sản phẩm và số lượng từ giao diện người dùng
                var productId = (int)cbProduct.SelectedValue;
                var product = context.Products.Find(productId);
                var quantity = int.Parse(txtQuantity.Text);
                var totalAmount = product.UnitPrice * quantity;

                // Kiểm tra xem sản phẩm đã có trong DataGridView chưa
                bool productExists = false;
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.Cells["ProductName"].Value.ToString() == product.ProductName)
                    {
                        // Cập nhật số lượng và tổng tiền nếu sản phẩm đã có
                        var oldQuantity = (int)row.Cells["Quantity"].Value;
                        row.Cells["Quantity"].Value = oldQuantity + quantity;
                        row.Cells["TotalAmount"].Value = (oldQuantity + quantity) * product.UnitPrice;

                        // Tính lại tổng tiền
                        CalculateTotalAmount();
                        productExists = true;
                        break;
                    }
                }

                // Nếu sản phẩm chưa có, thêm sản phẩm mới vào DataGridView
                if (!productExists)
                {
                    dgvProducts.Rows.Add(product.ProductName, product.UnitPrice, quantity, totalAmount);
                    // Tính lại tổng tiền
                    CalculateTotalAmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["TotalAmount"].Value);
            }

            txtTotalAmount.Text = totalAmount.ToString(); // Hiển thị tổng tiền dưới dạng tiền tệ
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView không
                if (dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dòng đang được chọn trong DataGridView
                var selectedRow = dgvProducts.SelectedRows[0];

                // Lấy thông tin sản phẩm và số lượng mới từ giao diện người dùng
                var productId = (int)cbProduct.SelectedValue;
                var product = context.Products.Find(productId);
                var quantity = int.Parse(txtQuantity.Text);
                var totalAmount = product.UnitPrice * quantity;

                // Cập nhật thông tin cho dòng được chọn
                selectedRow.Cells["ProductName"].Value = product.ProductName;
                selectedRow.Cells["Quantity"].Value = quantity;
                selectedRow.Cells["TotalAmount"].Value = totalAmount;

                // Tính lại tổng tiền
                CalculateTotalAmount();

                //MessageBox.Show("Sản phẩm đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn không
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    // Lấy hàng đã chọn và xóa nó
                    foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                    {
                        // Xóa hàng khỏi DataGridView
                        dgvProducts.Rows.Remove(row);
                    }

                    // Tính lại tổng tiền sau khi xóa sản phẩm
                    CalculateTotalAmount();
                }
                else
                {
                    // Thông báo nếu không có hàng nào được chọn
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var firstName = txtFirstName.Text.Trim();
                var lastName = txtLastName.Text.Trim();

                // Kiểm tra nếu họ tên khách hàng chưa nhập đầy đủ
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ họ tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem khách hàng đã tồn tại trong cơ sở dữ liệu chưa
                var existingCustomer = context.Customers.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

                Customer customer;

                if (existingCustomer == null)
                {
                    // Nếu khách hàng chưa tồn tại, tạo khách hàng mới
                    customer = new Customer { FirstName = firstName, LastName = lastName };
                    context.Customers.Add(customer);
                    context.SaveChanges(); // Lưu khách hàng mới vào cơ sở dữ liệu

                    MessageBox.Show("Khách hàng mới đã được thêm vào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    customer = existingCustomer; // Nếu khách hàng đã tồn tại, lấy khách hàng đã có
                }

                // Tạo một đơn hàng mới và gán ID khách hàng
                var order = new Order
                {
                    CustomerId = customer.Id, // Lưu ID khách hàng
                    OrderDate = DateTime.Now,          // Ngày đặt hàng
                    TotalAmount = decimal.Parse(txtTotalAmount.Text) // Tổng tiền đơn hàng
                };

                context.Orders.Add(order);
                context.SaveChanges(); // Lưu đơn hàng vào cơ sở dữ liệu

                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.Cells["ProductName"].Value != null)
                    {
                        var productName = row.Cells["ProductName"].Value.ToString();
                        var unitPrice = decimal.Parse(row.Cells["UnitPrice"].Value.ToString());
                        var quantity = int.Parse(row.Cells["Quantity"].Value.ToString());

                        var product = context.Products.FirstOrDefault(p => p.ProductName == productName);

                        if (product != null)
                        {
                            var orderDetail = new OrderItem
                            {
                                OrderId = order.Id,
                                ProductId = product.Id,
                                Quantity = quantity,
                                UnitPrice = unitPrice,
                            };

                            context.OrderItems.Add(orderDetail);
                        }
                    }
                }

                context.SaveChanges(); // Lưu chi tiết đơn hàng vào cơ sở dữ liệu

                //MessageBox.Show("Đơn hàng đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Lấy thông tin đơn hàng vừa lưu
                var savedOrder = context.Orders.Include(o => o.OrderItems)
                                               .ThenInclude(oi => oi.Product) // Đảm bảo rằng sản phẩm được tải kèm theo
                                               .FirstOrDefault(o => o.Id == order.Id);

                if (savedOrder != null)
                {
                    // Chuỗi để lưu thông tin đơn hàng
                    StringBuilder orderDetails = new StringBuilder();
                    orderDetails.AppendLine($"Mã đơn hàng: {savedOrder.Id}");
                    orderDetails.AppendLine($"Khách hàng: {savedOrder.Customer.FirstName} {savedOrder.Customer.LastName}");
                    orderDetails.AppendLine($"Ngày đặt hàng: {savedOrder.OrderDate.ToString("dd/MM/yyyy")}");
                    orderDetails.AppendLine($"Tổng tiền: {savedOrder.TotalAmount:C}");

                    // Thêm danh sách các sản phẩm trong đơn hàng
                    orderDetails.AppendLine("\nDanh sách sản phẩm:");
                    foreach (var item in savedOrder.OrderItems)
                    {
                        orderDetails.AppendLine($"{item.Product.ProductName} - {item.Quantity} - {item.UnitPrice:C} = {(item.Quantity * item.UnitPrice):C}");
                    }

                    // Hiển thị thông tin đơn hàng trong MessageBox
                    MessageBox.Show(orderDetails.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Đóng form AddOrder và quay lại form chính
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
