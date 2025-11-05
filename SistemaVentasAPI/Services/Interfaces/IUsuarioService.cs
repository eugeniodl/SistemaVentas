using SistemaVentasAPI.Models;

namespace SistemaVentasAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> ValidarUsuarioAsync(string usuario, string contrasena);
        Task<string> GenerarTokenAsync(Usuario usuario);
    }
}
