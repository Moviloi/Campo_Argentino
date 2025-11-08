using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DDetalleVenta
    {
        private int _Iddetalle;
        private int _Idventa;
        private int _Idarticulo;
        private decimal _Cantidad;
        private decimal _PrecioUnitario;
        private decimal _Subtotal;

        public int Iddetalle { get => _Iddetalle; set => _Iddetalle = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal PrecioUnitario { get => _PrecioUnitario; set => _PrecioUnitario = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }

        public DDetalleVenta() { }

        public DDetalleVenta(int iddetalle, int idventa, int idarticulo, decimal cantidad,
                           decimal precioUnitario, decimal subtotal)
        {
            this.Iddetalle = iddetalle;
            this.Idventa = idventa;
            this.Idarticulo = idarticulo;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.Subtotal = subtotal;
        }

        // Método Insertar
        public string Insertar(DDetalleVenta Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarDetalleVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 10;
                ParCantidad.Scale = 2;
                ParCantidad.Value = Detalle.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioUnitario = new SqlParameter();
                ParPrecioUnitario.ParameterName = "@precioUnitario";
                ParPrecioUnitario.SqlDbType = SqlDbType.Decimal;
                ParPrecioUnitario.Precision = 18;
                ParPrecioUnitario.Scale = 2;
                ParPrecioUnitario.Value = Detalle.PrecioUnitario;
                SqlCmd.Parameters.Add(ParPrecioUnitario);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Decimal;
                ParSubtotal.Precision = 18;
                ParSubtotal.Scale = 2;
                ParSubtotal.Value = Detalle.Subtotal;
                SqlCmd.Parameters.Add(ParSubtotal);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Detalle";
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

        // Método Mostrar Detalle por Venta
        public DataTable MostrarDetalle(int idventa)
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

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = idventa;
                SqlCmd.Parameters.Add(ParIdventa);

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