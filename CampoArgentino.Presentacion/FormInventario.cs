using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

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
            // Aquí puedes implementar la impresión del reporte
            MensajeOk("Función de impresión lista para implementar");
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar exportación a Excel
            MensajeOk("Función de exportación lista para implementar");
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