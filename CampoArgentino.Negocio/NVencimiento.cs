using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NVencimiento
    {
        // Método Insertar
        public static string Insertar(int idarticulo, DateTime fechaVencimiento, decimal cantidad,
                                     string numeroLote = null, DateTime? fechaFabricacion = null,
                                     string observaciones = null)
        {
            DVencimiento Obj = new DVencimiento();
            Obj.Idarticulo = idarticulo;
            Obj.FechaVencimiento = fechaVencimiento;
            Obj.Cantidad = cantidad;
            Obj.NumeroLote = numeroLote;
            Obj.FechaFabricacion = fechaFabricacion;
            Obj.Observaciones = observaciones;
            Obj.Estado = "VIGENTE";
            Obj.FechaRegistro = DateTime.Now;

            return Obj.Insertar(Obj);
        }

        // Método Editar
        public static string Editar(int idvencimiento, DateTime fechaVencimiento, decimal cantidad,
                                   string numeroLote = null, DateTime? fechaFabricacion = null,
                                   string observaciones = null)
        {
            DVencimiento Obj = new DVencimiento();
            Obj.Idvencimiento = idvencimiento;
            Obj.FechaVencimiento = fechaVencimiento;
            Obj.Cantidad = cantidad;
            Obj.NumeroLote = numeroLote;
            Obj.FechaFabricacion = fechaFabricacion;
            Obj.Observaciones = observaciones;

            return Obj.Editar(Obj);
        }

        // Método Eliminar
        public static string Eliminar(int idvencimiento)
        {
            DVencimiento Obj = new DVencimiento();
            Obj.Idvencimiento = idvencimiento;
            return Obj.Eliminar(Obj);
        }

        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DVencimiento().Mostrar();
        }

        // Método ObtenerAlertasVencimiento
        public static DataTable ObtenerAlertasVencimiento(int DiasAlerta = 30)
        {
            return new DVencimiento().ObtenerAlertasVencimiento(DiasAlerta);
        }

        // Método ObtenerVencimientosPorArticulo
        public static DataTable ObtenerVencimientosPorArticulo(int idarticulo)
        {
            return new DVencimiento().ObtenerVencimientosPorArticulo(idarticulo);
        }

        // Método ConsumirVencimiento
        public static string ConsumirVencimiento(int idvencimiento, decimal cantidad, int idventa = 0)
        {
            return new DVencimiento().ConsumirVencimiento(idvencimiento, cantidad, idventa);
        }

        // Método ActualizarVencimientos (automático)
        public static string ActualizarVencimientos()
        {
            return new DVencimiento().ActualizarVencimientos();
        }

        // Método GenerarAlertasVencimiento (automático)
        public static string GenerarAlertasVencimiento()
        {
            return new DVencimiento().GenerarAlertasVencimiento();
        }
    }
}