using System;

namespace DevSolutions.Models
{
    /// <summary>
    /// Modelo que representa la tabla INV.Tb_Productos
    /// </summary>
    public class Producto
    {
        // ============================================
        // CAMPOS QUE EXISTEN EN LA TABLA
        // ============================================

        /// <summary>
        /// ID único del producto (Identity)
        /// </summary>
        public int Producto_Id { get; set; }

        /// <summary>
        /// Imagen del producto (tipo IMAGE en SQL Server)
        /// </summary>
        public byte[]? Producto_Imagen { get; set; }

        /// <summary>
        /// Código SKU único del producto (máx 20 caracteres)
        /// </summary>
        public string Producto_SKU { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del producto (máx 25 caracteres)
        /// </summary>
        public string Producto_Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada del producto (máx 255 caracteres)
        /// </summary>
        public string? Producto_Descripcion { get; set; }

        /// <summary>
        /// Costo unitario del producto (debe ser > 0)
        /// </summary>
        public decimal Producto_CostoUnitario { get; set; }

        /// <summary>
        /// Indica si el producto tiene descuento (bit/boolean)
        /// </summary>
        public bool Producto_TieneDescuento { get; set; }

        // ============================================
        // FOREIGN KEYS - IDs de relaciones
        // ============================================

        /// <summary>
        /// ID de la categoría del producto
        /// </summary>
        public int Categoria_Id { get; set; }

        /// <summary>
        /// ID del tipo de producto (1=Producto, 2=Servicio)
        /// </summary>
        public int TipoProducto_Id { get; set; }

        /// <summary>
        /// ID de la unidad de medida
        /// </summary>
        public int UnidadMedida_Id { get; set; }

        /// <summary>
        /// ID del proveedor
        /// </summary>
        public int Proveedor_Id { get; set; }

        // ============================================
        // PROPIEDADES OPCIONALES PARA JOINS
        // Estas NO están en la tabla, pero son útiles
        // cuando haces consultas con JOINS
        // ============================================

        /// <summary>
        /// Nombre de la categoría (desde JOIN con Tb_Categorias)
        /// </summary>
        public string? Categoria_Nombre { get; set; }

        /// <summary>
        /// Nombre del tipo de producto (desde JOIN con Tb_TiposProductos)
        /// </summary>
        public string? TipoProducto_Nombre { get; set; }

        /// <summary>
        /// Nombre de la unidad de medida (desde JOIN con Tb_UnidadesMedidas)
        /// </summary>
        public string? UnidadMedida_Nombre { get; set; }

        /// <summary>
        /// Abreviatura de la unidad de medida (desde JOIN con Tb_UnidadesMedidas)
        /// </summary>
        public string? UnidadMedida_Abreviatura { get; set; }

        /// <summary>
        /// Nombre del proveedor (desde JOIN con Tb_Proveedores)
        /// </summary>
        public string? Proveedor_Nombre { get; set; }

        /// <summary>
        /// NIT del proveedor (desde JOIN con Tb_Proveedores)
        /// </summary>
        public string? Proveedor_NIT { get; set; }
    }
}