using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CampoArgentino.Datos
{
    public class DVencimiento
    {
        private int _Idvencimiento;
        private int _Idarticulo;
        private DateTime _FechaVencimiento;
        private decimal _Cantidad;
        private string _Estado;
        private DateTime _FechaRegistro;
        private string _Observaciones;
        private string _NumeroLote;
        private DateTime? _FechaFabricacion;
        private string _TextoBuscar;

        // Properties
        public int Idvencimiento { get => _Idvencimiento; set => _Idvencimiento = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public DateTime FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }
        public decimal Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public string NumeroLote { get => _NumeroLote; set => _NumeroLote = value; }
        public DateTime? FechaFabricacion { get => _FechaFabricacion; set => _FechaFabricacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DVencimiento() { }

        // Constructor completo
        public DVencimiento(int idvencimiento, int idarticulo, DateTime fechaVencimiento,
                           decimal cantidad, string estado, DateTime fechaRegistro,
                           string observaciones, string numeroLote, DateTime? fechaFabricacion)
        {
            this.Idvencimiento = idvencimiento;
            this.Idarticulo = idarticulo;
            this.FechaVencimiento = fechaVencimiento;
            this.Cantidad = cantidad;
            this.Estado = estado;
            this.FechaRegistro = fechaRegistro;
            this.Observaciones = observaciones;
            this.NumeroLote = numeroLote;
            this.FechaFabricacion = fechaFabricacion;
        }

        // Método Insertar - Siguiendo tu patrón de DArticulo
        public string Insertar(DVencimiento Vencimiento)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_RegistrarVencimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros
                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Vencimiento.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@FechaVencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = Vencimiento.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVencimiento);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 10;
                ParCantidad.Scale = 2;
                ParCantidad.Value = Vencimiento.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParNumeroLote = new SqlParameter();
                ParNumeroLote.ParameterName = "@NumeroLote";
                ParNumeroLote.SqlDbType = SqlDbType.NVarChar;
                ParNumeroLote.Size = 50;
                ParNumeroLote.Value = Vencimiento.NumeroLote ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParNumeroLote);

                SqlParameter ParFechaFabricacion = new SqlParameter();
                ParFechaFabricacion.ParameterName = "@FechaFabricacion";
                ParFechaFabricacion.SqlDbType = SqlDbType.Date;
                ParFechaFabricacion.Value = Vencimiento.FechaFabricacion ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParFechaFabricacion);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@Observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NVarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Vencimiento.Observaciones ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParObservaciones);

                // Usar ExecuteScalar para obtener respuesta consistente (como en DArticulo)
                object result = SqlCmd.ExecuteScalar();
                rpta = result != null ? result.ToString() : "No se recibió respuesta del servidor";

                if (rpta == "OK")
                {
                    return "OK";
                }
                else
                {
                    return "Error en base de datos: " + rpta;
                }
            }
            catch (Exception ex)
            {
                rpta = "Error al insertar vencimiento: " + ex.Message;
                return rpta;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        // Método Editar
        public string Editar(DVencimiento Vencimiento)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EditarVencimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros
                SqlParameter ParIdvencimiento = new SqlParameter();
                ParIdvencimiento.ParameterName = "@idvencimiento";
                ParIdvencimiento.SqlDbType = SqlDbType.Int;
                ParIdvencimiento.Value = Vencimiento.Idvencimiento;
                SqlCmd.Parameters.Add(ParIdvencimiento);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@FechaVencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = Vencimiento.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVencimiento);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 10;
                ParCantidad.Scale = 2;
                ParCantidad.Value = Vencimiento.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParNumeroLote = new SqlParameter();
                ParNumeroLote.ParameterName = "@NumeroLote";
                ParNumeroLote.SqlDbType = SqlDbType.NVarChar;
                ParNumeroLote.Size = 50;
                ParNumeroLote.Value = Vencimiento.NumeroLote ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParNumeroLote);

                SqlParameter ParFechaFabricacion = new SqlParameter();
                ParFechaFabricacion.ParameterName = "@FechaFabricacion";
                ParFechaFabricacion.SqlDbType = SqlDbType.Date;
                ParFechaFabricacion.Value = Vencimiento.FechaFabricacion ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParFechaFabricacion);

                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@Observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NVarChar;
                ParObservaciones.Size = 500;
                ParObservaciones.Value = Vencimiento.Observaciones ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParObservaciones);

                // Usar ExecuteScalar
                object result = SqlCmd.ExecuteScalar();
                rpta = result != null ? result.ToString() : "No se recibió respuesta del servidor";

                if (rpta == "OK")
                {
                    return "OK";
                }
                else
                {
                    return "Error en base de datos: " + rpta;
                }
            }
            catch (Exception ex)
            {
                rpta = "Error al editar vencimiento: " + ex.Message;
                return rpta;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        // Método Eliminar
        public string Eliminar(DVencimiento Vencimiento)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EliminarVencimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdvencimiento = new SqlParameter();
                ParIdvencimiento.ParameterName = "@idvencimiento";
                ParIdvencimiento.SqlDbType = SqlDbType.Int;
                ParIdvencimiento.Value = Vencimiento.Idvencimiento;
                SqlCmd.Parameters.Add(ParIdvencimiento);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el vencimiento";
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

        // Método Mostrar - Todos los vencimientos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Vencimiento");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarVencimientos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                Debug.WriteLine("Error en Mostrar Vencimientos: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }

        // Método ObtenerAlertasVencimiento
        public DataTable ObtenerAlertasVencimiento(int DiasAlerta = 30)
        {
            DataTable DtResultado = new DataTable("AlertasVencimiento");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ObtenerAlertasVencimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDiasAlerta = new SqlParameter();
                ParDiasAlerta.ParameterName = "@DiasAlerta";
                ParDiasAlerta.SqlDbType = SqlDbType.Int;
                ParDiasAlerta.Value = DiasAlerta;
                SqlCmd.Parameters.Add(ParDiasAlerta);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                Debug.WriteLine("Error en ObtenerAlertasVencimiento: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }

        // Método ObtenerVencimientosPorArticulo
        public DataTable ObtenerVencimientosPorArticulo(int idarticulo)
        {
            DataTable DtResultado = new DataTable("VencimientosArticulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ObtenerVencimientosPorArticulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
                Debug.WriteLine("Error en ObtenerVencimientosPorArticulo: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }

        // Método ConsumirVencimiento (para ventas)
        public string ConsumirVencimiento(int idvencimiento, decimal cantidad, int idventa = 0)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ConsumirVencimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdvencimiento = new SqlParameter();
                ParIdvencimiento.ParameterName = "@idvencimiento";
                ParIdvencimiento.SqlDbType = SqlDbType.Int;
                ParIdvencimiento.Value = idvencimiento;
                SqlCmd.Parameters.Add(ParIdvencimiento);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 10;
                ParCantidad.Scale = 2;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                // Usar ExecuteScalar
                object result = SqlCmd.ExecuteScalar();
                rpta = result != null ? result.ToString() : "No se recibió respuesta del servidor";

                if (rpta == "OK")
                {
                    return "OK";
                }
                else
                {
                    return "Error en base de datos: " + rpta;
                }
            }
            catch (Exception ex)
            {
                rpta = "Error al consumir vencimiento: " + ex.Message;
                return rpta;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        // Método ActualizarVencimientos (automático)
        public string ActualizarVencimientos()
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ActualizarVencimientos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Usar ExecuteScalar
                object result = SqlCmd.ExecuteScalar();
                rpta = result != null ? result.ToString() : "No se recibió respuesta del servidor";

                if (rpta == "OK")
                {
                    return "OK";
                }
                else
                {
                    return "Error en base de datos: " + rpta;
                }
            }
            catch (Exception ex)
            {
                rpta = "Error al actualizar vencimientos: " + ex.Message;
                return rpta;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        // Método GenerarAlertasVencimiento (automático)
        public string GenerarAlertasVencimiento()
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_GenerarAlertasVencimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Usar ExecuteScalar
                object result = SqlCmd.ExecuteScalar();
                rpta = result != null ? result.ToString() : "No se recibió respuesta del servidor";

                if (rpta == "OK")
                {
                    return "OK";
                }
                else
                {
                    return "Error en base de datos: " + rpta;
                }
            }
            catch (Exception ex)
            {
                rpta = "Error al generar alertas: " + ex.Message;
                return rpta;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}