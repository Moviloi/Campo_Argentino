using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

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

        private void btnReporte_Click_1(object sender, EventArgs e)
        {
            FormVistaArticulo_Venta frm = new FormVistaArticulo_Venta();
            frm.ShowDialog();
        }

        private void FormArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = 0;
                this.Left = 0;

                // Inicializar controles críticos si son null
                InicializarControles();

                // Temporal: Debug para ver qué se carga
                //DebugCombos();

                this.CargarCombos();
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

        private void InicializarControles()
        {
            // Verificar e inicializar controles críticos
            if (txtStockMaximo == null)
            {
                // Si el control es null, intenta encontrarlo en los controles del formulario
                var control = this.Controls.Find("txtStockMaximo", true).FirstOrDefault();
                if (control != null)
                {
                    txtStockMaximo = control as TextBox;
                }
                else
                {
                    // Si no existe, créalo (solo para emergencia)
                    txtStockMaximo = new TextBox();
                    txtStockMaximo.Name = "txtStockMaximo";
                    txtStockMaximo.Visible = false; // Ocultarlo hasta que se arregle el diseño
                }
            }

            // Repetir para otros controles críticos
            if (txtStockMinimo == null)
            {
                var control = this.Controls.Find("txtStockMinimo", true).FirstOrDefault();
                if (control != null)
                {
                    txtStockMinimo = control as TextBox;
                }
                else
                {
                    txtStockMinimo = new TextBox();
                    txtStockMinimo.Name = "txtStockMinimo";
                    txtStockMinimo.Visible = false;
                }
            }

            if (txtPrecioCompra == null)
            {
                var control = this.Controls.Find("txtPrecioCompra", true).FirstOrDefault();
                if (control != null)
                {
                    txtPrecioCompra = control as TextBox;
                }
                else
                {
                    txtPrecioCompra = new TextBox();
                    txtPrecioCompra.Name = "txtPrecioCompra";
                    txtPrecioCompra.Visible = false;
                }
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
            if (txtIdarticulo != null) this.txtIdarticulo.Text = string.Empty;
            if (txtCodigo != null) this.txtCodigo.Text = string.Empty;
            if (txtNombre != null) this.txtNombre.Text = string.Empty;
            if (txtDescripcion != null) this.txtDescripcion.Text = string.Empty;
            if (txtPrecioVenta != null) this.txtPrecioVenta.Text = string.Empty;
            if (txtStock != null) this.txtStock.Text = string.Empty;
            if (txtPrecioCompra != null) this.txtPrecioCompra.Text = string.Empty;
            if (txtStockMinimo != null) this.txtStockMinimo.Text = string.Empty;
            if (txtStockMaximo != null) this.txtStockMaximo.Text = string.Empty;
            if (cbCategoria != null) this.cbCategoria.SelectedIndex = -1;
            if (cbPresentacion != null) this.cbPresentacion.SelectedIndex = -1;
        }

        private void Habilitar(bool valor)
        {
            // Verificar que los controles existan antes de usarlos
            if (txtCodigo != null) txtCodigo.ReadOnly = !valor;
            if (txtNombre != null) txtNombre.ReadOnly = !valor;
            if (txtDescripcion != null) txtDescripcion.ReadOnly = !valor;
            if (txtPrecioVenta != null) txtPrecioVenta.ReadOnly = !valor;
            if (txtPrecioCompra != null) txtPrecioCompra.ReadOnly = !valor;
            if (txtStockMinimo != null) txtStockMinimo.ReadOnly = !valor;
            if (txtStockMaximo != null) txtStockMaximo.ReadOnly = !valor;
            if (cbCategoria != null) cbCategoria.Enabled = valor;
            if (cbPresentacion != null) cbPresentacion.Enabled = valor;
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
                this.OcultarColumnas();

                // Calcular stock total de forma segura
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

                // Verificar que lblTotal existe antes de usarlo
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

        private void CargarCombos()
        {
            try
            {
                // Verificar que los combos existan
                if (cbCategoria == null || cbPresentacion == null)
                {
                    MessageBox.Show("Error: Los combos no están inicializados correctamente", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                    MessageBox.Show("No hay categorías disponibles. Debe crear categorías primero.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("No hay presentaciones disponibles. Debe crear presentaciones primero.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebugCombos()
        {
            try
            {
                // Debug categorías
                DataTable dtCat = NCategoria.Mostrar();
                string debugInfo = "=== DEBUG COMBOS ===\n";
                debugInfo += $"Categorías: {dtCat?.Rows.Count ?? 0} registros\n";

                if (dtCat != null)
                {
                    foreach (DataRow row in dtCat.Rows)
                    {
                        debugInfo += $"ID: {row["idcategoria"]}, Nombre: {row["nombre"]}\n";
                    }
                }

                // Debug presentaciones
                DataTable dtPres = NPresentacion.Mostrar();
                debugInfo += $"\nPresentaciones: {dtPres?.Rows.Count ?? 0} registros\n";

                if (dtPres != null)
                {
                    foreach (DataRow row in dtPres.Rows)
                    {
                        debugInfo += $"ID: {row["idpresentacion"]}, Nombre: {row["Nombre"]}\n";
                    }
                }

                MessageBox.Show(debugInfo, "Debug - Combos");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en debug: {ex.Message}", "Debug Error");
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
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar los registros seleccionados?",
                    "Sistema Campo Argentino", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            int idarticulo = Convert.ToInt32(row.Cells["idarticulo"].Value);
                            Rpta = NArticulo.Eliminar(idarticulo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó correctamente el registro");
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
                this.dataListado.Columns["Eliminar"].Visible = true;
            }
            else
            {
                this.dataListado.Columns["Eliminar"].Visible = false;
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

                // Presentación (Unidad Base)
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

                // Otros campos
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
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposObligatorios())
                {
                    return;
                }

                string rpta = "";
                int idcategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                int idpresentacion = cbPresentacion.SelectedValue != null ? Convert.ToInt32(cbPresentacion.SelectedValue) : 0;
                string unidadBase = cbPresentacion.Text; // Usar el nombre de la presentación como unidad base

                if (this.IsNuevo)
                {
                    rpta = NArticulo.Insertar(
                        idcategoria,
                        idpresentacion,
                        this.txtCodigo.Text.Trim(),
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtDescripcion.Text.Trim(),
                        unidadBase,                   // unidadbase (nombre de la presentación)
                        1,                           // factorconversion
                        ObtenerStockMinimo(),
                        ObtenerStockMaximo(),
                        ObtenerPrecioCompra(),
                        Convert.ToDecimal(this.txtPrecioVenta.Text),
                        ObtenerIVA(),
                        true                         // activo
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
                        unidadBase,                   // unidadbase (nombre de la presentación)
                        1,                           // factorconversion
                        ObtenerStockMinimo(),
                        ObtenerStockMaximo(),
                        ObtenerPrecioCompra(),
                        Convert.ToDecimal(this.txtPrecioVenta.Text),
                        ObtenerIVA(),
                        true                         // activo
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

        private bool ValidarPrecios()
        {
            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) || precioVenta < 0)
            {
                MessageBox.Show("El precio de venta debe ser un valor numérico válido y mayor o igual a 0",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioVenta.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtPrecioCompra.Text))
            {
                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) || precioCompra < 0)
                {
                    MessageBox.Show("El precio de compra debe ser un valor numérico válido y mayor o igual a 0",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioCompra.Focus();
                    return false;
                }
            }

            return true;
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


    }
}