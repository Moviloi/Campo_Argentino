using CampoArgentino.Negocio;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CampoArgentino.Presentacion
{
    public partial class FormVistaArticuloCliente_Venta : Form
    {
        private int _idArticulo;
        private string _codigoArticulo;
        private string _nombreArticulo;

        public FormVistaArticuloCliente_Venta(int idArticulo, string codigo, string nombre)
        {
            InitializeComponent();
            _idArticulo = idArticulo;
            _codigoArticulo = codigo;
            _nombreArticulo = nombre;
        }

        private void FormVistaArticuloCliente_Venta_Load(object sender, EventArgs e)
        {
            ConfigurarCultureInfoArgentina();
            MostrarDatosArticulo();
            MostrarVentasPorCliente();
        }

        private void ConfigurarCultureInfoArgentina()
        {
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            culturaArgentina.NumberFormat.CurrencySymbol = "$";
            culturaArgentina.NumberFormat.CurrencyPositivePattern = 2;
            culturaArgentina.NumberFormat.CurrencyNegativePattern = 8;

            Thread.CurrentThread.CurrentCulture = culturaArgentina;
            Thread.CurrentThread.CurrentUICulture = culturaArgentina;
        }

        private void MostrarDatosArticulo()
        {
            lblArticuloInfo.Text = $"{_codigoArticulo} - {_nombreArticulo}";
            this.Text = $"Ventas por Cliente - {_codigoArticulo} - Campo Argentino";
        }

        private void MostrarVentasPorCliente()
        {
            try
            {
                Debug.WriteLine($"Buscando ventas para artículo ID: {_idArticulo}");

                DataTable dt = NVenta.VentasArticuloPorCliente(_idArticulo);

                // VERIFICAR SI ES NULL
                if (dt == null)
                {
                    MessageBox.Show($"Error: El método devolvió null para el artículo ID: {_idArticulo}\n" +
                                  $"Código: {_codigoArticulo}\n" +
                                  $"Nombre: {_nombreArticulo}",
                                  "Error de Datos",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                Debug.WriteLine($"Filas obtenidas: {dt.Rows.Count}");

                // Verificar si hay datos
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"El artículo '{_codigoArticulo} - {_nombreArticulo}' no tiene ventas registradas por clientes.\n\n" +
                                  $"ID Artículo: {_idArticulo}",
                                  "Sin Datos",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // Crear DataTable vacío con la estructura esperada
                    dt = CrearEstructuraClientesVacia();
                }

                dataListadoClientes.DataSource = dt;
                ConfigurarColumnas();
                CalcularEstadisticas(dt);
                lblTotal.Text = $"Total Clientes: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error detallado al cargar ventas por cliente:\n\n" +
                               $"Artículo: {_codigoArticulo} - {_nombreArticulo}\n" +
                               $"ID: {_idArticulo}\n\n" +
                               $"Error: {ex.Message}\n\n" +
                               $"Tipo: {ex.GetType().Name}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                // Mostrar datos de prueba en caso de error
                DataTable dtPrueba = CrearDatosPruebaClientes();
                dataListadoClientes.DataSource = dtPrueba;
                ConfigurarColumnas();
                CalcularEstadisticas(dtPrueba);
                lblTotal.Text = $"Total Clientes (Prueba): {dtPrueba.Rows.Count}";
            }
        }

        private void ConfigurarColumnas()
        {
            try
            {
                // Ocultar columnas ID
                if (dataListadoClientes.Columns.Contains("idcliente"))
                    dataListadoClientes.Columns["idcliente"].Visible = false;

                // Configurar headers y formatos para las columnas de clientes
                if (dataListadoClientes.Columns.Contains("CantidadComprada"))
                {
                    dataListadoClientes.Columns["CantidadComprada"].HeaderText = "CANT. COMPRADA";
                    dataListadoClientes.Columns["CantidadComprada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListadoClientes.Columns.Contains("PrecioPromedio"))
                {
                    dataListadoClientes.Columns["PrecioPromedio"].HeaderText = "PRECIO PROMEDIO";
                    dataListadoClientes.Columns["PrecioPromedio"].DefaultCellStyle.Format = "C2";
                    dataListadoClientes.Columns["PrecioPromedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListadoClientes.Columns.Contains("TotalComprado"))
                {
                    dataListadoClientes.Columns["TotalComprado"].HeaderText = "TOTAL COMPRADO";
                    dataListadoClientes.Columns["TotalComprado"].DefaultCellStyle.Format = "C2";
                    dataListadoClientes.Columns["TotalComprado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataListadoClientes.Columns.Contains("VecesComprado"))
                {
                    dataListadoClientes.Columns["VecesComprado"].HeaderText = "VECES COMPRADO";
                    dataListadoClientes.Columns["VecesComprado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dataListadoClientes.Columns.Contains("FechaUltimaCompra"))
                {
                    dataListadoClientes.Columns["FechaUltimaCompra"].HeaderText = "ÚLTIMA COMPRA";
                    dataListadoClientes.Columns["FechaUltimaCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataListadoClientes.Columns["FechaUltimaCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Autoajustar columnas
                dataListadoClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas: " + ex.Message,
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void CalcularEstadisticas(DataTable dt)
        {
            try
            {
                decimal totalVentas = 0;
                decimal cantidadTotal = 0;
                int totalClientes = dt.Rows.Count;
                int clientesActivos = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["TotalComprado"] != DBNull.Value)
                        totalVentas += Convert.ToDecimal(row["TotalComprado"]);

                    if (row["CantidadComprada"] != DBNull.Value)
                        cantidadTotal += Convert.ToDecimal(row["CantidadComprada"]);

                    // Considerar cliente activo si ha comprado en los últimos 30 días
                    if (row["FechaUltimaCompra"] != DBNull.Value)
                    {
                        DateTime ultimaCompra = Convert.ToDateTime(row["FechaUltimaCompra"]);
                        if (ultimaCompra >= DateTime.Now.AddDays(-30))
                            clientesActivos++;
                    }
                }

                lblEstadisticas.Text = $"Clientes: {totalClientes} | Activos: {clientesActivos} | " +
                                     $"Total Vendido: {totalVentas.ToString("C2")} | " +
                                     $"Cantidad: {cantidadTotal.ToString("N2")}";
            }
            catch (Exception ex)
            {
                lblEstadisticas.Text = "Error al calcular estadísticas";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void BuscarClientes()
        {
            try
            {
                DataTable dt = NVenta.VentasArticuloPorCliente(_idArticulo);

                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    string filtro = txtBuscar.Text.ToLower();
                    DataView dv = new DataView(dt);
                    dv.RowFilter = $"Cliente LIKE '%{filtro}%' OR Documento LIKE '%{filtro}%'";
                    dataListadoClientes.DataSource = dv.ToTable();
                }
                else
                {
                    dataListadoClientes.DataSource = dt;
                }

                lblTotal.Text = $"Total Clientes: {dataListadoClientes.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Implementar generación de PDF específico para este reporte
            MessageBox.Show("Funcionalidad de impresión para ventas por cliente",
                "En Desarrollo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataListadoClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dataListadoClientes.CurrentRow != null)
            {
                // Posible funcionalidad adicional al hacer doble click
                string cliente = dataListadoClientes.CurrentRow.Cells["Cliente"].Value?.ToString() ?? "";
                string total = dataListadoClientes.CurrentRow.Cells["TotalComprado"].Value?.ToString() ?? "";

                ttMensaje.SetToolTip(dataListadoClientes,
                    $"Cliente: {cliente}\nTotal Comprado: {total}");
            }
        }

        private DataTable CrearEstructuraClientesVacia()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idcliente", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));  // Esta es la columna CUIT
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("CantidadComprada", typeof(decimal));
            dt.Columns.Add("PrecioPromedio", typeof(decimal));
            dt.Columns.Add("TotalComprado", typeof(decimal));
            dt.Columns.Add("VecesComprado", typeof(int));
            dt.Columns.Add("FechaUltimaCompra", typeof(DateTime));
            return dt;
        }

        private DataTable CrearDatosPruebaClientes()
        {
            DataTable dt = CrearEstructuraClientesVacia();

            // Agregar algunos clientes de prueba
            DataRow row1 = dt.NewRow();
            row1["idcliente"] = 1;
            row1["Cliente"] = "Cliente de Prueba 1";
            row1["Documento"] = "20-12345678-9";
            row1["Telefono"] = "11-1234-5678";
            row1["Email"] = "cliente1@ejemplo.com";
            row1["CantidadComprada"] = 5;
            row1["PrecioPromedio"] = 100;
            row1["TotalComprado"] = 500;
            row1["VecesComprado"] = 2;
            row1["FechaUltimaCompra"] = DateTime.Now.AddDays(-10);
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["idcliente"] = 2;
            row2["Cliente"] = "Cliente de Prueba 2";
            row2["Documento"] = "20-87654321-0";
            row2["Telefono"] = "11-8765-4321";
            row2["Email"] = "cliente2@ejemplo.com";
            row2["CantidadComprada"] = 3;
            row2["PrecioPromedio"] = 120;
            row2["TotalComprado"] = 360;
            row2["VecesComprado"] = 1;
            row2["FechaUltimaCompra"] = DateTime.Now.AddDays(-5);
            dt.Rows.Add(row2);

            return dt;
        }
    }
}