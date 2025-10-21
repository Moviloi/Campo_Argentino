using System;

namespace CampoArgentino.Entidades
{
    public class Compra
    {
        // Variables privadas
        private int _Idcompra;
        private string _NumeroDocumento;
        private int _Idproveedor;
        private DateTime _FechaCompra;
        private decimal _Subtotal;
        private decimal _Impuestos;
        private decimal _Total;
        private string _Observaciones;
        private int _Idusuario;
        private string _Estado;

        // Propiedades
        public int Idcompra
        {
            get { return _Idcompra; }
            set { _Idcompra = value; }
        }

        public string NumeroDocumento
        {
            get { return _NumeroDocumento; }
            set { _NumeroDocumento = value; }
        }

        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }

        public DateTime FechaCompra
        {
            get { return _FechaCompra; }
            set { _FechaCompra = value; }
        }

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        public decimal Impuestos
        {
            get { return _Impuestos; }
            set { _Impuestos = value; }
        }

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        // Constructores
        public Compra()
        {
        }

        public Compra(int idcompra, string numeroDocumento, int idproveedor, DateTime fechaCompra,
                     decimal subtotal, decimal impuestos, decimal total, string observaciones,
                     int idusuario, string estado)
        {
            this._Idcompra = idcompra;
            this._NumeroDocumento = numeroDocumento;
            this._Idproveedor = idproveedor;
            this._FechaCompra = fechaCompra;
            this._Subtotal = subtotal;
            this._Impuestos = impuestos;
            this._Total = total;
            this._Observaciones = observaciones;
            this._Idusuario = idusuario;
            this._Estado = estado;
        }
    }
}