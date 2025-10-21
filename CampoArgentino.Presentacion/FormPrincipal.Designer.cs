namespace CampoArgentino.Presentacion
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem mantenimientosToolStripMenuItem;
        private ToolStripMenuItem artículosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem categoríasToolStripMenuItem;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem comprasToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem1;
        private ToolStripMenuItem comprasToolStripMenuItem1;
        private ToolStripMenuItem clientesToolStripMenuItem1;
        private ToolStripMenuItem proveedoresToolStripMenuItem1;
        private ToolStripMenuItem artículosToolStripMenuItem1;
        private ToolStripMenuItem stockToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblUsuario;
        private Panel panelContenedor;
        private ToolStrip toolStrip1;
        private ToolStripButton btnArticulos;
        private ToolStripButton btnUsuarios;
        private ToolStripButton btnClientes;
        private ToolStripButton btnProveedores;
        private ToolStripButton btnCategorias;
        private ToolStripButton btnCompras;
        private ToolStripButton btnVentas;
        private ToolStripButton btnConsultas;
        private ToolStripButton btnInventario;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnCerrarSesion;
        private ToolStripButton btnSalir;
        private Panel panelHeader;
        private Label lblTituloPrincipal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            mantenimientosToolStripMenuItem = new ToolStripMenuItem();
            artículosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            categoríasToolStripMenuItem = new ToolStripMenuItem();
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            comprasToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem1 = new ToolStripMenuItem();
            comprasToolStripMenuItem1 = new ToolStripMenuItem();
            clientesToolStripMenuItem1 = new ToolStripMenuItem();
            proveedoresToolStripMenuItem1 = new ToolStripMenuItem();
            artículosToolStripMenuItem1 = new ToolStripMenuItem();
            stockToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUsuario = new ToolStripStatusLabel();
            panelContenedor = new Panel();
            toolStrip1 = new ToolStrip();
            btnArticulos = new ToolStripButton();
            btnUsuarios = new ToolStripButton();
            btnClientes = new ToolStripButton();
            btnProveedores = new ToolStripButton();
            btnCategorias = new ToolStripButton();
            btnCompras = new ToolStripButton();
            btnVentas = new ToolStripButton();
            btnConsultas = new ToolStripButton();
            btnInventario = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnCerrarSesion = new ToolStripButton();
            btnSalir = new ToolStripButton();
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            lblTituloPrincipal = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(52, 73, 94);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, mantenimientosToolStripMenuItem, operacionesToolStripMenuItem, consultasToolStripMenuItem, inventarioToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1200, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.ForeColor = Color.White;
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            cerrarSesiónToolStripMenuItem.Size = new Size(228, 26);
            cerrarSesiónToolStripMenuItem.Text = "&Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            salirToolStripMenuItem.Size = new Size(228, 26);
            salirToolStripMenuItem.Text = "&Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // mantenimientosToolStripMenuItem
            // 
            mantenimientosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { artículosToolStripMenuItem, usuariosToolStripMenuItem, clientesToolStripMenuItem, proveedoresToolStripMenuItem, categoríasToolStripMenuItem });
            mantenimientosToolStripMenuItem.ForeColor = Color.White;
            mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            mantenimientosToolStripMenuItem.Size = new Size(130, 24);
            mantenimientosToolStripMenuItem.Text = "&Mantenimientos";
            // 
            // artículosToolStripMenuItem
            // 
            artículosToolStripMenuItem.Name = "artículosToolStripMenuItem";
            artículosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            artículosToolStripMenuItem.Size = new Size(224, 26);
            artículosToolStripMenuItem.Text = "&Artículos";
            artículosToolStripMenuItem.Click += artículosToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
            usuariosToolStripMenuItem.Size = new Size(224, 26);
            usuariosToolStripMenuItem.Text = "&Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            clientesToolStripMenuItem.Size = new Size(224, 26);
            clientesToolStripMenuItem.Text = "&Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            proveedoresToolStripMenuItem.Size = new Size(224, 26);
            proveedoresToolStripMenuItem.Text = "&Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // categoríasToolStripMenuItem
            // 
            categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            categoríasToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            categoríasToolStripMenuItem.Size = new Size(224, 26);
            categoríasToolStripMenuItem.Text = "&Categorías";
            categoríasToolStripMenuItem.Click += categoríasToolStripMenuItem_Click;
            // 
            // operacionesToolStripMenuItem
            // 
            operacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { comprasToolStripMenuItem, ventasToolStripMenuItem });
            operacionesToolStripMenuItem.ForeColor = Color.White;
            operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            operacionesToolStripMenuItem.Size = new Size(106, 24);
            operacionesToolStripMenuItem.Text = "&Operaciones";
            // 
            // comprasToolStripMenuItem
            // 
            comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            comprasToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            comprasToolStripMenuItem.Size = new Size(204, 26);
            comprasToolStripMenuItem.Text = "&Compras";
            comprasToolStripMenuItem.Click += comprasToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            ventasToolStripMenuItem.Size = new Size(204, 26);
            ventasToolStripMenuItem.Text = "&Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ventasToolStripMenuItem1, comprasToolStripMenuItem1, clientesToolStripMenuItem1, proveedoresToolStripMenuItem1, artículosToolStripMenuItem1, stockToolStripMenuItem });
            consultasToolStripMenuItem.ForeColor = Color.White;
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(86, 24);
            consultasToolStripMenuItem.Text = "&Consultas";
            // 
            // ventasToolStripMenuItem1
            // 
            ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            ventasToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.F1;
            ventasToolStripMenuItem1.Size = new Size(231, 26);
            ventasToolStripMenuItem1.Text = "&Ventas";
            ventasToolStripMenuItem1.Click += ventasToolStripMenuItem1_Click;
            // 
            // comprasToolStripMenuItem1
            // 
            comprasToolStripMenuItem1.Name = "comprasToolStripMenuItem1";
            comprasToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.F2;
            comprasToolStripMenuItem1.Size = new Size(231, 26);
            comprasToolStripMenuItem1.Text = "&Compras";
            comprasToolStripMenuItem1.Click += comprasToolStripMenuItem1_Click;
            // 
            // clientesToolStripMenuItem1
            // 
            clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            clientesToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.F3;
            clientesToolStripMenuItem1.Size = new Size(231, 26);
            clientesToolStripMenuItem1.Text = "&Clientes";
            clientesToolStripMenuItem1.Click += clientesToolStripMenuItem1_Click;
            // 
            // proveedoresToolStripMenuItem1
            // 
            proveedoresToolStripMenuItem1.Name = "proveedoresToolStripMenuItem1";
            proveedoresToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.F4;
            proveedoresToolStripMenuItem1.Size = new Size(231, 26);
            proveedoresToolStripMenuItem1.Text = "&Proveedores";
            proveedoresToolStripMenuItem1.Click += proveedoresToolStripMenuItem1_Click;
            // 
            // artículosToolStripMenuItem1
            // 
            artículosToolStripMenuItem1.Name = "artículosToolStripMenuItem1";
            artículosToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.F5;
            artículosToolStripMenuItem1.Size = new Size(231, 26);
            artículosToolStripMenuItem1.Text = "&Artículos";
            artículosToolStripMenuItem1.Click += artículosToolStripMenuItem1_Click;
            // 
            // stockToolStripMenuItem
            // 
            stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            stockToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F6;
            stockToolStripMenuItem.Size = new Size(231, 26);
            stockToolStripMenuItem.Text = "&Stock";
            stockToolStripMenuItem.Click += stockToolStripMenuItem_Click;
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.ForeColor = Color.White;
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            inventarioToolStripMenuItem.Size = new Size(89, 24);
            inventarioToolStripMenuItem.Text = "&Inventario";
            inventarioToolStripMenuItem.Click += inventarioToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.ForeColor = Color.White;
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(158, 26);
            acercaDeToolStripMenuItem.Text = "&Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(248, 249, 250);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblUsuario });
            statusStrip1.Location = new Point(0, 823);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1200, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(52, 73, 94);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(66, 20);
            lblUsuario.Text = "Usuario: ";
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 117);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1200, 706);
            panelContenedor.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnArticulos, btnUsuarios, btnClientes, btnProveedores, btnCategorias, btnCompras, btnVentas, btnConsultas, btnInventario, toolStripSeparator1, btnCerrarSesion, btnSalir });
            toolStrip1.Location = new Point(0, 90);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1200, 27);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnArticulos
            // 
            btnArticulos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnArticulos.ForeColor = Color.FromArgb(52, 73, 94);
            btnArticulos.ImageTransparentColor = Color.Magenta;
            btnArticulos.Margin = new Padding(5, 1, 0, 2);
            btnArticulos.Name = "btnArticulos";
            btnArticulos.Size = new Size(71, 24);
            btnArticulos.Text = "Artículos";
            btnArticulos.Click += btnArticulos_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUsuarios.ForeColor = Color.FromArgb(52, 73, 94);
            btnUsuarios.ImageTransparentColor = Color.Magenta;
            btnUsuarios.Margin = new Padding(10, 1, 0, 2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(69, 24);
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.FromArgb(52, 73, 94);
            btnClientes.ImageTransparentColor = Color.Magenta;
            btnClientes.Margin = new Padding(10, 1, 0, 2);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(65, 24);
            btnClientes.Text = "Clientes";
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProveedores.ForeColor = Color.FromArgb(52, 73, 94);
            btnProveedores.ImageTransparentColor = Color.Magenta;
            btnProveedores.Margin = new Padding(10, 1, 0, 2);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(95, 24);
            btnProveedores.Text = "Proveedores";
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCategorias.ForeColor = Color.FromArgb(52, 73, 94);
            btnCategorias.ImageTransparentColor = Color.Magenta;
            btnCategorias.Margin = new Padding(10, 1, 0, 2);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(84, 24);
            btnCategorias.Text = "Categorías";
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnCompras
            // 
            btnCompras.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCompras.ForeColor = Color.FromArgb(52, 73, 94);
            btnCompras.ImageTransparentColor = Color.Magenta;
            btnCompras.Margin = new Padding(10, 1, 0, 2);
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(72, 24);
            btnCompras.Text = "Compras";
            btnCompras.Click += btnCompras_Click;
            // 
            // btnVentas
            // 
            btnVentas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVentas.ForeColor = Color.FromArgb(52, 73, 94);
            btnVentas.ImageTransparentColor = Color.Magenta;
            btnVentas.Margin = new Padding(10, 1, 0, 2);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(56, 24);
            btnVentas.Text = "Ventas";
            btnVentas.Click += btnVentas_Click;
            // 
            // btnConsultas
            // 
            btnConsultas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConsultas.ForeColor = Color.FromArgb(52, 73, 94);
            btnConsultas.ImageTransparentColor = Color.Magenta;
            btnConsultas.Margin = new Padding(10, 1, 0, 2);
            btnConsultas.Name = "btnConsultas";
            btnConsultas.Size = new Size(76, 24);
            btnConsultas.Text = "Consultas";
            btnConsultas.Click += btnConsultas_Click;
            // 
            // btnInventario
            // 
            btnInventario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.FromArgb(52, 73, 94);
            btnInventario.ImageTransparentColor = Color.Magenta;
            btnInventario.Margin = new Padding(10, 1, 0, 2);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(79, 24);
            btnInventario.Text = "Inventario";
            btnInventario.Click += btnInventario_Click_1;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(20, 0, 0, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrarSesion.ForeColor = Color.FromArgb(52, 73, 94);
            btnCerrarSesion.ImageTransparentColor = Color.Magenta;
            btnCerrarSesion.Margin = new Padding(10, 1, 0, 2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(100, 24);
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.FromArgb(52, 73, 94);
            btnSalir.ImageTransparentColor = Color.Magenta;
            btnSalir.Margin = new Padding(10, 1, 0, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(42, 24);
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(pictureBox1);
            panelHeader.Controls.Add(lblTituloPrincipal);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 28);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 62);
            panelHeader.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.Ikesis_wordmark;
            pictureBox1.Location = new Point(1075, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblTituloPrincipal
            // 
            lblTituloPrincipal.AutoSize = true;
            lblTituloPrincipal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloPrincipal.ForeColor = Color.White;
            lblTituloPrincipal.Location = new Point(20, 12);
            lblTituloPrincipal.Name = "lblTituloPrincipal";
            lblTituloPrincipal.Size = new Size(204, 31);
            lblTituloPrincipal.TabIndex = 0;
            lblTituloPrincipal.Text = "Campo Argentino";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 849);
            Controls.Add(panelContenedor);
            Controls.Add(toolStrip1);
            Controls.Add(panelHeader);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrincipal";
            Text = "Campo Argentino - Sistema de Gestión";
            WindowState = FormWindowState.Maximized;
            Load += FormPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private PictureBox pictureBox1;
    }
}