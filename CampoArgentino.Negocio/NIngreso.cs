using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NIngreso
    {
        // Método Insertar
        public static string Insertar(string NumeroDocumento, int Idproveedor, DateTime FechaCompra,
                                     decimal Subtotal, decimal Impuestos, decimal Total,
                                     string Observaciones, int Idusuario)
        {
            DIngreso Obj = new DIngreso();
            Obj.NumeroDocumento = NumeroDocumento;
            Obj.Idproveedor = Idproveedor;
            Obj.FechaCompra = FechaCompra;
            Obj.Subtotal = Subtotal;
            Obj.Impuestos = Impuestos;
            Obj.Total = Total;
            Obj.Observaciones = Observaciones;
            Obj.Idusuario = Idusuario;
            return Obj.Insertar(Obj);
        }

        // Método Editar
        public static string Editar(int Idingreso, string NumeroDocumento, int Idproveedor,
                                   DateTime FechaCompra, decimal Subtotal, decimal Impuestos,
                                   decimal Total, string Observaciones, int Idusuario)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = Idingreso;
            Obj.NumeroDocumento = NumeroDocumento;
            Obj.Idproveedor = Idproveedor;
            Obj.FechaCompra = FechaCompra;
            Obj.Subtotal = Subtotal;
            Obj.Impuestos = Impuestos;
            Obj.Total = Total;
            Obj.Observaciones = Observaciones;
            Obj.Idusuario = Idusuario;
            return Obj.Editar(Obj);
        }

        // Método Anular
        public static string Anular(int Idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = Idingreso;
            return Obj.Anular(Obj);
        }

        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        // Método BuscarFechas
        public static DataTable BuscarFechas(string FechaInicio, string FechaFin)
        {
            return new DIngreso().BuscarFechas(FechaInicio, FechaFin);
        }

        // Método Insertar Ingreso Completo con Detalles
        public static string InsertarIngresoCompleto(string NumeroDocumento, int Idproveedor, DateTime FechaCompra,
            decimal Subtotal, decimal Impuestos, decimal Total, string Observaciones, int Idusuario, DataTable dtDetalle)
        {
            DIngreso Obj = new DIngreso()
            {
                NumeroDocumento = NumeroDocumento,
                Idproveedor = Idproveedor,
                FechaCompra = FechaCompra,
                Subtotal = Subtotal,
                Impuestos = Impuestos,
                Total = Total,
                Observaciones = Observaciones,
                Idusuario = Idusuario
            };
            return Obj.InsertarIngresoCompleto(Obj, dtDetalle);
        }
    }
}