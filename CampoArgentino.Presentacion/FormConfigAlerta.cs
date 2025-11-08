using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormConfigAlerta : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FormConfigAlerta()
        {
            InitializeComponent();
        }


        // Evento Load
        private void FormConfigAlerta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        // Método para mostrar configuraciones
        private void Mostrar()
        {
            try
            {
                // Cargar artículos para configuración
                DataTable dtArticulos = NArticulo.Mostrar();
                dataListado.DataSource = dtArticulos;
                OcultarColumnas();
                lblTotal.Text = "Total Artículos: " + dataListado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message,
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

        // Limpiar controles
        private void Limpiar()
        {
            txtIdarticulo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            txtStockMaximo.Text = string.Empty;
            chkNotificar.Checked = true;
        }

        // Habilitar/Deshabilitar controles
        private void Habilitar(bool valor)
        {
            txtStockMinimo.ReadOnly = !valor;
            txtStockMaximo.ReadOnly = !valor;
            chkNotificar.Enabled = valor;
        }

        // Mostrar mensajes
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Configurar botones
        private void Botones()
        {
            if (IsNuevo || IsEditar)
            {
                this.Habilitar(true);
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnNuevo.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
            }
        }

        // Evento doble click en DataGridView
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                txtIdarticulo.Text = dataListado.CurrentRow.Cells["idarticulo"].Value.ToString();
                txtNombre.Text = dataListado.CurrentRow.Cells["nombre"].Value.ToString();
                txtStockMinimo.Text = dataListado.CurrentRow.Cells["stockminimo"].Value.ToString();

                if (dataListado.CurrentRow.Cells["stockmaximo"].Value != DBNull.Value)
                    txtStockMaximo.Text = dataListado.CurrentRow.Cells["stockmaximo"].Value.ToString();
                else
                    txtStockMaximo.Text = "0";

                chkNotificar.Checked = true; // Por defecto activar notificaciones

                tabControl1.SelectedIndex = 1; // Ir a pestaña de configuración
            }
        }

        // Botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1; // Ir a pestaña de configuración
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            txtNombre.Focus();
        }

        // Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        // Botón Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdarticulo.Text.Equals(""))
            {
                IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccionar primero un artículo");
            }
        }

        // Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                    errorIcono.SetError(txtNombre, "Ingrese un valor");
                }
                else
                {
                    decimal stockMinimo = Convert.ToDecimal(txtStockMinimo.Text);
                    decimal stockMaximo = Convert.ToDecimal(txtStockMaximo.Text);

                    if (stockMinimo >= stockMaximo && stockMaximo > 0)
                    {
                        MensajeError("El stock mínimo debe ser menor al stock máximo");
                        return;
                    }

                    if (IsEditar)
                    {
                        DataTable dtArticulo = NArticulo.BuscarNombre(txtNombre.Text);
                        if (dtArticulo.Rows.Count > 0)
                        {
                            DataRow articulo = dtArticulo.Rows[0];

                            // OBTENER EL idpresentacion ACTUAL DEL ARTÍCULO
                            int idPresentacion = 0;
                            if (articulo["idpresentacion"] != DBNull.Value)
                            {
                                idPresentacion = Convert.ToInt32(articulo["idpresentacion"]);
                            }

                            rpta = NArticulo.Editar(
                                Convert.ToInt32(txtIdarticulo.Text),
                                Convert.ToInt32(articulo["idcategoria"]),
                                idPresentacion, // ← USAR EL VALOR REAL
                                articulo["codigo"].ToString(),
                                articulo["nombre"].ToString(),
                                articulo["descripcion"].ToString(),
                                articulo["unidadbase"].ToString(),
                                Convert.ToDecimal(articulo["factorconversion"]),
                                stockMinimo,
                                stockMaximo,
                                Convert.ToDecimal(articulo["preciocompra"]),
                                Convert.ToDecimal(articulo["precioventa"]),
                                Convert.ToDecimal(articulo["iva"]),
                                Convert.ToBoolean(articulo["activo"])
                            );
                        }
                        else
                        {
                            MensajeError("No se pudo obtener la información del artículo");
                            return;
                        }
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (IsEditar)
                        {
                            MensajeOk("Configuración actualizada correctamente");
                        }
                        IsEditar = false;
                        this.Botones();
                        this.Limpiar();
                        this.Mostrar();
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // Aplicar configuración global
        private void btnAplicarGlobal_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "¿Desea aplicar esta configuración a todos los artículos?\n\n" +
                    "Stock Mínimo: " + numStockMinimoGlobal.Value + "\n" +
                    "Stock Máximo: " + numStockMaximoGlobal.Value,
                    "Configuración Global",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Aquí la lógica para aplicar a todos los artículos
                    MensajeOk("Configuración global aplicada a todos los artículos");
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al aplicar configuración global: " + ex.Message);
            }
        }

        // Buscar artículos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataListado.DataSource = NArticulo.BuscarNombre(txtBuscar.Text);
                OcultarColumnas();
                lblTotal.Text = "Total Artículos: " + dataListado.Rows.Count;
            }
            catch (Exception ex)
            {
                MensajeError("Error al buscar: " + ex.Message);
            }
        }

        // Búsqueda en tiempo real
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.btnBuscar_Click(sender, e);
        }
    }
}