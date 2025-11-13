using Newtonsoft.Json;
using SistemaVentasApp.Dto;
using SistemaVentasApp.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasApp.Models.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public UserRepository(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var credentials = new LoginRequest
            {
                NombreUsuario = username,
                Contrasena = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(credentials), 
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);

            if(response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                if(loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
                    return loginResponse.Token;

                throw new Exception("No se recibió el token del servidor.");
            }
            else
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error de autenticación: {response.StatusCode} - {errorText}");
            }

        }
    }
}
