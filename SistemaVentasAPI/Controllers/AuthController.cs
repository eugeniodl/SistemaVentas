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
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUsuarioService usuarioService, 
            ILogger<AuthController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Intento de inicio de sesión para el usuario: {Usuario}",
                               request.NombreUsuario);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Datos de inicio de sesión inválidos para el usuario: {Usuario}",
                                                      request.NombreUsuario);
                return BadRequest(new { error = "Datos de entrada inválidos", detalles = ModelState });
            }

            var usuario = await _usuarioService.ValidarUsuarioAsync(request.NombreUsuario, 
                request.Contrasena);
            if (usuario == null)
            {
                _logger.LogWarning("Fallo en la autenticación para el usuario: {Usuario}",
                                                     request.NombreUsuario);
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }

            var token = await _usuarioService.GenerarTokenAsync(usuario);

            _logger.LogInformation("Inicio de sesión exitoso para el usuario: {Usuario}",
                                              request.NombreUsuario);
            var response = new LoginResponse
            {
                Token = token,
                Usuario = usuario.NombreUsuario,
                Rol = usuario.Rol,
                Expiracion = DateTime.UtcNow.AddHours(1)
            };
            return Ok(response);
        }
    }
}
