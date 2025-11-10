using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CampoArgentino.Presentacion
{
    partial class FormIngreso
    {
        private System.ComponentModel.IContainer components = null;

        // Main Controls
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabControl1;

        // TabPage1 - Listado
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimir;

        // TabPage2 - Gestión
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImpuestos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompraID;
        private System.Windows.Forms.Label label10;

        // Detalle Section
        private System.Windows.Forms.DataGridView dataListadoDetalle;
        private System.Windows.Forms.Label label11;

        // Article Management Panel
        private System.Windows.Forms.Panel panelAgregarArticulo;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnQuitarArticulo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbArticulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBuscarArticulo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataListadoArticulos;

        // Additional Controls
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;

        // Data
        private DataTable dtDetalleIngreso;

        // Para el TextBox de búsqueda (si no existe)
        private TextBox txtBuscar;

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
            components = new Container();
            panelHeader = new Panel();
            lblTitulo = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnNuevo = new Button();
            btnImprimir = new Button();
            dataListado = new DataGridView();
            Eliminar = new DataGridViewCheckBoxColumn();
            lblTotal = new Label();
            btnAnular = new Button();
            btnBuscar = new Button();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            panelAgregarArticulo = new Panel();
            label15 = new Label();
            txtBuscarArticulo = new TextBox();
            label14 = new Label();
            cbArticulo = new ComboBox();
            label13 = new Label();
            txtPrecioCompra = new TextBox();
            label12 = new Label();
            txtCantidad = new TextBox();
            btnQuitarArticulo = new Button();
            btnAgregarArticulo = new Button();
            dataListadoArticulos = new DataGridView();
            dataListadoDetalle = new DataGridView();
            label11 = new Label();
            groupBox1 = new GroupBox();
            txtObservaciones = new TextBox();
            label9 = new Label();
            txtTotal = new TextBox();
            label8 = new Label();
            txtImpuestos = new TextBox();
            label7 = new Label();
            txtSubtotal = new TextBox();
            label6 = new Label();
            dtpFechaCompra = new DateTimePicker();
            label5 = new Label();
            cbProveedor = new ComboBox();
            label4 = new Label();
            txtNumeroDocumento = new TextBox();
            label1 = new Label();
            txtCompraID = new TextBox();
            label10 = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            errorIcono = new ErrorProvider(components);
            ttMensaje = new ToolTip(components);
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((ISupportInitialize)dataListado).BeginInit();
            tabPage2.SuspendLayout();
            panelAgregarArticulo.SuspendLayout();
            ((ISupportInitialize)dataListadoArticulos).BeginInit();
            ((ISupportInitialize)dataListadoDetalle).BeginInit();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)errorIcono).BeginInit();
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
            panelHeader.Size = new Size(1000, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(418, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Ingresos (Compras)";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 83);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 504);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(btnNuevo);
            tabPage1.Controls.Add(btnImprimir);
            tabPage1.Controls.Add(dataListado);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(btnAnular);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(dtpFechaFin);
            tabPage1.Controls.Add(dtpFechaInicio);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(992, 471);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.OrangeRed;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(501, 8);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(105, 81);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "&Nueva Compra";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(52, 152, 219);
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(612, 44);
            btnImprimir.Margin = new Padding(3, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(105, 44);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "&Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // dataListado
            // 
            dataListado.AllowUserToAddRows = false;
            dataListado.AllowUserToDeleteRows = false;
            dataListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataListado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataListado.BackgroundColor = Color.White;
            dataListado.BorderStyle = BorderStyle.Fixed3D;
            dataListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListado.Columns.AddRange(new DataGridViewColumn[] { Eliminar });
            dataListado.Location = new Point(6, 134);
            dataListado.Margin = new Padding(3, 4, 3, 4);
            dataListado.Name = "dataListado";
            dataListado.ReadOnly = true;
            dataListado.RowHeadersWidth = 51;
            dataListado.RowTemplate.Height = 24;
            dataListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListado.Size = new Size(978, 329);
            dataListado.TabIndex = 9;
            dataListado.CellContentClick += dataListado_CellContentClick;
            dataListado.DoubleClick += dataListado_DoubleClick;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "Anular";
            Eliminar.MinimumWidth = 6;
            Eliminar.Name = "Eliminar";
            Eliminar.ReadOnly = true;
            Eliminar.Width = 58;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotal.Location = new Point(800, 99);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 20);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total:";
            // 
            // btnAnular
            // 
            btnAnular.BackColor = Color.DimGray;
            btnAnular.FlatAppearance.BorderSize = 0;
            btnAnular.FlatStyle = FlatStyle.Flat;
            btnAnular.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnular.ForeColor = Color.White;
            btnAnular.Location = new Point(723, 43);
            btnAnular.Margin = new Padding(3, 4, 3, 4);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(105, 44);
            btnAnular.TabIndex = 6;
            btnAnular.Text = "&Anular";
            btnAnular.UseVisualStyleBackColor = false;
            btnAnular.Click += btnAnular_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(41, 128, 185);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(390, 44);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 44);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(250, 52);
            dtpFechaFin.Margin = new Padding(3, 4, 3, 4);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(120, 27);
            dtpFechaFin.TabIndex = 4;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(80, 52);
            dtpFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(120, 27);
            dtpFechaInicio.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(210, 55);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 2;
            label3.Text = "Fin:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(20, 55);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 1;
            label2.Text = "Inicio:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(panelAgregarArticulo);
            tabPage2.Controls.Add(dataListadoDetalle);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(992, 471);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Gestión de Ingreso";
            // 
            // panelAgregarArticulo
            // 
            panelAgregarArticulo.BackColor = Color.FromArgb(248, 249, 250);
            panelAgregarArticulo.BorderStyle = BorderStyle.FixedSingle;
            panelAgregarArticulo.Controls.Add(label15);
            panelAgregarArticulo.Controls.Add(txtBuscarArticulo);
            panelAgregarArticulo.Controls.Add(label14);
            panelAgregarArticulo.Controls.Add(cbArticulo);
            panelAgregarArticulo.Controls.Add(label13);
            panelAgregarArticulo.Controls.Add(txtPrecioCompra);
            panelAgregarArticulo.Controls.Add(label12);
            panelAgregarArticulo.Controls.Add(txtCantidad);
            panelAgregarArticulo.Controls.Add(btnQuitarArticulo);
            panelAgregarArticulo.Controls.Add(btnAgregarArticulo);
            panelAgregarArticulo.Controls.Add(dataListadoArticulos);
            panelAgregarArticulo.Location = new Point(20, 320);
            panelAgregarArticulo.Name = "panelAgregarArticulo";
            panelAgregarArticulo.Size = new Size(950, 150);
            panelAgregarArticulo.TabIndex = 3;
            panelAgregarArticulo.Visible = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(20, 40);
            label15.Name = "label15";
            label15.Size = new Size(55, 20);
            label15.TabIndex = 0;
            label15.Text = "Buscar:";
            // 
            // txtBuscarArticulo
            // 
            txtBuscarArticulo.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarArticulo.Location = new Point(20, 60);
            txtBuscarArticulo.Name = "txtBuscarArticulo";
            txtBuscarArticulo.PlaceholderText = "Buscar artículo...";
            txtBuscarArticulo.Size = new Size(120, 27);
            txtBuscarArticulo.TabIndex = 5;
            txtBuscarArticulo.TextChanged += txtBuscarArticulo_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(150, 40);
            label14.Name = "label14";
            label14.Size = new Size(64, 20);
            label14.TabIndex = 0;
            label14.Text = "Artículo:";
            // 
            // cbArticulo
            // 
            cbArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArticulo.FormattingEnabled = true;
            cbArticulo.Location = new Point(150, 60);
            cbArticulo.Name = "cbArticulo";
            cbArticulo.Size = new Size(300, 28);
            cbArticulo.TabIndex = 6;
            cbArticulo.SelectedIndexChanged += cbArticulo_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(700, 40);
            label13.Name = "label13";
            label13.Size = new Size(110, 20);
            label13.TabIndex = 0;
            label13.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioCompra.Location = new Point(700, 60);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(100, 27);
            txtPrecioCompra.TabIndex = 9;
            txtPrecioCompra.Text = "0.00";
            txtPrecioCompra.TextAlign = HorizontalAlignment.Right;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(600, 40);
            label12.Name = "label12";
            label12.Size = new Size(72, 20);
            label12.TabIndex = 0;
            label12.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.BorderStyle = BorderStyle.FixedSingle;
            txtCantidad.Location = new Point(600, 60);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(80, 27);
            txtCantidad.TabIndex = 8;
            txtCantidad.Text = "1";
            txtCantidad.TextAlign = HorizontalAlignment.Right;
            // 
            // btnQuitarArticulo
            // 
            btnQuitarArticulo.BackColor = Color.FromArgb(231, 76, 60);
            btnQuitarArticulo.FlatAppearance.BorderSize = 0;
            btnQuitarArticulo.FlatStyle = FlatStyle.Flat;
            btnQuitarArticulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQuitarArticulo.ForeColor = Color.White;
            btnQuitarArticulo.Location = new Point(820, 100);
            btnQuitarArticulo.Name = "btnQuitarArticulo";
            btnQuitarArticulo.Size = new Size(110, 35);
            btnQuitarArticulo.TabIndex = 11;
            btnQuitarArticulo.Text = "&Quitar";
            btnQuitarArticulo.UseVisualStyleBackColor = false;
            btnQuitarArticulo.Click += btnQuitarArticulo_Click;
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.BackColor = Color.FromArgb(46, 204, 113);
            btnAgregarArticulo.FlatAppearance.BorderSize = 0;
            btnAgregarArticulo.FlatStyle = FlatStyle.Flat;
            btnAgregarArticulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarArticulo.ForeColor = Color.White;
            btnAgregarArticulo.Location = new Point(700, 100);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(110, 35);
            btnAgregarArticulo.TabIndex = 10;
            btnAgregarArticulo.Text = "&Agregar";
            btnAgregarArticulo.UseVisualStyleBackColor = false;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            // 
            // dataListadoArticulos
            // 
            dataListadoArticulos.AllowUserToAddRows = false;
            dataListadoArticulos.AllowUserToDeleteRows = false;
            dataListadoArticulos.BackgroundColor = Color.White;
            dataListadoArticulos.BorderStyle = BorderStyle.Fixed3D;
            dataListadoArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoArticulos.Location = new Point(20, 90);
            dataListadoArticulos.Name = "dataListadoArticulos";
            dataListadoArticulos.ReadOnly = true;
            dataListadoArticulos.RowHeadersWidth = 51;
            dataListadoArticulos.RowTemplate.Height = 24;
            dataListadoArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListadoArticulos.Size = new Size(570, 50);
            dataListadoArticulos.TabIndex = 12;
            dataListadoArticulos.Visible = false;
            dataListadoArticulos.DoubleClick += dataListadoArticulos_DoubleClick;
            // 
            // dataListadoDetalle
            // 
            dataListadoDetalle.AllowUserToDeleteRows = false;
            dataListadoDetalle.BackgroundColor = Color.White;
            dataListadoDetalle.BorderStyle = BorderStyle.Fixed3D;
            dataListadoDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoDetalle.Location = new Point(20, 480);
            dataListadoDetalle.Margin = new Padding(3, 4, 3, 4);
            dataListadoDetalle.Name = "dataListadoDetalle";
            dataListadoDetalle.ReadOnly = true;
            dataListadoDetalle.RowHeadersWidth = 51;
            dataListadoDetalle.RowTemplate.Height = 24;
            dataListadoDetalle.Size = new Size(950, 118);
            dataListadoDetalle.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(52, 73, 94);
            label11.Location = new Point(20, 450);
            label11.Name = "label11";
            label11.Size = new Size(161, 23);
            label11.TabIndex = 1;
            label11.Text = "Detalle del Ingreso";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtObservaciones);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtTotal);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtImpuestos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtSubtotal);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpFechaCompra);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbProveedor);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNumeroDocumento);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtCompraID);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(52, 73, 94);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(950, 280);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Ingreso";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtObservaciones.Location = new Point(150, 230);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(400, 40);
            txtObservaciones.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(50, 233);
            label9.Name = "label9";
            label9.Size = new Size(108, 20);
            label9.TabIndex = 18;
            label9.Text = "Observaciones:";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(650, 190);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(150, 27);
            txtTotal.TabIndex = 17;
            txtTotal.Text = "0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(600, 193);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 16;
            label8.Text = "Total:";
            // 
            // txtImpuestos
            // 
            txtImpuestos.BorderStyle = BorderStyle.FixedSingle;
            txtImpuestos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtImpuestos.Location = new Point(650, 150);
            txtImpuestos.Margin = new Padding(3, 4, 3, 4);
            txtImpuestos.Name = "txtImpuestos";
            txtImpuestos.Size = new Size(150, 27);
            txtImpuestos.TabIndex = 15;
            txtImpuestos.Text = "0.00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(570, 153);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 14;
            label7.Text = "Impuestos:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.BorderStyle = BorderStyle.FixedSingle;
            txtSubtotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSubtotal.Location = new Point(650, 110);
            txtSubtotal.Margin = new Padding(3, 4, 3, 4);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.Size = new Size(150, 27);
            txtSubtotal.TabIndex = 13;
            txtSubtotal.Text = "0.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(580, 113);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 12;
            label6.Text = "Subtotal:";
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaCompra.Format = DateTimePickerFormat.Short;
            dtpFechaCompra.Location = new Point(150, 150);
            dtpFechaCompra.Margin = new Padding(3, 4, 3, 4);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(200, 27);
            dtpFechaCompra.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(50, 153);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 10;
            label5.Text = "Fecha Compra:";
            // 
            // cbProveedor
            // 
            cbProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbProveedor.FormattingEnabled = true;
            cbProveedor.Location = new Point(150, 110);
            cbProveedor.Margin = new Padding(3, 4, 3, 4);
            cbProveedor.Name = "cbProveedor";
            cbProveedor.Size = new Size(300, 28);
            cbProveedor.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(50, 113);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 8;
            label4.Text = "Proveedor:";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtNumeroDocumento.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumeroDocumento.Location = new Point(150, 70);
            txtNumeroDocumento.Margin = new Padding(3, 4, 3, 4);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Size = new Size(200, 27);
            txtNumeroDocumento.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 73);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 6;
            label1.Text = "N° Documento:";
            // 
            // txtCompraID
            // 
            txtCompraID.BorderStyle = BorderStyle.FixedSingle;
            txtCompraID.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCompraID.Location = new Point(150, 30);
            txtCompraID.Margin = new Padding(3, 4, 3, 4);
            txtCompraID.Name = "txtCompraID";
            txtCompraID.ReadOnly = true;
            txtCompraID.Size = new Size(100, 27);
            txtCompraID.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(50, 33);
            label10.Name = "label10";
            label10.Size = new Size(61, 20);
            label10.TabIndex = 4;
            label10.Text = "Código:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(820, 230);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 41);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(700, 230);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 41);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "&Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorIcono
            // 
            errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            ttMensaje.IsBalloon = true;
            // 
            // FormIngreso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormIngreso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Ingresos (Compras) - Campo Argentino";
            Load += FormIngreso_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((ISupportInitialize)dataListado).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panelAgregarArticulo.ResumeLayout(false);
            panelAgregarArticulo.PerformLayout();
            ((ISupportInitialize)dataListadoArticulos).EndInit();
            ((ISupportInitialize)dataListadoDetalle).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)errorIcono).EndInit();
            ResumeLayout(false);

        }
        private Button btnNuevo;
    }
}