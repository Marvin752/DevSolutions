using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DevSolutions.Dal;

namespace DevSolutions.Forms
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
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
            string query = tipo switch
            {
                "Productos" => @"
                    SELECT 
                        P.Producto_Id AS [ID],
                        P.Producto_SKU AS [SKU],
                        P.Producto_Nombre AS [Nombre],
                        P.Producto_Descripcion AS [Descripción],
                        P.Producto_CostoUnitario AS [Costo Unitario],
                        CASE WHEN P.Producto_TieneDescuento = 1 THEN 'Sí' ELSE 'No' END AS [Tiene Descuento],
                        C.Categoria_Nombre AS [Categoría],
                        T.TipoProducto_Nombre AS [Tipo de Producto],
                        U.UnidadMedida_Nombre AS [Unidad de Medida],
                        PR.Proveedor_Nombre AS [Proveedor]
                    FROM INV.Tb_Productos P
                    INNER JOIN INV.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
                    INNER JOIN INV.Tb_TiposProductos T ON P.TipoProducto_Id = T.TipoProducto_Id
                    INNER JOIN INV.Tb_UnidadesMedidas U ON P.UnidadMedida_Id = U.UnidadMedida_Id
                    INNER JOIN INV.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
                    ORDER BY P.Producto_Nombre",

                "Inventario" => @"
                    SELECT 
                        I.Inventario_Id AS [ID],
                        P.Producto_Nombre AS [Producto],
                        P.Producto_SKU AS [SKU],
                        I.Inventario_Cantidad AS [Cantidad Disponible],
                        I.Inventario_PrecioVenta AS [Precio de Venta],
                        I.Inventario_Descuento AS [Descuento %],
                        E.Estanteria_Codigo AS [Estantería],
                        B.Bodega_Nombre AS [Bodega],
                        S.Seccion_Nombre AS [Sección],
                        CONVERT(VARCHAR, I.Inventario_FechaActualizacion, 103) AS [Fecha Actualización]
                    FROM INV.Tb_Inventarios I
                    INNER JOIN INV.Tb_Productos P ON I.Producto_Id = P.Producto_Id
                    INNER JOIN INV.Tb_Estanterias E ON I.Estanteria_Id = E.Estanteria_Id
                    INNER JOIN INV.Tb_Bodegas B ON E.Bodega_Id = B.Bodega_Id
                    INNER JOIN INV.Tb_Secciones S ON E.Seccion_Id = S.Seccion_Id
                    ORDER BY I.Inventario_FechaActualizacion DESC",

                _ => @"
                    SELECT 
                        P.Producto_SKU AS [SKU],
                        P.Producto_Nombre AS [Nombre del Producto],
                        ISNULL(I.Inventario_Cantidad, 0) AS [Cantidad Disponible],
                        P.Producto_CostoUnitario AS [Costo Unitario],
                        ISNULL(I.Inventario_PrecioVenta, 0) AS [Precio de Venta],
                        C.Categoria_Nombre AS [Categoría],
                        B.Bodega_Nombre AS [Bodega]
                    FROM INV.Tb_Productos P
                    INNER JOIN INV.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
                    INNER JOIN INV.Tb_TiposProductos T ON P.TipoProducto_Id = T.TipoProducto_Id
                    INNER JOIN INV.Tb_UnidadesMedidas U ON P.UnidadMedida_Id = U.UnidadMedida_Id
                    INNER JOIN INV.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
                    LEFT JOIN INV.Tb_Inventarios I ON P.Producto_Id = I.Producto_Id
                    LEFT JOIN INV.Tb_Estanterias E ON I.Estanteria_Id = E.Estanteria_Id
                    LEFT JOIN INV.Tb_Bodegas B ON E.Bodega_Id = B.Bodega_Id
                    ORDER BY P.Producto_Nombre"
            };

            DataTable dt = new DataTable();
            try
            {
                using SqlConnection conn = DBConnection.GetConnection();
                using SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error accediendo a la base de datos: " + ex.Message, ex);
            }

            return dt;
        }

        private void GenerarPDF(DataTable datos, string tipo, string ruta)
        {
            if (datos == null) throw new ArgumentNullException(nameof(datos));
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentNullException(nameof(ruta));

            // Orientación horizontal para mejor lectura
            iTextSharp.text.Rectangle pageSize = PageSize.A4.Rotate();

            using (Document doc = new Document(pageSize, 30, 30, 40, 40))
            {
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Fuentes
                iTextSharp.text.Font tituloFont = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                iTextSharp.text.Font subtituloFont = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 11f, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 9f, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL);

                // Encabezado de la empresa
                iTextSharp.text.Font empresaFont = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 22f, iTextSharp.text.Font.BOLD, new BaseColor(41, 128, 185));
                iTextSharp.text.Font sloganFont = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);

                Paragraph empresa = new Paragraph("DevSolutions", empresaFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 3
                };
                doc.Add(empresa);

                Paragraph slogan = new Paragraph("Sistema de Gestión de Inventario", sloganFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10
                };
                doc.Add(slogan);

                // Línea separadora
                PdfPTable lineaSeparadora = new PdfPTable(1)
                {
                    WidthPercentage = 80,
                    SpacingAfter = 15
                };
                PdfPCell lineaCell = new PdfPCell()
                {
                    BackgroundColor = new BaseColor(41, 128, 185),
                    FixedHeight = 2f,
                    Border = iTextSharp.text.Rectangle.NO_BORDER
                };
                lineaSeparadora.AddCell(lineaCell);
                doc.Add(lineaSeparadora);

                // Título del reporte
                Paragraph tituloReporte = new Paragraph($"Reporte de {tipo}", tituloFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10
                };
                doc.Add(tituloReporte);

                // Información del reporte
                Paragraph infoReporte = new Paragraph(
                    $"Fecha de generación: {DateTime.Now:dddd, dd 'de' MMMM 'de' yyyy - HH:mm} hrs\n" +
                    $"Total de registros: {datos.Rows.Count}",
                    normalFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                doc.Add(infoReporte);

                // Crear tabla con el número correcto de columnas
                PdfPTable table = new PdfPTable(datos.Columns.Count)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10
                };

                // Ajustar ancho de columnas si es el reporte "Ambos"
                if (tipo == "Ambos" && datos.Columns.Count == 7)
                {
                    // SKU (10%), Nombre (30%), Cantidad (12%), Costo (15%), Precio (15%), Categoría (10%), Bodega (8%)
                    table.SetWidths(new float[] { 10f, 30f, 12f, 15f, 15f, 10f, 8f });
                }

                // Headers de columnas
                foreach (DataColumn col in datos.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName, headerFont))
                    {
                        BackgroundColor = new BaseColor(41, 128, 185),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        Padding = 6
                    };
                    table.AddCell(cell);
                }

                // Filas de datos
                int rowNum = 0;
                foreach (DataRow row in datos.Rows)
                {
                    rowNum++;
                    BaseColor rowColor = (rowNum % 2 == 0) ? BaseColor.WHITE : new BaseColor(240, 248, 255);

                    foreach (DataColumn col in datos.Columns)
                    {
                        string valor = row[col] != DBNull.Value ? row[col].ToString() : "-";

                        // Formatear valores numéricos monetarios
                        if ((col.ColumnName.Contains("Costo") ||
                             col.ColumnName.Contains("Precio") ||
                             col.ColumnName.Contains("Venta")) &&
                            decimal.TryParse(valor, out decimal num))
                        {
                            valor = num > 0 ? $"Q {num:N2}" : "-";
                        }

                        // Formatear cantidades
                        if (col.ColumnName.Contains("Cantidad") && int.TryParse(valor, out int cantidad))
                        {
                            valor = cantidad.ToString("N0");
                        }

                        // Alineación según tipo de dato
                        int alignment = Element.ALIGN_LEFT;
                        if (col.ColumnName == "ID" ||
                            col.ColumnName.Contains("Cantidad") ||
                            col.ColumnName.Contains("Stock") ||
                            col.ColumnName.Contains("Costo") ||
                            col.ColumnName.Contains("Precio") ||
                            col.ColumnName.Contains("Desc"))
                        {
                            alignment = Element.ALIGN_RIGHT;
                        }
                        else if (col.ColumnName.Contains("Descuento") && valor == "Sí" || valor == "No")
                        {
                            alignment = Element.ALIGN_CENTER;
                        }

                        PdfPCell dataCell = new PdfPCell(new Phrase(valor, normalFont))
                        {
                            BackgroundColor = rowColor,
                            Padding = 5,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            HorizontalAlignment = alignment
                        };
                        table.AddCell(dataCell);
                    }
                }

                doc.Add(table);

                // Pie de página
                doc.Add(new Paragraph("\n"));
                Paragraph footer = new Paragraph(
                    $"Reporte generado automáticamente por DevSolutions © {DateTime.Now.Year}",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.ITALIC, BaseColor.GRAY))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(footer);

                doc.Close();
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
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
                    MessageBox.Show("No hay datos para mostrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tempPath = Path.Combine(Path.GetTempPath(), $"VistaPrevia_{Guid.NewGuid()}.pdf");
                GenerarPDF(datos, tipo, tempPath);
                AbrirPDF(tempPath);
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

        private void lblTitulo_Click(object sender, EventArgs e) { }
    }
}