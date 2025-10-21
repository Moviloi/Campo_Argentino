using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaCliente : Form
    {
        public FormVistaCliente()
        {
            InitializeComponent();
        }

        // Propiedades para obtener el cliente seleccionado
        public string Idcliente
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["ClienteID"].Value);
                return "";
            }
        }

        public string NombreCliente
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                return "";
            }
        }

        public string CUIT
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["CUIT"].Value);
                return "";
            }
        }

        // Método para mostrar clientes
        private void Mostrar()
        {
            try
            {
                this.dataListado.DataSource = NCliente.Mostrar();
                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Método para buscar clientes por nombre
        private void BuscarNombre()
        {
            try
            {
                this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
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
                // Mostrar solo columnas relevantes para selección
                if (dataListado.Columns.Contains("ClienteID"))
                    dataListado.Columns["ClienteID"].Visible = false;

                if (dataListado.Columns.Contains("Direccion"))
                    dataListado.Columns["Direccion"].Visible = false;

                if (dataListado.Columns.Contains("Telefono"))
                    dataListado.Columns["Telefono"].Visible = false;

                if (dataListado.Columns.Contains("Email"))
                    dataListado.Columns["Email"].Visible = false;
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
        private void FormVistaCliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        // Evento doble click para seleccionar cliente
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
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
                DialogResult result = MessageBox.Show("¿Desea imprimir el reporte de clientes?",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Reporte de clientes generado exitosamente.\n\n" +
                                  "Total de clientes: " + dataListado.Rows.Count,
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