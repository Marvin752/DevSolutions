using System;

namespace DevSolutions.Models
{
    /// <summary>
    /// Modelo que representa un registro de inventario
    /// Corresponde a la tabla INV.Tb_Inventarios
    /// </summary>
    public class Inventario
    {
        // Primary Key
        public int InventarioId { get; set; }

        // Foreign Keys
        public int ProductoId { get; set; }
        public int EstanteriaId { get; set; }

        // Campos de negocio
        public decimal Descuento { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Constructor por defecto
        public Inventario()
        {
            // Valores predeterminados
            Descuento = 0;
            Cantidad = 0;
            PrecioVenta = 0;
            FechaActualizacion = DateTime.Now;
        }

        // Constructor con parámetros principales
        public Inventario(int productoId, int estanteriaId, int cantidad, decimal precioVenta)
        {
            ProductoId = productoId;
            EstanteriaId = estanteriaId;
            Cantidad = cantidad;
            PrecioVenta = precioVenta;
            Descuento = 0;
            FechaActualizacion = DateTime.Now;
        }

        // Constructor completo
        public Inventario(int inventarioId, int productoId, int estanteriaId,
                         decimal descuento, int cantidad, decimal precioVenta,
                         DateTime fechaActualizacion)
        {
            InventarioId = inventarioId;
            ProductoId = productoId;
            EstanteriaId = estanteriaId;
            Descuento = descuento;
            Cantidad = cantidad;
            PrecioVenta = precioVenta;
            FechaActualizacion = fechaActualizacion;
        }

        /// <summary>
        /// Calcula el precio final después de aplicar el descuento
        /// </summary>
        public decimal PrecioFinal
        {
            get { return PrecioVenta - Descuento; }
        }

        /// <summary>
        /// Calcula el valor total del inventario (precio final * cantidad)
        /// </summary>
        public decimal ValorTotal
        {
            get { return PrecioFinal * Cantidad; }
        }

        /// <summary>
        /// Verifica si el inventario tiene stock disponible
        /// </summary>
        public bool TieneStock
        {
            get { return Cantidad > 0; }
        }

        /// <summary>
        /// Verifica si el producto tiene descuento aplicado
        /// </summary>
        public bool TieneDescuento
        {
            get { return Descuento > 0; }
        }

        public override string ToString()
        {
            return $"Inventario #{InventarioId} - Producto: {ProductoId}, " +
                   $"Cantidad: {Cantidad}, Precio: Q{PrecioVenta:N2}, " +
                   $"Descuento: Q{Descuento:N2}";
        }
    }
}