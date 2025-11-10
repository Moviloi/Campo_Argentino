using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormUsuario : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FormUsuario()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombreUsuario, "Ingrese el nombre de usuario");
            this.ttMensaje.SetToolTip(this.txtContrasena, "Ingrese la contraseña");
            this.ttMensaje.SetToolTip(this.txtConfirmarContrasena, "Confirme la contraseña");
            this.ttMensaje.SetToolTip(this.txtNombreCompleto, "Ingrese el nombre completo");
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        // Métodos auxiliares
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Campo Argentino", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.txtUsuarioID.Text = string.Empty;
            this.txtNombreUsuario.Text = string.Empty;
            this.txtContrasena.Text = string.Empty;
            this.txtConfirmarContrasena.Text = string.Empty;
            this.txtNombreCompleto.Text = string.Empty;
            this.chkActivo.Checked = true;
        }

        private void Habilitar(bool valor)
        {
            this.txtNombreUsuario.ReadOnly = !valor;
            this.txtContrasena.ReadOnly = !valor;
            this.txtConfirmarContrasena.ReadOnly = !valor;
            this.txtNombreCompleto.ReadOnly = !valor;
            this.chkActivo.Enabled = valor;
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            // Ocultar columnas sensibles, mantener "Seleccionar" visible
            if (this.dataListado.Columns.Contains("idusuario"))
                this.dataListado.Columns["idusuario"].Visible = false;

            if (this.dataListado.Columns.Contains("Contrasena"))
                this.dataListado.Columns["Contrasena"].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NUsuario.Mostrar();

            // Configurar columna de selección
            ConfigurarColumnaSeleccion();

            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void ConfigurarColumnaSeleccion()
        {
            // Limpiar columnas antiguas primero
            LimpiarColumnasAntiguas();

            // Verificar si la columna ya existe
            if (!dataListado.Columns.Contains("Seleccionar"))
            {
                // Crear columna de botón para selección
                DataGridViewButtonColumn btnSeleccionarCol = new DataGridViewButtonColumn();
                btnSeleccionarCol.Name = "Seleccionar";
                btnSeleccionarCol.HeaderText = "Seleccionar";
                btnSeleccionarCol.Text = "⬜"; // Cuadrado vacío (no seleccionado)
                btnSeleccionarCol.UseColumnTextForButtonValue = true;
                btnSeleccionarCol.Width = 80;
                btnSeleccionarCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnSeleccionarCol.DefaultCellStyle.Font = new Font("Arial", 12);
                btnSeleccionarCol.FlatStyle = FlatStyle.Flat;

                // Insertar la columna al principio
                dataListado.Columns.Insert(0, btnSeleccionarCol);
            }

            // Asegurarse de que la columna esté visible
            dataListado.Columns["Seleccionar"].Visible = true;

            // Inicializar el estado de selección de todas las filas
            foreach (DataGridViewRow row in dataListado.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Por defecto, no seleccionado
                    row.Cells["Seleccionar"].Value = "⬜";
                    row.Cells["Seleccionar"].Tag = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void LimpiarColumnasAntiguas()
        {
            // Eliminar la columna "Eliminar" si existe
            if (dataListado.Columns.Contains("Eliminar"))
            {
                dataListado.Columns.Remove("Eliminar");
            }

            // También eliminar cualquier columna de checkbox existente
            foreach (DataGridViewColumn col in dataListado.Columns)
            {
                if (col is DataGridViewCheckBoxColumn)
                {
                    dataListado.Columns.Remove(col);
                    break;
                }
            }
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NUsuario.BuscarNombre(this.txtBuscar.Text);

            // Reconfigurar columna de selección después de buscar
            ConfigurarColumnaSeleccion();

            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        // Eventos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Contar cuántos están seleccionados
                int cantidadSeleccionados = 0;
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Seleccionar"].Tag != null && (bool)row.Cells["Seleccionar"].Tag)
                    {
                        cantidadSeleccionados++;
                    }
                }

                if (cantidadSeleccionados == 0)
                {
                    MensajeError("No hay usuarios seleccionados para eliminar");
                    return;
                }

                DialogResult Opcion = MessageBox.Show(
                    $"¿Realmente desea eliminar los {cantidadSeleccionados} usuarios seleccionados?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    int eliminadosExitosos = 0;
                    int errores = 0;
                    System.Text.StringBuilder erroresDetallados = new System.Text.StringBuilder();

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["Seleccionar"].Tag != null && (bool)row.Cells["Seleccionar"].Tag)
                        {
                            int idusuario = Convert.ToInt32(row.Cells["idusuario"].Value);
                            string nombreUsuario = row.Cells["NombreUsuario"].Value?.ToString() ?? "Sin nombre";

                         
                            // if (idusuario == UsuarioLogueado.ID) { ... }

                            Rpta = NUsuario.Eliminar(idusuario);

                            if (Rpta.Equals("OK"))
                            {
                                eliminadosExitosos++;
                            }
                            else
                            {
                                errores++;
                                if (erroresDetallados.Length < 200)
                                {
                                    erroresDetallados.AppendLine($"{nombreUsuario}: {Rpta}");
                                }
                            }
                        }
                    }

                    // Mostrar resumen
                    if (errores == 0)
                    {
                        MensajeOk($"Se eliminaron correctamente {eliminadosExitosos} usuarios");
                    }
                    else
                    {
                        string mensajeError = $"Proceso completado: {eliminadosExitosos} eliminados, {errores} errores";
                        if (erroresDetallados.Length > 0)
                        {
                            mensajeError += "\n\nErrores:\n" + erroresDetallados.ToString();
                        }
                        MensajeError(mensajeError);
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error inesperado al eliminar: {ex.Message}");
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna "Seleccionar"
            if (e.RowIndex >= 0 && e.ColumnIndex == dataListado.Columns["Seleccionar"].Index)
            {
                DataGridViewRow row = dataListado.Rows[e.RowIndex];
                bool estaSeleccionado = false;

                // Obtener el estado actual del Tag
                if (row.Cells["Seleccionar"].Tag != null)
                {
                    estaSeleccionado = (bool)row.Cells["Seleccionar"].Tag;
                }

                // Cambiar el estado
                estaSeleccionado = !estaSeleccionado;

                // Actualizar el texto del botón y el Tag
                if (estaSeleccionado)
                {
                    row.Cells["Seleccionar"].Value = "✅"; // Checkbox marcado
                    row.Cells["Seleccionar"].Tag = true;
                    row.DefaultCellStyle.BackColor = Color.DimGray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.Cells["Seleccionar"].Value = "⬜"; // Checkbox vacío
                    row.Cells["Seleccionar"].Tag = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                // Forzar el repintado de la fila
                dataListado.InvalidateRow(e.RowIndex);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataListado.CurrentRow != null)
            {
                this.txtUsuarioID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idusuario"].Value);
                this.txtNombreUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreUsuario"].Value);
                this.txtNombreCompleto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreCompleto"].Value);
                this.chkActivo.Checked = Convert.ToBoolean(this.dataListado.CurrentRow.Cells["Activo"].Value);

                // Limpiar campos de contraseña por seguridad
                this.txtContrasena.Text = "";
                this.txtConfirmarContrasena.Text = "";

                this.tabControl1.SelectedIndex = 1;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombreUsuario.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombreUsuario.Text == string.Empty || this.txtNombreCompleto.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos obligatorios");
                    errorIcono.SetError(txtNombreUsuario, "Ingrese un nombre de usuario");
                    errorIcono.SetError(txtNombreCompleto, "Ingrese el nombre completo");
                    return;
                }

                // Validar contraseñas solo si es nuevo o si se cambió la contraseña
                if (this.IsNuevo && (this.txtContrasena.Text == string.Empty || this.txtConfirmarContrasena.Text == string.Empty))
                {
                    MensajeError("Debe ingresar y confirmar la contraseña para nuevo usuario");
                    errorIcono.SetError(txtContrasena, "Ingrese la contraseña");
                    errorIcono.SetError(txtConfirmarContrasena, "Confirme la contraseña");
                    return;
                }

                if (this.txtContrasena.Text != this.txtConfirmarContrasena.Text)
                {
                    MensajeError("Las contraseñas no coinciden");
                    errorIcono.SetError(txtConfirmarContrasena, "Las contraseñas no coinciden");
                    return;
                }

                if (this.IsNuevo)
                {
                    rpta = NUsuario.Insertar(
                        this.txtNombreUsuario.Text.Trim(),
                        this.txtContrasena.Text.Trim(),
                        this.txtNombreCompleto.Text.Trim().ToUpper()
                    );
                }
                else
                {
                    // Si no se cambió la contraseña, pasar cadena vacía
                    string contrasena = string.IsNullOrEmpty(this.txtContrasena.Text) ? "" : this.txtContrasena.Text.Trim();

                    rpta = NUsuario.Editar(
                        Convert.ToInt32(this.txtUsuarioID.Text),
                        this.txtNombreUsuario.Text.Trim(),
                        contrasena,
                        this.txtNombreCompleto.Text.Trim().ToUpper(),
                        this.chkActivo.Checked
                    );
                }

                if (rpta.Equals("OK"))
                {
                    string mensaje = this.IsNuevo ?
                        "Se insertó de forma correcta el registro" :
                        "Se actualizó de forma correcta el registro";

                    this.MensajeOk(mensaje);

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
                else
                {
                    this.MensajeError(rpta);
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error al guardar el usuario: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtUsuarioID.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

                // Enfocar en nombre de usuario al editar
                this.txtNombreUsuario.Focus();
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            ValidarCoincidenciaContrasenas();
        }

        private void txtConfirmarContrasena_TextChanged(object sender, EventArgs e)
        {
            ValidarCoincidenciaContrasenas();
        }

        private void ValidarCoincidenciaContrasenas()
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text && !string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                errorIcono.SetError(txtConfirmarContrasena, "Las contraseñas no coinciden");
            }
            else
            {
                errorIcono.SetError(txtConfirmarContrasena, "");
            }
        }
       
    }
}