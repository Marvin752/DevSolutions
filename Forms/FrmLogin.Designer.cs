namespace DevSolutions.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblTitulo = new Label();
            panelLogin = new Panel();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;
            panelLogin.Controls.Add(lblTitulo);
            panelLogin.Controls.Add(lblUsuario);
            panelLogin.Controls.Add(txtUsuario);
            panelLogin.Controls.Add(lblPassword);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Location = new Point(380, 150);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(460, 400);
            panelLogin.TabIndex = 5;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitulo.Location = new Point(120, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 45);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Iniciar Sesión";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11F);
            lblUsuario.ForeColor = Color.FromArgb(52, 73, 94);
            lblUsuario.Location = new Point(70, 130);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(71, 25);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(70, 160);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(320, 32);
            txtUsuario.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F);
            lblPassword.ForeColor = Color.FromArgb(52, 73, 94);
            lblPassword.Location = new Point(70, 210);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(101, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(70, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 32);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(70, 310);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(320, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "INICIAR SESIÓN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1219, 706);
            Controls.Add(panelLogin);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DevSolutions - Login";
            Load += FrmLogin_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblTitulo;
        private Panel panelLogin;
    }
}