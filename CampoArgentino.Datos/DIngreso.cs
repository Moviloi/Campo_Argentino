using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DIngreso
    {
        private int _Idingreso;
        private string _NumeroDocumento;
        private int _Idproveedor;
        private DateTime _FechaCompra;
        private decimal _Subtotal;
        private decimal _Impuestos;
        private decimal _Total;
        private string _Observaciones;
        private int _Idusuario;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public string NumeroDocumento { get => _NumeroDocumento; set => _NumeroDocumento = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime FechaCompra { get => _FechaCompra; set => _FechaCompra = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }
        public decimal Impuestos { get => _Impuestos; set => _Impuestos = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }

        public DIngreso() { }

        // Método Insertar
        public string Insertar(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNumeroDocumento = new SqlParameter();
                ParNumeroDocumento.ParameterName = "@NumeroDocumento";
                ParNumeroDocumento.SqlDbType = SqlDbType.NVarChar;
                ParNumeroDocumento.Size = 50;
                ParNumeroDocumento.Value = Ingreso.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumeroDocumento);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFechaCompra = new SqlParameter();
                ParFechaCompra.ParameterName = "@FechaCompra";
                ParFechaCompra.SqlDbType = SqlDbType.DateTime;
                ParFechaCompra.Value = Ingreso.FechaCompra;
                SqlCmd.Parameters.Add(ParFechaCompra);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@Subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Precision = 18;
                ParSubtotal.Scale = 2;
                ParSubtotal.Value = Ingreso.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);

                SqlParameter ParImpuestos = new SqlParameter();
                ParImpuestos.ParameterName = "@Impuestos";
                ParImpuestos.SqlDbType = SqlDbType.Decimal;
                ParImpuestos.Precision = 18;
                ParImpuestos.Scale = 2;
                ParImpuestos.Value = Ingreso.Impuestos;
                SqlCmd.Parameters.Add(ParImpuestos);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@Total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Precision = 18;
                ParTotal.Scale = 2;
                ParTotal.Value = Ingreso.Total;
                SqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@Observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NVarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Ingreso.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Ingreso.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

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

        // Método Editar
        public string Editar(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EditarIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParNumeroDocumento = new SqlParameter();
                ParNumeroDocumento.ParameterName = "@NumeroDocumento";
                ParNumeroDocumento.SqlDbType = SqlDbType.NVarChar;
                ParNumeroDocumento.Size = 50;
                ParNumeroDocumento.Value = Ingreso.NumeroDocumento;
                SqlCmd.Parameters.Add(ParNumeroDocumento);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFechaCompra = new SqlParameter();
                ParFechaCompra.ParameterName = "@FechaCompra";
                ParFechaCompra.SqlDbType = SqlDbType.DateTime;
                ParFechaCompra.Value = Ingreso.FechaCompra;
                SqlCmd.Parameters.Add(ParFechaCompra);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@Subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Precision = 18;
                ParSubtotal.Scale = 2;
                ParSubtotal.Value = Ingreso.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);

                SqlParameter ParImpuestos = new SqlParameter();
                ParImpuestos.ParameterName = "@Impuestos";
                ParImpuestos.SqlDbType = SqlDbType.Decimal;
                ParImpuestos.Precision = 18;
                ParImpuestos.Scale = 2;
                ParImpuestos.Value = Ingreso.Impuestos;
                SqlCmd.Parameters.Add(ParImpuestos);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@Total";
                ParTotal.SqlDbType = SqlDbType.Decimal;
                ParTotal.Precision = 18;
                ParTotal.Scale = 2;
                ParTotal.Value = Ingreso.Total;
                SqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@Observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NVarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Ingreso.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Ingreso.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizó el Registro";
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

        // Método Anular
        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_AnularIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdIngreso);

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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarIngreso";
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

        // Método BuscarFechas
        public DataTable BuscarFechas(string FechaInicio, string FechaFin)
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_BuscarIngresoFechas";
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
            }
            return DtResultado;
        }
    }
}