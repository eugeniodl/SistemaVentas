using SistemaVentasAPI.Models;

namespace SistemaVentasAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> ValidarUsuarioAsync(string nombreUsuario, string contrasena);
        Task<string> GenerarTokenAsync(Usuario usuario);
    }
}
