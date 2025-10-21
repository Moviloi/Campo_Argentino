using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DInventario
    {
        public DataTable ReporteConteoInventario()
        {
            DataTable DtResultado = new DataTable("conteo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ReporteConteoInventario";
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

        public string ActualizarStockIndividual(int idarticulo, decimal nuevoStock)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ActualizarStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParNuevoStock = new SqlParameter("@NuevoStock", SqlDbType.Decimal);
                ParNuevoStock.Value = nuevoStock;
                SqlCmd.Parameters.Add(ParNuevoStock);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizó el stock";
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

        public int IniciarConteoInventario(int idusuario, string observaciones)
        {
            int idconteo = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_IniciarConteoInventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter("@idusuario", SqlDbType.Int);
                ParIdusuario.Value = idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParObservaciones = new SqlParameter("@Observaciones", SqlDbType.NVarChar, 500);
                ParObservaciones.Value = observaciones ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParObservaciones);

                idconteo = Convert.ToInt32(SqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                idconteo = 0;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return idconteo;
        }

        public string AgregarDetalleConteo(int idconteo, int idarticulo, decimal stockFisico)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_AgregarDetalleConteo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdconteo = new SqlParameter("@idconteo", SqlDbType.Int);
                ParIdconteo.Value = idconteo;
                SqlCmd.Parameters.Add(ParIdconteo);

                SqlParameter ParIdarticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParStockFisico = new SqlParameter("@StockFisico", SqlDbType.Decimal);
                ParStockFisico.Value = stockFisico;
                SqlCmd.Parameters.Add(ParStockFisico);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se agregó el detalle";
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

        public string ProcesarConteo(int idconteo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ProcesarConteo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdconteo = new SqlParameter("@idconteo", SqlDbType.Int);
                ParIdconteo.Value = idconteo;
                SqlCmd.Parameters.Add(ParIdconteo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se procesó el conteo";
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

        public DataTable ObtenerDetalleConteo(int idconteo)
        {
            DataTable DtResultado = new DataTable("detalle");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ObtenerDetalleConteo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdconteo = new SqlParameter("@idconteo", SqlDbType.Int);
                ParIdconteo.Value = idconteo;
                SqlCmd.Parameters.Add(ParIdconteo);

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