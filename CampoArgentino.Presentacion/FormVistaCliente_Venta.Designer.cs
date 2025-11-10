namespace CampoArgentino.Presentacion
{
    partial class FormVistaCliente_Venta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label2;

        // Nuevos controles para pestañas
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.TabPage tabPageDetalle;
        private System.Windows.Forms.Label lblClienteInfo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.DataGridView dataListadoArticulos;
        private System.Windows.Forms.Label lblTotalArticulos;
        private System.Windows.Forms.Button btnVolver;

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
            panelHeader = new Panel();
            lblTitulo = new Label();
            tabControl1 = new TabControl();
            tabPageListado = new TabPage();
            btnImprimir = new Button();
            dataListado = new DataGridView();
            lblTotal = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            tabPageDetalle = new TabPage();
            btnImprimirDetalle = new Button();
            lblClienteInfo = new Label();
            lblResumen = new Label();
            dataListadoArticulos = new DataGridView();
            lblTotalArticulos = new Label();
            btnVolver = new Button();
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).BeginInit();
            tabPageDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoArticulos).BeginInit();
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
            lblTitulo.Size = new Size(262, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Clientes - Compras";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageListado);
            tabControl1.Controls.Add(tabPageDetalle);
            tabControl1.Location = new Point(0, 75);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(987, 623);
            tabControl1.TabIndex = 1;
            // 
            // tabPageListado
            // 
            tabPageListado.BackColor = Color.White;
            tabPageListado.Controls.Add(btnImprimir);
            tabPageListado.Controls.Add(dataListado);
            tabPageListado.Controls.Add(lblTotal);
            tabPageListado.Controls.Add(btnBuscar);
            tabPageListado.Controls.Add(txtBuscar);
            tabPageListado.Controls.Add(label2);
            tabPageListado.Location = new Point(4, 29);
            tabPageListado.Name = "tabPageListado";
            tabPageListado.Padding = new Padding(3);
            tabPageListado.Size = new Size(979, 590);
            tabPageListado.TabIndex = 0;
            tabPageListado.Text = "Listado de Clientes";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(46, 204, 113);
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(862, 29);
            btnImprimir.Margin = new Padding(3, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(108, 44);
            btnImprimir.TabIndex = 8;
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
            dataListado.Location = new Point(17, 119);
            dataListado.Margin = new Padding(3, 4, 3, 4);
            dataListado.MultiSelect = false;
            dataListado.Name = "dataListado";
            dataListado.ReadOnly = true;
            dataListado.RowHeadersWidth = 51;
            dataListado.RowTemplate.Height = 24;
            dataListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListado.Size = new Size(953, 458);
            dataListado.TabIndex = 7;
            dataListado.DoubleClick += dataListado_DoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotal.Location = new Point(503, 84);
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
            btnBuscar.Location = new Point(419, 29);
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
            txtBuscar.Location = new Point(89, 34);
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
            label2.Location = new Point(26, 37);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Buscar:";
            // 
            // tabPageDetalle
            // 
            tabPageDetalle.BackColor = Color.White;
            tabPageDetalle.Controls.Add(btnImprimirDetalle);
            tabPageDetalle.Controls.Add(lblClienteInfo);
            tabPageDetalle.Controls.Add(lblResumen);
            tabPageDetalle.Controls.Add(dataListadoArticulos);
            tabPageDetalle.Controls.Add(lblTotalArticulos);
            tabPageDetalle.Controls.Add(btnVolver);
            tabPageDetalle.Location = new Point(4, 29);
            tabPageDetalle.Name = "tabPageDetalle";
            tabPageDetalle.Padding = new Padding(3);
            tabPageDetalle.Size = new Size(979, 590);
            tabPageDetalle.TabIndex = 1;
            tabPageDetalle.Text = "Detalle de Compras";
            // 
            // btnImprimirDetalle
            // 
            btnImprimirDetalle.BackColor = Color.FromArgb(46, 204, 113);
            btnImprimirDetalle.FlatAppearance.BorderSize = 0;
            btnImprimirDetalle.FlatStyle = FlatStyle.Flat;
            btnImprimirDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimirDetalle.ForeColor = Color.White;
            btnImprimirDetalle.Location = new Point(851, 36);
            btnImprimirDetalle.Margin = new Padding(3, 4, 3, 4);
            btnImprimirDetalle.Name = "btnImprimirDetalle";
            btnImprimirDetalle.Size = new Size(108, 44);
            btnImprimirDetalle.TabIndex = 9;
            btnImprimirDetalle.Text = "&Imprimir";
            btnImprimirDetalle.UseVisualStyleBackColor = false;
            btnImprimirDetalle.Click += btnImprimirDetalle_Click;
            // 
            // lblClienteInfo
            // 
            lblClienteInfo.AutoSize = true;
            lblClienteInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClienteInfo.ForeColor = Color.FromArgb(41, 128, 185);
            lblClienteInfo.Location = new Point(20, 20);
            lblClienteInfo.Name = "lblClienteInfo";
            lblClienteInfo.Size = new Size(208, 28);
            lblClienteInfo.TabIndex = 0;
            lblClienteInfo.Text = "Cliente Seleccionado";
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumen.ForeColor = Color.FromArgb(52, 73, 94);
            lblResumen.Location = new Point(20, 60);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(78, 20);
            lblResumen.TabIndex = 1;
            lblResumen.Text = "Resumen:";
            // 
            // dataListadoArticulos
            // 
            dataListadoArticulos.AllowUserToAddRows = false;
            dataListadoArticulos.AllowUserToDeleteRows = false;
            dataListadoArticulos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataListadoArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataListadoArticulos.BackgroundColor = Color.White;
            dataListadoArticulos.BorderStyle = BorderStyle.Fixed3D;
            dataListadoArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoArticulos.Location = new Point(20, 90);
            dataListadoArticulos.Name = "dataListadoArticulos";
            dataListadoArticulos.ReadOnly = true;
            dataListadoArticulos.RowHeadersWidth = 51;
            dataListadoArticulos.Size = new Size(939, 430);
            dataListadoArticulos.TabIndex = 2;
            // 
            // lblTotalArticulos
            // 
            lblTotalArticulos.AutoSize = true;
            lblTotalArticulos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalArticulos.Location = new Point(20, 540);
            lblTotalArticulos.Name = "lblTotalArticulos";
            lblTotalArticulos.Size = new Size(50, 20);
            lblTotalArticulos.TabIndex = 3;
            lblTotalArticulos.Text = "label3";
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(149, 165, 166);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(859, 535);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 40);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "&Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormVistaCliente_Venta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(987, 698);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormVistaCliente_Venta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes para Ventas - Campo Argentino";
            Load += FormVistaCliente_Venta_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageListado.ResumeLayout(false);
            tabPageListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).EndInit();
            tabPageDetalle.ResumeLayout(false);
            tabPageDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoArticulos).EndInit();
            ResumeLayout(false);
        }
        private Button btnImprimir;
        private Button btnImprimirDetalle;
    }
}