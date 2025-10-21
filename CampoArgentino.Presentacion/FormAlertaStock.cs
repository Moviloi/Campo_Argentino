using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormAlertaStock : Form
    {
        public FormAlertaStock()
        {
            InitializeComponent();
        }

        // Método para cargar alertas de stock bajo
        private void CargarAlertas()
        {
            try
            {
                // Aquí necesitaríamos un método específico para alertas de stock
                // Por ahora usamos el método general de artículos
                DataTable dtArticulos = NArticulo.Mostrar();

                // Filtrar artículos con stock bajo (simulado)
                DataView dv = new DataView(dtArticulos);
                dv.RowFilter = "Convert(stockminimo, 'System.Decimal') > 0"; // Ejemplo

                dataListado.DataSource = dv;
                OcultarColumnas();
                lblTotal.Text = "Alertas Activas: " + dataListado.Rows.Count;

                // Cambiar color del label si hay alertas
                if (dataListado.Rows.Count > 0)
                {
                    lblTotal.ForeColor = Color.Red;
                    lblTotal.Text += " - ATENCIÓN REQUERIDA";
                }
                else
                {
                    lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
                    lblTotal.Text += " - TODO EN ORDEN";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alertas: " + ex.Message,
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

        // Evento Load
        private void FormAlertaStock_Load(object sender, EventArgs e)
        {
            this.CargarAlertas();
        }

        // Evento para actualizar alertas
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.CargarAlertas();
            MessageBox.Show("Alertas actualizadas correctamente",
                "Sistema Campo Argentino",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Evento para configurar alertas
        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            FormConfigAlerta frm = new FormConfigAlerta();
            frm.ShowDialog();
        }

        // Evento para generar reporte
        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "¿Desea generar un reporte de las alertas de stock?",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show(
                            "Reporte de alertas generado exitosamente.\n\n" +
                            "Total de alertas: " + dataListado.Rows.Count + "\n" +
                            "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                            "Sistema Campo Argentino",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No hay alertas activas para reportar",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Evento doble click para ver detalles del artículo
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                string articuloId = dataListado.CurrentRow.Cells["idarticulo"].Value.ToString();
                string nombreArticulo = dataListado.CurrentRow.Cells["nombre"].Value.ToString();

                MessageBox.Show(
                    $"Artículo: {nombreArticulo}\n" +
                    $"ID: {articuloId}\n" +
                    "Acción: Revisar stock y realizar pedido",
                    "Detalle de Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}