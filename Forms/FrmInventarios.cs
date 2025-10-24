using System;
using System.Data;
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
            CargarProductos();
            CargarInventarios();

            // Vinculamos el evento del ComboBox
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
        }

        // ==========================================================
        // 🔹 Cargar productos en el ComboBox
        // ==========================================================
        private void CargarProductos()
        {
            try
            {
                using (var conn = DBConnection.GetConnection())

                {
                    conn.Open();
                    var cmd = new System.Data.SqlClient.SqlCommand(
                        "SELECT Producto_Id, Nombre FROM INV.Tb_Productos", conn);
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbProducto.DataSource = dt;
                    cmbProducto.DisplayMember = "Nombre";
                    cmbProducto.ValueMember = "Producto_Id";
                    cmbProducto.SelectedIndex = -1; // Inicia vacío
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}");
            }
        }

        // ==========================================================
        // 🔹 Cargar inventarios existentes
        // ==========================================================
        private void CargarInventarios()
        {
            try
            {
                dgvInventarios.DataSource = inventarioDAL.ObtenerInventarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventarios: {ex.Message}");
            }
        }

        // ==========================================================
        // 🔹 Cuando se selecciona un producto en el ComboBox
        // ==========================================================
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null || cmbProducto.SelectedIndex == -1)
                return;

            try
            {
                int productoId = Convert.ToInt32(cmbProducto.SelectedValue);

                using (var conn = DBConnection.GetConnection())

                {
                    conn.Open();

                    // ✅ Incluimos Producto_Id en el SELECT
                    var cmd = new System.Data.SqlClient.SqlCommand(
                        @"SELECT Producto_Id, SKU, PrecioVenta, Descuento, Stock 
                  FROM INV.Tb_Productos 
                  WHERE Producto_Id = @id", conn);

                    cmd.Parameters.AddWithValue("@id", productoId);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // ✅ Ya no dará error porque Producto_Id está incluido
                        txtInventarioId.Text = reader["Producto_Id"].ToString();
                        txtPrecioVenta.Text = reader["PrecioVenta"].ToString();
                        txtDescuento.Text = reader["Descuento"].ToString();
                        txtCantidad.Text = reader["Stock"].ToString();

                        // Opcional: si tienes un campo SKU
                        if (Controls.Find("txtSKU", true).Length > 0)
                            Controls.Find("txtSKU", true)[0].Text = reader["SKU"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos del producto seleccionado.");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del producto: {ex.Message}");
            }
        }


        // ==========================================================
        // 🔹 Agregar nuevo inventario
        // ==========================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un producto.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Ingrese una cantidad.");
                    return;
                }

                Inventario inv = CrearInventarioDesdeFormulario();
                inventarioDAL.InsertarInventario(inv);

                MessageBox.Show("Inventario agregado correctamente.");
                CargarInventarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar inventario: {ex.Message}");
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
                    MessageBox.Show("Seleccione un inventario para actualizar.");
                    return;
                }

                Inventario inv = CrearInventarioDesdeFormulario();
                inv.InventarioId = int.Parse(txtInventarioId.Text);

                inventarioDAL.ActualizarInventario(inv);
                MessageBox.Show("Inventario actualizado correctamente.");
                CargarInventarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar inventario: {ex.Message}");
            }
        }

        // ==========================================================
        // 🔹 Crear objeto Inventario
        // ==========================================================
        private Inventario CrearInventarioDesdeFormulario()
        {
            return new Inventario
            {
                ProductoId = Convert.ToInt32(cmbProducto.SelectedValue),
                Cantidad = int.Parse(txtCantidad.Text),
                FechaIngreso = dtpFechaActualizacion.Value
            };
        }

        // ==========================================================
        // 🔹 Click en DataGridView (para editar)
        // ==========================================================
        // ==========================================================
        // 🔹 Click en DataGridView (para editar)
        // ==========================================================
        private void dgvInventarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvInventarios.Rows[e.RowIndex];
                txtInventarioId.Text = fila.Cells["Inventario_Id"].Value.ToString();
                cmbProducto.Text = fila.Cells["ProductoNombre"].Value.ToString();
                txtCantidad.Text = fila.Cells["Cantidad"].Value.ToString();
                dtpFechaActualizacion.Value = Convert.ToDateTime(fila.Cells["FechaIngreso"].Value);

                // Verifica si existe la columna antes de asignar
                if (fila.DataGridView.Columns.Contains("PrecioVenta"))
                    txtPrecioVenta.Text = fila.Cells["PrecioVenta"].Value.ToString();
            }
        }

        // ==========================================================
        // 🔹 Limpiar campos
        // ==========================================================
        private void LimpiarCampos()
        {
            txtInventarioId.Clear();
            txtCantidad.Clear();
            txtPrecioVenta.Clear();

            // Solo limpias estos si existen en tu formulario
            if (Controls.Find("txtDescuento", true).Length > 0)
                Controls.Find("txtDescuento", true)[0].Text = "";

            if (Controls.Find("txtSKU", true).Length > 0)
                Controls.Find("txtSKU", true)[0].Text = "";

            cmbProducto.SelectedIndex = -1;
            dtpFechaActualizacion.Value = DateTime.Now;
        }


        // ==========================================================
        // 🔹 Regresar al menú
        // ==========================================================
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenuAdmin menu = new FrmMenuAdmin();
            menu.Show();
            this.Hide();
        }

        // ==========================================================
        // 🔹 No usado
        // ==========================================================
        private void dgvInventarios_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            try
            {
                var fila = dgvInventarios.Rows[e.RowIndex];

                // 🔹 ID del inventario
                if (fila.Cells["Inventario_Id"] != null)
                    txtInventarioId.Text = fila.Cells["Inventario_Id"].Value?.ToString() ?? "";

                // 🔹 Producto (nombre mostrado y valor del ComboBox)
                if (fila.Cells["Producto_Id"] != null)
                {
                    int productoId = Convert.ToInt32(fila.Cells["Producto_Id"].Value);
                    cmbProducto.SelectedValue = productoId; // 🔸 Esto dispara automáticamente el SelectedIndexChanged
                }

                // 🔹 Cantidad
                if (fila.Cells["Cantidad"] != null)
                    txtCantidad.Text = fila.Cells["Cantidad"].Value?.ToString() ?? "";

                // 🔹 Fecha de ingreso
                if (fila.Cells["FechaIngreso"] != null)
                    dtpFechaActualizacion.Value = Convert.ToDateTime(fila.Cells["FechaIngreso"].Value);

                // 🔹 Precio y descuento (si vienen en el DataGridView)
                if (fila.DataGridView.Columns.Contains("PrecioVenta"))
                    txtPrecioVenta.Text = fila.Cells["PrecioVenta"].Value?.ToString() ?? "";

                if (fila.DataGridView.Columns.Contains("Descuento") && Controls.Find("txtDescuento", true).Length > 0)
                    Controls.Find("txtDescuento", true)[0].Text = fila.Cells["Descuento"].Value?.ToString() ?? "";

                // 🔹 SKU (si existe en el formulario)
                if (fila.DataGridView.Columns.Contains("SKU") && Controls.Find("txtSKU", true).Length > 0)
                    Controls.Find("txtSKU", true)[0].Text = fila.Cells["SKU"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar inventario: {ex.Message}");
            }
        }
    }
}
