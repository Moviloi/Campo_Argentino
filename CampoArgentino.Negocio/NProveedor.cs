using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NProveedor
    {
        // Método Insertar
        public static string Insertar(string nombre, string cuit, string direccion, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();
            Obj.Nombre = nombre;
            Obj.CUIT = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Insertar(Obj);
        }

        // Método Editar
        public static string Editar(int idproveedor, string nombre, string cuit, string direccion, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Nombre = nombre;
            Obj.CUIT = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        // Método Eliminar
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }

        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        // Método BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}