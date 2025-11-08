using System;
using System.Data;
using System.Data.SqlClient;

// prueba git

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
        private int _Idpresentacion;
        private string _TextoBuscar;
        private string _ImagenUrl;

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
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string ImagenUrl { get => _ImagenUrl; set => _ImagenUrl = value; }

        public DArticulo() { }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion,
                        string unidadbase, decimal factorconversion, decimal stockminimo,
                        decimal stockmaximo, decimal preciocompra, decimal precioventa,
                        decimal iva, bool activo, int idcategoria, int idpresentacion,
                        string textobuscar, string imagenUrl = null)
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
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
            this.ImagenUrl = imagenUrl;
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
                SqlCmd.CommandText = "spCampoArgentino_InsertarArticuloConImagen";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros para artículo
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
                ParDescripcion.Value = Articulo.Descripcion ?? (object)DBNull.Value;
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

                SqlParameter ParImagenUrl = new SqlParameter();
                ParImagenUrl.ParameterName = "@imagenurl";
                ParImagenUrl.SqlDbType = SqlDbType.NVarChar;
                ParImagenUrl.Size = 500;
                ParImagenUrl.Value = Articulo.ImagenUrl ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParImagenUrl);

                // Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el artículo";

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
                SqlCmd.CommandText = "spCampoArgentino_EditarArticuloConImagen";
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
                ParDescripcion.Value = Articulo.Descripcion ?? (object)DBNull.Value;
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

                SqlParameter ParImagenUrl = new SqlParameter();
                ParImagenUrl.ParameterName = "@imagenurl";
                ParImagenUrl.SqlDbType = SqlDbType.NVarChar;
                ParImagenUrl.Size = 500;
                ParImagenUrl.Value = Articulo.ImagenUrl ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParImagenUrl);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el artículo";

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

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el artículo";

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

        // Método para actualizar stock individual
        public string ActualizarStock(int idarticulo, decimal nuevoStock)
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

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParNuevoStock = new SqlParameter();
                ParNuevoStock.ParameterName = "@NuevoStock";
                ParNuevoStock.SqlDbType = SqlDbType.Decimal;
                ParNuevoStock.Precision = 10;
                ParNuevoStock.Scale = 2;
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

        // Método para obtener artículo con imagen
        public DataTable ObtenerArticuloConImagen(int idarticulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ObtenerArticuloConImagen";
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
            }
            return DtResultado;
        }

        // Método para actualizar solo la imagen
        public string ActualizarImagen(int idarticulo, string imagenUrl)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ActualizarImagenArticulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParImagenUrl = new SqlParameter();
                ParImagenUrl.ParameterName = "@ImagenUrl";
                ParImagenUrl.SqlDbType = SqlDbType.NVarChar;
                ParImagenUrl.Size = 500;
                ParImagenUrl.Value = imagenUrl ?? (object)DBNull.Value;
                SqlCmd.Parameters.Add(ParImagenUrl);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizó la imagen";
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

        //Método para reporte de stock bajo
        public DataTable ReporteStockBajo()
        {
            DataTable DtResultado = new DataTable("stock_bajo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_ReporteStockBajo";
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

        // Método para verificar stock
        public DataTable VerificarStock(int idarticulo, decimal cantidadRequerida)
        {
            DataTable DtResultado = new DataTable("verificar_stock");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spCampoArgentino_VerificarStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParCantidadRequerida = new SqlParameter();
                ParCantidadRequerida.ParameterName = "@CantidadRequerida";
                ParCantidadRequerida.SqlDbType = SqlDbType.Decimal;
                ParCantidadRequerida.Precision = 10;
                ParCantidadRequerida.Scale = 2;
                ParCantidadRequerida.Value = cantidadRequerida;
                SqlCmd.Parameters.Add(ParCantidadRequerida);

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