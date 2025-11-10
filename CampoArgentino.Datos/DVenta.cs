using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace CampoArgentino.Datos
{
    public class DVenta
    {
        private int _Idventa;
        private string _NumeroDocumento;
        private int _Idcliente;
        private DateTime _FechaVenta;
        private DateTime _FechaRegistro;
        private decimal _Subtotal;
        private decimal _Impuestos;
        private decimal _Total;
        private string _Observaciones;
        private int _Idusuario;
        private string _TextoBuscar;

        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public string NumeroDocumento { get => _NumeroDocumento; set => _NumeroDocumento = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public DateTime FechaVenta { get => _FechaVenta; set => _FechaVenta = value; }
        public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }
        public decimal Impuestos { get => _Impuestos; set => _Impuestos = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DVenta() { }

        // Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                System.Diagnostics.Debug.WriteLine("Error en Mostrar Ventas: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtResultado;
        }

        // Método Insertar
        public string Insertar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNumeroDocumento = new SqlParameter();
                ParNumeroDocumento.ParameterName = "@NumeroDocumento";
                ParNumeroDocumento.SqlDbType = SqlDbType.NVarChar;
                ParNumeroDocumento.Size = 50;
                ParNumeroDocumento.Value = Venta.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumeroDocumento);

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParFechaVenta = new SqlParameter();
                ParFechaVenta.ParameterName = "@FechaVenta";
                ParFechaVenta.SqlDbType = SqlDbType.DateTime;
                ParFechaVenta.Value = Venta.FechaVenta;
                SqlCmd.Parameters.Add(ParFechaVenta);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@Subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Value = Venta.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);

                SqlParameter ParImpuestos = new SqlParameter();
                ParImpuestos.ParameterName = "@Impuestos";
                ParImpuestos.SqlDbType = SqlDbType.Decimal;
                ParImpuestos.Value = Venta.Impuestos;
                SqlCmd.Parameters.Add(ParImpuestos);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@Total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Value = Venta.Total;
                SqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@Observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NVarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Venta.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Venta.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Método Anular (Eliminar)
        public string Anular(DVenta Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_AnularVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Anuló el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Método Buscar por Fechas
        public DataTable BuscarFechas(string FechaInicio, string FechaFin)
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_BuscarVentaFechas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.NVarChar;
                ParFechaInicio.Size = 50;
                ParFechaInicio.Value = FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@FechaFin";
                ParFechaFin.SqlDbType = SqlDbType.NVarChar;
                ParFechaFin.Size = 50;
                ParFechaFin.Value = FechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                System.Diagnostics.Debug.WriteLine("Error en BuscarFechas: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtResultado;
        }

        // Método Mostrar Detalle
        public DataTable MostrarDetalle(int Idventa)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarDetalleVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                System.Diagnostics.Debug.WriteLine("Error en MostrarDetalle: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtResultado;
        }

        public string InsertarVentaCompleta(DVenta Venta, DataTable Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarVentaCompleta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de la venta
                SqlParameter ParNumeroDocumento = new SqlParameter();
                ParNumeroDocumento.ParameterName = "@NumeroDocumento";
                ParNumeroDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumeroDocumento.Size = 50;
                ParNumeroDocumento.Value = Venta.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumeroDocumento);

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParFechaVenta = new SqlParameter();
                ParFechaVenta.ParameterName = "@FechaVenta";
                ParFechaVenta.SqlDbType = SqlDbType.DateTime;
                ParFechaVenta.Value = Venta.FechaVenta;
                SqlCmd.Parameters.Add(ParFechaVenta);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@Subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Precision = 18;
                ParSubtotal.Scale = 2;
                ParSubtotal.Value = Venta.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);

                SqlParameter ParImpuestos = new SqlParameter();
                ParImpuestos.ParameterName = "@Impuestos";
                ParImpuestos.SqlDbType = SqlDbType.Decimal;
                ParImpuestos.Precision = 18;
                ParImpuestos.Scale = 2;
                ParImpuestos.Value = Venta.Impuestos;
                SqlCmd.Parameters.Add(ParImpuestos);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@Total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Precision = 18;
                ParTotal.Scale = 2;
                ParTotal.Value = Venta.Total;
                SqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@Observaciones";
                ParObservaciones.SqlDbType = SqlDbType.VarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Venta.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Venta.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);


                
                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@Detalle";
                ParDetalle.SqlDbType = SqlDbType.Structured;
                ParDetalle.TypeName = "dbo.DetalleVentaType";
                ParDetalle.Value = Detalle;
                SqlCmd.Parameters.Add(ParDetalle);

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se Ingreso la Venta";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        public string ObtenerProximoNumeroDocumento()
        {
            string proximoNumero = "000001";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SELECT ISNULL(MAX(CAST(NumeroDocumento AS INT)), 0) + 1 FROM Venta";
                SqlCmd.CommandType = CommandType.Text;

                SqlCon.Open();
                int ultimoNumero = Convert.ToInt32(SqlCmd.ExecuteScalar());
                proximoNumero = ultimoNumero.ToString("D6"); // Formato 000001, 000002, etc.
            }
            catch (Exception ex)
            {
                proximoNumero = "000001";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return proximoNumero;
        }

        public DataTable VentasPorArticulo()
        {
            DataTable DtResultado = new DataTable("VentasPorArticulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_VentasPorArticulo"; 
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                // devuelve un DataTable vacío
                DtResultado = new DataTable();
                // O puedes loguear el error
                Debug.WriteLine("Error en VentasPorArticulo: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return DtResultado;
        }

        public DataTable VentasArticuloPorCliente(int idArticulo)
        {
            DataTable DtResultado = new DataTable("VentasArticuloCliente");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_VentasArticuloPorCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = idArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

                // DEBUG: Verificar si se llenó la tabla
                Debug.WriteLine($"Filas obtenidas: {DtResultado.Rows.Count}");
            }
            catch (SqlException sqlEx)
            {
                // Error específico de SQL
                DtResultado = null;
                Debug.WriteLine($"Error SQL: {sqlEx.Message}");
                throw new Exception($"Error de base de datos: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Error general
                DtResultado = null;
                Debug.WriteLine($"Error general: {ex.Message}");
                throw new Exception($"Error al obtener ventas por cliente: {ex.Message}");
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return DtResultado;
        }

        public DataTable ComprasClientePorArticulo(int idCliente)
        {
            DataTable DtResultado = new DataTable("ComprasClienteArticulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ComprasClientePorArticulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = idCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                Debug.WriteLine($"Error en ComprasClientePorArticulo: {ex.Message}");
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }

        public DataTable TotalComprasCliente(int idCliente)
        {
            DataTable DtResultado = new DataTable("TotalComprasCliente");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_TotalComprasCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = idCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                Debug.WriteLine($"Error en TotalComprasCliente: {ex.Message}");
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }
    }
}