using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DUsuario
    {
        private int _idusuario;
        private string _NombreUsuario;
        private string _Contrasena;
        private string _NombreCompleto;
        private bool _Activo;
        private string _TextoBuscar;

     
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public string NombreCompleto { get => _NombreCompleto; set => _NombreCompleto = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public int Idusuario { get => _idusuario; set => _idusuario = value; }

        public DUsuario() { }

        public DUsuario(int idusuario, string nombreUsuario, string contrasena, string nombreCompleto, bool activo, string textobuscar)
        {
            this.Idusuario = idusuario;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.NombreCompleto = nombreCompleto;
            this.Activo = activo;
            this.TextoBuscar = textobuscar;
        }

        // Método Insertar
        public string Insertar(DUsuario Usuario)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNombreUsuario = new SqlParameter();
                ParNombreUsuario.ParameterName = "@nombreUsuario";
                ParNombreUsuario.SqlDbType = SqlDbType.VarChar;
                ParNombreUsuario.Size = 50;
                ParNombreUsuario.Value = Usuario.NombreUsuario;
                SqlCmd.Parameters.Add(ParNombreUsuario);

                SqlParameter ParContrasena = new SqlParameter();
                ParContrasena.ParameterName = "@contrasena";
                ParContrasena.SqlDbType = SqlDbType.VarChar;
                ParContrasena.Size = 255;
                ParContrasena.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(ParContrasena);

                SqlParameter ParNombreCompleto = new SqlParameter();
                ParNombreCompleto.ParameterName = "@nombreCompleto";
                ParNombreCompleto.SqlDbType = SqlDbType.VarChar;
                ParNombreCompleto.Size = 100;
                ParNombreCompleto.Value = Usuario.NombreCompleto;
                SqlCmd.Parameters.Add(ParNombreCompleto);

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
        public string Editar(DUsuario Usuario)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EditarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParNombreUsuario = new SqlParameter();
                ParNombreUsuario.ParameterName = "@nombreUsuario";
                ParNombreUsuario.SqlDbType = SqlDbType.VarChar;
                ParNombreUsuario.Size = 50;
                ParNombreUsuario.Value = Usuario.NombreUsuario;
                SqlCmd.Parameters.Add(ParNombreUsuario);

                SqlParameter ParContrasena = new SqlParameter();
                ParContrasena.ParameterName = "@contrasena";
                ParContrasena.SqlDbType = SqlDbType.VarChar;
                ParContrasena.Size = 255;
                ParContrasena.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(ParContrasena);

                SqlParameter ParNombreCompleto = new SqlParameter();
                ParNombreCompleto.ParameterName = "@nombreCompleto";
                ParNombreCompleto.SqlDbType = SqlDbType.VarChar;
                ParNombreCompleto.Size = 100;
                ParNombreCompleto.Value = Usuario.NombreCompleto;
                SqlCmd.Parameters.Add(ParNombreCompleto);

                SqlParameter ParActivo = new SqlParameter();
                ParActivo.ParameterName = "@activo";
                ParActivo.SqlDbType = SqlDbType.Bit;
                ParActivo.Value = Usuario.Activo;
                SqlCmd.Parameters.Add(ParActivo);

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

        // Método Eliminar (eliminación lógica)
        public string Eliminar(DUsuario Usuario)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EliminarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Eliminó el Registro";
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
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarUsuario";
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

        // Método BuscarNombre
        public DataTable BuscarNombre(DUsuario Usuario)
        {
            DataTable DtResultado = new DataTable("Usuario");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_BuscarUsuarioNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@nombre";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.Value = Usuario.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Método Login
        public DataTable Login(DUsuario Usuario)
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNombreUsuario = new SqlParameter();
                ParNombreUsuario.ParameterName = "@nombreUsuario";
                ParNombreUsuario.SqlDbType = SqlDbType.VarChar;
                ParNombreUsuario.Size = 50;
                ParNombreUsuario.Value = Usuario.NombreUsuario;
                SqlCmd.Parameters.Add(ParNombreUsuario);

                SqlParameter ParContrasena = new SqlParameter();
                ParContrasena.ParameterName = "@contrasena";
                ParContrasena.SqlDbType = SqlDbType.VarChar;
                ParContrasena.Size = 255;
                ParContrasena.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(ParContrasena);

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