namespace DevSolutions.Forms
{
    partial class FrmMenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuAdmin));
            label1 = new Label();
            btnProductos = new Button();
            btnInventario = new Button();
            btnReporte = new Button();
            btnCerrarSesion = new Button();
            panelHeader = new Panel();
            panelButtons = new Panel();
            panelHeader.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(280, 30);
            label1.Name = "label1";
            label1.Size = new Size(349, 46);
            label1.TabIndex = 0;
            label1.Text = "Panel Administrador";
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(52, 152, 219);
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(50, 30);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(300, 60);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "GESTIÓN DE PRODUCTOS";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.FromArgb(46, 204, 113);
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(50, 110);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(300, 60);
            btnInventario.TabIndex = 2;
            btnInventario.Text = "GESTIÓN DE INVENTARIO";
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnReporte
            // 
            btnReporte.BackColor = Color.FromArgb(155, 89, 182);
            btnReporte.FlatAppearance.BorderSize = 0;
            btnReporte.FlatStyle = FlatStyle.Flat;
            btnReporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReporte.ForeColor = Color.White;
            btnReporte.Location = new Point(50, 190);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(300, 60);
            btnReporte.TabIndex = 3;
            btnReporte.Text = "GENERAR REPORTE PDF";
            btnReporte.UseVisualStyleBackColor = false;
            btnReporte.Click += btnReporte_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(30, 520);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(180, 45);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "CERRAR SESIÓN";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(882, 100);
            panelHeader.TabIndex = 5;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnProductos);
            panelButtons.Controls.Add(btnInventario);
            panelButtons.Controls.Add(btnReporte);
            panelButtons.Location = new Point(241, 150);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(400, 300);
            panelButtons.TabIndex = 6;
            // 
            // FrmMenuAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(882, 590);
            Controls.Add(btnCerrarSesion);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMenuAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DevSolutions - Panel Administrador";
            Load += FrmMenuAdmin_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnProductos;
        private Button btnInventario;
        private Button btnReporte;
        private Button btnCerrarSesion;
        private Panel panelHeader;
        private Panel panelButtons;
    }
}