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
                this.dataListado.DataSource = NArticulo.Mostrar();
                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message,
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
                // Ocultar columnas que no son relevantes para el reporte de ventas
                if (dataListado.Columns.Contains("idarticulo"))
                    dataListado.Columns["idarticulo"].Visible = false;

                if (dataListado.Columns.Contains("idcategoria"))
                    dataListado.Columns["idcategoria"].Visible = false;

                if (dataListado.Columns.Contains("descripcion"))
                    dataListado.Columns["descripcion"].Visible = false;

                if (dataListado.Columns.Contains("preciocompra"))
                    dataListado.Columns["preciocompra"].Visible = false;

                if (dataListado.Columns.Contains("activo"))
                    dataListado.Columns["activo"].Visible = false;

                if (dataListado.Columns.Contains("idpresentacion"))
                    dataListado.Columns["idpresentacion"].Visible = false;

                if (dataListado.Columns.Contains("factorconversion"))
                    dataListado.Columns["factorconversion"].Visible = false;

                if (dataListado.Columns.Contains("iva"))
                    dataListado.Columns["iva"].Visible = false;
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
                saveFileDialog.FileName = $"Catalogo_Articulos_Venta_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

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

                // Título del reporte
                iText.Paragraph titulo = new iText.Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = iText.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                iText.Paragraph subtitulo = new iText.Paragraph("CATÁLOGO DE ARTÍCULOS PARA VENTA", fontSubtitulo);
                subtitulo.Alignment = iText.Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // ===== INFORMACIÓN DEL REPORTE =====
                iTextPdf.PdfPTable tablaInfo = new iTextPdf.PdfPTable(4);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas
                decimal valorTotalInventario = 0;
                int articulosActivos = 0;
                int articulosConStock = 0;
                decimal stockTotal = 0;

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Verificar si el artículo está activo
                        bool activo = true;
                        if (row.Cells["activo"].Value != null)
                        {
                            if (row.Cells["activo"].Value is bool activoValue)
                                activo = activoValue;
                            else if (row.Cells["activo"].Value.ToString() == "False")
                                activo = false;
                        }

                        if (activo) articulosActivos++;

                        // Calcular stock y valor
                        if (row.Cells["StockActual"].Value != null && row.Cells["StockActual"].Value != DBNull.Value)
                        {
                            decimal stock = Convert.ToDecimal(row.Cells["StockActual"].Value);
                            stockTotal += stock;
                            if (stock > 0) articulosConStock++;

                            // Calcular valor del inventario (stock * precio de venta)
                            if (row.Cells["precioventa"].Value != null && row.Cells["precioventa"].Value != DBNull.Value)
                            {
                                decimal precioVenta = Convert.ToDecimal(row.Cells["precioventa"].Value);
                                valorTotalInventario += stock * precioVenta;
                            }
                        }
                    }
                }

                // Formatear montos con formato argentino
                string valorInventarioFormateado = valorTotalInventario.ToString("C2", culturaArgentina);

                AgregarCeldaTabla(tablaInfo, "Fecha de generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total de artículos:", dataListado.Rows.Count.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Artículos activos:", articulosActivos.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Artículos con stock:", articulosConStock.ToString(), fontNormal);

                AgregarCeldaTabla(tablaInfo, "Stock total:", stockTotal.ToString("N2"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Valor total inventario:", valorInventarioFormateado, fontMonto);
                AgregarCeldaTabla(tablaInfo, "Tipo de reporte:", "CATÁLOGO VENTAS", fontNormal);
                AgregarCeldaTabla(tablaInfo, "", "", fontNormal);

                document.Add(tablaInfo);

                // ===== TABLA PRINCIPAL DE ARTÍCULOS =====
                if (dataListado.Rows.Count > 0)
                {
                    // Columnas para mostrar en el reporte de ventas
                    string[] columnasImpresion = { "Codigo", "Nombre", "Categoria", "precioventa", "StockActual" };
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
                        if (columnasDisponibles[i] == "Codigo") anchos[i] = 12f;
                        else if (columnasDisponibles[i] == "precioventa") anchos[i] = 15f;
                        else if (columnasDisponibles[i] == "StockActual") anchos[i] = 12f;
                        else if (columnasDisponibles[i] == "Categoria") anchos[i] = 20f;
                        else anchos[i] = 41f; // Para Nombre
                    }
                    tablaDatos.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasDisponibles)
                    {
                        string headerText = ObtenerHeaderLegibleArticulos(columna);
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

                                // Formatear valores específicos
                                if (columna == "precioventa" && decimal.TryParse(valor, out decimal precio))
                                {
                                    valor = precio.ToString("C2", culturaArgentina);
                                    frase = new iText.Phrase(valor, fontMonto);
                                }
                                else if (columna == "StockActual")
                                {
                                    if (decimal.TryParse(valor, out decimal stock))
                                    {
                                        frase = new iText.Phrase(stock.ToString("N2"), fontData);
                                    }
                                    else
                                    {
                                        frase = new iText.Phrase(valor, fontData);
                                    }
                                }
                                else
                                {
                                    frase = new iText.Phrase(valor, fontData);
                                }

                                iTextPdf.PdfPCell celdaData = new iTextPdf.PdfPCell(frase);

                                // Alineación según el tipo de dato
                                if (columna == "Codigo" || columna == "StockActual")
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                                }
                                else if (columna == "precioventa")
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                                }
                                else
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_LEFT;
                                }

                                celdaData.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                                celdaData.Padding = 4;
                                celdaData.PaddingTop = 5;

                                // Resaltar artículos sin stock
                                if (columna == "StockActual" && decimal.TryParse(valor, out decimal stockActual) && stockActual == 0)
                                {
                                    celdaData.BackgroundColor = new iText.BaseColor(255, 200, 200);
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
                AgregarCeldaTablaResumen(tablaResumen, "Artículos activos:", articulosActivos.ToString(), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "Stock total:", stockTotal.ToString("N2"), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "VALOR INVENTARIO:", valorInventarioFormateado, fontNormal, fontMonto);

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

        private string ObtenerHeaderLegibleArticulos(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "Codigo": return "CÓDIGO";
                case "Nombre": return "NOMBRE DEL ARTÍCULO";
                case "Categoria": return "CATEGORÍA";
                case "precioventa": return "PRECIO VENTA";
                case "StockActual": return "STOCK ACTUAL";
                default: return headerOriginal.ToUpper();
            }
        }

        // Evento doble click para seleccionar artículo
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                // Aquí puedes agregar lógica para cuando se selecciona un artículo
                // Por ejemplo, pasar el artículo seleccionado al formulario de venta
                string codigo = dataListado.CurrentRow.Cells["Codigo"].Value?.ToString() ?? "";
                string nombre = dataListado.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";

                MessageBox.Show($"Artículo seleccionado:\nCódigo: {codigo}\nNombre: {nombre}",
                    "Artículo Seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}