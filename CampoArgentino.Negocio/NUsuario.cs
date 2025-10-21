using System;
using System.Data;
using CampoArgentino.Datos;

namespace CampoArgentino.Negocio
{
    public class NUsuario
    {
        // Método Insertar
        public static string Insertar(string nombreUsuario, string contrasena, string nombreCompleto)
        {
            DUsuario Obj = new DUsuario();
            Obj.NombreUsuario = nombreUsuario;
            Obj.Contrasena = contrasena;
            Obj.NombreCompleto = nombreCompleto;
            return Obj.Insertar(Obj);
        }

        // Método Editar
        public static string Editar(int idusuario, string nombreUsuario, string contrasena, string nombreCompleto, bool activo)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = idusuario;
            Obj.NombreUsuario = nombreUsuario;
            Obj.Contrasena = contrasena;
            Obj.NombreCompleto = nombreCompleto;
            Obj.Activo = activo;
            return Obj.Editar(Obj);
        }

        // Método Eliminar
        public static string Eliminar(int usuarioID)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = usuarioID;
            return Obj.Eliminar(Obj);
        }

        // Método Mostrar
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();
        }

        // Método BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        // Método Login
        public static DataTable Login(string nombreUsuario, string contrasena)
        {
            DUsuario Obj = new DUsuario();
            Obj.NombreUsuario = nombreUsuario;
            Obj.Contrasena = contrasena;
            return Obj.Login(Obj);
        }
    }
}