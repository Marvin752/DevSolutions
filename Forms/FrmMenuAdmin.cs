using System;
using System.Windows.Forms;

namespace DevSolutions.Forms
{
    public partial class FrmMenuAdmin : Form
    {
        public FrmMenuAdmin()
        {
            InitializeComponent();
        }

        // ==========================================================
        // 🔹 Botón: Gestión de Productos
        // ==========================================================
        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                // Evita abrir múltiples ventanas del mismo formulario
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
                // 🔹 Soltar foco antes de abrir el nuevo formulario
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
                // Vuelve al login
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
        }

        // ==========================================================
        // 🔹 Evento Load (opcional)
        // ==========================================================
        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {
            // Aquí podrías cargar datos o estadísticas generales del sistema si se desea.
        }
    }
}
