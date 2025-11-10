using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CampoArgentino.Negocio;

namespace CampoArgentino.Presentacion
{
    public partial class FormAlertaVencimientos : Form
    {
        public FormAlertaVencimientos()
        {
            InitializeComponent();
        }

        private void FormAlertaVencimientos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            CargarAlertasVencimientos();
            cbFiltroAlerta.SelectedIndex = 0; // TODAS LAS ALERTAS
        }

        private void CargarAlertasVencimientos()
        {
            try
            {
                DataTable dt = NVencimiento.ObtenerAlertasVencimiento(30); // 30 días de alerta

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataListado.DataSource = dt;
                    AplicarFormatoCeldas();
                    lblTotal.Text = $"Alertas: {dt.Rows.Count}";
                }
                else
                {
                    dataListado.DataSource = null;
                    lblTotal.Text = "Alertas: 0";
                    MessageBox.Show("No hay alertas de vencimientos en este momento.",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                dataListado.DataSource = null;
                lblTotal.Text = "Alertas: 0";
                MessageBox.Show($"Error al cargar alertas: {ex.Message}",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFormatoCeldas()
        {
            foreach (DataGridViewRow row in dataListado.Rows)
            {
                if (row.Cells["NivelAlerta"].Value != null)
                {
                    string nivelAlerta = row.Cells["NivelAlerta"].Value.ToString();

                    switch (nivelAlerta)
                    {
                        case "VENCIDO":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0);
                            break;
                        case "CRITICA":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(139, 0, 0);
                            break;
                        case "ALTA":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 156);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(153, 102, 0);
                            break;
                        case "MEDIA":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 205);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(102, 102, 0);
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataListado.Columns[e.ColumnIndex].Name == "DiasParaVencer")
                {
                    if (e.Value != null && int.TryParse(e.Value.ToString(), out int dias))
                    {
                        if (dias < 0)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.Font = new Font(dataListado.Font, FontStyle.Bold);
                        }
                        else if (dias <= 7)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 220, 220);
                            e.CellStyle.ForeColor = Color.DarkRed;
                            e.CellStyle.Font = new Font(dataListado.Font, FontStyle.Bold);
                        }
                        else if (dias <= 15)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 240, 200);
                            e.CellStyle.ForeColor = Color.OrangeRed;
                        }
                        else if (dias <= 30)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 250, 210);
                            e.CellStyle.ForeColor = Color.Goldenrod;
                        }
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarAlertasVencimientos();
        }

        private void btnGenerarAlertas_Click(object sender, EventArgs e)
        {
            try
            {
                string resultado = NVencimiento.GenerarAlertasVencimiento();

                if (resultado == "OK")
                {
                    MessageBox.Show("Alertas generadas correctamente.",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAlertasVencimientos();
                }
                else
                {
                    MessageBox.Show($"Error al generar alertas: {resultado}",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar alertas: {ex.Message}",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Configuración de alertas de vencimientos.\n\n" +
                "Aquí podrás configurar:\n" +
                "• Días de alerta para cada nivel\n" +
                "• Notificaciones automáticas\n" +
                "• Umbrales de vencimiento\n\n" +
                "Módulo en desarrollo.",
                "Configuración de Alertas",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListado.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para generar el reporte.",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_Vencimientos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFVencimientos(saveFileDialog.FileName);

                    DialogResult imprimir = MessageBox.Show(
                        "¿Desea abrir el PDF para imprimir?",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (imprimir == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveFileDialog.FileName)
                        {
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPDFVencimientos(string filePath)
        {
            // Implementación similar a la que tienes en FormVenta
            // Aquí iría el código para generar el PDF
            MessageBox.Show("Funcionalidad de reporte PDF en desarrollo.",
                "Sistema Campo Argentino",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbFiltroAlerta_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarAlertas();
        }

        private void FiltrarAlertas()
        {
            if (dataListado.DataSource is DataTable dt)
            {
                string filtro = "";

                switch (cbFiltroAlerta.SelectedItem.ToString())
                {
                    case "CRÍTICA (≤ 7 días)":
                        filtro = "NivelAlerta = 'CRITICA'";
                        break;
                    case "ALTA (≤ 15 días)":
                        filtro = "NivelAlerta = 'ALTA'";
                        break;
                    case "MEDIA (≤ 30 días)":
                        filtro = "NivelAlerta = 'MEDIA'";
                        break;
                    case "VENCIDOS":
                        filtro = "NivelAlerta = 'VENCIDO'";
                        break;
                    default:
                        filtro = ""; // Todas
                        break;
                }

                dt.DefaultView.RowFilter = filtro;
                lblTotal.Text = $"Alertas: {dt.DefaultView.Count}";
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.CurrentRow != null && dataListado.CurrentRow.Index >= 0)
            {
                string articulo = dataListado.CurrentRow.Cells["Articulo"].Value?.ToString() ?? "";
                string fechaVencimiento = dataListado.CurrentRow.Cells["FechaVencimiento"].Value?.ToString() ?? "";
                string dias = dataListado.CurrentRow.Cells["DiasParaVencer"].Value?.ToString() ?? "";
                string nivelAlerta = dataListado.CurrentRow.Cells["NivelAlerta"].Value?.ToString() ?? "";

                string mensaje = $"Artículo: {articulo}\n" +
                               $"Fecha Vencimiento: {fechaVencimiento}\n" +
                               $"Días para vencer: {dias}\n" +
                               $"Nivel de Alerta: {nivelAlerta}";

                MessageBox.Show(mensaje, "Detalle de Vencimiento",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizarVencimientos_Click(object sender, EventArgs e)
        {
            try
            {
                string resultado = NVencimiento.ActualizarVencimientos();

                if (resultado == "OK")
                {
                    MessageBox.Show("Vencimientos actualizados correctamente.",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAlertasVencimientos();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar vencimientos: {resultado}",
                        "Sistema Campo Argentino",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar vencimientos: {ex.Message}",
                    "Sistema Campo Argentino",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}