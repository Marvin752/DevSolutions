using System;
using System.Windows.Forms;

namespace DevSolutions.Forms
{
    public partial class FrmMenuAdmin : Form
    {
        private Form _loginForm; // 🔹 Referencia al formulario de login original

        // ==========================================================
        // 🔹 Constructor que recibe la instancia del login
        // ==========================================================
        public FrmMenuAdmin(Form loginForm = null)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        // ==========================================================
        // 🔹 Botón: Gestión de Productos
        // ==========================================================
        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is FrmProductos)
                    {
                        f.Focus();
                        return;
                    }
                }
                FrmProductos frm = new FrmProductos();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la gestión de productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Botón: Gestión de Inventario
        // ==========================================================
        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is FrmInventarios)
                    {
                        f.Focus();
                        return;
                    }
                }
                FrmInventarios frm = new FrmInventarios();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la gestión de inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Botón: Generar Reporte
        // ==========================================================
        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = null;
                FrmReporte frm = new FrmReporte();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Botón: Cerrar Sesión
        // ==========================================================
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 🔹 Reutiliza el login original si existe
                if (_loginForm != null && !_loginForm.IsDisposed)
                {
                    _loginForm.Show();
                    this.Close();
                }
                else
                {
                    // Si no existe, crea uno nuevo
                    FrmLogin login = new FrmLogin();
                    login.Show();
                    this.Close();
                }
            }
        }

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {
            // Código opcional
        }
    }
}