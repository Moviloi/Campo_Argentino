namespace CampoArgentino.Presentacion
{
    partial class FormInventario
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl1;
        private TabPage tabPageReporte;
        private TabPage tabPageConteo;
        private TabPage tabPageAjuste;
        private DataGridView dataListadoReporte;
        private Button btnImprimirReporte;
        private Button btnExportarExcel;
        private Label lblTotalReporte;
        private GroupBox groupBoxConteo;
        private TextBox txtObservacionesConteo;
        private Label label1;
        private Button btnIniciarConteo;
        private Button btnFinalizarConteo;
        private Label lblEstadoConteo;
        private DataGridView dataListadoConteo;
        private Label lblTotalConteo;
        private GroupBox groupBoxDetalleConteo;
        private TextBox txtStockFisicoConteo;
        private Label label4;
        private TextBox txtStockSistemaConteo;
        private Label label3;
        private TextBox txtNombreConteo;
        private Label label2;
        private TextBox txtCodigoConteo;
        private Label label5;
        private Button btnAgregarConteo;
        private DataGridView dataListadoResumen;
        private Label lblTotalResumen;
        private GroupBox groupBoxAjuste;
        private TextBox txtBuscarAjuste;
        private Label label6;
        private DataGridView dataListadoAjuste;
        private Label lblTotalAjuste;
        private GroupBox groupBoxDetalleAjuste;
        private TextBox txtNuevoStockAjuste;
        private Label label7;
        private TextBox txtStockActualAjuste;
        private Label label8;
        private TextBox txtNombreAjuste;
        private Label label9;
        private TextBox txtCodigoAjuste;
        private Label label10;
        private TextBox txtIdArticuloAjuste;
        private Label label11;
        private Button btnAplicarAjuste;
        private Button btnBuscarAjuste;

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
            tabControl1 = new TabControl();
            tabPageReporte = new TabPage();
            lblTotalReporte = new Label();
            btnExportarExcel = new Button();
            btnImprimirReporte = new Button();
            dataListadoReporte = new DataGridView();
            tabPageConteo = new TabPage();
            lblTotalResumen = new Label();
            dataListadoResumen = new DataGridView();
            lblTotalConteo = new Label();
            dataListadoConteo = new DataGridView();
            groupBoxDetalleConteo = new GroupBox();
            btnAgregarConteo = new Button();
            txtStockFisicoConteo = new TextBox();
            label4 = new Label();
            txtStockSistemaConteo = new TextBox();
            label3 = new Label();
            txtNombreConteo = new TextBox();
            label2 = new Label();
            txtCodigoConteo = new TextBox();
            label5 = new Label();
            groupBoxConteo = new GroupBox();
            lblEstadoConteo = new Label();
            btnFinalizarConteo = new Button();
            btnIniciarConteo = new Button();
            txtObservacionesConteo = new TextBox();
            label1 = new Label();
            tabPageAjuste = new TabPage();
            groupBoxDetalleAjuste = new GroupBox();
            btnAplicarAjuste = new Button();
            txtNuevoStockAjuste = new TextBox();
            label7 = new Label();
            txtStockActualAjuste = new TextBox();
            label8 = new Label();
            txtNombreAjuste = new TextBox();
            label9 = new Label();
            txtCodigoAjuste = new TextBox();
            label10 = new Label();
            txtIdArticuloAjuste = new TextBox();
            label11 = new Label();
            lblTotalAjuste = new Label();
            dataListadoAjuste = new DataGridView();
            btnBuscarAjuste = new Button();
            txtBuscarAjuste = new TextBox();
            label6 = new Label();
            tabControl1.SuspendLayout();
            tabPageReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoReporte).BeginInit();
            tabPageConteo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoResumen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataListadoConteo).BeginInit();
            groupBoxDetalleConteo.SuspendLayout();
            groupBoxConteo.SuspendLayout();
            tabPageAjuste.SuspendLayout();
            groupBoxDetalleAjuste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoAjuste).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageReporte);
            tabControl1.Controls.Add(tabPageConteo);
            tabControl1.Controls.Add(tabPageAjuste);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1143, 800);
            tabControl1.TabIndex = 0;
            // 
            // tabPageReporte
            // 
            tabPageReporte.Controls.Add(lblTotalReporte);
            tabPageReporte.Controls.Add(btnExportarExcel);
            tabPageReporte.Controls.Add(btnImprimirReporte);
            tabPageReporte.Controls.Add(dataListadoReporte);
            tabPageReporte.Location = new Point(4, 29);
            tabPageReporte.Margin = new Padding(3, 4, 3, 4);
            tabPageReporte.Name = "tabPageReporte";
            tabPageReporte.Padding = new Padding(3, 4, 3, 4);
            tabPageReporte.Size = new Size(1135, 767);
            tabPageReporte.TabIndex = 0;
            tabPageReporte.Text = "Reporte para Conteo";
            tabPageReporte.UseVisualStyleBackColor = true;
            // 
            // lblTotalReporte
            // 
            lblTotalReporte.AutoSize = true;
            lblTotalReporte.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalReporte.Location = new Point(23, 707);
            lblTotalReporte.Name = "lblTotalReporte";
            lblTotalReporte.Size = new Size(52, 20);
            lblTotalReporte.TabIndex = 3;
            lblTotalReporte.Text = "Total: ";
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.FromArgb(46, 204, 113);
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(994, 27);
            btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(114, 47);
            btnExportarExcel.TabIndex = 2;
            btnExportarExcel.Text = "Exportar Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // btnImprimirReporte
            // 
            btnImprimirReporte.BackColor = Color.FromArgb(52, 152, 219);
            btnImprimirReporte.FlatStyle = FlatStyle.Flat;
            btnImprimirReporte.ForeColor = Color.White;
            btnImprimirReporte.Location = new Point(869, 27);
            btnImprimirReporte.Margin = new Padding(3, 4, 3, 4);
            btnImprimirReporte.Name = "btnImprimirReporte";
            btnImprimirReporte.Size = new Size(114, 47);
            btnImprimirReporte.TabIndex = 1;
            btnImprimirReporte.Text = "Imprimir";
            btnImprimirReporte.UseVisualStyleBackColor = false;
            btnImprimirReporte.Click += btnImprimirReporte_Click;
            // 
            // dataListadoReporte
            // 
            dataListadoReporte.AllowUserToAddRows = false;
            dataListadoReporte.AllowUserToDeleteRows = false;
            dataListadoReporte.BackgroundColor = Color.White;
            dataListadoReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoReporte.Location = new Point(23, 93);
            dataListadoReporte.Margin = new Padding(3, 4, 3, 4);
            dataListadoReporte.Name = "dataListadoReporte";
            dataListadoReporte.ReadOnly = true;
            dataListadoReporte.RowHeadersWidth = 51;
            dataListadoReporte.RowTemplate.Height = 25;
            dataListadoReporte.Size = new Size(1086, 600);
            dataListadoReporte.TabIndex = 0;
            // 
            // tabPageConteo
            // 
            tabPageConteo.Controls.Add(lblTotalResumen);
            tabPageConteo.Controls.Add(dataListadoResumen);
            tabPageConteo.Controls.Add(lblTotalConteo);
            tabPageConteo.Controls.Add(dataListadoConteo);
            tabPageConteo.Controls.Add(groupBoxDetalleConteo);
            tabPageConteo.Controls.Add(groupBoxConteo);
            tabPageConteo.Location = new Point(4, 29);
            tabPageConteo.Margin = new Padding(3, 4, 3, 4);
            tabPageConteo.Name = "tabPageConteo";
            tabPageConteo.Padding = new Padding(3, 4, 3, 4);
            tabPageConteo.Size = new Size(1135, 767);
            tabPageConteo.TabIndex = 1;
            tabPageConteo.Text = "Conteo Físico";
            tabPageConteo.UseVisualStyleBackColor = true;
            // 
            // lblTotalResumen
            // 
            lblTotalResumen.AutoSize = true;
            lblTotalResumen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalResumen.Location = new Point(571, 533);
            lblTotalResumen.Name = "lblTotalResumen";
            lblTotalResumen.Size = new Size(52, 20);
            lblTotalResumen.TabIndex = 5;
            lblTotalResumen.Text = "Total: ";
            // 
            // dataListadoResumen
            // 
            dataListadoResumen.AllowUserToAddRows = false;
            dataListadoResumen.AllowUserToDeleteRows = false;
            dataListadoResumen.BackgroundColor = Color.White;
            dataListadoResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoResumen.Location = new Point(23, 560);
            dataListadoResumen.Margin = new Padding(3, 4, 3, 4);
            dataListadoResumen.Name = "dataListadoResumen";
            dataListadoResumen.ReadOnly = true;
            dataListadoResumen.RowHeadersWidth = 51;
            dataListadoResumen.RowTemplate.Height = 25;
            dataListadoResumen.Size = new Size(1086, 187);
            dataListadoResumen.TabIndex = 4;
            // 
            // lblTotalConteo
            // 
            lblTotalConteo.AutoSize = true;
            lblTotalConteo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalConteo.Location = new Point(571, 333);
            lblTotalConteo.Name = "lblTotalConteo";
            lblTotalConteo.Size = new Size(52, 20);
            lblTotalConteo.TabIndex = 3;
            lblTotalConteo.Text = "Total: ";
            // 
            // dataListadoConteo
            // 
            dataListadoConteo.AllowUserToAddRows = false;
            dataListadoConteo.AllowUserToDeleteRows = false;
            dataListadoConteo.BackgroundColor = Color.White;
            dataListadoConteo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoConteo.Location = new Point(23, 360);
            dataListadoConteo.Margin = new Padding(3, 4, 3, 4);
            dataListadoConteo.Name = "dataListadoConteo";
            dataListadoConteo.RowHeadersWidth = 51;
            dataListadoConteo.RowTemplate.Height = 25;
            dataListadoConteo.Size = new Size(1086, 160);
            dataListadoConteo.TabIndex = 2;
            // 
            // groupBoxDetalleConteo
            // 
            groupBoxDetalleConteo.Controls.Add(btnAgregarConteo);
            groupBoxDetalleConteo.Controls.Add(txtStockFisicoConteo);
            groupBoxDetalleConteo.Controls.Add(label4);
            groupBoxDetalleConteo.Controls.Add(txtStockSistemaConteo);
            groupBoxDetalleConteo.Controls.Add(label3);
            groupBoxDetalleConteo.Controls.Add(txtNombreConteo);
            groupBoxDetalleConteo.Controls.Add(label2);
            groupBoxDetalleConteo.Controls.Add(txtCodigoConteo);
            groupBoxDetalleConteo.Controls.Add(label5);
            groupBoxDetalleConteo.Location = new Point(571, 27);
            groupBoxDetalleConteo.Margin = new Padding(3, 4, 3, 4);
            groupBoxDetalleConteo.Name = "groupBoxDetalleConteo";
            groupBoxDetalleConteo.Padding = new Padding(3, 4, 3, 4);
            groupBoxDetalleConteo.Size = new Size(537, 267);
            groupBoxDetalleConteo.TabIndex = 1;
            groupBoxDetalleConteo.TabStop = false;
            groupBoxDetalleConteo.Text = "Agregar Artículo al Conteo";
            // 
            // btnAgregarConteo
            // 
            btnAgregarConteo.BackColor = Color.FromArgb(46, 204, 113);
            btnAgregarConteo.FlatStyle = FlatStyle.Flat;
            btnAgregarConteo.ForeColor = Color.White;
            btnAgregarConteo.Location = new Point(400, 200);
            btnAgregarConteo.Margin = new Padding(3, 4, 3, 4);
            btnAgregarConteo.Name = "btnAgregarConteo";
            btnAgregarConteo.Size = new Size(114, 47);
            btnAgregarConteo.TabIndex = 8;
            btnAgregarConteo.Text = "Agregar";
            btnAgregarConteo.UseVisualStyleBackColor = false;
            btnAgregarConteo.Click += btnAgregarConteo_Click;
            // 
            // txtStockFisicoConteo
            // 
            txtStockFisicoConteo.Location = new Point(137, 200);
            txtStockFisicoConteo.Margin = new Padding(3, 4, 3, 4);
            txtStockFisicoConteo.Name = "txtStockFisicoConteo";
            txtStockFisicoConteo.Size = new Size(228, 27);
            txtStockFisicoConteo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 204);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 6;
            label4.Text = "Stock Físico:";
            // 
            // txtStockSistemaConteo
            // 
            txtStockSistemaConteo.Location = new Point(137, 147);
            txtStockSistemaConteo.Margin = new Padding(3, 4, 3, 4);
            txtStockSistemaConteo.Name = "txtStockSistemaConteo";
            txtStockSistemaConteo.ReadOnly = true;
            txtStockSistemaConteo.Size = new Size(228, 27);
            txtStockSistemaConteo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 151);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 4;
            label3.Text = "Stock Sistema:";
            // 
            // txtNombreConteo
            // 
            txtNombreConteo.Location = new Point(137, 93);
            txtNombreConteo.Margin = new Padding(3, 4, 3, 4);
            txtNombreConteo.Name = "txtNombreConteo";
            txtNombreConteo.ReadOnly = true;
            txtNombreConteo.Size = new Size(228, 27);
            txtNombreConteo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 97);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // txtCodigoConteo
            // 
            txtCodigoConteo.Location = new Point(137, 40);
            txtCodigoConteo.Margin = new Padding(3, 4, 3, 4);
            txtCodigoConteo.Name = "txtCodigoConteo";
            txtCodigoConteo.Size = new Size(228, 27);
            txtCodigoConteo.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 44);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 0;
            label5.Text = "Código:";
            // 
            // groupBoxConteo
            // 
            groupBoxConteo.Controls.Add(lblEstadoConteo);
            groupBoxConteo.Controls.Add(btnFinalizarConteo);
            groupBoxConteo.Controls.Add(btnIniciarConteo);
            groupBoxConteo.Controls.Add(txtObservacionesConteo);
            groupBoxConteo.Controls.Add(label1);
            groupBoxConteo.Location = new Point(23, 27);
            groupBoxConteo.Margin = new Padding(3, 4, 3, 4);
            groupBoxConteo.Name = "groupBoxConteo";
            groupBoxConteo.Padding = new Padding(3, 4, 3, 4);
            groupBoxConteo.Size = new Size(537, 267);
            groupBoxConteo.TabIndex = 0;
            groupBoxConteo.TabStop = false;
            groupBoxConteo.Text = "Control de Conteo";
            // 
            // lblEstadoConteo
            // 
            lblEstadoConteo.AutoSize = true;
            lblEstadoConteo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoConteo.Location = new Point(23, 213);
            lblEstadoConteo.Name = "lblEstadoConteo";
            lblEstadoConteo.Size = new Size(95, 20);
            lblEstadoConteo.TabIndex = 4;
            lblEstadoConteo.Text = "SIN INICIAR";
            // 
            // btnFinalizarConteo
            // 
            btnFinalizarConteo.BackColor = Color.FromArgb(231, 76, 60);
            btnFinalizarConteo.FlatStyle = FlatStyle.Flat;
            btnFinalizarConteo.ForeColor = Color.White;
            btnFinalizarConteo.Location = new Point(400, 133);
            btnFinalizarConteo.Margin = new Padding(3, 4, 3, 4);
            btnFinalizarConteo.Name = "btnFinalizarConteo";
            btnFinalizarConteo.Size = new Size(114, 47);
            btnFinalizarConteo.TabIndex = 3;
            btnFinalizarConteo.Text = "Finalizar Conteo";
            btnFinalizarConteo.UseVisualStyleBackColor = false;
            btnFinalizarConteo.Click += btnFinalizarConteo_Click;
            // 
            // btnIniciarConteo
            // 
            btnIniciarConteo.BackColor = Color.FromArgb(52, 152, 219);
            btnIniciarConteo.FlatStyle = FlatStyle.Flat;
            btnIniciarConteo.ForeColor = Color.White;
            btnIniciarConteo.Location = new Point(400, 67);
            btnIniciarConteo.Margin = new Padding(3, 4, 3, 4);
            btnIniciarConteo.Name = "btnIniciarConteo";
            btnIniciarConteo.Size = new Size(114, 47);
            btnIniciarConteo.TabIndex = 2;
            btnIniciarConteo.Text = "Iniciar Conteo";
            btnIniciarConteo.UseVisualStyleBackColor = false;
            btnIniciarConteo.Click += btnIniciarConteo_Click;
            // 
            // txtObservacionesConteo
            // 
            txtObservacionesConteo.Location = new Point(137, 67);
            txtObservacionesConteo.Margin = new Padding(3, 4, 3, 4);
            txtObservacionesConteo.Multiline = true;
            txtObservacionesConteo.Name = "txtObservacionesConteo";
            txtObservacionesConteo.Size = new Size(228, 132);
            txtObservacionesConteo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 71);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = "Observaciones:";
            // 
            // tabPageAjuste
            // 
            tabPageAjuste.Controls.Add(groupBoxDetalleAjuste);
            tabPageAjuste.Controls.Add(lblTotalAjuste);
            tabPageAjuste.Controls.Add(dataListadoAjuste);
            tabPageAjuste.Controls.Add(btnBuscarAjuste);
            tabPageAjuste.Controls.Add(txtBuscarAjuste);
            tabPageAjuste.Controls.Add(label6);
            tabPageAjuste.Location = new Point(4, 29);
            tabPageAjuste.Margin = new Padding(3, 4, 3, 4);
            tabPageAjuste.Name = "tabPageAjuste";
            tabPageAjuste.Padding = new Padding(3, 4, 3, 4);
            tabPageAjuste.Size = new Size(1135, 767);
            tabPageAjuste.TabIndex = 2;
            tabPageAjuste.Text = "Ajuste Rápido";
            tabPageAjuste.UseVisualStyleBackColor = true;
            // 
            // groupBoxDetalleAjuste
            // 
            groupBoxDetalleAjuste.Controls.Add(btnAplicarAjuste);
            groupBoxDetalleAjuste.Controls.Add(txtNuevoStockAjuste);
            groupBoxDetalleAjuste.Controls.Add(label7);
            groupBoxDetalleAjuste.Controls.Add(txtStockActualAjuste);
            groupBoxDetalleAjuste.Controls.Add(label8);
            groupBoxDetalleAjuste.Controls.Add(txtNombreAjuste);
            groupBoxDetalleAjuste.Controls.Add(label9);
            groupBoxDetalleAjuste.Controls.Add(txtCodigoAjuste);
            groupBoxDetalleAjuste.Controls.Add(label10);
            groupBoxDetalleAjuste.Controls.Add(txtIdArticuloAjuste);
            groupBoxDetalleAjuste.Controls.Add(label11);
            groupBoxDetalleAjuste.Location = new Point(571, 93);
            groupBoxDetalleAjuste.Margin = new Padding(3, 4, 3, 4);
            groupBoxDetalleAjuste.Name = "groupBoxDetalleAjuste";
            groupBoxDetalleAjuste.Padding = new Padding(3, 4, 3, 4);
            groupBoxDetalleAjuste.Size = new Size(537, 333);
            groupBoxDetalleAjuste.TabIndex = 5;
            groupBoxDetalleAjuste.TabStop = false;
            groupBoxDetalleAjuste.Text = "Ajuste de Stock";
            // 
            // btnAplicarAjuste
            // 
            btnAplicarAjuste.BackColor = Color.FromArgb(46, 204, 113);
            btnAplicarAjuste.FlatStyle = FlatStyle.Flat;
            btnAplicarAjuste.ForeColor = Color.White;
            btnAplicarAjuste.Location = new Point(400, 267);
            btnAplicarAjuste.Margin = new Padding(3, 4, 3, 4);
            btnAplicarAjuste.Name = "btnAplicarAjuste";
            btnAplicarAjuste.Size = new Size(114, 47);
            btnAplicarAjuste.TabIndex = 10;
            btnAplicarAjuste.Text = "Aplicar Ajuste";
            btnAplicarAjuste.UseVisualStyleBackColor = false;
            btnAplicarAjuste.Click += btnAplicarAjuste_Click;
            // 
            // txtNuevoStockAjuste
            // 
            txtNuevoStockAjuste.Location = new Point(137, 267);
            txtNuevoStockAjuste.Margin = new Padding(3, 4, 3, 4);
            txtNuevoStockAjuste.Name = "txtNuevoStockAjuste";
            txtNuevoStockAjuste.Size = new Size(228, 27);
            txtNuevoStockAjuste.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 271);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 8;
            label7.Text = "Nuevo Stock:";
            // 
            // txtStockActualAjuste
            // 
            txtStockActualAjuste.Location = new Point(137, 213);
            txtStockActualAjuste.Margin = new Padding(3, 4, 3, 4);
            txtStockActualAjuste.Name = "txtStockActualAjuste";
            txtStockActualAjuste.ReadOnly = true;
            txtStockActualAjuste.Size = new Size(228, 27);
            txtStockActualAjuste.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 217);
            label8.Name = "label8";
            label8.Size = new Size(94, 20);
            label8.TabIndex = 6;
            label8.Text = "Stock Actual:";
            // 
            // txtNombreAjuste
            // 
            txtNombreAjuste.Location = new Point(137, 160);
            txtNombreAjuste.Margin = new Padding(3, 4, 3, 4);
            txtNombreAjuste.Name = "txtNombreAjuste";
            txtNombreAjuste.ReadOnly = true;
            txtNombreAjuste.Size = new Size(228, 27);
            txtNombreAjuste.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 164);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 4;
            label9.Text = "Nombre:";
            // 
            // txtCodigoAjuste
            // 
            txtCodigoAjuste.Location = new Point(137, 107);
            txtCodigoAjuste.Margin = new Padding(3, 4, 3, 4);
            txtCodigoAjuste.Name = "txtCodigoAjuste";
            txtCodigoAjuste.ReadOnly = true;
            txtCodigoAjuste.Size = new Size(228, 27);
            txtCodigoAjuste.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 111);
            label10.Name = "label10";
            label10.Size = new Size(61, 20);
            label10.TabIndex = 2;
            label10.Text = "Código:";
            // 
            // txtIdArticuloAjuste
            // 
            txtIdArticuloAjuste.Location = new Point(137, 53);
            txtIdArticuloAjuste.Margin = new Padding(3, 4, 3, 4);
            txtIdArticuloAjuste.Name = "txtIdArticuloAjuste";
            txtIdArticuloAjuste.ReadOnly = true;
            txtIdArticuloAjuste.Size = new Size(228, 27);
            txtIdArticuloAjuste.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 57);
            label11.Name = "label11";
            label11.Size = new Size(83, 20);
            label11.TabIndex = 0;
            label11.Text = "ID Artículo:";
            // 
            // lblTotalAjuste
            // 
            lblTotalAjuste.AutoSize = true;
            lblTotalAjuste.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalAjuste.Location = new Point(23, 707);
            lblTotalAjuste.Name = "lblTotalAjuste";
            lblTotalAjuste.Size = new Size(52, 20);
            lblTotalAjuste.TabIndex = 4;
            lblTotalAjuste.Text = "Total: ";
            // 
            // dataListadoAjuste
            // 
            dataListadoAjuste.AllowUserToAddRows = false;
            dataListadoAjuste.AllowUserToDeleteRows = false;
            dataListadoAjuste.BackgroundColor = Color.White;
            dataListadoAjuste.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataListadoAjuste.Location = new Point(23, 93);
            dataListadoAjuste.Margin = new Padding(3, 4, 3, 4);
            dataListadoAjuste.Name = "dataListadoAjuste";
            dataListadoAjuste.ReadOnly = true;
            dataListadoAjuste.RowHeadersWidth = 51;
            dataListadoAjuste.RowTemplate.Height = 25;
            dataListadoAjuste.Size = new Size(537, 600);
            dataListadoAjuste.TabIndex = 3;
            dataListadoAjuste.DoubleClick += dataListadoAjuste_DoubleClick;
            // 
            // btnBuscarAjuste
            // 
            btnBuscarAjuste.BackColor = Color.FromArgb(52, 152, 219);
            btnBuscarAjuste.FlatStyle = FlatStyle.Flat;
            btnBuscarAjuste.ForeColor = Color.White;
            btnBuscarAjuste.Location = new Point(446, 27);
            btnBuscarAjuste.Margin = new Padding(3, 4, 3, 4);
            btnBuscarAjuste.Name = "btnBuscarAjuste";
            btnBuscarAjuste.Size = new Size(114, 47);
            btnBuscarAjuste.TabIndex = 2;
            btnBuscarAjuste.Text = "Buscar";
            btnBuscarAjuste.UseVisualStyleBackColor = false;
            btnBuscarAjuste.Click += btnBuscarAjuste_Click;
            // 
            // txtBuscarAjuste
            // 
            txtBuscarAjuste.Location = new Point(137, 33);
            txtBuscarAjuste.Margin = new Padding(3, 4, 3, 4);
            txtBuscarAjuste.Name = "txtBuscarAjuste";
            txtBuscarAjuste.Size = new Size(285, 27);
            txtBuscarAjuste.TabIndex = 1;
            txtBuscarAjuste.TextChanged += txtBuscarAjuste_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 37);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 0;
            label6.Text = "Buscar artículo:";
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 800);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormInventario";
            Text = "Sistema de Inventario - Campo Argentino";
            Load += FormInventario_Load;
            tabControl1.ResumeLayout(false);
            tabPageReporte.ResumeLayout(false);
            tabPageReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoReporte).EndInit();
            tabPageConteo.ResumeLayout(false);
            tabPageConteo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoResumen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataListadoConteo).EndInit();
            groupBoxDetalleConteo.ResumeLayout(false);
            groupBoxDetalleConteo.PerformLayout();
            groupBoxConteo.ResumeLayout(false);
            groupBoxConteo.PerformLayout();
            tabPageAjuste.ResumeLayout(false);
            tabPageAjuste.PerformLayout();
            groupBoxDetalleAjuste.ResumeLayout(false);
            groupBoxDetalleAjuste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListadoAjuste).EndInit();
            ResumeLayout(false);

        }
    }
}