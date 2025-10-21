using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DProveedor
    {
        private int _Idproveedor;
        private string _Nombre;
        private string _CUIT;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string CUIT { get => _CUIT; set => _CUIT = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DProveedor() { }

        public DProveedor(int idproveedor, string nombre, string cuit, string direccion, string telefono, string email, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Nombre = nombre;
            this.CUIT = cuit;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }

        // Método Insertar
        public string Insertar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Proveedor.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCUIT = new SqlParameter();
                ParCUIT.ParameterName = "@CUIT";
                ParCUIT.SqlDbType = SqlDbType.VarChar;
                ParCUIT.Size = 20;
                ParCUIT.Value = Proveedor.CUIT;
                SqlCmd.Parameters.Add(ParCUIT);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 255;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 20;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 100;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Editar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EditarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParProveedorID = new SqlParameter();
                ParProveedorID.ParameterName = "@idproveedor";
                ParProveedorID.SqlDbType = SqlDbType.Int;
                ParProveedorID.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParProveedorID);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Proveedor.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCUIT = new SqlParameter();
                ParCUIT.ParameterName = "@CUIT";
                ParCUIT.SqlDbType = SqlDbType.VarChar;
                ParCUIT.Size = 20;
                ParCUIT.Value = Proveedor.CUIT;
                SqlCmd.Parameters.Add(ParCUIT);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 255;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 20;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 100;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

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

        // Método Eliminar
        public string Eliminar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EliminarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParProveedorID = new SqlParameter();
                ParProveedorID.ParameterName = "@idproveedor";
                ParProveedorID.SqlDbType = SqlDbType.Int;
                ParProveedorID.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParProveedorID);

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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarProveedor";
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
        public DataTable BuscarNombre(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_BuscarProveedorNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@nombre";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
    }
}