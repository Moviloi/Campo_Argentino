using CampoArgentino.Datos;
using CampoArgentino.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;
using iTextSharp = iTextSharp.text;

namespace CampoArgentino.Presentacion
{
    public partial class FormVenta : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static int IdusuarioActual = 1;
        private DataTable dtDetalleVenta;

        public FormVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNumeroDocumento, "Ingrese el número de documento");
            this.ttMensaje.SetToolTip(this.txtObservaciones, "Ingrese observaciones adicionales");
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            // Configura CultureInfo para Argentina
            ConfigurarCultureInfoArgentina();

            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.LlenarComboCliente();
            this.LlenarComboArticulo();
            this.InicializarDetalleVenta();
            this.dtpFechaVenta.Value = DateTime.Now;
            this.ConfigurarBotonFactura();
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

        private void InicializarDetalleVenta()
        {
            dtDetalleVenta = new DataTable();
            dtDetalleVenta.Columns.Add("idarticulo", typeof(int));
            dtDetalleVenta.Columns.Add("Codigo", typeof(string));
            dtDetalleVenta.Columns.Add("Nombre", typeof(string));
            dtDetalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
            dtDetalleVenta.Columns.Add("Cantidad", typeof(decimal));
            dtDetalleVenta.Columns.Add("Subtotal", typeof(decimal));

            dataListadoDetalle.DataSource = dtDetalleVenta;
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

        private void Limpiar()
        {
            this.txtVentaID.Text = string.Empty;
            this.txtNumeroDocumento.Text = string.Empty; // Se llenará automáticamente al crear nueva
            this.cbCliente.SelectedIndex = -1;
            this.dtpFechaVenta.Value = DateTime.Now;
            this.txtSubtotal.Text = "0.00";
            this.txtImpuestos.Text = "0.00";
            this.txtTotal.Text = "0.00";
            this.txtObservaciones.Text = string.Empty;

            // Limpiar detalle y controles de artículos
            dtDetalleVenta.Clear();
            LimpiarControlesArticulo();
        }

        private void Habilitar(bool valor)
        {
            // El número de documento es editable solo en nuevo registro
            this.txtNumeroDocumento.ReadOnly = !valor || !this.IsNuevo;

            this.cbCliente.Enabled = valor;
            this.dtpFechaVenta.Enabled = valor;
            this.txtObservaciones.ReadOnly = !valor;

            // Habilitar/deshabilitar controles de artículos
            panelAgregarArticulo.Visible = valor;
            btnAgregarArticulo.Enabled = valor;
            btnQuitarArticulo.Enabled = valor;
            cbArticulo.Enabled = valor;
            txtCantidad.ReadOnly = !valor;
            txtPrecioVenta.ReadOnly = !valor;
            txtBuscarArticulo.ReadOnly = !valor;
            dataListadoArticulos.Enabled = valor;

            // Mostrar/ocultar el listado de artículos según si hay texto de búsqueda
            dataListadoArticulos.Visible = !string.IsNullOrEmpty(txtBuscarArticulo.Text);
        }

        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            if (this.dataListado.Columns.Count > 0 && this.dataListado.Columns["Eliminar"] != null)
            {
                this.dataListado.Columns["Eliminar"].Visible = chkEliminar.Checked;
            }

            if (this.dataListado.Columns["idventa"] != null)
            {
                this.dataListado.Columns["idventa"].Visible = false;
            }
        }

        private void Mostrar()
        {
            try
            {
                DataTable dt = NVenta.Mostrar();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataListado.DataSource = dt;
                    this.OcultarColumnas();
                    lblTotal.Text = "Total Registros: " + dt.Rows.Count;

                    if (dataListado.Columns["Eliminar"] == null)
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "Anular";
                        checkColumn.Name = "Eliminar";
                        checkColumn.Width = 60;
                        dataListado.Columns.Insert(0, checkColumn);
                    }
                }
                else
                {
                    this.dataListado.DataSource = null;
                    lblTotal.Text = "Total Registros: 0";
                    MensajeError("No se encontraron registros de ventas");
                }
            }
            catch (Exception ex)
            {
                this.dataListado.DataSource = null;
                lblTotal.Text = "Total Registros: 0";
                MensajeError("Error al cargar ventas: " + ex.Message);
            }
        }

        private void BuscarFechas()
        {
            try
            {
                DataTable dt = NVenta.BuscarFechas(
                    dtpFechaInicio.Value.ToString("yyyy-MM-dd"),
                    dtpFechaFin.Value.ToString("yyyy-MM-dd")
                );

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataListado.DataSource = dt;
                    this.OcultarColumnas();
                    lblTotal.Text = "Total Registros: " + dt.Rows.Count;
                }
                else
                {
                    this.dataListado.DataSource = null;
                    lblTotal.Text = "Total Registros: 0";
                    MensajeOk("No se encontraron ventas en el rango de fechas seleccionado");
                }
            }
            catch (Exception ex)
            {
                this.dataListado.DataSource = null;
                lblTotal.Text = "Total Registros: 0";
                MensajeError("Error al buscar ventas: " + ex.Message);
            }
        }

        private void LlenarComboCliente()
        {
            try
            {
                DataTable dtClientes = NCliente.Mostrar();
                cbCliente.DataSource = dtClientes;
                cbCliente.ValueMember = "idcliente";
                cbCliente.DisplayMember = "Nombre";
                cbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void LlenarComboArticulo()
        {
            try
            {
                DataTable dtArticulos = NArticulo.Mostrar();
                cbArticulo.DataSource = dtArticulos;
                cbArticulo.ValueMember = "idarticulo";
                cbArticulo.DisplayMember = "Nombre";
                cbArticulo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message);
            }
        }

        private void MostrarDetalle(int ventaID)
        {
            dataListadoDetalle.DataSource = NVenta.MostrarDetalle(ventaID);
        }

        // Métodos para gestión de artículos
        private void BuscarArticulos()
        {
            try
            {
                if (txtBuscarArticulo.Text.Length >= 2)
                {
                    DataTable dtArticulos = NArticulo.BuscarNombre(txtBuscarArticulo.Text);
                    dataListadoArticulos.DataSource = dtArticulos;
                    dataListadoArticulos.Visible = true;
                }
                else
                {
                    dataListadoArticulos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al buscar artículos: " + ex.Message);
            }
        }

        private void AgregarArticuloDetalle()
        {
            try
            {
                if (cbArticulo.SelectedIndex == -1)
                {
                    MensajeError("Seleccione un artículo");
                    return;
                }

                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
                {
                    MensajeError("Ingrese una cantidad válida");
                    return;
                }

                if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precio) || precio <= 0)
                {
                    MensajeError("Ingrese un precio válido");
                    return;
                }

                int idarticulo = Convert.ToInt32(cbArticulo.SelectedValue);
                string codigo = ObtenerValorArticulo("Codigo");
                string nombre = cbArticulo.Text;
                decimal subtotal = cantidad * precio;

                // Verificar si el artículo ya está en el detalle
                DataRow[] filasExistentes = dtDetalleVenta.Select($"idarticulo = {idarticulo}");
                if (filasExistentes.Length > 0)
                {
                    filasExistentes[0]["Cantidad"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) + cantidad;
                    filasExistentes[0]["Subtotal"] = Convert.ToDecimal(filasExistentes[0]["Subtotal"]) + subtotal;
                }
                else
                {
                    DataRow nuevaFila = dtDetalleVenta.NewRow();
                    nuevaFila["idarticulo"] = idarticulo;
                    nuevaFila["Codigo"] = codigo;
                    nuevaFila["Nombre"] = nombre;
                    nuevaFila["PrecioVenta"] = precio;
                    nuevaFila["Cantidad"] = cantidad;
                    nuevaFila["Subtotal"] = subtotal;
                    dtDetalleVenta.Rows.Add(nuevaFila);
                }

                CalcularTotalesVenta();
                LimpiarControlesArticulo();
            }
            catch (Exception ex)
            {
                MensajeError("Error al agregar artículo: " + ex.Message);
            }
        }

        private string ObtenerValorArticulo(string columna)
        {
            try
            {
                if (cbArticulo.SelectedItem != null && cbArticulo.SelectedValue != null)
                {
                    DataRowView drv = (DataRowView)cbArticulo.SelectedItem;
                    return drv[columna]?.ToString() ?? "";
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        private void CalcularTotalesVenta()
        {
            try
            {
                decimal subtotal = 0;

                foreach (DataRow row in dtDetalleVenta.Rows)
                {
                    subtotal += Convert.ToDecimal(row["Subtotal"]);
                }

                txtSubtotal.Text = subtotal.ToString("F2");

                // Calcular impuestos (21% IVA)
                decimal impuestos = subtotal * 0.21m;
                txtImpuestos.Text = impuestos.ToString("F2");

                // Calcular total
                decimal total = subtotal + impuestos;
                txtTotal.Text = total.ToString("F2");
            }
            catch (Exception ex)
            {
                MensajeError("Error al calcular totales: " + ex.Message);
            }
        }

        private void LimpiarControlesArticulo()
        {
            try
            {
                cbArticulo.SelectedIndex = -1;
                txtCantidad.Text = "1";
                txtPrecioVenta.Text = "0.00";
                txtBuscarArticulo.Text = "";
                dataListadoArticulos.DataSource = null;
                dataListadoArticulos.Visible = false;
            }
            catch (Exception ex)
            {
                MensajeError("Error al limpiar controles de artículo: " + ex.Message);
            }
        }

        private void QuitarArticuloDetalle()
        {
            try
            {
                if (dataListadoDetalle.CurrentRow != null && dataListadoDetalle.CurrentRow.Index >= 0)
                {
                    int index = dataListadoDetalle.CurrentRow.Index;
                    dtDetalleVenta.Rows.RemoveAt(index);
                    CalcularTotalesVenta();
                }
                else
                {
                    MensajeError("Seleccione un artículo del detalle para quitar");
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al quitar artículo: " + ex.Message);
            }
        }

        // Eventos para gestión de artículos
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            AgregarArticuloDetalle();
        }

        private void btnQuitarArticulo_Click(object sender, EventArgs e)
        {
            QuitarArticuloDetalle();
        }

        private void txtBuscarArticulo_TextChanged(object sender, EventArgs e)
        {
            BuscarArticulos();
        }

        private void cbArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbArticulo.SelectedIndex != -1)
                {
                    string precio = ObtenerValorArticulo("PrecioVenta");
                    if (!string.IsNullOrEmpty(precio) && decimal.TryParse(precio, out decimal precioDecimal))
                    {
                        txtPrecioVenta.Text = precioDecimal.ToString("F2");
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al cargar precio: " + ex.Message);
            }
        }

        private void dataListadoArticulos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoArticulos.CurrentRow != null && dataListadoArticulos.CurrentRow.Index >= 0)
                {
                    int idarticulo = Convert.ToInt32(dataListadoArticulos.CurrentRow.Cells["idarticulo"].Value);

                    // Buscar y seleccionar el artículo en el ComboBox
                    foreach (DataRowView item in cbArticulo.Items)
                    {
                        if (Convert.ToInt32(item["idarticulo"]) == idarticulo)
                        {
                            cbArticulo.SelectedValue = idarticulo;
                            break;
                        }
                    }

                    // Ocultar el listado de búsqueda
                    dataListadoArticulos.Visible = false;

                    // Enfocar la cantidad
                    txtCantidad.Focus();
                    txtCantidad.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al seleccionar artículo: " + ex.Message);
            }
        }

        // Eventos principales
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea anular la venta seleccionada?",
                    "Sistema Campo Argentino", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se anuló correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtVentaID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtNumeroDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NumeroDocumento"].Value);

            string clienteNombre = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            foreach (DataRowView item in cbCliente.Items)
            {
                if (item["Nombre"].ToString() == clienteNombre)
                {
                    cbCliente.SelectedValue = item["idcliente"];
                    break;
                }
            }

            this.dtpFechaVenta.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaVenta"].Value);
            this.txtSubtotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Subtotal"].Value);
            this.txtImpuestos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuestos"].Value);
            this.txtTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.txtObservaciones.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observaciones"].Value);

            MostrarDetalle(Convert.ToInt32(this.txtVentaID.Text));

            // Cuando se edita una venta existente, no permitir cambiar el número de documento
            this.txtNumeroDocumento.ReadOnly = true;

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);

            // Obtener el siguiente número de documento automáticamente
            GenerarSiguienteNumeroDocumento();

            this.txtNumeroDocumento.Focus();
        }

        private void ConfigurarColumnaSeleccion()
        {
            LimpiarColumnasAntiguas();



            // Crear columna de botón para selección
            DataGridViewButtonColumn btnSeleccionarCol = new DataGridViewButtonColumn();
            btnSeleccionarCol.Name = "Seleccionar";
            btnSeleccionarCol.HeaderText = "Sel.";
            btnSeleccionarCol.Text = "⬜"; // Cuadrado vacío (no seleccionado)
            btnSeleccionarCol.UseColumnTextForButtonValue = true;
            btnSeleccionarCol.Width = 80;
            btnSeleccionarCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnSeleccionarCol.DefaultCellStyle.Font = new Font("Arial", 12);
            btnSeleccionarCol.FlatStyle = FlatStyle.Flat;


            // Inserta la columna al principio

            dataListado.Columns.Insert(0, btnSeleccionarCol);


            // Asegura de que la columna esté visible
            dataListado.Columns["Seleccionar"].Visible = true;

            // Inicializa el estado de selección de todas las filas
            foreach (DataGridViewRow row in dataListado.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Por defecto, no seleccionado
                    row.Cells["Seleccionar"].Value = "⬜";
                    row.Cells["Seleccionar"].Tag = false; // Usa Tag para almacenar estado
                    row.DefaultCellStyle.BackColor = Color.White; // Fondo blanco por defecto
                }
            }
        }

        private void LimpiarColumnasAntiguas()
        {
            // Eliminar la columna "Eliminar" si existe
            if (dataListado.Columns.Contains("Eliminar"))
            {
                dataListado.Columns.Remove("Eliminar");
            }

            // También eliminar cualquier columna de checkbox existente
            foreach (DataGridViewColumn col in dataListado.Columns)
            {
                if (col is DataGridViewCheckBoxColumn)
                {
                    dataListado.Columns.Remove(col);
                    break;
                }
            }
        }



        private void GenerarSiguienteNumeroDocumento()
        {
            try
            {
                string proximoNumero = NVenta.ObtenerProximoNumeroDocumento();
                this.txtNumeroDocumento.Text = proximoNumero;

                // Seleccionar solo la parte numérica para facilitar edición
                if (proximoNumero.StartsWith("VTA-") && proximoNumero.Length > 4)
                {
                    this.txtNumeroDocumento.Select(4, proximoNumero.Length - 4);
                }
            }
            catch (Exception ex)
            {
                // En caso de error, usar un número secuencial simple
                MensajeError("Error al generar número de documento: " + ex.Message);
                this.txtNumeroDocumento.Text = $"VTA-{DateTime.Now:MMddHHmm}";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                // Validaciones
                if (string.IsNullOrEmpty(this.txtNumeroDocumento.Text) || cbCliente.SelectedIndex == -1)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNumeroDocumento, "Ingrese un valor");
                    errorIcono.SetError(cbCliente, "Seleccione un cliente");
                    return;
                }

                // Validar formato del número de documento
                if (!this.txtNumeroDocumento.Text.StartsWith("VTA-"))
                {
                    MensajeError("El número de documento debe tener el formato VTA-XXXX");
                    errorIcono.SetError(txtNumeroDocumento, "Formato inválido. Use VTA-XXXX");
                    return;
                }

                // Validar que el número tenga formato correcto
                string numeroParte = this.txtNumeroDocumento.Text.Substring(4);
                if (!int.TryParse(numeroParte, out int numero) || numero <= 0)
                {
                    MensajeError("El número de documento debe tener un formato válido (VTA-0001, VTA-0002, etc.)");
                    errorIcono.SetError(txtNumeroDocumento, "Número inválido. Use formato VTA-0001");
                    return;
                }

                if (dtDetalleVenta.Rows.Count == 0)
                {
                    MensajeError("Debe agregar al menos un artículo a la venta");
                    return;
                }

                if (this.IsNuevo)
                {
                    rpta = NVenta.InsertarVentaCompleta(
                        this.txtNumeroDocumento.Text.Trim(),
                        Convert.ToInt32(cbCliente.SelectedValue),
                        this.dtpFechaVenta.Value,
                        Convert.ToDecimal(this.txtSubtotal.Text),
                        Convert.ToDecimal(this.txtImpuestos.Text),
                        Convert.ToDecimal(this.txtTotal.Text),
                        this.txtObservaciones.Text.Trim(),
                        IdusuarioActual,
                        dtDetalleVenta
                    );

                    if (rpta == "OK")
                    {
                        this.MensajeOk("Venta registrada correctamente");
                        this.IsNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.Mostrar();
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}\nDetalle: {ex.StackTrace}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Configurar CultureInfo para Argentina antes de generar el PDF
                ConfigurarCultureInfoArgentina();

                if (dataListado.Rows.Count == 0)
                {
                    MensajeError("No hay ventas para generar el reporte");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFVentas(saveFileDialog.FileName);

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

        private void GenerarPDFVentas(string filePath)
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

                // Título de la empresa
                iText.Paragraph titulo = new iText.Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = iText.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                iText.Paragraph subtitulo = new iText.Paragraph("REPORTE DE VENTAS", fontSubtitulo);
                subtitulo.Alignment = iText.Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // ===== INFORMACIÓN DEL REPORTE =====
                iTextPdf.PdfPTable tablaInfo = new iTextPdf.PdfPTable(4);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas de ventas
                decimal totalVentas = 0;
                decimal totalImpuestos = 0;
                decimal totalSubtotal = 0;
                int ventasActivas = 0;
                int totalVentasCount = 0;

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        totalVentasCount++;
                        if (row.Cells["Total"].Value != null && row.Cells["Total"].Value != DBNull.Value)
                            totalVentas += Convert.ToDecimal(row.Cells["Total"].Value);

                        if (row.Cells["Impuestos"].Value != null && row.Cells["Impuestos"].Value != DBNull.Value)
                            totalImpuestos += Convert.ToDecimal(row.Cells["Impuestos"].Value);

                        if (row.Cells["Subtotal"].Value != null && row.Cells["Subtotal"].Value != DBNull.Value)
                            totalSubtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);

                        ventasActivas++;
                    }
                }

                // Formatear montos con formato argentino
                string totalVentasFormateado = totalVentas.ToString("C2", culturaArgentina);
                string totalImpuestosFormateado = totalImpuestos.ToString("C2", culturaArgentina);
                string totalSubtotalFormateado = totalSubtotal.ToString("C2", culturaArgentina);

                AgregarCeldaTabla(tablaInfo, "Fecha generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Período:", $"{dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}", fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total ventas:", totalVentasCount.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Ventas activas:", ventasActivas.ToString(), fontNormal);

                AgregarCeldaTabla(tablaInfo, "Subtotal:", totalSubtotalFormateado, fontMonto);
                AgregarCeldaTabla(tablaInfo, "Impuestos:", totalImpuestosFormateado, fontMonto);
                AgregarCeldaTabla(tablaInfo, "TOTAL VENTAS:", totalVentasFormateado, fontMonto);
                AgregarCeldaTabla(tablaInfo, "", "", fontNormal);

                document.Add(tablaInfo);

                // ===== TABLA PRINCIPAL DE VENTAS =====
                if (totalVentasCount > 0)
                {
                    List<string> columnasVentas = new List<string>();
                    string[] columnasRecomendadas = { "NumeroDocumento", "Cliente", "FechaVenta", "Subtotal", "Impuestos", "Total" };

                    foreach (string columna in columnasRecomendadas)
                    {
                        if (dataListado.Columns.Contains(columna))
                            columnasVentas.Add(columna);
                    }

                    iTextPdf.PdfPTable tablaVentas = new iTextPdf.PdfPTable(columnasVentas.Count);
                    tablaVentas.WidthPercentage = 100;
                    tablaVentas.SpacingBefore = 10f;
                    tablaVentas.SpacingAfter = 20f;

                    // Configurar anchos de columnas
                    float[] anchos = new float[columnasVentas.Count];
                    for (int i = 0; i < columnasVentas.Count; i++)
                    {
                        switch (columnasVentas[i])
                        {
                            case "NumeroDocumento": anchos[i] = 15f; break;
                            case "FechaVenta": anchos[i] = 12f; break;
                            case "Subtotal": anchos[i] = 14f; break;
                            case "Impuestos": anchos[i] = 14f; break;
                            case "Total": anchos[i] = 14f; break;
                            case "Cliente": anchos[i] = 31f; break;
                            default: anchos[i] = 15f; break;
                        }
                    }
                    tablaVentas.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasVentas)
                    {
                        string headerText = ObtenerHeaderVentas(columna);
                        iTextPdf.PdfPCell celdaHeader = new iTextPdf.PdfPCell(new iText.Phrase(headerText, fontHeader));
                        celdaHeader.BackgroundColor = new iText.BaseColor(70, 130, 180); // Azul
                        celdaHeader.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                        celdaHeader.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                        celdaHeader.Padding = 5;
                        celdaHeader.PaddingTop = 6;
                        tablaVentas.AddCell(celdaHeader);
                    }

                    // Datos de las ventas
                    foreach (DataGridViewRow fila in dataListado.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (string columna in columnasVentas)
                            {
                                string valor = fila.Cells[columna].Value?.ToString() ?? "";
                                iText.Phrase frase;

                                // Formatear valores numéricos con formato argentino
                                if (columna == "Subtotal" || columna == "Impuestos" || columna == "Total")
                                {
                                    if (decimal.TryParse(valor, out decimal valorDecimal))
                                    {
                                        valor = valorDecimal.ToString("C2", culturaArgentina);
                                        frase = new iText.Phrase(valor, fontMonto);
                                    }
                                    else
                                    {
                                        frase = new iText.Phrase(valor, fontData);
                                    }
                                }
                                // Formatear fecha
                                else if (columna == "FechaVenta")
                                {
                                    if (DateTime.TryParse(valor, out DateTime fecha))
                                    {
                                        valor = fecha.ToString("dd/MM/yyyy");
                                    }
                                    frase = new iText.Phrase(valor, fontData);
                                }
                                else
                                {
                                    frase = new iText.Phrase(valor, fontData);
                                }

                                iTextPdf.PdfPCell celdaData = new iTextPdf.PdfPCell(frase);

                                // Alineación según el tipo de dato
                                if (columna == "Subtotal" || columna == "Impuestos" || columna == "Total" ||
                                    columna == "FechaVenta" || columna == "NumeroDocumento")
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
                                tablaVentas.AddCell(celdaData);
                            }
                        }
                    }

                    document.Add(tablaVentas);
                }

                // ===== RESUMEN FINAL =====
                iTextPdf.PdfPTable tablaResumen = new iTextPdf.PdfPTable(2);
                tablaResumen.WidthPercentage = 50;
                tablaResumen.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                tablaResumen.SpacingBefore = 10f;

                AgregarCeldaTablaResumen(tablaResumen, "SUB-TOTAL:", totalSubtotal.ToString("C2", culturaArgentina), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "IMPUESTOS:", totalImpuestos.ToString("C2", culturaArgentina), fontNormal, fontMonto);

                iTextPdf.PdfPCell celdaTotalLabel = new iTextPdf.PdfPCell(new iText.Phrase("TOTAL GENERAL:", fontMonto));
                celdaTotalLabel.Border = iTextPdf.PdfPCell.NO_BORDER;
                celdaTotalLabel.Padding = 5;
                celdaTotalLabel.BackgroundColor = new iText.BaseColor(240, 240, 240);
                tablaResumen.AddCell(celdaTotalLabel);

                iTextPdf.PdfPCell celdaTotalValor = new iTextPdf.PdfPCell(new iText.Phrase(totalVentas.ToString("C2", culturaArgentina), fontMonto));
                celdaTotalValor.Border = iTextPdf.PdfPCell.NO_BORDER;
                celdaTotalValor.Padding = 5;
                celdaTotalValor.BackgroundColor = new iText.BaseColor(240, 240, 240);
                celdaTotalValor.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                tablaResumen.AddCell(celdaTotalValor);

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
                throw new Exception("Error al generar PDF de ventas: " + ex.Message);
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
                default: return headerOriginal.ToUpper();
            }
        }

        // Métodos adicionales
        private void ConfigurarBotonFactura()
        {
            btnFactura.Enabled = false;
            btnFactura.BackColor = Color.LightGray;
            ttMensaje.SetToolTip(btnFactura, "Módulo de facturación en desarrollo - Disponible en próximas versiones");
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "El módulo de facturación oficial está en desarrollo.\n\n" +
                "Estará disponible en la próxima actualización del sistema.",
                "Función en Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtImpuestos_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            try
            {
                decimal subtotal = string.IsNullOrEmpty(txtSubtotal.Text) ? 0 : Convert.ToDecimal(txtSubtotal.Text);
                decimal impuestos = string.IsNullOrEmpty(txtImpuestos.Text) ? 0 : Convert.ToDecimal(txtImpuestos.Text);
                decimal total = subtotal + impuestos;
                txtTotal.Text = total.ToString("F2");
            }
            catch
            {
                txtTotal.Text = "0.00";
            }
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void panelAgregarArticulo_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}