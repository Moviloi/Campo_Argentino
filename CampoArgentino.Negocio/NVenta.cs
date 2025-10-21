using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NVenta
    {
        // Método Insertar
        public static string Insertar(string numeroDocumento, int idcliente, DateTime fechaVenta,
                                     decimal subtotal, decimal impuestos, decimal total,
                                     string observaciones, int idusuario)
        {
            DVenta Obj = new DVenta();
            Obj.NumeroDocumento = numeroDocumento;
            Obj.Idcliente = idcliente;
            Obj.FechaVenta = fechaVenta;
            Obj.Subtotal = subtotal;
            Obj.Impuestos = impuestos;
            Obj.Total = total;
            Obj.Observaciones = observaciones;
            Obj.Idusuario = idusuario;
            return Obj.Insertar(Obj);
        }

        // Método Anular
        public static string Anular(int ventaID)
        {
            DVenta Obj = new DVenta();
            Obj.VentaID = ventaID;
            return Obj.Anular(Obj);
        }

        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        // Método Buscar por Fechas
        public static DataTable BuscarFechas(string fechaInicio, string fechaFin)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(fechaInicio, fechaFin);
        }

        // Método Mostrar Detalle
        public static DataTable MostrarDetalle(int ventaID)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(ventaID);
        }
    }
}