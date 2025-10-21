using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaProveedor : Form
    {
        public FormVistaProveedor()
        {
            InitializeComponent();
        }

        // Propiedades para obtener el proveedor seleccionado
        public string Idproveedor
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["ProveedorID"].Value);
                return "";
            }
        }

        public string NombreProveedor
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

        // Método para mostrar proveedores
        private void Mostrar()
        {
            try
            {
                this.dataListado.DataSource = NProveedor.Mostrar();
                this.OcultarColumnas();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Método para buscar proveedores por nombre
        private void BuscarNombre()
        {
            try
            {
                this.dataListado.DataSource = NProveedor.BuscarNombre(this.txtBuscar.Text);
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
                if (dataListado.Columns.Contains("ProveedorID"))
                    dataListado.Columns["ProveedorID"].Visible = false;

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
        private void FormVistaProveedor_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        // Evento doble click para seleccionar proveedor
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
                DialogResult result = MessageBox.Show("¿Desea imprimir el reporte de proveedores?",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Reporte de proveedores generado exitosamente.\n\n" +
                                  "Total de proveedores: " + dataListado.Rows.Count,
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