using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using CampoArgentino.Negocio;
using iTextSharp = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;
using iText = iTextSharp.text;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaArticulo_Venta : Form
    {
        public FormVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        // Método para configurar CultureInfo Argentina
        private void ConfigurarCultureInfoArgentina()
        {
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            culturaArgentina.NumberFormat.CurrencySymbol = "$";
            culturaArgentina.NumberFormat.CurrencyPositivePattern = 2; // $1.00
            culturaArgentina.NumberFormat.CurrencyNegativePattern = 8; // -$1.00

            Thread.CurrentThread.CurrentCulture = culturaArgentina;
            Thread.CurrentThread.CurrentUICulture = culturaArgentina;
        }

        // Método para mostrar artículos
        private void Mostrar()
        {
            try
            {

                this.dataListado.DataSource = NVenta.VentasPorArticulo();

                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas por artículo: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Método para buscar artículos por nombre
        private void BuscarNombre()
        {
            try
            {
                this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Ocultar columnas que no se necesitan mostrar
        private void OcultarColumnas()
        {
            try
            {
                // Ocultar columnas ID
                if (dataListado.Columns.Contains("idarticulo"))
                    dataListado.Columns["idarticulo"].Visible = false;

                // Mostrar solo las columnas relevantes para ventas
                string[] columnasMostrar = {
            "Codigo", "Nombre", "Categoria", "CantidadVendida",
            "TotalVentas", "PrecioPromedio", "FechaUltimaVenta",
            "StockActual", "PrecioActual"
        };

                foreach (DataGridViewColumn columna in dataListado.Columns)
                {
                    columna.Visible = columnasMostrar.Contains(columna.Name);
                }

                // Configurar headers y formatos
                if (dataListado.Columns.Contains("CantidadVendida"))
                {
                    dataListado.Columns["CantidadVendida"].HeaderText = "CANT. VENDIDA";
                    dataListado.Columns["CantidadVendida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListado.Columns.Contains("TotalVentas"))
                {
                    dataListado.Columns["TotalVentas"].HeaderText = "TOTAL VENTAS";
                    dataListado.Columns["TotalVentas"].DefaultCellStyle.Format = "C2";
                    dataListado.Columns["TotalVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListado.Columns.Contains("PrecioPromedio"))
                {
                    dataListado.Columns["PrecioPromedio"].HeaderText = "PRECIO PROMEDIO";
                    dataListado.Columns["PrecioPromedio"].DefaultCellStyle.Format = "C2";
                    dataListado.Columns["PrecioPromedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListado.Columns.Contains("FechaUltimaVenta"))
                {
                    dataListado.Columns["FechaUltimaVenta"].HeaderText = "ÚLTIMA VENTA";
                    dataListado.Columns["FechaUltimaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataListado.Columns["FechaUltimaVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Evento Load del formulario
        private void FormVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            ConfigurarCultureInfoArgentina();
            this.Mostrar();
        }

        // Evento buscar al hacer click
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        // Evento buscar al escribir
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

      
        // Evento imprimir reporte
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count == 0)
                {
                    MessageBox.Show("No hay artículos para generar el reporte",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_Ventas_Articulo_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFArticulosVenta(saveFileDialog.FileName);

                    DialogResult imprimir = MessageBox.Show(
                        "¿Desea abrir el PDF para imprimir?",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (imprimir == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(saveFileDialog.FileName)
                        {
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GenerarPDFArticulosVenta(string filePath)
        {
            // Configurar CultureInfo para Argentina específicamente para el PDF
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            culturaArgentina.NumberFormat.CurrencySymbol = "$";
            culturaArgentina.NumberFormat.CurrencyPositivePattern = 2;
            culturaArgentina.NumberFormat.CurrencyNegativePattern = 8;

            // Configurar documento para impresión (A4 horizontal)
            iText.Document document = new iText.Document(iText.PageSize.A4.Rotate(), 20, 20, 30, 30);

            try
            {
                iTextPdf.PdfWriter writer = iTextPdf.PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // ===== ENCABEZADO DEL REPORTE =====
                iText.Font fontTitulo = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 16, iText.BaseColor.BLACK);
                iText.Font fontSubtitulo = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 10, iText.BaseColor.DARK_GRAY);
                iText.Font fontNormal = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA, 9, iText.BaseColor.BLACK);
                iText.Font fontHeader = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 8, iText.BaseColor.WHITE);
                iText.Font fontData = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA, 8, iText.BaseColor.BLACK);
                iText.Font fontMonto = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 8, iText.BaseColor.BLACK);
                iText.Font fontDestacado = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 9, iText.BaseColor.DARK_GRAY);

                // Título del reporte
                iText.Paragraph titulo = new iText.Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = iText.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                iText.Paragraph subtitulo = new iText.Paragraph("REPORTE DE VENTAS POR ARTÍCULO", fontSubtitulo);
                subtitulo.Alignment = iText.Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // ===== INFORMACIÓN DEL REPORTE =====
                iTextPdf.PdfPTable tablaInfo = new iTextPdf.PdfPTable(4);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas de ventas
                decimal totalVentas = 0;
                decimal cantidadTotalVendida = 0;
                int articulosConVentas = 0;
                int articulosSinVentas = 0;
                DateTime? fechaPrimeraVenta = null;
                DateTime? fechaUltimaVenta = null;

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Cantidad vendida
                        if (row.Cells["CantidadVendida"].Value != null && row.Cells["CantidadVendida"].Value != DBNull.Value)
                        {
                            decimal cantidad = Convert.ToDecimal(row.Cells["CantidadVendida"].Value);
                            cantidadTotalVendida += cantidad;

                            if (cantidad > 0)
                                articulosConVentas++;
                            else
                                articulosSinVentas++;
                        }

                        // Total ventas
                        if (row.Cells["TotalVentas"].Value != null && row.Cells["TotalVentas"].Value != DBNull.Value)
                        {
                            totalVentas += Convert.ToDecimal(row.Cells["TotalVentas"].Value);
                        }

                        // Fechas de venta
                        if (row.Cells["FechaUltimaVenta"].Value != null && row.Cells["FechaUltimaVenta"].Value != DBNull.Value)
                        {
                            DateTime fechaVenta = Convert.ToDateTime(row.Cells["FechaUltimaVenta"].Value);

                            if (fechaUltimaVenta == null || fechaVenta > fechaUltimaVenta)
                                fechaUltimaVenta = fechaVenta;

                            if (fechaPrimeraVenta == null || fechaVenta < fechaPrimeraVenta)
                                fechaPrimeraVenta = fechaVenta;
                        }
                    }
                }

                // Formatear montos con formato argentino
                string totalVentasFormateado = totalVentas.ToString("C2", culturaArgentina);

                AgregarCeldaTabla(tablaInfo, "Fecha de generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total de artículos:", dataListado.Rows.Count.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Artículos con ventas:", articulosConVentas.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Artículos sin ventas:", articulosSinVentas.ToString(), fontNormal);

                AgregarCeldaTabla(tablaInfo, "Cantidad total vendida:", cantidadTotalVendida.ToString("N2"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "TOTAL VENTAS:", totalVentasFormateado, fontMonto);
                AgregarCeldaTabla(tablaInfo, "Período analizado:",
                    fechaPrimeraVenta.HasValue ?
                    $"{fechaPrimeraVenta.Value:dd/MM/yyyy} al {fechaUltimaVenta.Value:dd/MM/yyyy}" :
                    "Sin datos", fontNormal);
                AgregarCeldaTabla(tablaInfo, "", "", fontNormal);

                document.Add(tablaInfo);

                // ===== TABLA PRINCIPAL DE VENTAS POR ARTÍCULO =====
                if (dataListado.Rows.Count > 0)
                {
                    // Columnas para mostrar en el reporte de ventas
                    string[] columnasImpresion = {
                "Codigo",
                "Nombre",
                "Categoria",
                "CantidadVendida",
                "PrecioPromedio",
                "TotalVentas",
                "FechaUltimaVenta",
                "StockActual"
            };

                    List<string> columnasDisponibles = new List<string>();

                    // Verificar qué columnas están disponibles
                    foreach (string columna in columnasImpresion)
                    {
                        if (dataListado.Columns.Contains(columna))
                            columnasDisponibles.Add(columna);
                    }

                    iTextPdf.PdfPTable tablaDatos = new iTextPdf.PdfPTable(columnasDisponibles.Count);
                    tablaDatos.WidthPercentage = 100;
                    tablaDatos.SpacingBefore = 10f;
                    tablaDatos.SpacingAfter = 20f;

                    // Configurar anchos de columnas para formato horizontal
                    float[] anchos = new float[columnasDisponibles.Count];
                    for (int i = 0; i < columnasDisponibles.Count; i++)
                    {
                        string columna = columnasDisponibles[i];
                        if (columna == "Codigo") anchos[i] = 8f;
                        else if (columna == "CantidadVendida") anchos[i] = 10f;
                        else if (columna == "PrecioPromedio") anchos[i] = 10f;
                        else if (columna == "TotalVentas") anchos[i] = 12f;
                        else if (columna == "FechaUltimaVenta") anchos[i] = 10f;
                        else if (columna == "StockActual") anchos[i] = 8f;
                        else if (columna == "Categoria") anchos[i] = 15f;
                        else anchos[i] = 27f; // Para Nombre
                    }
                    tablaDatos.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasDisponibles)
                    {
                        string headerText = ObtenerHeaderLegibleVentas(columna);
                        iTextPdf.PdfPCell celdaHeader = new iTextPdf.PdfPCell(new iText.Phrase(headerText, fontHeader));
                        celdaHeader.BackgroundColor = new iText.BaseColor(70, 130, 180); // Azul corporativo
                        celdaHeader.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                        celdaHeader.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                        celdaHeader.Padding = 5;
                        celdaHeader.PaddingTop = 6;
                        tablaDatos.AddCell(celdaHeader);
                    }

                    // Datos de las filas
                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (string columna in columnasDisponibles)
                            {
                                string valor = fila.Cells[columna].Value?.ToString() ?? "";
                                iText.Phrase frase;
                                iTextPdf.PdfPCell celdaData;

                                // Formatear valores específicos
                                if ((columna == "PrecioPromedio" || columna == "TotalVentas") && decimal.TryParse(valor, out decimal monto))
                                {
                                    valor = monto.ToString("C2", culturaArgentina);
                                    frase = new iText.Phrase(valor, fontMonto);
                                    celdaData = new iTextPdf.PdfPCell(frase);
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                                }
                                else if (columna == "CantidadVendida" || columna == "StockActual")
                                {
                                    if (decimal.TryParse(valor, out decimal cantidad))
                                    {
                                        frase = new iText.Phrase(cantidad.ToString("N2"), fontData);
                                        celdaData = new iTextPdf.PdfPCell(frase);
                                        celdaData.HorizontalAlignment = iText.Element.ALIGN_RIGHT;

                                        // Resaltar artículos sin ventas
                                        if (columna == "CantidadVendida" && cantidad == 0)
                                        {
                                            celdaData.BackgroundColor = new iText.BaseColor(255, 240, 240);
                                        }
                                    }
                                    else
                                    {
                                        frase = new iText.Phrase(valor, fontData);
                                        celdaData = new iTextPdf.PdfPCell(frase);
                                        celdaData.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                                    }
                                }
                                else if (columna == "FechaUltimaVenta")
                                {
                                    if (DateTime.TryParse(valor, out DateTime fecha))
                                    {
                                        frase = new iText.Phrase(fecha.ToString("dd/MM/yyyy"), fontData);
                                    }
                                    else
                                    {
                                        frase = new iText.Phrase("Sin ventas", fontData);
                                    }
                                    celdaData = new iTextPdf.PdfPCell(frase);
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                                }
                                else
                                {
                                    frase = new iText.Phrase(valor, fontData);
                                    celdaData = new iTextPdf.PdfPCell(frase);
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_LEFT;
                                }

                                celdaData.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                                celdaData.Padding = 4;
                                celdaData.PaddingTop = 5;

                                // Resaltar los artículos más vendidos (top 3 por total de ventas)
                                if (columna == "TotalVentas" && decimal.TryParse(fila.Cells["TotalVentas"].Value?.ToString(), out decimal totalVenta) && totalVenta > 0)
                                {
                                    // Ordenar las filas por TotalVentas para encontrar los top 3
                                    var filasOrdenadas = dataListado.Rows.Cast<DataGridViewRow>()
                                        .Where(r => !r.IsNewRow && r.Cells["TotalVentas"].Value != null)
                                        .OrderByDescending(r => Convert.ToDecimal(r.Cells["TotalVentas"].Value))
                                        .Take(3)
                                        .ToList();

                                    if (filasOrdenadas.Contains(fila))
                                    {
                                        celdaData.BackgroundColor = new iText.BaseColor(220, 255, 220); // Verde claro para top ventas
                                    }
                                }

                                tablaDatos.AddCell(celdaData);
                            }
                        }
                    }

                    document.Add(tablaDatos);
                }

                // ===== RESUMEN FINAL =====
                iTextPdf.PdfPTable tablaResumen = new iTextPdf.PdfPTable(2);
                tablaResumen.WidthPercentage = 50;
                tablaResumen.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                tablaResumen.SpacingBefore = 10f;

                AgregarCeldaTablaResumen(tablaResumen, "Total artículos:", dataListado.Rows.Count.ToString(), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "Artículos con ventas:", articulosConVentas.ToString(), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "Cantidad total vendida:", cantidadTotalVendida.ToString("N2"), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "TOTAL VENTAS:", totalVentasFormateado, fontDestacado, fontMonto);

                document.Add(tablaResumen);

                // ===== PIE DE PÁGINA =====
                iText.Paragraph piePagina = new iText.Paragraph(
                    $"Página 1 | Generado por Sistema Campo Argentino | {DateTime.Now:dd/MM/yyyy HH:mm}",
                    iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_OBLIQUE, 7, iText.BaseColor.GRAY));
                piePagina.Alignment = iText.Element.ALIGN_CENTER;
                document.Add(piePagina);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar PDF: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        // Método auxiliar actualizado para headers de ventas
        private string ObtenerHeaderLegibleVentas(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "Codigo": return "CÓDIGO";
                case "Nombre": return "NOMBRE DEL ARTÍCULO";
                case "Categoria": return "CATEGORÍA";
                case "CantidadVendida": return "CANT. VENDIDA";
                case "PrecioPromedio": return "PRECIO PROMEDIO";
                case "TotalVentas": return "TOTAL VENTAS";
                case "FechaUltimaVenta": return "ÚLTIMA VENTA";
                case "StockActual": return "STOCK ACTUAL";
                default: return headerOriginal.ToUpper();
            }
        }

        // Métodos auxiliares para PDF
        private void AgregarCeldaTabla(iTextPdf.PdfPTable tabla, string etiqueta, string valor, iText.Font font)
        {
            iTextPdf.PdfPCell celdaEtiqueta = new iTextPdf.PdfPCell(new iText.Phrase(etiqueta, font));
            celdaEtiqueta.Border = iTextPdf.PdfPCell.NO_BORDER;
            celdaEtiqueta.Padding = 2;
            tabla.AddCell(celdaEtiqueta);

            iTextPdf.PdfPCell celdaValor = new iTextPdf.PdfPCell(new iText.Phrase(valor, font));
            celdaValor.Border = iTextPdf.PdfPCell.NO_BORDER;
            celdaValor.Padding = 2;
            tabla.AddCell(celdaValor);
        }

        private void AgregarCeldaTablaResumen(iTextPdf.PdfPTable tabla, string etiqueta, string valor, iText.Font fontEtiqueta, iText.Font fontValor)
        {
            iTextPdf.PdfPCell celdaEtiqueta = new iTextPdf.PdfPCell(new iText.Phrase(etiqueta, fontEtiqueta));
            celdaEtiqueta.Border = iTextPdf.PdfPCell.NO_BORDER;
            celdaEtiqueta.Padding = 5;
            tabla.AddCell(celdaEtiqueta);

            iTextPdf.PdfPCell celdaValor = new iTextPdf.PdfPCell(new iText.Phrase(valor, fontValor));
            celdaValor.Border = iTextPdf.PdfPCell.NO_BORDER;
            celdaValor.Padding = 5;
            celdaValor.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
            tabla.AddCell(celdaValor);
        }


       
        // Evento doble click para abrir ventas por cliente
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                // Obtener datos del artículo seleccionado
                int idArticulo = Convert.ToInt32(dataListado.CurrentRow.Cells["idarticulo"].Value);
                string codigo = dataListado.CurrentRow.Cells["Codigo"].Value?.ToString() ?? "";
                string nombre = dataListado.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";

                // Abrir directamente el formulario de ventas por cliente
                try
                {
                    FormVistaArticuloCliente_Venta formVentaCliente = new FormVistaArticuloCliente_Venta(idArticulo, codigo, nombre);
                    formVentaCliente.MdiParent = this.MdiParent;
                    formVentaCliente.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir ventas por cliente: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }

}