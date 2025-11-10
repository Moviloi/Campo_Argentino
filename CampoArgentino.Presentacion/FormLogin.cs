using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla = NUsuario.Login(this.txtUsuario.Text.Trim(), this.txtPassword.Text.Trim());

                if (Tabla.Rows.Count <= 0)
                {
                    MensajeError("Usuario o Contraseña incorrectos");
                    this.txtUsuario.Clear();
                    this.txtPassword.Clear();
                    this.txtUsuario.Focus();
                }
                else
                {
                    if (Convert.ToBoolean(Tabla.Rows[0][4]) == false)
                    {
                        MensajeError("Este usuario no está activo");
                        this.txtUsuario.Clear();
                        this.txtPassword.Clear();
                        this.txtUsuario.Focus();
                    }
                    else
                    {
                        // Guardar información del usuario logueado
                        int idusuario = Convert.ToInt32(Tabla.Rows[0][0]);
                        string nombreUsuario = Convert.ToString(Tabla.Rows[0][1]);
                        string nombreCompleto = Convert.ToString(Tabla.Rows[0][3]);

                        // Establecer el resultado del diálogo como OK
                        this.DialogResult = DialogResult.OK;

                        // Ocultar el formulario de login en lugar de cerrarlo
                        this.Hide();

                        // Crear y mostrar el formulario principal
                        FormPrincipal frm = new FormPrincipal(idusuario, nombreUsuario, nombreCompleto);
                        frm.ShowDialog(); // Usar ShowDialog para mantener la aplicación abierta

                        // Cuando se cierre el FormPrincipal, cerrar la aplicación
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema Campo Argentino",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación completamente
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar.PerformClick();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

      
    }
}