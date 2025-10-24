namespace DevSolutions.Forms
{
    partial class FrmMenuUsuario
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
            lblBienvenida = new Label();
            btnVerProductos = new Button();
            btnVerInventario = new Button();
            btnGenerarReporte = new Button();
            btnCerrarSesion = new Button();
            panelHeader = new Panel();
            panelButtons = new Panel();
            panelHeader.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblBienvenida);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 100);
            panelHeader.TabIndex = 5;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(250, 30);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(280, 46);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Panel Usuario";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnVerProductos);
            panelButtons.Controls.Add(btnVerInventario);
            panelButtons.Controls.Add(btnGenerarReporte);
            panelButtons.Location = new Point(200, 150);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(400, 280);
            panelButtons.TabIndex = 6;
            // 
            // btnVerProductos
            // 
            btnVerProductos.BackColor = Color.FromArgb(52, 152, 219);
            btnVerProductos.FlatAppearance.BorderSize = 0;
            btnVerProductos.FlatStyle = FlatStyle.Flat;
            btnVerProductos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVerProductos.ForeColor = Color.White;
            btnVerProductos.Location = new Point(50, 30);
            btnVerProductos.Name = "btnVerProductos";
            btnVerProductos.Size = new Size(300, 60);
            btnVerProductos.TabIndex = 1;
            btnVerProductos.Text = "VER PRODUCTOS";
            btnVerProductos.UseVisualStyleBackColor = false;
            btnVerProductos.Click += btnVerProductos_Click;
            // 
            // btnVerInventario
            // 
            btnVerInventario.BackColor = Color.FromArgb(46, 204, 113);
            btnVerInventario.FlatAppearance.BorderSize = 0;
            btnVerInventario.FlatStyle = FlatStyle.Flat;
            btnVerInventario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVerInventario.ForeColor = Color.White;
            btnVerInventario.Location = new Point(50, 110);
            btnVerInventario.Name = "btnVerInventario";
            btnVerInventario.Size = new Size(300, 60);
            btnVerInventario.TabIndex = 2;
            btnVerInventario.Text = "VER INVENTARIO";
            btnVerInventario.UseVisualStyleBackColor = false;
            btnVerInventario.Click += btnVerInventario_Click;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.FromArgb(155, 89, 182);
            btnGenerarReporte.FlatAppearance.BorderSize = 0;
            btnGenerarReporte.FlatStyle = FlatStyle.Flat;
            btnGenerarReporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.Location = new Point(50, 190);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(300, 60);
            btnGenerarReporte.TabIndex = 3;
            btnGenerarReporte.Text = "GENERAR REPORTE PDF";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(30, 490);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(180, 45);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "CERRAR SESIÓN";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FrmMenuUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(800, 562);
            Controls.Add(btnCerrarSesion);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Name = "FrmMenuUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DevSolutions - Panel Usuario";
            Load += FrmMenuUsuario_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblBienvenida;
        private Button btnVerProductos;
        private Button btnVerInventario;
        private Button btnGenerarReporte;
        private Button btnCerrarSesion;
        private Panel panelHeader;
        private Panel panelButtons;
    }
}