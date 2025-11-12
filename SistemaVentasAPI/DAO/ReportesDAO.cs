using Microsoft.Data.SqlClient;
using SistemaVentasAPI.Data;
using SistemaVentasAPI.Dto;
using System.Data;

namespace SistemaVentasAPI.DAO
{
    public class ReportesDAO
    {
        private readonly ConexionDB _conexion;

        public ReportesDAO(ConexionDB conexion)
        {
            _conexion = conexion;
        }

        public async Task<IEnumerable<ReporteClienteDto>> ReporteClientesAsync(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var lista = new List<ReporteClienteDto>();

            using var cn = _conexion.ObtenerConexion();
            await cn.OpenAsync();

            using var cmd = new SqlCommand(Procedimientos.SP_REPORTE_CLIENTES, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@fechaInicio", (object?)fechaInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@fechaFin", (object?)fechaFin ?? DBNull.Value);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lista.Add(new ReporteClienteDto
                {
                    IdCliente = Convert.ToInt32(reader["id_cliente"]),
                    Cliente = reader["Cliente"].ToString() ?? "",
                    Correo = reader["correo"].ToString() ?? "",
                    Telefono = reader["telefono"].ToString() ?? "",
                    CantidadPedidos = Convert.ToInt32(reader["CantidadPedidos"]),
                    TotalComprado = reader["TotalComprado"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalComprado"])
                });
            }

            return lista;
        }
    }
}
