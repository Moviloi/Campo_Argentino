namespace CampoArgentino.Presentacion
{
    partial class FormAlertaVencimientos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFiltroAlerta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerarAlertas;

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
            dataListado = new DataGridView();
            lblTotal = new Label();
            btnReporte = new Button();
            btnConfigurar = new Button();
            btnActualizar = new Button();
            label1 = new Label();
            cbFiltroAlerta = new ComboBox();
            label2 = new Label();
            btnGenerarAlertas = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(231, 76, 60);
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
            lblTitulo.Size = new Size(391, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Alertas de Vencimientos 🚨";
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
            dataListado.Location = new Point(12, 194);
            dataListado.Margin = new Padding(3, 4, 3, 4);
            dataListado.Name = "dataListado";
            dataListado.ReadOnly = true;
            dataListado.RowHeadersWidth = 51;
            dataListado.RowTemplate.Height = 24;
            dataListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListado.Size = new Size(1076, 491);
            dataListado.TabIndex = 7;
            dataListado.CellFormatting += dataListado_CellFormatting;
            dataListado.DoubleClick += dataListado_DoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotal.Location = new Point(503, 159);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(76, 20);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Alertas: 0";
            // 
            // btnReporte
            // 
            btnReporte.BackColor = Color.FromArgb(52, 152, 219);
            btnReporte.FlatAppearance.BorderSize = 0;
            btnReporte.FlatStyle = FlatStyle.Flat;
            btnReporte.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReporte.ForeColor = Color.White;
            btnReporte.Location = new Point(311, 104);
            btnReporte.Margin = new Padding(3, 4, 3, 4);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(108, 44);
            btnReporte.TabIndex = 5;
            btnReporte.Text = "&Reporte";
            btnReporte.UseVisualStyleBackColor = false;
            btnReporte.Click += btnReporte_Click;
            // 
            // btnConfigurar
            // 
            btnConfigurar.BackColor = Color.FromArgb(243, 156, 18);
            btnConfigurar.FlatAppearance.BorderSize = 0;
            btnConfigurar.FlatStyle = FlatStyle.Flat;
            btnConfigurar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfigurar.ForeColor = Color.White;
            btnConfigurar.Location = new Point(200, 104);
            btnConfigurar.Margin = new Padding(3, 4, 3, 4);
            btnConfigurar.Name = "btnConfigurar";
            btnConfigurar.Size = new Size(105, 44);
            btnConfigurar.TabIndex = 4;
            btnConfigurar.Text = "&Configurar";
            btnConfigurar.UseVisualStyleBackColor = false;
            btnConfigurar.Click += btnConfigurar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(46, 204, 113);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(89, 104);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(105, 44);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "&Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(26, 112);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 2;
            label1.Text = "Acción:";
            // 
            // cbFiltroAlerta
            // 
            cbFiltroAlerta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiltroAlerta.FormattingEnabled = true;
            cbFiltroAlerta.Items.AddRange(new object[] { "TODAS LAS ALERTAS", "CRÍTICA (≤ 7 días)", "ALTA (≤ 15 días)", "MEDIA (≤ 30 días)", "VENCIDOS" });
            cbFiltroAlerta.Location = new Point(650, 112);
            cbFiltroAlerta.Name = "cbFiltroAlerta";
            cbFiltroAlerta.Size = new Size(200, 28);
            cbFiltroAlerta.TabIndex = 8;
            cbFiltroAlerta.SelectedIndexChanged += cbFiltroAlerta_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(600, 115);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 9;
            label2.Text = "Filtro:";
            // 
            // btnGenerarAlertas
            // 
            btnGenerarAlertas.BackColor = Color.FromArgb(155, 89, 182);
            btnGenerarAlertas.FlatAppearance.BorderSize = 0;
            btnGenerarAlertas.FlatStyle = FlatStyle.Flat;
            btnGenerarAlertas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerarAlertas.ForeColor = Color.White;
            btnGenerarAlertas.Location = new Point(425, 104);
            btnGenerarAlertas.Margin = new Padding(3, 4, 3, 4);
            btnGenerarAlertas.Name = "btnGenerarAlertas";
            btnGenerarAlertas.Size = new Size(140, 44);
            btnGenerarAlertas.TabIndex = 10;
            btnGenerarAlertas.Text = "&Generar Alertas";
            btnGenerarAlertas.UseVisualStyleBackColor = false;
            btnGenerarAlertas.Click += btnGenerarAlertas_Click;
            // 
            // FormAlertaVencimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 698);
            Controls.Add(btnGenerarAlertas);
            Controls.Add(label2);
            Controls.Add(cbFiltroAlerta);
            Controls.Add(dataListado);
            Controls.Add(lblTotal);
            Controls.Add(btnReporte);
            Controls.Add(btnConfigurar);
            Controls.Add(btnActualizar);
            Controls.Add(label1);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAlertaVencimientos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alertas de Vencimientos - Campo Argentino";
            Load += FormAlertaVencimientos_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataListado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}