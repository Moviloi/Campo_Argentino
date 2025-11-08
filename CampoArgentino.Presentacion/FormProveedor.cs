using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FormProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del proveedor");
            this.ttMensaje.SetToolTip(this.txtCUIT, "Ingrese el RUC del proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del proveedor");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el teléfono del proveedor");
            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese el email del proveedor");
        }

        private void FormProveedor_Load(object sender, EventArgs e)
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
            this.txtProveedorID.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtCUIT.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtCUIT.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
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
            // Ocultar solo la columna ID, mantener "Seleccionar" visible
            if (this.dataListado.Columns.Contains("idproveedor"))
                this.dataListado.Columns["idproveedor"].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();

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
            this.dataListado.DataSource = NProveedor.BuscarNombre(this.txtBuscar.Text);

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
                    MensajeError("No hay proveedores seleccionados para eliminar");
                    return;
                }

                DialogResult Opcion = MessageBox.Show(
                    $"¿Realmente desea eliminar los {cantidadSeleccionados} proveedores seleccionados?\n\nEsta acción no se puede deshacer.",
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
                            int idproveedor = Convert.ToInt32(row.Cells["idproveedor"].Value);
                            string nombreProveedor = row.Cells["Nombre"].Value?.ToString() ?? "Sin nombre";

                            Rpta = NProveedor.Eliminar(idproveedor);

                            if (Rpta.Equals("OK"))
                            {
                                eliminadosExitosos++;
                            }
                            else
                            {
                                errores++;
                                if (erroresDetallados.Length < 200)
                                {
                                    erroresDetallados.AppendLine($"{nombreProveedor}: {Rpta}");
                                }
                            }
                        }
                    }

                    // Mostrar resumen
                    if (errores == 0)
                    {
                        MensajeOk($"Se eliminaron correctamente {eliminadosExitosos} proveedores");
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
                    row.DefaultCellStyle.BackColor = Color.DarkGreen;
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
                this.txtProveedorID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
                this.txtCUIT.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CUIT"].Value);
                this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
                this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
                this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
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
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un valor");
                    return;
                }

                // Validar CUIT si se ingresó
                if (!string.IsNullOrEmpty(this.txtCUIT.Text) && !EsCuitValido(this.txtCUIT.Text))
                {
                    MensajeError("El CUIT ingresado no tiene un formato válido");
                    errorIcono.SetError(txtCUIT, "Formato de CUIT inválido");
                    return;
                }

                // Validar email si se ingresó
                if (!string.IsNullOrEmpty(this.txtEmail.Text) && !EsEmailValido(this.txtEmail.Text))
                {
                    MensajeError("El email ingresado no tiene un formato válido");
                    errorIcono.SetError(txtEmail, "Formato de email inválido");
                    return;
                }

                if (this.IsNuevo)
                {
                    rpta = NProveedor.Insertar(
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtCUIT.Text.Trim(),
                        this.txtDireccion.Text.Trim(),
                        this.txtTelefono.Text.Trim(),
                        this.txtEmail.Text.Trim()
                    );
                }
                else
                {
                    rpta = NProveedor.Editar(
                        Convert.ToInt32(this.txtProveedorID.Text),
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtCUIT.Text.Trim(),
                        this.txtDireccion.Text.Trim(),
                        this.txtTelefono.Text.Trim(),
                        this.txtEmail.Text.Trim()
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
                MensajeError($"Error al guardar el proveedor: {ex.Message}");
            }
        }

        // Métodos de validación
        private bool EsCuitValido(string cuit)
        {
            // Validación básica de CUIT
            if (string.IsNullOrEmpty(cuit)) return true;

            // Eliminar guiones y espacios
            cuit = cuit.Replace("-", "").Replace(" ", "");

            // Debe tener 11 dígitos
            if (cuit.Length != 11) return false;

            // Debe contener solo números
            return long.TryParse(cuit, out _);
        }

        private bool EsEmailValido(string email)
        {
            if (string.IsNullOrEmpty(email)) return true;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtProveedorID.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
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

       
    }
}