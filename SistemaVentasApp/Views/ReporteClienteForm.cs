using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using SistemaVentasApp.Controllers;
using SistemaVentasApp.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaVentasApp.Views
{
    public partial class ReporteClienteForm : Form
    {
        private readonly ApiClient _apiClient;
        public ReporteClienteForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            //cmbTipoGrafico.Items.AddRange(["Barra", "Torta"]);
            //cmbTipoGrafico.SelectedIndex = 0;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            // Await the asynchronous method to get the data
            var datos = await _apiClient.Reportes.ObtenerReporteClientes(dtpFechaInicio.Value, dtpFechaFin.Value);

            // Convert the IEnumerable to a List for binding to the DataGridView
            dgvReporte.DataSource = datos.ToList();

            //string tipoGrafico = cmbTipoGrafico.SelectedItem?.ToString() ?? "Barra";
            GenerarGrafico(datos.ToList()); // Pass the selected chart type
        }

        private void GenerarGrafico(List<ReporteClienteDto> datos, string tipo = "Barra")
        {
            var plt = formsPlot1.Plot;
            plt.Clear();

            var clientes = datos.Select(x => x.IdCliente.ToString()).ToArray();
            var valores = datos.Select(x => (double)x.TotalComprado).ToArray();

            if (!valores.Any()) return;

            if (tipo.Equals("Barra", StringComparison.OrdinalIgnoreCase))
            {
                // Dibujar barras
                plt.AddBar(valores);

                // Configurar etiquetas del eje X
                plt.XTicks(Enumerable.Range(0, clientes.Length).Select(i => (double)i).ToArray(), clientes);

                plt.Title("Total de compras por cliente");
                plt.YLabel("Total Comprado");
            }
            else if (tipo.Equals("Torta", StringComparison.OrdinalIgnoreCase))
            {
                plt.AddPie(valores).ShowLabels = true;
                plt.Title("Distribución de compras por cliente");
            }

            formsPlot1.Refresh();
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivo Excel|*.xlsx";
                    saveFileDialog.Title = "Guardar reporte Excel";
                    saveFileDialog.FileName = $"Reporte_Clientes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportarDataGridViewAExcel(dgvReporte, saveFileDialog.FileName);
                        MessageBox.Show("Reporte exportado exitosamente", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarDataGridViewAExcel(DataGridView dataGridView, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte");

                // Encabezados
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Datos
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        var value = dataGridView.Rows[row].Cells[col].Value;
                        worksheet.Cell(row + 2, col + 1).Value = value?.ToString() ?? "";
                    }
                }

                // Autoajustar columnas
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }
    }
}
