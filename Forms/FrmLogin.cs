using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevSolutions.Dal; // Importa la clase DBConnection

namespace DevSolutions.Forms
{
    public partial class FrmLogin : Form
    {
        // 🔹 No es necesario crear instancia si DBConnection es estática
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT Usuario_Rol 
                        FROM SEG.Tb_Usuarios
                        WHERE Usuario_Usuario = @usuario 
                        AND Usuario_Contrasena = @contrasena;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        object rol = cmd.ExecuteScalar();

                        if (rol != null)
                        {
                            string rolUsuario = rol.ToString();

                            MessageBox.Show($"✅ Bienvenido {usuario} ({rolUsuario})",
                                "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cargar formulario según el rol
                            Form menuForm;

                            if (rolUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                                menuForm = new FrmMenuAdmin();
                            else
                                menuForm = new FrmMenuUsuario(true);

                            menuForm.FormClosed += (s, args) => this.Show();
                            menuForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("❌ Usuario o contraseña incorrectos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("⚠️ Error de conexión a la base de datos:\n" + ex.Message,
                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error inesperado:\n" + ex.Message,
                    "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // ✅ Mostrar el resultado de la prueba de conexión
            string resultado = DBConnection.TestConnectionWithDetails();
            MessageBox.Show(resultado, "Prueba de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
