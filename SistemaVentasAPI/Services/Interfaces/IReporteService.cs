using SistemaVentasAPI.Dto;

namespace SistemaVentasAPI.Services.Interfaces
{
    public interface IReporteService
    {
        Task<IEnumerable<ReporteClienteDto>> ObtenerReporteClientes(DateTime? inicio, DateTime? fin);
    }
}
