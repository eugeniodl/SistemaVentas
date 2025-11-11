namespace SistemaVentasAPI.Dto
{
    public class ClienteUpdateDto
    {
        public int IdCliente { get; set; }
        public string PNombre { get; set; } = string.Empty;
        public string? SNombre { get; set; }
        public string PApellido { get; set; } = string.Empty;
        public string? SApellido { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string? Telefono { get; set; }
    }
}
