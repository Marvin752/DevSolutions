using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevSolutions.Dal;
using DevSolutions.Models;

namespace DevSolutions.Forms
{
    public partial class FrmInventarios : Form
    {
        private readonly InventarioDAL inventarioDAL = new InventarioDAL();

        public FrmInventarios()
        {
            InitializeComponent();
        }

        // ==========================================================
        // 🔹 Evento de carga del formulario
        // ==========================================================
        private void FrmInventarios_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarProductos();
            CargarEstanterias();
            CargarInventarios();
        }

        // ==========================================================
        // 🔹 Configurar controles iniciales
        // ==========================================================
        private void ConfigurarControles()
        {
            // Limpiar textos placeholder
            txtCantidad.Text = "";
            txtPrecioVenta.Text = "";
            textBoxDescuento.Text = "0";

            // Configurar DataGridView para mejor visualización
            dgvInventarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventarios.MultiSelect = false;
            dgvInventarios.ReadOnly = true;

            // ✅ Cambiar el evento a CellClick en lugar de CellContentClick
            dgvInventarios.CellClick += dgvInventarios_CellClick;
        }

        // ==========================================================
        // 🔹 Cargar productos en el ComboBox
        // ==========================================================
        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT Producto_Id, Producto_Nombre FROM INV.Tb_Productos ORDER BY Producto_Nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbProducto.DataSource = dt;
                    cmbProducto.DisplayMember = "Producto_Nombre";
                    cmbProducto.ValueMember = "Producto_Id";
                    cmbProducto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar estanterías en el ComboBox
        // ==========================================================
        private void CargarEstanterias()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT Estanteria_Id, Estanteria_Codigo FROM INV.Tb_Estanterias ORDER BY Estanteria_Codigo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    comboBoxEstanterias.DataSource = dt;
                    comboBoxEstanterias.DisplayMember = "Estanteria_Codigo";
                    comboBoxEstanterias.ValueMember = "Estanteria_Id";
                    comboBoxEstanterias.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando estanterías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar inventarios existentes en el DataGridView
        // ==========================================================
        private void CargarInventarios()
        {
            try
            {
                DataTable dt = inventarioDAL.ObtenerInventarios();
                dgvInventarios.DataSource = dt;

                // ✅ Mostrar el ID del inventario (pero solo lectura)
                if (dgvInventarios.Columns.Contains("Inventario_Id"))
                {
                    dgvInventarios.Columns["Inventario_Id"].HeaderText = "ID";
                    dgvInventarios.Columns["Inventario_Id"].Width = 50;
                    dgvInventarios.Columns["Inventario_Id"].Visible = true; // ✅ Ahora visible
                }

                // Ocultar columnas de IDs relacionales
                if (dgvInventarios.Columns.Contains("Producto_Id"))
                    dgvInventarios.Columns["Producto_Id"].Visible = false;

                if (dgvInventarios.Columns.Contains("Estanteria_Id"))
                    dgvInventarios.Columns["Estanteria_Id"].Visible = false;

                // Renombrar encabezados para mejor presentación
                if (dgvInventarios.Columns.Contains("Inventario_Cantidad"))
                    dgvInventarios.Columns["Inventario_Cantidad"].HeaderText = "Cantidad";

                if (dgvInventarios.Columns.Contains("Inventario_PrecioVenta"))
                {
                    dgvInventarios.Columns["Inventario_PrecioVenta"].HeaderText = "Precio Venta";
                    dgvInventarios.Columns["Inventario_PrecioVenta"].DefaultCellStyle.Format = "C2";
                }

                if (dgvInventarios.Columns.Contains("Inventario_Descuento"))
                {
                    dgvInventarios.Columns["Inventario_Descuento"].HeaderText = "Descuento";
                    dgvInventarios.Columns["Inventario_Descuento"].DefaultCellStyle.Format = "N2";
                }

                if (dgvInventarios.Columns.Contains("Inventario_FechaActualizacion"))
                {
                    dgvInventarios.Columns["Inventario_FechaActualizacion"].HeaderText = "Fecha Actualización";
                    dgvInventarios.Columns["Inventario_FechaActualizacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando inventarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Validar formulario
        // ==========================================================
        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = "";

            if (cmbProducto.SelectedIndex == -1)
            {
                mensajeError = "Seleccione un producto.";
                cmbProducto.Focus();
                return false;
            }

            if (comboBoxEstanterias.SelectedIndex == -1)
            {
                mensajeError = "Seleccione una estantería.";
                comboBoxEstanterias.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                mensajeError = "Ingrese una cantidad.";
                txtCantidad.Focus();
                return false;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad < 0)
            {
                mensajeError = "La cantidad debe ser un número entero mayor o igual a 0.";
                txtCantidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                mensajeError = "Ingrese un precio de venta.";
                txtPrecioVenta.Focus();
                return false;
            }

            decimal precioVenta;
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta) || precioVenta < 0)
            {
                mensajeError = "El precio de venta debe ser un número mayor o igual a 0.";
                txtPrecioVenta.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBoxDescuento.Text))
            {
                decimal descuento;
                if (!decimal.TryParse(textBoxDescuento.Text, out descuento) || descuento < 0)
                {
                    mensajeError = "El descuento debe ser un número mayor o igual a 0.";
                    textBoxDescuento.Focus();
                    return false;
                }
            }

            return true;
        }

