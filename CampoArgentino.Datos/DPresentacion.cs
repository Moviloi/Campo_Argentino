using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DPresentacion
    {
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SELECT idpresentacion, Nombre, Descripcion FROM Presentacion WHERE Estado = 1 ORDER BY Nombre";
                SqlCmd.CommandType = CommandType.Text;

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