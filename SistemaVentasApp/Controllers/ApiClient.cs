using SistemaVentasApp.Models.Repository;
using SistemaVentasApp.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasApp.Controllers
{
    internal class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IUserRepository LoginUsers { get; }

        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]!; 
            _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl)};
            LoginUsers = new UserRepository(_httpClient, "Auth/login");
        }

        internal void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
