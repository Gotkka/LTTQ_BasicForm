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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = "quangvinh120504";
            var password = "vinh12052004";

            if (ValidateInputs() == false)
            { 
                return;
            }

            // Xác thực tài khoản
            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                // Mở form Index
                var context = new ShopContext();
                Index indexForm = new Index(context);
                this.Hide(); // Ẩn form hiện tại nếu cần
                indexForm.Show(); // Hoặc ShowDialog() nếu muốn form này là modal
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            isValid &= ValidateTextBox(txtUsername, "Tên đăng nhập không được để trống.");
            isValid &= ValidateTextBox(txtPassword, "Mật khẩu không được để trống.");

            return isValid;
        }


    }
}