        // ==========================================================
        // 🔹 Agregar nuevo inventario
        // ==========================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeError;
                if (!ValidarFormulario(out mensajeError))
                {
                    MessageBox.Show(mensajeError, "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear inventario con fecha automática
                Inventario inv = CrearInventarioDesdeFormulario();
                inventarioDAL.InsertarInventario(inv);

                MessageBox.Show("✅ Inventario agregado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarInventarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar inventario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Actualizar inventario existente
        // ==========================================================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInventarioId.Text))
                {
                    MessageBox.Show("Seleccione un inventario del grid haciendo clic en una fila.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string mensajeError;
                if (!ValidarFormulario(out mensajeError))
                {
                    MessageBox.Show(mensajeError, "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear inventario con fecha actual
                Inventario inv = CrearInventarioDesdeFormulario();
                inv.InventarioId = int.Parse(txtInventarioId.Text);

                inventarioDAL.ActualizarInventario(inv);

                MessageBox.Show("✅ Inventario actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarInventarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar inventario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Crear objeto Inventario desde el formulario
        // ✅ LA FECHA SE ASIGNA AUTOMÁTICAMENTE CON DateTime.Now
        // ==========================================================
        private Inventario CrearInventarioDesdeFormulario()
        {
            return new Inventario
            {
                ProductoId = Convert.ToInt32(cmbProducto.SelectedValue),
                EstanteriaId = Convert.ToInt32(comboBoxEstanterias.SelectedValue),
                Descuento = string.IsNullOrWhiteSpace(textBoxDescuento.Text) ? 0 : decimal.Parse(textBoxDescuento.Text),
                Cantidad = int.Parse(txtCantidad.Text),
                PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                FechaActualizacion = DateTime.Now // ✅ SIEMPRE FECHA ACTUAL
            };
        }

        // ==========================================================
        // 🔹 ✅ MÉTODO MEJORADO - Click en DataGridView (CellClick)
        // ==========================================================
        private void dgvInventarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow fila = dgvInventarios.Rows[e.RowIndex];

                // ✅ Cargar ID del inventario en txtInventarioId
                if (fila.Cells["Inventario_Id"].Value != null && fila.Cells["Inventario_Id"].Value != DBNull.Value)
                {
                    txtInventarioId.Text = fila.Cells["Inventario_Id"].Value.ToString();
                }

                // ✅ Cargar producto - MEJORADO
                if (fila.Cells["Producto_Id"].Value != null && fila.Cells["Producto_Id"].Value != DBNull.Value)
                {
                    int productoId = Convert.ToInt32(fila.Cells["Producto_Id"].Value);
                    cmbProducto.SelectedValue = productoId;

                    // Si no se seleccionó correctamente, intentar de otra forma
                    if (cmbProducto.SelectedValue == null || Convert.ToInt32(cmbProducto.SelectedValue) != productoId)
                    {
                        for (int i = 0; i < cmbProducto.Items.Count; i++)
                        {
                            DataRowView item = (DataRowView)cmbProducto.Items[i];
                            if (Convert.ToInt32(item["Producto_Id"]) == productoId)
                            {
                                cmbProducto.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }

                // ✅ Cargar estantería - MEJORADO
                if (fila.Cells["Estanteria_Id"].Value != null && fila.Cells["Estanteria_Id"].Value != DBNull.Value)
                {
                    int estanteriaId = Convert.ToInt32(fila.Cells["Estanteria_Id"].Value);
                    comboBoxEstanterias.SelectedValue = estanteriaId;

                    // Si no se seleccionó correctamente, intentar de otra forma
                    if (comboBoxEstanterias.SelectedValue == null || Convert.ToInt32(comboBoxEstanterias.SelectedValue) != estanteriaId)
                    {
                        for (int i = 0; i < comboBoxEstanterias.Items.Count; i++)
                        {
                            DataRowView item = (DataRowView)comboBoxEstanterias.Items[i];
                            if (Convert.ToInt32(item["Estanteria_Id"]) == estanteriaId)
                            {
                                comboBoxEstanterias.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }

                // ✅ Cargar descuento
                if (fila.Cells["Inventario_Descuento"].Value != null && fila.Cells["Inventario_Descuento"].Value != DBNull.Value)
                {
                    textBoxDescuento.Text = fila.Cells["Inventario_Descuento"].Value.ToString();
                }
                else
                {
                    textBoxDescuento.Text = "0";
                }

                // ✅ Cargar cantidad
                if (fila.Cells["Inventario_Cantidad"].Value != null && fila.Cells["Inventario_Cantidad"].Value != DBNull.Value)
                {
                    txtCantidad.Text = fila.Cells["Inventario_Cantidad"].Value.ToString();
                }
                else
                {
                    txtCantidad.Text = "";
                }

                // ✅ Cargar precio de venta
                if (fila.Cells["Inventario_PrecioVenta"].Value != null && fila.Cells["Inventario_PrecioVenta"].Value != DBNull.Value)
                {
                    // Remover formato de moneda si existe
                    decimal precioVenta = Convert.ToDecimal(fila.Cells["Inventario_PrecioVenta"].Value);
                    txtPrecioVenta.Text = precioVenta.ToString("0.00");
                }
                else
                {
                    txtPrecioVenta.Text = "";
                }

                // ✅ NO CARGAMOS LA FECHA porque siempre se actualizará al guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar inventario: {ex.Message}\n\nDetalles: {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 ⚠️ MANTENER ESTE MÉTODO PARA COMPATIBILIDAD CON EL DISEÑADOR
        // ==========================================================
        private void dgvInventarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este método lo llama el diseñador, pero redirige a CellClick
            dgvInventarios_CellClick(sender, e);
        }

        // ==========================================================
        // 🔹 Limpiar campos del formulario
        // ==========================================================
        private void LimpiarCampos()
        {
            txtInventarioId.Clear();
            txtCantidad.Clear();
            txtPrecioVenta.Clear();
            textBoxDescuento.Text = "0";
            cmbProducto.SelectedIndex = -1;
            comboBoxEstanterias.SelectedIndex = -1;
            cmbProducto.Focus();
        }

        // ==========================================================
        // 🔹 Botón limpiar
        // ==========================================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // ==========================================================
        // 🔹 Regresar al menú principal
        // ==========================================================
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenuAdmin menu = new FrmMenuAdmin();
            menu.Show();
            this.Hide();
        }

        // ==========================================================
        // 🔹 Evento del ComboBox de productos (opcional)
        // ==========================================================
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes agregar lógica adicional aquí si lo necesitas
        }
    }
}