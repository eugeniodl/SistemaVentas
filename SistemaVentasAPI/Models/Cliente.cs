using System.ComponentModel.DataAnnotations;

namespace SistemaVentasAPI.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Required, StringLength(25)]
        public string PNombre { get; set; } = string.Empty;

        [StringLength(25)]
        public string? SNombre { get; set; }

        [Required, StringLength(25)]
        public string PApellido { get; set; } = string.Empty;

        [StringLength(25)]
        public string? SApellido { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Telefono { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
