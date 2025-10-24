using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevSolutions.Dal;
using DevSolutions.Models;
using DevSolutions.Dal;
using DevSolutions.Models;

namespace DevSolutions.Forms
{
    public partial class FrmProductos : Form
    {
        private readonly ProductoDAL productoDAL = new ProductoDAL();
        private readonly bool soloLectura = false;

        // ==========================================================
        // 🔹 Constructor normal (modo administrador)
        // ==========================================================
        public FrmProductos()
        {
            InitializeComponent();
            CargarCategorias();
            CargarBodegas();
            CargarProductos();
        }

        // ==========================================================
        // 🔹 Constructor con parámetro (modo lectura)
        // ==========================================================
        public FrmProductos(bool soloLectura) : this()
        {
            this.soloLectura = soloLectura;
        }

        // ==========================================================
        // 🔹 Evento Load
        // ==========================================================
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
        // 🔹 Cargar datos (categorías, bodegas, productos)
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

        private void CargarBodegas()
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT Bodega_Id, Bodega_Nombre FROM INV.Tb_Bodegas";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbBodega.DataSource = dt;
                    cmbBodega.DisplayMember = "Bodega_Nombre";
                    cmbBodega.ValueMember = "Bodega_Id";
                    cmbBodega.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando bodegas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = productoDAL.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Cargar imagen
        // ==========================================================
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            if (soloLectura) return;

            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Archivos de imagen (.jpg; *.jpeg; *.png; *.bmp)|.jpg;.jpeg;.png;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    picImagen.Image = Image.FromFile(open.FileName);
                    picImagen.Tag = open.FileName;
                }
            }
        }

        // ==========================================================
        // 🔹 Guardar producto
        // ==========================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (soloLectura) return;

            try
            {
                Producto producto = CrearProductoDesdeFormulario();
                productoDAL.InsertarProducto(producto);

                MessageBox.Show("✅ Producto guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Actualizar producto
        // ==========================================================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor selecciona un producto para actualizar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE INV.Tb_Productos
                        SET SKU = @SKU,
                            Nombre = @Nombre,
                            Descripcion = @Descripcion,
                            CostoUnitario = @CostoUnitario,
                            UnidadMedida = @UnidadMedida,
                            Descuento = @Descuento,
                            Stock = @Stock,
                            CategoriaId = @CategoriaId,
                            BodegaId = @BodegaId,
                            EsBien = @EsBien,
                            Imagen = @Imagen,
                            PrecioVenta = @PrecioVenta
                        WHERE Producto_Id = @Producto_Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SKU", txtSKU.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@CostoUnitario", decimal.TryParse(txtCostoUnitario.Text, out var costo) ? costo : 0);
                        cmd.Parameters.AddWithValue("@UnidadMedida", txtUnidadMedida.Text.Trim());
                        cmd.Parameters.AddWithValue("@Descuento", decimal.TryParse(txtDescuento.Text, out var desc) ? desc : 0);
                        cmd.Parameters.AddWithValue("@Stock", int.TryParse(txtStock.Text, out var stock) ? stock : 0);
                        cmd.Parameters.AddWithValue("@CategoriaId", cmbCategoria.SelectedValue ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@BodegaId", cmbBodega.SelectedValue ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@EsBien", chkEsBien.Checked);
                        cmd.Parameters.AddWithValue("@PrecioVenta", decimal.TryParse(txtPrecioVenta.Text, out var precioVenta) ? precioVenta : 0);

                        if (picImagen.Image != null)
                            cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = ImageToBytes(picImagen.Image);
                        else
                            cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = DBNull.Value;

                        cmd.Parameters.AddWithValue("@Producto_Id", int.Parse(txtId.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Producto actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 🔹 Conversión imagen → bytes
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
        // 🔹 Crear objeto Producto desde formulario
        // ==========================================================
        private Producto CrearProductoDesdeFormulario()
        {
            return new Producto
            {
                Producto_SKU = txtSKU.Text,
                Producto_Nombre = txtNombre.Text,
                Producto_Descripcion = txtDescripcion.Text,
                Categoria_Id = Convert.ToInt32(cmbCategoria.SelectedValue),
                Bodega_Id = Convert.ToInt32(cmbBodega.SelectedValue),
                EsBien = chkEsBien.Checked,
                Producto_CostoUnitario = decimal.TryParse(txtCostoUnitario.Text, out var costo) ? costo : 0,
                UnidadMedida = txtUnidadMedida.Text,
                Descuento = decimal.TryParse(txtDescuento.Text, out var desc) ? desc : 0,
                Producto_Imagen = picImagen.Image != null ? ImageToBytes(picImagen.Image) : null,
                Stock = int.TryParse(txtStock.Text, out var stock) ? stock : 0,
                PrecioVenta = decimal.TryParse(txtPrecioVenta.Text, out var precioVenta) ? precioVenta : 0
            };
        }

        // ==========================================================
        // 🔹 DataGridView: seleccionar fila
        // ==========================================================
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            txtId.Text = fila.Cells["Producto_Id"].Value?.ToString() ?? "";
            txtSKU.Text = fila.Cells["SKU"].Value?.ToString() ?? "";
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString() ?? "";
            txtCostoUnitario.Text = fila.Cells["CostoUnitario"].Value?.ToString() ?? "";
            txtUnidadMedida.Text = fila.Cells["UnidadMedida"].Value?.ToString() ?? "";
            txtDescuento.Text = fila.Cells["Descuento"].Value?.ToString() ?? "";
            txtStock.Text = fila.Cells["Stock"].Value?.ToString() ?? "";
            txtPrecioVenta.Text = fila.Cells["PrecioVenta"].Value?.ToString() ?? "";

            cmbCategoria.SelectedValue = fila.Cells["CategoriaId"].Value ?? -1;
            cmbBodega.SelectedValue = fila.Cells["BodegaId"].Value ?? -1;
            chkEsBien.Checked = fila.Cells["EsBien"].Value != DBNull.Value &&
                                Convert.ToBoolean(fila.Cells["EsBien"].Value);

            if (fila.Cells["Imagen"].Value != DBNull.Value)
            {
                byte[] imgBytes = (byte[])fila.Cells["Imagen"].Value;
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    picImagen.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picImagen.Image = null;
            }
        }

        // ==========================================================
        // 🔹 Limpiar
        // ==========================================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtSKU.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCostoUnitario.Clear();
            txtUnidadMedida.Clear();
            txtDescuento.Clear();
            txtStock.Clear();
            txtPrecioVenta.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbBodega.SelectedIndex = -1;
            chkEsBien.Checked = false;
            picImagen.Image = null;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e) { }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e) { }
    }
}