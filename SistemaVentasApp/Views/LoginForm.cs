using SistemaVentasApp.Controllers;
using SistemaVentasApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentasApp
{
    public partial class LoginForm : Form
    {
        private readonly ApiClient _apiClient;
        public LoginForm()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private async Task LoginAsync()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                var token = await _apiClient.LoginUsers.ValidateCredentialsAsync(username, password);

                if (!string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Guardar el token en ApiClient para futuras solicitudes
                    _apiClient.SetAuthToken(token);

                    Hide();
                    var mainForm = new ClienteForm(_apiClient);
                    mainForm.Show();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"No se pudo conectar con el servidor. Detalles: {ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("La solicitud al servidor tardó demasiado. Intente de nuevo más tarde.",
                    "Tiempo de espera agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión:\n{ex.Message}",
                    "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
