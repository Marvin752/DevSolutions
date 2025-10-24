using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevSolutions.Dal;
using DevSolutions.Models;

namespace DevSolutions.Forms
{
    public partial class FrmProductos : Form
    {
        private readonly ProductoDAL productoDAL = new ProductoDAL();
        private readonly bool soloLectura = false;

        public FrmProductos()
        {
            InitializeComponent();
            CargarCategorias();
            CargarUnidadesMedida();
            CargarTiposProductos();
            CargarProveedores();
            CargarProductos();
        }

        public FrmProductos(bool soloLectura) : this()
        {
            this.soloLectura = soloLectura;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            if (soloLectura)
            {
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = false;
                btnCargarImagen.Enabled = false;
                btnLimpiar.Enabled = false;

                MessageBox.Show("Modo solo lectura activado. No puedes editar ni agregar productos.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================================
        // 🔹 Cargar Categorías
        // ==========================================================
        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT Categoria_Id, Categoria_Nombre FROM INV.Tb_Categorias";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbCategoria.DataSource = dt;
                    cmbCategoria.DisplayMember = "Categoria_Nombre";
                    cmbCategoria.ValueMember = "Categoria_Id";
                    cmbCategoria.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar Unidades de Medida
        // ==========================================================
        private void CargarUnidadesMedida()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT UnidadMedida_Id, UnidadMedida_Nombre FROM INV.Tb_UnidadesMedidas";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbBodega.DataSource = dt;
                    cmbBodega.DisplayMember = "UnidadMedida_Nombre";
                    cmbBodega.ValueMember = "UnidadMedida_Id";
                    cmbBodega.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando unidades de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar Tipos de Productos
        // ==========================================================
        private void CargarTiposProductos()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT TipoProducto_Id, TipoProducto_Nombre FROM INV.Tb_TiposProductos";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    comboBoxTipoProducto.DataSource = dt;
                    comboBoxTipoProducto.DisplayMember = "TipoProducto_Nombre";
                    comboBoxTipoProducto.ValueMember = "TipoProducto_Id";
                    comboBoxTipoProducto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando tipos de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar Proveedores
        // ==========================================================
        private void CargarProveedores()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT Proveedor_Id, Proveedor_Nombre FROM INV.Tb_Proveedores";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    comboBoxProveedor.DataSource = dt;
                    comboBoxProveedor.DisplayMember = "Proveedor_Nombre";
                    comboBoxProveedor.ValueMember = "Proveedor_Id";
                    comboBoxProveedor.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar Productos en DataGridView
        // ==========================================================
        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = productoDAL.ObtenerProductos();

                // Ocultar columnas de IDs si existen
                if (dgvProductos.Columns.Contains("Producto_Id"))
                    dgvProductos.Columns["Producto_Id"].Visible = false;

                if (dgvProductos.Columns.Contains("Categoria_Id"))
                    dgvProductos.Columns["Categoria_Id"].Visible = false;

                if (dgvProductos.Columns.Contains("TipoProducto_Id"))
                    dgvProductos.Columns["TipoProducto_Id"].Visible = false;

                if (dgvProductos.Columns.Contains("UnidadMedida_Id"))
                    dgvProductos.Columns["UnidadMedida_Id"].Visible = false;

                if (dgvProductos.Columns.Contains("Proveedor_Id"))
                    dgvProductos.Columns["Proveedor_Id"].Visible = false;

                if (dgvProductos.Columns.Contains("Producto_Imagen"))
                    dgvProductos.Columns["Producto_Imagen"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Validar Formulario
        // ==========================================================
        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = "";

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                mensajeError = "El código SKU es obligatorio.";
                txtSKU.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mensajeError = "El nombre del producto es obligatorio.";
                txtNombre.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                mensajeError = "Seleccione una categoría.";
                cmbCategoria.Focus();
                return false;
            }

            if (comboBoxTipoProducto.SelectedIndex == -1)
            {
                mensajeError = "Seleccione un tipo de producto.";
                comboBoxTipoProducto.Focus();
                return false;
            }

            if (cmbBodega.SelectedIndex == -1)
            {
                mensajeError = "Seleccione una unidad de medida.";
                cmbBodega.Focus();
                return false;
            }

            if (comboBoxProveedor.SelectedIndex == -1)
            {
                mensajeError = "Seleccione un proveedor.";
                comboBoxProveedor.Focus();
                return false;
            }

            decimal costoUnitario;
            if (!decimal.TryParse(txtCostoUnitario.Text, out costoUnitario) || costoUnitario <= 0)
            {
                mensajeError = "El costo unitario debe ser mayor a 0.";
                txtCostoUnitario.Focus();
                return false;
            }

            return true;
        }

        // ==========================================================
        // 🔹 Botón Cargar Imagen
        // ==========================================================
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            if (soloLectura) return;

            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    picImagen.Image = Image.FromFile(open.FileName);
                    picImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    picImagen.Tag = open.FileName;
                }
            }
        }

