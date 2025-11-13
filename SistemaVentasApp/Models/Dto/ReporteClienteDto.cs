namespace SistemaVentasApp.Dto
{
    public class ReporteClienteDto
    {
        public int IdCliente { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int CantidadPedidos { get; set; }
        public decimal TotalComprado { get; set; }
    }
}
