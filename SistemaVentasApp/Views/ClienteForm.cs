using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVentasApp.Controllers;
using SistemaVentasApp.Dto;

namespace SistemaVentasApp.Views
{
    public partial class ClienteForm : Form
    {
        private readonly ApiClient _apiClient;

        public ClienteForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void ClienteForm_Load(object sender, EventArgs e)
        {
            await LoadClientesAsync();
        }

        private async Task LoadClientesAsync()
        {
            try
            {
                var clientes = await _apiClient.Clientes.GetAllAsync();
                dgvCliente.DataSource = clientes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cliente = (ClienteDto)dgvCliente.Rows[e.RowIndex].DataBoundItem;
                txtPNombre.Text = cliente.PNombre;
                txtSNombre.Text = cliente.SNombre;
                txtPApellido.Text = cliente.PApellido;
                txtSApellido.Text = cliente.SApellido;
                txtCorreo.Text = cliente.Correo;
                txtTelefono.Text = cliente.Telefono;
            }
        }

        private void ClearInputFields()
        {
            txtPNombre.Clear();
            txtSNombre.Clear();
            txtPApellido.Clear();
            txtSApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newCliente = new ClienteCreateDto
            {
                PNombre = txtPNombre.Text,
                SNombre = txtSNombre.Text,
                PApellido = txtPApellido.Text,
                SApellido = txtSApellido.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            };
            try
            {

                var sucess = await _apiClient.Clientes.CreateAsync(newCliente);
                MessageBox.Show("¡Cliente agregado exitosamente!",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
                await LoadClientesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var selectedCliente = (ClienteDto)dgvCliente.SelectedRows[0].DataBoundItem;
                var updatedCliente = new ClienteUpdateDto
                {
                    IdCliente = selectedCliente.IdCliente,
                    PNombre = txtPNombre.Text,
                    SNombre = txtSNombre.Text,
                    PApellido = txtPApellido.Text,
                    SApellido = txtSApellido.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text
                };

                try
                {
                    var success =
                                await _apiClient.Clientes.UpdateAsync(selectedCliente.IdCliente, updatedCliente);

                    if (success)
                    {
                        MessageBox.Show("¡Cliente actualizado exitosamente!",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                        await LoadClientesAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar cliente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar cliente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Seleccione un cliente para actualizar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var selectedCliente = (ClienteDto)dgvCliente.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de que desea eliminar el " +
                    $"cliente '{selectedCliente.IdCliente}'?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                            await _apiClient.Clientes.DeleteAsync(selectedCliente.IdCliente);

                        if (sucess)
                        {
                            MessageBox.Show("¡Cliente eliminado exitosamente!", "¡Éxito!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadClientesAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Error al eliminar cliente.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar cliente: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un estudiante para eliminar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
