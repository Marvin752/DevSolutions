using System;
using System.Data;
using System.Data.SqlClient; // ✅ Solo esta librería
using DevSolutions.Models;

namespace DevSolutions.Dal
{
    public class InventarioDAL
    {
        // ✅ Usa la cadena de conexión desde DBConnection
        private readonly string connectionString = DBConnection.ConnectionString;

        // ==========================================================
        // 🔹 Obtener registros de inventario (con datos del producto)
        // ==========================================================
        public DataTable ObtenerInventarios()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            i.Inventario_Id,
                            i.Producto_Id,
                            i.Cantidad,
                            i.FechaIngreso,
                            p.Nombre AS ProductoNombre,
                            p.SKU,
                            p.PrecioVenta
                        FROM INV.Tb_Inventarios AS i
                        LEFT JOIN INV.Tb_Productos AS p 
                            ON i.Producto_Id = p.Producto_Id";

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
                throw new Exception("Error al obtener inventarios: " + ex.Message);
            }
        }

        // ==========================================================
        // 🔹 Insertar nuevo inventario
        // ==========================================================
        public void InsertarInventario(Inventario inv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO INV.Tb_Inventarios
                            (Producto_Id, Cantidad, FechaIngreso)
                        VALUES
                            (@ProductoId, @Cantidad, @FechaIngreso)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductoId", inv.ProductoId);
                        cmd.Parameters.AddWithValue("@Cantidad", inv.Cantidad);
                        cmd.Parameters.AddWithValue("@FechaIngreso", inv.FechaIngreso);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar inventario: " + ex.Message);
            }
        }

        // ==========================================================
        // 🔹 Actualizar inventario existente
        // ==========================================================
        public void ActualizarInventario(Inventario inv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE INV.Tb_Inventarios
                        SET 
                            Producto_Id = @ProductoId,
                            Cantidad = @Cantidad,
                            FechaIngreso = @FechaIngreso
                        WHERE Inventario_Id = @InventarioId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InventarioId", inv.InventarioId);
                        cmd.Parameters.AddWithValue("@ProductoId", inv.ProductoId);
                        cmd.Parameters.AddWithValue("@Cantidad", inv.Cantidad);
                        cmd.Parameters.AddWithValue("@FechaIngreso", inv.FechaIngreso);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar inventario: " + ex.Message);
            }
        }
    }
}
