using System;
using System.Drawing;
using System.Windows.Forms;

namespace CampoArgentino.Presentacion
{
    public partial class FormPrincipal : Form
    {
        private int _idusuario;
        private string _nombreUsuario;
        private string _nombreCompleto;

        // Constructor con parámetros
        public FormPrincipal(int idusuario, string nombreUsuario, string nombreCompleto)
        {
            InitializeComponent();
            _idusuario = idusuario;
            _nombreUsuario = nombreUsuario;
            _nombreCompleto = nombreCompleto;
        }

        // Constructor vacío por compatibilidad
        public FormPrincipal() : this(0, "", "") { }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + _nombreCompleto;
            this.WindowState = FormWindowState.Maximized;
        }

        private void AbrirFormulario(Form formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(formHijo);
            this.panelContenedor.Tag = formHijo;
            formHijo.Show();
        }

        // ========== MÉTODOS DE MANTENIMIENTOS ==========
        private void btnArticulos_Click(object sender, EventArgs e)
        {
            FormArticulo frm = new FormArticulo();
            AbrirFormulario(frm);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuario frm = new FormUsuario();
            AbrirFormulario(frm);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormCliente frm = new FormCliente();
            AbrirFormulario(frm);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormProveedor frm = new FormProveedor();
            AbrirFormulario(frm);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormCategoria frm = new FormCategoria();
            AbrirFormulario(frm);
        }

        // ========== MÉTODOS DE OPERACIONES ==========
        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormIngreso frm = new FormIngreso();
            AbrirFormulario(frm);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVenta frm = new FormVenta();
            AbrirFormulario(frm);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormVistaArticulo_Venta frm = new FormVistaArticulo_Venta();
            AbrirFormularioEnPanel(frm);
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormVistaProveedor_Ingreso frm = new FormVistaProveedor_Ingreso();
            AbrirFormulario(frm);
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormVistaCliente_Venta frm = new FormVistaCliente_Venta();
            AbrirFormulario(frm);
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormVistaProveedor frm = new FormVistaProveedor();
            AbrirFormulario(frm);
        }

        private void artículosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormVistaArticulo frm = new FormVistaArticulo();
            AbrirFormulario(frm);
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlertaStock frm = new FormAlertaStock();
            AbrirFormulario(frm);
        }

        // ========== MÉTODOS DEL MENÚ QUE LLAMAN A LOS BOTONES ==========
        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnArticulos_Click(sender, e);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUsuarios_Click(sender, e);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClientes_Click(sender, e);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProveedores_Click(sender, e);
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCategorias_Click(sender, e);
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCompras_Click(sender, e);
        }

        // Método para el menú Inventario
        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormInventario());
        }

        // Método auxiliar para abrir formularios en el panel contenedor
        private void AbrirFormularioEnPanel(Form formHijo)
        {
            try
            {
                
                if (panelContenedor.Controls.Count > 0)
                {
                    Form formActual = panelContenedor.Controls[0] as Form;
                    if (formActual != null)
                    {
                        formActual.Close(); // Libera recursos correctamente
                    }
                    panelContenedor.Controls.Clear();
                }

                // Configurar el nuevo formulario
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                panelContenedor.Controls.Add(formHijo);
                panelContenedor.Tag = formHijo; // ✅ Útil para referencia futura
                formHijo.Show();
                formHijo.BringToFront(); // ✅ Asegura que esté visible
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuInventario_Click(object sender, EventArgs e)
        {
            FormInventario frm = new FormInventario();
            frm.MdiParent = this;
            frm.Show();

            // Tu método existente para abrir FormInventario
            AbrirFormulario(new FormInventario());
        }


        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVentas_Click(sender, e);
        }

        // ========== MÉTODOS DE SISTEMA ==========
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cerrar sesión?", "Sistema Campo Argentino",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin frm = new FormLogin();
                frm.Show();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de salir del sistema?", "Sistema Campo Argentino",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCerrarSesion_Click(sender, e);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema Campo Argentino\nVersión 1.0\nDesarrollado para gestión de inventario y ventas",
                "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     
    }
}