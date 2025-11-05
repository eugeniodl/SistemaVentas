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

        public AuthController(IUsuarioService usuarioService, ILogger<AuthController> logger)
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
            _logger.LogInformation("Intento de login para usuario: {Usuario}", request.User);

            // Validación del modelo - el ExceptionMiddleware capturará cualquier excepción
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido en login para usuario: {Usuario}", request.User);
                return BadRequest(new { error = "Datos de entrada inválidos", detalles = ModelState });
            }

            var usuario = await _usuarioService.ValidarUsuarioAsync(request.User, request.Pass);

            if (usuario == null)
            {
                _logger.LogWarning("Credenciales incorrectas para usuario: {Usuario}", request.User);
                return Unauthorized(new { error = "Credenciales incorrectas" });
            }

            var token = await _usuarioService.GenerarTokenAsync(usuario);

            _logger.LogInformation("Login exitoso para usuario: {Usuario}, Rol: {Rol}",
                usuario.NombreUsuario, usuario.Rol);

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
