using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaVentasAPI.Dto;
using SistemaVentasAPI.Models;
using SistemaVentasAPI.Services.Interfaces;

namespace SistemaVentasAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IService<Cliente> _clienteService;
        private readonly ILogger<ClientesController> _logger;
        private readonly IMapper _mapper;

        public ClientesController(
            IService<Cliente> clienteService,
            ILogger<ClientesController> logger,
            IMapper mapper)
        {
            _clienteService = clienteService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes");

            var clientes = await _clienteService.ListarAsync();
            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientes));
        }

        [Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("ID de cliente no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            _logger.LogInformation("Obteniendo cliente con ID: {Id}", id);

            var cliente = await _clienteService.ObtenerPorIdAsync(id);
            if (cliente == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            return Ok(_mapper.Map<ClienteDto>(cliente));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClienteDto>> Create([FromBody] ClienteCreateDto createDto)
        {
            _logger.LogInformation("Creando nuevo cliente");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al crear cliente");
                return BadRequest(ModelState);
            }

            var cliente = _mapper.Map<Cliente>(createDto);
            var (ok, error) = await _clienteService.CrearAsync(cliente);

            if (!ok)
            {
                _logger.LogWarning("Error al crear cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            _logger.LogInformation("Cliente creado exitosamente con ID: {Id}", cliente.IdCliente);

            return CreatedAtAction(
                nameof(GetById),
                new { id = cliente.IdCliente },
                new { message = "Cliente creado exitosamente", cliente = clienteDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClienteDto>> Update(int id, [FromBody] ClienteUpdateDto updateDto)
        {
            _logger.LogInformation("Actualizando cliente con ID: {Id}", id);

            if (id != updateDto.IdCliente)
            {
                _logger.LogWarning("ID de ruta {Id} no coincide con ID del cuerpo {BodyId}",
                    id, updateDto.IdCliente);
                return BadRequest(new { error = "El ID del cliente no coincide" });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al actualizar cliente");
                return BadRequest(ModelState);
            }

            var existingCliente = await _clienteService.ObtenerPorIdAsync(id);
            if (existingCliente == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para actualizar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            _mapper.Map(updateDto, existingCliente);
            var (ok, error) = await _clienteService.ActualizarAsync(existingCliente);

            if (!ok)
            {
                _logger.LogWarning("Error al actualizar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var clienteDto = _mapper.Map<ClienteDto>(existingCliente);

            _logger.LogInformation("Cliente con ID {Id} actualizado exitosamente", id);

            return Ok(new { message = "Cliente actualizado exitosamente", cliente = clienteDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Eliminando cliente con ID: {Id}", id);

            if (id <= 0)
            {
                _logger.LogWarning("ID de cliente no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            var existingCliente = await _clienteService.ObtenerPorIdAsync(id);
            if (existingCliente == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para eliminar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            var (ok, error) = await _clienteService.EliminarAsync(id);

            if (!ok)
            {
                _logger.LogWarning("Error al eliminar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            _logger.LogInformation("Cliente con ID {Id} eliminado exitosamente", id);

            return NoContent();
        }
    }
}
