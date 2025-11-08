using CampoArgentino.Presentacion;
using OfficeOpenXml;
using System;
using System.Windows.Forms;


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