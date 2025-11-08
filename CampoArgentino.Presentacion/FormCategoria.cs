using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormCategoria : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FormCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la categoría");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripción de la categoría");
        }

        private void FormCategoria_Load(object sender, EventArgs e)
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
            this.txtCategoriaID.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
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
            if (this.dataListado.Columns.Contains("idcategoria"))
                this.dataListado.Columns["idcategoria"].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();

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
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);

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
                    MensajeError("No hay categorías seleccionadas para eliminar");
                    return;
                }

                DialogResult Opcion = MessageBox.Show(
                    $"¿Realmente desea eliminar las {cantidadSeleccionados} categorías seleccionadas?\n\nEsta acción no se puede deshacer.",
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
                            int idcategoria = Convert.ToInt32(row.Cells["idcategoria"].Value);
                            string nombreCategoria = row.Cells["nombre"].Value?.ToString() ?? "Sin nombre";

                            Rpta = NCategoria.Eliminar(idcategoria);

                            if (Rpta.Equals("OK"))
                            {
                                eliminadosExitosos++;
                            }
                            else
                            {
                                errores++;
                                if (erroresDetallados.Length < 200) // Limitar longitud del mensaje
                                {
                                    erroresDetallados.AppendLine($"{nombreCategoria}: {Rpta}");
                                }
                            }
                        }
                    }

                    // Mostrar resumen
                    if (errores == 0)
                    {
                        MensajeOk($"Se eliminaron correctamente {eliminadosExitosos} categorías");
                    }
                    else
                    {
                        string mensajeError = $"Proceso completado: {eliminadosExitosos} eliminadas, {errores} errores";
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
                this.txtCategoriaID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
                this.tabControl1.SelectedIndex = 1;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
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

                if (this.IsNuevo)
                {
                    rpta = NCategoria.Insertar(
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtDescripcion.Text.Trim()
                    );
                }
                else
                {
                    rpta = NCategoria.Editar(
                        Convert.ToInt32(this.txtCategoriaID.Text),
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtDescripcion.Text.Trim()
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
                MensajeError($"Error al guardar la categoría: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtCategoriaID.Text.Equals(""))
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