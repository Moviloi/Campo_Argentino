using System;
using System.Windows.Forms;
using CampoArgentino.Presentacion;

namespace CampoArgentino
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar el formulario de login primero
            FormLogin login = new FormLogin();
            login.ShowDialog();

           
        }
    }
}