using System;
using System.Data;
using System.Data.SqlClient;
using DevSolutions.Models;

namespace DevSolutions.Dal
{
    public class ProductoDAL
    {
        private readonly string connectionString = DBConnection.ConnectionString;

        // ==========================================================
        // 🔹 OBTENER TODOS LOS PRODUCTOS
        // ==========================================================
        public DataTable ObtenerProductos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            Producto_Id,
                            Producto_Imagen,
                            Producto_SKU,
                            Producto_Nombre,
                            Producto_Descripcion,
                            Producto_CostoUnitario,
                            Producto_TieneDescuento,
                            Categoria_Id,
                            TipoProducto_Id,
                            UnidadMedida_Id,
                            Proveedor_Id
                        FROM INV.Tb_Productos";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }
        }

        // ==========================================================
        // 🔹 INSERTAR NUEVO PRODUCTO
        // ==========================================================
        public void InsertarProducto(Producto p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO INV.Tb_Productos
                        (
                            Producto_Imagen,
                            Producto_SKU,
                            Producto_Nombre,
                            Producto_Descripcion,
                            Producto_CostoUnitario,
                            Producto_TieneDescuento,
                            Categoria_Id,
                            TipoProducto_Id,
                            UnidadMedida_Id,
                            Proveedor_Id
                        )
                        VALUES 
                        (
                            @Producto_Imagen,
                            @Producto_SKU,
                            @Producto_Nombre,
                            @Producto_Descripcion,
                            @Producto_CostoUnitario,
                            @Producto_TieneDescuento,
                            @Categoria_Id,
                            @TipoProducto_Id,
                            @UnidadMedida_Id,
                            @Proveedor_Id
                        )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Producto_Id", p.Producto_Id);
                        cmd.Parameters.Add("@Producto_Imagen", SqlDbType.Image).Value = p.Producto_Imagen ?? (object)DBNull.Value;
                        cmd.Parameters.AddWithValue("@Producto_SKU", p.Producto_SKU ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Producto_Nombre", p.Producto_Nombre ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Producto_Descripcion", p.Producto_Descripcion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Producto_CostoUnitario", p.Producto_CostoUnitario);
                        cmd.Parameters.AddWithValue("@Producto_TieneDescuento", p.Producto_TieneDescuento);
                        cmd.Parameters.AddWithValue("@Categoria_Id", p.Categoria_Id);
                        cmd.Parameters.AddWithValue("@TipoProducto_Id", p.TipoProducto_Id);
                        cmd.Parameters.AddWithValue("@UnidadMedida_Id", p.UnidadMedida_Id);
                        cmd.Parameters.AddWithValue("@Proveedor_Id", p.Proveedor_Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }

        // ==========================================================
        // 🔹 ACTUALIZAR PRODUCTO EXISTENTE
        // ==========================================================
        public void ActualizarProducto(Producto p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE INV.Tb_Productos
                        SET
                            Producto_Imagen          = @Producto_Imagen,
                            Producto_SKU             = @Producto_SKU,
                            Producto_Nombre          = @Producto_Nombre,
                            Producto_Descripcion     = @Producto_Descripcion,
                            Producto_CostoUnitario   = @Producto_CostoUnitario,
                            Producto_TieneDescuento  = @Producto_TieneDescuento,
                            Categoria_Id             = @Categoria_Id,
                            TipoProducto_Id          = @TipoProducto_Id,
                            UnidadMedida_Id          = @UnidadMedida_Id,
                            Proveedor_Id             = @Proveedor_Id
                        WHERE Producto_Id = @Producto_Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Producto_Id", p.Producto_Id);
                        cmd.Parameters.Add("@Producto_Imagen", SqlDbType.Image).Value = p.Producto_Imagen ?? (object)DBNull.Value;
                        cmd.Parameters.AddWithValue("@Producto_SKU", p.Producto_SKU ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Producto_Nombre", p.Producto_Nombre ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Producto_Descripcion", p.Producto_Descripcion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Producto_CostoUnitario", p.Producto_CostoUnitario);
                        cmd.Parameters.AddWithValue("@Producto_TieneDescuento", p.Producto_TieneDescuento);
                        cmd.Parameters.AddWithValue("@Categoria_Id", p.Categoria_Id);
                        cmd.Parameters.AddWithValue("@TipoProducto_Id", p.TipoProducto_Id);
                        cmd.Parameters.AddWithValue("@UnidadMedida_Id", p.UnidadMedida_Id);
                        cmd.Parameters.AddWithValue("@Proveedor_Id", p.Proveedor_Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }
    }
}
