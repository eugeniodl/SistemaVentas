using SistemaVentasAPI.Services.Interfaces;
using SistemaVentasApp.Dto;
using SistemaVentasApp.Models.Repository;
using SistemaVentasApp.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasApp.Controllers
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IRepository<ClienteDto> Clientes { get; }
        public IUserRepository LoginUsers { get; }
        public IReporteRepository Reportes { get; }

        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]!;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl)
            };
            Clientes = new Repository<ClienteDto>(_httpClient, "Clientes");
            LoginUsers = new UserRepository(_httpClient, "Auth/login");
            Reportes = new ReporteRepository(_httpClient, "Reportes/ClientesJson");
        }

        internal void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

    }
}
