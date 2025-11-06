using Microsoft.AspNetCore.Mvc;
using SistemaVentasAPI.Dto;
using SistemaVentasAPI.Services.Interfaces;

namespace SistemaVentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _usuarioService.ValidarUsuarioAsync(request.NombreUsuario, 
                request.Contrasena);
            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }

            var token = _usuarioService.GenerarToken(usuario);
            return Ok(new { token });
        }
    }
}
