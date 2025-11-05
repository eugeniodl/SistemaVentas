using System.ComponentModel.DataAnnotations;

namespace SistemaVentasAPI.Dto
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Pass { get; set; } = string.Empty;
    }
}
