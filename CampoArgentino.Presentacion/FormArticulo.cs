using CampoArgentino.Negocio;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;

namespace CampoArgentino.Presentacion
{
    public partial class FormArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FormArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del artículo");
            this.ttMensaje.SetToolTip(this.txtCodigo, "Ingrese el código del artículo");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripción del artículo");

        }



        private void FormArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = 0;
                this.Left = 0;

                this.CargarCombos();

                // Limpia columnas antiguas
                LimpiarColumnasAntiguas();

                this.Mostrar();
                this.Habilitar(false);
                this.Botones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.txtIdarticulo.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtStockMinimo.Text = string.Empty;
            this.txtStockMaximo.Text = string.Empty;
            this.cbCategoria.SelectedIndex = -1;
            this.cbPresentacion.SelectedIndex = -1;
        }

        private void Habilitar(bool valor)
        {
            txtCodigo.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            txtDescripcion.ReadOnly = !valor;
            txtPrecioVenta.ReadOnly = !valor;
            txtPrecioCompra.ReadOnly = !valor;
            txtStockMinimo.ReadOnly = !valor;
            txtStockMaximo.ReadOnly = !valor;
            cbCategoria.Enabled = valor;
            cbPresentacion.Enabled = valor;
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            // Ocultar columnas que no queremos mostrar en el listado
            if (this.dataListado.Columns.Contains("idarticulo"))
                this.dataListado.Columns["idarticulo"].Visible = false;

            if (this.dataListado.Columns.Contains("idcategoria"))
                this.dataListado.Columns["idcategoria"].Visible = false;

            if (this.dataListado.Columns.Contains("idpresentacion"))
                this.dataListado.Columns["idpresentacion"].Visible = false;

            if (this.dataListado.Columns.Contains("preciocompra"))
                this.dataListado.Columns["preciocompra"].Visible = false;

            if (this.dataListado.Columns.Contains("iva"))
                this.dataListado.Columns["iva"].Visible = false;

            if (this.dataListado.Columns.Contains("activo"))
                this.dataListado.Columns["activo"].Visible = false;

            if (this.dataListado.Columns.Contains("factorconversion"))
                this.dataListado.Columns["factorconversion"].Visible = false;
        }

        private void Mostrar()
        {
            try
            {
                this.dataListado.DataSource = NArticulo.Mostrar();

                // Limpia columnas antiguas
                LimpiarColumnasAntiguas();

                this.OcultarColumnas();

                // Agrega o configura columna de selección múltiple
                ConfigurarColumnaSeleccion();

                // Calcula stock total
                decimal stockTotal = 0;
                if (dataListado != null && dataListado.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (row.Cells["StockActual"] != null &&
                            row.Cells["StockActual"].Value != null &&
                            row.Cells["StockActual"].Value != DBNull.Value)
                        {
                            stockTotal += Convert.ToDecimal(row.Cells["StockActual"].Value);
                        }
                    }
                }

                if (lblTotal != null)
                {
                    lblTotal.Text = "Total Registros: " + dataListado.Rows.Count + " | Stock Total: " + stockTotal.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar artículos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CargarCombos()
        {
            try
            {
                // Cargar categorías
                DataTable dtCategorias = NCategoria.Mostrar();
                if (dtCategorias != null && dtCategorias.Rows.Count > 0)
                {
                    cbCategoria.DataSource = dtCategorias;
                    cbCategoria.DisplayMember = "nombre";
                    cbCategoria.ValueMember = "idcategoria";
                    cbCategoria.SelectedIndex = -1;
                }
                else
                {
                    cbCategoria.DataSource = null;
                    cbCategoria.Items.Clear();
                    cbCategoria.Items.Add("-- SIN CATEGORÍAS --");
                    cbCategoria.SelectedIndex = 0;
                    cbCategoria.Enabled = false;
                }

                // Cargar presentaciones
                DataTable dtPresentaciones = NPresentacion.Mostrar();
                if (dtPresentaciones != null && dtPresentaciones.Rows.Count > 0)
                {
                    cbPresentacion.DataSource = dtPresentaciones;
                    cbPresentacion.DisplayMember = "Nombre";
                    cbPresentacion.ValueMember = "idpresentacion";
                    cbPresentacion.SelectedIndex = -1;
                }
                else
                {
                    cbPresentacion.DataSource = null;
                    cbPresentacion.Items.Clear();
                    cbPresentacion.Items.Add("-- SIN PRESENTACIONES --");
                    cbPresentacion.SelectedIndex = 0;
                    cbPresentacion.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}\n\nAsegúrese de que existen categorías y presentaciones en la base de datos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        // Eventos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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
                    MensajeError("No hay artículos seleccionados para eliminar");
                    return;
                }

                DialogResult Opcion = MessageBox.Show(
                    $"¿Realmente desea eliminar los {cantidadSeleccionados} artículos seleccionados?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2); // Por defecto selecciona Cancelar

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    int eliminadosExitosos = 0;
                    int errores = 0;
                    List<string> erroresDetallados = new List<string>();

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["Seleccionar"].Tag != null && (bool)row.Cells["Seleccionar"].Tag)
                        {
                            int idarticulo = Convert.ToInt32(row.Cells["idarticulo"].Value);
                            string nombreArticulo = row.Cells["nombre"].Value?.ToString() ?? "Sin nombre";

                            Rpta = NArticulo.Eliminar(idarticulo);

                            if (Rpta.Equals("OK"))
                            {
                                eliminadosExitosos++;
                            }
                            else
                            {
                                errores++;
                                erroresDetallados.Add($"{nombreArticulo}: {Rpta}");
                            }
                        }
                    }

                    // Mostrar resumen
                    if (errores == 0)
                    {
                        MensajeOk($"Se eliminaron correctamente {eliminadosExitosos} artículos");
                    }
                    else
                    {
                        string mensajeError = $"Proceso completado: {eliminadosExitosos} eliminados, {errores} errores";
                        if (erroresDetallados.Count > 0)
                        {
                            mensajeError += "\n\nErrores:\n" + string.Join("\n", erroresDetallados.Take(5)); // Mostrar solo primeros 5 errores
                            if (erroresDetallados.Count > 5)
                            {
                                mensajeError += $"\n... y {erroresDetallados.Count - 5} más";
                            }
                        }
                        MensajeError(mensajeError);
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error inesperado al eliminar: {ex.Message}");
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
                    row.DefaultCellStyle.BackColor = Color.DimGray; // Verde oscuro
                    row.DefaultCellStyle.ForeColor = Color.White; // Texto blanco para mejor contraste
                }
                else
                {
                    row.Cells["Seleccionar"].Value = "⬜"; // Checkbox vacío
                    row.Cells["Seleccionar"].Tag = false;
                    row.DefaultCellStyle.BackColor = Color.White; // Quitar resaltado
                    row.DefaultCellStyle.ForeColor = Color.Black; // Texto negro por defecto
                }

                // Actualizar contador de seleccionados
                ActualizarContadorSeleccionados();

                // Forzar el repintado de la fila
                dataListado.InvalidateRow(e.RowIndex);
            }
        }

        private void ActualizarContadorSeleccionados()
        {
            int contador = 0;

            foreach (DataGridViewRow row in dataListado.Rows)
            {
                if (!row.IsNewRow && row.Cells["Seleccionar"].Tag != null)
                {
                    if ((bool)row.Cells["Seleccionar"].Tag)
                    {
                        contador++;
                    }
                }
            }

            // Mostrar contador
            if (lblTotal != null)
            {
                lblTotal.Text = $"Total Registros: {dataListado.Rows.Count} | Seleccionados: {contador}";
            }
        }

        
        // Botón para deseleccionar todos
        private void btnDeseleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataListado.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["Seleccionar"].Value = "⬜";
                    row.Cells["Seleccionar"].Tag = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            ActualizarContadorSeleccionados();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataListado.CurrentRow != null)
            {
                this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
                this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
                this.txtPrecioVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precioventa"].Value);

                // Stock actual
                if (this.dataListado.CurrentRow.Cells["StockActual"] != null)
                {
                    this.txtStock.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["StockActual"].Value);
                }

                // Categoría
                if (this.dataListado.CurrentRow.Cells["idcategoria"] != null &&
                    this.dataListado.CurrentRow.Cells["idcategoria"].Value != DBNull.Value)
                {
                    int idcategoria = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
                    cbCategoria.SelectedValue = idcategoria;
                }

                // Presentación
                if (this.dataListado.CurrentRow.Cells["idpresentacion"] != null &&
                    this.dataListado.CurrentRow.Cells["idpresentacion"].Value != DBNull.Value)
                {
                    int idpresentacion = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);
                    cbPresentacion.SelectedValue = idpresentacion;
                }
                else
                {
                    cbPresentacion.SelectedIndex = -1;
                }

                // Otros campos - usar controles directamente
                if (this.dataListado.CurrentRow.Cells["preciocompra"] != null &&
                    this.dataListado.CurrentRow.Cells["preciocompra"].Value != DBNull.Value)
                {
                    this.txtPrecioCompra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["preciocompra"].Value);
                }

                if (this.dataListado.CurrentRow.Cells["stockminimo"] != null &&
                    this.dataListado.CurrentRow.Cells["stockminimo"].Value != DBNull.Value)
                {
                    this.txtStockMinimo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stockminimo"].Value);
                }

                if (this.dataListado.CurrentRow.Cells["stockmaximo"] != null &&
                    this.dataListado.CurrentRow.Cells["stockmaximo"].Value != DBNull.Value)
                {
                    this.txtStockMaximo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stockmaximo"].Value);
                }

                this.tabControl1.SelectedIndex = 1;
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
            this.txtNombre.Focus();
        }

        private void btnReporte_Click_1(object sender, EventArgs e)
        {
            FormVistaArticulo_Venta frm = new FormVistaArticulo_Venta();
            frm.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposObligatorios())
                {
                    return;
                }

                // AGREGAR VALIDACIÓN DE PRECIOS ANTES DE GUARDAR
                if (!ValidarPreciosYStock())
                {
                    return;
                }

                string rpta = "";
                int idcategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                int idpresentacion = cbPresentacion.SelectedValue != null ? Convert.ToInt32(cbPresentacion.SelectedValue) : 0;
                string unidadBase = cbPresentacion.Text;

                if (this.IsNuevo)
                {
                    rpta = NArticulo.Insertar(
                        idcategoria,
                        idpresentacion,
                        this.txtCodigo.Text.Trim(),
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtDescripcion.Text.Trim(),
                        unidadBase,
                        1,
                        ObtenerStockMinimo(),
                        ObtenerStockMaximo(),
                        ObtenerPrecioCompra(),
                        Convert.ToDecimal(this.txtPrecioVenta.Text),
                        ObtenerIVA(),
                        true
                    );
                }
                else
                {
                    rpta = NArticulo.Editar(
                        Convert.ToInt32(this.txtIdarticulo.Text),
                        idcategoria,
                        idpresentacion,
                        this.txtCodigo.Text.Trim(),
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtDescripcion.Text.Trim(),
                        unidadBase,
                        1,
                        ObtenerStockMinimo(),
                        ObtenerStockMaximo(),
                        ObtenerPrecioCompra(),
                        Convert.ToDecimal(this.txtPrecioVenta.Text),
                        ObtenerIVA(),
                        true
                    );
                }

                if (rpta.Equals("OK"))
                {
                    string mensaje = this.IsNuevo ?
                        "Se insertó de forma correcta el registro" :
                        "Se actualizó de forma correcta el registro";

                    this.MensajeOk(mensaje);

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
                else
                {
                    this.MensajeError(rpta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el artículo: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos de validación y auxiliares
        private bool ValidarCamposObligatorios()
        {
            bool camposValidos = true;
            errorIcono.Clear();

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorIcono.SetError(txtNombre, "Ingrese un nombre");
                camposValidos = false;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                errorIcono.SetError(txtCodigo, "Ingrese un código");
                camposValidos = false;
            }

            if (string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                errorIcono.SetError(txtPrecioVenta, "Ingrese un precio de venta");
                camposValidos = false;
            }

            if (cbCategoria.SelectedIndex == -1)
            {
                errorIcono.SetError(cbCategoria, "Seleccione una categoría");
                camposValidos = false;
            }

            if (cbPresentacion.SelectedIndex == -1)
            {
                errorIcono.SetError(cbPresentacion, "Seleccione una presentación");
                camposValidos = false;
            }

            if (!camposValidos)
            {
                MensajeError("Falta ingresar algunos datos, serán remarcados");
            }

            return camposValidos;
        }

        private bool ValidarPreciosYStock()
        {
            errorIcono.Clear();
            bool esValido = true;

            // Validar Precio de Venta
            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) || precioVenta < 0)
            {
                errorIcono.SetError(txtPrecioVenta, "El precio de venta debe ser un número válido y mayor o igual a 0");
                esValido = false;
            }

            // Validar Precio de Compra (si se ingresó)
            if (!string.IsNullOrEmpty(txtPrecioCompra.Text))
            {
                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) || precioCompra < 0)
                {
                    errorIcono.SetError(txtPrecioCompra, "El precio de compra debe ser un número válido y mayor o igual a 0");
                    esValido = false;
                }

                // Validar que precio de venta sea mayor o igual al de compra
                if (esValido && precioVenta < precioCompra)
                {
                    errorIcono.SetError(txtPrecioVenta, "El precio de venta no puede ser menor al precio de compra");
                    esValido = false;
                }
            }

            // Validar Stock Mínimo
            if (!string.IsNullOrEmpty(txtStockMinimo.Text))
            {
                if (!decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo) || stockMinimo < 0)
                {
                    errorIcono.SetError(txtStockMinimo, "El stock mínimo debe ser un número válido y mayor o igual a 0");
                    esValido = false;
                }
            }

            // Validar Stock Máximo
            if (!string.IsNullOrEmpty(txtStockMaximo.Text))
            {
                if (!decimal.TryParse(txtStockMaximo.Text, out decimal stockMaximo) || stockMaximo < 0)
                {
                    errorIcono.SetError(txtStockMaximo, "El stock máximo debe ser un número válido y mayor o igual a 0");
                    esValido = false;
                }
            }

            // Validar que stock máximo sea mayor al mínimo si ambos están completos
            if (esValido && !string.IsNullOrEmpty(txtStockMinimo.Text) && !string.IsNullOrEmpty(txtStockMaximo.Text))
            {
                decimal stockMin = decimal.Parse(txtStockMinimo.Text);
                decimal stockMax = decimal.Parse(txtStockMaximo.Text);

                if (stockMax <= stockMin && stockMax > 0)
                {
                    errorIcono.SetError(txtStockMaximo, "El stock máximo debe ser mayor al stock mínimo");
                    esValido = false;
                }
            }

            if (!esValido)
            {
                MensajeError("Revise los datos ingresados en precios y stock");
            }

            return esValido;
        }

        private decimal ObtenerStockMinimo()
        {
            if (string.IsNullOrEmpty(txtStockMinimo.Text))
                return 0;
            return decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo) ? stockMinimo : 0;
        }

        private decimal ObtenerStockMaximo()
        {
            if (string.IsNullOrEmpty(txtStockMaximo.Text))
                return 0;
            return decimal.TryParse(txtStockMaximo.Text, out decimal stockMaximo) ? stockMaximo : 0;
        }

        private decimal ObtenerPrecioCompra()
        {
            if (string.IsNullOrEmpty(txtPrecioCompra.Text))
                return 0;
            return decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) ? precioCompra : 0;
        }

        private decimal ObtenerIVA()
        {
            return 21; // 21% por defecto
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdarticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar");
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
                saveFileDialog.FileName = $"Reporte_Articulos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFArticulos(saveFileDialog.FileName);

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

        private void GenerarPDFArticulos(string filePath)
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

                // Título del reporte
                iText.Paragraph titulo = new iText.Paragraph("CAMPO ARGENTINO", fontTitulo);
                titulo.Alignment = iText.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                document.Add(titulo);

                iText.Paragraph subtitulo = new iText.Paragraph("REPORTE DE ARTÍCULOS", fontSubtitulo);
                subtitulo.Alignment = iText.Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 15f;
                document.Add(subtitulo);

                // ===== INFORMACIÓN DEL REPORTE =====
                iTextPdf.PdfPTable tablaInfo = new iTextPdf.PdfPTable(2);
                tablaInfo.WidthPercentage = 100;
                tablaInfo.SpacingAfter = 10f;

                // Calcular estadísticas
                decimal totalStock = 0;
                decimal totalValorInventario = 0;
                int articulosActivos = 0;
                int articulosInactivos = 0;

                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Verificar si el artículo está activo
                        bool activo = true;
                        if (row.Cells["Activo"].Value != null)
                        {
                            if (row.Cells["Activo"].Value is bool activoValue)
                                activo = activoValue;
                            else if (row.Cells["Activo"].Value.ToString() == "False")
                                activo = false;
                        }

                        if (activo) articulosActivos++;
                        else articulosInactivos++;

                        // Calcular stock y valor
                        if (row.Cells["StockActual"].Value != null && row.Cells["StockActual"].Value != DBNull.Value)
                        {
                            decimal stock = Convert.ToDecimal(row.Cells["StockActual"].Value);
                            totalStock += stock;

                            // Calcular valor del inventario (stock * precio de compra)
                            if (row.Cells["PrecioCompra"].Value != null && row.Cells["PrecioCompra"].Value != DBNull.Value)
                            {
                                decimal precioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);
                                totalValorInventario += stock * precioCompra;
                            }
                        }
                    }
                }

                AgregarCeldaTabla(tablaInfo, "Fecha de generación:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Total de artículos:", dataListado.Rows.Count.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Artículos activos:", articulosActivos.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Artículos inactivos:", articulosInactivos.ToString(), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Stock total:", totalStock.ToString("N2"), fontNormal);
                AgregarCeldaTabla(tablaInfo, "Valor total inventario:", totalValorInventario.ToString("C2"), fontNormal);

                document.Add(tablaInfo);

                // ===== TABLA PRINCIPAL DE ARTÍCULOS =====
                if (dataListado.Rows.Count > 0)
                {
                    // Columnas para mostrar en el reporte
                    string[] columnasImpresion = { "Codigo", "Nombre", "Categoria", "PrecioVenta", "StockActual", "Activo" };
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

                    // Configurar anchos de columnas
                    float[] anchos = new float[columnasDisponibles.Count];
                    for (int i = 0; i < columnasDisponibles.Count; i++)
                    {
                        if (columnasDisponibles[i] == "Codigo") anchos[i] = 12f;
                        else if (columnasDisponibles[i] == "PrecioVenta") anchos[i] = 15f;
                        else if (columnasDisponibles[i] == "StockActual") anchos[i] = 12f;
                        else if (columnasDisponibles[i] == "Activo") anchos[i] = 10f;
                        else anchos[i] = 51f; // Para Nombre y Categoría
                    }
                    tablaDatos.SetWidths(anchos);

                    // Encabezados de columnas
                    foreach (string columna in columnasDisponibles)
                    {
                        string headerText = ObtenerHeaderLegibleArticulos(columna);
                        iTextPdf.PdfPCell celdaHeader = new iTextPdf.PdfPCell(new iText.Phrase(headerText, fontHeader));
                        celdaHeader.BackgroundColor = new iText.BaseColor(51, 51, 51); // Gris oscuro
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

                                // Formatear valores específicos
                                if (columna == "PrecioVenta" && decimal.TryParse(valor, out decimal precio))
                                {
                                    valor = precio.ToString("C2");
                                }
                                else if (columna == "Activo")
                                {
                                    valor = (valor == "True" || valor == "1") ? "ACTIVO" : "INACTIVO";
                                }

                                iText.Phrase frase = new iText.Phrase(valor, fontData);
                                iTextPdf.PdfPCell celdaData = new iTextPdf.PdfPCell(frase);

                                // Alineación según el tipo de dato
                                if (columna == "Codigo" || columna == "StockActual" || columna == "Activo")
                                {
                                    celdaData.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                                }
                                else if (columna == "PrecioVenta")
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

                                // Resaltar artículos inactivos
                                if (columna == "Activo" && valor == "INACTIVO")
                                {
                                    celdaData.BackgroundColor = new iText.BaseColor(255, 200, 200);
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

        // Métodos auxiliares para FormArticulo
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

        private string ObtenerHeaderLegibleArticulos(string headerOriginal)
        {
            switch (headerOriginal)
            {
                case "Codigo": return "CÓDIGO";
                case "Nombre": return "NOMBRE DEL ARTÍCULO";
                case "Categoria": return "CATEGORÍA";
                case "PrecioVenta": return "PRECIO VENTA";
                case "StockActual": return "STOCK ACTUAL";
                case "Activo": return "ESTADO";
                default: return headerOriginal.ToUpper();
            }
        }

       
    }

}