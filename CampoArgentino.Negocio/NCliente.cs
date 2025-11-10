using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NCliente
    {
        // Método Insertar
        public static string Insertar(string nombre, string cuit, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.CUIT = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Insertar(Obj);
        }

        // Método Editar
        public static string Editar(int idcliente, string nombre, string cuit, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.CUIT = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        // Método Eliminar
        public static string Eliminar(int clienteID)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = clienteID;
            return Obj.Eliminar(Obj);
        }

        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        // Método BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static DataTable MostrarClientesConVentas()
        {
            return new DCliente().MostrarClientesConVentas();
        }
    }
}