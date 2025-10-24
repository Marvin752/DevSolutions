using System;

namespace DevSolutions.Models
{
    public class Inventario
    {
        public int InventarioId { get; set; }  // sin guion bajo
        public int ProductoId { get; set; }    // sin guion bajo
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
