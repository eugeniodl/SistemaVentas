using SistemaVentasAPI.DAO.Interfaces;
using SistemaVentasAPI.Models;
using SistemaVentasAPI.Services.Interfaces;

namespace SistemaVentasAPI.Services
{
    public class ClienteService : ServiceBase<Cliente>, IService<Cliente>
    {
        public ClienteService(IRepository<Cliente> repository) : base(repository) { }

        public override async Task<(bool ok, string error)> CrearAsync(Cliente c)
        {
            // Validación 1: Campos obligatorios
            if (string.IsNullOrWhiteSpace(c.PNombre) || string.IsNullOrWhiteSpace(c.PApellido))
                return (false, "Nombre y apellido son obligatorios.");

            // Validación 2: Regla de negocio específica
            if (!string.IsNullOrWhiteSpace(c.Correo) &&
                c.Correo.EndsWith("@example.com", StringComparison.OrdinalIgnoreCase))
                return (false, "Dominios de correo no válidos para registro.");

            // Llamamos al método base para insertar
            return await base.CrearAsync(c);
        }

        public override async Task<IEnumerable<Cliente>> ListarAsync() => await base.ListarAsync();
        public override async Task<Cliente?> ObtenerPorIdAsync(int id) => await base.ObtenerPorIdAsync(id);
        public override async Task<(bool ok, string error)> ActualizarAsync(Cliente c) => await base.ActualizarAsync(c);
        public override async Task<(bool ok, string error)> EliminarAsync(int id) => await base.EliminarAsync(id);
    }
}