        // ==========================================================
        // 🔹 Botón Guardar Producto (NUEVO)
        // ==========================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeError;
                if (!ValidarFormulario(out mensajeError))
                {
                    MessageBox.Show(mensajeError, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (picImagen.Image == null)
                {
                    MessageBox.Show("Por favor carga una imagen antes de guardar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el producto
                Producto producto = new Producto
                {
                    Producto_SKU = txtSKU.Text.Trim(),
                    Producto_Nombre = txtNombre.Text.Trim(),
                    Producto_Descripcion = txtDescripcion.Text.Trim(),
                    Categoria_Id = Convert.ToInt32(cmbCategoria.SelectedValue),
                    TipoProducto_Id = Convert.ToInt32(comboBoxTipoProducto.SelectedValue),
                    UnidadMedida_Id = Convert.ToInt32(cmbBodega.SelectedValue),
                    Proveedor_Id = Convert.ToInt32(comboBoxProveedor.SelectedValue),
                    Producto_TieneDescuento = checkBoxDescuento.Checked,
                    Producto_CostoUnitario = decimal.Parse(txtCostoUnitario.Text),
                    Producto_Imagen = ImageToBytes(picImagen.Image)
                };

                // Insertar usando el DAL
                productoDAL.InsertarProducto(producto);

                MessageBox.Show("✅ Producto guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Botón Actualizar Producto (MEJORADO)
        // ==========================================================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si txtId existe y tiene valor
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Seleccione un producto del grid haciendo clic en una fila.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string mensajeError;
                if (!ValidarFormulario(out mensajeError))
                {
                    MessageBox.Show(mensajeError, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE INV.Tb_Productos
                        SET Producto_SKU = @SKU,
                            Producto_Nombre = @Nombre,
                            Producto_Descripcion = @Descripcion,
                            Producto_CostoUnitario = @CostoUnitario,
                            UnidadMedida_Id = @UnidadMedida_Id,
                            Producto_TieneDescuento = @TieneDescuento,
                            Categoria_Id = @CategoriaId,
                            TipoProducto_Id = @TipoProducto_Id,
                            Proveedor_Id = @Proveedor_Id,
                            Producto_Imagen = @Imagen
                        WHERE Producto_Id = @Producto_Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SKU", txtSKU.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@CostoUnitario", decimal.Parse(txtCostoUnitario.Text));
                        cmd.Parameters.AddWithValue("@UnidadMedida_Id", cmbBodega.SelectedValue);
                        cmd.Parameters.AddWithValue("@TieneDescuento", checkBoxDescuento.Checked);
                        cmd.Parameters.AddWithValue("@CategoriaId", cmbCategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("@TipoProducto_Id", comboBoxTipoProducto.SelectedValue);
                        cmd.Parameters.AddWithValue("@Proveedor_Id", comboBoxProveedor.SelectedValue);

                        if (picImagen.Image != null)
                            cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = ImageToBytes(picImagen.Image);
                        else
                            cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = DBNull.Value;

                        cmd.Parameters.AddWithValue("@Producto_Id", int.Parse(txtId.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Producto actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Convertir Imagen a Bytes
        // ==========================================================
        private byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        // ==========================================================
        // 🔹 Click en DataGridView (CORREGIDO GDI+ COMPLETO)
        // ==========================================================
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                // Cargar ID y datos básicos
                txtId.Text = fila.Cells["Producto_Id"].Value?.ToString() ?? "";
                txtSKU.Text = fila.Cells["Producto_SKU"].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells["Producto_Nombre"].Value?.ToString() ?? "";
                txtDescripcion.Text = fila.Cells["Producto_Descripcion"].Value?.ToString() ?? "";
                txtCostoUnitario.Text = fila.Cells["Producto_CostoUnitario"].Value?.ToString() ?? "";

                // ComboBoxes
                cmbCategoria.SelectedValue = fila.Cells["Categoria_Id"].Value != DBNull.Value
                    ? Convert.ToInt32(fila.Cells["Categoria_Id"].Value)
                    : -1;

                comboBoxTipoProducto.SelectedValue = fila.Cells["TipoProducto_Id"].Value != DBNull.Value
                    ? Convert.ToInt32(fila.Cells["TipoProducto_Id"].Value)
                    : -1;

                cmbBodega.SelectedValue = fila.Cells["UnidadMedida_Id"].Value != DBNull.Value
                    ? Convert.ToInt32(fila.Cells["UnidadMedida_Id"].Value)
                    : -1;

                comboBoxProveedor.SelectedValue = fila.Cells["Proveedor_Id"].Value != DBNull.Value
                    ? Convert.ToInt32(fila.Cells["Proveedor_Id"].Value)
                    : -1;

                // CheckBox
                checkBoxDescuento.Checked = fila.Cells["Producto_TieneDescuento"].Value != DBNull.Value &&
                                            Convert.ToBoolean(fila.Cells["Producto_TieneDescuento"].Value);

                // Imagen (✅ CORREGIDO GDI+)
                if (picImagen.Image != null)
                {
                    picImagen.Image.Dispose(); // Liberar imagen anterior
                    picImagen.Image = null;
                }

                if (fila.Cells["Producto_Imagen"].Value != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])fila.Cells["Producto_Imagen"].Value;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        Image tempImg = Image.FromStream(ms);
                        picImagen.Image = new Bitmap(tempImg); // ✅ Crear un bitmap nuevo
                        picImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Limpiar Campos
        // ==========================================================
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtSKU.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCostoUnitario.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbBodega.SelectedIndex = -1;
            comboBoxTipoProducto.SelectedIndex = -1;
            comboBoxProveedor.SelectedIndex = -1;
            checkBoxDescuento.Checked = false;
            picImagen.Image = null;
        }

        // ==========================================================
        // 🔹 Botón Limpiar
        // ==========================================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // ==========================================================
        // 🔹 Botón Regresar
        // ==========================================================
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ==========================================================
        // 🔹 Eventos vacíos (opcional mantenerlos para el diseñador)
        // ==========================================================
        private void label4_Click(object sender, EventArgs e) { }
        private void txtPrecioVenta_TextChanged(object sender, EventArgs e) { }
        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e) { }

    }
}