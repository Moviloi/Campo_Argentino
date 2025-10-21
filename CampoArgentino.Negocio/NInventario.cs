using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NInventario
    {
        // Método para obtener reporte de conteo
        public static DataTable ReporteConteoInventario()
        {
            return new DInventario().ReporteConteoInventario();
        }

        // Método para actualizar stock individual
        public static string ActualizarStockIndividual(int idarticulo, decimal nuevoStock)
        {
            DInventario Obj = new DInventario();
            return Obj.ActualizarStockIndividual(idarticulo, nuevoStock);
        }

        // Método para iniciar conteo
        public static int IniciarConteoInventario(int idusuario, string observaciones)
        {
            DInventario Obj = new DInventario();
            return Obj.IniciarConteoInventario(idusuario, observaciones);
        }

        // Método para agregar detalle de conteo
        public static string AgregarDetalleConteo(int idconteo, int idarticulo, decimal stockFisico)
        {
            DInventario Obj = new DInventario();
            return Obj.AgregarDetalleConteo(idconteo, idarticulo, stockFisico);
        }

        // Método para procesar conteo
        public static string ProcesarConteo(int idconteo)
        {
            DInventario Obj = new DInventario();
            return Obj.ProcesarConteo(idconteo);
        }

        // Método para obtener detalle de conteo
        public static DataTable ObtenerDetalleConteo(int idconteo)
        {
            DInventario Obj = new DInventario();
            return Obj.ObtenerDetalleConteo(idconteo);
        }
    }
}