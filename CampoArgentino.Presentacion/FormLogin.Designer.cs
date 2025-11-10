namespace CampoArgentino.Presentacion
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnIngresar;
        private Button btnCancelar;
        private Panel panel1;
        private Label lblTituloSistema;
        private Label lblSubtitulo;
        private Panel panelClient;
        private Label lblCliente;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnIngresar = new Button();
            btnCancelar = new Button();
            panel1 = new Panel();
            lblCliente = new Label();
            lblSubtitulo = new Label();
            lblTituloSistema = new Label();
            panelClient = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(180, 125);
            label1.Name = "label1";
            label1.Size = new Size(191, 38);
            label1.TabIndex = 0;
            label1.Text = "Iniciar Sesión";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(97, 176);
            label2.Name = "label2";
            label2.Size = new Size(72, 23);
            label2.TabIndex = 1;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(97, 250);
            label3.Name = "label3";
            label3.Size = new Size(101, 23);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(101, 208);
            txtUsuario.Margin = new Padding(3, 12, 3, 12);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(320, 30);
            txtUsuario.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(101, 283);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(320, 30);
            txtPassword.TabIndex = 4;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(41, 128, 185);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(101, 363);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(150, 50);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "&Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(271, 363);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 50);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 249, 250);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblCliente);
            panel1.Controls.Add(lblSubtitulo);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 487);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 138);
            panel1.TabIndex = 7;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCliente.ForeColor = Color.FromArgb(127, 140, 141);
            lblCliente.Location = new Point(24, 37);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(478, 19);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente: Campo Argentino | Desarrollado por: IKESIS - Innovativa en Sistemas";
            lblCliente.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitulo.Location = new Point(164, 13);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(166, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión v1.0";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloSistema
            // 
            lblTituloSistema.AutoSize = true;
            lblTituloSistema.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloSistema.ForeColor = Color.FromArgb(192, 255, 255);
            lblTituloSistema.Location = new Point(112, 26);
            lblTituloSistema.Name = "lblTituloSistema";
            lblTituloSistema.Size = new Size(293, 46);
            lblTituloSistema.TabIndex = 0;
            lblTituloSistema.Text = "Campo Argentino";
            lblTituloSistema.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelClient
            // 
            panelClient.BackColor = Color.FromArgb(41, 128, 185);
            panelClient.Controls.Add(label1);
            panelClient.Controls.Add(lblTituloSistema);
            panelClient.Dock = DockStyle.Top;
            panelClient.Location = new Point(0, 0);
            panelClient.Margin = new Padding(3, 4, 3, 4);
            panelClient.Name = "panelClient";
            panelClient.Size = new Size(529, 100);
            panelClient.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(209, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Navy;
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(529, 58);
            panel2.TabIndex = 4;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(529, 625);
            Controls.Add(panel1);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panelClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acceso al Sistema - Campo Argentino";
            Load += FormLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelClient.ResumeLayout(false);
            panelClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private PictureBox pictureBox1;
        private Panel panel2;
    }
}