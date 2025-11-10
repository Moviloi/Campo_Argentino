namespace CampoArgentino.Presentacion
{
    partial class FormVistaArticuloCliente_Venta
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitulo;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataListadoClientes;
        private Label lblTotal;
        private Button btnImprimir;
        private Button btnCerrar;
        private Label lblArticuloInfo;
        private Label lblEstadisticas;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label label2;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVistaArticuloCliente_Venta));
            panelHeader = new Panel();
            lblTitulo = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblEstadisticas = new Label();
            btnCerrar = new Button();
            btnImprimir = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            dataListadoClientes = new DataGridView();
            lblTotal = new Label();
            lblArticuloInfo = new Label();
            ttMensaje = new ToolTip(components);
            errorIcono = new ErrorProvider(components);
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoClientes).BeginInit();
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
            panelHeader.Size = new Size(1100, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(329, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ventas por Cliente - Artículo";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(0, 83);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1100, 600);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(lblEstadisticas);
            tabPage1.Controls.Add(btnCerrar);
            tabPage1.Controls.Add(btnImprimir);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dataListadoClientes);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(lblArticuloInfo);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1092, 567);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Clientes que Compraron";
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEstadisticas.AutoSize = true;
            lblEstadisticas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadisticas.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstadisticas.Location = new Point(23, 525);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(89, 20);
            lblEstadisticas.TabIndex = 8;
            lblEstadisticas.Text = "Estadísticas";
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.BackColor = Color.FromArgb(149, 165, 166);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(877, 515);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(105, 44);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "&Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimir.BackColor = Color.FromArgb(41, 128, 185);
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(766, 515);
            btnImprimir.Margin = new Padding(3, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(105, 44);
            btnImprimir.TabIndex = 6;
            btnImprimir.Text = "&Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(41, 128, 185);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(416, 84);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 44);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "&Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(86, 89);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre de cliente...";
            txtBuscar.Size = new Size(300, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(23, 92);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 3;
            label2.Text = "Buscar:";
            // 
            // dataListadoClientes
            // 
            dataListadoClientes.AllowUserToAddRows = false;
            dataListadoClientes.AllowUserToDeleteRows = false;
            dataListadoClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataListadoClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataListadoClientes.BackgroundColor = Color.White;
            dataListadoClientes.BorderStyle = BorderStyle.Fixed3D;
            dataListadoClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoClientes.Location = new Point(23, 144);
            dataListadoClientes.Margin = new Padding(3, 4, 3, 4);
            dataListadoClientes.Name = "dataListadoClientes";
            dataListadoClientes.ReadOnly = true;
            dataListadoClientes.RowHeadersWidth = 51;
            dataListadoClientes.RowTemplate.Height = 24;
            dataListadoClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListadoClientes.Size = new Size(1056, 363);
            dataListadoClientes.TabIndex = 2;
            dataListadoClientes.DoubleClick += dataListadoClientes_DoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotal.Location = new Point(23, 120);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "label3";
            // 
            // lblArticuloInfo
            // 
            lblArticuloInfo.AutoSize = true;
            lblArticuloInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArticuloInfo.ForeColor = Color.FromArgb(41, 128, 185);
            lblArticuloInfo.Location = new Point(23, 24);
            lblArticuloInfo.Name = "lblArticuloInfo";
            lblArticuloInfo.Size = new Size(198, 28);
            lblArticuloInfo.TabIndex = 0;
            lblArticuloInfo.Text = "Artículo Seleccionado";
            // 
            // ttMensaje
            // 
            ttMensaje.IsBalloon = true;
            ttMensaje.ToolTipIcon = ToolTipIcon.Info;
            ttMensaje.ToolTipTitle = "Información";
            // 
            // errorIcono
            // 
            errorIcono.ContainerControl = this;
            // 
            // FormVistaArticuloCliente_Venta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 700);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1118, 747);
            Name = "FormVistaArticuloCliente_Venta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas por Cliente - Campo Argentino";
            Load += FormVistaArticuloCliente_Venta_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorIcono).EndInit();
            ResumeLayout(false);
        }
    }
}