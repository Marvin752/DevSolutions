using System;
using System.ComponentModel; // para LicenseManager.UsageMode
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DevSolutions.Forms
{
    public partial class FrmReporte : Form
    {
        private readonly string connectionString =
            "Data Source=SRV-BD\\MYINSTANCE;Initial Catalog=DB_DevSolutions;User ID=Usr_productos;Password=SuperPassword123!;TrustServerCertificate=True;";

        public FrmReporte()
        {
            InitializeComponent();
        }

        // El diseñador espera este handler: asegúrate que el Designer referencia este método
        private void FrmReporte_Load(object sender, EventArgs e)
        {
            // Evita ejecutar código de runtime cuando Visual Studio está en modo diseñador
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.AddRange(new object[] { "Productos", "Inventario", "Ambos" });
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return;

                if (cmbTipoReporte.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un tipo de reporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = cmbTipoReporte.SelectedItem.ToString();
                DataTable datos = ObtenerDatos(tipo);

                if (datos == null || datos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Archivo PDF (*.pdf)|*.pdf",
                    FileName = $"Reporte_{tipo}_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
                })
                {
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        GenerarPDF(datos, tipo, saveFile.FileName);
                        MessageBox.Show("✅ Reporte PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AbrirPDF(saveFile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatos(string tipo)
        {
            // Querys según el tipo seleccionado
            string query = tipo switch
            {
                "Productos" => @"
                    SELECT 
                        Producto_Id AS [ID Producto],
                        Nombre AS [Nombre del Producto],
                        Descripcion AS [Descripción],
                        PrecioVenta AS [Precio de Venta],
                        Stock AS [Stock Disponible],
                        CostoUnitario AS [Costo Unitario],
                        Descuento,
                        UnidadMedida AS [Unidad de Medida]
                    FROM INV.Tb_Productos
                    ORDER BY Nombre",
                "Inventario" => @"
                    SELECT 
                        i.Inventario_Id AS [ID Inventario],
                        p.Nombre AS [Producto],
                        i.Cantidad AS [Cantidad en Inventario],
                        i.FechaIngreso AS [Fecha de Ingreso]
                    FROM INV.Tb_Inventarios i
                    INNER JOIN INV.Tb_Productos p ON i.Producto_Id = p.Producto_Id
                    ORDER BY i.FechaIngreso DESC",
                _ => @"
                    SELECT 
                        p.Producto_Id AS [ID Producto],
                        p.Nombre AS [Producto],
                        p.PrecioVenta AS [Precio Venta],
                        p.Stock AS [Stock Total],
                        i.Inventario_Id AS [ID Inventario],
                        i.Cantidad AS [Cantidad Inventariada],
                        i.FechaIngreso AS [Fecha de Ingreso]
                    FROM INV.Tb_Productos p
                    LEFT JOIN INV.Tb_Inventarios i ON p.Producto_Id = i.Producto_Id
                    ORDER BY p.Nombre"
            };

            DataTable dt = new DataTable();
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                // Si ocurre error de BD, propágalo hacia arriba para mostrar mensaje claro
                throw new Exception("Error accediendo a la base de datos: " + ex.Message, ex);
            }

            return dt;
        }

        private void GenerarPDF(DataTable datos, string tipo, string ruta)
        {
            // Validación mínima de entrada
            if (datos == null) throw new ArgumentNullException(nameof(datos));
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentNullException(nameof(ruta));

            // Crear documento y escribir tabla con iTextSharp
            using (Document doc = new Document(PageSize.A4, 50, 50, 50, 50))
            {
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Usar la clase iTextSharp.text.Font explicitamente para evitar ambigüedad
                iTextSharp.text.Font tituloFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL);

                Paragraph header = new Paragraph($"DevSolutions\n\nReporte de {tipo}", tituloFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(header);
                doc.Add(new Paragraph($"\nFecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n", normalFont));

                PdfPTable table = new PdfPTable(datos.Columns.Count) { WidthPercentage = 100 };

                // Cabeceras
                foreach (DataColumn col in datos.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName, normalFont))
                    {
                        BackgroundColor = new BaseColor(230, 230, 230),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 4
                    };
                    table.AddCell(cell);
                }

                // Filas
                foreach (DataRow row in datos.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item?.ToString() ?? string.Empty, normalFont)) { Padding = 4 });
                    }
                }

                doc.Add(table);
                doc.Close();
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return; // no ejecutar en diseñador

                if (cmbTipoReporte.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un tipo de reporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = cmbTipoReporte.SelectedItem.ToString();
                DataTable datos = ObtenerDatos(tipo);

                if (datos == null || datos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document doc = new Document(PageSize.A4, 50, 50, 50, 50))
                    {
                        PdfWriter.GetInstance(doc, ms);
                        doc.Open();

                        iTextSharp.text.Font tituloFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL);

                        Paragraph header = new Paragraph($"DevSolutions\n\nVista Previa de Reporte - {tipo}", tituloFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        doc.Add(header);
                        doc.Add(new Paragraph($"\nFecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n", normalFont));

                        PdfPTable table = new PdfPTable(datos.Columns.Count) { WidthPercentage = 100 };

                        foreach (DataColumn col in datos.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName, normalFont))
                            {
                                BackgroundColor = new BaseColor(230, 230, 230),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 4
                            };
                            table.AddCell(cell);
                        }

                        foreach (DataRow row in datos.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                table.AddCell(new PdfPCell(new Phrase(item?.ToString() ?? string.Empty, normalFont)) { Padding = 4 });
                            }
                        }

                        doc.Add(table);
                        doc.Close();
                    }

                    // Guardar bytes en archivo temporal
                    string tempPath = Path.Combine(Path.GetTempPath(), $"VistaPrevia_{Guid.NewGuid()}.pdf");
                    File.WriteAllBytes(tempPath, ms.ToArray());

                    // Abrir con la app predeterminada de Windows
                    AbrirPDF(tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la vista previa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void AbrirPDF(string ruta)
        {
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return;

                if (!File.Exists(ruta))
                {
                    MessageBox.Show("El archivo PDF no existe o fue eliminado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var psi = new ProcessStartInfo
                {
                    FileName = ruta,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el PDF automáticamente.\n\n{ex.Message}", "Error al abrir PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // El diseñador referencia estos handlers: deben existir aunque sean vacíos
        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // si quieres que el título haga algo, implementalo aquí. Por ahora lo dejamos vacío.
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si quieres manejar el cambio de selección, implementa aquí.
            // Por ejemplo, podrías actualizar una vista previa en pantalla o habilitar botones.
        }
    }
}
