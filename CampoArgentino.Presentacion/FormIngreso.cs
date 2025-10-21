using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormIngreso : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

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
        }

        private void Habilitar(bool valor)
        {
            this.txtNumeroDocumento.ReadOnly = !valor;
            this.cbProveedor.Enabled = valor;
            this.dtpFechaCompra.Enabled = valor;
            this.txtSubtotal.ReadOnly = !valor;
            this.txtImpuestos.ReadOnly = !valor;
            this.txtObservaciones.ReadOnly = !valor;
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
            this.dataListado.Columns[0].Visible = false;
            if (this.dataListado.Columns.Contains("idingreso"))
            {
                this.dataListado.Columns["idingreso"].Visible = false;
            }
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(
                this.dtpFechaInicio.Value.ToString("yyyy-MM-dd"),
                this.dtpFechaFin.Value.ToString("yyyy-MM-dd")
            );
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
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea anular los registros seleccionados?",
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
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

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
            try
            {
                // VERIFICAR COLUMNAS DISPONIBLES
                Debug.WriteLine("=== COLUMNAS EN DATAGRIDVIEW ===");
                foreach (DataGridViewColumn col in dataListado.Columns)
                {
                    Debug.WriteLine($"'{col.Name}' -> '{col.HeaderText}'");
                }

                // Cargar ID del ingreso - buscar por diferentes nombres posibles
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
                    // Si no encuentra, usar la primera columna
                    idColumnName = dataListado.Columns[0].Name;
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

                // Cargar fecha de compra - CORREGIDO: usar dtpFechaCompra
                if (dataListado.Columns.Contains("FechaCompra") &&
                    this.dataListado.CurrentRow.Cells["FechaCompra"].Value != null)
                {
                    DateTime fechaCompra = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaCompra"].Value);
                    dtpFechaCompra.Value = fechaCompra; // ← CORREGIDO: dtpFechaCompra en lugar de dtFechaCompra
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
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
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
                }
                else
                {
                    decimal subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
                    decimal impuestos = Convert.ToDecimal(this.txtImpuestos.Text);
                    decimal total = Convert.ToDecimal(this.txtTotal.Text);

                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(
                            this.txtNumeroDocumento.Text.Trim(),
                            Convert.ToInt32(this.cbProveedor.SelectedValue),
                            this.dtpFechaCompra.Value, // ← CORREGIDO: dtpFechaCompra
                            subtotal,
                            impuestos,
                            total,
                            this.txtObservaciones.Text.Trim(),
                            1 // idusuario temporal
                        );
                    }
                    else
                    {
                        rpta = NIngreso.Editar(
                            Convert.ToInt32(this.txtCompraID.Text),
                            this.txtNumeroDocumento.Text.Trim(),
                            Convert.ToInt32(this.cbProveedor.SelectedValue),
                            this.dtpFechaCompra.Value, // ← CORREGIDO: dtpFechaCompra
                            subtotal,
                            impuestos,
                            total,
                            this.txtObservaciones.Text.Trim(),
                            1 // idusuario temporal
                        );
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            this.CalcularTotal();
        }

        private void txtImpuestos_TextChanged(object sender, EventArgs e)
        {
            this.CalcularTotal();
        }

        private void CalcularTotal()
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
                decimal impuestos = Convert.ToDecimal(this.txtImpuestos.Text);
                decimal total = subtotal + impuestos;
                this.txtTotal.Text = total.ToString("0.00");
            }
            catch
            {
                this.txtTotal.Text = "0.00";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Lógica para imprimir
            MessageBox.Show("Funcionalidad de impresión en desarrollo", "Sistema Campo Argentino");
        }
    }
}