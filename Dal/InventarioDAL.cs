using System;
using System.Data;
using System.Data.SqlClient;
using DevSolutions.Models;

namespace DevSolutions.Dal
{
    public class InventarioDAL
    {
        // ==========================================================
        // 🔹 OBTENER TODOS LOS INVENTARIOS CON INFORMACIÓN RELACIONADA
        // ==========================================================
        public DataTable ObtenerInventarios()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    // Query con INNER JOIN para traer datos relacionados
                    string query = @"
                        SELECT 
                            i.Inventario_Id,
                            i.Producto_Id,
                            p.Producto_Nombre,
                            p.Producto_SKU,
                            i.Estanteria_Id,
                            e.Estanteria_Codigo,
                            b.Bodega_Nombre,
                            s.Seccion_Nombre,
                            i.Inventario_Descuento,
                            i.Inventario_Cantidad,
                            i.Inventario_PrecioVenta,
                            i.Inventario_FechaActualizacion
                        FROM INV.Tb_Inventarios i
                        INNER JOIN INV.Tb_Productos p ON i.Producto_Id = p.Producto_Id
                        INNER JOIN INV.Tb_Estanterias e ON i.Estanteria_Id = e.Estanteria_Id
                        INNER JOIN INV.Tb_Bodegas b ON e.Bodega_Id = b.Bodega_Id
                        INNER JOIN INV.Tb_Secciones s ON e.Seccion_Id = s.Seccion_Id
                        ORDER BY i.Inventario_FechaActualizacion DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener inventarios: {ex.Message}", ex);
            }

