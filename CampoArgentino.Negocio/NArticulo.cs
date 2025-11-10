using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NArticulo
    {
        // Método Insertar
        public static string Insertar(int idcategoria, int idpresentacion, string codigo, string nombre,
                             string descripcion, string unidadbase, decimal factorconversion,
                             decimal stockminimo, decimal stockmaximo, decimal preciocompra,
                             decimal precioventa, decimal iva, bool activo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.UnidadBase = unidadbase;
            Obj.FactorConversion = factorconversion;
            Obj.StockMinimo = stockminimo;
            Obj.StockMaximo = stockmaximo;
            Obj.PrecioCompra = preciocompra;
            Obj.PrecioVenta = precioventa;
            Obj.Iva = iva;
            Obj.Activo = activo;
            return Obj.Insertar(Obj);
        }

        // Método Insertar con imagen
        public static string InsertarConImagen(int idcategoria, int idpresentacion, string codigo, string nombre,
                                      string descripcion, string unidadbase, decimal factorconversion,
                                      decimal stockminimo, decimal stockmaximo, decimal preciocompra,
                                      decimal precioventa, decimal iva, bool activo, string imagenUrl)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.UnidadBase = unidadbase;
            Obj.FactorConversion = factorconversion;
            Obj.StockMinimo = stockminimo;
            Obj.StockMaximo = stockmaximo;
            Obj.PrecioCompra = preciocompra;
            Obj.PrecioVenta = precioventa;
            Obj.Iva = iva;
            Obj.Activo = activo;
            Obj.ImagenUrl = imagenUrl;
            return Obj.Insertar(Obj);
        }

        // Método Editar
        public static string Editar(int idarticulo, int idcategoria, int idpresentacion, string codigo,
                           string nombre, string descripcion, string unidadbase,
                           decimal factorconversion, decimal stockminimo, decimal stockmaximo,
                           decimal preciocompra, decimal precioventa, decimal iva, bool activo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.UnidadBase = unidadbase;
            Obj.FactorConversion = factorconversion;
            Obj.StockMinimo = stockminimo;
            Obj.StockMaximo = stockmaximo;
            Obj.PrecioCompra = preciocompra;
            Obj.PrecioVenta = precioventa;
            Obj.Iva = iva;
            Obj.Activo = activo;
            return Obj.Editar(Obj);
        }

        // Método Editar con imagen
        public static string EditarConImagen(int idarticulo, int idcategoria, int idpresentacion, string codigo,
                                    string nombre, string descripcion, string unidadbase,
                                    decimal factorconversion, decimal stockminimo, decimal stockmaximo,
                                    decimal preciocompra, decimal precioventa, decimal iva, bool activo, string imagenUrl)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.UnidadBase = unidadbase;
            Obj.FactorConversion = factorconversion;
            Obj.StockMinimo = stockminimo;
            Obj.StockMaximo = stockmaximo;
            Obj.PrecioCompra = preciocompra;
            Obj.PrecioVenta = precioventa;
            Obj.Iva = iva;
            Obj.Activo = activo;
            Obj.ImagenUrl = imagenUrl;
            return Obj.Editar(Obj);
        }

        // Método Eliminar 
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }

        // Método Mostrar 
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        // Método BuscarNombre 
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        // Método para actualizar stock individual 
        public static string ActualizarStockIndividual(int idarticulo, decimal nuevoStock)
        {
            DArticulo Obj = new DArticulo();
            return Obj.ActualizarStock(idarticulo, nuevoStock);
        }

        // Método para obtener reporte de conteo 
        public static DataTable ReporteConteoInventario()
        {
            DInventario Obj = new DInventario();
            return Obj.ReporteConteoInventario();
        }

        // Método para iniciar conteo
        public static int IniciarConteoInventario(int idusuario, string observaciones)
        {

            return 0; // temporal 
        }

        // Método para obtener artículo con imagen
        public static DataTable ObtenerArticuloConImagen(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            return Obj.ObtenerArticuloConImagen(idarticulo);
        }

        // Método para actualizar solo la imagen
        public static string ActualizarImagen(int idarticulo, string imagenUrl)
        {
            DArticulo Obj = new DArticulo();
            return Obj.ActualizarImagen(idarticulo, imagenUrl);
        }

        // Método para reporte de stock bajo
        public static DataTable ReporteStockBajo()
        {
            DArticulo Obj = new DArticulo();
            return Obj.ReporteStockBajo();
        }

        // Método para verificar stock
        public static DataTable VerificarStock(int idarticulo, decimal cantidadRequerida)
        {
            DArticulo Obj = new DArticulo();
            return Obj.VerificarStock(idarticulo, cantidadRequerida);
        }

        // Método para actualizar stock
        public static string ActualizarStock(int idarticulo, decimal cantidad)
        {
            DArticulo Obj = new DArticulo();
            return Obj.ActualizarStock(idarticulo, cantidad);
        }
    }
}