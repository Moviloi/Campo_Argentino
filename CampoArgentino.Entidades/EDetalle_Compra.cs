using System;

namespace CampoArgentino.Entidades
{
    public class EDetalle_Compra
    {
        // Variables privadas
        private int _Iddetalle_compra;
        private int _Idcompra;
        private int _Idproducto;
        private decimal _Cantidad;
        private decimal _Precio;
        private decimal _Descuento;

        // Propiedades
        public int Iddetalle_compra
        {
            get { return _Iddetalle_compra; }
            set { _Iddetalle_compra = value; }
        }

        public int Idcompra
        {
            get { return _Idcompra; }
            set { _Idcompra = value; }
        }

        public int Idproducto
        {
            get { return _Idproducto; }
            set { _Idproducto = value; }
        }

        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        // Propiedad calculada para el subtotal
        public decimal Subtotal
        {
            get { return (Cantidad * Precio) - Descuento; }
        }

        // Constructores
        public EDetalle_Compra()
        {
        }

        public EDetalle_Compra(int iddetalle_compra, int idcompra, int idproducto,
                            decimal cantidad, decimal precio, decimal descuento)
        {
            this._Iddetalle_compra = iddetalle_compra;
            this._Idcompra = idcompra;
            this._Idproducto = idproducto;
            this._Cantidad = cantidad;
            this._Precio = precio;
            this._Descuento = descuento;
        }
    }
}