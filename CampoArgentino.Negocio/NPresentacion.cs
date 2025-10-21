using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NPresentacion
    {
        // Método para mostrar todas las presentaciones activas
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
    }
}