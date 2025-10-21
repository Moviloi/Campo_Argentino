using System;

namespace CampoArgentino.Entidades
{
    public class EProducto
    {
        private int _IdProducto;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private int _IdCategoria;
        private string _UnidadBase;
        private decimal _FactorConversion;
        private decimal _StockMinimo;
        private decimal _StockMaximo;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private decimal _IVA;
        private bool _Activo;

        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string UnidadBase { get => _UnidadBase; set => _UnidadBase = value; }
        public decimal FactorConversion { get => _FactorConversion; set => _FactorConversion = value; }
        public decimal StockMinimo { get => _StockMinimo; set => _StockMinimo = value; }
        public decimal StockMaximo { get => _StockMaximo; set => _StockMaximo = value; }
        public decimal PrecioCompra { get => _PrecioCompra; set => _PrecioCompra = value; }
        public decimal PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public decimal IVA { get => _IVA; set => _IVA = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }

        public EProducto()
        {
        }

        public EProducto(int idproducto, string codigo, string nombre, string descripcion, int idcategoria,
                       string unidadbase, decimal factorconversion, decimal stockminimo, decimal stockmaximo,
                       decimal preciocompra, decimal precioventa, decimal iva, bool activo)
        {
            this.IdProducto = idproducto;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.IdCategoria = idcategoria;
            this.UnidadBase = unidadbase;
            this.FactorConversion = factorconversion;
            this.StockMinimo = stockminimo;
            this.StockMaximo = stockmaximo;
            this.PrecioCompra = preciocompra;
            this.PrecioVenta = precioventa;
            this.IVA = iva;
            this.Activo = activo;
        }
    }
}