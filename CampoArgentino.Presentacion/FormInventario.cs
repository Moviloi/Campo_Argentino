using CampoArgentino.Negocio;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;
using System.Globalization;
using System.Threading;

namespace CampoArgentino.Presentacion
{
    public partial class FormInventario : Form
    {
        private int idconteoActual = 0;
        private bool conteoEnCurso = false;

        public FormInventario()
        {
            InitializeComponent();
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            MostrarReporteConteo();
            LimpiarControlesConteo();
        }

        // Métodos auxiliares
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LimpiarControlesConteo()
        {
            txtCodigoConteo.Text = "";
            txtNombreConteo.Text = "";
            txtStockSistemaConteo.Text = "";
            txtStockFisicoConteo.Text = "";
            txtCodigoConteo.Focus();
        }

        private void MostrarReporteConteo()
        {
            try
            {
                dataListadoReporte.DataSource = NInventario.ReporteConteoInventario();
                CalcularTotalesReporte();
            }
            catch (Exception ex)
            {
                MensajeError("Error al cargar reporte: " + ex.Message);
            }
        }

        private void CalcularTotalesReporte()
        {
            if (dataListadoReporte.Rows.Count > 0)
            {
                decimal totalStock = 0;
                int stockBajo = 0;
                int stockAlto = 0;

                foreach (DataGridViewRow row in dataListadoReporte.Rows)
                {
                    if (row.Cells["StockSistema"].Value != DBNull.Value)
                        totalStock += Convert.ToDecimal(row.Cells["StockSistema"].Value);

                    if (row.Cells["EstadoStock"].Value?.ToString() == "STOCK BAJO")
                        stockBajo++;
                    else if (row.Cells["EstadoStock"].Value?.ToString() == "STOCK ALTO")
                        stockAlto++;
                }

                lblTotalReporte.Text = $"Total Artículos: {dataListadoReporte.Rows.Count} | " +
                                     $"Stock Total: {totalStock:N2} | " +
                                     $"Stock Bajo: {stockBajo} | " +
                                     $"Stock Alto: {stockAlto}";
            }
        }

      
        

