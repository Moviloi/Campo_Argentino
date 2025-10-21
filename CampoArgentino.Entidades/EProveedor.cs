using System;

namespace CampoArgentino.Entidades
{
    public class EProveedor
    {
        public int Idproveedor { get; set; }
        public string RazonSocial { get; set; }
        public string SectorComercial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public bool Estado { get; set; }
    }
}