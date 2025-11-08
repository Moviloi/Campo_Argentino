using CampoArgentino.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms;
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;

namespace CampoArgentino.Presentacion
{
    public partial class FormAlertaStock : Form
    {
        public FormAlertaStock()
        {
            InitializeComponent();
        }

        // Método para cargar alertas de stock bajo
        private void CargarAlertas()
        {
            try
            {
                // Usa el método general de artículos
                DataTable dtArticulos = NArticulo.Mostrar();

                // Filtra artículos con stock bajo
                DataView dv = new DataView(dtArticulos);
                dv.RowFilter = "Convert(stockminimo, 'System.Decimal') > 0"; // Ejemplo

                dataListado.DataSource = dv;
                OcultarColumnas();
                lblTotal.Text = "Alertas Activas: " + dataListado.Rows.Count;

                // Cambia color del label si hay alertas
                if (dataListado.Rows.Count > 0)
                {
                    lblTotal.ForeColor = Color.Red;
                    lblTotal.Text += " - ATENCIÓN REQUERIDA";
                }
                else
                {
                    lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
                    lblTotal.Text += " - TODO EN ORDEN";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alertas: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Ocultar columnas innecesarias
        private void OcultarColumnas()
        {
            try
            {
                dataListado.Columns["idarticulo"].Visible = false;
                dataListado.Columns["idcategoria"].Visible = false;
                dataListado.Columns["descripcion"].Visible = false;
                dataListado.Columns["unidadbase"].Visible = false;
                dataListado.Columns["factorconversion"].Visible = false;
                dataListado.Columns["preciocompra"].Visible = false;
                dataListado.Columns["iva"].Visible = false;
                dataListado.Columns["activo"].Visible = false;
            }
            catch (Exception ex)
            {
                // Ignorar errores de columnas que no existen
            }
        }

        // Evento Load
        private void FormAlertaStock_Load(object sender, EventArgs e)
        {
            this.CargarAlertas();
        }

        // Evento para actualizar alertas
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.CargarAlertas();
            MessageBox.Show("Alertas actualizadas correctamente",
                "Sistema Campo Argentino",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Evento para configurar alertas
        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            FormConfigAlerta frm = new FormConfigAlerta();
            frm.ShowDialog();
        }

        // Evento para generar reporte
        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "¿Desea generar un reporte PDF de las alertas de stock?",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        GenerarReportePDF();
                    }
                }
                else
                {
                    MessageBox.Show("No hay alertas activas para reportar",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GenerarReportePDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Reporte_Alertas_Stock_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                iText.Document document = new iText.Document(iText.PageSize.A4.Rotate(), 10, 10, 15, 15);

                try
                {
                    iTextPdf.PdfWriter writer = iTextPdf.PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Título
                    iText.Font tituloFont = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 14, iText.BaseColor.DARK_GRAY);
                    iText.Paragraph titulo = new iText.Paragraph("REPORTE DE ALERTAS DE STOCK - CAMPO ARGENTINO", tituloFont);
                    titulo.Alignment = iText.Element.ALIGN_CENTER;
                    titulo.SpacingAfter = 10f;
                    document.Add(titulo);

                    // Información
                    iText.Font infoFont = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA, 8);
                    iText.Paragraph info = new iText.Paragraph();
                    info.Add(new iText.Chunk($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm} | ", infoFont));
                    info.Add(new iText.Chunk($"Total alertas: {dataListado.Rows.Count} | ", infoFont));
                    info.Add(new iText.Chunk("Sistema Campo Argentino", infoFont));
                    info.SpacingAfter = 8f;
                    document.Add(info);

                    // Tabla
                    iTextPdf.PdfPTable tabla = new iTextPdf.PdfPTable(dataListado.Columns.Count);
                    tabla.WidthPercentage = 98;
                    tabla.SpacingBefore = 5f;
                    tabla.SpacingAfter = 5f;

                    // Encabezados
                    iText.Font headerFont = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 7, iText.BaseColor.WHITE);
                    foreach (DataGridViewColumn columna in dataListado.Columns)
                    {
                        iTextPdf.PdfPCell celdaHeader = new iTextPdf.PdfPCell(new iText.Phrase(columna.HeaderText, headerFont));
                        celdaHeader.BackgroundColor = new iText.BaseColor(70, 130, 180);
                        celdaHeader.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                        celdaHeader.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                        celdaHeader.Padding = 3;
                        celdaHeader.FixedHeight = 18;
                        tabla.AddCell(celdaHeader);
                    }

                    // Datos
                    iText.Font dataFont = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA, 7);
                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                string valor = celda.Value?.ToString() ?? "";
                                iTextPdf.PdfPCell celdaData = new iTextPdf.PdfPCell(new iText.Phrase(valor, dataFont));
                                celdaData.Padding = 2;
                                celdaData.FixedHeight = 16;
                                tabla.AddCell(celdaData);
                            }
                        }
                    }

                    document.Add(tabla);

                    // Pie de página
                    document.Add(new iText.Paragraph(" "));
                    iText.Font pieFont = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_OBLIQUE, 6, iText.BaseColor.GRAY);
                    iText.Paragraph pie = new iText.Paragraph("Reporte generado automáticamente - Campo Argentino", pieFont);
                    pie.Alignment = iText.Element.ALIGN_CENTER;
                    document.Add(pie);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear PDF: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    document.Close();
                }

                // Abre el PDF
                try
                {
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName)
                    {
                        UseShellExecute = true
                    });

                    MessageBox.Show("Reporte PDF generado exitosamente!\n\nEl archivo se ha abierto automáticamente.",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Reporte generado exitosamente en:\n{saveFileDialog.FileName}\n\nError al abrir: {ex.Message}",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        // Evento doble click para ver detalles del artículo
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                string articuloId = dataListado.CurrentRow.Cells["idarticulo"].Value.ToString();
                string nombreArticulo = dataListado.CurrentRow.Cells["nombre"].Value.ToString();

                MessageBox.Show(
                    $"Artículo: {nombreArticulo}\n" +
                    $"ID: {articuloId}\n" +
                    "Acción: Revisar stock y realizar pedido",
                    "Detalle de Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}