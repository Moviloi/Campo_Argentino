namespace CampoArgentino.Presentacion
{
    partial class FormProveedor
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitulo;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataListado;
        private DataGridViewCheckBoxColumn Eliminar;
        private Label lblTotal;
        private CheckBox chkEliminar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label2;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private Button btnCancelar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtCUIT;
        private TextBox txtNombre;
        private TextBox txtProveedorID;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ToolTip ttMensaje;
        private ErrorProvider errorIcono;

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
            panelHeader = new Panel();
            lblTitulo = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataListado = new DataGridView();
            Eliminar = new DataGridViewCheckBoxColumn();
            lblTotal = new Label();
            chkEliminar = new CheckBox();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtCUIT = new TextBox();
            txtNombre = new TextBox();
            txtProveedorID = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            ttMensaje = new ToolTip(components);
            errorIcono = new ErrorProvider(components);
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).BeginInit();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorIcono).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(327, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Proveedores";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 75);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(900, 613);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(dataListado);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(chkEliminar);
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(892, 580);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            // 
            // dataListado
            // 
            dataListado.AllowUserToAddRows = false;
            dataListado.AllowUserToDeleteRows = false;
            dataListado.BackgroundColor = Color.White;
            dataListado.BorderStyle = BorderStyle.Fixed3D;
            dataListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListado.Columns.AddRange(new DataGridViewColumn[] { Eliminar });
            dataListado.Location = new Point(14, 134);
            dataListado.Margin = new Padding(3, 4, 3, 4);
            dataListado.Name = "dataListado";
            dataListado.ReadOnly = true;
            dataListado.RowHeadersWidth = 51;
            dataListado.RowTemplate.Height = 24;
            dataListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListado.Size = new Size(864, 418);
            dataListado.TabIndex = 1;
            dataListado.CellContentClick += dataListado_CellContentClick;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "Eliminar";
            Eliminar.MinimumWidth = 6;
            Eliminar.Name = "Eliminar";
            Eliminar.ReadOnly = true;
            Eliminar.Width = 125;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotal.Location = new Point(500, 99);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total:";
            // 
            // chkEliminar
            // 
            chkEliminar.AutoSize = true;
            chkEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEliminar.ForeColor = Color.FromArgb(52, 73, 94);
            chkEliminar.Location = new Point(14, 99);
            chkEliminar.Margin = new Padding(3, 4, 3, 4);
            chkEliminar.Name = "chkEliminar";
            chkEliminar.Size = new Size(85, 24);
            chkEliminar.TabIndex = 6;
            chkEliminar.Text = "Eliminar";
            chkEliminar.UseVisualStyleBackColor = true;
            chkEliminar.CheckedChanged += chkEliminar_CheckedChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(540, 44);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 44);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "&Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(41, 128, 185);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(416, 44);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 44);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(86, 49);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 27);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(23, 52);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Buscar:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(892, 580);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Mantenimiento";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(txtCUIT);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtProveedorID);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(52, 73, 94);
            groupBox1.Location = new Point(14, 26);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(864, 525);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Proveedor";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(391, 225);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 17;
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(391, 188);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 27);
            txtTelefono.TabIndex = 16;
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(391, 112);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ScrollBars = ScrollBars.Vertical;
            txtDireccion.Size = new Size(250, 62);
            txtDireccion.TabIndex = 15;
            // 
            // txtCUIT
            // 
            txtCUIT.BorderStyle = BorderStyle.FixedSingle;
            txtCUIT.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCUIT.Location = new Point(391, 75);
            txtCUIT.Margin = new Padding(3, 4, 3, 4);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(200, 27);
            txtCUIT.TabIndex = 14;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(117, 112);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 13;
            // 
            // txtProveedorID
            // 
            txtProveedorID.BorderStyle = BorderStyle.FixedSingle;
            txtProveedorID.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProveedorID.Location = new Point(117, 75);
            txtProveedorID.Margin = new Padding(3, 4, 3, 4);
            txtProveedorID.Name = "txtProveedorID";
            txtProveedorID.ReadOnly = true;
            txtProveedorID.Size = new Size(125, 27);
            txtProveedorID.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(290, 229);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 11;
            label8.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(290, 191);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 10;
            label7.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(290, 116);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 9;
            label6.Text = "Dirección:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(290, 79);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 8;
            label5.Text = "CUIT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 116);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 7;
            label4.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 79);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 6;
            label3.Text = "Código:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(737, 462);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 41);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(243, 156, 18);
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(617, 462);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(107, 41);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "E&ditar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(497, 462);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 41);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "&Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(41, 128, 185);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(377, 462);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(107, 41);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "&Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // ttMensaje
            // 
            ttMensaje.IsBalloon = true;
            // 
            // errorIcono
            // 
            errorIcono.ContainerControl = this;
            // 
            // FormProveedor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 688);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormProveedor";
            Text = "Gestión de Proveedores - Campo Argentino";
            Load += FormProveedor_Load_1;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorIcono).EndInit();
            ResumeLayout(false);
        }
    }
}