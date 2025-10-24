using System;
using System.Windows.Forms;

namespace DevSolutions.Forms
{
    public partial class FrmMenuUsuario : Form
    {
        private readonly bool soloLectura;
        private Form _loginForm; // 🔹 Referencia al formulario de login original

        // ==========================================================
        // 🔹 Constructor sin parámetros
        // ==========================================================
        public FrmMenuUsuario()
        {
            InitializeComponent();
        }

        // ==========================================================
        // 🔹 Constructor que recibe modo lectura y el login
        // ==========================================================
        public FrmMenuUsuario(bool soloLectura, Form loginForm = null) : this()
        {
            this.soloLectura = soloLectura;
            _loginForm = loginForm;
        }

        // ==========================================================
        // 🔹 Evento Load
        // ==========================================================
        private void FrmMenuUsuario_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "Bienvenido al menú de usuario";

            if (soloLectura)
            {
                MessageBox.Show("Modo usuario: solo lectura activado.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================================
        // 🔹 Botón: Ver Productos (solo lectura)
        // ==========================================================
        private void btnVerProductos_Click(object sender, EventArgs e)
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

                FrmProductos frm = new FrmProductos(true);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la vista de productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Botón: Ver Inventario (solo lectura)
        // ==========================================================
        private void btnVerInventario_Click(object sender, EventArgs e)
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
                MessageBox.Show("Error al abrir la vista de inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Botón: Generar Reporte
        // ==========================================================
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
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

    }
}