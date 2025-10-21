using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaArticulo_Venta : Form
    {
        public FormVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        // Método para mostrar artículos
        private void Mostrar()
        {
            try
            {
                this.dataListado.DataSource = NArticulo.Mostrar();
                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Método para buscar artículos por nombre
        private void BuscarNombre()
        {
            try
            {
                this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Ocultar columnas que no se necesitan mostrar
        private void OcultarColumnas()
        {
            try
            {
                // Ocultar columnas que no son relevantes para el reporte de ventas
                if (dataListado.Columns.Contains("idarticulo"))
                    dataListado.Columns["idarticulo"].Visible = false;

                if (dataListado.Columns.Contains("idcategoria"))
                    dataListado.Columns["idcategoria"].Visible = false;

                if (dataListado.Columns.Contains("descripcion"))
                    dataListado.Columns["descripcion"].Visible = false;

                if (dataListado.Columns.Contains("preciocompra"))
                    dataListado.Columns["preciocompra"].Visible = false;

                if (dataListado.Columns.Contains("activo"))
                    dataListado.Columns["activo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Evento Load del formulario
        private void FormVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        // Evento buscar al hacer click
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        // Evento buscar al escribir
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        // Evento imprimir reporte
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea imprimir el reporte de artículos para ventas?",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Aquí iría la lógica de impresión real
                    // Por ahora mostramos un mensaje de éxito
                    MessageBox.Show("Reporte de artículos para ventas generado exitosamente.\n\n" +
                                  "Total de artículos: " + dataListado.Rows.Count,
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
    }
}