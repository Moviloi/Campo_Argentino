using System;

namespace CampoArgentino.Entidades
{
    public class ECliente
    {
        public int Idcliente { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}