using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DVenta
    {
        private int _VentaID;
        private string _NumeroDocumento;
        private int _Idcliente;
        private DateTime _FechaVenta;
        private decimal _Subtotal;
        private decimal _Impuestos;
        private decimal _Total;
        private string _Observaciones;
        private int _Idusuario;
        private string _TextoBuscar;

        public int VentaID { get => _VentaID; set => _VentaID = value; }
        public string NumeroDocumento { get => _NumeroDocumento; set => _NumeroDocumento = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public DateTime FechaVenta { get => _FechaVenta; set => _FechaVenta = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }
        public decimal Impuestos { get => _Impuestos; set => _Impuestos = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DVenta() { }

        public DVenta(int ventaID, string numeroDocumento, int idcliente, DateTime fechaVenta,
                     decimal subtotal, decimal impuestos, decimal total, string observaciones,
                     int idusuario, string textobuscar)
        {
            this.VentaID = ventaID;
            this.NumeroDocumento = numeroDocumento;
            this.Idcliente = idcliente;
            this.FechaVenta = fechaVenta;
            this.Subtotal = subtotal;
            this.Impuestos = impuestos;
            this.Total = total;
            this.Observaciones = observaciones;
            this.Idusuario = idusuario;
            this.TextoBuscar = textobuscar;
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
                ParNumeroDocumento.ParameterName = "@numeroDocumento";
                ParNumeroDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumeroDocumento.Size = 50;
                ParNumeroDocumento.Value = Venta.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumeroDocumento);

                SqlParameter ParClienteID = new SqlParameter();
                ParClienteID.ParameterName = "@idcliente";
                ParClienteID.SqlDbType = SqlDbType.Int;
                ParClienteID.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParClienteID);

                SqlParameter ParFechaVenta = new SqlParameter();
                ParFechaVenta.ParameterName = "@fechaVenta";
                ParFechaVenta.SqlDbType = SqlDbType.DateTime;
                ParFechaVenta.Value = Venta.FechaVenta;
                SqlCmd.Parameters.Add(ParFechaVenta);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Precision = 11;
                ParSubtotal.Scale = 2;
                ParSubtotal.Value = Venta.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);

                SqlParameter ParImpuestos = new SqlParameter();
                ParImpuestos.ParameterName = "@impuestos";
                ParImpuestos.SqlDbType = SqlDbType.Decimal;
                ParImpuestos.Precision = 11;
                ParImpuestos.Scale = 2;
                ParImpuestos.Value = Venta.Impuestos;
                SqlCmd.Parameters.Add(ParImpuestos);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Precision = 11;
                ParTotal.Scale = 2;
                ParTotal.Value = Venta.Total;
                SqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@observaciones";
                ParObservaciones.SqlDbType = SqlDbType.VarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Venta.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);

                SqlParameter ParUsuarioID = new SqlParameter();
                ParUsuarioID.ParameterName = "@idusuario";
                ParUsuarioID.SqlDbType = SqlDbType.Int;
                ParUsuarioID.Value = Venta.Idusuario;
                SqlCmd.Parameters.Add(ParUsuarioID);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";
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

                SqlParameter ParVentaID = new SqlParameter();
                ParVentaID.ParameterName = "@idventa";
                ParVentaID.SqlDbType = SqlDbType.Int;
                ParVentaID.Value = Venta.VentaID;
                SqlCmd.Parameters.Add(ParVentaID);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Anuló el Registro";
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

        // Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
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
            }
            return DtResultado;
        }

        // Método Buscar por Fechas
        public DataTable BuscarFechas(string fechaInicio, string fechaFin)
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
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.VarChar;
                ParFechaInicio.Size = 50;
                ParFechaInicio.Value = fechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechaFin";
                ParFechaFin.SqlDbType = SqlDbType.VarChar;
                ParFechaFin.Size = 50;
                ParFechaFin.Value = fechaFin;
                SqlCmd.Parameters.Add(ParFechaFin);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Método Mostrar Detalle
        public DataTable MostrarDetalle(int ventaID)
        {
            DataTable DtResultado = new DataTable("detalleVenta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarDetalleVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParVentaID = new SqlParameter();
                ParVentaID.ParameterName = "@idventa";
                ParVentaID.SqlDbType = SqlDbType.Int;
                ParVentaID.Value = ventaID;
                SqlCmd.Parameters.Add(ParVentaID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}