        private void btnImprimirReporte_Click(object sender, EventArgs e)
            {

            // CultureInfo para Argentina
            CultureInfo culturaArgentina = new CultureInfo("es-AR");


            Thread.CurrentThread.CurrentCulture = culturaArgentina;
            Thread.CurrentThread.CurrentUICulture = culturaArgentina;

            try
                {
                    if (dataListadoReporte.Rows.Count == 0)
                    {
                        MensajeError("No hay datos para generar el reporte");
                        return;
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    saveFileDialog.FileName = $"Reporte_Inventario_Impresion_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        GenerarPDFParaImpresion(saveFileDialog.FileName);

                        // Preguntar si desea abrir para imprimir
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
                    MensajeError("Error al generar PDF: " + ex.Message);
                }
            }

        private void GenerarPDFParaImpresion(string filePath)
        {
            // Configurar documento para impresión (A4 vertical con márgenes optimizados)
            iText.Document document = new iText.Document(iText.PageSize.A4, 20, 20, 30, 30);

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

                // Logo o título de la empresa
                iText.Paragraph titulo = new iText.Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = iText.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                iText.Paragraph subtitulo = new iText.Paragraph("REPORTE DE INVENTARIO", fontSubtitulo);
                subtitulo.Alignment = iText.Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // ===== INFORMACIÓN DEL REPORTE =====
                iTextPdf.PdfPTable tablaInfo = new iTextPdf.PdfPTable(2);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas
                decimal totalStock = 0;
                int stockBajo = 0;
                int stockAlto = 0;
                int stockNormal = 0;
                int totalArticulos = 0;

                foreach (DataGridViewRow row in dataListadoReporte.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        totalArticulos++;
                        if (row.Cells["StockSistema"].Value != null && row.Cells["StockSistema"].Value != DBNull.Value)
                            totalStock += Convert.ToDecimal(row.Cells["StockSistema"].Value);

                        string estado = row.Cells["EstadoStock"].Value?.ToString() ?? "";
                        if (estado == "STOCK BAJO") stockBajo++;
                        else if (estado == "STOCK ALTO") stockAlto++;
                        else stockNormal++;
                    }
                }

                AgregarCeldaTabla(tablaInfo, "Fecha de generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total de artículos:", totalArticulos.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Stock total:", totalStock.ToString("N2"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Stock bajo:", stockBajo.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Stock alto:", stockAlto.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Stock normal:", stockNormal.ToString(), fontNormal);

                document.Add(tablaInfo);

                // ===== TABLA PRINCIPAL DE DATOS =====
                if (totalArticulos > 0)
                {
                    // Crear tabla con las columnas más importantes para impresión
                    string[] columnasImpresion = { "Codigo", "Nombre", "StockSistema", "EstadoStock" };
                    List<string> columnasDisponibles = new List<string>();

                    // Verificar qué columnas están disponibles
                    foreach (string columna in columnasImpresion)
                    {
                        if (dataListadoReporte.Columns.Contains(columna))
                            columnasDisponibles.Add(columna);
                    }

                    iTextPdf.PdfPTable tablaDatos = new iTextPdf.PdfPTable(columnasDisponibles.Count);
                    tablaDatos.WidthPercentage = 100;
                    tablaDatos.SpacingBefore = 10f;
                    tablaDatos.SpacingAfter = 20f;

                    // Configurar anchos de columnas
                    float[] anchos = new float[columnasDisponibles.Count];
                    for (int i = 0; i < columnasDisponibles.Count; i++)
                    {
                        if (columnasDisponibles[i] == "Codigo") anchos[i] = 15f;
                        else if (columnasDisponibles[i] == "StockSistema") anchos[i] = 15f;
                        else if (columnasDisponibles[i] == "EstadoStock") anchos[i] = 20f;
                        else anchos[i] = 50f; // Para Nombre
                    }
                    tablaDatos.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasDisponibles)
                    {
                        string headerText = ObtenerHeaderLegible(columna);
                        iTextPdf.PdfPCell celdaHeader = new iTextPdf.PdfPCell(new iText.Phrase(headerText, fontHeader));
                        celdaHeader.BackgroundColor = new iText.BaseColor(51, 51, 51); // Gris oscuro
                        celdaHeader.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                        celdaHeader.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                        celdaHeader.Padding = 5;
                        celdaHeader.PaddingTop = 6;
                        tablaDatos.AddCell(celdaHeader);
                    }

                    // Datos de las filas
                    foreach (DataGridViewRow fila in dataListadoReporte.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (string columna in columnasDisponibles)
                            {
                                string valor = fila.Cells[columna].Value?.ToString() ?? "";
                                iText.Phrase frase = new iText.Phrase(valor, fontData);
                                iTextPdf.PdfPCell celdaData = new iTextPdf.PdfPCell(frase);

                                // Alineación según el tipo de dato
                                if (columna == "StockSistema" || columna == "Codigo")
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                                }
                                else
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_LEFT;
                                }

                                celdaData.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                                celdaData.Padding = 4;
                                celdaData.PaddingTop = 5;

                                // Resaltar según estado de stock
                                if (columna == "EstadoStock")
                                {
                                    if (valor == "STOCK BAJO")
                                        celdaData.BackgroundColor = new iText.BaseColor(255, 200, 200);
                                    else if (valor == "STOCK ALTO")
                                        celdaData.BackgroundColor = new iText.BaseColor(255, 255, 200);
                                }

                                tablaDatos.AddCell(celdaData);
                            }
                        }
                    }

                    document.Add(tablaDatos);
                }

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

        // Métodos auxiliares
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

        private string ObtenerHeaderLegible(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "Codigo": return "CÓDIGO";
                case "Nombre": return "NOMBRE DEL ARTÍCULO";
                case "StockSistema": return "STOCK ACTUAL";
                case "EstadoStock": return "ESTADO";
                default: return headerOriginal.ToUpper();
            }
        }

    private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoReporte.Rows.Count == 0)
                {
                    MensajeError("No hay datos para exportar");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv";
                saveFileDialog.FileName = $"Inventario_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Encabezados
                        for (int i = 0; i < dataListadoReporte.Columns.Count; i++)
                        {
                            writer.Write(dataListadoReporte.Columns[i].HeaderText);
                            if (i < dataListadoReporte.Columns.Count - 1)
                                writer.Write(";");
                        }
                        writer.WriteLine();

                        // Datos
                        foreach (DataGridViewRow row in dataListadoReporte.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataListadoReporte.Columns.Count; i++)
                                {
                                    string valor = row.Cells[i].Value?.ToString() ?? "";
                                    writer.Write(valor);
                                    if (i < dataListadoReporte.Columns.Count - 1)
                                        writer.Write(";");
                                }
                                writer.WriteLine();
                            }
                        }
                    }

                    MensajeOk("Datos exportados a CSV exitosamente!");
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al exportar: " + ex.Message);
            }
        }

        // Pestaña 2: Conteo Físico
        private void btnIniciarConteo_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del usuario actual (deberías tener esto en tu sesión)
                int idusuario = 1; // Cambiar por el usuario logueado

                idconteoActual = NInventario.IniciarConteoInventario(idusuario, txtObservacionesConteo.Text);

                if (idconteoActual > 0)
                {
                    conteoEnCurso = true;
                    btnIniciarConteo.Enabled = false;
                    btnFinalizarConteo.Enabled = true;
                    btnAgregarConteo.Enabled = true;
                    lblEstadoConteo.Text = "CONTEO EN CURSO - ID: " + idconteoActual;
                    lblEstadoConteo.ForeColor = Color.Green;
                    MensajeOk("Conteo iniciado correctamente. ID: " + idconteoActual);
                }
                else
                {
                    MensajeError("No se pudo iniciar el conteo");
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al iniciar conteo: " + ex.Message);
            }
        }

        private void btnFinalizarConteo_Click(object sender, EventArgs e)
        {
            try
            {
                if (idconteoActual > 0)
                {
                    string resultado = NInventario.ProcesarConteo(idconteoActual);

                    if (resultado == "OK")
                    {
                        conteoEnCurso = false;
                        btnIniciarConteo.Enabled = true;
                        btnFinalizarConteo.Enabled = false;
                        btnAgregarConteo.Enabled = false;
                        lblEstadoConteo.Text = "CONTEO FINALIZADO";
                        lblEstadoConteo.ForeColor = Color.Blue;

                        // Mostrar resumen
                        MostrarResumenConteo();
                        MensajeOk("Conteo finalizado y stocks actualizados correctamente");
                    }
                    else
                    {
                        MensajeError("Error al finalizar conteo: " + resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al finalizar conteo: " + ex.Message);
            }
        }

        private void btnAgregarConteo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!conteoEnCurso)
                {
                    MensajeError("Debe iniciar un conteo primero");
                    return;
                }

                if (string.IsNullOrEmpty(txtCodigoConteo.Text))
                {
                    MensajeError("Ingrese un código de artículo");
                    return;
                }

                if (!decimal.TryParse(txtStockFisicoConteo.Text, out decimal stockFisico))
                {
                    MensajeError("Stock físico debe ser un valor numérico válido");
                    return;
                }

                // Buscar artículo por código
                DataTable dtArticulo = NArticulo.BuscarNombre(txtCodigoConteo.Text);
                if (dtArticulo.Rows.Count == 0)
                {
                    MensajeError("No se encontró el artículo con código: " + txtCodigoConteo.Text);
                    return;
                }

                int idarticulo = Convert.ToInt32(dtArticulo.Rows[0]["idarticulo"]);
                string resultado = NInventario.AgregarDetalleConteo(idconteoActual, idarticulo, stockFisico);

                if (resultado == "OK")
                {
                    // Agregar a DataGridView
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataListadoConteo);
                    row.Cells[0].Value = dtArticulo.Rows[0]["Codigo"];
                    row.Cells[1].Value = dtArticulo.Rows[0]["Nombre"];
                    row.Cells[2].Value = dtArticulo.Rows[0]["StockSistema"];
                    row.Cells[3].Value = stockFisico;
                    row.Cells[4].Value = stockFisico - Convert.ToDecimal(dtArticulo.Rows[0]["StockSistema"]);
                    dataListadoConteo.Rows.Add(row);

                    LimpiarControlesConteo();
                    CalcularTotalesConteo();
                }
                else
                {
                    MensajeError("Error al agregar artículo al conteo: " + resultado);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al agregar artículo: " + ex.Message);
            }
        }

        private void CalcularTotalesConteo()
        {
            if (dataListadoConteo.Rows.Count > 0)
            {
                int totalArticulos = dataListadoConteo.Rows.Count;
                int conDiferencia = 0;

                foreach (DataGridViewRow row in dataListadoConteo.Rows)
                {
                    if (Convert.ToDecimal(row.Cells["DiferenciaConteo"].Value) != 0)
                        conDiferencia++;
                }

                lblTotalConteo.Text = $"Artículos contados: {totalArticulos} | Con diferencia: {conDiferencia}";
            }
        }

        private void MostrarResumenConteo()
        {
            try
            {
                dataListadoResumen.DataSource = NInventario.ObtenerDetalleConteo(idconteoActual);
                CalcularResumenConteo();
            }
            catch (Exception ex)
            {
                MensajeError("Error al cargar resumen: " + ex.Message);
            }
        }

        private void CalcularResumenConteo()
        {
            if (dataListadoResumen.Rows.Count > 0)
            {
                decimal totalDiferencias = 0;
                int faltantes = 0;
                int sobrantes = 0;

                foreach (DataGridViewRow row in dataListadoResumen.Rows)
                {
                    decimal diferencia = Convert.ToDecimal(row.Cells["Diferencia"].Value);
                    totalDiferencias += diferencia;

                    if (diferencia < 0) faltantes++;
                    else if (diferencia > 0) sobrantes++;
                }

                lblTotalResumen.Text = $"Total diferencias: {totalDiferencias:N2} | " +
                                    $"Faltantes: {faltantes} | " +
                                    $"Sobrantes: {sobrantes}";
            }
        }

        // Pestaña 3: Ajuste Rápido
        private void btnBuscarAjuste_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtArticulo = NArticulo.BuscarNombre(txtBuscarAjuste.Text);
                if (dtArticulo.Rows.Count > 0)
                {
                    dataListadoAjuste.DataSource = dtArticulo;
                    lblTotalAjuste.Text = "Artículos encontrados: " + dtArticulo.Rows.Count;
                }
                else
                {
                    MensajeError("No se encontraron artículos");
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al buscar artículos: " + ex.Message);
            }
        }

        private void dataListadoAjuste_DoubleClick(object sender, EventArgs e)
        {
            if (dataListadoAjuste.CurrentRow != null)
            {
                txtIdArticuloAjuste.Text = dataListadoAjuste.CurrentRow.Cells["idarticulo"].Value.ToString();
                txtCodigoAjuste.Text = dataListadoAjuste.CurrentRow.Cells["Codigo"].Value.ToString();
                txtNombreAjuste.Text = dataListadoAjuste.CurrentRow.Cells["Nombre"].Value.ToString();
                txtStockActualAjuste.Text = dataListadoAjuste.CurrentRow.Cells["StockActual"].Value.ToString();
                txtNuevoStockAjuste.Text = dataListadoAjuste.CurrentRow.Cells["StockActual"].Value.ToString();
                txtNuevoStockAjuste.Focus();
                txtNuevoStockAjuste.SelectAll();
            }
        }

        private void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdArticuloAjuste.Text))
                {
                    MensajeError("Seleccione un artículo primero");
                    return;
                }

                if (!decimal.TryParse(txtNuevoStockAjuste.Text, out decimal nuevoStock))
                {
                    MensajeError("El nuevo stock debe ser un valor numérico válido");
                    return;
                }

                int idarticulo = Convert.ToInt32(txtIdArticuloAjuste.Text);
                string resultado = NInventario.ActualizarStockIndividual(idarticulo, nuevoStock);

                if (resultado == "OK")
                {
                    MensajeOk("Stock actualizado correctamente");
                    // Actualizar el listado
                    btnBuscarAjuste_Click(sender, e);
                    // Limpiar controles
                    txtIdArticuloAjuste.Text = "";
                    txtCodigoAjuste.Text = "";
                    txtNombreAjuste.Text = "";
                    txtStockActualAjuste.Text = "";
                    txtNuevoStockAjuste.Text = "";
                }
                else
                {
                    MensajeError("Error al actualizar stock: " + resultado);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al aplicar ajuste: " + ex.Message);
            }
        }

        private void txtBuscarAjuste_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarAjuste.Text.Length >= 3)
            {
                btnBuscarAjuste_Click(sender, e);
            }
        }

     
    }
}