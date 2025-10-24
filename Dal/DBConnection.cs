using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DevSolutions.Dal
{
    /// <summary>
    /// Clase estática central para manejar la conexión a la base de datos
    /// usando cadenas definidas en app.config.
    /// </summary>
    public static class DBConnection
    {
        /// <summary>
        /// Obtiene la cadena de conexión "conexionLogin" desde app.config
        /// </summary>
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["conexionLogin"]?.ConnectionString
            ?? throw new Exception("No se encontró la cadena 'conexionLogin' en app.config");

        /// <summary>
        /// Crea y retorna una nueva SqlConnection (sin abrirla)
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Alias alternativo por compatibilidad con código existente
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Prueba rápida de conexión (true/false)
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using var c = GetConnection();
                c.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Prueba detallada de conexión con mensaje informativo
        /// </summary>
        public static string TestConnectionWithDetails()
        {
            try
            {
                using var c = GetConnection();
                c.Open();
                string server = c.DataSource;
                string db = c.Database;
                string ver = c.ServerVersion;

                return $"✅ Conexión OK\nServidor: {server}\nBase: {db}\nVersión: {ver}";
            }
            catch (SqlException ex)
            {
                return $"❌ Error SQL ({ex.Number}): {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"❌ Error general: {ex.Message}";
            }
        }
    }
}