using System;
using System.Data;
using System.Data.SqlClient;

namespace CampoArgentino.Datos
{
    public class DArticulo
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private string _UnidadBase;
        private decimal _FactorConversion;
        private decimal _StockMinimo;
        private decimal _StockMaximo;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private decimal _Iva;
        private bool _Activo;
        private int _Idcategoria;
        private int _Idpresentacion; // Agregado para manejar la presentación
        private string _TextoBuscar;

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string UnidadBase { get => _UnidadBase; set => _UnidadBase = value; }
        public decimal FactorConversion { get => _FactorConversion; set => _FactorConversion = value; }
        public decimal StockMinimo { get => _StockMinimo; set => _StockMinimo = value; }
        public decimal StockMaximo { get => _StockMaximo; set => _StockMaximo = value; }
        public decimal PrecioCompra { get => _PrecioCompra; set => _PrecioCompra = value; }
        public decimal PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }

        public DArticulo() { }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion,
                        string unidadbase, decimal factorconversion, decimal stockminimo,
                        decimal stockmaximo, decimal preciocompra, decimal precioventa,
                        decimal iva, bool activo, int idcategoria, string textobuscar, int idpresentacion)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.UnidadBase = unidadbase;
            this.FactorConversion = factorconversion;
            this.StockMinimo = stockminimo;
            this.StockMaximo = stockmaximo;
            this.PrecioCompra = preciocompra;
            this.PrecioVenta = precioventa;
            this.Iva = iva;
            this.Activo = activo;
            this.Idcategoria = idcategoria;
            this.TextoBuscar = textobuscar;
            this.Idpresentacion = idpresentacion;
        }

        // Método Insertar
        public string Insertar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_InsertarArticulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParUnidadBase = new SqlParameter();
                ParUnidadBase.ParameterName = "@unidadbase";
                ParUnidadBase.SqlDbType = SqlDbType.VarChar;
                ParUnidadBase.Size = 50;
                ParUnidadBase.Value = Articulo.UnidadBase;
                SqlCmd.Parameters.Add(ParUnidadBase);

                SqlParameter ParFactorConversion = new SqlParameter();
                ParFactorConversion.ParameterName = "@factorconversion";
                ParFactorConversion.SqlDbType = SqlDbType.Decimal;
                ParFactorConversion.Precision = 11;
                ParFactorConversion.Scale = 2;
                ParFactorConversion.Value = Articulo.FactorConversion;
                SqlCmd.Parameters.Add(ParFactorConversion);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockminimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 11;
                ParStockMinimo.Scale = 2;
                ParStockMinimo.Value = Articulo.StockMinimo;
                SqlCmd.Parameters.Add(ParStockMinimo);

                SqlParameter ParStockMaximo = new SqlParameter();
                ParStockMaximo.ParameterName = "@stockmaximo";
                ParStockMaximo.SqlDbType = SqlDbType.Decimal;
                ParStockMaximo.Precision = 11;
                ParStockMaximo.Scale = 2;
                ParStockMaximo.Value = Articulo.StockMaximo;
                SqlCmd.Parameters.Add(ParStockMaximo);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@preciocompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Decimal;
                ParPrecioCompra.Precision = 11;
                ParPrecioCompra.Scale = 2;
                ParPrecioCompra.Value = Articulo.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioventa";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 11;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = Articulo.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParIva = new SqlParameter();
                ParIva.ParameterName = "@iva";
                ParIva.SqlDbType = SqlDbType.Decimal;
                ParIva.Precision = 4;
                ParIva.Scale = 2;
                ParIva.Value = Articulo.Iva;
                SqlCmd.Parameters.Add(ParIva);

                SqlParameter ParActivo = new SqlParameter();
                ParActivo.ParameterName = "@activo";
                ParActivo.SqlDbType = SqlDbType.Bit;
                ParActivo.Value = Articulo.Activo;
                SqlCmd.Parameters.Add(ParActivo);

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
        public string Editar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EditarArticulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParUnidadBase = new SqlParameter();
                ParUnidadBase.ParameterName = "@unidadbase";
                ParUnidadBase.SqlDbType = SqlDbType.VarChar;
                ParUnidadBase.Size = 50;
                ParUnidadBase.Value = Articulo.UnidadBase;
                SqlCmd.Parameters.Add(ParUnidadBase);

                SqlParameter ParFactorConversion = new SqlParameter();
                ParFactorConversion.ParameterName = "@factorconversion";
                ParFactorConversion.SqlDbType = SqlDbType.Decimal;
                ParFactorConversion.Precision = 11;
                ParFactorConversion.Scale = 2;
                ParFactorConversion.Value = Articulo.FactorConversion;
                SqlCmd.Parameters.Add(ParFactorConversion);

                SqlParameter ParStockMinimo = new SqlParameter();
                ParStockMinimo.ParameterName = "@stockminimo";
                ParStockMinimo.SqlDbType = SqlDbType.Decimal;
                ParStockMinimo.Precision = 11;
                ParStockMinimo.Scale = 2;
                ParStockMinimo.Value = Articulo.StockMinimo;
                SqlCmd.Parameters.Add(ParStockMinimo);

                SqlParameter ParStockMaximo = new SqlParameter();
                ParStockMaximo.ParameterName = "@stockmaximo";
                ParStockMaximo.SqlDbType = SqlDbType.Decimal;
                ParStockMaximo.Precision = 11;
                ParStockMaximo.Scale = 2;
                ParStockMaximo.Value = Articulo.StockMaximo;
                SqlCmd.Parameters.Add(ParStockMaximo);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@preciocompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Decimal;
                ParPrecioCompra.Precision = 11;
                ParPrecioCompra.Scale = 2;
                ParPrecioCompra.Value = Articulo.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioventa";
                ParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                ParPrecioVenta.Precision = 11;
                ParPrecioVenta.Scale = 2;
                ParPrecioVenta.Value = Articulo.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParIva = new SqlParameter();
                ParIva.ParameterName = "@iva";
                ParIva.SqlDbType = SqlDbType.Decimal;
                ParIva.Precision = 4;
                ParIva.Scale = 2;
                ParIva.Value = Articulo.Iva;
                SqlCmd.Parameters.Add(ParIva);

                SqlParameter ParActivo = new SqlParameter();
                ParActivo.ParameterName = "@activo";
                ParActivo.SqlDbType = SqlDbType.Bit;
                ParActivo.Value = Articulo.Activo;
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

        // Método Eliminar
        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_EliminarArticulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_MostrarArticulo";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_BuscarArticuloNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
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

        // Método para actualizar stock
        public string ActualizarStock(int idarticulo, decimal cantidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "UPDATE Articulo SET StockActual = StockActual + @cantidad WHERE idarticulo = @idarticulo";
                SqlCmd.CommandType = CommandType.Text;

                SqlParameter ParIdarticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParCantidad = new SqlParameter("@cantidad", SqlDbType.Decimal);
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

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

        // Método para obtener reporte de conteo
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

        // Método para actualizar stock individual
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

        // Método para iniciar conteo
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
    }
}