using CampoArgentino.Datos;
using System;
using System.Data;

namespace CampoArgentino.Negocio
{
    public class NDetalleVenta
    {
        public static string Insertar(int idventa, int idarticulo, decimal cantidad,
                                    decimal precioUnitario, decimal subtotal)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.Idventa = idventa;
            Obj.Idarticulo = idarticulo;
            Obj.Cantidad = cantidad;
            Obj.PrecioUnitario = precioUnitario;
            Obj.Subtotal = subtotal;

            return Obj.Insertar(Obj);
        }

        public static DataTable MostrarDetalle(int idventa)
        {
            return new DDetalleVenta().MostrarDetalle(idventa);
        }
    }
}