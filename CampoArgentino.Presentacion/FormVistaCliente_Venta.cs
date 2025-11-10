using CampoArgentino.Negocio;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaCliente_Venta : Form
    {
        // Variables para el detalle del cliente
        private int _clienteSeleccionadoId;
        private string _clienteSeleccionadoNombre;
        private string _clienteSeleccionadoCUIT;
        private decimal _totalVentasGeneral = 0;
        private Label lblTotalVentasGeneral;

        public FormVistaCliente_Venta()
        {
            InitializeComponent();

            // Inicializar variables
            _clienteSeleccionadoId = 0;
            _clienteSeleccionadoNombre = "";
            _clienteSeleccionadoCUIT = "";

            // Registrar eventos adicionales
            dataListado.SelectionChanged += dataListado_SelectionChanged;
            dataListado.DataBindingComplete += dataListado_DataBindingComplete;

            // Configurar selección por fila completa
            dataListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListado.MultiSelect = false;
        }

        private void FormVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            AgregarLabelTotalVentas();
            MostrarClientesConVentas();
        }

        private void AgregarLabelTotalVentas()
        {
            try
            {
                lblTotalVentasGeneral = new Label();
                lblTotalVentasGeneral.AutoSize = true;
                lblTotalVentasGeneral.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
                lblTotalVentasGeneral.ForeColor = Color.FromArgb(39, 174, 96); // Verde
                lblTotalVentasGeneral.Location = new Point(650, 85);
                lblTotalVentasGeneral.Text = "Total Ventas General: $0.00";

                // Agregar al panel del tabPageListado de forma segura
                if (tabPageListado != null && !tabPageListado.Controls.Contains(lblTotalVentasGeneral))
                {
                    tabPageListado.Controls.Add(lblTotalVentasGeneral);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al agregar label: {ex.Message}");
            }
        }

        // Propiedades para acceder a los datos del cliente seleccionado
        public int IdclienteSeleccionado
        {
            get
            {
                if (dataListado?.SelectedRows?.Count > 0)
                {
                    var selectedRow = dataListado.SelectedRows[0];
                    if (selectedRow?.Cells["idcliente"]?.Value != null)
                        return Convert.ToInt32(selectedRow.Cells["idcliente"].Value);
                    else if (selectedRow?.Cells["ClienteID"]?.Value != null)
                        return Convert.ToInt32(selectedRow.Cells["ClienteID"].Value);
                }
                return 0;
            }
        }

        public string NombreClienteSeleccionado
        {
            get
            {
                if (dataListado?.SelectedRows?.Count > 0)
                {
                    var selectedRow = dataListado.SelectedRows[0];
                    return selectedRow?.Cells["Nombre"]?.Value?.ToString() ?? "";
                }
                return "";
            }
        }

        public string CUITSeleccionado
        {
            get
            {
                if (dataListado?.SelectedRows?.Count > 0)
                {
                    var selectedRow = dataListado.SelectedRows[0];
                    return selectedRow?.Cells["CUIT"]?.Value?.ToString() ?? "";
                }
                return "";
            }
        }

        // Método principal para mostrar clientes con ventas
        private void MostrarClientesConVentas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable dtClientes = NCliente.MostrarClientesConVentas();

                if (dtClientes != null && dtClientes.Rows.Count > 0)
                {
                    dataListado.DataSource = dtClientes;

                    // Calcular total general de ventas
                    _totalVentasGeneral = 0;
                    foreach (DataRow row in dtClientes.Rows)
                    {
                        if (row["TotalVentas"] != DBNull.Value)
                        {
                            _totalVentasGeneral += Convert.ToDecimal(row["TotalVentas"]);
                        }
                    }

                    // Actualizar labels de forma segura
                    ActualizarLabelSeguro(lblTotal, $"Total Clientes: {dtClientes.Rows.Count}");
                    ActualizarLabelTotalVentas();
                }
                else
                {
                    dataListado.DataSource = null;
                    ActualizarLabelSeguro(lblTotal, "No hay clientes registrados");
                    ActualizarLabelSeguro(lblTotalVentasGeneral, "Total Ventas: $0.00");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar clientes con ventas: {ex.Message}");
                dataListado.DataSource = null;
                ActualizarLabelSeguro(lblTotal, "Error al cargar datos");
                ActualizarLabelSeguro(lblTotalVentasGeneral, "Total Ventas: $0.00");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Método seguro para actualizar labels
        private void ActualizarLabelSeguro(Label label, string texto)
        {
            if (label != null && !label.IsDisposed)
            {
                if (label.InvokeRequired)
                {
                    label.Invoke(new Action(() => label.Text = texto));
                }
                else
                {
                    label.Text = texto;
                }
            }
        }

        private void ActualizarLabelTotalVentas()
        {
            if (lblTotalVentasGeneral != null && !lblTotalVentasGeneral.IsDisposed)
            {
                string texto = $"Total Ventas General: {_totalVentasGeneral.ToString("C2")}";
                if (lblTotalVentasGeneral.InvokeRequired)
                {
                    lblTotalVentasGeneral.Invoke(new Action(() => lblTotalVentasGeneral.Text = texto));
                }
                else
                {
                    lblTotalVentasGeneral.Text = texto;
                }
            }
        }

        // Método para buscar clientes por nombre
        private void BuscarNombre()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar?.Text))
                {
                    MostrarClientesConVentas();
                    return;
                }

                Cursor = Cursors.WaitCursor;

                DataTable dtResultado = NCliente.BuscarNombre(txtBuscar.Text.Trim());

                if (dtResultado != null && dtResultado.Rows.Count > 0)
                {
                    dataListado.DataSource = dtResultado;
                    ActualizarLabelSeguro(lblTotal, "Registros encontrados: " + dtResultado.Rows.Count);

                    // Recalcular total ventas para los resultados filtrados
                    _totalVentasGeneral = 0;
                    foreach (DataRow row in dtResultado.Rows)
                    {
                        if (dtResultado.Columns.Contains("TotalVentas") && row["TotalVentas"] != DBNull.Value)
                        {
                            _totalVentasGeneral += Convert.ToDecimal(row["TotalVentas"]);
                        }
                    }
                    ActualizarLabelTotalVentas();
                }
                else
                {
                    dataListado.DataSource = null;
                    ActualizarLabelSeguro(lblTotal, "No se encontraron coincidencias");
                    ActualizarLabelSeguro(lblTotalVentasGeneral, "Total Ventas: $0.00");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al buscar clientes: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Ocultar columnas que no se necesitan mostrar 
        private void OcultarColumnas()
        {
            try
            {
                if (dataListado?.Columns == null || dataListado.Columns.Count == 0) return;

                // Columnas a ocultar
                string[] columnasOcultar = { "idcliente", "Direccion", "Telefono", "Email" };

                foreach (string columna in columnasOcultar)
                {
                    if (dataListado.Columns.Contains(columna))
                    {
                        dataListado.Columns[columna].Visible = false;
                    }
                }

                ConfigurarColumnasVisibles();
                dataListado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en OcultarColumnas: {ex.Message}");
            }
        }

        private void ConfigurarColumnasVisibles()
        {
            try
            {
                if (dataListado?.Columns == null) return;

                if (dataListado.Columns.Contains("Nombre"))
                {
                    dataListado.Columns["Nombre"].HeaderText = "CLIENTE";
                    dataListado.Columns["Nombre"].Width = 200;
                    dataListado.Columns["Nombre"].DisplayIndex = 0;
                }

                if (dataListado.Columns.Contains("CUIT"))
                {
                    dataListado.Columns["CUIT"].HeaderText = "CUIT/DNI";
                    dataListado.Columns["CUIT"].Width = 120;
                    dataListado.Columns["CUIT"].DisplayIndex = 1;
                }

                if (dataListado.Columns.Contains("TotalVentas"))
                {
                    dataListado.Columns["TotalVentas"].HeaderText = "TOTAL VENTAS";
                    dataListado.Columns["TotalVentas"].Width = 120;
                    dataListado.Columns["TotalVentas"].DefaultCellStyle.Format = "C2";
                    dataListado.Columns["TotalVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataListado.Columns["TotalVentas"].DisplayIndex = 2;
                }

                if (dataListado.Columns.Contains("CantidadVentas"))
                {
                    dataListado.Columns["CantidadVentas"].HeaderText = "CANT. VENTAS";
                    dataListado.Columns["CantidadVentas"].Width = 100;
                    dataListado.Columns["CantidadVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataListado.Columns["CantidadVentas"].DisplayIndex = 3;
                }

                if (dataListado.Columns.Contains("FechaUltimaVenta"))
                {
                    dataListado.Columns["FechaUltimaVenta"].HeaderText = "ÚLTIMA VENTA";
                    dataListado.Columns["FechaUltimaVenta"].Width = 110;
                    dataListado.Columns["FechaUltimaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataListado.Columns["FechaUltimaVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataListado.Columns["FechaUltimaVenta"].DisplayIndex = 4;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en ConfigurarColumnasVisibles: {ex.Message}");
            }
        }

        // Evento doble click para ver detalle de compras
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado?.SelectedRows == null || dataListado.SelectedRows.Count == 0)
            {
                MostrarInformacion("Seleccione un cliente primero");
                return;
            }

            try
            {
                DataGridViewRow row = dataListado.SelectedRows[0];
                if (row?.Cells["idcliente"]?.Value != null)
                {
                    _clienteSeleccionadoId = Convert.ToInt32(row.Cells["idcliente"].Value);
                    _clienteSeleccionadoNombre = row.Cells["Nombre"]?.Value?.ToString() ?? "Cliente";
                    _clienteSeleccionadoCUIT = row.Cells["CUIT"]?.Value?.ToString() ?? "Sin CUIT";

                    MostrarDetalleComprasCliente();
                }
                else
                {
                    MostrarError("No se pudo obtener la información del cliente seleccionado");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error: {ex.Message}");
            }
        }

        private void dataListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListado?.SelectedRows?.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataListado.SelectedRows[0];
                    if (selectedRow?.Cells["idcliente"]?.Value != null)
                    {
                        _clienteSeleccionadoId = Convert.ToInt32(selectedRow.Cells["idcliente"]?.Value ?? 0);
                        _clienteSeleccionadoNombre = selectedRow.Cells["Nombre"]?.Value?.ToString() ?? "";
                        _clienteSeleccionadoCUIT = selectedRow.Cells["CUIT"]?.Value?.ToString() ?? "";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error en SelectionChanged: {ex.Message}");
                }
            }
        }

        private void dataListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                Debug.WriteLine("✅ DataBindingComplete - Configurando interfaz");

                OcultarColumnas();

                if (dataListado?.DataSource is DataTable dt)
                {
                    ActualizarLabelSeguro(lblTotal, "Total Registros: " + dt.Rows.Count);
                }

                // Seleccionar la primera fila si hay datos
                if (dataListado?.Rows?.Count > 0)
                {
                    dataListado.Rows[0].Selected = true;
                    Debug.WriteLine("✅ Primera fila seleccionada automáticamente");
                }

                Debug.WriteLine("🎯 Configuración de interfaz completada");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en DataBindingComplete: {ex.Message}");
            }
        }

        private void MostrarDetalleComprasCliente()
        {
            try
            {
                if (_clienteSeleccionadoId <= 0) return;

                // Actualizar información del cliente de forma segura
                ActualizarLabelSeguro(lblClienteInfo, $"{_clienteSeleccionadoNombre} - {_clienteSeleccionadoCUIT}");

                // Cargar detalle por artículo
                DataTable dtArticulos = NVenta.ComprasClientePorArticulo(_clienteSeleccionadoId);

                if (dtArticulos != null && dtArticulos.Rows.Count > 0)
                {
                    dataListadoArticulos.DataSource = dtArticulos;
                    ConfigurarColumnasArticulos();
                    ActualizarLabelSeguro(lblTotalArticulos, $"Total Artículos Diferentes: {dtArticulos.Rows.Count}");
                }
                else
                {
                    // Cliente sin compras - mostrar mensaje amigable
                    DataTable dtVacio = new DataTable();
                    dtVacio.Columns.Add("Información");
                    dtVacio.Rows.Add("Este cliente no tiene compras registradas");
                    dataListadoArticulos.DataSource = dtVacio;

                    if (dataListadoArticulos.Columns.Contains("Información"))
                    {
                        dataListadoArticulos.Columns["Información"].Width = 300;
                    }
                    ActualizarLabelSeguro(lblTotalArticulos, "Sin compras registradas");
                }

                // Cargar resumen total
                try
                {
                    DataTable dtResumen = NVenta.TotalComprasCliente(_clienteSeleccionadoId);
                    MostrarResumenCliente(dtResumen);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al cargar resumen: {ex.Message}");
                    ActualizarLabelSeguro(lblResumen, "No se pudo cargar el resumen de compras");
                }

                // Cambiar a pestaña de detalle de forma segura
                if (tabControl1 != null && tabPageDetalle != null)
                {
                    tabControl1.SelectedTab = tabPageDetalle;
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar detalle: {ex.Message}");
            }
        }

        private void ConfigurarColumnasArticulos()
        {
            try
            {
                if (dataListadoArticulos?.Columns == null) return;

                if (dataListadoArticulos.Columns.Contains("CantidadComprada"))
                {
                    dataListadoArticulos.Columns["CantidadComprada"].HeaderText = "CANT. COMPRADA";
                    dataListadoArticulos.Columns["CantidadComprada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListadoArticulos.Columns.Contains("PrecioPromedio"))
                {
                    dataListadoArticulos.Columns["PrecioPromedio"].HeaderText = "PRECIO PROMEDIO";
                    dataListadoArticulos.Columns["PrecioPromedio"].DefaultCellStyle.Format = "C2";
                    dataListadoArticulos.Columns["PrecioPromedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListadoArticulos.Columns.Contains("TotalComprado"))
                {
                    dataListadoArticulos.Columns["TotalComprado"].HeaderText = "TOTAL COMPRADO";
                    dataListadoArticulos.Columns["TotalComprado"].DefaultCellStyle.Format = "C2";
                    dataListadoArticulos.Columns["TotalComprado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListadoArticulos.Columns.Contains("VecesComprado"))
                {
                    dataListadoArticulos.Columns["VecesComprado"].HeaderText = "VECES COMPRADO";
                    dataListadoArticulos.Columns["VecesComprado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dataListadoArticulos.Columns.Contains("FechaUltimaCompra"))
                {
                    dataListadoArticulos.Columns["FechaUltimaCompra"].HeaderText = "ÚLTIMA COMPRA";
                    dataListadoArticulos.Columns["FechaUltimaCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataListadoArticulos.Columns["FechaUltimaCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dataListadoArticulos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MostrarAdvertencia("Error al configurar columnas: " + ex.Message);
            }
        }

        private void MostrarResumenCliente(DataTable dtResumen)
        {
            try
            {
                if (dtResumen == null || dtResumen.Rows.Count == 0)
                {
                    ActualizarLabelSeguro(lblResumen, "El cliente no tiene compras registradas");
                    return;
                }

                DataRow row = dtResumen.Rows[0];

                decimal montoTotal = row["MontoTotalCompras"] != DBNull.Value ?
                    Convert.ToDecimal(row["MontoTotalCompras"]) : 0;

                int totalVentas = row["TotalVentas"] != DBNull.Value ?
                    Convert.ToInt32(row["TotalVentas"]) : 0;

                string resumen = $"Total Compras: {montoTotal.ToString("C2")} | Ventas: {totalVentas}";
                ActualizarLabelSeguro(lblResumen, resumen);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en MostrarResumenCliente: {ex.Message}");
                ActualizarLabelSeguro(lblResumen, "Información de compras no disponible");
            }
        }

        // Métodos de navegación
        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (tabControl1 != null && tabPageListado != null)
            {
                tabControl1.SelectedTab = tabPageListado;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        // Métodos de impresión
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirReporteClientes();
        }

        private void btnImprimirDetalle_Click(object sender, EventArgs e)
        {
            ImprimirReporteDetalleCompras();
        }

        private void ImprimirReporteClientes()
        {
            try
            {
                ConfigurarCultureInfoArgentina();

                if (dataListado?.Rows == null || dataListado.Rows.Count == 0)
                {
                    MostrarError("No hay clientes para generar el reporte");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_Clientes_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFClientesConVentas(saveFileDialog.FileName);

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
                MostrarError("Error al generar PDF: " + ex.Message);
            }
        }

        private void ImprimirReporteDetalleCompras()
        {
            try
            {
                ConfigurarCultureInfoArgentina();

                if (dataListadoArticulos?.Rows == null || dataListadoArticulos.Rows.Count == 0)
                {
                    MostrarError("No hay datos de compras para generar el reporte");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_Compras_Cliente_{_clienteSeleccionadoNombre}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFDetalleCompras(saveFileDialog.FileName);

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
                MostrarError("Error al generar PDF: " + ex.Message);
            }
        }

        // Métodos auxiliares
        private void ConfigurarCultureInfoArgentina()
        {
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            culturaArgentina.NumberFormat.CurrencySymbol = "$";
            culturaArgentina.NumberFormat.CurrencyPositivePattern = 2;
            culturaArgentina.NumberFormat.CurrencyNegativePattern = 8;
            System.Threading.Thread.CurrentThread.CurrentCulture = culturaArgentina;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culturaArgentina;
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Métodos para generar PDF (se mantienen igual)
        private void AgregarCeldaTabla(PdfPTable tabla, string etiqueta, string valor, Font font)
        {
            PdfPCell celdaEtiqueta = new PdfPCell(new Phrase(etiqueta, font));
            celdaEtiqueta.Border = PdfPCell.NO_BORDER;
            celdaEtiqueta.Padding = 2;
            tabla.AddCell(celdaEtiqueta);

            PdfPCell celdaValor = new PdfPCell(new Phrase(valor, font));
            celdaValor.Border = PdfPCell.NO_BORDER;
            celdaValor.Padding = 2;
            tabla.AddCell(celdaValor);
        }

        private void AgregarCeldaTablaResumen(PdfPTable tabla, string etiqueta, string valor, Font fontEtiqueta, Font fontValor)
        {
            PdfPCell celdaEtiqueta = new PdfPCell(new Phrase(etiqueta, fontEtiqueta));
            celdaEtiqueta.Border = PdfPCell.NO_BORDER;
            celdaEtiqueta.Padding = 5;
            tabla.AddCell(celdaEtiqueta);

            PdfPCell celdaValor = new PdfPCell(new Phrase(valor, fontValor));
            celdaValor.Border = PdfPCell.NO_BORDER;
            celdaValor.Padding = 5;
            celdaValor.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabla.AddCell(celdaValor);
        }
        private void GenerarPDFClientesConVentas(string filePath)
        {
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            culturaArgentina.NumberFormat.CurrencySymbol = "$";
            culturaArgentina.NumberFormat.CurrencyPositivePattern = 2;
            culturaArgentina.NumberFormat.CurrencyNegativePattern = 8;

            Document document = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Fuentes
                Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                Font fontSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.DARK_GRAY);
                Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
                Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.WHITE);
                Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
                Font fontMonto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.BLACK);

                // Título
                Paragraph titulo = new Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                Paragraph subtitulo = new Paragraph("REPORTE DE CLIENTES - RESUMEN DE VENTAS", fontSubtitulo);
                subtitulo.Alignment = Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // Información del reporte
                PdfPTable tablaInfo = new PdfPTable(4);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas
                int totalClientes = dataListado.Rows.Count;
                int clientesConVentas = 0;
                decimal totalVentasGeneral = 0;

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow && row.Cells["TotalVentas"].Value != null && row.Cells["TotalVentas"].Value != DBNull.Value)
                    {
                        decimal ventasCliente = Convert.ToDecimal(row.Cells["TotalVentas"].Value);
                        totalVentasGeneral += ventasCliente;
                        if (ventasCliente > 0) clientesConVentas++;
                    }
                }

                AgregarCeldaTabla(tablaInfo, "Fecha generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total clientes:", totalClientes.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Clientes con ventas:", clientesConVentas.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Clientes sin ventas:", (totalClientes - clientesConVentas).ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total ventas general:", totalVentasGeneral.ToString("C2", culturaArgentina), fontMonto);
                AgregarCeldaTabla(tablaInfo, "", "", fontNormal);
                AgregarCeldaTabla(tablaInfo, "", "", fontNormal);

                document.Add(tablaInfo);

                // Tabla principal de clientes
                if (totalClientes > 0)
                {
                    List<string> columnasClientes = new List<string> { "Nombre", "CUIT", "TotalVentas", "CantidadVentas", "FechaUltimaVenta" };

                    PdfPTable tablaClientes = new PdfPTable(columnasClientes.Count);
                    tablaClientes.WidthPercentage = 100;
                    tablaClientes.SpacingBefore = 10f;
                    tablaClientes.SpacingAfter = 20f;

                    // Configurar anchos de columnas - CORREGIDO: usar float explícito
                    float[] anchos = { 35f, 20f, 15f, 15f, 15f };
                    tablaClientes.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasClientes)
                    {
                        string headerText = ObtenerHeaderVentas(columna);
                        PdfPCell celdaHeader = new PdfPCell(new Phrase(headerText, fontHeader));
                        celdaHeader.BackgroundColor = new BaseColor(70, 130, 180);
                        celdaHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                        celdaHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
                        celdaHeader.Padding = 5;
                        celdaHeader.PaddingTop = 6;
                        tablaClientes.AddCell(celdaHeader);
                    }

                    // Datos de los clientes
                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (string columna in columnasClientes)
                            {
                                string valor = fila.Cells[columna].Value?.ToString() ?? "";
                                Phrase frase;

                                // Formatear valores
                                if (columna == "TotalVentas")
                                {
                                    if (decimal.TryParse(valor, out decimal valorDecimal))
                                    {
                                        valor = valorDecimal.ToString("C2", culturaArgentina);
                                        frase = new Phrase(valor, fontMonto);
                                    }
                                    else
                                    {
                                        frase = new Phrase(valor, fontData);
                                    }
                                }
                                else if (columna == "FechaUltimaVenta")
                                {
                                    if (DateTime.TryParse(valor, out DateTime fecha))
                                    {
                                        valor = fecha.ToString("dd/MM/yyyy");
                                    }
                                    frase = new Phrase(valor, fontData);
                                }
                                else
                                {
                                    frase = new Phrase(valor, fontData);
                                }

                                PdfPCell celdaData = new PdfPCell(frase);

                                // Alineación
                                if (columna == "TotalVentas" || columna == "CantidadVentas" || columna == "FechaUltimaVenta")
                                {
                                    celdaData.HorizontalAlignment = Element.ALIGN_CENTER;
                                }
                                else
                                {
                                    celdaData.HorizontalAlignment = Element.ALIGN_LEFT;
                                }

                                celdaData.VerticalAlignment = Element.ALIGN_MIDDLE;
                                celdaData.Padding = 4;
                                celdaData.PaddingTop = 5;
                                tablaClientes.AddCell(celdaData);
                            }
                        }
                    }

                    document.Add(tablaClientes);
                }

                // Resumen final
                PdfPTable tablaResumen = new PdfPTable(2);
                tablaResumen.WidthPercentage = 50;
                tablaResumen.HorizontalAlignment = Element.ALIGN_RIGHT;
                tablaResumen.SpacingBefore = 10f;

                AgregarCeldaTablaResumen(tablaResumen, "TOTAL CLIENTES:", totalClientes.ToString(), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "CLIENTES CON VENTAS:", clientesConVentas.ToString(), fontNormal, fontMonto);

                PdfPCell celdaTotalLabel = new PdfPCell(new Phrase("TOTAL VENTAS GENERAL:", fontMonto));
                celdaTotalLabel.Border = PdfPCell.NO_BORDER;
                celdaTotalLabel.Padding = 5;
                celdaTotalLabel.BackgroundColor = new BaseColor(240, 240, 240);
                tablaResumen.AddCell(celdaTotalLabel);

                PdfPCell celdaTotalValor = new PdfPCell(new Phrase(totalVentasGeneral.ToString("C2", culturaArgentina), fontMonto));
                celdaTotalValor.Border = PdfPCell.NO_BORDER;
                celdaTotalValor.Padding = 5;
                celdaTotalValor.BackgroundColor = new BaseColor(240, 240, 240);
                celdaTotalValor.HorizontalAlignment = Element.ALIGN_RIGHT;
                tablaResumen.AddCell(celdaTotalValor);

                document.Add(tablaResumen);

                // Pie de página
                Paragraph piePagina = new Paragraph(
                    $"Página 1 | Generado por Sistema Campo Argentino | {DateTime.Now:dd/MM/yyyy HH:mm}",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7, BaseColor.GRAY));
                piePagina.Alignment = Element.ALIGN_CENTER;
                document.Add(piePagina);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar PDF de clientes: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        private void GenerarPDFDetalleCompras(string filePath)
        {
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            culturaArgentina.NumberFormat.CurrencySymbol = "$";
            culturaArgentina.NumberFormat.CurrencyPositivePattern = 2;
            culturaArgentina.NumberFormat.CurrencyNegativePattern = 8;

            Document document = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Fuentes
                Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                Font fontSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.DARK_GRAY);
                Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
                Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.WHITE);
                Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
                Font fontMonto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.BLACK);

                // Título
                Paragraph titulo = new Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                Paragraph subtitulo = new Paragraph($"DETALLE DE COMPRAS - {_clienteSeleccionadoNombre}", fontSubtitulo);
                subtitulo.Alignment = Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // Información del cliente
                PdfPTable tablaInfo = new PdfPTable(2);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                AgregarCeldaTabla(tablaInfo, "Cliente:", _clienteSeleccionadoNombre, fontNormal);
                AgregarCeldaTabla(tablaInfo, "CUIT/DNI:", _clienteSeleccionadoCUIT, fontNormal);
                AgregarCeldaTabla(tablaInfo, "Fecha generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total artículos diferentes:", dataListadoArticulos.Rows.Count.ToString(), fontNormal);

                document.Add(tablaInfo);

                // Tabla de compras por artículo
                if (dataListadoArticulos.Rows.Count > 0 && !dataListadoArticulos.Rows[0].IsNewRow)
                {
                    List<string> columnasArticulos = new List<string>();

                    // Verificar qué columnas están disponibles
                    if (dataListadoArticulos.Columns.Contains("Articulo")) columnasArticulos.Add("Articulo");
                    if (dataListadoArticulos.Columns.Contains("Categoria")) columnasArticulos.Add("Categoria");
                    if (dataListadoArticulos.Columns.Contains("CantidadComprada")) columnasArticulos.Add("CantidadComprada");
                    if (dataListadoArticulos.Columns.Contains("PrecioPromedio")) columnasArticulos.Add("PrecioPromedio");
                    if (dataListadoArticulos.Columns.Contains("TotalComprado")) columnasArticulos.Add("TotalComprado");
                    if (dataListadoArticulos.Columns.Contains("VecesComprado")) columnasArticulos.Add("VecesComprado");
                    if (dataListadoArticulos.Columns.Contains("FechaUltimaCompra")) columnasArticulos.Add("FechaUltimaCompra");

                    if (columnasArticulos.Count > 0)
                    {
                        PdfPTable tablaArticulos = new PdfPTable(columnasArticulos.Count);
                        tablaArticulos.WidthPercentage = 100;
                        tablaArticulos.SpacingBefore = 10f;
                        tablaArticulos.SpacingAfter = 20f;

                        // Configurar anchos de columnas dinámicamente
                        float[] anchos = new float[columnasArticulos.Count];
                        for (int i = 0; i < columnasArticulos.Count; i++)
                        {
                            anchos[i] = 100f / columnasArticulos.Count;
                        }
                        tablaArticulos.SetWidths(anchos);

                        // Encabezados de columnas
                        foreach (string columna in columnasArticulos)
                        {
                            string headerText = ObtenerHeaderArticulos(columna);
                            PdfPCell celdaHeader = new PdfPCell(new Phrase(headerText, fontHeader));
                            celdaHeader.BackgroundColor = new BaseColor(70, 130, 180);
                            celdaHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                            celdaHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
                            celdaHeader.Padding = 5;
                            celdaHeader.PaddingTop = 6;
                            tablaArticulos.AddCell(celdaHeader);
                        }

                        // Calcular totales
                        decimal totalComprasCliente = 0;
                        decimal totalCantidadComprada = 0;

                        // Datos de los artículos
                        foreach (DataGridViewRow fila in dataListadoArticulos.Rows)
                        {
                            if (!fila.IsNewRow)
                            {
                                foreach (string columna in columnasArticulos)
                                {
                                    string valor = fila.Cells[columna].Value?.ToString() ?? "";
                                    Phrase frase;

                                    // Formatear valores numéricos
                                    if (columna == "PrecioPromedio" || columna == "TotalComprado")
                                    {
                                        if (decimal.TryParse(valor, out decimal valorDecimal))
                                        {
                                            valor = valorDecimal.ToString("C2", culturaArgentina);
                                            frase = new Phrase(valor, fontMonto);

                                            // Acumular totales
                                            if (columna == "TotalComprado")
                                                totalComprasCliente += valorDecimal;
                                        }
                                        else
                                        {
                                            frase = new Phrase(valor, fontData);
                                        }
                                    }
                                    else if (columna == "CantidadComprada")
                                    {
                                        if (decimal.TryParse(valor, out decimal cantidad))
                                        {
                                            totalCantidadComprada += cantidad;
                                            frase = new Phrase(cantidad.ToString("N2"), fontData);
                                        }
                                        else
                                        {
                                            frase = new Phrase(valor, fontData);
                                        }
                                    }
                                    else if (columna == "FechaUltimaCompra")
                                    {
                                        if (DateTime.TryParse(valor, out DateTime fecha))
                                        {
                                            valor = fecha.ToString("dd/MM/yyyy");
                                        }
                                        frase = new Phrase(valor, fontData);
                                    }
                                    else
                                    {
                                        frase = new Phrase(valor, fontData);
                                    }

                                    PdfPCell celdaData = new PdfPCell(frase);

                                    // Alineación
                                    if (columna == "CantidadComprada" || columna == "PrecioPromedio" ||
                                        columna == "TotalComprado" || columna == "VecesComprado" ||
                                        columna == "FechaUltimaCompra")
                                    {
                                        celdaData.HorizontalAlignment = Element.ALIGN_CENTER;
                                    }
                                    else
                                    {
                                        celdaData.HorizontalAlignment = Element.ALIGN_LEFT;
                                    }

                                    celdaData.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    celdaData.Padding = 4;
                                    celdaData.PaddingTop = 5;
                                    tablaArticulos.AddCell(celdaData);
                                }
                            }
                        }

                        document.Add(tablaArticulos);

                        // Resumen final
                        PdfPTable tablaResumen = new PdfPTable(2);
                        tablaResumen.WidthPercentage = 50;
                        tablaResumen.HorizontalAlignment = Element.ALIGN_RIGHT;
                        tablaResumen.SpacingBefore = 10f;

                        AgregarCeldaTablaResumen(tablaResumen, "Artículos diferentes:", dataListadoArticulos.Rows.Count.ToString(), fontNormal, fontMonto);
                        AgregarCeldaTablaResumen(tablaResumen, "Total cantidad comprada:", totalCantidadComprada.ToString("N2"), fontNormal, fontMonto);

                        PdfPCell celdaTotalLabel = new PdfPCell(new Phrase("TOTAL COMPRAS CLIENTE:", fontMonto));
                        celdaTotalLabel.Border = PdfPCell.NO_BORDER;
                        celdaTotalLabel.Padding = 5;
                        celdaTotalLabel.BackgroundColor = new BaseColor(240, 240, 240);
                        tablaResumen.AddCell(celdaTotalLabel);

                        PdfPCell celdaTotalValor = new PdfPCell(new Phrase(totalComprasCliente.ToString("C2", culturaArgentina), fontMonto));
                        celdaTotalValor.Border = PdfPCell.NO_BORDER;
                        celdaTotalValor.Padding = 5;
                        celdaTotalValor.BackgroundColor = new BaseColor(240, 240, 240);
                        celdaTotalValor.HorizontalAlignment = Element.ALIGN_RIGHT;
                        tablaResumen.AddCell(celdaTotalValor);

                        document.Add(tablaResumen);
                    }
                }

                // Pie de página
                Paragraph piePagina = new Paragraph(
                    $"Página 1 | Generado por Sistema Campo Argentino | {DateTime.Now:dd/MM/yyyy HH:mm}",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7, BaseColor.GRAY));
                piePagina.Alignment = Element.ALIGN_CENTER;
                document.Add(piePagina);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar PDF de detalle: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        // Métodos auxiliares para headers
        private string ObtenerHeaderArticulos(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "Articulo": return "ARTÍCULO";
                case "Categoria": return "CATEGORÍA";
                case "CantidadComprada": return "CANT. COMPRADA";
                case "PrecioPromedio": return "PRECIO PROMEDIO";
                case "TotalComprado": return "TOTAL COMPRADO";
                case "VecesComprado": return "VECES COMPRADO";
                case "FechaUltimaCompra": return "ÚLTIMA COMPRA";
                case "Mensaje": return "INFORMACIÓN";
                default: return headerOriginal?.ToUpper() ?? "COLUMNA";
            }
        }

        private string ObtenerHeaderVentas(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "NumeroDocumento": return "DOCUMENTO";
                case "Cliente": return "CLIENTE";
                case "FechaVenta": return "FECHA";
                case "Subtotal": return "SUBTOTAL";
                case "Impuestos": return "IMPUESTOS";
                case "Total": return "TOTAL";
                case "Observaciones": return "OBSERVACIONES";
                case "Nombre": return "CLIENTE";
                case "CUIT": return "CUIT/DNI";
                case "TotalVentas": return "TOTAL VENTAS";
                case "CantidadVentas": return "CANT. VENTAS";
                case "FechaUltimaVenta": return "ÚLTIMA VENTA";
                default: return headerOriginal?.ToUpper() ?? "COLUMNA";
            }
        }

        // Eventos vacíos necesarios
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}