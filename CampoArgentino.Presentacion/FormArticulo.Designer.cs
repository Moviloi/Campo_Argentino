namespace CampoArgentino.Presentacion
{
    partial class FormArticulo
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dataListado;
        private DataGridViewCheckBoxColumn Eliminar;
        private Label lblTotal;
        private CheckBox chkEliminar;
        private Button btnEliminar;
        private Button btnImprimir;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private Button btnCancelar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private TextBox txtIdarticulo;
        private Label label5;
        private Label label4;
        private Label label3;
        private ToolTip ttMensaje;
        private ErrorProvider errorIcono;
        private TextBox txtCodigo;
        private Label label6;
        private TextBox txtPrecioVenta;
        private Label label7;
        private TextBox txtStock;
        private Label label8;
        private ComboBox cbCategoria;
        private Label label9;
        private ComboBox cbPresentacion;
        private Label label10;
        private Button btnReporte;
        private Panel panelHeader;
        private Label lblTitulo;
        private TextBox txtPrecioCompra;
        private Label label11;
        private TextBox txtStockMinimo;
        private TextBox txtStockMaximo;
        private Label labelStockMinimo;
        private Label labelStockMaximo;
        // ... otros controles

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
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnReporte = new Button();
            btnImprimir = new Button();
            chkEliminar = new CheckBox();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            dataListado = new DataGridView();
            Eliminar = new DataGridViewCheckBoxColumn();
            lblTotal = new Label();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            txtPrecioCompra = new TextBox();
            label11 = new Label();
            cbPresentacion = new ComboBox();
            label10 = new Label();
            cbCategoria = new ComboBox();
            label9 = new Label();
            txtStock = new TextBox();
            label8 = new Label();
            txtPrecioVenta = new TextBox();
            label7 = new Label();
            txtCodigo = new TextBox();
            label6 = new Label();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            txtIdarticulo = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtStockMinimo = new TextBox();
            labelStockMinimo = new Label();
            ttMensaje = new ToolTip(components);
            errorIcono = new ErrorProvider(components);
            panelHeader = new Panel();
            lblTitulo = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).BeginInit();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorIcono).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(29, 10);
            label1.Name = "label1";
            label1.Size = new Size(260, 41);
            label1.TabIndex = 12;
            label1.Text = "Gestión Artículos";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(17, 101);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(953, 574);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(btnReporte);
            tabPage1.Controls.Add(btnImprimir);
            tabPage1.Controls.Add(chkEliminar);
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dataListado);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(945, 541);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            // 
            // btnReporte
            // 
            btnReporte.BackColor = Color.FromArgb(52, 152, 219);
            btnReporte.FlatAppearance.BorderSize = 0;
            btnReporte.FlatStyle = FlatStyle.Flat;
            btnReporte.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReporte.ForeColor = Color.White;
            btnReporte.Location = new Point(791, 44);
            btnReporte.Margin = new Padding(3, 4, 3, 4);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(117, 44);
            btnReporte.TabIndex = 8;
            btnReporte.Text = "&Reporte";
            btnReporte.UseVisualStyleBackColor = false;
            btnReporte.Click += btnReporte_Click_1;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(46, 204, 113);
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(664, 44);
            btnImprimir.Margin = new Padding(3, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(108, 44);
            btnImprimir.TabIndex = 7;
            btnImprimir.Text = "&Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
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
            dataListado.Size = new Size(894, 371);
            dataListado.TabIndex = 1;
            dataListado.CellContentClick += dataListado_CellContentClick;
            dataListado.DoubleClick += dataListado_DoubleClick;
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
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "label3";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(945, 541);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Mantenimiento";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPrecioCompra);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cbPresentacion);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cbCategoria);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtPrecioVenta);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtIdarticulo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtStockMinimo);
            groupBox1.Controls.Add(labelStockMinimo);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(52, 73, 94);
            groupBox1.Location = new Point(14, 26);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(897, 485);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Artículo";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioCompra.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioCompra.Location = new Point(399, 38);
            txtPrecioCompra.Margin = new Padding(3, 4, 3, 4);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(117, 27);
            txtPrecioCompra.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(290, 42);
            label11.Name = "label11";
            label11.Size = new Size(110, 20);
            label11.TabIndex = 20;
            label11.Text = "Precio Compra:";
            // 
            // cbPresentacion
            // 
            cbPresentacion.BackColor = Color.White;
            cbPresentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPresentacion.FlatStyle = FlatStyle.Flat;
            cbPresentacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbPresentacion.FormattingEnabled = true;
            cbPresentacion.Location = new Point(391, 234);
            cbPresentacion.Margin = new Padding(3, 4, 3, 4);
            cbPresentacion.Name = "cbPresentacion";
            cbPresentacion.Size = new Size(200, 28);
            cbPresentacion.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(290, 237);
            label10.Name = "label10";
            label10.Size = new Size(96, 20);
            label10.TabIndex = 18;
            label10.Text = "Presentación:";
            // 
            // cbCategoria
            // 
            cbCategoria.BackColor = Color.White;
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FlatStyle = FlatStyle.Flat;
            cbCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(391, 196);
            cbCategoria.Margin = new Padding(3, 4, 3, 4);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(200, 28);
            cbCategoria.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(290, 200);
            label9.Name = "label9";
            label9.Size = new Size(77, 20);
            label9.TabIndex = 16;
            label9.Text = "Categoría:";
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStock.Location = new Point(399, 112);
            txtStock.Margin = new Padding(3, 4, 3, 4);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(117, 27);
            txtStock.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(290, 116);
            label8.Name = "label8";
            label8.Size = new Size(48, 20);
            label8.TabIndex = 14;
            label8.Text = "Stock:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioVenta.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioVenta.Location = new Point(399, 75);
            txtPrecioVenta.Margin = new Padding(3, 4, 3, 4);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(117, 27);
            txtPrecioVenta.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(290, 79);
            label7.Name = "label7";
            label7.Size = new Size(94, 20);
            label7.TabIndex = 12;
            label7.Text = "Precio Venta:";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(117, 75);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(125, 27);
            txtCodigo.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(24, 79);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 10;
            label6.Text = "Código:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(757, 436);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 41);
            btnCancelar.TabIndex = 9;
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
            btnEditar.Location = new Point(637, 436);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(107, 41);
            btnEditar.TabIndex = 8;
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
            btnGuardar.Location = new Point(517, 436);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 41);
            btnGuardar.TabIndex = 7;
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
            btnNuevo.Location = new Point(397, 436);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(107, 41);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "&Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcion.Location = new Point(117, 150);
            txtDescripcion.Margin = new Padding(3, 4, 3, 4);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(125, 74);
            txtDescripcion.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(117, 112);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 4;
            // 
            // txtIdarticulo
            // 
            txtIdarticulo.BorderStyle = BorderStyle.FixedSingle;
            txtIdarticulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIdarticulo.Location = new Point(117, 38);
            txtIdarticulo.Margin = new Padding(3, 4, 3, 4);
            txtIdarticulo.Name = "txtIdarticulo";
            txtIdarticulo.ReadOnly = true;
            txtIdarticulo.Size = new Size(125, 27);
            txtIdarticulo.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(24, 154);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 2;
            label5.Text = "Descripción:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 116);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 1;
            label4.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 41);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 0;
            label3.Text = "Código:";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.BorderStyle = BorderStyle.FixedSingle;
            txtStockMinimo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStockMinimo.Location = new Point(399, 150);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(117, 27);
            txtStockMinimo.TabIndex = 22;
            // 
            // labelStockMinimo
            // 
            labelStockMinimo.AutoSize = true;
            labelStockMinimo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStockMinimo.Location = new Point(290, 154);
            labelStockMinimo.Name = "labelStockMinimo";
            labelStockMinimo.Size = new Size(103, 20);
            labelStockMinimo.TabIndex = 23;
            labelStockMinimo.Text = "Stock Mínimo:";
            // 
            // ttMensaje
            // 
            ttMensaje.IsBalloon = true;
            // 
            // errorIcono
            // 
            errorIcono.ContainerControl = this;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(987, 75);
            panelHeader.TabIndex = 15;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(283, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Artículos";
            // 
            // FormArticulo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(987, 698);
            Controls.Add(panelHeader);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormArticulo";
            Text = "Gestión de Artículos - Campo Argentino";
            Load += FormArticulo_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorIcono).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}