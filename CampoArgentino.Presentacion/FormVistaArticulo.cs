using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaArticulo : Form
    {
        public FormVistaArticulo()
        {
            InitializeComponent();
        }

        // Método para mostrar todos los artículos
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        // Método para buscar artículos por nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        // Ocultar columnas que no se necesitan mostrar
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false; // idarticulo
            this.dataListado.Columns[1].Visible = false; // idcategoria
        }

        // Evento Load del formulario
        private void FormVistaArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        // Evento doble click para seleccionar artículo
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            // Aquí se enviará el artículo seleccionado al formulario padre
            DialogResult = DialogResult.OK;
            this.Close();
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

        // Propiedad para obtener el artículo seleccionado
        public string IdArticulo
        {
            get
            {
                return Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            }
        }

        public string NombreArticulo
        {
            get
            {
                return Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            }
        }

        public string PrecioVenta
        {
            get
            {
                return Convert.ToString(this.dataListado.CurrentRow.Cells["precioventa"].Value);
            }
        }

        public string StockDisponible
        {
            get
            {
                // Nota: En tu estructura actual no hay campo Stock, se calcularía
                return "0"; // Por ahora retornamos 0
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}