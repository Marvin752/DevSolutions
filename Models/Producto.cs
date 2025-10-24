using System;

namespace DevSolutions.Models
{
    public class Producto
    {
        public int Producto_Id { get; set; }

        // Imagen del producto
        public byte[]? Producto_Imagen { get; set; }

        // Código SKU único
        public string Producto_SKU { get; set; } = string.Empty;

        // Nombre del producto
        public string Producto_Nombre { get; set; } = string.Empty;

        // Descripción detallada
        public string? Producto_Descripcion { get; set; }

        // Costo unitario
        public decimal Producto_CostoUnitario { get; set; }

        // Indica si es bien (true) o servicio (false)
        public bool EsBien { get; set; }

        // Indica si tiene descuento
        public decimal Descuento { get; set; }

        // Stock actual
        public int Stock { get; set; }

        // Precio de venta
        public decimal PrecioVenta { get; set; }

        // Relación con categoría
        public int Categoria_Id { get; set; }
        public string? Categoria_Nombre { get; set; } // opcional

        // Relación con tipo de producto
        public int TipoProducto_Id { get; set; }
        public string? TipoProducto_Nombre { get; set; } // opcional

        // Relación con unidad de medida
        public int UnidadMedida_Id { get; set; }
        public string? UnidadMedida_Nombre { get; set; } // opcional

        // Texto de unidad de medida (si tu formulario lo guarda como string)
        public string? UnidadMedida { get; set; }

        // Relación con proveedor
        public int Proveedor_Id { get; set; }
        public string? Proveedor_Nombre { get; set; } // opcional

        // Relación con bodega
        public int Bodega_Id { get; set; }
        public string? Bodega_Nombre { get; set; } // opcional
    }
}
