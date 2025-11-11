namespace SistemaVentasApp.Dto
{
    public class ClienteCreateDto
    {
        public string PNombre { get; set; } = string.Empty;
        public string? SNombre { get; set; }
        public string PApellido { get; set; } = string.Empty;
        public string? SApellido { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string? Telefono { get; set; }
    }
}
