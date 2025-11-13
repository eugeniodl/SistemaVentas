using SistemaVentasApp.Dto;

namespace SistemaVentasAPI.Services.Interfaces
{
    public interface IReporteRepository
    {
        Task<IEnumerable<ReporteClienteDto>> ObtenerReporteClientes(DateTime? inicio, DateTime? fin);
    }
}
