namespace WinFormsCore.Views
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pbLogo = new PictureBox();
            lblUsername = new Label();
            panel1 = new Panel();
            txtUsername = new TextBox();
            panel2 = new Panel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(136, 16);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(471, 127);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(35, 34);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = " Tài khoản";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblUsername);
            panel1.Location = new Point(136, 164);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 75);
            panel1.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(119, 31);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(279, 27);
            txtUsername.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(lblPassword);
            panel2.Location = new Point(136, 245);
            panel2.Name = "panel2";
            panel2.Size = new Size(471, 72);
            panel2.TabIndex = 3;
            // 
            // txtPassword
            // 
            errorProvider1.SetIconAlignment(txtPassword, ErrorIconAlignment.BottomLeft);
            txtPassword.Location = new Point(119, 32);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(279, 27);
            txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(35, 35);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(312, 323);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(140, 51);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pbLogo);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Label lblUsername;
        private Panel panel1;
        private TextBox txtUsername;
        private Panel panel2;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private ErrorProvider errorProvider1;
    }
}