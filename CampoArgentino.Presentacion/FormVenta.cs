using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormVenta : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static int IdusuarioActual = 1; // Esto debería venir del login

        public FormVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNumeroDocumento, "Ingrese el número de documento");
            this.ttMensaje.SetToolTip(this.txtObservaciones, "Ingrese observaciones adicionales");
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.LlenarComboCliente();
            this.dtpFechaVenta.Value = DateTime.Now;
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
            this.txtNumeroDocumento.Text = string.Empty;
            this.cbCliente.SelectedIndex = -1;
            this.dtpFechaVenta.Value = DateTime.Now;
            this.txtSubtotal.Text = "0.00";
            this.txtImpuestos.Text = "0.00";
            this.txtTotal.Text = "0.00";
            this.txtObservaciones.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtNumeroDocumento.ReadOnly = !valor;
            this.cbCliente.Enabled = valor;
            this.dtpFechaVenta.Enabled = valor;
            this.txtObservaciones.ReadOnly = !valor;
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
            this.dataListado.Columns[0].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(dtpFechaInicio.Value.ToString("yyyy-MM-dd"),
                                                             dtpFechaFin.Value.ToString("yyyy-MM-dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarComboCliente()
        {
            try
            {
                DataTable dtClientes = NCliente.Mostrar();
                cbCliente.DataSource = dtClientes;
                cbCliente.ValueMember = "ClienteID";
                cbCliente.DisplayMember = "Nombre";
                cbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void MostrarDetalle(int ventaID)
        {
            dataListadoDetalle.DataSource = NVenta.MostrarDetalle(ventaID);
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
            this.txtVentaID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["VentaID"].Value);
            this.txtNumeroDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NumeroDocumento"].Value);

            // Buscar y seleccionar el cliente en el combo
            string clienteNombre = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            foreach (DataRowView item in cbCliente.Items)
            {
                if (item["Nombre"].ToString() == clienteNombre)
                {
                    cbCliente.SelectedValue = item["ClienteID"];
                    break;
                }
            }

            this.dtpFechaVenta.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaVenta"].Value);
            this.txtSubtotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Subtotal"].Value);
            this.txtImpuestos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuestos"].Value);
            this.txtTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.txtObservaciones.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observaciones"].Value);

            // Mostrar detalle
            MostrarDetalle(Convert.ToInt32(this.txtVentaID.Text));

            this.tabControl1.SelectedIndex = 1;
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

                if (this.txtNumeroDocumento.Text == string.Empty || cbCliente.SelectedIndex == -1)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNumeroDocumento, "Ingrese un valor");
                    errorIcono.SetError(cbCliente, "Seleccione un cliente");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(
                            this.txtNumeroDocumento.Text.Trim(),
                            Convert.ToInt32(cbCliente.SelectedValue),
                            this.dtpFechaVenta.Value,
                            Convert.ToDecimal(this.txtSubtotal.Text),
                            Convert.ToDecimal(this.txtImpuestos.Text),
                            Convert.ToDecimal(this.txtTotal.Text),
                            this.txtObservaciones.Text.Trim(),
                            IdusuarioActual
                        );
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se insertó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Implementar reporte cuando tengamos el módulo de reportes
            MessageBox.Show("Módulo de reportes en desarrollo", "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVentaID.Text))
            {
                // Lógica para generar factura
                MessageBox.Show("Generando factura para venta: " + txtVentaID.Text,
                    "Sistema Campo Argentino", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MensajeError("Seleccione una venta para generar la factura");
            }
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
    }
}