            return dt;
        }

        // ==========================================================
        // 🔹 OBTENER UN INVENTARIO POR ID
        // ==========================================================
        public Inventario ObtenerInventarioPorId(int inventarioId)
        {
            Inventario inventario = null;

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            Inventario_Id,
                            Producto_Id,
                            Estanteria_Id,
                            Inventario_Descuento,
                            Inventario_Cantidad,
                            Inventario_PrecioVenta,
                            Inventario_FechaActualizacion
                        FROM INV.Tb_Inventarios
                        WHERE Inventario_Id = @InventarioId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InventarioId", inventarioId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        inventario = new Inventario
                        {
                            InventarioId = Convert.ToInt32(reader["Inventario_Id"]),
                            ProductoId = Convert.ToInt32(reader["Producto_Id"]),
                            EstanteriaId = Convert.ToInt32(reader["Estanteria_Id"]),
                            Descuento = Convert.ToDecimal(reader["Inventario_Descuento"]),
                            Cantidad = Convert.ToInt32(reader["Inventario_Cantidad"]),
                            PrecioVenta = Convert.ToDecimal(reader["Inventario_PrecioVenta"]),
                            FechaActualizacion = Convert.ToDateTime(reader["Inventario_FechaActualizacion"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener inventario: {ex.Message}", ex);
            }

            return inventario;
        }

        // ==========================================================
        // 🔹 INSERTAR NUEVO INVENTARIO
        // ==========================================================
        public void InsertarInventario(Inventario inventario)
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO INV.Tb_Inventarios 
                        (
                            Producto_Id,
                            Estanteria_Id,
                            Inventario_Descuento,
                            Inventario_Cantidad,
                            Inventario_PrecioVenta,
                            Inventario_FechaActualizacion
                        )
                        VALUES 
                        (
                            @ProductoId,
                            @EstanteriaId,
                            @Descuento,
                            @Cantidad,
                            @PrecioVenta,
                            @FechaActualizacion
                        )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductoId", inventario.ProductoId);
                    cmd.Parameters.AddWithValue("@EstanteriaId", inventario.EstanteriaId);
                    cmd.Parameters.AddWithValue("@Descuento", inventario.Descuento);
                    cmd.Parameters.AddWithValue("@Cantidad", inventario.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioVenta", inventario.PrecioVenta);
                    cmd.Parameters.AddWithValue("@FechaActualizacion", inventario.FechaActualizacion);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar inventario: {ex.Message}", ex);
            }
        }

        // ==========================================================
        // 🔹 ACTUALIZAR INVENTARIO EXISTENTE
        // ==========================================================
        public void ActualizarInventario(Inventario inventario)
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        UPDATE INV.Tb_Inventarios
                        SET 
                            Producto_Id = @ProductoId,
                            Estanteria_Id = @EstanteriaId,
                            Inventario_Descuento = @Descuento,
                            Inventario_Cantidad = @Cantidad,
                            Inventario_PrecioVenta = @PrecioVenta,
                            Inventario_FechaActualizacion = @FechaActualizacion
                        WHERE Inventario_Id = @InventarioId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InventarioId", inventario.InventarioId);
                    cmd.Parameters.AddWithValue("@ProductoId", inventario.ProductoId);
                    cmd.Parameters.AddWithValue("@EstanteriaId", inventario.EstanteriaId);
                    cmd.Parameters.AddWithValue("@Descuento", inventario.Descuento);
                    cmd.Parameters.AddWithValue("@Cantidad", inventario.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioVenta", inventario.PrecioVenta);
                    cmd.Parameters.AddWithValue("@FechaActualizacion", inventario.FechaActualizacion);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró el inventario a actualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar inventario: {ex.Message}", ex);
            }
        }

        // ==========================================================
        // 🔹 ELIMINAR INVENTARIO
        // ==========================================================
        public void EliminarInventario(int inventarioId)
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        DELETE FROM INV.Tb_Inventarios
                        WHERE Inventario_Id = @InventarioId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InventarioId", inventarioId);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró el inventario a eliminar.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar inventario: {ex.Message}", ex);
            }
        }

        // ==========================================================
        // 🔹 VERIFICAR SI EXISTE INVENTARIO PARA UN PRODUCTO EN UNA ESTANTERÍA
        // ==========================================================
        public bool ExisteInventario(int productoId, int estanteriaId)
        {
            bool existe = false;

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT COUNT(*) 
                        FROM INV.Tb_Inventarios
                        WHERE Producto_Id = @ProductoId 
                        AND Estanteria_Id = @EstanteriaId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);
                    cmd.Parameters.AddWithValue("@EstanteriaId", estanteriaId);

                    int count = (int)cmd.ExecuteScalar();
                    existe = count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar inventario: {ex.Message}", ex);
            }

            return existe;
        }

        // ==========================================================
        // 🔹 OBTENER INVENTARIO POR PRODUCTO Y ESTANTERÍA
        // ==========================================================
        public Inventario ObtenerInventarioPorProductoYEstanteria(int productoId, int estanteriaId)
        {
            Inventario inventario = null;

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            Inventario_Id,
                            Producto_Id,
                            Estanteria_Id,
                            Inventario_Descuento,
                            Inventario_Cantidad,
                            Inventario_PrecioVenta,
                            Inventario_FechaActualizacion
                        FROM INV.Tb_Inventarios
                        WHERE Producto_Id = @ProductoId 
                        AND Estanteria_Id = @EstanteriaId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);
                    cmd.Parameters.AddWithValue("@EstanteriaId", estanteriaId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        inventario = new Inventario
                        {
                            InventarioId = Convert.ToInt32(reader["Inventario_Id"]),
                            ProductoId = Convert.ToInt32(reader["Producto_Id"]),
                            EstanteriaId = Convert.ToInt32(reader["Estanteria_Id"]),
                            Descuento = Convert.ToDecimal(reader["Inventario_Descuento"]),
                            Cantidad = Convert.ToInt32(reader["Inventario_Cantidad"]),
                            PrecioVenta = Convert.ToDecimal(reader["Inventario_PrecioVenta"]),
                            FechaActualizacion = Convert.ToDateTime(reader["Inventario_FechaActualizacion"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener inventario: {ex.Message}", ex);
            }

            return inventario;
        }

        // ==========================================================
        // 🔹 OBTENER CANTIDAD TOTAL EN INVENTARIO POR PRODUCTO
        // ==========================================================
        public int ObtenerCantidadTotalPorProducto(int productoId)
        {
            int cantidadTotal = 0;

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT ISNULL(SUM(Inventario_Cantidad), 0) 
                        FROM INV.Tb_Inventarios
                        WHERE Producto_Id = @ProductoId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);

                    cantidadTotal = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cantidad total: {ex.Message}", ex);
            }

            return cantidadTotal;
        }

        // ==========================================================
        // 🔹 BUSCAR INVENTARIOS POR PRODUCTO (con búsqueda parcial)
        // ==========================================================
        public DataTable BuscarInventariosPorProducto(string nombreProducto)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            i.Inventario_Id,
                            i.Producto_Id,
                            p.Producto_Nombre,
                            p.Producto_SKU,
                            i.Estanteria_Id,
                            e.Estanteria_Codigo,
                            b.Bodega_Nombre,
                            s.Seccion_Nombre,
                            i.Inventario_Descuento,
                            i.Inventario_Cantidad,
                            i.Inventario_PrecioVenta,
                            i.Inventario_FechaActualizacion
                        FROM INV.Tb_Inventarios i
                        INNER JOIN INV.Tb_Productos p ON i.Producto_Id = p.Producto_Id
                        INNER JOIN INV.Tb_Estanterias e ON i.Estanteria_Id = e.Estanteria_Id
                        INNER JOIN INV.Tb_Bodegas b ON e.Bodega_Id = b.Bodega_Id
                        INNER JOIN INV.Tb_Secciones s ON e.Seccion_Id = s.Seccion_Id
                        WHERE p.Producto_Nombre LIKE @NombreProducto
                        ORDER BY i.Inventario_FechaActualizacion DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NombreProducto", "%" + nombreProducto + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar inventarios: {ex.Message}", ex);
            }

            return dt;
        }
    }
}