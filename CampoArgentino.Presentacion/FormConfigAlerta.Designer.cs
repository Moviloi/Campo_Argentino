namespace CampoArgentino.Presentacion
{
    partial class FormConfigAlerta
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitulo;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataListado;
        private Label lblTotal;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label2;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private Button btnCancelar;
        private Button btnEditar;
        private Button btnGuardar;
        private CheckBox chkNotificar;
        private TextBox txtStockMaximo;
        private Label label6;
        private TextBox txtStockMinimo;
        private Label label5;
        private TextBox txtNombre;
        private Label label4;
        private TextBox txtIdarticulo;
        private Label label3;
        private GroupBox groupBox2;
        private Button btnAplicarGlobal;
        private NumericUpDown numStockMaximoGlobal;
        private NumericUpDown numStockMinimoGlobal;
        private Label label8;
        private Label label7;
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
            btnNuevo = new Button();
            dataListado = new DataGridView();
            lblTotal = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            btnAplicarGlobal = new Button();
            numStockMaximoGlobal = new NumericUpDown();
            numStockMinimoGlobal = new NumericUpDown();
            label8 = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            chkNotificar = new CheckBox();
            txtStockMaximo = new TextBox();
            label6 = new Label();
            txtStockMinimo = new TextBox();
            label5 = new Label();
            txtNombre = new TextBox();
            label4 = new Label();
            txtIdarticulo = new TextBox();
            label3 = new Label();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            ttMensaje = new ToolTip(components);
            errorIcono = new ErrorProvider(components);
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStockMaximoGlobal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimoGlobal).BeginInit();
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
            panelHeader.Size = new Size(987, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(343, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración de Alertas";
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
            tabControl1.Size = new Size(987, 574);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(btnNuevo);
            tabPage1.Controls.Add(dataListado);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(979, 541);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado de Artículos";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(255, 128, 0);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(573, 47);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(107, 41);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "&Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
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
            dataListado.Location = new Point(8, 134);
            dataListado.Margin = new Padding(3, 4, 3, 4);
            dataListado.Name = "dataListado";
            dataListado.ReadOnly = true;
            dataListado.RowHeadersWidth = 51;
            dataListado.RowTemplate.Height = 24;
            dataListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListado.Size = new Size(963, 371);
            dataListado.TabIndex = 7;
            dataListado.DoubleClick += dataListado_DoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotal.Location = new Point(500, 99);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 20);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total:";
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
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(979, 541);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Configuración";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAplicarGlobal);
            groupBox2.Controls.Add(numStockMaximoGlobal);
            groupBox2.Controls.Add(numStockMinimoGlobal);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.FromArgb(52, 73, 94);
            groupBox2.Location = new Point(500, 26);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(400, 200);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Configuración Global";
            // 
            // btnAplicarGlobal
            // 
            btnAplicarGlobal.BackColor = Color.FromArgb(155, 89, 182);
            btnAplicarGlobal.FlatAppearance.BorderSize = 0;
            btnAplicarGlobal.FlatStyle = FlatStyle.Flat;
            btnAplicarGlobal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAplicarGlobal.ForeColor = Color.White;
            btnAplicarGlobal.Location = new Point(150, 140);
            btnAplicarGlobal.Margin = new Padding(3, 4, 3, 4);
            btnAplicarGlobal.Name = "btnAplicarGlobal";
            btnAplicarGlobal.Size = new Size(130, 41);
            btnAplicarGlobal.TabIndex = 4;
            btnAplicarGlobal.Text = "&Aplicar a Todos";
            btnAplicarGlobal.UseVisualStyleBackColor = false;
            btnAplicarGlobal.Click += btnAplicarGlobal_Click;
            // 
            // numStockMaximoGlobal
            // 
            numStockMaximoGlobal.Location = new Point(150, 90);
            numStockMaximoGlobal.Margin = new Padding(3, 4, 3, 4);
            numStockMaximoGlobal.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStockMaximoGlobal.Name = "numStockMaximoGlobal";
            numStockMaximoGlobal.Size = new Size(130, 27);
            numStockMaximoGlobal.TabIndex = 3;
            numStockMaximoGlobal.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numStockMinimoGlobal
            // 
            numStockMinimoGlobal.Location = new Point(150, 50);
            numStockMinimoGlobal.Margin = new Padding(3, 4, 3, 4);
            numStockMinimoGlobal.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStockMinimoGlobal.Name = "numStockMinimoGlobal";
            numStockMinimoGlobal.Size = new Size(130, 27);
            numStockMinimoGlobal.TabIndex = 2;
            numStockMinimoGlobal.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(50, 92);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 1;
            label8.Text = "Stock Máx.:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 52);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 0;
            label7.Text = "Stock Mín.:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkNotificar);
            groupBox1.Controls.Add(txtStockMaximo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtStockMinimo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtIdarticulo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(52, 73, 94);
            groupBox1.Location = new Point(14, 26);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(450, 400);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuración por Artículo";
            // 
            // chkNotificar
            // 
            chkNotificar.AutoSize = true;
            chkNotificar.Checked = true;
            chkNotificar.CheckState = CheckState.Checked;
            chkNotificar.Location = new Point(150, 180);
            chkNotificar.Margin = new Padding(3, 4, 3, 4);
            chkNotificar.Name = "chkNotificar";
            chkNotificar.Size = new Size(173, 24);
            chkNotificar.TabIndex = 12;
            chkNotificar.Text = "Activar notificaciones";
            chkNotificar.UseVisualStyleBackColor = true;
            // 
            // txtStockMaximo
            // 
            txtStockMaximo.BorderStyle = BorderStyle.FixedSingle;
            txtStockMaximo.Location = new Point(150, 140);
            txtStockMaximo.Margin = new Padding(3, 4, 3, 4);
            txtStockMaximo.Name = "txtStockMaximo";
            txtStockMaximo.Size = new Size(125, 27);
            txtStockMaximo.TabIndex = 11;
            txtStockMaximo.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 143);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 10;
            label6.Text = "Stock Máx.:";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.BorderStyle = BorderStyle.FixedSingle;
            txtStockMinimo.Location = new Point(150, 100);
            txtStockMinimo.Margin = new Padding(3, 4, 3, 4);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(125, 27);
            txtStockMinimo.TabIndex = 9;
            txtStockMinimo.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 103);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 8;
            label5.Text = "Stock Mín.:";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(150, 60);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 63);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 6;
            label4.Text = "Artículo:";
            // 
            // txtIdarticulo
            // 
            txtIdarticulo.BorderStyle = BorderStyle.FixedSingle;
            txtIdarticulo.Location = new Point(150, 20);
            txtIdarticulo.Margin = new Padding(3, 4, 3, 4);
            txtIdarticulo.Name = "txtIdarticulo";
            txtIdarticulo.ReadOnly = true;
            txtIdarticulo.Size = new Size(125, 27);
            txtIdarticulo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 23);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 4;
            label3.Text = "Código:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(320, 340);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 41);
            btnCancelar.TabIndex = 3;
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
            btnEditar.Location = new Point(200, 340);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(107, 41);
            btnEditar.TabIndex = 2;
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
            btnGuardar.Location = new Point(80, 340);
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
            // FormConfigAlerta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(987, 698);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormConfigAlerta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración de Alertas - Campo Argentino";
            Load += FormConfigAlerta_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStockMaximoGlobal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimoGlobal).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorIcono).EndInit();
            ResumeLayout(false);
        }
        private Button btnNuevo;
    }
}