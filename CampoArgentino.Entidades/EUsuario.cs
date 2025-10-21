using System;

namespace CampoArgentino.Entidades
{
    public class EUsuario
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _NombreUsuario;
        private string _Password;
        private bool _Activo;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }

        public EUsuario()
        {
        }

        public EUsuario(int idusuario, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                      string num_documento, string direccion, string telefono, string email, string acceso,
                      string nombreusuario, string password, bool activo)
        {
            this.IdUsuario = idusuario;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.NombreUsuario = nombreusuario;
            this.Password = password;
            this.Activo = activo;
        }
    }
}