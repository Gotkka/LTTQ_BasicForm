using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Doc;
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
using Table = Spire.Doc.Table;

namespace WinFormsCore.Views
{
    public partial class OrderDetails : Form
    {
        private readonly ShopContext context;
        private readonly int id;
        public OrderDetails(ShopContext context, int id)
        {
            InitializeComponent();
            this.context = context;
            this.id = id;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            try
            {
                var order = context.Orders
                                   .Include(o => o.Customer)
                                   .Include(o => o.OrderItems)
                                       .ThenInclude(oi => oi.Product)
                                   .Where(o => o.Id == id)
                                   .Select(o => new
                                   {
                                       o.Id,
                                       CustomerName = o.Customer.FirstName + " " + o.Customer.LastName,
                                       o.OrderDate,
                                       o.TotalAmount,
                                       Items = o.OrderItems.Select(oi => new
                                       {
                                           ProductName = oi.Product.ProductName,
                                           oi.Quantity,
                                           oi.UnitPrice,
                                           TotalPrice = oi.Quantity * oi.UnitPrice
                                       }).ToList()
                                   })
                                   .FirstOrDefault();

                if (order != null)
                {
                    // Hiển thị thông tin của đơn hàng
                    lblOrderNumber.Text = $"Mã Đơn Hàng: {order.Id}";
                    lblCustomerName.Text = $"Tên Khách Hàng: {order.CustomerName}";
                    lblOrderDate.Text = $"Ngày Đặt Hàng: {order.OrderDate:dd/MM/yyyy}";
                    lblTotalAmount.Text = $"Tổng Tiền: {order.TotalAmount:C}";

                    // Hiển thị danh sách sản phẩm trong đơn hàng lên DataGridView
                    dgvShow.DataSource = order.Items;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin đơn hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string baseDirectory = Application.StartupPath;
                string filePath = Path.Combine(baseDirectory, "OrderDetailsWord", "Form.docx");

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Không tìm thấy file mẫu 'Form.docx'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Tải file Word mẫu
                Document doc = new Document();
                doc.LoadFromFile(filePath);

                // Lấy thông tin từ các label trong form
                string orderNumber = lblOrderNumber.Text.Substring(lblOrderNumber.Text.IndexOf(":") + 1).Trim();
                string customerName = lblCustomerName.Text.Substring(lblCustomerName.Text.IndexOf(":") + 1).Trim();
                string orderDate = lblOrderDate.Text.Substring(lblOrderDate.Text.IndexOf(":") + 1).Trim();
                string totalAmount = lblTotalAmount.Text.Substring(lblTotalAmount.Text.IndexOf(":") + 1).Trim();

                // Thay thế các placeholders trong tài liệu với giá trị thực tế
                doc.Replace("{orderNumber}", orderNumber, false, true);
                doc.Replace("{customerName}", customerName, false, true);
                doc.Replace("{orderDate}", orderDate, false, true);
                doc.Replace("{totalAmount}", totalAmount, false, true);

                // Thay thế danh sách sản phẩm vào phần {dgvShow}
                StringBuilder productList = new StringBuilder();
                for (int i = 0; i < dgvShow.RowCount; i++)
                {
                    string productName = dgvShow.Rows[i].Cells["ProductName"].Value.ToString();
                    string quantity = dgvShow.Rows[i].Cells["Quantity"].Value.ToString();
                    string unitPrice = dgvShow.Rows[i].Cells["UnitPrice"].Value.ToString();
                    string totalPrice = dgvShow.Rows[i].Cells["TotalPrice"].Value.ToString();

                    productList.AppendLine($"{productName} - {quantity} x {unitPrice} = {totalPrice}");
                }

                // Thay thế phần danh sách sản phẩm
                doc.Replace("{dgvShow}", productList.ToString(), false, true);

                // Lưu tệp Word
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Word Documents|*.docx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    doc.SaveToFile(saveFileDialog.FileName, Spire.Doc.FileFormat.Docx);
                    MessageBox.Show("Đã xuất đơn hàng sang file Word thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
