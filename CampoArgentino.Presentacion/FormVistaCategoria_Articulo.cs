using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaCategoria_Articulo : Form
    {
        public FormVistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        // Propiedades para obtener el artículo seleccionado
        public string ArticuloID
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
                return "";
            }
        }

        public string NombreArticulo
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
                return "";
            }
        }

        public string PrecioVenta
        {
            get
            {
                if (dataListado.CurrentRow != null)
                    return Convert.ToString(dataListado.CurrentRow.Cells["precioventa"].Value);
                return "";
            }
        }

        // Método para mostrar todos los artículos
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

        // Método para filtrar por categoría
        private void FiltrarPorCategoria()
        {
            try
            {
                if (cbCategoria.SelectedValue != null && cbCategoria.SelectedIndex > 0)
                {
                    int idCategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                    // Aquí necesitaría un método en NArticulo para filtrar por categoría
                    // Por ahora usa el método general y filtramos localmente
                    DataTable dt = NArticulo.Mostrar();
                    DataView dv = new DataView(dt);
                    dv.RowFilter = $"idcategoria = {idCategoria}";
                    dataListado.DataSource = dv;
                }
                else
                {
                    Mostrar(); // Mostrar todos si se selecciona "Todas las categorías"
                }

                lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por categoría: " + ex.Message,
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
                if (dataListado.Columns.Contains("idarticulo"))
                    dataListado.Columns["idarticulo"].Visible = false;

                if (dataListado.Columns.Contains("idcategoria"))
                    dataListado.Columns["idcategoria"].Visible = false;

                if (dataListado.Columns.Contains("descripcion"))
                    dataListado.Columns["descripcion"].Visible = false;

                if (dataListado.Columns.Contains("unidadbase"))
                    dataListado.Columns["unidadbase"].Visible = false;

                if (dataListado.Columns.Contains("factorconversion"))
                    dataListado.Columns["factorconversion"].Visible = false;

                if (dataListado.Columns.Contains("stockminimo"))
                    dataListado.Columns["stockminimo"].Visible = false;

                if (dataListado.Columns.Contains("stockmaximo"))
                    dataListado.Columns["stockmaximo"].Visible = false;

                if (dataListado.Columns.Contains("preciocompra"))
                    dataListado.Columns["preciocompra"].Visible = false;

                if (dataListado.Columns.Contains("iva"))
                    dataListado.Columns["iva"].Visible = false;

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
        private void CargarCategorias()
        {
            try
            {
                DataTable dt = NCategoria.Mostrar();

                // DIAGNÓSTICO: Ver qué devuelve la capa de negocio
                if (dt == null)
                {
                    MessageBox.Show("ERROR: DataTable de categorías es NULL");
                    return;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("ADVERTENCIA: No hay categorías en la base de datos");
                    return;
                }

                // Mostrar información de diagnóstico
                string debugInfo = $"Categorías cargadas: {dt.Rows.Count}\n";
                debugInfo += "Columnas: ";
                foreach (DataColumn col in dt.Columns)
                {
                    debugInfo += $"{col.ColumnName} ";
                }
                debugInfo += "\nPrimeras categorías:\n";
                for (int i = 0; i < Math.Min(3, dt.Rows.Count); i++)
                {
                    debugInfo += $"ID: {dt.Rows[i]["idcategoria"]} | Nombre: {dt.Rows[i]["nombre"]}\n";
                }

                MessageBox.Show(debugInfo, "DEBUG - Categorías");

                // Configurar el ComboBox
                cbCategoria.DataSource = dt;
                cbCategoria.DisplayMember = "nombre";
                cbCategoria.ValueMember = "idcategoria";
                cbCategoria.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}\n\n{ex.StackTrace}", "ERROR");
            }
        }

        // Evento Load del formulario
        private void FormVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.CargarCategorias();
        }

        // Evento doble click para seleccionar artículo
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

        // Evento cambiar categoría
        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedIndex > 0)
            {
                this.FiltrarPorCategoria();
            }
            else
            {
                this.Mostrar();
            }
        }

        // Evento imprimir reporte
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string categoriaSeleccionada = cbCategoria.SelectedIndex > 0 ?
                    cbCategoria.Text : "Todas las categorías";

                DialogResult result = MessageBox.Show($"¿Desea imprimir el reporte de artículos ({categoriaSeleccionada})?",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"Reporte de artículos generado exitosamente.\n\n" +
                                  $"Categoría: {categoriaSeleccionada}\n" +
                                  $"Total de artículos: {dataListado.Rows.Count}",
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