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
        private ToolStripMenuItem clientesToolStripMenuItem1;
        private ToolStripMenuItem proveedoresToolStripMenuItem1;
        private ToolStripMenuItem artículosToolStripMenuItem1;
        private ToolStripMenuItem stockToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblUsuario;
        private Panel panelHeader;
        private Label lblTituloPrincipal;
        private PictureBox pictureBox1;
        private FlowLayoutPanel panelMenuLateral;
        private Panel panelControlesSuperiores;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
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
            clientesToolStripMenuItem1 = new ToolStripMenuItem();
            proveedoresToolStripMenuItem1 = new ToolStripMenuItem();
            artículosToolStripMenuItem1 = new ToolStripMenuItem();
            stockToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUsuario = new ToolStripStatusLabel();
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            lblTituloPrincipal = new Label();
            panelMenuLateral = new FlowLayoutPanel();
            btnVentas = new PictureBox();
            btnArticulos = new PictureBox();
            btnClientes = new PictureBox();
            btnProveedores = new PictureBox();
            panelControlesSuperiores = new Panel();
            panelContenedor = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnProveedores).BeginInit();
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
            mantenimientosToolStripMenuItem.Size = new Size(87, 24);
            mantenimientosToolStripMenuItem.Text = "&Gestiònes";
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
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ventasToolStripMenuItem1, clientesToolStripMenuItem1, proveedoresToolStripMenuItem1, artículosToolStripMenuItem1, stockToolStripMenuItem });
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
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1075, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            // panelMenuLateral
            // 
            panelMenuLateral.BackColor = Color.FromArgb(64, 64, 64);
            panelMenuLateral.Controls.Add(btnVentas);
            panelMenuLateral.Controls.Add(btnArticulos);
            panelMenuLateral.Controls.Add(btnClientes);
            panelMenuLateral.Controls.Add(btnProveedores);
            panelMenuLateral.Dock = DockStyle.Left;
            panelMenuLateral.FlowDirection = FlowDirection.TopDown;
            panelMenuLateral.Location = new Point(0, 90);
            panelMenuLateral.Name = "panelMenuLateral";
            panelMenuLateral.Size = new Size(205, 733);
            panelMenuLateral.TabIndex = 5;
            // 
            // btnVentas
            // 
            btnVentas.Cursor = Cursors.SizeAll;
            btnVentas.Image = (Image)resources.GetObject("btnVentas.Image");
            btnVentas.Location = new Point(50, 100);
            btnVentas.Margin = new Padding(50, 100, 50, 20);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(100, 100);
            btnVentas.SizeMode = PictureBoxSizeMode.StretchImage;
            btnVentas.TabIndex = 0;
            btnVentas.TabStop = false;
            btnVentas.UseWaitCursor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnArticulos
            // 
            btnArticulos.Cursor = Cursors.SizeAll;
            btnArticulos.Image = (Image)resources.GetObject("btnArticulos.Image");
            btnArticulos.Location = new Point(50, 220);
            btnArticulos.Margin = new Padding(50, 0, 50, 20);
            btnArticulos.Name = "btnArticulos";
            btnArticulos.Size = new Size(100, 100);
            btnArticulos.SizeMode = PictureBoxSizeMode.StretchImage;
            btnArticulos.TabIndex = 0;
            btnArticulos.TabStop = false;
            btnArticulos.UseWaitCursor = true;
            btnArticulos.Click += btnArticulos_Click;
            // 
            // btnClientes
            // 
            btnClientes.Cursor = Cursors.SizeAll;
            btnClientes.Image = (Image)resources.GetObject("btnClientes.Image");
            btnClientes.Location = new Point(50, 340);
            btnClientes.Margin = new Padding(50, 0, 50, 20);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(100, 100);
            btnClientes.SizeMode = PictureBoxSizeMode.StretchImage;
            btnClientes.TabIndex = 0;
            btnClientes.TabStop = false;
            btnClientes.UseWaitCursor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.Cursor = Cursors.SizeAll;
            btnProveedores.Image = (Image)resources.GetObject("btnProveedores.Image");
            btnProveedores.Location = new Point(50, 460);
            btnProveedores.Margin = new Padding(50, 0, 50, 20);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(100, 100);
            btnProveedores.SizeMode = PictureBoxSizeMode.StretchImage;
            btnProveedores.TabIndex = 0;
            btnProveedores.TabStop = false;
            btnProveedores.UseWaitCursor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // panelControlesSuperiores
            // 
            panelControlesSuperiores.BackColor = Color.SkyBlue;
            panelControlesSuperiores.Dock = DockStyle.Top;
            panelControlesSuperiores.Location = new Point(205, 90);
            panelControlesSuperiores.Name = "panelControlesSuperiores";
            panelControlesSuperiores.Size = new Size(995, 60);
            panelControlesSuperiores.TabIndex = 6;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(205, 150);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(995, 673);
            panelContenedor.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 849);
            Controls.Add(panelContenedor);
            Controls.Add(panelControlesSuperiores);
            Controls.Add(panelMenuLateral);
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
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Aquí puedes agregar los botones al panelMenuLateral dinámicamente
        public void AgregarBotonMenu(string texto, Image icono, EventHandler clickHandler)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Image = icono;
            btn.Size = new Size(180, 45);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.FromArgb(52, 73, 94);
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.FlatAppearance.BorderSize = 0;
            btn.Margin = new Padding(10, 5, 10, 5);
            btn.Click += clickHandler;

            panelMenuLateral.Controls.Add(btn);
        }
        private Panel panelContenedor;
        private PictureBox btnVentas;
        private PictureBox btnArticulos;
        private PictureBox btnClientes;
        private PictureBox btnProveedores;
        private ContextMenuStrip contextMenuStrip1;
    }
}