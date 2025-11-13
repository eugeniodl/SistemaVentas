using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SistemaVentasAPI.Services.Interfaces;
using SistemaVentasApp.Dto;

namespace SistemaVentasApp.Models.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public ReporteRepository(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<IEnumerable<ReporteClienteDto>> ObtenerReporteClientes(DateTime? inicio, DateTime? fin)
        {
            var url = _endpoint;

            var queryParams = new List<string>();
            if (inicio.HasValue)
                queryParams.Add($"fechaInicio={inicio.Value:yyyy-MM-dd}");
            if (fin.HasValue)
                queryParams.Add($"fechaFin={fin.Value:yyyy-MM-dd}");

            if (queryParams.Any())
                url += "?" + string.Join("&", queryParams);

            // Realiza la solicitud HTTP GET
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al obtener reporte: {response.StatusCode} - {error}");
            }

            // Leer contenido y deserializar usando Newtonsoft.Json
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<ReporteClienteDto>>(json);

            return data ?? Enumerable.Empty<ReporteClienteDto>();
        }
    }
}
