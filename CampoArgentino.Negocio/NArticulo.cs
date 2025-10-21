using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NArticulo
    {
        // Método Insertar actualizado
        public static string Insertar(int idcategoria, int idpresentacion, string codigo, string nombre,
                             string descripcion, string unidadbase, decimal factorconversion,
                             decimal stockminimo, decimal stockmaximo, decimal preciocompra,
                             decimal precioventa, decimal iva, bool activo)
        {
            DArticulo Obj = new DArticulo();
            // ... propiedades existentes
            Obj.Idpresentacion = idpresentacion;
            return Obj.Insertar(Obj);
        }

        // Método Editar actualizado
        public static string Editar(int idarticulo, int idcategoria, int idpresentacion, string codigo,
                           string nombre, string descripcion, string unidadbase,
                           decimal factorconversion, decimal stockminimo, decimal stockmaximo,
                           decimal preciocompra, decimal precioventa, decimal iva, bool activo)
        {
            DArticulo Obj = new DArticulo();
            // ... propiedades existentes
            Obj.Idpresentacion = idpresentacion;
            return Obj.Editar(Obj);
        }

        // Método Eliminar (sin cambios)
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }

        // Método Mostrar (sin cambios)
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        // Método BuscarNombre (sin cambios)
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
            return Obj.ActualizarStockIndividual(idarticulo, nuevoStock);
        }

        // Método para obtener reporte de conteo
        public static DataTable ReporteConteoInventario()
        {
            DArticulo Obj = new DArticulo();
            return Obj.ReporteConteoInventario();
        }

        // Método para iniciar conteo
        public static int IniciarConteoInventario(int idusuario, string observaciones)
        {
            DArticulo Obj = new DArticulo();
            return Obj.IniciarConteoInventario(idusuario, observaciones);
        }
    }
}