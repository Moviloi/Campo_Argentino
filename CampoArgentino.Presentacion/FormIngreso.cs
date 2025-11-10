using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using CampoArgentino.Negocio;
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;
using SystemFont = System.Drawing.Font;

namespace CampoArgentino.Presentacion
{
    public partial class FormIngreso : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        public FormIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNumeroDocumento, "Ingrese el número de documento");
            this.ttMensaje.SetToolTip(this.cbProveedor, "Seleccione un proveedor");
            this.ttMensaje.SetToolTip(this.dtpFechaCompra, "Seleccione la fecha de compra");
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CargarProveedores();
            this.LlenarComboArticulo();
            this.InicializarDetalleIngreso();
            this.dtpFechaCompra.Value = DateTime.Now;
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
            this.txtCompraID.Text = string.Empty;
            this.txtNumeroDocumento.Text = string.Empty;
            this.cbProveedor.SelectedIndex = -1;
            this.dtpFechaCompra.Value = DateTime.Now;
            this.txtSubtotal.Text = "0.00";
            this.txtImpuestos.Text = "0.00";
            this.txtTotal.Text = "0.00";
            this.txtObservaciones.Text = string.Empty;

            dtDetalleIngreso.Clear();
            LimpiarControlesArticulo();
        }

        private void Habilitar(bool valor)
        {
            this.txtNumeroDocumento.ReadOnly = !valor;
            this.cbProveedor.Enabled = valor;
            this.dtpFechaCompra.Enabled = valor;
            this.txtObservaciones.ReadOnly = !valor;

            panelAgregarArticulo.Visible = valor;
            btnAgregarArticulo.Enabled = valor;
            btnQuitarArticulo.Enabled = valor;
            cbArticulo.Enabled = valor;
            txtCantidad.ReadOnly = !valor;
            txtPrecioCompra.ReadOnly = !valor;
            txtBuscarArticulo.ReadOnly = !valor;
            dataListadoArticulos.Enabled = valor;

            dataListadoArticulos.Visible = !string.IsNullOrEmpty(txtBuscarArticulo.Text);
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
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
            // Ocultar solo la columna idproveedor, mostrar Estado
            if (this.dataListado.Columns.Contains("idproveedor"))
            {
                this.dataListado.Columns["idproveedor"].Visible = false;
            }

            // Ocultar otras columnas ID si existen
            string[] otrasColumnasOcultar = { "idingreso", "idcompra", "CompraID" };
            foreach (string columna in otrasColumnasOcultar)
            {
                if (this.dataListado.Columns.Contains(columna))
                {
                    this.dataListado.Columns[columna].Visible = false;
                }
            }

            // Asegurar que Estado sea visible y tenga buen formato
            if (this.dataListado.Columns.Contains("Estado"))
            {
                this.dataListado.Columns["Estado"].Visible = true;
                this.dataListado.Columns["Estado"].HeaderText = "ESTADO";
                this.dataListado.Columns["Estado"].Width = 100;
                this.dataListado.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();

            // Configurar columna de selección
            ConfigurarColumnaSeleccion();

            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void ConfigurarColumnaSeleccion()
        {
            // Limpiar columnas antiguas primero
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

                // Insertar la columna al principio
                dataListado.Columns.Insert(0, btnSeleccionarCol);
      
            // Asegurarse de que la columna esté visible
            dataListado.Columns["Seleccionar"].Visible = true;

            // Inicializar el estado de selección de todas las filas
            foreach (DataGridViewRow row in dataListado.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Por defecto, no seleccionado
                    row.Cells["Seleccionar"].Value = "⬜";
                    row.Cells["Seleccionar"].Tag = false;
                    row.DefaultCellStyle.BackColor = Color.White;
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

        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(
                this.dtpFechaInicio.Value.ToString("yyyy-MM-dd"),
                this.dtpFechaFin.Value.ToString("yyyy-MM-dd")
            );

            // Reconfigurar columna de selección después de buscar
            ConfigurarColumnaSeleccion();

            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void CargarProveedores()
        {
            try
            {
                DataTable dtProveedores = NProveedor.Mostrar();
                cbProveedor.DataSource = dtProveedores;
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "idproveedor";
                cbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}");
            }
        }

        // Eventos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                // Contar cuántos están seleccionados
                int cantidadSeleccionados = 0;
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Seleccionar"].Tag != null && (bool)row.Cells["Seleccionar"].Tag)
                    {
                        cantidadSeleccionados++;
                    }
                }

                if (cantidadSeleccionados == 0)
                {
                    MensajeError("No hay ingresos seleccionados para anular");
                    return;
                }

                DialogResult Opcion = MessageBox.Show(
                    $"¿Realmente desea anular los {cantidadSeleccionados} ingresos seleccionados?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Anulación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    int anuladosExitosos = 0;
                    int errores = 0;
                    System.Text.StringBuilder erroresDetallados = new System.Text.StringBuilder();

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["Seleccionar"].Tag != null && (bool)row.Cells["Seleccionar"].Tag)
                        {
                            // Buscar la columna ID por diferentes nombres posibles
                            string idColumnName = "";
                            string[] posiblesNombresID = { "idingreso", "idcompra", "CompraID", "ID" };

                            foreach (string nombre in posiblesNombresID)
                            {
                                if (dataListado.Columns.Contains(nombre))
                                {
                                    idColumnName = nombre;
                                    break;
                                }
                            }

                            if (string.IsNullOrEmpty(idColumnName))
                            {
                                idColumnName = dataListado.Columns[1].Name; // Segunda columna después de Seleccionar
                            }

                            int idingreso = Convert.ToInt32(row.Cells[idColumnName].Value);
                            string numeroDocumento = row.Cells["NumeroDocumento"]?.Value?.ToString() ?? "Sin número";

                            Rpta = NIngreso.Anular(idingreso);

                            if (Rpta.Equals("OK"))
                            {
                                anuladosExitosos++;
                            }
                            else
                            {
                                errores++;
                                if (erroresDetallados.Length < 200)
                                {
                                    erroresDetallados.AppendLine($"Documento {numeroDocumento}: {Rpta}");
                                }
                            }
                        }
                    }

                    // Mostrar resumen
                    if (errores == 0)
                    {
                        MensajeOk($"Se anularon correctamente {anuladosExitosos} ingresos");
                    }
                    else
                    {
                        string mensajeError = $"Proceso completado: {anuladosExitosos} anulados, {errores} errores";
                        if (erroresDetallados.Length > 0)
                        {
                            mensajeError += "\n\nErrores:\n" + erroresDetallados.ToString();
                        }
                        MensajeError(mensajeError);
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error inesperado al anular: {ex.Message}");
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna "Seleccionar"
            if (e.RowIndex >= 0 && e.ColumnIndex == dataListado.Columns["Seleccionar"].Index)
            {
                DataGridViewRow row = dataListado.Rows[e.RowIndex];
                bool estaSeleccionado = false;

                // Obtener el estado actual del Tag
                if (row.Cells["Seleccionar"].Tag != null)
                {
                    estaSeleccionado = (bool)row.Cells["Seleccionar"].Tag;
                }

                // Cambiar el estado
                estaSeleccionado = !estaSeleccionado;

                // Actualizar el texto del botón y el Tag
                if (estaSeleccionado)
                {
                    row.Cells["Seleccionar"].Value = "✅"; // Checkbox marcado
                    row.Cells["Seleccionar"].Tag = true;
                    row.DefaultCellStyle.BackColor = Color.DimGray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.Cells["Seleccionar"].Value = "⬜"; // Checkbox vacío
                    row.Cells["Seleccionar"].Tag = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                // Forzar el repintado de la fila
                dataListado.InvalidateRow(e.RowIndex);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("=== COLUMNAS EN DATAGRIDVIEW ===");
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    Debug.WriteLine($"'{col.Name}' -> '{col.HeaderText}'");
                }

                // Cargar ID del ingreso
                string idColumnName = "";
                string[] posiblesNombresID = { "idingreso", "idcompra", "CompraID", "ID" };

                foreach (string nombre in posiblesNombresID)
                {
                    if (dataListado.Columns.Contains(nombre))
                    {
                        idColumnName = nombre;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(idColumnName))
                {
                    idColumnName = dataListado.Columns[1].Name; // Segunda columna después de Seleccionar
                }

                this.txtCompraID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells[idColumnName].Value);

                // Cargar número de documento
                if (dataListado.Columns.Contains("NumeroDocumento"))
                {
                    this.txtNumeroDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NumeroDocumento"].Value);
                }

                // Cargar proveedor por nombre
                if (dataListado.Columns.Contains("Proveedor") &&
                    this.dataListado.CurrentRow.Cells["Proveedor"].Value != null)
                {
                    string proveedorNombre = Convert.ToString(this.dataListado.CurrentRow.Cells["Proveedor"].Value);

                    for (int i = 0; i < cbProveedor.Items.Count; i++)
                    {
                        if (cbProveedor.GetItemText(cbProveedor.Items[i]).Trim().ToUpper() == proveedorNombre.Trim().ToUpper())
                        {
                            cbProveedor.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // Cargar fecha de compra 
                if (dataListado.Columns.Contains("FechaCompra") &&
                    this.dataListado.CurrentRow.Cells["FechaCompra"].Value != null)
                {
                    DateTime fechaCompra = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaCompra"].Value);
                    dtpFechaCompra.Value = fechaCompra;
                }

                // Cargar montos
                if (dataListado.Columns.Contains("Subtotal"))
                {
                    this.txtSubtotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Subtotal"].Value);
                }
                if (dataListado.Columns.Contains("Impuestos"))
                {
                    this.txtImpuestos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuestos"].Value);
                }
                if (dataListado.Columns.Contains("Total"))
                {
                    this.txtTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
                }

                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.InicializarDetalleIngreso();
            this.txtNumeroDocumento.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNumeroDocumento.Text == string.Empty ||
                    this.cbProveedor.SelectedIndex == -1)
                {
                    MensajeError("Falta ingresar algunos datos obligatorios");
                    errorIcono.SetError(txtNumeroDocumento, "Ingrese un valor");
                    errorIcono.SetError(cbProveedor, "Seleccione un proveedor");
                    return;
                }

                // Validar que haya artículos en el detalle
                if (dtDetalleIngreso.Rows.Count == 0)
                {
                    MensajeError("Debe agregar al menos un artículo al ingreso");
                    return;
                }

                decimal subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
                decimal impuestos = Convert.ToDecimal(this.txtImpuestos.Text);
                decimal total = Convert.ToDecimal(this.txtTotal.Text);

                if (this.IsNuevo)
                {
                    rpta = NIngreso.InsertarIngresoCompleto(
                        this.txtNumeroDocumento.Text.Trim(),
                        Convert.ToInt32(this.cbProveedor.SelectedValue),
                        this.dtpFechaCompra.Value,
                        subtotal,
                        impuestos,
                        total,
                        this.txtObservaciones.Text.Trim(),
                        1, // idusuario temporal
                        dtDetalleIngreso
                    );

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }
                else
                {
                    MensajeError("Funcionalidad de edición no implementada");
                    return;
                }

                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MensajeError($"Error al guardar el ingreso: {ex.Message}");
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


        private void InicializarDetalleIngreso()
        {
            dtDetalleIngreso = new DataTable();
            dtDetalleIngreso.Columns.Add("idarticulo", typeof(int));
            dtDetalleIngreso.Columns.Add("Codigo", typeof(string));
            dtDetalleIngreso.Columns.Add("Nombre", typeof(string));
            dtDetalleIngreso.Columns.Add("PrecioCompra", typeof(decimal));
            dtDetalleIngreso.Columns.Add("Cantidad", typeof(decimal));
            dtDetalleIngreso.Columns.Add("Subtotal", typeof(decimal));
            dataListadoDetalle.DataSource = dtDetalleIngreso;
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

                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precio) || precio <= 0)
                {
                    MensajeError("Ingrese un precio válido");
                    return;
                }

                int idarticulo = Convert.ToInt32(cbArticulo.SelectedValue);
                string codigo = ObtenerValorArticulo("Codigo");
                string nombre = cbArticulo.Text;
                decimal subtotal = cantidad * precio;

                DataRow[] filasExistentes = dtDetalleIngreso.Select($"idarticulo = {idarticulo}");
                if (filasExistentes.Length > 0)
                {
                    filasExistentes[0]["Cantidad"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) + cantidad;
                    filasExistentes[0]["Subtotal"] = Convert.ToDecimal(filasExistentes[0]["Subtotal"]) + subtotal;
                }
                else
                {
                    DataRow nuevaFila = dtDetalleIngreso.NewRow();
                    nuevaFila["idarticulo"] = idarticulo;
                    nuevaFila["Codigo"] = codigo;
                    nuevaFila["Nombre"] = nombre;
                    nuevaFila["PrecioCompra"] = precio;
                    nuevaFila["Cantidad"] = cantidad;
                    nuevaFila["Subtotal"] = subtotal;
                    dtDetalleIngreso.Rows.Add(nuevaFila);
                }

                CalcularTotalesIngreso();
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

        private void CalcularTotalesIngreso()
        {
            try
            {
                decimal subtotal = 0;
                foreach (DataRow row in dtDetalleIngreso.Rows)
                {
                    subtotal += Convert.ToDecimal(row["Subtotal"]);
                }

                txtSubtotal.Text = subtotal.ToString("F2");

                decimal impuestos = subtotal * 0.21m;
                txtImpuestos.Text = impuestos.ToString("F2");

                decimal total = subtotal + impuestos;
                txtTotal.Text = total.ToString("F2");
            }
            catch (Exception ex)
            {
                MensajeError("Error al calcular totales: " + ex.Message);
            }
        }

        private void QuitarArticuloDetalle()
        {
            try
            {
                if (dataListadoDetalle.CurrentRow != null && dataListadoDetalle.CurrentRow.Index >= 0)
                {
                    int index = dataListadoDetalle.CurrentRow.Index;
                    dtDetalleIngreso.Rows.RemoveAt(index);
                    CalcularTotalesIngreso();
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

        private void LimpiarControlesArticulo()
        {
            try
            {
                cbArticulo.SelectedIndex = -1;
                txtCantidad.Text = "1";
                txtPrecioCompra.Text = "0.00";
                txtBuscarArticulo.Text = "";
                dataListadoArticulos.DataSource = null;
                dataListadoArticulos.Visible = false;
            }
            catch (Exception ex)
            {
                MensajeError("Error al limpiar controles de artículo: " + ex.Message);
            }
        }

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
                    string precio = ObtenerValorArticulo("PrecioCompra");
                    if (!string.IsNullOrEmpty(precio) && decimal.TryParse(precio, out decimal precioDecimal))
                    {
                        txtPrecioCompra.Text = precioDecimal.ToString("F2");
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

                    foreach (DataRowView item in cbArticulo.Items)
                    {
                        if (Convert.ToInt32(item["idarticulo"]) == idarticulo)
                        {
                            cbArticulo.SelectedValue = idarticulo;
                            break;
                        }
                    }

                    dataListadoArticulos.Visible = false;
                    txtCantidad.Focus();
                    txtCantidad.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al seleccionar artículo: " + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // CultureInfo para Argentina
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentCulture = culturaArgentina;
            Thread.CurrentThread.CurrentUICulture = culturaArgentina;

            try
            {
                if (dataListado.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para generar el reporte", "Sistema Campo Argentino",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_Ingresos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFIngresos(saveFileDialog.FileName);

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
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Sistema Campo Argentino",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPDFIngresos(string filePath)
        {
            // Configurar documento para impresión (A4 vertical)
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
                iText.Font fontMonto = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 8, iText.BaseColor.BLACK);

                // Título del reporte
                iText.Paragraph titulo = new iText.Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = iText.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                iText.Paragraph subtitulo = new iText.Paragraph("REPORTE DE INGRESOS / COMPRAS", fontSubtitulo);
                subtitulo.Alignment = iText.Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // ===== INFORMACIÓN DEL REPORTE =====
                iTextPdf.PdfPTable tablaInfo = new iTextPdf.PdfPTable(2);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas específicas para ingresos
                decimal totalIngresos = 0;
                decimal totalImpuestos = 0;
                decimal totalSubtotal = 0;
                int ingresosActivos = 0;
                int ingresosAnulados = 0;

                // DEBUG: Verificar columnas disponibles
                Debug.WriteLine("=== COLUMNAS DISPONIBLES EN DATA GRID ===");
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    Debug.WriteLine($"Columna: '{col.Name}' - Header: '{col.HeaderText}'");
                }

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Verificar si el ingreso está anulado - métodos alternativos
                        bool estaAnulado = false;

                        // Método 1: Buscar columna "Estado"
                        if (dataListado.Columns.Contains("Estado") && row.Cells["Estado"].Value != null)
                        {
                            string estado = row.Cells["Estado"].Value.ToString();
                            estaAnulado = estado.ToUpper().Contains("ANULADO") || estado == "False" || estado == "0";
                        }
                        // Método 2: Buscar columna "activo" o "estado" con diferentes nombres
                        else if (dataListado.Columns.Contains("activo") && row.Cells["activo"].Value != null)
                        {
                            string estado = row.Cells["activo"].Value.ToString();
                            estaAnulado = estado == "False" || estado == "0";
                        }
                        // Método 3: Si no hay columna de estado, asumir que todos están activos
                        else
                        {
                            estaAnulado = false; // Por defecto, no anulado
                        }

                        if (estaAnulado) ingresosAnulados++;
                        else ingresosActivos++;

                        // Calcular totales - con verificaciones seguras
                        if (dataListado.Columns.Contains("Total") &&
                            row.Cells["Total"].Value != null &&
                            row.Cells["Total"].Value != DBNull.Value)
                        {
                            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                            totalIngresos += total;
                        }

                        if (dataListado.Columns.Contains("Subtotal") &&
                            row.Cells["Subtotal"].Value != null &&
                            row.Cells["Subtotal"].Value != DBNull.Value)
                        {
                            decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                            totalSubtotal += subtotal;
                        }

                        if (dataListado.Columns.Contains("Impuestos") &&
                            row.Cells["Impuestos"].Value != null &&
                            row.Cells["Impuestos"].Value != DBNull.Value)
                        {
                            decimal impuestos = Convert.ToDecimal(row.Cells["Impuestos"].Value);
                            totalImpuestos += impuestos;
                        }
                    }
                }

                // Información del período si se filtró por fechas
                string periodo = "Todos los registros";
                if (dtpFechaInicio.Value != DateTime.MinValue && dtpFechaFin.Value != DateTime.MaxValue)
                {
                    periodo = $"Del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}";
                }

                AgregarCeldaTabla(tablaInfo, "Fecha de generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Período del reporte:", periodo, fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total de ingresos:", dataListado.Rows.Count.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Ingresos activos:", ingresosActivos.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Ingresos anulados:", ingresosAnulados.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Subtotal acumulado:", totalSubtotal.ToString("C2"), fontMonto);
                AgregarCeldaTabla(tablaInfo, "Impuestos acumulados:", totalImpuestos.ToString("C2"), fontMonto);
                AgregarCeldaTabla(tablaInfo, "TOTAL GENERAL:", totalIngresos.ToString("C2"), fontMonto);

                document.Add(tablaInfo);

                // ===== TABLA PRINCIPAL DE INGRESOS =====
                if (dataListado.Rows.Count > 0)
                {
                    // Columnas disponibles en tu DataGridView - ajusta según lo que veas en el DEBUG
                    List<string> columnasDisponibles = new List<string>();

                    // Verificar qué columnas están disponibles y son relevantes
                    string[] columnasPosibles = {
                "NumeroDocumento", "numerodocumento", "Documento",
                "Proveedor", "proveedor",
                "FechaCompra", "fechacompra", "Fecha",
                "Subtotal", "subtotal",
                "Impuestos", "impuestos",
                "Total", "total",
                "Estado", "estado", "Activo", "activo"
            };

                    foreach (string columna in columnasPosibles)
                    {
                        if (dataListado.Columns.Contains(columna) && !columnasDisponibles.Contains(ObtenerHeaderLegibleIngresos(columna)))
                        {
                            columnasDisponibles.Add(columna);
                        }
                    }

                    // Si no encontramos columnas, usar las primeras disponibles
                    if (columnasDisponibles.Count == 0)
                    {
                        for (int i = 0; i < Math.Min(6, dataListado.Columns.Count); i++)
                        {
                            columnasDisponibles.Add(dataListado.Columns[i].Name);
                        }
                    }

                    iTextPdf.PdfPTable tablaDatos = new iTextPdf.PdfPTable(columnasDisponibles.Count);
                    tablaDatos.WidthPercentage = 100;
                    tablaDatos.SpacingBefore = 10f;
                    tablaDatos.SpacingAfter = 20f;

                    // Configurar anchos de columnas
                    float[] anchos = new float[columnasDisponibles.Count];
                    for (int i = 0; i < columnasDisponibles.Count; i++)
                    {
                        string columna = columnasDisponibles[i].ToLower();
                        if (columna.Contains("documento")) anchos[i] = 15f;
                        else if (columna.Contains("proveedor")) anchos[i] = 25f;
                        else if (columna.Contains("fecha")) anchos[i] = 12f;
                        else if (columna.Contains("subtotal") || columna.Contains("impuesto") || columna.Contains("total")) anchos[i] = 12f;
                        else if (columna.Contains("estado") || columna.Contains("activo")) anchos[i] = 10f;
                        else anchos[i] = 15f;
                    }
                    tablaDatos.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasDisponibles)
                    {
                        string headerText = ObtenerHeaderLegibleIngresos(columna);
                        iTextPdf.PdfPCell celdaHeader = new iTextPdf.PdfPCell(new iText.Phrase(headerText, fontHeader));
                        celdaHeader.BackgroundColor = new iText.BaseColor(51, 51, 51);
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

                                // Formatear valores específicos para ingresos
                                string columnaLower = columna.ToLower();
                                if ((columnaLower.Contains("subtotal") || columnaLower.Contains("impuesto") || columnaLower.Contains("total")) &&
                                    decimal.TryParse(valor, out decimal monto))
                                {
                                    valor = monto.ToString("C2");
                                }
                                else if (columnaLower.Contains("fecha") && DateTime.TryParse(valor, out DateTime fecha))
                                {
                                    valor = fecha.ToString("dd/MM/yyyy");
                                }
                                else if (columnaLower.Contains("estado") || columnaLower.Contains("activo"))
                                {
                                    valor = (valor == "True" || valor == "1" || valor.ToUpper().Contains("ACTIVO")) ? "ACTIVO" : "ANULADO";
                                }

                                iText.Phrase frase = new iText.Phrase(valor, fontData);
                                iTextPdf.PdfPCell celdaData = new iTextPdf.PdfPCell(frase);

                                // Alineación según el tipo de dato
                                if (columnaLower.Contains("fecha") || columnaLower.Contains("estado") || columnaLower.Contains("activo"))
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                                }
                                else if (columnaLower.Contains("subtotal") || columnaLower.Contains("impuesto") || columnaLower.Contains("total"))
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                                    celdaData.Phrase.Font = fontMonto;
                                }
                                else
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_LEFT;
                                }

                                celdaData.VerticalAlignment = iText.Element.ALIGN_MIDDLE;
                                celdaData.Padding = 4;
                                celdaData.PaddingTop = 5;

                                // Resaltar ingresos anulados
                                if ((columnaLower.Contains("estado") || columnaLower.Contains("activo")) && valor == "ANULADO")
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
                tablaResumen.WidthPercentage = 60;
                tablaResumen.HorizontalAlignment = iText.Element.ALIGN_RIGHT;
                tablaResumen.SpacingBefore = 10f;

                AgregarCeldaTablaResumen(tablaResumen, "SUB-TOTAL:", totalSubtotal.ToString("C2"), fontNormal, fontMonto);
                AgregarCeldaTablaResumen(tablaResumen, "IMPUESTOS:", totalImpuestos.ToString("C2"), fontNormal, fontMonto);

                iTextPdf.PdfPCell celdaTotalLabel = new iTextPdf.PdfPCell(new iText.Phrase("TOTAL GENERAL:", fontMonto));
                celdaTotalLabel.Border = iTextPdf.PdfPCell.NO_BORDER;
                celdaTotalLabel.Padding = 5;
                celdaTotalLabel.BackgroundColor = new iText.BaseColor(240, 240, 240);
                tablaResumen.AddCell(celdaTotalLabel);

                iTextPdf.PdfPCell celdaTotalValor = new iTextPdf.PdfPCell(new iText.Phrase(totalIngresos.ToString("C2"), fontMonto));
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
                throw new Exception("Error al generar PDF: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        // Métodos auxiliares específicos para FormIngreso
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

        private string ObtenerHeaderLegibleIngresos(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "NumeroDocumento": return "N° DOCUMENTO";
                case "Proveedor": return "PROVEEDOR";
                case "FechaCompra": return "FECHA COMPRA";
                case "Subtotal": return "SUB-TOTAL";
                case "Impuestos": return "IMPUESTOS";
                case "Total": return "TOTAL";
                case "Estado": return "ESTADO";
                default: return headerOriginal.ToUpper();
            }
        }
    }
}