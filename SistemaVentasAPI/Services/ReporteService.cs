using SistemaVentasAPI.DAO;
using SistemaVentasAPI.Dto;
using SistemaVentasAPI.Services.Interfaces;

namespace SistemaVentasAPI.Services
{
    public class ReporteService : IReporteService
    {
        private readonly ReportesDAO _dao;

        public ReporteService(ReportesDAO dao)
        {
            _dao = dao;
        }

        public Task<IEnumerable<ReporteClienteDto>> ObtenerReporteClientes(DateTime? inicio, DateTime? fin)
            => _dao.ReporteClientesAsync(inicio, fin);
    }
}
