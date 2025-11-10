using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NVenta
    {
        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        // Método Insertar
        public static string Insertar(string NumeroDocumento, int Idcliente, DateTime FechaVenta,
                                    decimal Subtotal, decimal Impuestos, decimal Total,
                                    string Observaciones, int Idusuario)
        {
            DVenta Obj = new DVenta();
            Obj.NumeroDocumento = NumeroDocumento;
            Obj.Idcliente = Idcliente;
            Obj.FechaVenta = FechaVenta;
            Obj.Subtotal = Subtotal;
            Obj.Impuestos = Impuestos;
            Obj.Total = Total;
            Obj.Observaciones = Observaciones;
            Obj.Idusuario = Idusuario;

            return Obj.Insertar(Obj);
        }

        // Método Anular
        public static string Anular(int Idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = Idventa;
            return Obj.Anular(Obj);
        }

        // Método Buscar por Fechas
        public static DataTable BuscarFechas(string FechaInicio, string FechaFin)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(FechaInicio, FechaFin);
        }

        // Método Mostrar Detalle
        public static DataTable MostrarDetalle(int Idventa)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(Idventa);
        }


        // MÉTODOS PARA VENTA COMPLETA

        public static string InsertarVentaCompleta(string NumeroDocumento, int Idcliente, DateTime FechaVenta,
                decimal Subtotal, decimal Impuestos, decimal Total, string Observaciones, int Idusuario, DataTable dtDetalle)
        {
            DVenta Obj = new DVenta()
            {
                NumeroDocumento = NumeroDocumento,
                Idcliente = Idcliente,
                FechaVenta = FechaVenta,
                Subtotal = Subtotal,
                Impuestos = Impuestos,
                Total = Total,
                Observaciones = Observaciones,
                Idusuario = Idusuario
            };
            return Obj.InsertarVentaCompleta(Obj, dtDetalle);
        }

        public static string ObtenerProximoNumeroDocumento()
        {
            return new DVenta().ObtenerProximoNumeroDocumento();
        }

        public static DataTable VentasPorArticulo()
        {
            return new DVenta().VentasPorArticulo(); 
        }

        public static DataTable VentasArticuloPorCliente(int idArticulo)
        {
            return new DVenta().VentasArticuloPorCliente(idArticulo);
        }

        public static DataTable ComprasClientePorArticulo(int idCliente)
        {
            return new DVenta().ComprasClientePorArticulo(idCliente);
        }

        public static DataTable TotalComprasCliente(int idCliente)
        {
            return new DVenta().TotalComprasCliente(idCliente);
        }


    }


    }

